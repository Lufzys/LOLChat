using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLChat
{
    class Firewall
    {
        public static void AddRule(string Ip)
        {
            var createRule =
                new ProcessStartInfo("c:\\windows\\system32\\netsh.exe",
                $"advfirewall firewall add rule name = \"LF1337\" dir =out remoteip = {Ip} protocol = TCP action = block")
                {
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas"
                };

            try
            {
                Process.Start(createRule);
            }
            catch (Win32Exception) { }
        }

        public static void RemoveRule()
        {
            var psi =
                new ProcessStartInfo("c:\\windows\\system32\\netsh.exe",
                "advfirewall firewall delete rule name = \"LF1337\"")
                {
                    UseShellExecute = true,
                    Verb = "runas",
                    WindowStyle = ProcessWindowStyle.Hidden
                };
            try
            {
                Process.Start(psi);
            }
            catch (Win32Exception) { }
        }
    }
}
