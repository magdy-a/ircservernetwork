using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using IRCPhase1Tester.Tests;

namespace IRCPhase1Tester
{
    public partial class Phase2Tester : Form
    {
        private Thread runThread;
        private Thread uploadThread;

        // TODO SomeNewMembersHere

        #region SomeNewMembersHere

        private Point movingMouseDownLocation;
        private Point resizingMouseDownLocation;

        #endregion SomeNewMembersHere

        delegate void UpdateControl(string message);

        public Phase2Tester()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                runThread.Abort();
                uploadThread.Abort();
            }
            catch
            {
            }
        }

        // TODO NewEventsHere

        #region NewEventsHere

        // Move Form
        private void Phase2TesterForm_MouseDown(object sender, MouseEventArgs e)
        {
            movingMouseDownLocation = e.Location;
        }

        private void Phase2TesterForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Location = new Point(Location.X + e.X - movingMouseDownLocation.X, Location.Y + e.Y - movingMouseDownLocation.Y);
        }

        // Close & Minimize & Maximize
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void scMain_Panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        // Resize Form
        private void pbResize_MouseDown(object sender, MouseEventArgs e)
        {
            this.resizingMouseDownLocation = e.Location;
        }

        private void pbResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Size = new Size(Size.Width + e.X - this.resizingMouseDownLocation.X, Size.Height + e.Y - this.resizingMouseDownLocation.Y);

            Refresh();
        }

        // Drag & Drop
        private void Phase2Tester_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void Phase2Tester_DragDrop(object sender, DragEventArgs e)
        {
            // Go Open the File
            this.OpenMyFile((string[])e.Data.GetData(DataFormats.FileDrop));
        }

        // List View
        private void lvTests_ItemActivate(object sender, EventArgs e)
        {
            if (this.lvTests.SelectedIndices.Count < 1)
            {
                return;
            }

            this.lvTests.Items[this.lvTests.SelectedIndices[0]].Checked = !this.lvTests.Items[this.lvTests.SelectedIndices[0]].Checked;
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lvTests.Items)
            {
                item.Checked = true;
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lvTests.Items)
            {
                item.Checked = false;
            }
        }

        // Theme Change
        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == this.btnThemeOrange.Name)
            {
                this.ChangeTheme(Color.DarkOrange);
            }
            else if (((Button)sender).Name == this.btnThemeBlue.Name)
            {
                this.ChangeTheme(Color.MediumBlue);
            }
            else if (((Button)sender).Name == this.btnThemeWhite.Name)
            {
                this.ChangeTheme(Color.White);
            }
            else if (((Button)sender).Name == this.btnThemePink.Name)
            {
                this.ChangeTheme(Color.Pink);
            }
        }

        private void pnlBackground_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                this.ChangeTheme(c.Color);
            }
        }

        #endregion NewEventsHere

        // TODO NewFunctionsHere

        #region NewFunctionsHere

        // Open File
        private void OpenMyFile(string[] pathes)
        {
            ExtensionsType type;

            foreach (string path in pathes)
            {
                type = Configuration.GetFileExtensionType(path);

                switch (type)
                {
                    case ExtensionsType.EXE:
                        this.txtServerPath.Text = path;
                        Session.Instance.ServerPath = path;
                        break;
                    case ExtensionsType.SLN:
                        this.txtSolutionPath.Text = path;
                        break;
                    case ExtensionsType.UNKNOWN:
                        continue;
                }

                Settings.UpdateSettingsFile(path, type);
            }
        }

        // Run in General
        /// <summary>
        /// Check If I can run, and set the Control properties
        /// </summary>
        /// <returns></returns>
        private bool PreRun()
        {
            // New Code at the end of the function

            bool error = false;

            if (txtServerPath.Text == string.Empty)
            {
                errProvider.SetError(txtServerPath, "Browse for the server exe first.");
                error = true;
            }
            else
            {
                errProvider.SetError(txtServerPath, null);
            }

            if (txtSolutionPath.Text == string.Empty)
            {
                errProvider.SetError(txtSolutionPath, "Browse for the solution file first.");
                error = true;
            }
            else
            {
                errProvider.SetError(txtSolutionPath, null);
            }

            if (txtSecretKey.Text == string.Empty)
            {
                errProvider.SetError(txtSecretKey, "Enter your secret key first.");
                error = true;
            }
            else
            {
                errProvider.SetError(txtSecretKey, null);
            }

            if (error)
                return false;

            if (runThread != null && runThread.IsAlive)
            {
                MessageBox.Show("Please end the previous Run first");
                return false;
            }

            Session.Instance.FailedTests.Clear();
            Session.Instance.PassedTests.Clear();
            this.lvTestingProgress.Items.Clear();

            // TODO NewCodeHere

            #region NewCodeHere

            this.lblComplete.Visible = false;
            this.btnUpload.Visible = false;
            this.btnStop.Visible = true;

            #endregion NewCodeHere

            return true;
        }

        /// <summary>
        /// Check passed tests, and Log the Run
        /// </summary>
        private void PostRun()
        {
            this.btnStop.Visible = false;

            // If the user finished all the Tests
            if (Session.Instance.PassedTests.Count == TestUtility.NumOfTests)
            {
                if (this.lblComplete.InvokeRequired)
                {
                    this.lblComplete.Invoke(new ThreadStart(Complete));
                }
                else
                {
                    Complete();
                }
            }

            // Log Run
            Logger.LogRun();
        }

        /// <summary>
        /// A function to do events on the form, that is called from Invoke(Delegate)
        /// </summary>
        private void Complete()
        {
            this.lblComplete.Visible = true;
            this.btnUpload.Visible = true;
        }

        // Run Checked Items
        /// <summary>
        /// Gets the Indicies of the Checked Items, Replaces them with their TestType, then Get the Object for that TestType, then Runs it
        /// </summary>
        private void RunCheckedTests()
        {
            if (this.lvTests.CheckedIndices.Count < 1)
            {
                return;
            }

            int[] testNumbers = new int[this.lvTests.CheckedIndices.Count];

            for (int i = 0; i < this.lvTests.CheckedIndices.Count; i++)
            {
                testNumbers[i] = int.Parse(this.lvTests.Items[this.lvTests.CheckedIndices[i]].Text);
            }

            foreach (TestType type in TestUtility.GetArrayOfTestTypesFromIntegerArray(testNumbers))
            {
                RunTest(TestUtility.GetTest(type));
            }

            PostRun();

            MessageBox.Show("For (" + testNumbers.Length + ") Test Case(s) :: " + Session.Instance.PassedTests.Count.ToString() + " passed testObject(s), " +
                Session.Instance.FailedTests.Count.ToString() + " failed testObject(s).");
        }

        // Starts function RunCheckTests
        private void btnRunCheckedTests_Click(object sender, EventArgs e)
        {
            if (this.lvTests.CheckedIndices.Count == 0)
            {
                return;
            }

            if (this.PreRun())
            {
                runThread = new Thread(new ThreadStart(RunCheckedTests));
                runThread.Start();
            }
        }

        // Change Theme
        /// <summary>
        /// Changes the Theme of the form
        /// </summary>
        /// <param name="c"></param>
        private void ChangeTheme(Color c)
        {
            this.pnlBackground.BackColor = c;
            this.scMain.BackColor = c;
            this.scData.BackColor = c;
        }

        #endregion NewFunctionsHere

        // TODO ChangedFunctionsHere

        #region ChangedFunctionsHere

        // Loading
        private void MainForm_Load(object sender, EventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            ProgressBar.CheckForIllegalCrossThreadCalls = false;
            Session.Instance.PortNumber = 9090;

            // TODO NewCodeHere

            #region NewCodeHere

            Configuration config = Settings.GetConfigurationFromFile();

            if (config != null)
            {
                this.txtServerPath.Text = config.ExePath;
                Session.Instance.ServerPath = config.ExePath;

                this.txtSolutionPath.Text = config.SlnPath;
            }

            ListViewItem tmpItem;
            foreach (TestType type in Enum.GetValues(typeof(TestType)))
            {
                tmpItem = new ListViewItem(new string[] { ((int)type).ToString(), type.ToString() });

                this.lvTests.Items.Add(tmpItem);
            }

            this.lvTests.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            #endregion NewCodeHere
        }

        // Browse File
        private void btnBrowseServer_Click(object sender, EventArgs e)
        {
            if (this.ofdServer.ShowDialog() == DialogResult.OK)
            {
                if (Configuration.GetFileExtensionType(this.ofdServer.FileName) != ExtensionsType.EXE)
                    return;
                this.OpenMyFile(new string[] { this.ofdServer.FileName });
                Session.Instance.ServerPath = this.ofdServer.FileName;
            }
        }

        private void btnBrowseSolution_Click(object sender, EventArgs e)
        {
            if (this.ofdSolution.ShowDialog() == DialogResult.OK)
            {
                if (Configuration.GetFileExtensionType(this.ofdSolution.FileName) != ExtensionsType.SLN)
                    return;
                this.OpenMyFile(new string[] { this.ofdSolution.FileName });
            }
        }

        //Run Test, (Send the Parameter a TestResult not a String)
        /// <summary>
        /// Runs a specific Test
        /// </summary>
        /// <param name="test">ITest Object</param>
        private void RunTest(ITest test)
        {
            TestingContext context;

            AddNewListItem("Running " + test.Title() + " Test... ");
            context = new TestingContext(test);
            UpdateLastListItem(context.ExecuteTest() ? TestResult.Passed : TestResult.Failed);
        }

        // Run All Tests
        /// <summary>
        /// Run All Tests, by calling a new thread to run the RunAllTests Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunTests_Click(object sender, EventArgs e)
        {
            if (this.PreRun())
            {
                runThread = new Thread(new ThreadStart(RunAllTests));
                runThread.Start();
            }
        }

        /// <summary>
        /// Loopa all Items in the Enum TestType, Get's an Object from that test, then runs it
        /// </summary>
        private void RunAllTests()
        {
            for (int i = 1; i <= TestUtility.NumOfTests; i++)
            {
                RunTest(TestUtility.GetTest(i));
            }

            PostRun();

            MessageBox.Show("Finished all tests, " + Session.Instance.PassedTests.Count.ToString() + " passed testObject(s), " +
                Session.Instance.FailedTests.Count.ToString() + " failed testObject(s).");
        }

        // Test Progress, (List View)
        private void AddNewListItem(string message)
        {
            this.lvTestingProgress.Items.Add(new ListViewItem(message));

            this.lvTestingProgress.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void UpdateLastListItem(TestResult result)
        {
            ((ListViewItem)this.lvTestingProgress.Items[this.lvTestingProgress.Items.Count - 1]).SubItems.Add(result.ToString());
            this.lvTestingProgress.Items[this.lvTestingProgress.Items.Count - 1].BackColor = (result == TestResult.Passed) ? Color.LightGreen : Color.DarkOrange;

            this.lvTestingProgress.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        // Upload, (Checks also that the Passed is the number of tests, to handle the Run Checked Tests
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (Session.Instance.FailedTests.Count == 0 && Session.Instance.PassedTests.Count == 0)
            {
                MessageBox.Show("Nothing to upload. Please run the tests first.");
                return;
            }
            else if (Session.Instance.FailedTests.Count + Session.Instance.PassedTests.Count != TestUtility.NumOfTests)
            {
                MessageBox.Show("Please run all the test cases first");
                return;
            }

            Session.Instance.SecretKey = this.txtSecretKey.Text;
        }

        #endregion ChangedFunctionsHere

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.runThread.Abort();

            this.btnStop.Visible = false;

            this.lvTestingProgress.Items.Clear();
        }
    }
}