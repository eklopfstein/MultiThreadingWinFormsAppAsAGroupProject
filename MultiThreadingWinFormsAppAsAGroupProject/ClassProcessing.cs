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
                    txtMessages.AppendText(s);
                    myFantasticBeast = (FantasticBeast) (Activator.CreateInstance(null, "MultiThreadingWinFormsAppAsAGroupProject." + s).Unwrap());
                    myFantasticBeast.setTextBox(txtMessages);
                    myBeasts.Add(myFantasticBeast);
                    myFantasticBeast.SayHello();
                    Spawn(myFantasticBeast);
                    txtMessages.AppendText(" passed");
                    txtMessages.AppendText(Environment.NewLine);
                }
                catch (Exception ex) {
                    if (txtMessages != null) {
                        txtMessages.AppendText(" failed");
                        txtMessages.AppendText(Environment.NewLine);
                    }
                }
            }
            // All the beasts have been spawned. If any are running, wait for them to finish
            foreach (FantasticBeast fb in myBeasts) {
                if (fb.IsAlive) {
                    Console.WriteLine("Waiting for thread to complete");
                    fb.Join();
                }
            }
        }
        private static void Spawn(FantasticBeast fb) {
            fb.Start(); // This will invoke RunThread in the derived class
        }

    }
}
