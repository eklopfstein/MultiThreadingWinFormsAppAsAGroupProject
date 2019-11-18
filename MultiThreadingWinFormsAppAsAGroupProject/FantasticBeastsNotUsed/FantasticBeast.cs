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
        private TextBox txtMessages;
        public void setTextBox(TextBox txtMessages) { this.txtMessages = txtMessages; }
        public TextBox getTextBox() { return txtMessages; }
        public virtual void SayHello() { Console.WriteLine("Hello from FantasticBeast.SayHello()"); }
        private Thread _thread;

        protected FantasticBeast()
        {
            txtMessages = null;
            _thread = new Thread(new ThreadStart(this.RunThread));
        }
        protected FantasticBeast(TextBox txtMessages)
        {
            this.txtMessages = txtMessages;
            _thread = new Thread(new ThreadStart(this.RunThread));
        }

        // Thread methods / properties
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;

        // Override in base class
        public virtual void RunThread() { }
    }
}
