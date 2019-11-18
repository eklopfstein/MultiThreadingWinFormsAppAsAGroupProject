using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    abstract class FantasticBeast
    {
        private String _msg;
        public String msg {get { return _msg; } set { _msg = value; } }

        public virtual void SayHello() { Console.WriteLine("Hello from FantasticBeast.SayHello()"); }

        private Thread _thread;

        protected FantasticBeast()
        {
            _thread = new Thread(new ThreadStart(this.RunThread));
            _msg = ""; 
        }

        // Thread methods / properties
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public Boolean Join(int waitMilliseconds) => _thread.Join(waitMilliseconds);
        public bool IsAlive => _thread.IsAlive;

        // Override in base class
        public virtual void RunThread() { }
    }
}
