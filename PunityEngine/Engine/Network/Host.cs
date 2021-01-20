using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace PunityEngine.Engine.Network
{
    static public class Host
    {
        static public void InitHost(){
            // Create a seprete thread so that the main thread don't get clogged up by a while loop
            Thread hostThread = new Thread(new ThreadStart(startServer));
            hostThread.Start();
        }

        static void startServer(){
            // This will start the PunityServer.exe, a dedicated server.
            // https://github.com/voro-ntisthlm/PunityServer 
            // Process.Start("./Data/Network/Server/PunityServer.exe");

            ProcessStartInfo serverInfo = new ProcessStartInfo("./Data/Network/Server/PunityServer.exe");
            serverInfo.WindowStyle = ProcessWindowStyle.Minimized;

            Process.Start(serverInfo);

            
        }
    }
}
