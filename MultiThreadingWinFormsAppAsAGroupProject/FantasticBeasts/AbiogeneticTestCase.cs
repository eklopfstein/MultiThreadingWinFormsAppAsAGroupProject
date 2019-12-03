/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Threading;


namespace MultiThreadingWinFormsAppAsAGroupProject {
    /// <summary>
    /// Test case. Do not edit. 
    /// </summary>
    class AbiogeneticTestCase : FantasticBeast {
        public override void SayHello() {
            Console.WriteLine("Hello from " + this.GetType());
        }
        public override void RunThread() {
            Thread.Sleep(2000);
            long num = Convert.ToInt64(request);
            response = Convert.ToString(19541);
        }
    }
}
