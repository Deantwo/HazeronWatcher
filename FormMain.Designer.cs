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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1Options = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1OptionsAvatarIds = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1OptionsWatchHighlight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1OptionsWatchList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1OptionsRecentList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1OptionsNotificationSound = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1OptionsTrayNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1OptionsMinimizeTray = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1Help = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1HelpGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1HelpThread = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1HelpHowToUse = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvOnline = new System.Windows.Forms.DataGridView();
            this.dgvOnlineColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnlineColumnAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnlineColumnEmpire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRecent = new System.Windows.Forms.DataGridView();
            this.dgvRecentColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRecentColumnAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRecentColumnEmpire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAvatars = new System.Windows.Forms.TabPage();
            this.dgvAvatarWatch = new System.Windows.Forms.DataGridView();
            this.dgvAvatarWatchColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAvatarWatchColumnAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAvatarWatchColumnGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAvatarWatchColumnNotify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAvatarWatchColumnNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddAvatar = new System.Windows.Forms.Button();
            this.chxHideNonWatched = new System.Windows.Forms.CheckBox();
            this.tabPageEmpires = new System.Windows.Forms.TabPage();
            this.dgvEmpireWatch = new System.Windows.Forms.DataGridView();
            this.dgvEmpireWatchColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmpireWatchColumnEmpire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmpireWatchColumnGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmpireWatchColumnNotify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmpireWatchColumnNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddEmpire = new System.Windows.Forms.Button();
            this.tabPageGroups = new System.Windows.Forms.TabPage();
            this.btnGroupDelete = new System.Windows.Forms.Button();
            this.btnGroupNew = new System.Windows.Forms.Button();
            this.btnGroupEdit = new System.Windows.Forms.Button();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.dgvGroupColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGroupColumnGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGroupColumnMembers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGroupColumnNotify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGroupColumnSound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGroupColumnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsAvatarRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAvatarRightClickCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsAvatarRightClickAvatar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAvatarRightClickRecheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsAvatarRightClickWatchGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAvatarRightClickWatchGroupUnset = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAvatarRightClickWatchGroupNew = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAvatarRightClickWatchGroupSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cmsAvatarRightClickWatch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsAvatarRightClickNote = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotifyIconRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsNotifyIconRightClickRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsGroupRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsGroupRightClickCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsGroupRightClickEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsGroupRightClickDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEmpireRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEmpireRightClickCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEmpireRightClickRecheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEmpireRightClickWatchGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEmpireRightClickWatchGroupUnset = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEmpireRightClickWatchGroupNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEmpireRightClickWatch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEmpireRightClickNote = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageAvatars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvatarWatch)).BeginInit();
            this.tabPageEmpires.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpireWatch)).BeginInit();
            this.tabPageGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.cmsAvatarRightClick.SuspendLayout();
            this.cmsNotifyIconRightClick.SuspendLayout();
            this.cmsGroupRightClick.SuspendLayout();
            this.cmsEmpireRightClick.SuspendLayout();
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
            this.toolStripSeparator5.Size = new System.Drawing.Size(132, 6);
            // 
            // menuStrip1FileExit
            // 
            this.menuStrip1FileExit.Name = "menuStrip1FileExit";
            this.menuStrip1FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuStrip1FileExit.Size = new System.Drawing.Size(135, 22);
            this.menuStrip1FileExit.Text = "Exit";
            this.menuStrip1FileExit.Click += new System.EventHandler(this.menuStrip1FileExit_Click);
            // 
            // menuStrip1Options
            // 
            this.menuStrip1Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip1OptionsAvatarIds,
            this.menuStrip1OptionsWatchHighlight,
            this.toolStripSeparator7,
            this.menuStrip1OptionsWatchList,
            this.menuStrip1OptionsRecentList,
            this.toolStripSeparator1,
            this.menuStrip1OptionsNotificationSound,
            this.menuStrip1OptionsTrayNotification,
            this.toolStripSeparator8,
            this.menuStrip1OptionsMinimizeTray});
            this.menuStrip1Options.Name = "menuStrip1Options";
            this.menuStrip1Options.Size = new System.Drawing.Size(61, 20);
            this.menuStrip1Options.Text = "Options";
            // 
            // menuStrip1OptionsAvatarIds
            // 
            this.menuStrip1OptionsAvatarIds.Name = "menuStrip1OptionsAvatarIds";
            this.menuStrip1OptionsAvatarIds.Size = new System.Drawing.Size(189, 22);
            this.menuStrip1OptionsAvatarIds.Text = "Show Avatar IDs";
            this.menuStrip1OptionsAvatarIds.Click += new System.EventHandler(this.menuStrip1OptionsAvatarIds_Click);
            // 
            // menuStrip1OptionsWatchHighlight
            // 
            this.menuStrip1OptionsWatchHighlight.Name = "menuStrip1OptionsWatchHighlight";
            this.menuStrip1OptionsWatchHighlight.Size = new System.Drawing.Size(189, 22);
            this.menuStrip1OptionsWatchHighlight.Text = "Highlight Watched";
            this.menuStrip1OptionsWatchHighlight.Click += new System.EventHandler(this.menuStrip1OptionsWatchHighlight_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(186, 6);
            // 
            // menuStrip1OptionsWatchList
            // 
            this.menuStrip1OptionsWatchList.Name = "menuStrip1OptionsWatchList";
            this.menuStrip1OptionsWatchList.Size = new System.Drawing.Size(189, 22);
            this.menuStrip1OptionsWatchList.Text = "Show Watch List";
            this.menuStrip1OptionsWatchList.Click += new System.EventHandler(this.menuStrip1OptionsWatchList_Click);
            // 
            // menuStrip1OptionsRecentList
            // 
            this.menuStrip1OptionsRecentList.Name = "menuStrip1OptionsRecentList";
            this.menuStrip1OptionsRecentList.Size = new System.Drawing.Size(189, 22);
            this.menuStrip1OptionsRecentList.Text = "Show Recently Online";
            this.menuStrip1OptionsRecentList.Click += new System.EventHandler(this.menuStrip1OptionsRecentList_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // menuStrip1OptionsNotificationSound
            // 
            this.menuStrip1OptionsNotificationSound.Name = "menuStrip1OptionsNotificationSound";
            this.menuStrip1OptionsNotificationSound.Size = new System.Drawing.Size(189, 22);
            this.menuStrip1OptionsNotificationSound.Text = "Notification Sound";
            this.menuStrip1OptionsNotificationSound.Click += new System.EventHandler(this.menuStrip1OptionsNotificationSound_Click);
            // 
            // menuStrip1OptionsTrayNotification
            // 
            this.menuStrip1OptionsTrayNotification.Name = "menuStrip1OptionsTrayNotification";
            this.menuStrip1OptionsTrayNotification.Size = new System.Drawing.Size(189, 22);
            this.menuStrip1OptionsTrayNotification.Text = "Tray Notification";
            this.menuStrip1OptionsTrayNotification.Click += new System.EventHandler(this.menuStrip1OptionsTrayNotification_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(186, 6);
            // 
            // menuStrip1OptionsMinimizeTray
            // 
            this.menuStrip1OptionsMinimizeTray.Name = "menuStrip1OptionsMinimizeTray";
            this.menuStrip1OptionsMinimizeTray.Size = new System.Drawing.Size(189, 22);
            this.menuStrip1OptionsMinimizeTray.Text = "Minimize to Tray";
            this.menuStrip1OptionsMinimizeTray.Click += new System.EventHandler(this.menuStrip1OptionsMinimizeTray_Click);
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
            this.menuStrip1HelpGithub.Size = new System.Drawing.Size(155, 22);
            this.menuStrip1HelpGithub.Text = "GitHub Repo";
            this.menuStrip1HelpGithub.Click += new System.EventHandler(this.menuStrip1HelpGithub_Click);
            // 
            // menuStrip1HelpThread
            // 
            this.menuStrip1HelpThread.Name = "menuStrip1HelpThread";
            this.menuStrip1HelpThread.Size = new System.Drawing.Size(155, 22);
            this.menuStrip1HelpThread.Text = "Forum Thread";
            this.menuStrip1HelpThread.Click += new System.EventHandler(this.menuStrip1HelpThread_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(152, 6);
            // 
            // menuStrip1HelpAbout
            // 
            this.menuStrip1HelpAbout.Name = "menuStrip1HelpAbout";
            this.menuStrip1HelpAbout.Size = new System.Drawing.Size(155, 22);
            this.menuStrip1HelpAbout.Text = "About";
            this.menuStrip1HelpAbout.Click += new System.EventHandler(this.menuStrip1HelpAbout_Click);
            // 
            // menuStrip1HelpHowToUse
            // 
            this.menuStrip1HelpHowToUse.Name = "menuStrip1HelpHowToUse";
            this.menuStrip1HelpHowToUse.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuStrip1HelpHowToUse.Size = new System.Drawing.Size(155, 22);
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(392, 291);
            this.splitContainer1.SplitterDistance = 176;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvOnline);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvRecent);
            this.splitContainer2.Size = new System.Drawing.Size(172, 287);
            this.splitContainer2.SplitterDistance = 192;
            this.splitContainer2.TabIndex = 2;
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
            this.dgvOnlineColumnAvatar,
            this.dgvOnlineColumnEmpire});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnline.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOnline.Location = new System.Drawing.Point(0, 0);
            this.dgvOnline.Name = "dgvOnline";
            this.dgvOnline.ReadOnly = true;
            this.dgvOnline.RowHeadersVisible = false;
            this.dgvOnline.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOnline.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOnline.Size = new System.Drawing.Size(172, 192);
            this.dgvOnline.TabIndex = 1;
            this.dgvOnline.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAvatar_CellMouseDown);
            this.dgvOnline.Click += new System.EventHandler(this.dgv_Click);
            this.dgvOnline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAvatar_KeyDown);
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
            this.dgvOnlineColumnAvatar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvOnlineColumnAvatar.HeaderText = "Avatars Online";
            this.dgvOnlineColumnAvatar.Name = "dgvOnlineColumnAvatar";
            this.dgvOnlineColumnAvatar.ReadOnly = true;
            // 
            // dgvOnlineColumnEmpire
            // 
            this.dgvOnlineColumnEmpire.HeaderText = "Empire";
            this.dgvOnlineColumnEmpire.Name = "dgvOnlineColumnEmpire";
            this.dgvOnlineColumnEmpire.ReadOnly = true;
            this.dgvOnlineColumnEmpire.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOnlineColumnEmpire.Width = 50;
            // 
            // dgvRecent
            // 
            this.dgvRecent.AllowUserToAddRows = false;
            this.dgvRecent.AllowUserToDeleteRows = false;
            this.dgvRecent.AllowUserToResizeRows = false;
            this.dgvRecent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvRecentColumnId,
            this.dgvRecentColumnAvatar,
            this.dgvRecentColumnEmpire});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecent.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecent.Location = new System.Drawing.Point(0, 0);
            this.dgvRecent.Name = "dgvRecent";
            this.dgvRecent.ReadOnly = true;
            this.dgvRecent.RowHeadersVisible = false;
            this.dgvRecent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRecent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecent.Size = new System.Drawing.Size(172, 91);
            this.dgvRecent.TabIndex = 2;
            this.dgvRecent.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAvatar_CellMouseDown);
            this.dgvRecent.Click += new System.EventHandler(this.dgv_Click);
            this.dgvRecent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAvatar_KeyDown);
            // 
            // dgvRecentColumnId
            // 
            this.dgvRecentColumnId.FillWeight = 50F;
            this.dgvRecentColumnId.Frozen = true;
            this.dgvRecentColumnId.HeaderText = "ID";
            this.dgvRecentColumnId.MinimumWidth = 50;
            this.dgvRecentColumnId.Name = "dgvRecentColumnId";
            this.dgvRecentColumnId.ReadOnly = true;
            this.dgvRecentColumnId.Width = 50;
            // 
            // dgvRecentColumnAvatar
            // 
            this.dgvRecentColumnAvatar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvRecentColumnAvatar.HeaderText = "Recently Online";
            this.dgvRecentColumnAvatar.Name = "dgvRecentColumnAvatar";
            this.dgvRecentColumnAvatar.ReadOnly = true;
            // 
            // dgvRecentColumnEmpire
            // 
            this.dgvRecentColumnEmpire.HeaderText = "Empire";
            this.dgvRecentColumnEmpire.Name = "dgvRecentColumnEmpire";
            this.dgvRecentColumnEmpire.ReadOnly = true;
            this.dgvRecentColumnEmpire.Width = 50;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAvatars);
            this.tabControl1.Controls.Add(this.tabPageEmpires);
            this.tabControl1.Controls.Add(this.tabPageGroups);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(208, 287);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageAvatars
            // 
            this.tabPageAvatars.Controls.Add(this.dgvAvatarWatch);
            this.tabPageAvatars.Controls.Add(this.btnAddAvatar);
            this.tabPageAvatars.Controls.Add(this.chxHideNonWatched);
            this.tabPageAvatars.Location = new System.Drawing.Point(4, 22);
            this.tabPageAvatars.Name = "tabPageAvatars";
            this.tabPageAvatars.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAvatars.Size = new System.Drawing.Size(200, 261);
            this.tabPageAvatars.TabIndex = 0;
            this.tabPageAvatars.Text = "Avatars";
            this.tabPageAvatars.UseVisualStyleBackColor = true;
            // 
            // dgvAvatarWatch
            // 
            this.dgvAvatarWatch.AllowUserToAddRows = false;
            this.dgvAvatarWatch.AllowUserToDeleteRows = false;
            this.dgvAvatarWatch.AllowUserToResizeRows = false;
            this.dgvAvatarWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAvatarWatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAvatarWatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvatarWatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvAvatarWatchColumnId,
            this.dgvAvatarWatchColumnAvatar,
            this.dgvAvatarWatchColumnGroup,
            this.dgvAvatarWatchColumnNotify,
            this.dgvAvatarWatchColumnNote});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAvatarWatch.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAvatarWatch.Location = new System.Drawing.Point(3, 58);
            this.dgvAvatarWatch.Name = "dgvAvatarWatch";
            this.dgvAvatarWatch.ReadOnly = true;
            this.dgvAvatarWatch.RowHeadersVisible = false;
            this.dgvAvatarWatch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAvatarWatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvatarWatch.Size = new System.Drawing.Size(191, 200);
            this.dgvAvatarWatch.TabIndex = 0;
            this.dgvAvatarWatch.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAvatar_CellMouseDown);
            this.dgvAvatarWatch.Click += new System.EventHandler(this.dgv_Click);
            this.dgvAvatarWatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAvatar_KeyDown);
            // 
            // dgvAvatarWatchColumnId
            // 
            this.dgvAvatarWatchColumnId.FillWeight = 50F;
            this.dgvAvatarWatchColumnId.Frozen = true;
            this.dgvAvatarWatchColumnId.HeaderText = "ID";
            this.dgvAvatarWatchColumnId.Name = "dgvAvatarWatchColumnId";
            this.dgvAvatarWatchColumnId.ReadOnly = true;
            this.dgvAvatarWatchColumnId.Width = 50;
            // 
            // dgvAvatarWatchColumnAvatar
            // 
            this.dgvAvatarWatchColumnAvatar.HeaderText = "Avatar";
            this.dgvAvatarWatchColumnAvatar.Name = "dgvAvatarWatchColumnAvatar";
            this.dgvAvatarWatchColumnAvatar.ReadOnly = true;
            // 
            // dgvAvatarWatchColumnGroup
            // 
            this.dgvAvatarWatchColumnGroup.HeaderText = "Group";
            this.dgvAvatarWatchColumnGroup.Name = "dgvAvatarWatchColumnGroup";
            this.dgvAvatarWatchColumnGroup.ReadOnly = true;
            // 
            // dgvAvatarWatchColumnNotify
            // 
            this.dgvAvatarWatchColumnNotify.HeaderText = "Notify";
            this.dgvAvatarWatchColumnNotify.Name = "dgvAvatarWatchColumnNotify";
            this.dgvAvatarWatchColumnNotify.ReadOnly = true;
            // 
            // dgvAvatarWatchColumnNote
            // 
            this.dgvAvatarWatchColumnNote.HeaderText = "Note";
            this.dgvAvatarWatchColumnNote.Name = "dgvAvatarWatchColumnNote";
            this.dgvAvatarWatchColumnNote.ReadOnly = true;
            // 
            // btnAddAvatar
            // 
            this.btnAddAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAvatar.Location = new System.Drawing.Point(3, 29);
            this.btnAddAvatar.Name = "btnAddAvatar";
            this.btnAddAvatar.Size = new System.Drawing.Size(191, 23);
            this.btnAddAvatar.TabIndex = 3;
            this.btnAddAvatar.Text = "Add Avatar via ID";
            this.btnAddAvatar.UseVisualStyleBackColor = true;
            this.btnAddAvatar.Click += new System.EventHandler(this.btnAddAvatar_Click);
            // 
            // chxHideNonWatched
            // 
            this.chxHideNonWatched.AutoCheck = false;
            this.chxHideNonWatched.AutoSize = true;
            this.chxHideNonWatched.Location = new System.Drawing.Point(6, 6);
            this.chxHideNonWatched.Name = "chxHideNonWatched";
            this.chxHideNonWatched.Size = new System.Drawing.Size(116, 17);
            this.chxHideNonWatched.TabIndex = 1;
            this.chxHideNonWatched.Text = "Hide non-Watched";
            this.chxHideNonWatched.UseVisualStyleBackColor = true;
            this.chxHideNonWatched.Click += new System.EventHandler(this.chxHideNonWatched_Click);
            // 
            // tabPageEmpires
            // 
            this.tabPageEmpires.Controls.Add(this.dgvEmpireWatch);
            this.tabPageEmpires.Controls.Add(this.btnAddEmpire);
            this.tabPageEmpires.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmpires.Name = "tabPageEmpires";
            this.tabPageEmpires.Size = new System.Drawing.Size(200, 261);
            this.tabPageEmpires.TabIndex = 2;
            this.tabPageEmpires.Text = "Empires";
            this.tabPageEmpires.UseVisualStyleBackColor = true;
            // 
            // dgvEmpireWatch
            // 
            this.dgvEmpireWatch.AllowUserToAddRows = false;
            this.dgvEmpireWatch.AllowUserToDeleteRows = false;
            this.dgvEmpireWatch.AllowUserToResizeRows = false;
            this.dgvEmpireWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmpireWatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmpireWatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpireWatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvEmpireWatchColumnId,
            this.dgvEmpireWatchColumnEmpire,
            this.dgvEmpireWatchColumnGroup,
            this.dgvEmpireWatchColumnNotify,
            this.dgvEmpireWatchColumnNote});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmpireWatch.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvEmpireWatch.Location = new System.Drawing.Point(3, 32);
            this.dgvEmpireWatch.Name = "dgvEmpireWatch";
            this.dgvEmpireWatch.ReadOnly = true;
            this.dgvEmpireWatch.RowHeadersVisible = false;
            this.dgvEmpireWatch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEmpireWatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpireWatch.Size = new System.Drawing.Size(191, 226);
            this.dgvEmpireWatch.TabIndex = 4;
            this.dgvEmpireWatch.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmpire_CellMouseDown);
            this.dgvEmpireWatch.Click += new System.EventHandler(this.dgv_Click);
            this.dgvEmpireWatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvEmpire_KeyDown);
            // 
            // dgvEmpireWatchColumnId
            // 
            this.dgvEmpireWatchColumnId.FillWeight = 50F;
            this.dgvEmpireWatchColumnId.Frozen = true;
            this.dgvEmpireWatchColumnId.HeaderText = "ID";
            this.dgvEmpireWatchColumnId.Name = "dgvEmpireWatchColumnId";
            this.dgvEmpireWatchColumnId.ReadOnly = true;
            this.dgvEmpireWatchColumnId.Width = 50;
            // 
            // dgvEmpireWatchColumnEmpire
            // 
            this.dgvEmpireWatchColumnEmpire.HeaderText = "Empire";
            this.dgvEmpireWatchColumnEmpire.Name = "dgvEmpireWatchColumnEmpire";
            this.dgvEmpireWatchColumnEmpire.ReadOnly = true;
            // 
            // dgvEmpireWatchColumnGroup
            // 
            this.dgvEmpireWatchColumnGroup.HeaderText = "Group";
            this.dgvEmpireWatchColumnGroup.Name = "dgvEmpireWatchColumnGroup";
            this.dgvEmpireWatchColumnGroup.ReadOnly = true;
            // 
            // dgvEmpireWatchColumnNotify
            // 
            this.dgvEmpireWatchColumnNotify.HeaderText = "Notify";
            this.dgvEmpireWatchColumnNotify.Name = "dgvEmpireWatchColumnNotify";
            this.dgvEmpireWatchColumnNotify.ReadOnly = true;
            // 
            // dgvEmpireWatchColumnNote
            // 
            this.dgvEmpireWatchColumnNote.HeaderText = "Note";
            this.dgvEmpireWatchColumnNote.Name = "dgvEmpireWatchColumnNote";
            this.dgvEmpireWatchColumnNote.ReadOnly = true;
            // 
            // btnAddEmpire
            // 
            this.btnAddEmpire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddEmpire.Location = new System.Drawing.Point(3, 3);
            this.btnAddEmpire.Name = "btnAddEmpire";
            this.btnAddEmpire.Size = new System.Drawing.Size(191, 23);
            this.btnAddEmpire.TabIndex = 5;
            this.btnAddEmpire.Text = "Add Empire via ID";
            this.btnAddEmpire.UseVisualStyleBackColor = true;
            this.btnAddEmpire.Click += new System.EventHandler(this.btnAddEmpire_Click);
            // 
            // tabPageGroups
            // 
            this.tabPageGroups.Controls.Add(this.btnGroupDelete);
            this.tabPageGroups.Controls.Add(this.btnGroupNew);
            this.tabPageGroups.Controls.Add(this.btnGroupEdit);
            this.tabPageGroups.Controls.Add(this.dgvGroup);
            this.tabPageGroups.Location = new System.Drawing.Point(4, 22);
            this.tabPageGroups.Name = "tabPageGroups";
            this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroups.Size = new System.Drawing.Size(200, 261);
            this.tabPageGroups.TabIndex = 1;
            this.tabPageGroups.Text = "Watch Groups";
            this.tabPageGroups.UseVisualStyleBackColor = true;
            // 
            // btnGroupDelete
            // 
            this.btnGroupDelete.Location = new System.Drawing.Point(118, 6);
            this.btnGroupDelete.Name = "btnGroupDelete";
            this.btnGroupDelete.Size = new System.Drawing.Size(75, 23);
            this.btnGroupDelete.TabIndex = 2;
            this.btnGroupDelete.Text = "Delete";
            this.btnGroupDelete.UseVisualStyleBackColor = true;
            this.btnGroupDelete.Click += new System.EventHandler(this.btnGroupDelete_Click);
            // 
            // btnGroupNew
            // 
            this.btnGroupNew.Location = new System.Drawing.Point(6, 6);
            this.btnGroupNew.Name = "btnGroupNew";
            this.btnGroupNew.Size = new System.Drawing.Size(50, 23);
            this.btnGroupNew.TabIndex = 2;
            this.btnGroupNew.Text = "New";
            this.btnGroupNew.UseVisualStyleBackColor = true;
            this.btnGroupNew.Click += new System.EventHandler(this.btnGroupNew_Click);
            // 
            // btnGroupEdit
            // 
            this.btnGroupEdit.Location = new System.Drawing.Point(62, 6);
            this.btnGroupEdit.Name = "btnGroupEdit";
            this.btnGroupEdit.Size = new System.Drawing.Size(50, 23);
            this.btnGroupEdit.TabIndex = 2;
            this.btnGroupEdit.Text = "Edit";
            this.btnGroupEdit.UseVisualStyleBackColor = true;
            this.btnGroupEdit.Click += new System.EventHandler(this.btnGroupEdit_Click);
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.AllowUserToResizeRows = false;
            this.dgvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvGroupColumnId,
            this.dgvGroupColumnGroup,
            this.dgvGroupColumnMembers,
            this.dgvGroupColumnNotify,
            this.dgvGroupColumnSound,
            this.dgvGroupColumnColor});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGroup.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvGroup.Location = new System.Drawing.Point(6, 35);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.ReadOnly = true;
            this.dgvGroup.RowHeadersVisible = false;
            this.dgvGroup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroup.Size = new System.Drawing.Size(188, 220);
            this.dgvGroup.TabIndex = 1;
            this.dgvGroup.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGroup_CellMouseDown);
            this.dgvGroup.Click += new System.EventHandler(this.dgv_Click);
            this.dgvGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvGroup_KeyDown);
            // 
            // dgvGroupColumnId
            // 
            this.dgvGroupColumnId.FillWeight = 50F;
            this.dgvGroupColumnId.Frozen = true;
            this.dgvGroupColumnId.HeaderText = "ID";
            this.dgvGroupColumnId.Name = "dgvGroupColumnId";
            this.dgvGroupColumnId.ReadOnly = true;
            this.dgvGroupColumnId.Width = 50;
            // 
            // dgvGroupColumnGroup
            // 
            this.dgvGroupColumnGroup.HeaderText = "Group";
            this.dgvGroupColumnGroup.Name = "dgvGroupColumnGroup";
            this.dgvGroupColumnGroup.ReadOnly = true;
            // 
            // dgvGroupColumnMembers
            // 
            this.dgvGroupColumnMembers.HeaderText = "Memebers";
            this.dgvGroupColumnMembers.Name = "dgvGroupColumnMembers";
            this.dgvGroupColumnMembers.ReadOnly = true;
            // 
            // dgvGroupColumnNotify
            // 
            this.dgvGroupColumnNotify.HeaderText = "Notify";
            this.dgvGroupColumnNotify.Name = "dgvGroupColumnNotify";
            this.dgvGroupColumnNotify.ReadOnly = true;
            // 
            // dgvGroupColumnSound
            // 
            this.dgvGroupColumnSound.HeaderText = "Sound";
            this.dgvGroupColumnSound.Name = "dgvGroupColumnSound";
            this.dgvGroupColumnSound.ReadOnly = true;
            // 
            // dgvGroupColumnColor
            // 
            this.dgvGroupColumnColor.HeaderText = "Color";
            this.dgvGroupColumnColor.Name = "dgvGroupColumnColor";
            this.dgvGroupColumnColor.ReadOnly = true;
            // 
            // cmsAvatarRightClick
            // 
            this.cmsAvatarRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAvatarRightClickCopy,
            this.toolStripSeparator9,
            this.cmsAvatarRightClickAvatar,
            this.cmsAvatarRightClickRecheck,
            this.toolStripSeparator2,
            this.cmsAvatarRightClickWatchGroup,
            this.cmsAvatarRightClickWatch,
            this.toolStripSeparator6,
            this.cmsAvatarRightClickNote});
            this.cmsAvatarRightClick.Name = "contextMenuStrip1";
            this.cmsAvatarRightClick.Size = new System.Drawing.Size(154, 154);
            this.cmsAvatarRightClick.Opening += new System.ComponentModel.CancelEventHandler(this.cmsAvatarRightClick_Opening);
            // 
            // cmsAvatarRightClickCopy
            // 
            this.cmsAvatarRightClickCopy.Name = "cmsAvatarRightClickCopy";
            this.cmsAvatarRightClickCopy.Size = new System.Drawing.Size(153, 22);
            this.cmsAvatarRightClickCopy.Text = "Copy";
            this.cmsAvatarRightClickCopy.Click += new System.EventHandler(this.cmsAvatarRightClickCopy_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(150, 6);
            // 
            // cmsAvatarRightClickAvatar
            // 
            this.cmsAvatarRightClickAvatar.Name = "cmsAvatarRightClickAvatar";
            this.cmsAvatarRightClickAvatar.Size = new System.Drawing.Size(153, 22);
            this.cmsAvatarRightClickAvatar.Text = "Avatar Page";
            this.cmsAvatarRightClickAvatar.Click += new System.EventHandler(this.cmsAvatarRightClickAvatar_Click);
            // 
            // cmsAvatarRightClickRecheck
            // 
            this.cmsAvatarRightClickRecheck.Name = "cmsAvatarRightClickRecheck";
            this.cmsAvatarRightClickRecheck.Size = new System.Drawing.Size(153, 22);
            this.cmsAvatarRightClickRecheck.Text = "Recheck";
            this.cmsAvatarRightClickRecheck.Click += new System.EventHandler(this.cmsAvatarRightClickRecheck_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // cmsAvatarRightClickWatchGroup
            // 
            this.cmsAvatarRightClickWatchGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAvatarRightClickWatchGroupUnset,
            this.cmsAvatarRightClickWatchGroupNew,
            this.cmsAvatarRightClickWatchGroupSeparator});
            this.cmsAvatarRightClickWatchGroup.Name = "cmsAvatarRightClickWatchGroup";
            this.cmsAvatarRightClickWatchGroup.Size = new System.Drawing.Size(153, 22);
            this.cmsAvatarRightClickWatchGroup.Text = "Watch Group...";
            // 
            // cmsAvatarRightClickWatchGroupUnset
            // 
            this.cmsAvatarRightClickWatchGroupUnset.Name = "cmsAvatarRightClickWatchGroupUnset";
            this.cmsAvatarRightClickWatchGroupUnset.Size = new System.Drawing.Size(180, 22);
            this.cmsAvatarRightClickWatchGroupUnset.Text = "Unset";
            this.cmsAvatarRightClickWatchGroupUnset.Click += new System.EventHandler(this.cmsAvatarRightClickWatchGroupUnset_Click);
            // 
            // cmsAvatarRightClickWatchGroupNew
            // 
            this.cmsAvatarRightClickWatchGroupNew.Name = "cmsAvatarRightClickWatchGroupNew";
            this.cmsAvatarRightClickWatchGroupNew.Size = new System.Drawing.Size(180, 22);
            this.cmsAvatarRightClickWatchGroupNew.Text = "New...";
            this.cmsAvatarRightClickWatchGroupNew.Click += new System.EventHandler(this.cmsAvatarRightClickWatchGroupNew_Click);
            // 
            // cmsAvatarRightClickWatchGroupSeparator
            // 
            this.cmsAvatarRightClickWatchGroupSeparator.Name = "cmsAvatarRightClickWatchGroupSeparator";
            this.cmsAvatarRightClickWatchGroupSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // cmsAvatarRightClickWatch
            // 
            this.cmsAvatarRightClickWatch.Name = "cmsAvatarRightClickWatch";
            this.cmsAvatarRightClickWatch.Size = new System.Drawing.Size(153, 22);
            this.cmsAvatarRightClickWatch.Text = "Watch";
            this.cmsAvatarRightClickWatch.Click += new System.EventHandler(this.cmsAvatarRightClickWatch_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(150, 6);
            // 
            // cmsAvatarRightClickNote
            // 
            this.cmsAvatarRightClickNote.Name = "cmsAvatarRightClickNote";
            this.cmsAvatarRightClickNote.Size = new System.Drawing.Size(153, 22);
            this.cmsAvatarRightClickNote.Text = "Note";
            this.cmsAvatarRightClickNote.Click += new System.EventHandler(this.cmsAvatarRightClickNote_Click);
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
            // cmsGroupRightClick
            // 
            this.cmsGroupRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsGroupRightClickCopy,
            this.toolStripSeparator11,
            this.cmsGroupRightClickEdit,
            this.cmsGroupRightClickDelete});
            this.cmsGroupRightClick.Name = "contextMenuStrip1";
            this.cmsGroupRightClick.Size = new System.Drawing.Size(108, 76);
            this.cmsGroupRightClick.Opening += new System.ComponentModel.CancelEventHandler(this.cmsGroupRightClick_Opening);
            // 
            // cmsGroupRightClickCopy
            // 
            this.cmsGroupRightClickCopy.Name = "cmsGroupRightClickCopy";
            this.cmsGroupRightClickCopy.Size = new System.Drawing.Size(107, 22);
            this.cmsGroupRightClickCopy.Text = "Copy";
            this.cmsGroupRightClickCopy.Click += new System.EventHandler(this.cmsGroupRightClickCopy_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(104, 6);
            // 
            // cmsGroupRightClickEdit
            // 
            this.cmsGroupRightClickEdit.Name = "cmsGroupRightClickEdit";
            this.cmsGroupRightClickEdit.Size = new System.Drawing.Size(107, 22);
            this.cmsGroupRightClickEdit.Text = "Edit";
            this.cmsGroupRightClickEdit.Click += new System.EventHandler(this.cmsGroupRightClickEdit_Click);
            // 
            // cmsGroupRightClickDelete
            // 
            this.cmsGroupRightClickDelete.Name = "cmsGroupRightClickDelete";
            this.cmsGroupRightClickDelete.Size = new System.Drawing.Size(107, 22);
            this.cmsGroupRightClickDelete.Text = "Delete";
            this.cmsGroupRightClickDelete.Click += new System.EventHandler(this.cmsGroupRightClickDelete_Click);
            // 
            // cmsEmpireRightClick
            // 
            this.cmsEmpireRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEmpireRightClickCopy,
            this.toolStripSeparator10,
            this.cmsEmpireRightClickRecheck,
            this.toolStripSeparator12,
            this.cmsEmpireRightClickWatchGroup,
            this.cmsEmpireRightClickWatch,
            this.toolStripSeparator14,
            this.cmsEmpireRightClickNote});
            this.cmsEmpireRightClick.Name = "contextMenuStrip1";
            this.cmsEmpireRightClick.Size = new System.Drawing.Size(154, 132);
            this.cmsEmpireRightClick.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEmpireRightClick_Opening);
            // 
            // cmsEmpireRightClickCopy
            // 
            this.cmsEmpireRightClickCopy.Name = "cmsEmpireRightClickCopy";
            this.cmsEmpireRightClickCopy.Size = new System.Drawing.Size(153, 22);
            this.cmsEmpireRightClickCopy.Text = "Copy";
            this.cmsEmpireRightClickCopy.Click += new System.EventHandler(this.cmsEmpireRightClickCopy_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(150, 6);
            // 
            // cmsEmpireRightClickRecheck
            // 
            this.cmsEmpireRightClickRecheck.Name = "cmsEmpireRightClickRecheck";
            this.cmsEmpireRightClickRecheck.Size = new System.Drawing.Size(153, 22);
            this.cmsEmpireRightClickRecheck.Text = "Recheck";
            this.cmsEmpireRightClickRecheck.Click += new System.EventHandler(this.cmsEmpireRightClickRecheck_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(150, 6);
            // 
            // cmsEmpireRightClickWatchGroup
            // 
            this.cmsEmpireRightClickWatchGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEmpireRightClickWatchGroupUnset,
            this.cmsEmpireRightClickWatchGroupNew,
            this.toolStripSeparator13});
            this.cmsEmpireRightClickWatchGroup.Name = "cmsEmpireRightClickWatchGroup";
            this.cmsEmpireRightClickWatchGroup.Size = new System.Drawing.Size(153, 22);
            this.cmsEmpireRightClickWatchGroup.Text = "Watch Group...";
            // 
            // cmsEmpireRightClickWatchGroupUnset
            // 
            this.cmsEmpireRightClickWatchGroupUnset.Name = "cmsEmpireRightClickWatchGroupUnset";
            this.cmsEmpireRightClickWatchGroupUnset.Size = new System.Drawing.Size(180, 22);
            this.cmsEmpireRightClickWatchGroupUnset.Text = "Unset";
            this.cmsEmpireRightClickWatchGroupUnset.Click += new System.EventHandler(this.cmsEmpireRightClickWatchGroupUnset_Click);
            // 
            // cmsEmpireRightClickWatchGroupNew
            // 
            this.cmsEmpireRightClickWatchGroupNew.Name = "cmsEmpireRightClickWatchGroupNew";
            this.cmsEmpireRightClickWatchGroupNew.Size = new System.Drawing.Size(180, 22);
            this.cmsEmpireRightClickWatchGroupNew.Text = "New...";
            this.cmsEmpireRightClickWatchGroupNew.Click += new System.EventHandler(this.cmsAvatarRightClickWatchGroupNew_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(177, 6);
            // 
            // cmsEmpireRightClickWatch
            // 
            this.cmsEmpireRightClickWatch.Name = "cmsEmpireRightClickWatch";
            this.cmsEmpireRightClickWatch.Size = new System.Drawing.Size(153, 22);
            this.cmsEmpireRightClickWatch.Text = "Watch";
            this.cmsEmpireRightClickWatch.Click += new System.EventHandler(this.cmsEmpireRightClickWatch_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(150, 6);
            // 
            // cmsEmpireRightClickNote
            // 
            this.cmsEmpireRightClickNote.Name = "cmsEmpireRightClickNote";
            this.cmsEmpireRightClickNote.Size = new System.Drawing.Size(153, 22);
            this.cmsEmpireRightClickNote.Text = "Note";
            this.cmsEmpireRightClickNote.Click += new System.EventHandler(this.cmsEmpireRightClickNote_Click);
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
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageAvatars.ResumeLayout(false);
            this.tabPageAvatars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvatarWatch)).EndInit();
            this.tabPageEmpires.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpireWatch)).EndInit();
            this.tabPageGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.cmsAvatarRightClick.ResumeLayout(false);
            this.cmsNotifyIconRightClick.ResumeLayout(false);
            this.cmsGroupRightClick.ResumeLayout(false);
            this.cmsEmpireRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1File;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1Options;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1Help;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1HelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1FileExit;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dgvOnline;
        private System.Windows.Forms.DataGridView dgvAvatarWatch;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsAvatarIds;
        private System.Windows.Forms.ContextMenuStrip cmsAvatarRightClick;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickWatch;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cmsNotifyIconRightClick;
        private System.Windows.Forms.ToolStripMenuItem cmsNotifyIconRightClickRestore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsWatchHighlight;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1HelpGithub;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1HelpThread;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1HelpHowToUse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickAvatar;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsNotificationSound;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickNote;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsRecentList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickWatchGroup;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickWatchGroupUnset;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickRecheck;
        private System.Windows.Forms.CheckBox chxHideNonWatched;
        private System.Windows.Forms.Button btnAddAvatar;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsWatchList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvRecent;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsMinimizeTray;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsTrayNotification;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickWatchGroupNew;
        private System.Windows.Forms.ToolStripSeparator cmsAvatarRightClickWatchGroupSeparator;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAvatars;
        private System.Windows.Forms.TabPage tabPageGroups;
        private System.Windows.Forms.Button btnGroupDelete;
        private System.Windows.Forms.Button btnGroupNew;
        private System.Windows.Forms.Button btnGroupEdit;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGroupColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGroupColumnGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGroupColumnMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGroupColumnNotify;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGroupColumnSound;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGroupColumnColor;
        private System.Windows.Forms.ContextMenuStrip cmsGroupRightClick;
        private System.Windows.Forms.ToolStripMenuItem cmsGroupRightClickCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem cmsGroupRightClickEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsGroupRightClickDelete;
        private System.Windows.Forms.TabPage tabPageEmpires;
        private System.Windows.Forms.DataGridView dgvEmpireWatch;
        private System.Windows.Forms.Button btnAddEmpire;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRecentColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRecentColumnAvatar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRecentColumnEmpire;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnlineColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnlineColumnAvatar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnlineColumnEmpire;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmpireWatchColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmpireWatchColumnEmpire;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmpireWatchColumnGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmpireWatchColumnNotify;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmpireWatchColumnNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAvatarWatchColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAvatarWatchColumnAvatar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAvatarWatchColumnGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAvatarWatchColumnNotify;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAvatarWatchColumnNote;
        private System.Windows.Forms.ContextMenuStrip cmsEmpireRightClick;
        private System.Windows.Forms.ToolStripMenuItem cmsEmpireRightClickCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem cmsEmpireRightClickRecheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem cmsEmpireRightClickWatchGroup;
        private System.Windows.Forms.ToolStripMenuItem cmsEmpireRightClickWatchGroupUnset;
        private System.Windows.Forms.ToolStripMenuItem cmsEmpireRightClickWatchGroupNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem cmsEmpireRightClickWatch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem cmsEmpireRightClickNote;
    }
}

