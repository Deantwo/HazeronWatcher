#define OldSettingsUpdate
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
        const string URL_PLAYERSON = @"https://hazeron.com/playerson.php";

#if DEBUG
        string _appdataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HazeronWatcherTest"); // %USERPROFILE%\AppData\Roaming\HazeronWatcherTest
#else
        string _appdataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HazeronWatcher"); // %USERPROFILE%\AppData\Roaming\HazeronWatcher
#endif
        const string SETTINGS = "HazeronWatcherSettings.xml";
        const string NOTIFICATION = "Notification.wav";
        HazeronWatcherSettings _settingsXml;

        DateTime _lastUpdated = DateTime.MinValue;
        int _numRetries = 0;
        int _numOnline = 0;

        Dictionary<string, Avatar> _avatarList;
        Dictionary<int, Empire> _empireList;
        Dictionary<int, WatchGroup> _watchGroupList;

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
            
            // Make sure the AppData folder exist.
            if (!Directory.Exists(_appdataFolder))
                Directory.CreateDirectory(_appdataFolder);
            // Load the settings XML file if there is one.
            if (File.Exists(Path.Combine(_appdataFolder, SETTINGS)))
                _settingsXml = HazeronWatcherSettings.Load(Path.Combine(_appdataFolder, SETTINGS));
            else
                _settingsXml = new HazeronWatcherSettings();
            // Get data from the settings.
            _avatarList = _settingsXml.AvatarList.ToDictionary(x => x.ID);
            _empireList = _settingsXml.EmpireList.ToDictionary(x => x.ID);
            _watchGroupList = _settingsXml.WatchGroupList.ToDictionary(x => x.ID);
            menuStrip1OptionsAvatarIds.Checked = !_settingsXml.Options.ShowIdColumn;
            menuStrip1OptionsAvatarIds_Click(null, null);
            menuStrip1OptionsWatchHighlight.Checked = _settingsXml.Options.ShowWatchHighlight;
            menuStrip1OptionsWatchList.Checked = !_settingsXml.Options.ShowWatchList;
            menuStrip1OptionsWatchList_Click(null, null);
            menuStrip1OptionsRecentList.Checked = !_settingsXml.Options.ShowRecentList;
            menuStrip1OptionsRecentList_Click(null, null);
            menuStrip1OptionsNotificationSound.Checked = _settingsXml.Options.PlaySound;
            menuStrip1OptionsTrayNotification.Checked = _settingsXml.Options.BallonTip;
            menuStrip1OptionsMinimizeTray.Checked = _settingsXml.Options.MinimizeToTray;
#if OldSettingsUpdate
            // If there is an old settings file, check if a backup exist, if not, make a backup and update the settings.
            if (_settingsXml.Options.Version == 1)
            {
                const string SETTINGS_BACKUP = "HazeronWatcherSettings (v1.4.6 backup).xml";
                if (!File.Exists(Path.Combine(_appdataFolder, SETTINGS_BACKUP)))
                {
                    // Rename the old "HazeronWatcherSettings.xml" to "HazeronWatcherSettings (v1.4.6 backup).xml".
                    File.Move(Path.Combine(_appdataFolder, SETTINGS), Path.Combine(_appdataFolder, SETTINGS_BACKUP));
                    // Create old default groups as new WatchGroups.
                    _watchGroupList.Add(1, new WatchGroup() { ID = 1, Name = "Enemy", GroupColor = Color.Red });
                    _watchGroupList.Add(2, new WatchGroup() { ID = 2, Name = "Unsure", GroupColor = Color.Yellow });
                    _watchGroupList.Add(3, new WatchGroup() { ID = 3, Name = "Friend", GroupColor = Color.FromArgb(50, 240, 50) });
                    _watchGroupList.Add(4, new WatchGroup() { ID = 4, Name = "Empire", GroupColor = Color.FromArgb(90, 110, 255) });
                    foreach (Avatar avatar in _avatarList.Values)
                    {
                        if (avatar.Relation == -2)
                            avatar.WatchGroup = 1;
                        else if (avatar.Relation == -1)
                            avatar.WatchGroup = 2;
                        else if (avatar.Relation == 1)
                            avatar.WatchGroup = 3;
                        else if (avatar.Relation == 2)
                            avatar.WatchGroup = 4;
                        avatar.Relation = 0;
                        avatar.Notify = avatar.Watch;
                        avatar.Watch = false;
                    }
                    _settingsXml.Options.Version = 2;
                    // Save the new "HazeronWatcherSettings.xml" and continue as if this never happened.
                    _settingsXml.Save(Path.Combine(_appdataFolder, SETTINGS));
                }
                else
                {
                    DialogResult question = MessageBox.Show(this,
                        "It seems that \"" + SETTINGS_BACKUP + "\" already file exist." + Environment.NewLine +
                        "In fear of messing up your settings, please go to HazeronWatcher's AppData folder and remove the incorrect file." + Environment.NewLine +
                        "" + Environment.NewLine +
                        "Would you like to open HazeronWatcher's AppData folder now?"
                        , "Settings File Update Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    if (question == DialogResult.Yes)
                        System.Diagnostics.Process.Start(_appdataFolder);
                    throw new FileLoadException("Cannot convert the \"" + SETTINGS + "\" file because a \"" + SETTINGS_BACKUP + "\" file already exist.", Path.Combine(_appdataFolder, SETTINGS));
                }
            }
#endif

            // Add data to the DataGridView.
            foreach (Avatar avatar in _avatarList.Values)
                AvatarDgvAddAvatar(avatar);
            EmpireDgvUpdate();
            foreach (WatchGroup watchGroup in _watchGroupList.Values)
                GroupDgvAddGroup(watchGroup);
            GroupDgvUpdate();

            // Update the contextMenu WatchGroup list.
            UpdateWatchGroupContextMenuList();

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
            dgvOnline.Columns["dgvOnlineColumnId"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvRecent.DefaultCellStyle.BackColor = Color.Black;
            dgvRecent.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvRecent.Columns["dgvRecentColumnId"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvAvatarWatch.DefaultCellStyle.BackColor = Color.Black;
            dgvAvatarWatch.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvAvatarWatch.Columns["dgvAvatarWatchColumnId"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvAvatarWatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmpireWatch.DefaultCellStyle.BackColor = Color.Black;
            dgvEmpireWatch.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvEmpireWatch.Columns["dgvEmpireWatchColumnId"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvEmpireWatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvGroup.DefaultCellStyle.BackColor = Color.Black;
            dgvGroup.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvGroup.Columns["dgvGroupColumnId"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvGroup.Columns["dgvGroupColumnId"].Visible = false;
            dgvGroup.Columns["dgvGroupColumnMembers"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGroup.Columns["dgvGroupColumnColor"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Disable Empire features.
            dgvOnline.Columns["dgvOnlineColumnEmpire"].Visible = false;
            tabControl1.TabPages.Remove(tabPageEmpires);

            // Run the tick once and start the looping timer.
            timer1_Tick(null, null);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Check the https://hazeron.com/playerson.php page and read the avatars.
            RefreshOnlineAvatars();

            // Update the DataGridViews with colors.
            AvatarDgvUpdate();
        }

        private void RefreshOnlineAvatars()
        {
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
                        const string HTTPLINE_FIRST = "<title>Shores of Hazeron - Avatars Online</title>";
                        if (httpLine != null && httpLine.Contains(HTTPLINE_FIRST))
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
                
                return;
            }

            // Save the time.
            _lastUpdated = DateTime.Now;
            _numRetries = 0;

            // Go through the HTTP page line by line.
            bool avatarsSection = false;
            foreach (string httpLine in httpDoc)
            {
                const string HTTPLINE_AVATAR_START = "<tbody><tr><td colspan=\"2\" style=\"vertical-align: top; background-color: #193680;\"><small><b>Avatar</b><br></small></td></tr>";
                const string HTTPLINE_AVATAR_END = "</tbody>";
                if (avatarsSection)
                {
                    if (httpLine == HTTPLINE_AVATAR_END)
                        break;
                    //const string EMPIRE_START = "src=\"https://Hazeron.com/EmpireStandings/";
                    //const string EMPIRE_END = ".png\"></a>";
                    const string AVATAR_START = "<a class=\"ll\" href=\"https://Hazeron.com/EmpireStandings/p";
                    const string AVATAR_MIDDLE = ".php\">";
                    const string AVATAR_END = "</a></small></td></tr>";
                    //int startIndex = httpLine.IndexOf(EMPIRE_START) + EMPIRE_START.Length;
                    //int endIndex = httpLine.IndexOf(EMPIRE_END) - startIndex;
                    //int empireId = Convert.ToInt32(httpLine.Substring(startIndex, endIndex));
                    int startIndex = httpLine.LastIndexOf(AVATAR_START) + AVATAR_START.Length;
                    int endIndex = httpLine.LastIndexOf(AVATAR_MIDDLE) - startIndex;
                    string avatarId = httpLine.Substring(startIndex, endIndex);
                    //Empire empire;
                    //if (!_empireList.ContainsKey(empireId))
                    //{
                    //    empire = new Empire(empireId);
                    //    _empireList.Add(empireId, empire);
                    //}
                    //else
                    //    empire = _empireList[empireId];
                    Avatar avatar;
                    if (!_avatarList.ContainsKey(avatarId))
                    {
                        startIndex = httpLine.LastIndexOf(AVATAR_MIDDLE) + AVATAR_MIDDLE.Length;
                        endIndex = httpLine.LastIndexOf(AVATAR_END) - startIndex;
                        string avatarName = httpLine.Substring(startIndex, endIndex);
                        avatar = new Avatar(avatarName, avatarId);
                        _avatarList.Add(avatarId, avatar);
                        AvatarDgvAddAvatar(avatar);
                    }
                    else
                        avatar = _avatarList[avatarId];
                    //avatar.Empire = empireId;
                    onlineNow.Add(avatarId);
                }
                else if (httpLine.EndsWith(" avatars are currently online.</span><br><br>"))
                {
                    const string AVATARS_START = "<br><div style=\"text-align: center; font-family: sans-serif;\"><big style=\"color: #ffffff; font-weight: bold;\">Avatars Online</big></div><br><span style=\"font-family: sans-serif;\">";
                    const string AVATARS_END = " avatars are currently online.</span><br><br>";
                    string numberAvatars = httpLine.Remove(httpLine.Length - AVATARS_END.Length).Substring(AVATARS_START.Length);
                    // If no avatars are online, the site might not say a number at all. "No avatars online"
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
                    if (!avatar.Online && avatar.Notify)
                    {
                        OnlineNotification(avatar);
                    }
                    else if (!avatar.Online && avatar.WatchGroup != 0 && _watchGroupList[avatar.WatchGroup].Notify)
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
            if (_avatarList.Values.Any(x => x.Notify && x.Online))
            {
                // Change notifyIcon's icon to lit version.
                notifyIcon1.Icon = _iconLit;
                // Add list of online watched avatars to the notifyIcon tooltip.
                string watchNames = this.Text;
                int watchExtra = 0;
                foreach (string avatarId in onlineNow)
                {
                    if (_avatarList[avatarId].Notify)
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
        }

        public void OnlineNotification(Avatar avatar)
        {
            // Notify popup message.
            TrayBalloonTip(avatar.Name + " has come online");

            // Play notification sound.
            if (menuStrip1OptionsNotificationSound.Checked)
            {
                if (avatar.WatchGroup != 0 && _watchGroupList[avatar.WatchGroup].Notify && _watchGroupList[avatar.WatchGroup].NotifySound != null)
                    using (System.Media.SoundPlayer notificationSound = new System.Media.SoundPlayer(_watchGroupList[avatar.WatchGroup].NotifySound))
                        notificationSound.Play();
                else if (File.Exists(Path.Combine(_appdataFolder, NOTIFICATION)))
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
                AvatarDgvAddAvatar(avatar);
            }
            return avatar;
        }

        public Empire GetEmpire(int id)
        {
            Empire empire;
            if (_empireList.ContainsKey(id))
                empire = _empireList[id];
            else
            {
                try
                {
                    empire = Empire.GetEmpire(id);
                }
                catch (HazeronAvatarNotFoundException)
                {
                    MessageBox.Show(this,
                        "There is no empire with that ID."
                        , "Empire Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                _empireList.Add(id, empire);
            }
            return empire;
        }

        #region WatchGroups
        private WatchGroup NewWatchGroup()
        {
            // Open WatchGroup creation dialog.
            FormWatchGroup form = new FormWatchGroup();
            DialogResult result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return null;
            WatchGroup newWatchGroup = form.ReturnValue;

            // Get a new WatchGroup ID.
            for (int i = 1; i <= _watchGroupList.Count + 1; i++)
            {
                if (!_watchGroupList.ContainsKey(i))
                {
                    newWatchGroup.ID = i;
                    break;
                }
            }

            // Add the new WatchGroup.
            _watchGroupList.Add(newWatchGroup.ID, newWatchGroup);

            // Update the contextMenu WatchGroup list.
            UpdateWatchGroupContextMenuList();

            // Update the WatchGroup DataGridView.
            GroupDgvAddGroup(newWatchGroup);
            GroupDgvUpdate();

            return newWatchGroup;
        }

        private void EditWatchGroup(WatchGroup editWatchGroup)
        {
            // Open WatchGroup creation dialog in edit mode.
            FormWatchGroup form = new FormWatchGroup(editWatchGroup);
            DialogResult result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            WatchGroup tempWatchGroup = form.ReturnValue;

            editWatchGroup.Name = tempWatchGroup.Name;
            editWatchGroup.GroupColor = tempWatchGroup.GroupColor;
            editWatchGroup.Notify = tempWatchGroup.Notify;
            editWatchGroup.NotifySound = tempWatchGroup.NotifySound;

            // Update the WatchGroup DataGridView.
            GroupDgvUpdate();
        }

        private void DeleteWatchGroup(WatchGroup deletingWatchGroup)
        {
            // Remove the WatchGroup from the WatchGroup list.
            _watchGroupList.Remove(deletingWatchGroup.ID);

            // Make all avatars in the removed WatchGroup, WatchGroup-less.
            foreach (Avatar avatar in _avatarList.Values.Where(x => x.WatchGroup == deletingWatchGroup.ID))
                avatar.WatchGroup = 0;

            // Update the WatchGroup DataGridView.
            GroupDgvRemoveGroup(deletingWatchGroup);

            // Update the contextMenu WatchGroup list.
            UpdateWatchGroupContextMenuList();
        }

        private List<ToolStripMenuItem> _groupMenuOptions = new List<ToolStripMenuItem>();
        private void UpdateWatchGroupContextMenuList()
        {
            foreach (ToolStripMenuItem menuItem in _groupMenuOptions)
                menuItem.Dispose();
            _groupMenuOptions.Clear();
            foreach (WatchGroup group in _watchGroupList.Values)
            {
                ToolStripMenuItem newMenuItem = new ToolStripMenuItem(group.Name, null, cmsAvatarRightClickWatchGroupSet_Click);
                newMenuItem.Tag = group.ID;
                _groupMenuOptions.Add(newMenuItem);
            }
            if (_groupMenuOptions.Count != 0)
                cmsAvatarRightClickWatchGroup.DropDownItems.AddRange(_groupMenuOptions.OrderBy(x => x.Text).ToArray());
        }
        #endregion

        #region Avatar Buttons
        private void chxHideNonWatched_Click(object sender, EventArgs e)
        {
            chxHideNonWatched.Checked = !chxHideNonWatched.Checked;
            AvatarDgvUpdate();
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
            avatar.Notify = true;
            AvatarDgvUpdate();
        }
        #endregion

        #region Empire Buttons
        private void btnAddEmpire_Click(object sender, EventArgs e)
        {
            FormInput inputDialog = new FormInput("Add Empire", "Enter the empire's ID.");
            if (inputDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            string id = inputDialog.ReturnInput.Trim();
            int idNum;
            if (!int.TryParse(id, out idNum))
            {
                MessageBox.Show(this, "Invalid input, please enter a valid empire ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Empire empire = GetEmpire(idNum);
            if (empire == null)
                return;
            empire.Notify = true;
            EmpireDgvUpdate();
        }
        #endregion

        #region Group Buttons
        private void btnGroupNew_Click(object sender, EventArgs e)
        {
            NewWatchGroup();
        }

        private void btnGroupEdit_Click(object sender, EventArgs e)
        {
            // Get row from the WatchGroup DataGridView.
            DataGridView dgv = dgvGroup;
            WatchGroup watchGroup = (WatchGroup)dgv.CurrentRow.Cells[1].Value;

            EditWatchGroup(watchGroup);
        }

        private void btnGroupDelete_Click(object sender, EventArgs e)
        {
            // Get row from the WatchGroup DataGridView.
            DataGridView dgv = dgvGroup;
            WatchGroup watchGroup = (WatchGroup)dgv.CurrentRow.Cells[1].Value;

            DeleteWatchGroup(watchGroup);
        }
        #endregion

        #region menuStrip1
        private void menuStrip1FileOpenAppdata_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_appdataFolder);
        }

        private void menuStrip1FileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1OptionsAvatarIds_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsAvatarIds.Checked = !menuStrip1OptionsAvatarIds.Checked;
            dgvOnlineColumnId.Visible = menuStrip1OptionsAvatarIds.Checked;
            dgvAvatarWatchColumnId.Visible = menuStrip1OptionsAvatarIds.Checked;
            dgvEmpireWatchColumnId.Visible = menuStrip1OptionsAvatarIds.Checked;
            dgvRecentColumnId.Visible = menuStrip1OptionsAvatarIds.Checked;
        }

        private void menuStrip1OptionsWatchHighlight_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsWatchHighlight.Checked = !menuStrip1OptionsWatchHighlight.Checked;
            GroupDgvUpdate();
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

        private void menuStrip1OptionsTrayNotification_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (sender as ToolStripMenuItem);
            if (menuItem == null)
                return;
            menuItem.Checked = !menuItem.Checked;
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
            System.Diagnostics.Process.Start(@"https://www.hazeron.com/mybb/showthread.php?tid=25");
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
                "     File -> Open AppData Folder" + Environment.NewLine +
                "     \"" + _appdataFolder + "\"" + Environment.NewLine +
                "2.  Move or copy the desired .wav file to the folder"
                , "How to use HazeronWatcher", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }
        #endregion

        #region DataGridView
        private void dgv_Click(object sender, EventArgs e)
        {
            if (sender != null && (sender as DataGridView) != dgvOnline)
                dgvOnline.ClearSelection();
            if (sender != null && (sender as DataGridView) != dgvAvatarWatch)
                dgvAvatarWatch.ClearSelection();
            if (sender != null && (sender as DataGridView) != dgvEmpireWatch)
                dgvEmpireWatch.ClearSelection();
            if (sender != null && (sender as DataGridView) != dgvRecent)
                dgvRecent.ClearSelection();
            if (sender != null && (sender as DataGridView) != dgvGroup)
                dgvGroup.ClearSelection();
        }

        public void AvatarDgvAddAvatar(Avatar avatar)
        {
            // Online list
            avatar.OnlineRow = dgvOnline.Rows[dgvOnline.Rows.Add()];
            avatar.OnlineRow.Visible = false;
            avatar.OnlineRow.Cells["dgvOnlineColumnID"].Value = avatar.ID;
            avatar.OnlineRow.Cells["dgvOnlineColumnAvatar"].Value = avatar;
            avatar.OnlineRow.Cells["dgvOnlineColumnEmpire"].Value = _empireList.ContainsKey(avatar.Empire) ? _empireList[avatar.Empire] : null;
            dgvOnline.Sort(dgvOnlineColumnAvatar, ListSortDirection.Ascending);
            // Recent list
            avatar.RecentRow = dgvRecent.Rows[dgvRecent.Rows.Add()];
            avatar.RecentRow.Visible = false;
            avatar.RecentRow.Cells["dgvRecentColumnID"].Value = avatar.ID;
            avatar.RecentRow.Cells["dgvRecentColumnAvatar"].Value = avatar;
            avatar.RecentRow.Cells["dgvRecentColumnEmpire"].Value = _empireList.ContainsKey(avatar.Empire) ? _empireList[avatar.Empire] : null;
            dgvRecent.Sort(dgvRecentColumnAvatar, ListSortDirection.Ascending);
        }

        public void AvatarDgvUpdate()
        {
            foreach (Avatar avatar in _avatarList.Values)
            {
                // Get colors.
                Color groupColor;
                if (avatar.WatchGroup != 0)
                    groupColor = _watchGroupList[avatar.WatchGroup].GroupColor;
                else
                    groupColor = Color.White;

                Color groupEmpireColor;
                if (avatar.Empire != 0 && _empireList[avatar.Empire].WatchGroup != 0)
                    groupEmpireColor = _watchGroupList[_empireList[avatar.Empire].WatchGroup].GroupColor;
                else
                    groupEmpireColor = Color.White;

                int notifyColorOffset;
                if (menuStrip1OptionsWatchHighlight.Checked && avatar.Notify)
                    notifyColorOffset = 40;
                else if (menuStrip1OptionsWatchHighlight.Checked && _empireList.ContainsKey(avatar.Empire) && _empireList[avatar.Empire].Notify)
                    notifyColorOffset = 20;
                else
                    notifyColorOffset = 0;

                // Update colors and note for dgvOnline
                avatar.OnlineRow.DefaultCellStyle.ForeColor = groupColor;
                avatar.OnlineRow.DefaultCellStyle.SelectionForeColor = groupColor;
                avatar.OnlineRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 0 + notifyColorOffset, 0 + notifyColorOffset); // Black
                avatar.OnlineRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30 + notifyColorOffset, 30 + notifyColorOffset); // Dark Gray
                foreach (DataGridViewCell cell in avatar.OnlineRow.Cells)
                {
                    cell.ToolTipText = avatar.Note;
                }

                // Update empires.
                avatar.OnlineRow.Cells[nameof(dgvOnlineColumnEmpire)].Value = _empireList.ContainsKey(avatar.Empire) ? _empireList[avatar.Empire] : null;
                avatar.OnlineRow.Cells[nameof(dgvOnlineColumnEmpire)].Style.ForeColor = groupEmpireColor;
                avatar.OnlineRow.Cells[nameof(dgvOnlineColumnEmpire)].Style.SelectionForeColor = groupEmpireColor;
                avatar.RecentRow.Cells[nameof(dgvRecentColumnEmpire)].Value = _empireList.ContainsKey(avatar.Empire) ? _empireList[avatar.Empire] : null;
                avatar.RecentRow.Cells[nameof(dgvRecentColumnEmpire)].Style.ForeColor = groupEmpireColor;
                avatar.RecentRow.Cells[nameof(dgvRecentColumnEmpire)].Style.SelectionForeColor = groupEmpireColor;

                // Is that avatar watch listed in anyway?
                if (avatar.IsWatchListed)
                {
                    if (avatar.AvatarWatchRow == null)
                    {
                        dgvAvatarWatch.Rows.Add();
                        avatar.AvatarWatchRow = dgvAvatarWatch.Rows[dgvAvatarWatch.RowCount - 1];
                        avatar.AvatarWatchRow.Cells["dgvAvatarWatchColumnId"].Value = avatar.ID;
                        avatar.AvatarWatchRow.Cells["dgvAvatarWatchColumnAvatar"].Value = avatar;
                        dgvAvatarWatch.Sort(dgvAvatarWatchColumnAvatar, ListSortDirection.Ascending);
                    }
                    avatar.AvatarWatchRow.Visible = (avatar.Notify || !chxHideNonWatched.Checked);
                    // Update colors and note for dgvAvatarWatch
                    avatar.AvatarWatchRow.DefaultCellStyle.ForeColor = groupColor;
                    avatar.AvatarWatchRow.DefaultCellStyle.SelectionForeColor = groupColor;
                    avatar.AvatarWatchRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 0 + notifyColorOffset, 0 + notifyColorOffset); // Black
                    avatar.AvatarWatchRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30 + notifyColorOffset, 30 + notifyColorOffset); // Dark Gray
                    if (avatar.WatchGroup != 0)
                        avatar.AvatarWatchRow.Cells["dgvAvatarWatchColumnGroup"].Value = _watchGroupList[avatar.WatchGroup].Name;
                    else
                        avatar.AvatarWatchRow.Cells["dgvAvatarWatchColumnGroup"].Value = null;
                    avatar.AvatarWatchRow.Cells["dgvAvatarWatchColumnNotify"].Value = avatar.Notify;
                    if (avatar.Note.Length < 50)
                        avatar.AvatarWatchRow.Cells["dgvAvatarWatchColumnNote"].Value = avatar.Note;
                    else
                        avatar.AvatarWatchRow.Cells["dgvAvatarWatchColumnNote"].Value = avatar.Note.Remove(50) + " ...";
                    foreach (DataGridViewCell cell in avatar.AvatarWatchRow.Cells)
                        cell.ToolTipText = avatar.Note;
                }
                else if (avatar.AvatarWatchRow != null)
                {
                    dgvAvatarWatch.Rows.Remove(avatar.AvatarWatchRow);
                    avatar.AvatarWatchRow = null;
                }

                // Update colors and note for dgvRecent
                avatar.RecentRow.DefaultCellStyle.ForeColor = groupColor;
                avatar.RecentRow.DefaultCellStyle.SelectionForeColor = groupColor;
                avatar.RecentRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 0 + notifyColorOffset, 0 + notifyColorOffset); // Black
                avatar.RecentRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30 + notifyColorOffset, 30 + notifyColorOffset); // Dark Gray
                foreach (DataGridViewCell cell in avatar.RecentRow.Cells)
                    cell.ToolTipText = avatar.Note;
            }

            // Invalidate the tables so "ToString()" methods updates.
            dgvOnline.Invalidate();
            dgvAvatarWatch.Invalidate();
        }

        public void EmpireDgvUpdate()
        {
            foreach (Empire empire in _empireList.Values)
            {
                Color groupColor;
                if (empire.WatchGroup != 0)
                    groupColor = _watchGroupList[empire.WatchGroup].GroupColor;
                else
                    groupColor = Color.White;

                int notifyColorOffset;
                if (menuStrip1OptionsWatchHighlight.Checked && empire.Notify)
                    notifyColorOffset = 40;
                else
                    notifyColorOffset = 0;

                // Is that empire watch listed in anyway?
                if (empire.IsWatchListed)
                {
                    if (empire.EmpireWatchRow == null)
                    {
                        dgvEmpireWatch.Rows.Add();
                        empire.EmpireWatchRow = dgvEmpireWatch.Rows[dgvEmpireWatch.RowCount - 1];
                        empire.EmpireWatchRow.Cells["dgvEmpireWatchColumnId"].Value = empire.ID;
                        empire.EmpireWatchRow.Cells["dgvEmpireWatchColumnEmpire"].Value = empire;
                        dgvEmpireWatch.Sort(dgvEmpireWatchColumnEmpire, ListSortDirection.Ascending);
                    }
                    empire.EmpireWatchRow.Visible = (empire.Notify || !chxHideNonWatched.Checked);
                    // Update colors and note for dgvEmpireWatch
                    empire.EmpireWatchRow.DefaultCellStyle.ForeColor = groupColor;
                    empire.EmpireWatchRow.DefaultCellStyle.SelectionForeColor = groupColor;
                    empire.EmpireWatchRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 0 + notifyColorOffset, 0 + notifyColorOffset); // Black
                    empire.EmpireWatchRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30 + notifyColorOffset, 30 + notifyColorOffset); // Dark Gray
                    if (empire.WatchGroup != 0)
                        empire.EmpireWatchRow.Cells["dgvEmpireWatchColumnGroup"].Value = _watchGroupList[empire.WatchGroup].Name;
                    else
                        empire.EmpireWatchRow.Cells["dgvEmpireWatchColumnGroup"].Value = null;
                    empire.EmpireWatchRow.Cells["dgvEmpireWatchColumnNotify"].Value = empire.Notify;
                    if (empire.Note.Length < 50)
                        empire.EmpireWatchRow.Cells["dgvEmpireWatchColumnNote"].Value = empire.Note;
                    else
                        empire.EmpireWatchRow.Cells["dgvEmpireWatchColumnNote"].Value = empire.Note.Remove(50) + " ...";
                    foreach (DataGridViewCell cell in empire.EmpireWatchRow.Cells)
                        cell.ToolTipText = empire.Note;
                }
                else if (empire.EmpireWatchRow != null)
                {
                    dgvEmpireWatch.Rows.Remove(empire.EmpireWatchRow);
                    empire.EmpireWatchRow = null;
                }
            }

            // Invalidate the tables so "ToString()" methods updates.
            dgvOnline.Invalidate();
            dgvEmpireWatch.Invalidate();
        }

        public void GroupDgvAddGroup(WatchGroup group)
        {
            // Add a new row on the WatchGroup DataGridView.
            group.GroupRow = dgvGroup.Rows[dgvGroup.Rows.Add()];
            group.GroupRow.Cells["dgvGroupColumnId"].Value = group.ID;
            group.GroupRow.Cells["dgvGroupColumnGroup"].Value = group;
            group.GroupRow.Cells["dgvGroupColumnColor"].Value = group.GroupColor.Name;
            group.GroupRow.DefaultCellStyle.ForeColor = Color.White;
            group.GroupRow.DefaultCellStyle.SelectionForeColor = Color.White;
            group.GroupRow.DefaultCellStyle.BackColor = Color.Black;
            group.GroupRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30); // Dark Gray
            dgvOnline.Sort(dgvOnlineColumnAvatar, ListSortDirection.Ascending);
        }

        public void GroupDgvUpdate()
        {
            foreach (WatchGroup group in _watchGroupList.Values)
            {
                // Update members column.
                group.GroupRow.Cells["dgvGroupColumnMembers"].Value = _avatarList.Values.Count(x => x.WatchGroup == group.ID);

                // Update notify column.
                group.GroupRow.Cells["dgvGroupColumnNotify"].Value = group.Notify;

                // Update sound column.
                if (string.IsNullOrEmpty(group.NotifySound))
                    group.GroupRow.Cells["dgvGroupColumnSound"].Value = "<default>";
                else
                    group.GroupRow.Cells["dgvGroupColumnSound"].Value = group.NotifySound;

                // Update color column.
                group.GroupRow.Cells["dgvGroupColumnColor"].Style.ForeColor = group.GroupColor;
                group.GroupRow.Cells["dgvGroupColumnColor"].Style.SelectionForeColor = group.GroupColor;
            }

            // Invalidate the tables so "ToString()" methods updates.
            dgvGroup.Invalidate();

            // Sort and resize the DataGridView.
            dgvGroup.Sort(dgvGroupColumnGroup, ListSortDirection.Ascending);
            dgvGroup.AutoResizeColumns();
        }

        public void GroupDgvRemoveGroup(WatchGroup group)
        {
            // Remove the row from the WatchGroup DataGridView.
            dgvGroup.Rows.Remove(group.GroupRow);
        }
        #endregion

        #region Avatar DataGridView ContextMenu RightClick
        private Control _cmsAvatarRightClickSourceControl;

        private void dgvAvatar_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridView dgv = (sender as DataGridView);
                _cmsAvatarRightClickSourceControl = (dgv as Control);

                // Get and set current cell from mouse location.
                DataGridViewCell currentCell = dgv[e.ColumnIndex, e.RowIndex];
                dgv.ClearSelection();
                dgv.CurrentCell = currentCell;
                currentCell.Selected = true;

                // Show the ContextMenuStrip.
                dgv.ContextMenuStrip = cmsAvatarRightClick;
                Point p = dgv.PointToClient(Control.MousePosition);
                dgv.ContextMenuStrip.Show(dgv, p);
                dgv.ContextMenuStrip = null;
            }
        }

        private void dgvAvatar_KeyDown(object sender, KeyEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            DataGridView dgv = (sender as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            _cmsAvatarRightClickSourceControl = (dgv as Control);
            if (currentCell != null)
            {
                if ((e.KeyCode == Keys.F10 && !e.Control && e.Shift) || e.KeyCode == Keys.Apps)
                {
                    // Show the ContextMenuStrip.
                    dgv.ContextMenuStrip = cmsAvatarRightClick;
                    Rectangle r = dgv.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                    Point p = new Point(r.X, r.Y + r.Height);
                    dgv.ContextMenuStrip.Show(dgv, p);
                    dgv.ContextMenuStrip = null;
                }
                else if (e.KeyCode == Keys.C && e.Control && !e.Shift)
                    cmsAvatarRightClickCopy_Click(sender, null);
            }
        }

        private void cmsAvatarRightClick_Opening(object sender, CancelEventArgs e)
        {
            DataGridView dgv = (_cmsAvatarRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            cmsAvatarRightClickWatchGroup.Checked = avatar.WatchGroup != 0;
            cmsAvatarRightClickWatchGroupUnset.Enabled = avatar.WatchGroup != 0;
            cmsAvatarRightClickWatch.Checked = avatar.Notify;
            cmsAvatarRightClickWatch.Text = (avatar.Notify ? "Remove from" : "Add to") + " Watch";
            cmsAvatarRightClickNote.Checked = !String.IsNullOrEmpty(avatar.Note);
            cmsAvatarRightClickNote.Text = (String.IsNullOrEmpty(avatar.Note) ? "Add" : "Edit") + " Note";
        }

        private void cmsAvatarRightClickCopy_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsAvatarRightClickSourceControl as DataGridView);
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

        private void cmsAvatarRightClickAvatar_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsAvatarRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            System.Diagnostics.Process.Start(@"https://Hazeron.com/EmpireStandings/p" + avatar.ID + ".php");
        }

        private void cmsAvatarRightClickRecheck_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsAvatarRightClickSourceControl as DataGridView);
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
            AvatarDgvUpdate();
        }

        private void cmsAvatarRightClickWatchGroupUnset_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsAvatarRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;

            // Set avatar WatchGroup to none (0).
            avatar.WatchGroup = 0;

            GroupDgvUpdate();
        }

        private void cmsAvatarRightClickWatchGroupNew_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsAvatarRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;

            // Create the WatchGroup.
            WatchGroup newWatchGroup = NewWatchGroup();
            if (newWatchGroup == null)
                return;

            // Set WatchGroup of Avatar to newly created WatchGroup.
            avatar.WatchGroup = newWatchGroup.ID;

            GroupDgvUpdate();
        }

        private void cmsAvatarRightClickWatchGroupSet_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsAvatarRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;

            // Get menu item.
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            // Set WatchGroup of Avatar to specified WatchGroup.
            avatar.WatchGroup = (int)menuItem.Tag;

            GroupDgvUpdate();
        }

        private void cmsAvatarRightClickWatch_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsAvatarRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            avatar.Notify = !avatar.Notify;
            GroupDgvUpdate();
        }

        private void cmsAvatarRightClickNote_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsAvatarRightClickSourceControl as DataGridView);
            Avatar avatar = (Avatar)dgv.CurrentRow.Cells[1].Value;
            FormInput inputBox = new FormInput(avatar.Name + " Note", "Writie notes for the avatar below." + Environment.NewLine + "Avatar: " + avatar.Name + " (" + avatar.ID + ")", avatar.Note, FormInputOptions.Multiline);
            if (inputBox.ShowDialog(this) == DialogResult.OK)
                avatar.Note = inputBox.ReturnInput;
            GroupDgvUpdate();
        }
        #endregion

        #region Empire DataGridView ContextMenu RightClick
        private Control _cmsEmpireRightClickSourceControl;

        private void dgvEmpire_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridView dgv = (sender as DataGridView);
                _cmsEmpireRightClickSourceControl = (dgv as Control);

                // Get and set current cell from mouse location.
                DataGridViewCell currentCell = dgv[e.ColumnIndex, e.RowIndex];
                dgv.ClearSelection();
                dgv.CurrentCell = currentCell;
                currentCell.Selected = true;

                // Show the ContextMenuStrip.
                dgv.ContextMenuStrip = cmsEmpireRightClick;
                Point p = dgv.PointToClient(Control.MousePosition);
                dgv.ContextMenuStrip.Show(dgv, p);
                dgv.ContextMenuStrip = null;
            }
        }

        private void dgvEmpire_KeyDown(object sender, KeyEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            DataGridView dgv = (sender as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            _cmsEmpireRightClickSourceControl = (dgv as Control);
            if (currentCell != null)
            {
                if ((e.KeyCode == Keys.F10 && !e.Control && e.Shift) || e.KeyCode == Keys.Apps)
                {
                    // Show the ContextMenuStrip.
                    dgv.ContextMenuStrip = cmsEmpireRightClick;
                    Rectangle r = dgv.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                    Point p = new Point(r.X, r.Y + r.Height);
                    dgv.ContextMenuStrip.Show(dgv, p);
                    dgv.ContextMenuStrip = null;
                }
                else if (e.KeyCode == Keys.C && e.Control && !e.Shift)
                    cmsEmpireRightClickCopy_Click(sender, null);
            }
        }

        private void cmsEmpireRightClick_Opening(object sender, CancelEventArgs e)
        {
            DataGridView dgv = (_cmsEmpireRightClickSourceControl as DataGridView);
            Empire empire = (Empire)dgv.CurrentRow.Cells[1].Value;
            cmsEmpireRightClickWatchGroup.Checked = empire.WatchGroup != 0;
            cmsEmpireRightClickWatchGroupUnset.Enabled = empire.WatchGroup != 0;
            cmsEmpireRightClickWatch.Checked = empire.Notify;
            cmsEmpireRightClickWatch.Text = (empire.Notify ? "Remove from" : "Add to") + " Watch";
            cmsEmpireRightClickNote.Checked = !String.IsNullOrEmpty(empire.Note);
            cmsEmpireRightClickNote.Text = (String.IsNullOrEmpty(empire.Note) ? "Add" : "Edit") + " Note";
        }

        private void cmsEmpireRightClickCopy_Click(object sender, EventArgs e)
        {
        }

        private void cmsEmpireRightClickRecheck_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsEmpireRightClickSourceControl as DataGridView);
            Empire empire = (Empire)dgv.CurrentRow.Cells[1].Value;
            try
            {
                empire.RecheckName();
            }
            catch (HazeronEmpireNotFoundException)
            {
                if (empire.IsWatchListed)
                {
                    DialogResult confimation = MessageBox.Show(this,
                        "There is no empire with that ID." + Environment.NewLine +
                        "The empire may have been deleted." + Environment.NewLine +
                        "" + Environment.NewLine +
                        "Would you like to remove the empire from watch list?"
                        , "Empire Not Found, Unwatch?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (confimation == DialogResult.Yes)
                    {
                        empire.Unlist();
                    }
                }
                else
                    MessageBox.Show(this,
                        "There is no empire with that ID." + Environment.NewLine +
                        "The empire may have been deleted."
                        , "Empire Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EmpireDgvUpdate();
        }

        private void cmsEmpireRightClickWatchGroupUnset_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsEmpireRightClickSourceControl as DataGridView);
            Empire empire = (Empire)dgv.CurrentRow.Cells[1].Value;

            // Set empire WatchGroup to none (0).
            empire.WatchGroup = 0;

            GroupDgvUpdate();
        }

        private void cmsEmpireRightClickWatchGroupNew_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsEmpireRightClickSourceControl as DataGridView);
            Empire empire = (Empire)dgv.CurrentRow.Cells[1].Value;

            // Create the WatchGroup.
            WatchGroup newWatchGroup = NewWatchGroup();
            if (newWatchGroup == null)
                return;

            // Set WatchGroup of Empire to newly created WatchGroup.
            empire.WatchGroup = newWatchGroup.ID;

            GroupDgvUpdate();
        }

        private void cmsEmpireRightClickWatchGroupSet_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsEmpireRightClickSourceControl as DataGridView);
            Empire empire = (Empire)dgv.CurrentRow.Cells[1].Value;

            // Get menu item.
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            // Set WatchGroup of Empire to specified WatchGroup.
            empire.WatchGroup = (int)menuItem.Tag;

            GroupDgvUpdate();
        }

        private void cmsEmpireRightClickWatch_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsEmpireRightClickSourceControl as DataGridView);
            Empire empire = (Empire)dgv.CurrentRow.Cells[1].Value;
            empire.Notify = !empire.Notify;
            GroupDgvUpdate();
        }

        private void cmsEmpireRightClickNote_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsEmpireRightClickSourceControl as DataGridView);
            Empire empire = (Empire)dgv.CurrentRow.Cells[1].Value;
            FormInput inputBox = new FormInput(empire.Name + " Note", "Writie notes for the empire below." + Environment.NewLine + "Empire: " + empire.Name + " (" + empire.ID + ")", empire.Note, FormInputOptions.Multiline);
            if (inputBox.ShowDialog(this) == DialogResult.OK)
                empire.Note = inputBox.ReturnInput;
            GroupDgvUpdate();
        }
        #endregion

        #region WatchGroup DataGridView ContextMenu RightClick
        private Control _cmsGroupRightClickSourceControl;

        private void dgvGroup_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridView dgv = (sender as DataGridView);
                _cmsGroupRightClickSourceControl = (dgv as Control);

                // Get and set current cell from mouse location.
                DataGridViewCell currentCell = dgv[e.ColumnIndex, e.RowIndex];
                dgv.ClearSelection();
                dgv.CurrentCell = currentCell;
                currentCell.Selected = true;

                //Show the ContextMenuStrip.
                dgv.ContextMenuStrip = cmsGroupRightClick;
                Point p = dgv.PointToClient(Control.MousePosition);
                dgv.ContextMenuStrip.Show(dgv, p);
                dgv.ContextMenuStrip = null;
            }
        }

        private void dgvGroup_KeyDown(object sender, KeyEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            DataGridView dgv = (sender as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            _cmsGroupRightClickSourceControl = (dgv as Control);
            if (currentCell != null)
            {
                if ((e.KeyCode == Keys.F10 && !e.Control && e.Shift) || e.KeyCode == Keys.Apps)
                {
                    //Show the ContextMenuStrip.
                    dgv.ContextMenuStrip = cmsGroupRightClick;
                    Rectangle r = dgv.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                    Point p = new Point(r.X, r.Y + r.Height);
                    dgv.ContextMenuStrip.Show(dgv, p);
                    dgv.ContextMenuStrip = null;
                }
                else if (e.KeyCode == Keys.C && e.Control && !e.Shift)
                    cmsGroupRightClickCopy_Click(sender, null);
            }
        }

        private void cmsGroupRightClick_Opening(object sender, CancelEventArgs e)
        {
            DataGridView dgv = (_cmsGroupRightClickSourceControl as DataGridView);
            WatchGroup watchGroup = (WatchGroup)dgv.CurrentRow.Cells[1].Value;
        }

        private void cmsGroupRightClickCopy_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsGroupRightClickSourceControl as DataGridView);
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

        private void cmsGroupRightClickEdit_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsGroupRightClickSourceControl as DataGridView);
            WatchGroup watchGroup = (WatchGroup)dgv.CurrentRow.Cells[1].Value;

            // Edit the WatchGroup.
            EditWatchGroup(watchGroup);
        }

        private void cmsGroupRightClickDelete_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (_cmsGroupRightClickSourceControl as DataGridView);
            WatchGroup watchGroup = (WatchGroup)dgv.CurrentRow.Cells[1].Value;

            // Delete the WatchGroup.
            DeleteWatchGroup(watchGroup);
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
            if (menuStrip1OptionsTrayNotification.Checked)
                notifyIcon1.ShowBalloonTip(time);
        }
        #endregion
        
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (!Directory.Exists(_appdataFolder))
                Directory.CreateDirectory(_appdataFolder);
            _settingsXml.AvatarList = _avatarList.Values.Where(x => x.IsWatchListed).ToList();
            _settingsXml.EmpireList = _empireList.Values.Where(x => x.IsWatchListed).ToList();
            _settingsXml.WatchGroupList = _watchGroupList.Values.ToList();
            _settingsXml.Options.ShowIdColumn = menuStrip1OptionsAvatarIds.Checked;
            _settingsXml.Options.ShowWatchHighlight = menuStrip1OptionsWatchHighlight.Checked;
            _settingsXml.Options.ShowWatchList = menuStrip1OptionsWatchList.Checked;
            _settingsXml.Options.ShowRecentList = menuStrip1OptionsRecentList.Checked;
            _settingsXml.Options.PlaySound = menuStrip1OptionsNotificationSound.Checked;
            _settingsXml.Options.BallonTip = menuStrip1OptionsTrayNotification.Checked;
            _settingsXml.Options.MinimizeToTray = menuStrip1OptionsMinimizeTray.Checked;
            _settingsXml.Save(Path.Combine(_appdataFolder, SETTINGS));
        }
    }
}
