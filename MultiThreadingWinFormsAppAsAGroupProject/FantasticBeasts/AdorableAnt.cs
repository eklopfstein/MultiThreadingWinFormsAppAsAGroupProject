using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    class AdorableAnt : FantasticBeast
    {
        public override void SayHello() {
            Console.WriteLine("Hello from AdorableAnt");
        }
        public override void RunThread() {
            getTextBox().AppendText("Hello from AdorableAnt.RunThread()");
            Console.WriteLine("Hello from AdorableAnt.RunThread()");
            Thread.Sleep(10000);
        }
    }
}
