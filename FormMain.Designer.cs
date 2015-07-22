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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1OptionsNotificationSound = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1Help = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1HelpGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1HelpThread = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1HelpHowToUse = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvOnline = new System.Windows.Forms.DataGridView();
            this.dgvOnlineColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnlineColumnAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWatch = new System.Windows.Forms.DataGridView();
            this.dgvWatchColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWatchColumnAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsListRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsListRightClickCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickAvatar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickRecheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsListRightClickStanding = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickStandingEmpire = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickStandingFriend = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickStandingUnsure = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListRightClickStandingEnemy = new System.Windows.Forms.ToolStripMenuItem();
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
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWatch)).BeginInit();
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
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(176, 6);
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvOnline);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvWatch);
            this.splitContainer1.Size = new System.Drawing.Size(392, 291);
            this.splitContainer1.SplitterDistance = 176;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvOnline
            // 
            this.dgvOnline.AllowUserToAddRows = false;
            this.dgvOnline.AllowUserToDeleteRows = false;
            this.dgvOnline.AllowUserToResizeRows = false;
            this.dgvOnline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOnline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOnline.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvOnlineColumnId,
            this.dgvOnlineColumnAvatar});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnline.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOnline.Location = new System.Drawing.Point(0, 0);
            this.dgvOnline.Name = "dgvOnline";
            this.dgvOnline.ReadOnly = true;
            this.dgvOnline.RowHeadersVisible = false;
            this.dgvOnline.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOnline.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOnline.Size = new System.Drawing.Size(172, 287);
            this.dgvOnline.TabIndex = 1;
            this.dgvOnline.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDown);
            this.dgvOnline.Click += new System.EventHandler(this.dgv_Click);
            this.dgvOnline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // dgvOnlineColumnId
            // 
            this.dgvOnlineColumnId.FillWeight = 50F;
            this.dgvOnlineColumnId.Frozen = true;
            this.dgvOnlineColumnId.HeaderText = "ID";
            this.dgvOnlineColumnId.MinimumWidth = 50;
            this.dgvOnlineColumnId.Name = "dgvOnlineColumnId";
            this.dgvOnlineColumnId.ReadOnly = true;
            this.dgvOnlineColumnId.Width = 50;
            // 
            // dgvOnlineColumnAvatar
            // 
            this.dgvOnlineColumnAvatar.FillWeight = 1000F;
            this.dgvOnlineColumnAvatar.Frozen = true;
            this.dgvOnlineColumnAvatar.HeaderText = "Avatars Online";
            this.dgvOnlineColumnAvatar.MinimumWidth = 1000;
            this.dgvOnlineColumnAvatar.Name = "dgvOnlineColumnAvatar";
            this.dgvOnlineColumnAvatar.ReadOnly = true;
            this.dgvOnlineColumnAvatar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnlineColumnAvatar.Width = 1000;
            // 
            // dgvWatch
            // 
            this.dgvWatch.AllowUserToAddRows = false;
            this.dgvWatch.AllowUserToDeleteRows = false;
            this.dgvWatch.AllowUserToResizeRows = false;
            this.dgvWatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvWatchColumnId,
            this.dgvWatchColumnAvatar});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWatch.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvWatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWatch.Location = new System.Drawing.Point(0, 0);
            this.dgvWatch.Name = "dgvWatch";
            this.dgvWatch.ReadOnly = true;
            this.dgvWatch.RowHeadersVisible = false;
            this.dgvWatch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvWatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWatch.Size = new System.Drawing.Size(208, 287);
            this.dgvWatch.TabIndex = 0;
            this.dgvWatch.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDown);
            this.dgvWatch.Click += new System.EventHandler(this.dgv_Click);
            this.dgvWatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // dgvWatchColumnId
            // 
            this.dgvWatchColumnId.FillWeight = 50F;
            this.dgvWatchColumnId.Frozen = true;
            this.dgvWatchColumnId.HeaderText = "ID";
            this.dgvWatchColumnId.MinimumWidth = 50;
            this.dgvWatchColumnId.Name = "dgvWatchColumnId";
            this.dgvWatchColumnId.ReadOnly = true;
            this.dgvWatchColumnId.Width = 50;
            // 
            // dgvWatchColumnAvatar
            // 
            this.dgvWatchColumnAvatar.FillWeight = 1000F;
            this.dgvWatchColumnAvatar.Frozen = true;
            this.dgvWatchColumnAvatar.HeaderText = "Watch List";
            this.dgvWatchColumnAvatar.MinimumWidth = 1000;
            this.dgvWatchColumnAvatar.Name = "dgvWatchColumnAvatar";
            this.dgvWatchColumnAvatar.ReadOnly = true;
            this.dgvWatchColumnAvatar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWatchColumnAvatar.Width = 1000;
            // 
            // cmsListRightClick
            // 
            this.cmsListRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsListRightClickCopy,
            this.cmsListRightClickAvatar,
            this.cmsListRightClickRecheck,
            this.toolStripSeparator2,
            this.cmsListRightClickStanding,
            this.cmsListRightClickWatch,
            this.toolStripSeparator6,
            this.cmsListRightClickMain,
            this.cmsListRightClickNote});
            this.cmsListRightClick.Name = "contextMenuStrip1";
            this.cmsListRightClick.Size = new System.Drawing.Size(153, 192);
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
            // cmsListRightClickRecheck
            // 
            this.cmsListRightClickRecheck.Name = "cmsListRightClickRecheck";
            this.cmsListRightClickRecheck.Size = new System.Drawing.Size(137, 22);
            this.cmsListRightClickRecheck.Text = "Recheck";
            this.cmsListRightClickRecheck.Click += new System.EventHandler(this.cmsListRightClickRecheck_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
            // 
            // cmsListRightClickStanding
            // 
            this.cmsListRightClickStanding.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsListRightClickStandingEmpire,
            this.cmsListRightClickStandingFriend,
            this.cmsListRightClickStandingUnsure,
            this.cmsListRightClickStandingEnemy});
            this.cmsListRightClickStanding.Name = "cmsListRightClickStanding";
            this.cmsListRightClickStanding.Size = new System.Drawing.Size(152, 22);
            this.cmsListRightClickStanding.Text = "Standing...";
            // 
            // cmsListRightClickStandingEmpire
            // 
            this.cmsListRightClickStandingEmpire.Name = "cmsListRightClickStandingEmpire";
            this.cmsListRightClickStandingEmpire.Size = new System.Drawing.Size(152, 22);
            this.cmsListRightClickStandingEmpire.Text = "Empire";
            // 
            // cmsListRightClickStandingFriend
            // 
            this.cmsListRightClickStandingFriend.Name = "cmsListRightClickStandingFriend";
            this.cmsListRightClickStandingFriend.Size = new System.Drawing.Size(152, 22);
            this.cmsListRightClickStandingFriend.Text = "Friend";
            // 
            // cmsListRightClickStandingUnsure
            // 
            this.cmsListRightClickStandingUnsure.Name = "cmsListRightClickStandingUnsure";
            this.cmsListRightClickStandingUnsure.Size = new System.Drawing.Size(152, 22);
            this.cmsListRightClickStandingUnsure.Text = "Unsure";
            // 
            // cmsListRightClickStandingEnemy
            // 
            this.cmsListRightClickStandingEnemy.Name = "cmsListRightClickStandingEnemy";
            this.cmsListRightClickStandingEnemy.Size = new System.Drawing.Size(152, 22);
            this.cmsListRightClickStandingEnemy.Text = "Enemy";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWatch)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvOnline;
        private System.Windows.Forms.DataGridView dgvWatch;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsAvatarIds;
        private System.Windows.Forms.ContextMenuStrip cmsListRightClick;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickWatch;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cmsNotifyIconRightClick;
        private System.Windows.Forms.ToolStripMenuItem cmsNotifyIconRightClickRestore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnlineColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnlineColumnAvatar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvWatchColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvWatchColumnAvatar;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickStanding;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickStandingEmpire;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickStandingFriend;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickStandingUnsure;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickStandingEnemy;
        private System.Windows.Forms.ToolStripMenuItem cmsListRightClickRecheck;
    }
}

