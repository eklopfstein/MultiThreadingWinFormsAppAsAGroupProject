using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    class ClassProcessing
    {
        public static void ProcessClasses(TextBox txtMessages)
        {
            List<FantasticBeast> myBeasts = new List<FantasticBeast>();
            List<String> files = new List<string>();
            foreach (string file in Directory.EnumerateFiles("..\\..\\FantasticBeasts", "*.cs")) {
                String s = file.Substring(file.LastIndexOf("\\") + 1);
                s = s.Substring(0, s.LastIndexOf(".cs"));
                files.Add(s);
            }
            FantasticBeast myFantasticBeast;
            foreach (String s in files) {
                try {
                    myFantasticBeast = (FantasticBeast) (Activator.CreateInstance(null, "MultiThreadingWinFormsAppAsAGroupProject." + s).Unwrap());
                    myBeasts.Add(myFantasticBeast);
                    myFantasticBeast.SayHello();
                    Spawn(myFantasticBeast, txtMessages);
                    txtMessages.AppendText(Environment.NewLine + s + " spawned");
                }
                catch (Exception ex) {
                   txtMessages.AppendText(Environment.NewLine + s + " did not spawn");
                }
            }
            // All the beasts have been spawned. If any are running, wait for them to finish
            foreach (FantasticBeast fb in myBeasts) {
                if (fb.IsAlive) {
                    Boolean joinStatus;
                    Console.WriteLine("Waiting for thread to complete");
                    joinStatus = fb.Join(500);
                    if (joinStatus == false) {
                        txtMessages.AppendText(Environment.NewLine + fb.GetType() + " thread timed out.");
                    } else {
                        GetMsg(fb, txtMessages);
                    }
                } else {
                    GetMsg(fb, txtMessages);
                }
            }
        }
        private static void GetMsg(FantasticBeast fb, TextBox txtMessages) {
            // The thread should have written a message so we can retrieve it.
            txtMessages.AppendText(Environment.NewLine + fb.msg);
        }
        private static void Spawn(FantasticBeast fb, TextBox txtMessages) {
            txtMessages.AppendText(Environment.NewLine + "Spawning " + fb.GetType());
            fb.Start(); // This will invoke RunThread in the derived class
        }

    }
}
