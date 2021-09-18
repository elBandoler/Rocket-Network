using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RocketNetwork
{
    public partial class MainForm : Form
    {
        private List<HostResponse_X> serverList = new List<HostResponse_X>();

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshButton.Enabled = false;
            serverList = RNetwork.Query();
            RNetwork.UpdateServerCount(serverLabel, serverList.Count);
            refreshButton.Enabled = true;

            PacketFaker.Intercept(serverList);
            // Query the server for a list of currently up and running servers
            // Insert that list to serverList
            // Redo it every minute unless connected to a server
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshButton.Enabled = false;
            serverList = RNetwork.Query();
            RNetwork.UpdateServerCount(serverLabel, serverList.Count);
            refreshButton.Enabled = true;
        }
    }
}
