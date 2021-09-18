/*
 * NetworkSimulator - UNDER DEVELOPMENT DO NOT USE
 * a new PacketFaker, but not WinPCap dependant
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace RocketNetwork
{
    public class NetworkSimulator
    {
        public static List<HostResponse_X> ServerList = new List<HostResponse_X>();
        public static List<Thread> OpenThreads = new List<Thread>();

        public struct UdpState
        {
            public UdpClient u;
            public IPEndPoint e;
        }

        public static void Intercept(List<HostResponse_X> serverList)
        {
            // Set new server list
            ServerList = serverList;

            // Close old threads
            foreach (var openThread in OpenThreads)
                openThread.Abort();

            // Start intercepting
            Thread thread = new Thread(InterceptPackets);
            thread.IsBackground = true;
            thread.Start();
            OpenThreads.Add(thread);
        }

        public static void InterceptPackets()
        {
            UdpClient listener = new UdpClient(14001);
            listener.BeginReceive(PacketHandler, new UdpState());
        }

        private static void PacketHandler(IAsyncResult ar)
        {
            Console.Out.WriteLine("test: " + ar.ToString());
            /*
            byte[] data = new byte[ar.Count];
            packet.CopyTo(data, 0);
            string str = Encoding.Default.GetString(data);

            // If this is a hostquery message we will respond
            if (str.Contains("HostQuery_X"))
            {
                Console.WriteLine(str);
                // Convert data to useable object
                string json = str.Split(new string[] { "HostQuery_X" }, StringSplitOptions.None)[1];
                try
                {
                    HostQuery_X query = JsonConvert.DeserializeObject<HostQuery_X>(json);
                    // For every server we want to show we will send a response packet back
                    foreach (HostResponse_X ServerID in ServerList)
                    {
                        HostResponse_X response = CraftResponse(ServerID, query);
                        SendResponse(response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }*/
        }
    }
    
 
}
