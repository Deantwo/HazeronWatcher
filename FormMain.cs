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
        string _appdataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HazeronWatcher"); // %USERPROFILE%\AppData\Roaming\HazeronWatcher
        const string SETTINGS = "HazeronWatcherSettings.xml";
        const string NOTIFICATION = "Notification.wav";
        HazeronWatcherSettings _settingsXml;

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
            menuStrip1OptionsNotificationSound.Checked = _settingsXml.Options.PlaySound;

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
            // Request the HTTP page.
            string[] httpArray = null;
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    httpArray = client.DownloadString(@"http://www.hazeron.com/playerson.html").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (WebException)
            {
                timer1.Stop();
                // Change notifyIcon's icon to error version.
                notifyIcon1.Icon = _iconError;
                // Set the notifyIcon tooltip.
                notifyIcon1.Text = this.Text + Environment.NewLine + "Connection error! Retry?";
                // Set the toolStripStatusLabel text.
                toolStripStatusLabel1.Text = "Connection error! Retry? (" + DateTime.Now.ToString(Hazeron.DateTimeFormat) + ")";
                // Make a nd show the retry dialog.
                DialogResult retryAnswer = MessageBox.Show(this,
                    "Failed to get the HTTP page." + Environment.NewLine +
                    "It may be a connection issue." + Environment.NewLine +
                    "" + Environment.NewLine +
                    "Would you like to continue the program?"
                    , "Connection Issue", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (retryAnswer == DialogResult.Cancel)
                    this.Close();
                timer1.Start();
            }
            if (httpArray == null || httpArray.Length == 0 || !httpArray[0].Contains("Shores of Hazeron"))
                return;

            // Go through the HTTP page line by line.
            List<string> onlineNow = new List<string>();
            bool avatarsSection = false;
            foreach (string httpLine in httpArray)
            {
                if (avatarsSection)
                {
                    if (httpLine.Contains("</tbody>"))
                        break;
                    const string start = "http://Hazeron.com/EmpireStandings2015/p";
                    const string middle = ".html\">";
                    const string end = "</a>";
                    int startIndex = httpLine.IndexOf(start) + start.Length;
                    int endIndex = httpLine.IndexOf(middle) - startIndex;
                    string avatarId = httpLine.Substring(startIndex, endIndex);
                    Avatar avatar;
                    if (!_avatarList.ContainsKey(avatarId))
                    {
                        startIndex = httpLine.IndexOf(middle) + middle.Length;
                        endIndex = httpLine.IndexOf(end) - startIndex;
                        string avatarName = httpLine.Substring(startIndex, endIndex);
                        avatar = new Avatar(avatarName, avatarId);
                        _avatarList.Add(avatarId, avatar);
                        AddAvatarToDGV(avatar);
                    }
                    else
                        avatar = _avatarList[avatarId];
                    onlineNow.Add(avatarId);
                }
                else if (httpLine.Contains(">Players Online</big>"))
                {
                    const string onlineStart = "<span style=\"font-family: sans-serif;\">";
                    const string onlineEnd = " players are currently online.<";
                    int startIndex = httpLine.IndexOf(onlineStart) + onlineStart.Length;
                    int endIndex = httpLine.IndexOf(onlineEnd) - startIndex;
                    _numOnline = Convert.ToInt32(httpLine.Substring(startIndex, endIndex));
                    toolStripStatusLabel1.Text = _numOnline.ToString() + " players online";
                }
                else if (httpLine.Contains("Player Name"))
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
                    avatar.ListRow.Visible = true;
                }
                else
                {
                    avatar.Online = false;
                    avatar.ListRow.Visible = false;
                }
            }

            // Change the notifyIcon if there are watched avatars online.
            if (_avatarList.Values.Any(x => x.Watch && x.Online))
            {
                // Change notifyIcon's icon to lit version.
                notifyIcon1.Icon = _iconLit;
                // Add list of online watched avatars to the notifyIcon tooltip.
                string watchNames = "";
                foreach (string avatarId in onlineNow)
                {
                    if (_avatarList[avatarId].Watch)
                        watchNames += Environment.NewLine + "• " + _avatarList[avatarId].ToString();
                }
                notifyIcon1.Text = this.Text + watchNames;
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
            TrayBalloonTip(avatar.Name + " has come online", ToolTipIcon.Info);

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
            dgvOnline.Rows.Add();
            avatar.ListRow = dgvOnline.Rows[dgvOnline.RowCount - 1];
            avatar.ListRow.Visible = false;
            avatar.ListRow.Cells["dgvOnlineColumnID"].Value = avatar.ID;
            avatar.ListRow.Cells["dgvOnlineColumnAvatar"].Value = avatar;
            dgvOnline.Sort(dgvOnlineColumnAvatar, ListSortDirection.Ascending);
        }

        public void UpdateDGV()
        {
            foreach (Avatar avatar in _avatarList.Values)
            {
                Color relationColor;
                if (avatar.Empire)
                    relationColor = Color.FromArgb(90, 110, 255); // Blue
                else if (avatar.Friend)
                    relationColor = Color.FromArgb(50, 240, 50); // Green
                else if (avatar.Unsure)
                    relationColor = Color.Yellow;
                else if (avatar.Enemy)
                    relationColor = Color.Red;
                else
                    relationColor = Color.White;

                int watchColorOffset;
                if (menuStrip1OptionsWatchHighlight.Checked && avatar.Watch)
                    watchColorOffset = 40;
                else
                    watchColorOffset = 0;

                avatar.ListRow.DefaultCellStyle.ForeColor = relationColor;
                avatar.ListRow.DefaultCellStyle.SelectionForeColor = relationColor;
                avatar.ListRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 0 + watchColorOffset, 0 + watchColorOffset); // Black
                avatar.ListRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30 + watchColorOffset, 30 + watchColorOffset); // Dark Gray
                foreach (DataGridViewCell cell in avatar.ListRow.Cells)
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
                                           || (avatar.Empire && cbxStandingFilter.SelectedItem == "Empire")
                                           || (avatar.Friend && cbxStandingFilter.SelectedItem == "Friend")
                                           || (avatar.Relation == 0 && cbxStandingFilter.SelectedItem == "Neutral")
                                           || (avatar.Unsure && cbxStandingFilter.SelectedItem == "Unsure")
                                           || (avatar.Enemy && cbxStandingFilter.SelectedItem == "Enemy")
                                             );
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

        private void menuStrip1OptionsNotificationSound_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsNotificationSound.Checked = !menuStrip1OptionsNotificationSound.Checked;
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
                "5.  Go to Edit -> Add Avatar" + Environment.NewLine +
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
        }
        #endregion

        #region DataGridView ContextMenu RightClick
        private Control _cmsRightClickSourceControl;

        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridView dgv = (sender as DataGridView);
                dgv.ContextMenuStrip = cmsListRightClick;
                DataGridViewCell currentCell = dgv[e.ColumnIndex, e.RowIndex];
                currentCell.DataGridView.ClearSelection();
                currentCell.DataGridView.CurrentCell = currentCell;
                currentCell.Selected = true;
                //Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                //Point p = new Point(r.X + r.Width, r.Y + r.Height);
                Point p = dgv.PointToClient(Control.MousePosition);
                dgv.ContextMenuStrip.Show(currentCell.DataGridView, p);
                dgv.ContextMenuStrip = null;
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            DataGridView dgv = (sender as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                cmsRightClick_Opening(sender, null);
                if ((e.KeyCode == Keys.F10 && !e.Control && e.Shift) || e.KeyCode == Keys.Apps)
                {
                    dgv.ContextMenuStrip = cmsListRightClick;
                    Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                    Point p = new Point(r.X, r.Y + r.Height);
                    dgv.ContextMenuStrip.Show(currentCell.DataGridView, p);
                    dgv.ContextMenuStrip = null;
                }
                else if (e.KeyCode == Keys.C && e.Control && !e.Shift)
                    cmsListRightClickCopy_Click(sender, null);
            }
        }

        private void cmsRightClick_Opening(object sender, CancelEventArgs e)
        {
            // Get table in question and currentCell.
            _cmsRightClickSourceControl = ((sender as ContextMenuStrip).SourceControl as Control);
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);

            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            cmsListRightClickStanding.Checked = avatar.Relation != 0;
            cmsListRightClickStandingEmpire.Checked = avatar.Empire;
            cmsListRightClickStandingEmpire.Text = (avatar.Empire ? "Unset" : "Set") + " Empire";
            cmsListRightClickStandingFriend.Checked = avatar.Friend;
            cmsListRightClickStandingFriend.Text = (avatar.Friend ? "Unset" : "Set") + " Friend";
            cmsListRightClickStandingUnsure.Checked = avatar.Unsure;
            cmsListRightClickStandingUnsure.Text = (avatar.Unsure ? "Unset" : "Set") + " Unsure";
            cmsListRightClickStandingEnemy.Checked = avatar.Enemy;
            cmsListRightClickStandingEnemy.Text = (avatar.Enemy ? "Unset" : "Set") + " Enemy";
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
            if (currentCell != null)
            {
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
                    if (dgv.CurrentCell.Value == null)
                        toolStripStatusLabel1.Text += " (null)";
                    else
                        toolStripStatusLabel1.Text += " (\"\")";
#endif
                }
            }
        }

        private void cmsListRightClickAvatar_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
                System.Diagnostics.Process.Start(@"http://Hazeron.com/EmpireStandings2015/p" + avatar.ID + ".html");
            }
        }

        private void cmsListRightClickRecheck_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
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
            }
            UpdateDGV();
        }

        private void cmsListRightClickStandingEmpire_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
                if (avatar.Empire)
                    avatar.Relation = 0;
                else
                    avatar.Relation = 2;
            }
            UpdateDGV();
        }

        private void cmsListRightClickStandingFriend_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
                if (avatar.Friend)
                    avatar.Relation = 0;
                else
                    avatar.Relation = 1;
            }
            UpdateDGV();
        }

        private void cmsListRightClickStandingUnsure_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
                if (avatar.Unsure)
                    avatar.Relation = 0;
                else
                    avatar.Relation = -1;
            }
            UpdateDGV();
        }

        private void cmsListRightClickStandingEnemy_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
                if (avatar.Enemy)
                    avatar.Relation = 0;
                else
                    avatar.Relation = -2;
            }
            UpdateDGV();
        }

        private void cmsListRightClickWatch_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
                avatar.Watch = !avatar.Watch;
            }
            UpdateDGV();
        }

        private void cmsListRightClickMain_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
#if !DisableMain
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
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
            }
            UpdateDGV();
#endif
        }

        private void cmsListRightClickNote_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsRightClickSourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Avatar player = (Avatar)dgv.CurrentRow.Cells[1].Value;
                FormInput inputBox = new FormInput(player.Name + " Note", "Writie notes for the character below." + Environment.NewLine + "Player: " + player.Name + " (" + player.ID + ")", player.Note, FormInputOptions.Multiline);
                if (inputBox.ShowDialog(this) == DialogResult.OK)
                    player.Note = inputBox.ReturnInput;
            }
            UpdateDGV();
        }
        #endregion

        #region Minimize to Tray
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                TrayBalloonTip("Minimized to tray");
                this.ShowInTaskbar = false;
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
            _settingsXml.Options.PlaySound = menuStrip1OptionsNotificationSound.Checked;
            _settingsXml.Save(Path.Combine(_appdataFolder, SETTINGS));
        }
    }
}
