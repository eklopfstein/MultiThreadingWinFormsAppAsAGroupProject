using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtMessages.Text = "";
            ClassProcessing.ProcessClasses(txtMessages);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
