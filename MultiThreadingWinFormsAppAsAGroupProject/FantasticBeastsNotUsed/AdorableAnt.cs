/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    /// <summary>
    /// A Fantastic Beast that will help us maintain a secure world
    /// </summary>
    class AdorableAnt : FantasticBeast
    {
        public override void SayHello() {
            Console.WriteLine("Hello from AdorableAnt");
        }
        public override void RunThread() {
            response = "42";
        }
    }
}
