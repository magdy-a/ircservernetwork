using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chatting
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //WIFI_PWM_Controller Frm = new WIFI_PWM_Controller();
            //Frm.StartPosition = FormStartPosition.CenterParent;
            Application.Run(new MyClient());
        }
    }
}