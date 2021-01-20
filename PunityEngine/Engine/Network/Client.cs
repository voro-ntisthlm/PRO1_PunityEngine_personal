using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PunityEngine.Engine.Network
{
    public static class Client
    {
        public static UdpClient udpClient = new UdpClient();
        public static IPAddress serverAdress = IPAddress.Parse("192.168.56.1");
        public static IPEndPoint serverEndPoint = new IPEndPoint(serverAdress, 3404);
        public static bool isMultiplayer = false;

        public static void Connect()
        {
            try
            {
                udpClient.Connect(serverEndPoint);
                
                byte[] datagram = Encoding.ASCII.GetBytes("Connected");
                udpClient.Send(datagram, datagram.Length);
            }
            catch (Exception e ) {
                Console.WriteLine(e.ToString());
            }
        }

        public static void Broadcast(){
            byte[] datagram = Encoding.ASCII.GetBytes("Hello World!");
            udpClient.Send(datagram, datagram.Length);
        }
    }
}
