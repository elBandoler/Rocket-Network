using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RocketNetwork
{
    static class Program
    {
        public static string directory = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);

        static void Main()
        {
            //Update first
            Update.CheckForUpdates();
            if (!CheckForDependencies())
            {
                DialogResult dialogResult = MessageBox.Show(@"Dependencies are missing. Try reinstalling RocketNetwork. RocketNetwork will close in 5 seconds", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
            }

            // then open main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static string[] dependencies =
        {
            "Newtonsoft.Json.dll",
            "PcapDotNet.Base.dll",
            "PcapDotNet.Core.dll",
            "PcapDotNet.Core.Extensions.dll",
            "PcapDotNet.Packets.dll" 
        };

        private static bool CheckForDependencies()
        {
            foreach (string dep in dependencies)
            {
                if (File.Exists(directory + "/RNAU.exe")) File.Delete(directory + "/RNAU.exe");
                if (!File.Exists(directory + "/" + dep)) return false;
            }
            return true;           
        }
    }
}
