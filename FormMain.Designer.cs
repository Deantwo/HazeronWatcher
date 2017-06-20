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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvRecent = new System.Windows.Forms.DataGridView();
            this.dgvRecentColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRecentColumnAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAvatars = new System.Windows.Forms.TabPage();
            this.cbxStandingFilter = new System.Windows.Forms.ComboBox();
            this.dgvWatch = new System.Windows.Forms.DataGridView();
            this.dgvWatchColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWatchColumnAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWatchColumnGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWatchColumnNotify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWatchColumnNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddAvatar = new System.Windows.Forms.Button();
            this.chxHideNonWatched = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvWatch)).BeginInit();
            this.tabPageGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.cmsAvatarRightClick.SuspendLayout();
            this.cmsNotifyIconRightClick.SuspendLayout();
            this.cmsGroupRightClick.SuspendLayout();
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
            this.menuStrip1HelpGithub.Size = new System.Drawing.Size(156, 22);
            this.menuStrip1HelpGithub.Text = "GitHub Repo";
            this.menuStrip1HelpGithub.Click += new System.EventHandler(this.menuStrip1HelpGithub_Click);
            // 
            // menuStrip1HelpThread
            // 
            this.menuStrip1HelpThread.Name = "menuStrip1HelpThread";
            this.menuStrip1HelpThread.Size = new System.Drawing.Size(156, 22);
            this.menuStrip1HelpThread.Text = "Forum Thread";
            this.menuStrip1HelpThread.Click += new System.EventHandler(this.menuStrip1HelpThread_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(153, 6);
            // 
            // menuStrip1HelpAbout
            // 
            this.menuStrip1HelpAbout.Name = "menuStrip1HelpAbout";
            this.menuStrip1HelpAbout.Size = new System.Drawing.Size(156, 22);
            this.menuStrip1HelpAbout.Text = "About";
            this.menuStrip1HelpAbout.Click += new System.EventHandler(this.menuStrip1HelpAbout_Click);
            // 
            // menuStrip1HelpHowToUse
            // 
            this.menuStrip1HelpHowToUse.Name = "menuStrip1HelpHowToUse";
            this.menuStrip1HelpHowToUse.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuStrip1HelpHowToUse.Size = new System.Drawing.Size(156, 22);
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
            this.dgvOnlineColumnAvatar});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnline.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.dgvOnlineColumnAvatar.FillWeight = 1000F;
            this.dgvOnlineColumnAvatar.Frozen = true;
            this.dgvOnlineColumnAvatar.HeaderText = "Avatars Online";
            this.dgvOnlineColumnAvatar.MinimumWidth = 1000;
            this.dgvOnlineColumnAvatar.Name = "dgvOnlineColumnAvatar";
            this.dgvOnlineColumnAvatar.ReadOnly = true;
            this.dgvOnlineColumnAvatar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnlineColumnAvatar.Width = 1000;
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
            this.dgvRecentColumnAvatar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecent.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.dgvRecentColumnAvatar.FillWeight = 1000F;
            this.dgvRecentColumnAvatar.Frozen = true;
            this.dgvRecentColumnAvatar.HeaderText = "Recently Online";
            this.dgvRecentColumnAvatar.MinimumWidth = 1000;
            this.dgvRecentColumnAvatar.Name = "dgvRecentColumnAvatar";
            this.dgvRecentColumnAvatar.ReadOnly = true;
            this.dgvRecentColumnAvatar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecentColumnAvatar.Width = 1000;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAvatars);
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
            this.tabPageAvatars.Controls.Add(this.cbxStandingFilter);
            this.tabPageAvatars.Controls.Add(this.dgvWatch);
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
            // cbxStandingFilter
            // 
            this.cbxStandingFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxStandingFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStandingFilter.FormattingEnabled = true;
            this.cbxStandingFilter.Items.AddRange(new object[] {
            "Show all",
            "Empire",
            "Friend",
            "Neutral",
            "Unsure",
            "Enemy"});
            this.cbxStandingFilter.Location = new System.Drawing.Point(6, 6);
            this.cbxStandingFilter.Name = "cbxStandingFilter";
            this.cbxStandingFilter.Size = new System.Drawing.Size(188, 21);
            this.cbxStandingFilter.TabIndex = 2;
            this.cbxStandingFilter.SelectedIndexChanged += new System.EventHandler(this.cbxStandingFilter_SelectedIndexChanged);
            // 
            // dgvWatch
            // 
            this.dgvWatch.AllowUserToAddRows = false;
            this.dgvWatch.AllowUserToDeleteRows = false;
            this.dgvWatch.AllowUserToResizeRows = false;
            this.dgvWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvWatchColumnId,
            this.dgvWatchColumnAvatar,
            this.dgvWatchColumnGroup,
            this.dgvWatchColumnNotify,
            this.dgvWatchColumnNote});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWatch.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWatch.Location = new System.Drawing.Point(6, 85);
            this.dgvWatch.Name = "dgvWatch";
            this.dgvWatch.ReadOnly = true;
            this.dgvWatch.RowHeadersVisible = false;
            this.dgvWatch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvWatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWatch.Size = new System.Drawing.Size(188, 170);
            this.dgvWatch.TabIndex = 0;
            this.dgvWatch.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAvatar_CellMouseDown);
            this.dgvWatch.Click += new System.EventHandler(this.dgv_Click);
            this.dgvWatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAvatar_KeyDown);
            // 
            // dgvWatchColumnId
            // 
            this.dgvWatchColumnId.FillWeight = 50F;
            this.dgvWatchColumnId.Frozen = true;
            this.dgvWatchColumnId.HeaderText = "ID";
            this.dgvWatchColumnId.Name = "dgvWatchColumnId";
            this.dgvWatchColumnId.ReadOnly = true;
            this.dgvWatchColumnId.Width = 50;
            // 
            // dgvWatchColumnAvatar
            // 
            this.dgvWatchColumnAvatar.HeaderText = "Avatar";
            this.dgvWatchColumnAvatar.Name = "dgvWatchColumnAvatar";
            this.dgvWatchColumnAvatar.ReadOnly = true;
            // 
            // dgvWatchColumnGroup
            // 
            this.dgvWatchColumnGroup.HeaderText = "Group";
            this.dgvWatchColumnGroup.Name = "dgvWatchColumnGroup";
            this.dgvWatchColumnGroup.ReadOnly = true;
            // 
            // dgvWatchColumnNotify
            // 
            this.dgvWatchColumnNotify.HeaderText = "Notify";
            this.dgvWatchColumnNotify.Name = "dgvWatchColumnNotify";
            this.dgvWatchColumnNotify.ReadOnly = true;
            // 
            // dgvWatchColumnNote
            // 
            this.dgvWatchColumnNote.HeaderText = "Note";
            this.dgvWatchColumnNote.Name = "dgvWatchColumnNote";
            this.dgvWatchColumnNote.ReadOnly = true;
            // 
            // btnAddAvatar
            // 
            this.btnAddAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAvatar.Location = new System.Drawing.Point(6, 56);
            this.btnAddAvatar.Name = "btnAddAvatar";
            this.btnAddAvatar.Size = new System.Drawing.Size(188, 23);
            this.btnAddAvatar.TabIndex = 3;
            this.btnAddAvatar.Text = "Add Avatar via ID";
            this.btnAddAvatar.UseVisualStyleBackColor = true;
            this.btnAddAvatar.Click += new System.EventHandler(this.btnAddAvatar_Click);
            // 
            // chxHideNonWatched
            // 
            this.chxHideNonWatched.AutoCheck = false;
            this.chxHideNonWatched.AutoSize = true;
            this.chxHideNonWatched.Location = new System.Drawing.Point(6, 33);
            this.chxHideNonWatched.Name = "chxHideNonWatched";
            this.chxHideNonWatched.Size = new System.Drawing.Size(116, 17);
            this.chxHideNonWatched.TabIndex = 1;
            this.chxHideNonWatched.Text = "Hide non-Watched";
            this.chxHideNonWatched.UseVisualStyleBackColor = true;
            this.chxHideNonWatched.Click += new System.EventHandler(this.chxHideNonWatched_Click);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGroup.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.cmsAvatarRightClickWatchGroupUnset.Size = new System.Drawing.Size(107, 22);
            this.cmsAvatarRightClickWatchGroupUnset.Text = "Unset";
            this.cmsAvatarRightClickWatchGroupUnset.Click += new System.EventHandler(this.cmsAvatarRightClickWatchGroupUnset_Click);
            // 
            // cmsAvatarRightClickWatchGroupNew
            // 
            this.cmsAvatarRightClickWatchGroupNew.Name = "cmsAvatarRightClickWatchGroupNew";
            this.cmsAvatarRightClickWatchGroupNew.Size = new System.Drawing.Size(107, 22);
            this.cmsAvatarRightClickWatchGroupNew.Text = "New...";
            this.cmsAvatarRightClickWatchGroupNew.Click += new System.EventHandler(this.cmsAvatarRightClickWatchGroupNew_Click);
            // 
            // cmsAvatarRightClickWatchGroupSeparator
            // 
            this.cmsAvatarRightClickWatchGroupSeparator.Name = "cmsAvatarRightClickWatchGroupSeparator";
            this.cmsAvatarRightClickWatchGroupSeparator.Size = new System.Drawing.Size(104, 6);
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
            this.cmsGroupRightClick.Size = new System.Drawing.Size(153, 98);
            this.cmsGroupRightClick.Opening += new System.ComponentModel.CancelEventHandler(this.cmsGroupRightClick_Opening);
            // 
            // cmsGroupRightClickCopy
            // 
            this.cmsGroupRightClickCopy.Name = "cmsGroupRightClickCopy";
            this.cmsGroupRightClickCopy.Size = new System.Drawing.Size(152, 22);
            this.cmsGroupRightClickCopy.Text = "Copy";
            this.cmsGroupRightClickCopy.Click += new System.EventHandler(this.cmsGroupRightClickCopy_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(149, 6);
            // 
            // cmsGroupRightClickEdit
            // 
            this.cmsGroupRightClickEdit.Name = "cmsGroupRightClickEdit";
            this.cmsGroupRightClickEdit.Size = new System.Drawing.Size(152, 22);
            this.cmsGroupRightClickEdit.Text = "Edit";
            this.cmsGroupRightClickEdit.Click += new System.EventHandler(this.cmsGroupRightClickEdit_Click);
            // 
            // cmsGroupRightClickDelete
            // 
            this.cmsGroupRightClickDelete.Name = "cmsGroupRightClickDelete";
            this.cmsGroupRightClickDelete.Size = new System.Drawing.Size(152, 22);
            this.cmsGroupRightClickDelete.Text = "Delete";
            this.cmsGroupRightClickDelete.Click += new System.EventHandler(this.cmsGroupRightClickDelete_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvWatch)).EndInit();
            this.tabPageGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.cmsAvatarRightClick.ResumeLayout(false);
            this.cmsNotifyIconRightClick.ResumeLayout(false);
            this.cmsGroupRightClick.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dgvWatch;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnlineColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnlineColumnAvatar;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickWatchGroup;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickWatchGroupUnset;
        private System.Windows.Forms.ToolStripMenuItem cmsAvatarRightClickRecheck;
        private System.Windows.Forms.CheckBox chxHideNonWatched;
        private System.Windows.Forms.ComboBox cbxStandingFilter;
        private System.Windows.Forms.Button btnAddAvatar;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsWatchList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvRecent;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1OptionsMinimizeTray;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRecentColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRecentColumnAvatar;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvWatchColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvWatchColumnAvatar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvWatchColumnGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvWatchColumnNotify;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvWatchColumnNote;
    }
}

