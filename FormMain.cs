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
        const string SETTINGS = "Settings.xml";
        const string NOTIFICATION = "Notification.wav";
        HazeronWatcherSettings _settingsXml;

        int _numOnline = 0;
        Dictionary<string, Player> _playerList;

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
            {
                _settingsXml = HazeronWatcherSettings.Load(Path.Combine(_appdataFolder, SETTINGS));
                _playerList = _settingsXml.PlayerList.ToDictionary(x => x.ID);
                foreach (Player player in _playerList.Values)
                    AddPlayer(player);
                menuStrip1OptionsPlayerIds.Checked = _settingsXml.ShowIdColumn;
                menuStrip1OptionsWatchHighlight.Checked = _settingsXml.ShowWatchHighlight;
                menuStrip1OptionsNonWatched.Checked = _settingsXml.ShowNonWatched;
                menuStrip1OptionsNotificationSound.Checked = _settingsXml.PlaySound;
            }
            else
            {
                _settingsXml = new HazeronWatcherSettings();
                _playerList = new Dictionary<string, Player>();
                menuStrip1OptionsPlayerIds.Checked = false;
                menuStrip1OptionsWatchHighlight.Checked = true;
                menuStrip1OptionsNonWatched.Checked = true;
                menuStrip1OptionsNotificationSound.Checked = true;
            }

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
            ColumnPlayerId.Visible = menuStrip1OptionsPlayerIds.Checked;
            ColumnWatchId.Visible = menuStrip1OptionsPlayerIds.Checked;
            dgvPlayersOnline.DefaultCellStyle.BackColor = Color.Black;
            dgvPlayersOnline.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvPlayersOnline.Columns["ColumnPlayerId"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvWatchList.DefaultCellStyle.BackColor = Color.Black;
            dgvWatchList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvWatchList.Columns["ColumnWatchId"].DefaultCellStyle.Font = new Font("Lucida Console", 9);

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
                    httpArray = client.DownloadString(@"http://www.hazeron.com/playerson.html").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (WebException)
            {
                timer1.Stop();
                DialogResult retryAnswer = MessageBox.Show(this, "Failed to get the HTTP page." + Environment.NewLine + "It may be a connection issue." + Environment.NewLine + Environment.NewLine + "Would you like to continue the program?", "Connection Issue", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (retryAnswer == DialogResult.Cancel)
                    this.Close();
                timer1.Start();
            }
            if (httpArray == null || !httpArray[0].Contains("Shores of Hazeron"))
                return;

            // Go through the HTTP page line by line.
            List<string> onlineNow = new List<string>();
            bool playersSection = false;
            foreach (string httpLine in httpArray)
            {
                if (playersSection)
                {
                    if (httpLine.Contains("</tbody>"))
                        break;
                    const string start = "http://Hazeron.com/EmpireStandings2015/p";
                    const string middle = ".html\">";
                    const string end = "</a>";
                    int startIndex = httpLine.IndexOf(start) + start.Length;
                    int endIndex = httpLine.IndexOf(middle) - startIndex;
                    string playerId = httpLine.Substring(startIndex, endIndex);
                    Player player;
                    if (!_playerList.ContainsKey(playerId))
                    {
                        startIndex = httpLine.IndexOf(middle) + middle.Length;
                        endIndex = httpLine.IndexOf(end) - startIndex;
                        string playerName = httpLine.Substring(startIndex, endIndex);
                        player = new Player(playerName, playerId);
                        _playerList.Add(playerId, player);
                        AddPlayer(player);
                    }
                    else
                        player = _playerList[playerId];
                    onlineNow.Add(playerId);
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
                    playersSection = true;
                }
            }

            // Go through each player in the player list.
            foreach (Player player in _playerList.Values)
            {
                if (onlineNow.Contains(player.ID))
                {
                    if (player.Watch && !player.Online)
                    {
                        OnlineNotification(player);
                    }
                    player.Online = true;
                    player.ListRow.Visible = true;
                }
                else
                {
                    player.Online = false;
                    player.ListRow.Visible = false;
                }
            }

            // Update the lists with colors and check the watch list.
            UpdateLists();
        }

        public void OnlineNotification(Player player)
        {
            // Notify popup message.
            TrayBalloonTip(player.Name + " has come online", ToolTipIcon.Info);

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

        public void AddPlayer(Player player)
        {
            dgvPlayersOnline.Rows.Add();
            player.ListRow = dgvPlayersOnline.Rows[dgvPlayersOnline.RowCount - 1];
            player.ListRow.Visible = false;
            player.ListRow.Cells["ColumnPlayerID"].Value = player.ID;
            player.ListRow.Cells["ColumnPlayerName"].Value = player;
            dgvPlayersOnline.Sort(ColumnPlayerName, ListSortDirection.Ascending);
        }

        public void UpdateLists()
        {
            foreach (Player player in _playerList.Values)
            {
                Color relationColor;
                if (player.Empire)
                    relationColor = Color.FromArgb(90, 110, 255); // Blue
                else if (player.Friend)
                    relationColor = Color.FromArgb(50, 240, 50); // Green
                else if (player.Unsure)
                    relationColor = Color.Yellow;
                else if (player.Enemy)
                    relationColor = Color.Red;
                else
                    relationColor = Color.White;

                int watchColorOffset;
                if (menuStrip1OptionsWatchHighlight.Checked && player.Watch)
                    watchColorOffset = 40;
                else
                    watchColorOffset = 0;

                player.ListRow.DefaultCellStyle.ForeColor = relationColor;
                player.ListRow.DefaultCellStyle.SelectionForeColor = relationColor;
                player.ListRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 0 + watchColorOffset, 0 + watchColorOffset); // Black
                player.ListRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30 + watchColorOffset, 30 + watchColorOffset); // Dark Gray

                if (player.Relation != 0 || player.Watch)
                {
                    if (player.WatchRow == null)
                    {
                        dgvWatchList.Rows.Add();
                        player.WatchRow = dgvWatchList.Rows[dgvWatchList.RowCount - 1];
                        player.WatchRow.Cells["ColumnWatchID"].Value = player.ID;
                        player.WatchRow.Cells["ColumnWatchName"].Value = player;
                        dgvWatchList.Sort(ColumnWatchName, ListSortDirection.Ascending);
                    }
                    player.WatchRow.Visible = (player.Watch || menuStrip1OptionsNonWatched.Checked);
                    player.WatchRow.DefaultCellStyle.ForeColor = relationColor;
                    player.WatchRow.DefaultCellStyle.SelectionForeColor = relationColor;
                    player.WatchRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 0 + watchColorOffset, 0 + watchColorOffset); // Black
                    player.WatchRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30 + watchColorOffset, 30 + watchColorOffset); // Dark Gray
                }
                else if (player.WatchRow != null)
                {
                    dgvWatchList.Rows.Remove(player.WatchRow);
                    player.WatchRow = null;
                }
            }
        }

        #region menuStrip1
        private void menuStrip1FileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuStrip1EditAddPlayer_Click(object sender, EventArgs e)
        {
            FormInput inputDialog = new FormInput("Add Player", "Enter the player's ID.");
            if (inputDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            string id = inputDialog.ReturnInput.Trim();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[A-Z]+$");
            System.Text.RegularExpressions.Match regexMatch = regex.Match(id);
            if (id == null || id == "" || !regexMatch.Success)
            {
                MessageBox.Show(this, "Invalid input, please enter a valid avatar ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_playerList.ContainsKey(id))
            {
                _playerList[id].Watch = true;
            }
            else
            {
                string httpLine = null;
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        httpLine = client.DownloadString(@"http://Hazeron.com/EmpireStandings2015/p" + id + ".html").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    }
                }
                catch (WebException)
                {
                    // Blackhole.
                }
                if (httpLine == null || !httpLine.Contains("Shores of Hazeron"))
                {
                    MessageBox.Show(this, "There is no avatar with that ID.", "Avatar Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                const string start = "<title>Shores of Hazeron - ";
                const string end = "</title>";
                int startIndex = httpLine.IndexOf(start) + start.Length;
                int endIndex = httpLine.IndexOf(end) - startIndex;
                string name = httpLine.Substring(startIndex, endIndex);
                Player player = new Player(name, id);
                _playerList.Add(id, player);
                player.Watch = true;
                AddPlayer(player);
            }
            UpdateLists();
        }

        private void menuStrip1OptionsPlayerIds_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsPlayerIds.Checked = !menuStrip1OptionsPlayerIds.Checked;
            ColumnPlayerId.Visible = menuStrip1OptionsPlayerIds.Checked;
            ColumnWatchId.Visible = menuStrip1OptionsPlayerIds.Checked;
        }

        private void menuStrip1OptionsWatchHighlight_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsWatchHighlight.Checked = !menuStrip1OptionsWatchHighlight.Checked;
            UpdateLists();
        }

        private void menuStrip1OptionsNonWatched_Click(object sender, EventArgs e)
        {
            menuStrip1OptionsNonWatched.Checked = !menuStrip1OptionsNonWatched.Checked;
            UpdateLists();
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
                "5.  Go to Edit -> Add Player" + Environment.NewLine +
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
            if (sender != null && (sender as DataGridView) != dgvPlayersOnline)
                dgvPlayersOnline.ClearSelection();
            if (sender != null && (sender as DataGridView) != dgvWatchList)
                dgvWatchList.ClearSelection();
        }
        #endregion

        #region DataGridView ContextMenu RightClick
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
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = ((sender as ContextMenuStrip).SourceControl as DataGridView);

            Player player = (Player)dgv.CurrentRow.Cells[1].Value;
            cmsListRightClickEmpire.Checked = player.Empire;
            cmsListRightClickFriend.Checked = player.Friend;
            cmsListRightClickNeutral.Checked = player.Relation == 0;
            cmsListRightClickUnsure.Checked = player.Unsure;
            cmsListRightClickEnemy.Checked = player.Enemy;
            cmsListRightClickWatch.Checked = player.Watch;
            cmsListRightClickWatch.Text = (player.Watch ? "Remove from" : "Add to") + " Watch";
        }

        private void cmsListRightClickCopy_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
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
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Player player = (Player)dgv.CurrentRow.Cells[1].Value;
                System.Diagnostics.Process.Start(@"http://Hazeron.com/EmpireStandings2015/p" + player.ID + ".html");
            }
        }

        private void cmsListRightClickEmpire_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Player player = (Player)dgv.CurrentRow.Cells[1].Value;
                player.Relation = 2;
            }
            UpdateLists();
        }

        private void cmsListRightClickFriend_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Player player = (Player)dgv.CurrentRow.Cells[1].Value;
                player.Relation = 1;
            }
            UpdateLists();
        }

        private void cmsListRightClickNeutral_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Player player = (Player)dgv.CurrentRow.Cells[1].Value;
                player.Relation = 0;
            }
            UpdateLists();
        }

        private void cmsListRightClickUnsure_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Player player = (Player)dgv.CurrentRow.Cells[1].Value;
                player.Relation = -1;
            }
            UpdateLists();
        }

        private void cmsListRightClickEnemy_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Player player = (Player)dgv.CurrentRow.Cells[1].Value;
                player.Relation = -2;
            }
            UpdateLists();
        }

        private void cmsListRightClickWatch_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                Player player = (Player)dgv.CurrentRow.Cells[1].Value;
                player.Watch = !player.Watch;
            }
            UpdateLists();
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
            _settingsXml.ShowIdColumn = menuStrip1OptionsPlayerIds.Checked;
            _settingsXml.ShowWatchHighlight = menuStrip1OptionsWatchHighlight.Checked;
            _settingsXml.ShowNonWatched = menuStrip1OptionsNonWatched.Checked;
            _settingsXml.PlaySound = menuStrip1OptionsNotificationSound.Checked;
            _settingsXml.PlayerList = _playerList.Values.Where(x => x.Watch || x.Relation != 0).ToList();
            _settingsXml.Save(Path.Combine(_appdataFolder, SETTINGS));
        }
    }
}
