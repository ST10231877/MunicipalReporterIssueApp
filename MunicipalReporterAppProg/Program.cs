using System;
using System.Windows.Forms;
using MunicipalReporterAppProg.Forms;

namespace MunicipalReporterAppProg
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm());
        }
    }
}
