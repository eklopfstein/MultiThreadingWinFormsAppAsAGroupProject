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
            long num = Convert.ToInt64(request);
            response = Convert.ToString(LPF(num));
        }

        static private long LPF(long num)
        {
            long test = 1;
            bool found = false;
            for (long i = num / 2; !found && i > 1; i--)
            {
                if (num % i == 0 && isPrime(i))
                {
                    test = i;
                    found = true;
                }
            }
            return test;

        }
        static private bool isPrime(long num)
        {
            for (long i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
