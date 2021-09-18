using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RocketNetwork
{
    static class RNetwork
    {
        public static readonly HttpClient client = new HttpClient();

        public static List<HostResponse_X> Query()
        {
            List<HostResponse_X> ServerList = new List<HostResponse_X>();
            string json = client.GetStringAsync("http://www.bandoler.com/rocketnetwork").Result;
            HostResponse_X[] responses = JsonConvert.DeserializeObject<HostResponse_X[]>(json);
            foreach (HostResponse_X response in responses)
            {
                ServerList.Add(response);
            }
            return ServerList;
        }

        public static void UpdateServerCount(Label serverLabel, int count)
        {
            serverLabel.Text = "Servers: " + count;
        }
    }
}
