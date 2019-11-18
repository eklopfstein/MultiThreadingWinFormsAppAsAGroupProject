using System;
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
            msg = "Hello from AdorableAnt.RunThread()";
            Thread.Sleep(2000);
        }
    }
}
