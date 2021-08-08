using System;
using System.Windows.Forms;
using static TrackerLibrary.Enums;

namespace TrackerUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            TrackerLibrary.GlobalConfig.InitializeConnections(DatabaseType.TextFiles);

            Application.Run(new TournamentDashboard());
        }
    }
}
