using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    class BenevolentBaboon : FantasticBeast
    {
        public override void SayHello() {
            Console.WriteLine("Hello from BenevolentBaboon");
        }
        public override void RunThread()
        {
            getTextBox().AppendText("Hello from BenevolentBaboon.RunThread()");
            Console.WriteLine("Hello from BenevolentBaboon.RunThread()");
            Thread.Sleep(10000);
        }
    }
}

