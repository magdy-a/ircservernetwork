namespace IRCPhase1Tester
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
            this.components = new System.ComponentModel.Container();
            this.txtServerPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseServer = new System.Windows.Forms.Button();
            this.txtSolutionPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseSolution = new System.Windows.Forms.Button();
            this.txtSecretKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRunTests = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lstTestingProgress = new System.Windows.Forms.ListBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.progressUpload = new System.Windows.Forms.ProgressBar();
            this.ofdServer = new System.Windows.Forms.OpenFileDialog();
            this.ofdSolution = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtServerPath
            // 
            this.txtServerPath.Enabled = false;
            this.txtServerPath.Location = new System.Drawing.Point(110, 12);
            this.txtServerPath.Name = "txtServerPath";
            this.txtServerPath.Size = new System.Drawing.Size(222, 20);
            this.txtServerPath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server Exe Path";
            // 
            // btnBrowseServer
            // 
            this.btnBrowseServer.Location = new System.Drawing.Point(345, 10);
            this.btnBrowseServer.Name = "btnBrowseServer";
            this.btnBrowseServer.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseServer.TabIndex = 4;
            this.btnBrowseServer.Text = "Browse";
            this.btnBrowseServer.UseVisualStyleBackColor = true;
            this.btnBrowseServer.Click += new System.EventHandler(this.btnBrowseServer_Click);
            // 
            // txtSolutionPath
            // 
            this.txtSolutionPath.Enabled = false;
            this.txtSolutionPath.Location = new System.Drawing.Point(110, 61);
            this.txtSolutionPath.Name = "txtSolutionPath";
            this.txtSolutionPath.Size = new System.Drawing.Size(222, 20);
            this.txtSolutionPath.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Solution Path";
            // 
            // btnBrowseSolution
            // 
            this.btnBrowseSolution.Location = new System.Drawing.Point(345, 60);
            this.btnBrowseSolution.Name = "btnBrowseSolution";
            this.btnBrowseSolution.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSolution.TabIndex = 7;
            this.btnBrowseSolution.Text = "Browse";
            this.btnBrowseSolution.UseVisualStyleBackColor = true;
            this.btnBrowseSolution.Click += new System.EventHandler(this.btnBrowseSolution_Click);
            // 
            // txtSecretKey
            // 
            this.txtSecretKey.Location = new System.Drawing.Point(110, 113);
            this.txtSecretKey.Name = "txtSecretKey";
            this.txtSecretKey.Size = new System.Drawing.Size(310, 20);
            this.txtSecretKey.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Secret Key";
            // 
            // btnRunTests
            // 
            this.btnRunTests.Location = new System.Drawing.Point(173, 157);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(75, 23);
            this.btnRunTests.TabIndex = 13;
            this.btnRunTests.Text = "Run Tests!";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // lstTestingProgress
            // 
            this.lstTestingProgress.FormattingEnabled = true;
            this.lstTestingProgress.HorizontalScrollbar = true;
            this.lstTestingProgress.Location = new System.Drawing.Point(18, 198);
            this.lstTestingProgress.Name = "lstTestingProgress";
            this.lstTestingProgress.Size = new System.Drawing.Size(402, 134);
            this.lstTestingProgress.TabIndex = 14;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(173, 353);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 15;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // progressUpload
            // 
            this.progressUpload.Location = new System.Drawing.Point(18, 395);
            this.progressUpload.Name = "progressUpload";
            this.progressUpload.Size = new System.Drawing.Size(402, 23);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 430);
            this.Controls.Add(this.progressUpload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lstTestingProgress);
            this.Controls.Add(this.btnRunTests);
            this.Controls.Add(this.txtSecretKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSolutionPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseSolution);
            this.Controls.Add(this.txtServerPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowseServer);
            this.Name = "Phase2Tester";
            this.Text = "Testing App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseServer;
        private System.Windows.Forms.TextBox txtSolutionPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseSolution;
        private System.Windows.Forms.TextBox txtSecretKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRunTests;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.TextBox txtServerPath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ListBox lstTestingProgress;
        private System.Windows.Forms.ProgressBar progressUpload;
        private System.Windows.Forms.OpenFileDialog ofdServer;
        private System.Windows.Forms.OpenFileDialog ofdSolution;

    }
}

