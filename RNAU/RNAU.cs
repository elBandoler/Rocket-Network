using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Windows.Forms;

namespace RNAU
{
    public static class RNAU
    {
        public static string directory = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);

        static void Main()
        {
            // Check the update is there
            if (!File.Exists("update.zip")) // add checksum testing
            {
                MessageBox.Show(@"Update file is missing", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateErrorMessage();
                return;
            }
            // Check RocketNetwork is dead or kill it, mwhahahaha.
            Process[] rnProcesses = Process.GetProcessesByName("RocketNetwork.exe");
            while (rnProcesses.Length > 0)
            {
                rnProcesses = Process.GetProcessesByName("RocketNetwork.exe");
                foreach (Process p in rnProcesses) p.Kill();
            }

            try
            {
                // extract all files now
                using (ZipArchive archive = ZipFile.OpenRead("update.zip"))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        entry.ExtractToFile(directory + "/" + entry.Name, true);
                    }
                }
                //delete the update
                File.Delete("update.zip");
            }
            catch (Exception e)
            {
                UpdateErrorMessage();
                return;
            }

            Process.Start("RocketNetwork.exe");
        }

        private static void UpdateErrorMessage() // always returns false, because it's an error ffs!
        {
            DialogResult dialogResult = MessageBox.Show(@"RocketNetwork was not updated due to an error in downloading the update. Please contact support.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Process.GetCurrentProcess().Kill();
        }
    }
    public class UpdateObject
    {
        public string version;
        public string url;
        public string rnau;
    }
}
