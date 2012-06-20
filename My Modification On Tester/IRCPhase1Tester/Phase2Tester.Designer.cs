using System;
namespace IRCPhase1Tester
{
    partial class Phase2Tester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Phase2Tester));
            this.txtServerPath = new System.Windows.Forms.TextBox();
            this.lblServerExePath = new System.Windows.Forms.Label();
            this.btnBrowseServer = new System.Windows.Forms.Button();
            this.txtSolutionPath = new System.Windows.Forms.TextBox();
            this.lblSolutionPath = new System.Windows.Forms.Label();
            this.btnBrowseSolution = new System.Windows.Forms.Button();
            this.txtSecretKey = new System.Windows.Forms.TextBox();
            this.lblSecretKey = new System.Windows.Forms.Label();
            this.btnRunTests = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnUpload = new System.Windows.Forms.Button();
            this.progressUpload = new System.Windows.Forms.ProgressBar();
            this.ofdServer = new System.Windows.Forms.OpenFileDialog();
            this.ofdSolution = new System.Windows.Forms.OpenFileDialog();
            this.lvTests = new System.Windows.Forms.ListView();
            this.colLVTests_Number = new System.Windows.Forms.ColumnHeader();
            this.colLVTests_Name = new System.Windows.Forms.ColumnHeader();
            this.scData = new System.Windows.Forms.SplitContainer();
            this.btnStop = new System.Windows.Forms.Button();
            this.lvTestingProgress = new System.Windows.Forms.ListView();
            this.colTestName = new System.Windows.Forms.ColumnHeader();
            this.colTestResult = new System.Windows.Forms.ColumnHeader();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnRunCheckedTests = new System.Windows.Forms.Button();
            this.btnThemePink = new System.Windows.Forms.Button();
            this.btnThemeBlue = new System.Windows.Forms.Button();
            this.btnThemeWhite = new System.Windows.Forms.Button();
            this.btnThemeOrange = new System.Windows.Forms.Button();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.lblComplete = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pbResize = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.scData.Panel1.SuspendLayout();
            this.scData.Panel2.SuspendLayout();
            this.scData.SuspendLayout();
            this.pnlBackground.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResize)).BeginInit();
            this.SuspendLayout();
            // 
            // txtServerPath
            // 
            this.txtServerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerPath.Location = new System.Drawing.Point(105, 17);
            this.txtServerPath.Name = "txtServerPath";
            this.txtServerPath.ReadOnly = true;
            this.txtServerPath.Size = new System.Drawing.Size(330, 20);
            this.txtServerPath.TabIndex = 6;
            // 
            // lblServerExePath
            // 
            this.lblServerExePath.AutoSize = true;
            this.lblServerExePath.Location = new System.Drawing.Point(8, 20);
            this.lblServerExePath.Name = "lblServerExePath";
            this.lblServerExePath.Size = new System.Drawing.Size(85, 13);
            this.lblServerExePath.TabIndex = 5;
            this.lblServerExePath.Text = "Server Exe Path";
            // 
            // btnBrowseServer
            // 
            this.btnBrowseServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseServer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseServer.BackgroundImage")));
            this.btnBrowseServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBrowseServer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBrowseServer.FlatAppearance.BorderSize = 0;
            this.btnBrowseServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBrowseServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightYellow;
            this.btnBrowseServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseServer.Location = new System.Drawing.Point(441, 11);
            this.btnBrowseServer.Name = "btnBrowseServer";
            this.btnBrowseServer.Size = new System.Drawing.Size(30, 30);
            this.btnBrowseServer.TabIndex = 4;
            this.btnBrowseServer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBrowseServer.UseVisualStyleBackColor = true;
            this.btnBrowseServer.Click += new System.EventHandler(this.btnBrowseServer_Click);
            // 
            // txtSolutionPath
            // 
            this.txtSolutionPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSolutionPath.Location = new System.Drawing.Point(105, 59);
            this.txtSolutionPath.Name = "txtSolutionPath";
            this.txtSolutionPath.ReadOnly = true;
            this.txtSolutionPath.Size = new System.Drawing.Size(330, 20);
            this.txtSolutionPath.TabIndex = 9;
            // 
            // lblSolutionPath
            // 
            this.lblSolutionPath.AutoSize = true;
            this.lblSolutionPath.Location = new System.Drawing.Point(8, 63);
            this.lblSolutionPath.Name = "lblSolutionPath";
            this.lblSolutionPath.Size = new System.Drawing.Size(70, 13);
            this.lblSolutionPath.TabIndex = 8;
            this.lblSolutionPath.Text = "Solution Path";
            // 
            // btnBrowseSolution
            // 
            this.btnBrowseSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSolution.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseSolution.BackgroundImage")));
            this.btnBrowseSolution.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBrowseSolution.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBrowseSolution.FlatAppearance.BorderSize = 0;
            this.btnBrowseSolution.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBrowseSolution.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightYellow;
            this.btnBrowseSolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseSolution.Location = new System.Drawing.Point(441, 54);
            this.btnBrowseSolution.Name = "btnBrowseSolution";
            this.btnBrowseSolution.Size = new System.Drawing.Size(30, 30);
            this.btnBrowseSolution.TabIndex = 7;
            this.btnBrowseSolution.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBrowseSolution.UseVisualStyleBackColor = true;
            this.btnBrowseSolution.Click += new System.EventHandler(this.btnBrowseSolution_Click);
            // 
            // txtSecretKey
            // 
            this.txtSecretKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecretKey.Location = new System.Drawing.Point(105, 95);
            this.txtSecretKey.Name = "txtSecretKey";
            this.txtSecretKey.Size = new System.Drawing.Size(366, 20);
            this.txtSecretKey.TabIndex = 12;
            // 
            // lblSecretKey
            // 
            this.lblSecretKey.AutoSize = true;
            this.lblSecretKey.Location = new System.Drawing.Point(8, 98);
            this.lblSecretKey.Name = "lblSecretKey";
            this.lblSecretKey.Size = new System.Drawing.Size(59, 13);
            this.lblSecretKey.TabIndex = 11;
            this.lblSecretKey.Text = "Secret Key";
            // 
            // btnRunTests
            // 
            this.btnRunTests.Location = new System.Drawing.Point(12, 121);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(90, 23);
            this.btnRunTests.TabIndex = 13;
            this.btnRunTests.Text = "Run All Tests!";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // btnUpload
            // 
            this.btnUpload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpload.BackgroundImage")));
            this.btnUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpload.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Location = new System.Drawing.Point(71, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(60, 56);
            this.btnUpload.TabIndex = 15;
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Visible = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // progressUpload
            // 
            this.progressUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressUpload.Location = new System.Drawing.Point(12, 346);
            this.progressUpload.Name = "progressUpload";
            this.progressUpload.Size = new System.Drawing.Size(460, 23);
            this.progressUpload.TabIndex = 16;
            // 
            // ofdServer
            // 
            this.ofdServer.Filter = "Executable Files|*.exe";
            // 
            // ofdSolution
            // 
            this.ofdSolution.FileName = "openFileDialog1";
            this.ofdSolution.Filter = "Solution files|*.sln";
            // 
            // lvTests
            // 
            this.lvTests.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTests.CheckBoxes = true;
            this.lvTests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLVTests_Number,
            this.colLVTests_Name});
            this.lvTests.FullRowSelect = true;
            this.lvTests.HideSelection = false;
            this.lvTests.Location = new System.Drawing.Point(16, 15);
            this.lvTests.MultiSelect = false;
            this.lvTests.Name = "lvTests";
            this.lvTests.Size = new System.Drawing.Size(245, 354);
            this.lvTests.TabIndex = 17;
            this.lvTests.UseCompatibleStateImageBehavior = false;
            this.lvTests.View = System.Windows.Forms.View.Details;
            this.lvTests.ItemActivate += new System.EventHandler(this.lvTests_ItemActivate);
            // 
            // colLVTests_Number
            // 
            this.colLVTests_Number.Text = "#";
            this.colLVTests_Number.Width = 58;
            // 
            // colLVTests_Name
            // 
            this.colLVTests_Name.Text = "Name";
            // 
            // scData
            // 
            this.scData.BackColor = System.Drawing.Color.DarkOrange;
            this.scData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scData.Location = new System.Drawing.Point(0, 0);
            this.scData.MinimumSize = new System.Drawing.Size(400, 300);
            this.scData.Name = "scData";
            // 
            // scData.Panel1
            // 
            this.scData.Panel1.BackColor = System.Drawing.Color.White;
            this.scData.Panel1.Controls.Add(this.btnStop);
            this.scData.Panel1.Controls.Add(this.lvTestingProgress);
            this.scData.Panel1.Controls.Add(this.btnUncheckAll);
            this.scData.Panel1.Controls.Add(this.btnCheckAll);
            this.scData.Panel1.Controls.Add(this.btnRunCheckedTests);
            this.scData.Panel1.Controls.Add(this.progressUpload);
            this.scData.Panel1.Controls.Add(this.txtServerPath);
            this.scData.Panel1.Controls.Add(this.btnBrowseSolution);
            this.scData.Panel1.Controls.Add(this.btnBrowseServer);
            this.scData.Panel1.Controls.Add(this.txtSecretKey);
            this.scData.Panel1.Controls.Add(this.lblServerExePath);
            this.scData.Panel1.Controls.Add(this.txtSolutionPath);
            this.scData.Panel1.Controls.Add(this.btnRunTests);
            this.scData.Panel1.Controls.Add(this.lblSolutionPath);
            this.scData.Panel1.Controls.Add(this.lblSecretKey);
            this.scData.Panel1MinSize = 200;
            // 
            // scData.Panel2
            // 
            this.scData.Panel2.BackColor = System.Drawing.Color.White;
            this.scData.Panel2.Controls.Add(this.btnThemePink);
            this.scData.Panel2.Controls.Add(this.lvTests);
            this.scData.Panel2.Controls.Add(this.btnThemeBlue);
            this.scData.Panel2.Controls.Add(this.btnThemeWhite);
            this.scData.Panel2.Controls.Add(this.btnThemeOrange);
            this.scData.Panel2MinSize = 100;
            this.scData.Size = new System.Drawing.Size(765, 385);
            this.scData.SplitterDistance = 484;
            this.scData.TabIndex = 18;
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(139, 121);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(39, 49);
            this.btnStop.TabIndex = 20;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lvTestingProgress
            // 
            this.lvTestingProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTestingProgress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTestName,
            this.colTestResult});
            this.lvTestingProgress.Location = new System.Drawing.Point(12, 177);
            this.lvTestingProgress.Name = "lvTestingProgress";
            this.lvTestingProgress.Size = new System.Drawing.Size(459, 163);
            this.lvTestingProgress.TabIndex = 19;
            this.lvTestingProgress.UseCompatibleStateImageBehavior = false;
            this.lvTestingProgress.View = System.Windows.Forms.View.Details;
            // 
            // colTestName
            // 
            this.colTestName.Text = "Test Name";
            // 
            // colTestResult
            // 
            this.colTestResult.Text = "Result";
            this.colTestResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUncheckAll.Location = new System.Drawing.Point(397, 148);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(75, 22);
            this.btnUncheckAll.TabIndex = 18;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckAll.Location = new System.Drawing.Point(397, 121);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(75, 22);
            this.btnCheckAll.TabIndex = 18;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnRunCheckedTests
            // 
            this.btnRunCheckedTests.Location = new System.Drawing.Point(12, 148);
            this.btnRunCheckedTests.Name = "btnRunCheckedTests";
            this.btnRunCheckedTests.Size = new System.Drawing.Size(121, 23);
            this.btnRunCheckedTests.TabIndex = 17;
            this.btnRunCheckedTests.Text = "Run Checked Tests!";
            this.btnRunCheckedTests.UseVisualStyleBackColor = true;
            this.btnRunCheckedTests.Click += new System.EventHandler(this.btnRunCheckedTests_Click);
            // 
            // btnThemePink
            // 
            this.btnThemePink.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThemePink.BackColor = System.Drawing.Color.LightPink;
            this.btnThemePink.Location = new System.Drawing.Point(173, 367);
            this.btnThemePink.Name = "btnThemePink";
            this.btnThemePink.Size = new System.Drawing.Size(17, 16);
            this.btnThemePink.TabIndex = 16;
            this.btnThemePink.UseVisualStyleBackColor = false;
            this.btnThemePink.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // btnThemeBlue
            // 
            this.btnThemeBlue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThemeBlue.BackColor = System.Drawing.Color.MediumBlue;
            this.btnThemeBlue.Location = new System.Drawing.Point(104, 367);
            this.btnThemeBlue.Name = "btnThemeBlue";
            this.btnThemeBlue.Size = new System.Drawing.Size(17, 16);
            this.btnThemeBlue.TabIndex = 16;
            this.btnThemeBlue.UseVisualStyleBackColor = false;
            this.btnThemeBlue.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // btnThemeWhite
            // 
            this.btnThemeWhite.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThemeWhite.BackColor = System.Drawing.Color.White;
            this.btnThemeWhite.Location = new System.Drawing.Point(150, 367);
            this.btnThemeWhite.Name = "btnThemeWhite";
            this.btnThemeWhite.Size = new System.Drawing.Size(17, 16);
            this.btnThemeWhite.TabIndex = 16;
            this.btnThemeWhite.UseVisualStyleBackColor = false;
            this.btnThemeWhite.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // btnThemeOrange
            // 
            this.btnThemeOrange.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThemeOrange.BackColor = System.Drawing.Color.DarkOrange;
            this.btnThemeOrange.Location = new System.Drawing.Point(127, 367);
            this.btnThemeOrange.Name = "btnThemeOrange";
            this.btnThemeOrange.Size = new System.Drawing.Size(17, 16);
            this.btnThemeOrange.TabIndex = 16;
            this.btnThemeOrange.UseVisualStyleBackColor = false;
            this.btnThemeOrange.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.DarkOrange;
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBackground.Controls.Add(this.scMain);
            this.pnlBackground.Controls.Add(this.pbResize);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(777, 469);
            this.pnlBackground.TabIndex = 19;
            this.pnlBackground.DoubleClick += new System.EventHandler(this.pnlBackground_DoubleClick);
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.BackColor = System.Drawing.Color.DarkOrange;
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(3, 3);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.BackColor = System.Drawing.Color.White;
            this.scMain.Panel1.Controls.Add(this.lblComplete);
            this.scMain.Panel1.Controls.Add(this.button2);
            this.scMain.Panel1.Controls.Add(this.button1);
            this.scMain.Panel1.Controls.Add(this.btnUpload);
            this.scMain.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Phase2TesterForm_MouseMove);
            this.scMain.Panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.scMain_Panel1_MouseDoubleClick);
            this.scMain.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Phase2TesterForm_MouseDown);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scData);
            this.scMain.Size = new System.Drawing.Size(765, 457);
            this.scMain.SplitterDistance = 68;
            this.scMain.TabIndex = 19;
            // 
            // lblComplete
            // 
            this.lblComplete.Image = ((System.Drawing.Image)(resources.GetObject("lblComplete.Image")));
            this.lblComplete.Location = new System.Drawing.Point(5, 4);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(60, 56);
            this.lblComplete.TabIndex = 1;
            this.lblComplete.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(632, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 56);
            this.button2.TabIndex = 0;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(698, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 56);
            this.button1.TabIndex = 0;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbResize
            // 
            this.pbResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbResize.BackColor = System.Drawing.Color.Transparent;
            this.pbResize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbResize.BackgroundImage")));
            this.pbResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pbResize.Location = new System.Drawing.Point(761, 451);
            this.pbResize.Name = "pbResize";
            this.pbResize.Size = new System.Drawing.Size(11, 13);
            this.pbResize.TabIndex = 20;
            this.pbResize.TabStop = false;
            this.pbResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbResize_MouseMove);
            this.pbResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbResize_MouseDown);
            // 
            // Phase2Tester
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 469);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "Phase2Tester";
            this.Text = "Testing App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Phase2Tester_DragDrop);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Phase2TesterForm_MouseDown);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Phase2Tester_DragEnter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Phase2TesterForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.scData.Panel1.ResumeLayout(false);
            this.scData.Panel1.PerformLayout();
            this.scData.Panel2.ResumeLayout(false);
            this.scData.ResumeLayout(false);
            this.pnlBackground.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbResize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblServerExePath;
        private System.Windows.Forms.Button btnBrowseServer;
        private System.Windows.Forms.TextBox txtSolutionPath;
        private System.Windows.Forms.Label lblSolutionPath;
        private System.Windows.Forms.Button btnBrowseSolution;
        private System.Windows.Forms.TextBox txtSecretKey;
        private System.Windows.Forms.Label lblSecretKey;
        private System.Windows.Forms.Button btnRunTests;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.TextBox txtServerPath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ProgressBar progressUpload;
        private System.Windows.Forms.OpenFileDialog ofdServer;
        private System.Windows.Forms.OpenFileDialog ofdSolution;
        private System.Windows.Forms.SplitContainer scData;
        private System.Windows.Forms.ListView lvTests;
        private System.Windows.Forms.ColumnHeader colLVTests_Number;
        private System.Windows.Forms.ColumnHeader colLVTests_Name;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.PictureBox pbResize;
        private System.Windows.Forms.Button btnRunCheckedTests;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnUncheckAll;
        private System.Windows.Forms.Label lblComplete;
        private System.Windows.Forms.Button btnThemePink;
        private System.Windows.Forms.Button btnThemeBlue;
        private System.Windows.Forms.Button btnThemeWhite;
        private System.Windows.Forms.Button btnThemeOrange;
        private System.Windows.Forms.ListView lvTestingProgress;
        private System.Windows.Forms.ColumnHeader colTestName;
        private System.Windows.Forms.ColumnHeader colTestResult;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;

    }
}

