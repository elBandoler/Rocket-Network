using System;
using System.Reflection;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace RocketNetwork
{
    public static class Update
    {
        private static UpdateObject updateObject = new UpdateObject();
        private static string updateOrigin = "http://bandoler.com/rocketnetwork/au.json";

        public static void CheckForUpdates()
        {
            HttpClient client = new HttpClient();
            updateObject = JsonConvert.DeserializeObject<UpdateObject>(client.GetStringAsync(updateOrigin).Result);
            Version current = Assembly.GetExecutingAssembly().GetName().Version,
                    newest = new Version(updateObject.version);
            if (newest.Major > current.Major || newest.Minor > current.Minor || newest.Build > current.Build || newest.Revision > current.Revision)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(updateObject.rnau, "rnau.exe");
                    webClient.DownloadFile(updateObject.url,"update.zip");
                }
                catch(WebException e)
                {
                    MessageBox.Show(@"Could not connect to the update server: " + (int)((HttpWebResponse)e.Response).StatusCode, 
                        @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Process.GetCurrentProcess().Kill();
                }
                Process.Start("rnau.exe");
                Process.GetCurrentProcess().Kill();
            }
            else return;
        }
    }

    public class UpdateObject
    {
        public string version;
        public string url;
        public string rnau;
    }
}
