using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PunityEngine.Engine.Network
{
    static public class Host
    {
        // TODO: Create a method that will parse host information and start the server listener.
        //       Create a new thread that will handle the host server stuff. 
        static public int port = 3404;
        static public IPAddress hostAdress = IPAddress.Parse("127.0.0.1");
        static public int playerLimit = 2;
        static public string hostName = "PunityGame";
        static public string motd = "A Punity Game";


        
        #region Intergration stuff.
        // Creates a new thread and parse Host.cfg to it.
        static public void InitHost(){
            ReadConfig(); // Reads and assigns the necisarry variables from Config

            // Create a seprete thread so that the main thread dont get clogged up by a while loop
            Thread hostThread = new Thread(new ThreadStart(TCPServerListener));
            hostThread.Start();
        }

        // Read Host.cfg
        static public void ReadConfig(){
            
            // Try to assign the Host.cfg values to the server variables
            try
            {
                string[] configLines = System.IO.File.ReadAllLines("./Data/Network/Host.cfg");

                // This will loop thorugh the file and depending on the "variable" 
                // it will assign the value to the corrosponding variable
                foreach (var config in configLines)
                {
                    string[] line = config.Split(":");

                    switch (line[0])
                    {
                        case "PORT":
                            int.TryParse(line[1], out port);
                            break;
                        case "MAXPLAYERS":
                            int.TryParse(line[1], out playerLimit);
                            break;
                        case "IP":
                            hostAdress = IPAddress.Parse(line[1]);
                            break;
                        case "NAME":
                            hostName = line[1];
                            break;
                        case "MOTD":
                            motd = line[1];
                            break;
                        default:
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("ERROR WHEN LOADING HOST.CFG");
                throw; 
            }
        }
        #endregion

        #region TCP SERVER

        // structure:
        /*
            Client(local), update screen, send data to -> Server
            Client(remote) <- Data from server.
            
            ------------------------
            |Server data:          |
            ------------------------
            |UID                   |
            |IP                    |
            |port                  |
            |position              |
            ------------------------

            Important note, No anti cheat etc.
            Serve should get validation code at some point.
        */

        static private void TCPServerListener(){
            try
            {
                // TCP server
                Console.WriteLine("Starting Server on:" + hostAdress + ":" + port);
            }
            catch (System.Exception)
            {
                // log errors
            }
        }

        //Error logger

        #endregion
    }
}
