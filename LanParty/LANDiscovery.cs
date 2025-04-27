using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanParty
{
    public class LANDiscovery
    {
        private readonly int listenPort;
        private readonly Action<string> log;
        private readonly string myName;

        /* old solution:
        private TextBox nameBox;
        private TextBox messagesBox;
        public LANDiscovery(int port, TextBox name, TextBox messages)
        {
            this.listenPort = port;
            this.nameBox = name;
            this.messagesBox = messages;
        }
        */
        public LANDiscovery(int port, Action<string> log, string name)
        { 
            this.listenPort = port;
            this.myName = name;
            this.log = log;
        }

        public async Task StartServerAsync()
        {
            log("Server started.");

            using (UdpClient server = new UdpClient(listenPort))
            {
                int maxTries = 10;
                bool clientFound = false;
                for (int attempt = 0; attempt<maxTries && !clientFound;attempt++)
                {
                    Task<UdpReceiveResult> receiveTask = server.ReceiveAsync();
                    Task timeoutTask = Task.Delay(12000);

                    Task completedTask = await Task.WhenAny(receiveTask, timeoutTask);
                    if (completedTask == receiveTask)
                    {
                        UdpReceiveResult result = await receiveTask;
                        string message = Encoding.UTF8.GetString(result.Buffer);
                        log($"Válasz érkezett: {message} ({result.RemoteEndPoint})");

                        if (message == "DISCOVER_SERVER")
                        {
                            clientFound = true;
                            string reply = "SERVER_HERE";
                            byte[] replyData = Encoding.UTF8.GetBytes(reply);
                            await server.SendAsync(replyData, replyData.Length, result.RemoteEndPoint);
                            log($"Válasz elküldve: {reply}");

                            result = await server.ReceiveAsync();
                            message = Encoding.UTF8.GetString(result.Buffer);
                            log($"A kliens neve: {message}");

                            byte[] nameData = Encoding.UTF8.GetBytes(myName);
                            await server.SendAsync(nameData, nameData.Length, result.RemoteEndPoint);
                            log($"Név elküldve: {myName}");
                        }
                        else 
                        {
                            log("Ismeretlen üzenet.");
                        }
                    }
                    else
                    {
                        log($"Timeout - {attempt+1}. újrapróbálkozás...");
                    }
                }
                if (!clientFound) 
                {
                    log("Nem sikerült klienst találni a megadott idő alatt.");
                }
            }
        }

        public async Task StartClientAsync()
        {
            log("Client started.");

            using (UdpClient client = new UdpClient())
            {
                client.EnableBroadcast = true;
                IPEndPoint broadcastEP = new IPEndPoint(IPAddress.Broadcast, listenPort);

                string discoveryMessage = "DISCOVER_SERVER";
                byte[] data = Encoding.UTF8.GetBytes(discoveryMessage);
                
                bool serverFound = false;
                int maxTries = 30;

                for (int attempt = 0; attempt < maxTries && !serverFound; attempt++)
                {
                    await client.SendAsync(data, data.Length, broadcastEP);
                    log($"Broadcast elküldve - {attempt+1}. próbálkozás.");

                    Task<UdpReceiveResult> receiveTask = client.ReceiveAsync();
                    Task timeoutTask = Task.Delay(500);
                    Task completedTask = await Task.WhenAny(receiveTask, timeoutTask);
                    
                    if (completedTask == receiveTask)
                    {
                        UdpReceiveResult result = await receiveTask;
                        string message = Encoding.UTF8.GetString(result.Buffer);
                        log($"Válasz érkezett: {message} ({result.RemoteEndPoint})");

                        if (message == "SERVER_HERE")
                        {
                            serverFound = true;
                            byte[] nameData = Encoding.UTF8.GetBytes(myName);
                            await client.SendAsync(nameData, nameData.Length, result.RemoteEndPoint);
                            log($"Név elküldve: {myName}");

                            result = await client.ReceiveAsync();
                            message = Encoding.UTF8.GetString(result.Buffer);
                            log($"A szerver neve: {message}");
                        }
                        else
                        {
                            log("Ismeretlen üzenet.");
                        }
                    }
                    else
                    {
                        log($"Timeout - újrapróbálkozás...");
                    }
                }

                if (!serverFound)
                {
                    this.log("Nem sikerült szervert találni.");
                }
            }
        }
    }
}


        /* régi szerver részlet
        IPEndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);

        byte[] receivedData = server.Receive(ref clientEP);
        string message = Encoding.UTF8.GetString(receivedData);
        this.messagesBox.Text += $"Üzenet érkezett: {message} ({clientEP})\r\n";
        if (message == "DISCOVER_SERVER")
        {
            string reply = "SERVER_HERE";
            byte[] replyData = Encoding.UTF8.GetBytes(reply);
            server.Send(replyData, replyData.Length, clientEP);
            this.messagesBox.Text += ($"Válasz elküldve: {reply}\r\n");
        }
        server.Close();*/


        /* régi kliens részlet
        IPEndPoint serverEP = new IPEndPoint(IPAddress.Any, 0);
        byte[] receivedData = client.Receive(ref serverEP);
        string message = Encoding.UTF8.GetString(receivedData);

        this.messagesBox.Text += $"Üzenet érkezett: {message} ({serverEP})\r\n";
        client.Close();
        */
    

