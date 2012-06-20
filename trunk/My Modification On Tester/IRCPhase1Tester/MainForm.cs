using System;
using System.Threading;
using System.Windows.Forms;
using IRCPhase1Tester.Tests;

namespace IRCPhase1Tester
{
    public partial class MainForm : Form
    {
        private Thread runThread;
        private Thread uploadThread;

        delegate void UpdateControl(string message);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            ProgressBar.CheckForIllegalCrossThreadCalls = false;
            Session.Instance.PortNumber = 9090;
        }

        private void AddNewListItem(string message)
        {
            this.lstTestingProgress.Items.Add(message);
        }

        private void UpdateLastListItem(string appendedMessage)
        {
            string message = (string)this.lstTestingProgress.Items[this.lstTestingProgress.Items.Count - 1];
            this.lstTestingProgress.Items[this.lstTestingProgress.Items.Count - 1] = message + appendedMessage;
        }

        private void RunTest(ITest test)
        {
            TestingContext context;

            AddNewListItem("Running " + test.Title() + " Test... ");
            context = new TestingContext(test);
            UpdateLastListItem(context.ExecuteTest() ? "Passed" : "Failed");
        }

        private void RunTests()
        {
            RunTest(new UserCommandHappy());
            RunTest(new UserCommandMissingParams());
            RunTest(new NickCommandHappy());
            RunTest(new NickCommandNickInUse());
            RunTest(new NickCommandNoNick());
            RunTest(new UnknownCommand());
            RunTest(new UserCommandAlreadyRegistered());
            RunTest(new Tests.PrivmsgCommandHappy());
            RunTest(new Tests.PrivmsgCommandNoRecipient());
            RunTest(new Tests.PrivmsgCommandNoSuchNick());
            RunTest(new Tests.PrivmsgCommandNoTextToSend());
            RunTest(new Tests.PrivmsgCommandUnregistered());
            RunTest(new Tests.PrivmsgCommandUnregisteredWithNickCommand());
            RunTest(new Tests.PrivmsgCommandUnregisteredWithUserCommand());
            RunTest(new Tests.PrivmsgCommandMultipleTargetsHappy());
            RunTest(new Tests.PrivmsgCommandMultipleTargetsNoSuchNick());
            RunTest(new Tests.PrivmsgCommandBackAndForth());
            RunTest(new Tests.PrivmsgCommandLoad());
            RunTest(new Tests.PrivmsgCommandSendToUnregisteredClient());

            MessageBox.Show("Finished all tests, " + Session.Instance.PassedTests.Count.ToString() + " passed testObject(s), " +
                Session.Instance.FailedTests.Count.ToString() + " failed testObject(s).");
        }

        private void btnRunTests_Click(object sender, EventArgs e)
        {
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
                return;

            Session.Instance.FailedTests.Clear();
            Session.Instance.PassedTests.Clear();
            this.lstTestingProgress.Items.Clear();
            runThread = new Thread(new ThreadStart(RunTests));
            runThread.Start();
        }

        private void btnBrowseServer_Click(object sender, EventArgs e)
        {
            if (this.ofdServer.ShowDialog() == DialogResult.OK)
            {
                this.txtServerPath.Text = this.ofdServer.FileName;
                Session.Instance.ServerPath = this.ofdServer.FileName;
            }
        }

        private void btnBrowseSolution_Click(object sender, EventArgs e)
        {
            if (this.ofdSolution.ShowDialog() == DialogResult.OK)
            {
                this.txtSolutionPath.Text = this.ofdSolution.FileName;
            }
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (Session.Instance.FailedTests.Count == 0 && Session.Instance.PassedTests.Count == 0)
            {
                MessageBox.Show("Nothing to upload. Please run the tests first.");
                return;
            }
            Session.Instance.SecretKey = this.txtSecretKey.Text;
        }
    }
}