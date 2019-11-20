/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
                    myFantasticBeast.request = "12345";
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
                    joinStatus = fb.Join(5000);
                    if (joinStatus == false) {
                        txtMessages.AppendText(Environment.NewLine + fb.GetType() + " thread timed out.");
                    } else {
                        GetMsg(fb, txtMessages);
                        GetResponse(fb, txtMessages);
                    }
                } else {
                    GetMsg(fb, txtMessages);
                }
            }
            txtMessages.AppendText(Environment.NewLine + "****Done.****");
        }
        private static void GetResponse(FantasticBeast fb, TextBox txtMessages) {
            // The thread should have responded to our request so we can retrieve it.
            txtMessages.AppendText(Environment.NewLine + "Response from " + fb.GetType() + ": " + fb.response);
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
