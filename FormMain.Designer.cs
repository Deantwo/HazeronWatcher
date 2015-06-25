namespace HazeronWatcher
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1EditAddAvatar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1Options = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1OptionsAvatarIds = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1OptionsWatchHighlight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1OptionsNonWatched = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1OptionsWatchList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1OptionsNotificationSound = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1Help = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1HelpGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1HelpThread = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1HelpHowToUse = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvPlayersOnline = new System.Windows.Forms.DataGridView();
            this.ColumnPlayerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWatchList = new System.Windows.Forms.DataGridView();
            this.ColumnWatchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWatchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsListRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsListRightClickCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickAvatar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsListRightClickEmpire = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickFriend = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickNeutral = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickUnsure = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickEnemy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsListRightClickWatch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsListRightClickMain = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickNote = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotifyIconRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsNotifyIconRightClickRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayersOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWatchList)).BeginInit();
            this.cmsListRightClick.SuspendLayout();
            this.cmsNotifyIconRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 315);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(392, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 18);
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(377, 19);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip1File,
            this.menuStrip1Edit,
            this.menuStrip1Options,
            this.menuStrip1Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(392, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip1File
            // 
            this.menuStrip1File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.menuStrip1FileExit});
            this.menuStrip1File.Name = "menuStrip1File";
            this.menuStrip1File.Size = new System.Drawing.Size(37, 20);
            this.menuStrip1File.Text = "File";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(131, 6);
            // 
            // menuStrip1FileExit
            // 
            this.menuStrip1FileExit.Name = "menuStrip1FileExit";
            this.menuStrip1FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuStrip1FileExit.Size = new System.Drawing.Size(134, 22);
            this.menuStrip1FileExit.Text = "Exit";
            this.menuStrip1FileExit.Click += new System.EventHandler(this.menuStrip1FileExit_Click);
            // 
            // menuStrip1Edit
            // 
            this.menuStrip1Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStrip1EditAddAvatar});
            this.menuStrip1Edit.Name = "menuStrip1Edit";
            this.menuStrip1Edit.Size = new System.Drawing.Size(39, 20);
            this.menuStrip1Edit.Text = "Edit";
            // 
            // MenuStrip1EditAddAvatar
            // 
            this.MenuStrip1EditAddAvatar.Name = "MenuStrip1EditAddAvatar";
            this.MenuStrip1EditAddAvatar.Size = new System.Drawing.Size(133, 22);
            this.MenuStrip1EditAddAvatar.Text = "Add Avatar";
            this.MenuStrip1EditAddAvatar.Click += new System.EventHandler(this.MenuStrip1EditAddAvatar_Click);
            // 
            // menuStrip1Options
            // 
            this.menuStrip1Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip1OptionsAvatarIds,
            this.menuStrip1OptionsWatchHighlight,
            this.menuStrip1OptionsNonWatched,
            this.menuStrip1OptionsWatchList,
            this.toolStripSeparator7,
            this.menuStrip1OptionsNotificationSound});
            this.menuStrip1Options.Name = "menuStrip1Options";
            this.menuStrip1Options.Size = new System.Drawing.Size(61, 20);
            this.menuStrip1Options.Text = "Options";
            // 
            // menuStrip1OptionsAvatarIds
            // 
            this.menuStrip1OptionsAvatarIds.Name = "menuStrip1OptionsAvatarIds";
            this.menuStrip1OptionsAvatarIds.Size = new System.Drawing.Size(179, 22);
            this.menuStrip1OptionsAvatarIds.Text = "Show Avatar IDs";
            this.menuStrip1OptionsAvatarIds.Click += new System.EventHandler(this.menuStrip1OptionsAvatarIds_Click);
            // 
            // menuStrip1OptionsWatchHighlight
            // 
            this.menuStrip1OptionsWatchHighlight.Name = "menuStrip1OptionsWatchHighlight";
            this.menuStrip1OptionsWatchHighlight.Size = new System.Drawing.Size(179, 22);
            this.menuStrip1OptionsWatchHighlight.Text = "Highlight Watched";
            this.menuStrip1OptionsWatchHighlight.Click += new System.EventHandler(this.menuStrip1OptionsWatchHighlight_Click);
            // 
            // menuStrip1OptionsNonWatched
            // 
            this.menuStrip1OptionsNonWatched.Name = "menuStrip1OptionsNonWatched";
            this.menuStrip1OptionsNonWatched.Size = new System.Drawing.Size(179, 22);
            this.menuStrip1OptionsNonWatched.Text = "Show non-Watched";
            this.menuStrip1OptionsNonWatched.Click += new System.EventHandler(this.menuStrip1OptionsNonWatched_Click);
            // 
            // menuStrip1OptionsWatchList
            // 
            this.menuStrip1OptionsWatchList.Name = "menuStrip1OptionsWatchList";
            this.menuStrip1OptionsWatchList.Size = new System.Drawing.Size(179, 22);
            this.menuStrip1OptionsWatchList.Text = "Show Watch List";
            this.menuStrip1OptionsWatchList.Click += new System.EventHandler(this.menuStrip1OptionsWatchList_Click);
            // 
            // menuStrip1OptionsNotificationSound
            // 
            this.menuStrip1OptionsNotificationSound.Name = "menuStrip1OptionsNotificationSound";
            this.menuStrip1OptionsNotificationSound.Size = new System.Drawing.Size(179, 22);
            this.menuStrip1OptionsNotificationSound.Text = "Notification Sound";
            this.menuStrip1OptionsNotificationSound.Click += new System.EventHandler(this.menuStrip1OptionsNotificationSound_Click);
            // 
            // menuStrip1Help
            // 
            this.menuStrip1Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip1HelpGithub,
            this.menuStrip1HelpThread,
            this.toolStripSeparator4,
            this.menuStrip1HelpAbout,
            this.menuStrip1HelpHowToUse});
            this.menuStrip1Help.Name = "menuStrip1Help";
            this.menuStrip1Help.Size = new System.Drawing.Size(44, 20);
            this.menuStrip1Help.Text = "Help";
            // 
            // menuStrip1HelpGithub
            // 
            this.menuStrip1HelpGithub.Name = "menuStrip1HelpGithub";
            this.menuStrip1HelpGithub.Size = new System.Drawing.Size(149, 22);
            this.menuStrip1HelpGithub.Text = "GitHub Repo";
            this.menuStrip1HelpGithub.Click += new System.EventHandler(this.menuStrip1HelpGithub_Click);
            // 
            // menuStrip1HelpThread
            // 
            this.menuStrip1HelpThread.Name = "menuStrip1HelpThread";
            this.menuStrip1HelpThread.Size = new System.Drawing.Size(149, 22);
            this.menuStrip1HelpThread.Text = "Forum Thread";
            this.menuStrip1HelpThread.Click += new System.EventHandler(this.menuStrip1HelpThread_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(146, 6);
            // 
            // menuStrip1HelpAbout
            // 
            this.menuStrip1HelpAbout.Name = "menuStrip1HelpAbout";
            this.menuStrip1HelpAbout.Size = new System.Drawing.Size(149, 22);
            this.menuStrip1HelpAbout.Text = "About";
            this.menuStrip1HelpAbout.Click += new System.EventHandler(this.menuStrip1HelpAbout_Click);
            // 
            // menuStrip1HelpHowToUse
            // 
            this.menuStrip1HelpHowToUse.Name = "menuStrip1HelpHowToUse";
            this.menuStrip1HelpHowToUse.Size = new System.Drawing.Size(149, 22);
            this.menuStrip1HelpHowToUse.Text = "How To Use";
            this.menuStrip1HelpHowToUse.Click += new System.EventHandler(this.menuStrip1HelpHowToUse_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvPlayersOnline);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvWatchList);
            this.splitContainer1.Size = new System.Drawing.Size(392, 291);
            this.splitContainer1.SplitterDistance = 176;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvPlayersOnline
            // 
            this.dgvPlayersOnline.AllowUserToAddRows = false;
            this.dgvPlayersOnline.AllowUserToDeleteRows = false;
            this.dgvPlayersOnline.AllowUserToResizeRows = false;
            this.dgvPlayersOnline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlayersOnline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayersOnline.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPlayerId,
            this.ColumnPlayerName});
            this.dgvPlayersOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlayersOnline.Location = new System.Drawing.Point(0, 0);
            this.dgvPlayersOnline.Name = "dgvPlayersOnline";
            this.dgvPlayersOnline.ReadOnly = true;
            this.dgvPlayersOnline.RowHeadersVisible = false;
            this.dgvPlayersOnline.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPlayersOnline.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayersOnline.Size = new System.Drawing.Size(172, 287);
            this.dgvPlayersOnline.TabIndex = 1;
            this.dgvPlayersOnline.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDown);
            this.dgvPlayersOnline.Click += new System.EventHandler(this.dgv_Click);
            this.dgvPlayersOnline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // ColumnPlayerId
            // 
            this.ColumnPlayerId.FillWeight = 50F;
            this.ColumnPlayerId.Frozen = true;
            this.ColumnPlayerId.HeaderText = "ID";
            this.ColumnPlayerId.MinimumWidth = 50;
            this.ColumnPlayerId.Name = "ColumnPlayerId";
            this.ColumnPlayerId.ReadOnly = true;
            this.ColumnPlayerId.Width = 50;
            // 
            // ColumnPlayerName
            // 
            this.ColumnPlayerName.FillWeight = 1000F;
            this.ColumnPlayerName.Frozen = true;
            this.ColumnPlayerName.HeaderText = "Players Online";
            this.ColumnPlayerName.MinimumWidth = 1000;
            this.ColumnPlayerName.Name = "ColumnPlayerName";
            this.ColumnPlayerName.ReadOnly = true;
            this.ColumnPlayerName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnPlayerName.Width = 1000;
            // 
            // dgvWatchList
            // 
            this.dgvWatchList.AllowUserToAddRows = false;
            this.dgvWatchList.AllowUserToDeleteRows = false;
            this.dgvWatchList.AllowUserToResizeRows = false;
            this.dgvWatchList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWatchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWatchList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnWatchId,
            this.ColumnWatchName});
            this.dgvWatchList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWatchList.Location = new System.Drawing.Point(0, 0);
            this.dgvWatchList.Name = "dgvWatchList";
            this.dgvWatchList.ReadOnly = true;
            this.dgvWatchList.RowHeadersVisible = false;
            this.dgvWatchList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvWatchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWatchList.Size = new System.Drawing.Size(208, 287);
            this.dgvWatchList.TabIndex = 0;
            this.dgvWatchList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDown);
            this.dgvWatchList.Click += new System.EventHandler(this.dgv_Click);
            this.dgvWatchList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // ColumnWatchId
            // 
            this.ColumnWatchId.FillWeight = 50F;
            this.ColumnWatchId.Frozen = true;
            this.ColumnWatchId.HeaderText = "ID";
            this.ColumnWatchId.MinimumWidth = 50;
            this.ColumnWatchId.Name = "ColumnWatchId";
            this.ColumnWatchId.ReadOnly = true;
            this.ColumnWatchId.Width = 50;
            // 
            // ColumnWatchName
            // 
            this.ColumnWatchName.FillWeight = 1000F;
            this.ColumnWatchName.Frozen = true;
            this.ColumnWatchName.HeaderText = "Watch List";
            this.ColumnWatchName.MinimumWidth = 1000;
            this.ColumnWatchName.Name = "ColumnWatchName";
            this.ColumnWatchName.ReadOnly = true;
            this.ColumnWatchName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnWatchName.Width = 1000;
            // 
            // cmsListRightClick
            // 
            this.cmsListRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsListRightClickCopy,
            this.cmsListRightClickAvatar,
            this.toolStripSeparator2,
            this.cmsListRightClickEmpire,
            this.cmsListRightClickFriend,
            this.cmsListRightClickNeutral,
            this.cmsListRightClickUnsure,
            this.cmsListRightClickEnemy,
            this.toolStripSeparator1,
            this.cmsListRightClickWatch,
            this.toolStripSeparator6,
            this.cmsListRightClickMain,
            this.cmsListRightClickNote});
            this.cmsListRightClick.Name = "contextMenuStrip1";
            this.cmsListRightClick.Size = new System.Drawing.Size(138, 242);
            this.cmsListRightClick.Opening += new System.ComponentModel.CancelEventHandler(this.cmsRightClick_Opening);
            // 
            // cmsListRightClickCopy
            // 
            this.cmsListRightClickCopy.Name = "cmsListRightClickCopy";
            this.cmsListRightClickCopy.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickCopy.Text = "Copy";
            this.cmsListRightClickCopy.Click += new System.EventHandler(this.cmsListRightClickCopy_Click);
            // 
            // cmsListRightClickAvatar
            // 
            this.cmsListRightClickAvatar.Name = "cmsListRightClickAvatar";
            this.cmsListRightClickAvatar.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickAvatar.Text = "Avatar Page";
            this.cmsListRightClickAvatar.Click += new System.EventHandler(this.cmsListRightClickAvatar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
            // 
            // cmsListRightClickEmpire
            // 
            this.cmsListRightClickEmpire.Name = "cmsListRightClickEmpire";
            this.cmsListRightClickEmpire.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickEmpire.Text = "Set Empire";
            this.cmsListRightClickEmpire.Click += new System.EventHandler(this.cmsListRightClickEmpire_Click);
            // 
            // cmsListRightClickFriend
            // 
            this.cmsListRightClickFriend.Name = "cmsListRightClickFriend";
            this.cmsListRightClickFriend.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickFriend.Text = "Set Friend";
            this.cmsListRightClickFriend.Click += new System.EventHandler(this.cmsListRightClickFriend_Click);
            // 
            // cmsListRightClickNeutral
            // 
            this.cmsListRightClickNeutral.Name = "cmsListRightClickNeutral";
            this.cmsListRightClickNeutral.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickNeutral.Text = "Set Neutral";
            this.cmsListRightClickNeutral.Click += new System.EventHandler(this.cmsListRightClickNeutral_Click);
            // 
            // cmsListRightClickUnsure
            // 
            this.cmsListRightClickUnsure.Name = "cmsListRightClickUnsure";
            this.cmsListRightClickUnsure.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickUnsure.Text = "Set Unsure";
            this.cmsListRightClickUnsure.Click += new System.EventHandler(this.cmsListRightClickUnsure_Click);
            // 
            // cmsListRightClickEnemy
            // 
            this.cmsListRightClickEnemy.Name = "cmsListRightClickEnemy";
            this.cmsListRightClickEnemy.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickEnemy.Text = "Set Enemy";
            this.cmsListRightClickEnemy.Click += new System.EventHandler(this.cmsListRightClickEnemy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // cmsListRightClickWatch
            // 
            this.cmsListRightClickWatch.Name = "cmsListRightClickWatch";
            this.cmsListRightClickWatch.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickWatch.Text = "Watch";
            this.cmsListRightClickWatch.Click += new System.EventHandler(this.cmsListRightClickWatch_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(134, 6);
            // 
            // cmsListRightClickMain
            // 
            this.cmsListRightClickMain.Name = "cmsListRightClickMain";
            this.cmsListRightClickMain.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickMain.Text = "Main";
            this.cmsListRightClickMain.Click += new System.EventHandler(this.cmsListRightClickMain_Click);
            // 
            // cmsListRightClickNote
            // 
            this.cmsListRightClickNote.Name = "cmsListRightClickNote";
            this.cmsListRightClickNote.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickNote.Text = "Note";
            this.cmsListRightClickNote.Click += new System.EventHandler(this.cmsListRightClickNote_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmsNotifyIconRightClick;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmsNotifyIconRightClick
            // 
            this.cmsNotifyIconRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsNotifyIconRightClickRestore,
            this.toolStripSeparator3,
            this.closeToolStripMenuItem});
            this.cmsNotifyIconRightClick.Name = "cmsNotifyIconRightClick";
            this.cmsNotifyIconRightClick.Size = new System.Drawing.Size(114, 54);
            // 
            // cmsNotifyIconRightClickRestore
            // 
            this.cmsNotifyIconRightClickRestore.Name = "cmsNotifyIconRightClickRestore";
            this.cmsNotifyIconRightClickRestore.Size = new System.Drawing.Size(113, 22);
            this.cmsNotifyIconRightClickRestore.Text = "Restore";
            this.cmsNotifyIconRightClickRestore.Click += new System.EventHandler(this.cmsNotifyIconRightClickRestore_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(110, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.menuStrip1FileExit_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(176, 6);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 339);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "HazeronWatcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayersOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWatchList)).EndInit();
            this.cmsListRightClick.ResumeLayout(false);
            this.cmsNotifyIconRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1File;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1Edit;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1Options;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1Help;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1HelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1FileExit;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dgvPlayersOnline;
        private System.Windows.Forms.DataGridView dgvWatchList;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsAvatarIds;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWatchId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWatchName;
        private System.Windows.Forms.ContextMenuStrip cmsListRightClick;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickFriend;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickNeutral;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickEnemy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickWatch;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cmsNotifyIconRightClick;
        private System.Windows.Forms.ToolStripMenuItem cmsNotifyIconRightClickRestore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickEmpire;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickUnsure;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsWatchHighlight;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsNonWatched;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1HelpGithub;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1HelpThread;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1HelpHowToUse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip1EditAddAvatar;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickAvatar;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsNotificationSound;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickNote;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickMain;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsWatchList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}

