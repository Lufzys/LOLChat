using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace LOLChat
{
    class Program
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        static void Main(string[] args)
        {
            try
            {
                Console.Title = "League of Legends - Chat";
            menu:
                Console.Clear();
                Write("\n  [=White]League of Legends - Chat[/]");
                Write("\n\n  [=Yellow]Commands[/] =>");
                Write("\n  - /block  [=Blue]{server}[/]");
                Write("\n  - /unblock");
                Write("\n  - /help");
                Console.Write("\n\n  Command Input : ");

                string command = Console.ReadLine();
                if (command.StartsWith("/"))
                {
                    if (command.StartsWith("/block "))
                    {
                        string parameter = command.Split(' ')[1];
                        System.Net.IPAddress address = System.Net.Dns.GetHostAddresses(parameter + ".chat.si.riotgames.com").FirstOrDefault();
                        Firewall.AddRule(address.ToString());
                        MessageBox((IntPtr)0, parameter + ".chat.si.riotgames.com succesfully blocked!", "League of Legends - Chat", 0);
                    }
                    else if (command.StartsWith("/unblock"))
                    {
                        Firewall.RemoveRule();
                        MessageBox((IntPtr)0, "Chat succesfully unblocked!", "League of Legends - Chat", 0);
                    }
                    else if (command.StartsWith("/help"))
                    {
                        Console.Clear();
                        Write("\n  [=Yellow]Servers =>[/]");
                        Write("\n  - [=White][EUW]  = euw1[/]");
                        Write("\n  - [=White][EUNE] = eun1[/]");
                        Write("\n  - [=White][NA]   = na2[/]");
                        Write("\n  - [=White][RU]   = ru1[/]");
                        Write("\n  - [=White][TR]   = tr1[/]");
                        Write("\n  - [=White][LAN]  = la1[/]");
                        Write("\n  - [=White][LAS]  = la2[/]");
                        Write("\n  - [=White][OC]   = oc1[/]");
                        Write("\n  - [=White][JP]   = jp1[/]");
                        Write("\n  - [=White][BR]   = br[/]");
                        Write("\n\n  Press any key for go to menu");
                        
                        Console.ReadKey();
                    }
                    else
                    {
                        Write("\n  [=Red]Unavaible Command[/]");
                        Thread.Sleep(2500);
                    }
                }
                goto menu;
            } catch { }
        }

        public static void Write(string msg)
        {
            string[] ss = msg.Split('[', ']');
            ConsoleColor c;
            foreach (var s in ss)
                if (s.StartsWith("/"))
                    Console.ResetColor();
                else if (s.StartsWith("=") && Enum.TryParse(s.Substring(1), out c))
                    Console.ForegroundColor = c;
                else
                    Console.Write(s);
        } 
    }
}
