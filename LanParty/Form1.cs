using System;
using System.Windows.Forms;

namespace LanParty
{
    public partial class Form1 : Form
    {
        LANDiscovery discovery;
        int listenPort = 7777;
        public Form1()
        {
            InitializeComponent();
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            if (nameBox.Text.Length > 0)
            {
                startServer.Enabled = true;
                findServer.Enabled = true;
                startServer.ForeColor = System.Drawing.Color.Black;
                findServer.ForeColor = System.Drawing.Color.Black;
                discovery = new LANDiscovery(listenPort,
                            msg => messagesBox.AppendText($"{msg}\r\n"),
                            nameBox.Text);
            }
            else 
            { 
                startServer.Enabled = false;
                startServer.ForeColor = System.Drawing.Color.LightGray;
                findServer.Enabled = false;
                findServer.ForeColor = System.Drawing.Color.LightGray;
            }

        }

        private async void startServer_Click(object sender, EventArgs e)
        {
            await discovery.StartServerAsync();
            findServer.Enabled = false;
        }

        private async void findServer_Click(object sender, EventArgs e)
        {
            await discovery.StartClientAsync();
            startServer.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
