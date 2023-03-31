namespace Typhoon.NET
{
    partial class MainForm
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
            this.AppMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenTileset = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveTileset = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSpacer2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNewTilemap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenTilemap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveTilemap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GameDevModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fraTiles = new System.Windows.Forms.GroupBox();
            this.pnlTiles = new System.Windows.Forms.Panel();
            this.picTiles = new System.Windows.Forms.PictureBox();
            this.fraMap = new System.Windows.Forms.GroupBox();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.fraTileset = new System.Windows.Forms.GroupBox();
            this.pnlTileset = new System.Windows.Forms.Panel();
            this.picTileset = new System.Windows.Forms.PictureBox();
            this.lblPaletteIndex = new System.Windows.Forms.Label();
            this.fraCurrentTile = new System.Windows.Forms.GroupBox();
            this.picCurrentTile = new System.Windows.Forms.PictureBox();
            this.PaletteIndexCombo = new System.Windows.Forms.ComboBox();
            this.AppStatusBar = new System.Windows.Forms.StatusStrip();
            this.lblCurrentTile = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentTileblock = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.AppToolbar = new System.Windows.Forms.ToolStrip();
            this.chkHFlip = new System.Windows.Forms.CheckBox();
            this.chkVFlip = new System.Windows.Forms.CheckBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.fraDimensions = new System.Windows.Forms.GroupBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.picCurrentTileblock = new System.Windows.Forms.PictureBox();
            this.fraCurrentTileblock = new System.Windows.Forms.GroupBox();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.picTop = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdSaveTile = new System.Windows.Forms.Button();
            this.AppMenu.SuspendLayout();
            this.fraTiles.SuspendLayout();
            this.pnlTiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTiles)).BeginInit();
            this.fraMap.SuspendLayout();
            this.pnlMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.fraTileset.SuspendLayout();
            this.pnlTileset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTileset)).BeginInit();
            this.fraCurrentTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentTile)).BeginInit();
            this.AppStatusBar.SuspendLayout();
            this.fraDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentTileblock)).BeginInit();
            this.fraCurrentTileblock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppMenu
            // 
            this.AppMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.AppMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.AppMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.OptionsMenu,
            this.HelpMenu});
            this.AppMenu.Location = new System.Drawing.Point(0, 0);
            this.AppMenu.Name = "AppMenu";
            this.AppMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.AppMenu.Size = new System.Drawing.Size(1236, 35);
            this.AppMenu.TabIndex = 0;
            this.AppMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenTiles,
            this.mnuOpenTileset,
            this.mnuSaveTileset,
            this.mnuSpacer2,
            this.mnuNewTilemap,
            this.mnuOpenTilemap,
            this.mnuSaveTilemap,
            this.mnuSeparator1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(54, 29);
            this.mnuFile.Text = "&File";
            // 
            // mnuOpenTiles
            // 
            this.mnuOpenTiles.Name = "mnuOpenTiles";
            this.mnuOpenTiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpenTiles.Size = new System.Drawing.Size(297, 34);
            this.mnuOpenTiles.Text = "Open Tiles...";
            this.mnuOpenTiles.Click += new System.EventHandler(this.mnuOpenTiles_Click);
            // 
            // mnuOpenTileset
            // 
            this.mnuOpenTileset.Enabled = false;
            this.mnuOpenTileset.Name = "mnuOpenTileset";
            this.mnuOpenTileset.Size = new System.Drawing.Size(297, 34);
            this.mnuOpenTileset.Text = "Open Tileset...";
            this.mnuOpenTileset.Click += new System.EventHandler(this.mnuOpenTileset_Click);
            // 
            // mnuSaveTileset
            // 
            this.mnuSaveTileset.Enabled = false;
            this.mnuSaveTileset.Name = "mnuSaveTileset";
            this.mnuSaveTileset.Size = new System.Drawing.Size(297, 34);
            this.mnuSaveTileset.Text = "Save Tileset";
            this.mnuSaveTileset.Click += new System.EventHandler(this.mnuSaveTileset_Click);
            // 
            // mnuSpacer2
            // 
            this.mnuSpacer2.Name = "mnuSpacer2";
            this.mnuSpacer2.Size = new System.Drawing.Size(294, 6);
            // 
            // mnuNewTilemap
            // 
            this.mnuNewTilemap.Enabled = false;
            this.mnuNewTilemap.Name = "mnuNewTilemap";
            this.mnuNewTilemap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNewTilemap.Size = new System.Drawing.Size(297, 34);
            this.mnuNewTilemap.Text = "New Tilemap";
            this.mnuNewTilemap.Click += new System.EventHandler(this.mnuNewTilemap_Click);
            // 
            // mnuOpenTilemap
            // 
            this.mnuOpenTilemap.Enabled = false;
            this.mnuOpenTilemap.Name = "mnuOpenTilemap";
            this.mnuOpenTilemap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuOpenTilemap.Size = new System.Drawing.Size(297, 34);
            this.mnuOpenTilemap.Text = "Open Tilemap...";
            this.mnuOpenTilemap.Click += new System.EventHandler(this.mnuOpenTilemap_Click);
            // 
            // mnuSaveTilemap
            // 
            this.mnuSaveTilemap.Enabled = false;
            this.mnuSaveTilemap.Name = "mnuSaveTilemap";
            this.mnuSaveTilemap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSaveTilemap.Size = new System.Drawing.Size(297, 34);
            this.mnuSaveTilemap.Text = "Save Tilemap";
            this.mnuSaveTilemap.Click += new System.EventHandler(this.mnuSaveTilemap_Click);
            // 
            // mnuSeparator1
            // 
            this.mnuSeparator1.Name = "mnuSeparator1";
            this.mnuSeparator1.Size = new System.Drawing.Size(294, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(297, 34);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameDevModeMenuItem});
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(92, 29);
            this.OptionsMenu.Text = "&Options";
            // 
            // GameDevModeMenuItem
            // 
            this.GameDevModeMenuItem.Enabled = false;
            this.GameDevModeMenuItem.Name = "GameDevModeMenuItem";
            this.GameDevModeMenuItem.Size = new System.Drawing.Size(270, 34);
            this.GameDevModeMenuItem.Text = "GameDev Mode";
            this.GameDevModeMenuItem.Click += new System.EventHandler(this.GameDevModeMenuItem_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuItem});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(65, 29);
            this.HelpMenu.Text = "&Help";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(274, 34);
            this.AboutMenuItem.Text = "About Typhoon.NET";
            // 
            // fraTiles
            // 
            this.fraTiles.Controls.Add(this.pnlTiles);
            this.fraTiles.Location = new System.Drawing.Point(12, 86);
            this.fraTiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraTiles.Name = "fraTiles";
            this.fraTiles.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraTiles.Size = new System.Drawing.Size(372, 246);
            this.fraTiles.TabIndex = 1;
            this.fraTiles.TabStop = false;
            this.fraTiles.Text = "Tiles";
            // 
            // pnlTiles
            // 
            this.pnlTiles.AutoScroll = true;
            this.pnlTiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTiles.Controls.Add(this.picTiles);
            this.pnlTiles.Location = new System.Drawing.Point(12, 25);
            this.pnlTiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTiles.Name = "pnlTiles";
            this.pnlTiles.Size = new System.Drawing.Size(347, 208);
            this.pnlTiles.TabIndex = 0;
            this.pnlTiles.Visible = false;
            // 
            // picTiles
            // 
            this.picTiles.Location = new System.Drawing.Point(0, 0);
            this.picTiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picTiles.Name = "picTiles";
            this.picTiles.Size = new System.Drawing.Size(128, 48);
            this.picTiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTiles.TabIndex = 0;
            this.picTiles.TabStop = false;
            this.picTiles.Paint += new System.Windows.Forms.PaintEventHandler(this.picTiles_Paint);
            this.picTiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTiles_MouseHandle);
            this.picTiles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTiles_MouseHandle);
            // 
            // fraMap
            // 
            this.fraMap.Controls.Add(this.pnlMap);
            this.fraMap.Location = new System.Drawing.Point(396, 86);
            this.fraMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraMap.Name = "fraMap";
            this.fraMap.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraMap.Size = new System.Drawing.Size(576, 578);
            this.fraMap.TabIndex = 2;
            this.fraMap.TabStop = false;
            this.fraMap.Text = "Map";
            // 
            // pnlMap
            // 
            this.pnlMap.AutoScroll = true;
            this.pnlMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMap.Controls.Add(this.picMap);
            this.pnlMap.Location = new System.Drawing.Point(12, 25);
            this.pnlMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(551, 540);
            this.pnlMap.TabIndex = 0;
            this.pnlMap.Visible = false;
            // 
            // picMap
            // 
            this.picMap.Location = new System.Drawing.Point(0, 0);
            this.picMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(200, 144);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            this.picMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseHandle);
            this.picMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseHandle);
            // 
            // fraTileset
            // 
            this.fraTileset.Controls.Add(this.pnlTileset);
            this.fraTileset.Location = new System.Drawing.Point(984, 86);
            this.fraTileset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraTileset.Name = "fraTileset";
            this.fraTileset.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraTileset.Size = new System.Drawing.Size(240, 578);
            this.fraTileset.TabIndex = 3;
            this.fraTileset.TabStop = false;
            this.fraTileset.Text = "Tileset";
            // 
            // pnlTileset
            // 
            this.pnlTileset.AutoScroll = true;
            this.pnlTileset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTileset.Controls.Add(this.picTileset);
            this.pnlTileset.Location = new System.Drawing.Point(12, 25);
            this.pnlTileset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTileset.Name = "pnlTileset";
            this.pnlTileset.Size = new System.Drawing.Size(215, 540);
            this.pnlTileset.TabIndex = 0;
            // 
            // picTileset
            // 
            this.picTileset.Location = new System.Drawing.Point(0, 0);
            this.picTileset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picTileset.Name = "picTileset";
            this.picTileset.Size = new System.Drawing.Size(120, 64);
            this.picTileset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTileset.TabIndex = 0;
            this.picTileset.TabStop = false;
            this.picTileset.Paint += new System.Windows.Forms.PaintEventHandler(this.picTileset_Paint);
            this.picTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTileset_MouseHandle);
            this.picTileset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTileset_MouseHandle);
            // 
            // lblPaletteIndex
            // 
            this.lblPaletteIndex.AutoSize = true;
            this.lblPaletteIndex.Location = new System.Drawing.Point(276, 345);
            this.lblPaletteIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaletteIndex.Name = "lblPaletteIndex";
            this.lblPaletteIndex.Size = new System.Drawing.Size(102, 20);
            this.lblPaletteIndex.TabIndex = 4;
            this.lblPaletteIndex.Text = "Palette Index";
            // 
            // fraCurrentTile
            // 
            this.fraCurrentTile.Controls.Add(this.picCurrentTile);
            this.fraCurrentTile.Location = new System.Drawing.Point(12, 332);
            this.fraCurrentTile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraCurrentTile.Name = "fraCurrentTile";
            this.fraCurrentTile.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraCurrentTile.Size = new System.Drawing.Size(96, 111);
            this.fraCurrentTile.TabIndex = 5;
            this.fraCurrentTile.TabStop = false;
            // 
            // picCurrentTile
            // 
            this.picCurrentTile.Location = new System.Drawing.Point(12, 25);
            this.picCurrentTile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picCurrentTile.Name = "picCurrentTile";
            this.picCurrentTile.Size = new System.Drawing.Size(32, 32);
            this.picCurrentTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCurrentTile.TabIndex = 6;
            this.picCurrentTile.TabStop = false;
            this.picCurrentTile.Visible = false;
            // 
            // PaletteIndexCombo
            // 
            this.PaletteIndexCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PaletteIndexCombo.Enabled = false;
            this.PaletteIndexCombo.FormattingEnabled = true;
            this.PaletteIndexCombo.Items.AddRange(new object[] {
            "PAL 0",
            "PAL 1",
            "PAL 2",
            "PAL 3",
            "PAL 4",
            "PAL 5",
            "PAL 6",
            "PAL 7",
            "PAL 8",
            "PAL 9",
            "PAL 10",
            "PAL 11",
            "PAL 12",
            "PAL 13",
            "PAL 14",
            "PAL 15"});
            this.PaletteIndexCombo.Location = new System.Drawing.Point(276, 369);
            this.PaletteIndexCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PaletteIndexCombo.Name = "PaletteIndexCombo";
            this.PaletteIndexCombo.Size = new System.Drawing.Size(106, 28);
            this.PaletteIndexCombo.TabIndex = 6;
            this.PaletteIndexCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteIndexCombo_SelectedIndexChanged);
            // 
            // AppStatusBar
            // 
            this.AppStatusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.AppStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentTile,
            this.lblCurrentTileblock,
            this.lblLocation});
            this.AppStatusBar.Location = new System.Drawing.Point(0, 675);
            this.AppStatusBar.Name = "AppStatusBar";
            this.AppStatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.AppStatusBar.Size = new System.Drawing.Size(1236, 36);
            this.AppStatusBar.TabIndex = 7;
            // 
            // lblCurrentTile
            // 
            this.lblCurrentTile.Name = "lblCurrentTile";
            this.lblCurrentTile.Size = new System.Drawing.Size(134, 29);
            this.lblCurrentTile.Text = "Current Tile: ???";
            // 
            // lblCurrentTileblock
            // 
            this.lblCurrentTileblock.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblCurrentTileblock.Name = "lblCurrentTileblock";
            this.lblCurrentTileblock.Size = new System.Drawing.Size(181, 29);
            this.lblCurrentTileblock.Text = "Current Tileblock: ???";
            // 
            // lblLocation
            // 
            this.lblLocation.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(103, 29);
            this.lblLocation.Text = "X: ??? Y:???";
            // 
            // AppToolbar
            // 
            this.AppToolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.AppToolbar.Location = new System.Drawing.Point(0, 35);
            this.AppToolbar.Name = "AppToolbar";
            this.AppToolbar.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.AppToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.AppToolbar.Size = new System.Drawing.Size(1236, 25);
            this.AppToolbar.TabIndex = 8;
            // 
            // chkHFlip
            // 
            this.chkHFlip.AutoSize = true;
            this.chkHFlip.Enabled = false;
            this.chkHFlip.Location = new System.Drawing.Point(12, 566);
            this.chkHFlip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHFlip.Name = "chkHFlip";
            this.chkHFlip.Size = new System.Drawing.Size(77, 24);
            this.chkHFlip.TabIndex = 1;
            this.chkHFlip.Text = "H-Flip";
            this.chkHFlip.UseVisualStyleBackColor = true;
            this.chkHFlip.CheckedChanged += new System.EventHandler(this.chkHFlip_CheckedChanged);
            // 
            // chkVFlip
            // 
            this.chkVFlip.AutoSize = true;
            this.chkVFlip.Enabled = false;
            this.chkVFlip.Location = new System.Drawing.Point(12, 591);
            this.chkVFlip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVFlip.Name = "chkVFlip";
            this.chkVFlip.Size = new System.Drawing.Size(76, 24);
            this.chkVFlip.TabIndex = 9;
            this.chkVFlip.Text = "V-Flip";
            this.chkVFlip.UseVisualStyleBackColor = true;
            this.chkVFlip.CheckedChanged += new System.EventHandler(this.chkVFlip_CheckedChanged);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(12, 34);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(50, 20);
            this.lblWidth.TabIndex = 1;
            this.lblWidth.Text = "Width";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(12, 71);
            this.lblHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(56, 20);
            this.lblHeight.TabIndex = 10;
            this.lblHeight.Text = "Height";
            // 
            // fraDimensions
            // 
            this.fraDimensions.Controls.Add(this.txtHeight);
            this.fraDimensions.Controls.Add(this.txtWidth);
            this.fraDimensions.Controls.Add(this.lblWidth);
            this.fraDimensions.Controls.Add(this.lblHeight);
            this.fraDimensions.Location = new System.Drawing.Point(120, 332);
            this.fraDimensions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraDimensions.Name = "fraDimensions";
            this.fraDimensions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraDimensions.Size = new System.Drawing.Size(144, 111);
            this.fraDimensions.TabIndex = 1;
            this.fraDimensions.TabStop = false;
            this.fraDimensions.Text = "Map Size";
            // 
            // txtHeight
            // 
            this.txtHeight.Enabled = false;
            this.txtHeight.Location = new System.Drawing.Point(72, 68);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHeight.MaxLength = 3;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(55, 26);
            this.txtHeight.TabIndex = 10;
            // 
            // txtWidth
            // 
            this.txtWidth.Enabled = false;
            this.txtWidth.Location = new System.Drawing.Point(72, 31);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWidth.MaxLength = 3;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(55, 26);
            this.txtWidth.TabIndex = 1;
            // 
            // picCurrentTileblock
            // 
            this.picCurrentTileblock.Location = new System.Drawing.Point(12, 25);
            this.picCurrentTileblock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picCurrentTileblock.Name = "picCurrentTileblock";
            this.picCurrentTileblock.Size = new System.Drawing.Size(32, 32);
            this.picCurrentTileblock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCurrentTileblock.TabIndex = 6;
            this.picCurrentTileblock.TabStop = false;
            // 
            // fraCurrentTileblock
            // 
            this.fraCurrentTileblock.Controls.Add(this.picCurrentTileblock);
            this.fraCurrentTileblock.Location = new System.Drawing.Point(12, 443);
            this.fraCurrentTileblock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraCurrentTileblock.Name = "fraCurrentTileblock";
            this.fraCurrentTileblock.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fraCurrentTileblock.Size = new System.Drawing.Size(96, 111);
            this.fraCurrentTileblock.TabIndex = 10;
            this.fraCurrentTileblock.TabStop = false;
            // 
            // picBottom
            // 
            this.picBottom.Location = new System.Drawing.Point(12, 25);
            this.picBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(72, 74);
            this.picBottom.TabIndex = 1;
            this.picBottom.TabStop = false;
            this.picBottom.Visible = false;
            this.picBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBottom_MouseHandle);
            this.picBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBottom_MouseHandle);
            // 
            // picTop
            // 
            this.picTop.Location = new System.Drawing.Point(96, 25);
            this.picTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(72, 74);
            this.picTop.TabIndex = 12;
            this.picTop.TabStop = false;
            this.picTop.Visible = false;
            this.picTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTop_MouseHandle);
            this.picTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTop_MouseHandle);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdSaveTile);
            this.groupBox1.Controls.Add(this.picBottom);
            this.groupBox1.Controls.Add(this.picTop);
            this.groupBox1.Location = new System.Drawing.Point(120, 443);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(264, 111);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bottom/Top";
            // 
            // cmdSaveTile
            // 
            this.cmdSaveTile.Enabled = false;
            this.cmdSaveTile.Location = new System.Drawing.Point(180, 62);
            this.cmdSaveTile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdSaveTile.Name = "cmdSaveTile";
            this.cmdSaveTile.Size = new System.Drawing.Size(72, 37);
            this.cmdSaveTile.TabIndex = 1;
            this.cmdSaveTile.Text = "Save";
            this.cmdSaveTile.UseVisualStyleBackColor = true;
            this.cmdSaveTile.Click += new System.EventHandler(this.cmdSaveTile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 711);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkHFlip);
            this.Controls.Add(this.chkVFlip);
            this.Controls.Add(this.fraCurrentTileblock);
            this.Controls.Add(this.fraDimensions);
            this.Controls.Add(this.AppToolbar);
            this.Controls.Add(this.AppStatusBar);
            this.Controls.Add(this.PaletteIndexCombo);
            this.Controls.Add(this.fraCurrentTile);
            this.Controls.Add(this.lblPaletteIndex);
            this.Controls.Add(this.fraTileset);
            this.Controls.Add(this.fraMap);
            this.Controls.Add(this.fraTiles);
            this.Controls.Add(this.AppMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.AppMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Typhoon.NET";
            this.AppMenu.ResumeLayout(false);
            this.AppMenu.PerformLayout();
            this.fraTiles.ResumeLayout(false);
            this.pnlTiles.ResumeLayout(false);
            this.pnlTiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTiles)).EndInit();
            this.fraMap.ResumeLayout(false);
            this.pnlMap.ResumeLayout(false);
            this.pnlMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.fraTileset.ResumeLayout(false);
            this.pnlTileset.ResumeLayout(false);
            this.pnlTileset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTileset)).EndInit();
            this.fraCurrentTile.ResumeLayout(false);
            this.fraCurrentTile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentTile)).EndInit();
            this.AppStatusBar.ResumeLayout(false);
            this.AppStatusBar.PerformLayout();
            this.fraDimensions.ResumeLayout(false);
            this.fraDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentTileblock)).EndInit();
            this.fraCurrentTileblock.ResumeLayout(false);
            this.fraCurrentTileblock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip AppMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.GroupBox fraTiles;
        private System.Windows.Forms.Panel pnlTiles;
        private System.Windows.Forms.GroupBox fraMap;
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.GroupBox fraTileset;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenTiles;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenTilemap;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveTilemap;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Panel pnlTileset;
        private System.Windows.Forms.Label lblPaletteIndex;
        private System.Windows.Forms.GroupBox fraCurrentTile;
        private System.Windows.Forms.PictureBox picCurrentTile;
        private System.Windows.Forms.ComboBox PaletteIndexCombo;
        private System.Windows.Forms.StatusStrip AppStatusBar;
        private System.Windows.Forms.ToolStrip AppToolbar;
        private System.Windows.Forms.PictureBox picTiles;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.PictureBox picTileset;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentTile;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem GameDevModeMenuItem;
        private System.Windows.Forms.CheckBox chkHFlip;
        private System.Windows.Forms.CheckBox chkVFlip;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.GroupBox fraDimensions;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.ToolStripMenuItem mnuNewTilemap;
        private System.Windows.Forms.ToolStripSeparator mnuSpacer2;
        private System.Windows.Forms.ToolStripStatusLabel lblLocation;
        private System.Windows.Forms.PictureBox picCurrentTileblock;
        private System.Windows.Forms.GroupBox fraCurrentTileblock;
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentTileblock;
        private System.Windows.Forms.PictureBox picTop;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenTileset;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveTileset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdSaveTile;
    }
}

