/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Threading;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    /// <summary>
    /// A Fantastic Beast that will help us maintain a secure world
    /// </summary>
    class CasualCheetah : FantasticBeast
    {
        public override void SayHello()
        {
            Console.WriteLine("Hello from " + this.GetType());
        }
        public override void RunThread()
        {
            Thread.Sleep(2000);
            long num = Convert.ToInt64(request);
            response = Convert.ToString(19541);
        }
    }
}
