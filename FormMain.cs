#define OldSettingsUpdate
#define DisableMain
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace HazeronWatcher
{
    public partial class FormMain : Form
    {
        const string URL_PLAYERSON = @"http://www.hazeron.com/playerson.html";

        string _appdataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HazeronWatcher"); // %USERPROFILE%\AppData\Roaming\HazeronWatcher
        const string SETTINGS = "HazeronWatcherSettings.xml";
        const string NOTIFICATION = "Notification.wav";
        HazeronWatcherSettings _settingsXml;

        DateTime _lastUpdated = DateTime.MinValue;
        int _numRetries = 0;
        int _numOnline = 0;
        Dictionary<string, Avatar> _avatarList;

        Icon _iconLit = HazeronWatcher.Properties.Resources.Psyker_s_lit_tray_icon;
        Icon _iconUnlit = HazeronWatcher.Properties.Resources.Psyker_s_unlit_tray_icon;
        //Icon _iconError = HazeronWatcher.Properties.Resources.Psyker_s_error_tray_icon; // Icon needed!
        Icon _iconError = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

        public FormMain()
        {
            InitializeComponent();

#if DEBUG
            this.Text += " (DEBUG MODE)";
#endif
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon1.BalloonTipTitle = this.Text;
            notifyIcon1.Text = this.Text;
            notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

#if DisableMain
            cmsListRightClickMain.Visible = false;
            cmsListRightClickMain.Click -= cmsListRightClickMain_Click;
#endif

            // Make sure the AppData folder exist.
            if (!Directory.Exists(_appdataFolder))
                Directory.CreateDirectory(_appdataFolder);
#if OldSettingsUpdate
            // If there is no "HazeronWatcherSettings.xml" and there is a "Settings.xml".
            if (!File.Exists(Path.Combine(_appdataFolder, SETTINGS)) && File.Exists(Path.Combine(_appdataFolder, "Settings.xml")))
            {
                if (!File.Exists(Path.Combine(_appdataFolder, "Settings (v1.1 backup).xml")))
                {
                    // Load the old "Settings.xml".
                    HazeronWatcherOLD.HazeronWatcherSettings oldSettingsXml = HazeronWatcherOLD.HazeronWatcherSettings.Load(Path.Combine(_appdataFolder, "Settings.xml"));
                    // Convert the old "Settings.xml" into a new "HazeronWatcherSettings.xml".
                    _settingsXml = new HazeronWatcherSettings();
                    foreach (HazeronWatcherOLD.Player oldPlayer in oldSettingsXml.PlayerList)
                        _settingsXml.AvatarList.Avatar.Add(oldPlayer.ToAvatar());
                    _settingsXml.Options.ShowIdColumn = oldSettingsXml.ShowIdColumn;
                    _settingsXml.Options.ShowWatchHighlight = oldSettingsXml.ShowWatchHighlight;
                    _settingsXml.Options.PlaySound = oldSettingsXml.PlaySound;
                    // Rename the old "Settings.xml" to "Settings (v1.1 backup).xml".
                    File.Move(Path.Combine(_appdataFolder, "Settings.xml"), Path.Combine(_appdataFolder, "Settings (v1.1 backup).xml"));
                    // Save the new "HazeronWatcherSettings.xml" and continue as if this never happened.
                    _settingsXml.Save(Path.Combine(_appdataFolder, SETTINGS));
                }
                else
                {
                    DialogResult question = MessageBox.Show(this,
                        "It seems that both \"Settings.xml\" and \"Settings (v1.1 backup).xml\" files exist." + Environment.NewLine +
                        "In fear of messing up your settings, please go to HazeronWatcher's AppData folder and remove the incorrect file." + Environment.NewLine +
                        "" + Environment.NewLine +
                        "Would you like to open HazeronWatcher's AppData folder now?"
                        , "Settings File Update Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    if (question == DialogResult.Yes)
                        System.Diagnostics.Process.Start(_appdataFolder);
                    throw new FileLoadException("Cannot convert the \"Settings.xml\" file because a \"Settings (v1.1 backup).xml\" file already exist.", Path.Combine(_appdataFolder, "Settings.xml"));
                }
            }
#endif
            // Load the settings XML file if there is one.
            if (File.Exists(Path.Combine(_appdataFolder, SETTINGS)))
                _settingsXml = HazeronWatcherSettings.Load(Path.Combine(_appdataFolder, SETTINGS));
            else
                _settingsXml = new HazeronWatcherSettings();
            // Get data from the settings.
            _avatarList = _settingsXml.AvatarList.Avatar.ToDictionary(x => x.ID);
            foreach (Avatar avatar in _avatarList.Values)
                AddAvatarToDGV(avatar);
            menuStrip1OptionsAvatarIds.Checked = !_settingsXml.Options.ShowIdColumn;
            menuStrip1OptionsAvatarIds_Click(null, null);
            menuStrip1OptionsWatchHighlight.Checked = _settingsXml.Options.ShowWatchHighlight;
            menuStrip1OptionsWatchList.Checked = !_settingsXml.Options.ShowWatchList;
            menuStrip1OptionsWatchList_Click(null, null);
            menuStrip1OptionsRecentList.Checked = !_settingsXml.Options.ShowRecentList;
            menuStrip1OptionsRecentList_Click(null, null);
            menuStrip1OptionsNotificationSound.Checked = _settingsXml.Options.PlaySound;
            menuStrip1OptionsMinimizeTray.Checked = _settingsXml.Options.MinimizeToTray;

            //// Create the "Notification.wav" file if it doesn't exist.
            //if (!File.Exists(Path.Combine(_appdataFolder, NOTIFICATION)))
            //{
            //    using (System.IO.Stream stream = HazeronWatcher.Properties.Resources.communi2)
            //    {
            //        using (System.IO.FileStream fileStream = new System.IO.FileStream(Path.Combine(_appdataFolder, NOTIFICATION), System.IO.FileMode.Create))
            //        {
            //            for (int i = 0; i < stream.Length; i++)
            //            {
            //                fileStream.WriteByte((byte)stream.ReadByte());
            //            }
            //            fileStream.Close();
            //        }
            //    }
            //}

            // Set the DataGridView colors and fonts.
            dgvOnline.DefaultCellStyle.BackColor = Color.Black;
            dgvOnline.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvOnline.Columns["dgvOnlineColumnID"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvWatch.DefaultCellStyle.BackColor = Color.Black;
            dgvWatch.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvWatch.Columns["dgvWatchColumnID"].DefaultCellStyle.Font = new Font("Lucida Console", 9);

            cbxStandingFilter.SelectedIndex = 0;

            // Run the tick once and start the looping timer.
            timer1_Tick(null, null);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool skip = false;
            List<string> httpDoc = new List<string>();
            List<string> onlineNow = new List<string>();
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL_PLAYERSON);
                request.IfModifiedSince = _lastUpdated;
                request.Timeout = 5000;
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream receiveStream = response.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(receiveStream, Encoding.UTF8);
                        string httpLine = sr.ReadLine();
                        const string HTTPLINE_FIRST = "<html><head><meta content=\"text/html;charset=UTF-8\" http-equiv=\"Content-Type\"><title>Shores of Hazeron - Avatars Online</title></head>";
                        if (httpLine == HTTPLINE_FIRST)
                        {
                            while ((httpLine = sr.ReadLine()) != null)
                            {
                                httpDoc.Add(httpLine);
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                if (response != null && response.StatusCode == HttpStatusCode.NotModified)
                {
                    _lastUpdated = DateTime.Now;
                    _numRetries = 0;
                }
                else
                    _numRetries++;

                if (_numRetries >= 2)
                {
                    // Change notifyIcon's icon to error version.
                    notifyIcon1.Icon = _iconError;
                    // Set the notifyIcon tooltip.
                    notifyIcon1.Text = this.Text + Environment.NewLine
                        + "Connection error! Retrying...";
                    // Set the toolStripStatusLabel text.
                    toolStripStatusLabel1.Text = "Connection error! Retrying... (" + _lastUpdated.ToString(Hazeron.DateTimeFormat) + ")";
                }

                skip = true;
            }
            if (skip)
                return;

            // Save the time.
            _lastUpdated = DateTime.Now;
            _numRetries = 0;

            // Go through the HTTP page line by line.
            bool avatarsSection = false;
            foreach (string httpLine in httpDoc)
            {
                const string HTTPLINE_AVATAR_START = "<tbody><tr><td colspan=\"2\" style=\"vertical-align: top; background-color: rgb(16,16,100);\"><small><b>Avatar</b><br></small></td></tr>";
                const string HTTPLINE_AVATAR_END = "</tbody>";
                if (avatarsSection)
                {
                    if (httpLine == HTTPLINE_AVATAR_END)
                        break;
                    const string EMPIRE_START = "src=\"http://Hazeron.com/EmpireStandings2015/";
                    const string EMPIRE_END = ".png\"></a>";
                    const string AVATAR_START = "href=\"http://Hazeron.com/EmpireStandings2015/p";
                    const string AVATAR_MIDDLE = ".html\">";
                    const string AVATAR_END = "</a></small></td></tr>";
                    int startIndex = httpLine.IndexOf(EMPIRE_START) + EMPIRE_START.Length;
                    int endIndex = httpLine.IndexOf(EMPIRE_END) - startIndex;
                    int empireId = Convert.ToInt32(httpLine.Substring(startIndex, endIndex));
                    startIndex = httpLine.LastIndexOf(AVATAR_START) + AVATAR_START.Length;
                    endIndex = httpLine.LastIndexOf(AVATAR_MIDDLE) - startIndex;
                    string avatarId = httpLine.Substring(startIndex, endIndex);
                    Avatar avatar;
                    if (!_avatarList.ContainsKey(avatarId))
                    {
                        startIndex = httpLine.LastIndexOf(AVATAR_MIDDLE) + AVATAR_MIDDLE.Length;
                        endIndex = httpLine.LastIndexOf(AVATAR_END) - startIndex;
                        string avatarName = httpLine.Substring(startIndex, endIndex);
                        avatar = new Avatar(avatarName, avatarId);
                        _avatarList.Add(avatarId, avatar);
                        AddAvatarToDGV(avatar);
                    }
                    else
                        avatar = _avatarList[avatarId];
                    avatar.Empire = empireId;
                    onlineNow.Add(avatarId);
                }
                else if (httpLine.EndsWith(" avatars are currently online.</span><br><br>"))
                {
                    const string AVATARS_START = "<div style=\"text-align: center; font-family: sans-serif;\"><big style=\"font-weight: bold;\">Avatars Online</big></div><br><span style=\"font-family: sans-serif;\">";
                    const string AVATARS_END = " avatars are currently online.</span><br><br>";
                    string numberAvatars = httpLine.Remove(httpLine.Length - AVATARS_END.Length).Substring(AVATARS_START.Length);
                    //if (numberAvatars != "No")
                    //    _numOnline = Convert.ToInt32(numberAvatars);
                    //else
                    //    _numOnline = 0;
                    if (!Int32.TryParse(numberAvatars, out _numOnline))
                        _numOnline = 0;
                    toolStripStatusLabel1.Text = _numOnline.ToString() + " avatars online";
                }
                else if (httpLine == HTTPLINE_AVATAR_START)
                {
                    avatarsSection = true;
                }
            }

            // Go through each avatar in the avatar list.
            foreach (Avatar avatar in _avatarList.Values)
            {
                if (onlineNow.Contains(avatar.ID))
                {
                    // Check if the avatar is watched and was offline last check.
                    if (avatar.Watch && !avatar.Online)
                    {
                        OnlineNotification(avatar);
                    }
                    // Set the status to online.
                    avatar.Online = true;
                    avatar.OnlineRow.Visible = true;
                    avatar.RecentRow.Visible = true;
                }
                else
                {
                    avatar.Online = false;
                    avatar.OnlineRow.Visible = false;
                }
            }

            // Change the notifyIcon if there are watched avatars online.
            if (_avatarList.Values.Any(x => x.Watch && x.Online))
            {
                // Change notifyIcon's icon to lit version.
                notifyIcon1.Icon = _iconLit;
                // Add list of online watched avatars to the notifyIcon tooltip.
                string watchNames = this.Text;
                int watchExtra = 0;
                foreach (string avatarId in onlineNow)
                {
                    if (_avatarList[avatarId].Watch)
                    {
                        string avatarName = _avatarList[avatarId].ToString();
                        if (watchExtra == 0 && (watchNames.Length + 3 + avatarName.Length) < 50)
                            watchNames += Environment.NewLine + "• " + avatarName;
                        else
                            watchExtra++;
                    }
                }
                notifyIcon1.Text = watchNames;
                if (watchExtra > 0)
                    notifyIcon1.Text += Environment.NewLine + "And " + watchExtra + " more";
            }
            else
            {
                // Change notifyIcon's icon to unlit version.
                notifyIcon1.Icon = _iconUnlit;
                // Clear the notifyIcon tooltip.
                notifyIcon1.Text = this.Text;
            }

            // Update the lists with colors and check the watch list.
            UpdateDGV();
        }

        public void OnlineNotification(Avatar avatar)
        {
            // Notify popup message.
            TrayBalloonTip(avatar.Name + " has come online");

            // Play notification sound.
            if (menuStrip1OptionsNotificationSound.Checked)
            {
                if (File.Exists(Path.Combine(_appdataFolder, NOTIFICATION)))
                    using (System.Media.SoundPlayer notificationSound = new System.Media.SoundPlayer(Path.Combine(_appdataFolder, NOTIFICATION)))
                        notificationSound.Play();
                else
                {
                    using (System.IO.Stream s = HazeronWatcher.Properties.Resources.communi2)
                    {
                        System.Media.SoundPlayer notificationSound = new System.Media.SoundPlayer(s);
                        notificationSound.Play();
                    }
                }
            }
        }

        public Avatar GetAvatar(string id)
        {
            Avatar avatar;
            if (_avatarList.ContainsKey(id))
                avatar = _avatarList[id];
            else
            {
                try
                {
                    avatar = Avatar.GetAvatar(id);
                }
                catch (HazeronAvatarNotFoundException)
                {
                    MessageBox.Show(this,
                        "There is no avatar with that ID."
                        , "Avatar Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                _avatarList.Add(id, avatar);
                AddAvatarToDGV(avatar);
            }
            return avatar;
        }

        public void AddAvatarToDGV(Avatar avatar)
        {
            // Online list
            dgvOnline.Rows.Add();
            avatar.OnlineRow = dgvOnline.Rows[dgvOnline.RowCount - 1];
            avatar.OnlineRow.Visible = false;
            avatar.OnlineRow.Cells["dgvOnlineColumnID"].Value = avatar.ID;
            avatar.OnlineRow.Cells["dgvOnlineColumnAvatar"].Value = avatar;
            dgvOnline.Sort(dgvOnlineColumnAvatar, ListSortDirection.Ascending);
            // Recent list
            dgvRecent.Rows.Add();
            avatar.RecentRow = dgvRecent.Rows[dgvRecent.RowCount - 1];
            avatar.RecentRow.Visible = false;
            avatar.RecentRow.Cells["dgvRecentColumnID"].Value = avatar.ID;
            avatar.RecentRow.Cells["dgvRecentColumnAvatar"].Value = avatar;
            dgvRecent.Sort(dgvRecentColumnAvatar, ListSortDirection.Ascending);
        }

        public void UpdateDGV()
        {
            foreach (Avatar avatar in _avatarList.Values)
            {
                Color relationColor;
                if (avatar.RelationEmpire)
                    relationColor = Color.FromArgb(90, 110, 255); // Blue
                else if (avatar.RelationFriend)
                    relationColor = Color.FromArgb(50, 240, 50); // Green
                else if (avatar.RelationUnsure)
                    relationColor = Color.Yellow;
                else if (avatar.RelationEnemy)
                    relationColor = Color.Red;
                else
                    relationColor = Color.White;

                int watchColorOffset;
                if (menuStrip1OptionsWatchHighlight.Checked && avatar.Watch)
                    watchColorOffset = 40;
                else
                    watchColorOffset = 0;

                // Update colors and note for dgvOnline
                avatar.OnlineRow.DefaultCellStyle.ForeColor = relationColor;
                avatar.OnlineRow.DefaultCellStyle.SelectionForeColor = relationColor;
                avatar.OnlineRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 0 + watchColorOffset, 0 + watchColorOffset); // Black
                avatar.OnlineRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30 + watchColorOffset, 30 + watchColorOffset); // Dark Gray
                foreach (DataGridViewCell cell in avatar.OnlineRow.Cells)
                    cell.ToolTipText = avatar.Note;

                // Is that avatar watch listed in anyway?
                if (avatar.IsWatchListed)
                {
                    if (avatar.WatchRow == null)
                    {
                        dgvWatch.Rows.Add();
                        avatar.WatchRow = dgvWatch.Rows[dgvWatch.RowCount - 1];
                        avatar.WatchRow.Cells["dgvWatchColumnId"].Value = avatar.ID;
                        avatar.WatchRow.Cells["dgvWatchColumnAvatar"].Value = avatar;
                        dgvWatch.Sort(dgvWatchColumnAvatar, ListSortDirection.Ascending);
                    }
                    avatar.WatchRow.Visible = (avatar.Watch || !chxHideNonWatched.Checked)
                                          && (cbxStandingFilter.SelectedItem == "Show all"
                                           || (avatar.RelationEmpire && cbxStandingFilter.SelectedItem == "Empire")
                                           || (avatar.RelationFriend && cbxStandingFilter.SelectedItem == "Friend")
                                           || (avatar.Relation == 0 && cbxStandingFilter.SelectedItem == "Neutral")
                                           || (avatar.RelationUnsure && cbxStandingFilter.SelectedItem == "Unsure")
                                           || (avatar.RelationEnemy && cbxStandingFilter.SelectedItem == "Enemy")
                                             );
                    // Update colors and note for dgvWatch
                    avatar.WatchRow.DefaultCellStyle.ForeColor = relationColor;
                    avatar.WatchRow.DefaultCellStyle.SelectionForeColor = relationColor;
                    avatar.WatchRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 0 + watchColorOffset, 0 + watchColorOffset); // Black
                    avatar.WatchRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30 + watchColorOffset, 30 + watchColorOffset); // Dark Gray
                    foreach (DataGridViewCell cell in avatar.WatchRow.Cells)
                        cell.ToolTipText = avatar.Note;
                }
                else if (avatar.WatchRow != null)
                {
                    dgvWatch.Rows.Remove(avatar.WatchRow);
                    avatar.WatchRow = null;
                }

                // Update colors and note for dgvRecent
                avatar.RecentRow.DefaultCellStyle.ForeColor = relationColor;
                avatar.RecentRow.DefaultCellStyle.SelectionForeColor = relationColor;
                avatar.RecentRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 0 + watchColorOffset, 0 + watchColorOffset); // Black
                avatar.RecentRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30 + watchColorOffset, 30 + watchColorOffset); // Dark Gray
                foreach (DataGridViewCell cell in avatar.RecentRow.Cells)
                    cell.ToolTipText = avatar.Note;
            }

            // Invalidate the tables so "ToString()" methods updates.
            dgvOnline.Invalidate();
            dgvWatch.Invalidate();
        }

        #region Buttons
        private void cbxStandingFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void chxHideNonWatched_Click(object sender, EventArgs e)
        {
            chxHideNonWatched.Checked = !chxHideNonWatched.Checked;
            UpdateDGV();
        }

        private void btnAddAvatar_Click(object sender, EventArgs e)
        {
            FormInput inputDialog = new FormInput("Add Avatar", "Enter the avatar's ID.");
            if (inputDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            string id = inputDialog.ReturnInput.Trim();
            if (!Hazeron.ValidID(id))
            {
                MessageBox.Show(this, "Invalid input, please enter a valid avatar ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Avatar avatar = GetAvatar(id);
            if (avatar == null)
                return;
            avatar.Watch = true;
            UpdateDGV();
        }
        #endregion

        #region menuStrip1
        private void menuStrip1FileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1OptionsAvatarIds_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsAvatarIds.Checked = !menuStrip1OptionsAvatarIds.Checked;
            dgvOnlineColumnId.Visible = menuStrip1OptionsAvatarIds.Checked;
            dgvWatchColumnId.Visible = menuStrip1OptionsAvatarIds.Checked;
            dgvRecentColumnId.Visible = menuStrip1OptionsAvatarIds.Checked;
        }

        private void menuStrip1OptionsWatchHighlight_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsWatchHighlight.Checked = !menuStrip1OptionsWatchHighlight.Checked;
            UpdateDGV();
        }

        private void menuStrip1OptionsWatchList_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsWatchList.Checked = !menuStrip1OptionsWatchList.Checked;
            splitContainer1.Panel2Collapsed = !menuStrip1OptionsWatchList.Checked;
            if (menuStrip1OptionsWatchList.Checked)
                splitContainer1.Panel2.Show();
            else
                splitContainer1.Panel2.Hide();
        }

        private void menuStrip1OptionsRecentList_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsRecentList.Checked = !menuStrip1OptionsRecentList.Checked;
            splitContainer2.Panel2Collapsed = !menuStrip1OptionsRecentList.Checked;
            if (menuStrip1OptionsRecentList.Checked)
                splitContainer2.Panel2.Show();
            else
                splitContainer2.Panel2.Hide();
        }

        private void menuStrip1OptionsNotificationSound_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsNotificationSound.Checked = !menuStrip1OptionsNotificationSound.Checked;
        }

        private void menuStrip1OptionsMinimizeTray_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsMinimizeTray.Checked = !menuStrip1OptionsMinimizeTray.Checked;
        }

        private void menuStrip1HelpGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/Deantwo/HazeronWatcher");
        }

        private void menuStrip1HelpThread_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://hazeron.com/phpBB3/viewtopic.php?f=124&t=7642#p85789");
        }

        private void menuStrip1HelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Program:" + Environment.NewLine +
                "   HazeronWatcher" + Environment.NewLine +
                "" + Environment.NewLine +
                "Version:" + Environment.NewLine +
                "   v" + Application.ProductVersion + Environment.NewLine +
                "" + Environment.NewLine +
                "Creator:" + Environment.NewLine +
                "   Deantwo" + Environment.NewLine +
                "" + Environment.NewLine +
                "Feedback, suggestions, and bug reports should be posted in the forum thread or PMed to Deantwo please."
                , "About HazeronWatcher", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void menuStrip1HelpHowToUse_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Adding offline avatars:" + Environment.NewLine +
                "1.  Go to the avatar list on www.Hazeron.com" + Environment.NewLine +
                "2.  Get the ID of the avatar" + Environment.NewLine +
                "4.  Start HazeronWatcher (which you already have done!)" + Environment.NewLine +
                "5.  Click the \"Add Avatar via ID\" button above the watchlist" + Environment.NewLine +
                "6.  Enter the avatar's ID" + Environment.NewLine +
                "7.  Click OK" + Environment.NewLine +
                "" + Environment.NewLine +
                "Change notifiication sound:" + Environment.NewLine +
                "1.  Open HazeronWatcher's AppData folder" + Environment.NewLine +
                "     \"" + _appdataFolder + "\"" + Environment.NewLine +
                "2.  Move the desired .wav file to the folder" + Environment.NewLine +
                "3.  Rename the file to \"Notification.wav\""
                , "How to use HazeronWatcher", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }
        #endregion

        #region DataGridView
        private void dgv_Click(object sender, EventArgs e)
        {
            if (sender != null && (sender as DataGridView) != dgvOnline)
                dgvOnline.ClearSelection();
            if (sender != null && (sender as DataGridView) != dgvWatch)
                dgvWatch.ClearSelection();
            if (sender != null && (sender as DataGridView) != dgvRecent)
                dgvRecent.ClearSelection();
        }
        #endregion

        #region DataGridView ContextMenu RightClick
        private Control _cmsRightClickSourceControl;

        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridView dgv = (sender as DataGridView);
                _cmsRightClickSourceControl = (dgv as Control);

                // Get and set current cell from mouse location.
                DataGridViewCell currentCell = dgv[e.ColumnIndex, e.RowIndex];
                dgv.ClearSelection();
                dgv.CurrentCell = currentCell;
                currentCell.Selected = true;

                //Show the ContextMenuStrip.
                dgv.ContextMenuStrip = cmsListRightClick;
                Point p = dgv.PointToClient(Control.MousePosition);
                dgv.ContextMenuStrip.Show(dgv, p);
                dgv.ContextMenuStrip = null;
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            DataGridView dgv = (sender as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            _cmsRightClickSourceControl = (dgv as Control);
            if (currentCell != null)
            {
                if ((e.KeyCode == Keys.F10 && !e.Control && e.Shift) || e.KeyCode == Keys.Apps)
                {
                    //Show the ContextMenuStrip.
                    dgv.ContextMenuStrip = cmsListRightClick;
                    Rectangle r = dgv.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                    Point p = new Point(r.X, r.Y + r.Height);
                    dgv.ContextMenuStrip.Show(dgv, p);
                    dgv.ContextMenuStrip = null;
                }
                else if (e.KeyCode == Keys.C && e.Control && !e.Shift)
                    cmsListRightClickCopy_Click(sender, null);
            }
        }

        private void cmsRightClick_Opening(object sender, CancelEventArgs e)
        {
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            cmsListRightClickStanding.Checked = avatar.Relation != 0;
            cmsListRightClickStandingEmpire.Checked = avatar.RelationEmpire;
            cmsListRightClickStandingEmpire.Text = (avatar.RelationEmpire ? "Unset" : "Set") + " Empire";
            cmsListRightClickStandingFriend.Checked = avatar.RelationFriend;
            cmsListRightClickStandingFriend.Text = (avatar.RelationFriend ? "Unset" : "Set") + " Friend";
            cmsListRightClickStandingUnsure.Checked = avatar.RelationUnsure;
            cmsListRightClickStandingUnsure.Text = (avatar.RelationUnsure ? "Unset" : "Set") + " Unsure";
            cmsListRightClickStandingEnemy.Checked = avatar.RelationEnemy;
            cmsListRightClickStandingEnemy.Text = (avatar.RelationEnemy ? "Unset" : "Set") + " Enemy";
            cmsListRightClickWatch.Checked = avatar.Watch;
            cmsListRightClickWatch.Text = (avatar.Watch ? "Remove from" : "Add to") + " Watch";
            cmsListRightClickMain.Checked = !String.IsNullOrEmpty(avatar.MainID);
            cmsListRightClickMain.Text = (String.IsNullOrEmpty(avatar.MainID) ? "Set" : "Unset") + " Main";
            cmsListRightClickNote.Checked = !String.IsNullOrEmpty(avatar.Note);
            cmsListRightClickNote.Text = (String.IsNullOrEmpty(avatar.Note) ? "Add" : "Edit") + " Note";
        }

        private void cmsListRightClickCopy_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            // Check if the cell is empty.
            if (!String.IsNullOrEmpty(currentCell.Value.ToString()))
            { // If not empty, add to clipboard and inform the user.
                Clipboard.SetText(currentCell.Value.ToString());
                toolStripStatusLabel1.Text = "Cell content copied to clipboard (\"" + currentCell.Value.ToString() + "\")";
            }
            else
            { // Inform the user the cell was empty and therefor no reason to erase the clipboard.
                toolStripStatusLabel1.Text = "Cell is empty";
#if DEBUG
                // Debug code to see if the cell is null or "".
                if (currentCell.Value == null)
                    toolStripStatusLabel1.Text += " (null)";
                else
                    toolStripStatusLabel1.Text += " (\"\")";
#endif
            }
        }

        private void cmsListRightClickAvatar_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            System.Diagnostics.Process.Start(@"http://Hazeron.com/EmpireStandings2015/p" + avatar.ID + ".html");
        }

        private void cmsListRightClickRecheck_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            try
            {
                avatar.RecheckName();
            }
            catch (HazeronAvatarNotFoundException)
            {
                if (avatar.IsWatchListed)
                {
                    DialogResult confimation = MessageBox.Show(this,
                        "There is no avatar with that ID." + Environment.NewLine +
                        "The avatar may have been deleted." + Environment.NewLine +
                        "" + Environment.NewLine +
                        "Would you like to remove the avatar from watch list?"
                        , "Avatar Not Found, Unwatch?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (confimation == DialogResult.Yes)
                    {
                        avatar.Unlist();
                    }
                }
                else
                    MessageBox.Show(this,
                        "There is no avatar with that ID." + Environment.NewLine +
                        "The avatar may have been deleted."
                        , "Avatar Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateDGV();
        }

        private void cmsListRightClickStandingEmpire_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            if (avatar.RelationEmpire)
                avatar.Relation = 0;
            else
                avatar.Relation = 2;
            UpdateDGV();
        }

        private void cmsListRightClickStandingFriend_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            if (avatar.RelationFriend)
                avatar.Relation = 0;
            else
                avatar.Relation = 1;
            UpdateDGV();
        }

        private void cmsListRightClickStandingUnsure_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            if (avatar.RelationUnsure)
                avatar.Relation = 0;
            else
                avatar.Relation = -1;
            UpdateDGV();
        }

        private void cmsListRightClickStandingEnemy_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            if (avatar.RelationEnemy)
                avatar.Relation = 0;
            else
                avatar.Relation = -2;
            UpdateDGV();
        }

        private void cmsListRightClickWatch_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            avatar.Watch = !avatar.Watch;
            UpdateDGV();
        }

        private void cmsListRightClickMain_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
#if !DisableMain
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;

            if (String.IsNullOrEmpty(avatar.MainID))
            {
                FormInput inputDialog = new FormInput("Set Main", "Enter the player's main avatar's ID.", avatar.MainID);
                if (inputDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                    return;
                string mainId = inputDialog.ReturnInput.Trim();
                if (!Hazeron.ValidID(mainId))
                {
                    MessageBox.Show(this, "Invalid input, please enter a valid avatar ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Avatar mainAvatar;
                if (!_avatarList.ContainsKey(mainId) ||
                    (_avatarList.ContainsKey(mainId) && !_avatarList[mainId].IsWatchListed)
                    )
                {
                    bool list = MessageBox.Show(this,
                        "The entered avatar ID is not on the watch list." + Environment.NewLine +
                        "´The avatar has to be on your watch list, either just as a having a note, relationship or watched." + Environment.NewLine +
                        "" + Environment.NewLine +
                        "Would you like to try and set the avatar to watch?"
                        , "Invalid Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes;
                    mainAvatar = GetAvatar(mainId);
                    if (mainAvatar == null)
                        return;
                    mainAvatar.Watch = true;
                }

                avatar.MainID = mainId;
            }
            else
                avatar.MainID = "";
            UpdateDGV();
#endif
        }

        private void cmsListRightClickNote_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            Avatar player = (Avatar)dgv.CurrentRow.Cells[1].Value;
            FormInput inputBox = new FormInput(player.Name + " Note", "Writie notes for the character below." + Environment.NewLine + "Player: " + player.Name + " (" + player.ID + ")", player.Note, FormInputOptions.Multiline);
            if (inputBox.ShowDialog(this) == DialogResult.OK)
                player.Note = inputBox.ReturnInput;
            UpdateDGV();
        }
        #endregion

        #region Minimize to Tray
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (menuStrip1OptionsMinimizeTray.Checked)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    TrayBalloonTip("Minimized to tray");
                    this.ShowInTaskbar = false;
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void cmsNotifyIconRightClickRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void TrayBalloonTip(string message, ToolTipIcon toolTipIcon = ToolTipIcon.None, int time = 500)
        {
            notifyIcon1.BalloonTipIcon = toolTipIcon;
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.ShowBalloonTip(time);
        }
        #endregion
        
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (!Directory.Exists(_appdataFolder))
                Directory.CreateDirectory(_appdataFolder);
            _settingsXml.AvatarList.Avatar = _avatarList.Values.Where(x => x.IsWatchListed).ToList();
            _settingsXml.Options.ShowIdColumn = menuStrip1OptionsAvatarIds.Checked;
            _settingsXml.Options.ShowWatchHighlight = menuStrip1OptionsWatchHighlight.Checked;
            _settingsXml.Options.ShowWatchList = menuStrip1OptionsWatchList.Checked;
            _settingsXml.Options.ShowRecentList = menuStrip1OptionsRecentList.Checked;
            _settingsXml.Options.PlaySound = menuStrip1OptionsNotificationSound.Checked;
            _settingsXml.Options.MinimizeToTray = menuStrip1OptionsMinimizeTray.Checked;
            _settingsXml.Save(Path.Combine(_appdataFolder, SETTINGS));
        }
    }
}
