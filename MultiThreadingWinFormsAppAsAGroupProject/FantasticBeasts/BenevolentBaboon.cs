using System;
using System.Collections.Generic;

using System.Threading;


namespace MultiThreadingWinFormsAppAsAGroupProject
{
    class BenevolentBaboon : FantasticBeast
    {
        public override void SayHello() {
            Console.WriteLine("Hello from BenevolentBaboon");
        }
        public override void RunThread() {
            msg = "Hello from BenevolentBaboon.RunThread()";
            long num = Convert.ToInt64(request);
            response = Convert.ToString(num / 2);
            Thread.Sleep(2000);
        }
    }
}

