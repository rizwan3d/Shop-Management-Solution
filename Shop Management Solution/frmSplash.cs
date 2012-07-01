using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shop_Management_Solution
{
    public partial class frmSplash : Form
    {
        private Timer objTimer = new Timer();
        public frmSplash()
        {
            InitializeComponent();
            timerSplash.Enabled = true;            
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            frmMainMenu mainMenu = new frmMainMenu();
            mainMenu.Show();
            timerSplash.Enabled = false;
            this.Dispose(false);
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            pbLoading.Increment(10);            
            objTimer.Interval = 300;
            objTimer.Tick += new EventHandler(_Timer_Tick);
            objTimer.Start();
        }

        private void _Timer_Tick(object sender, EventArgs e)
        {
            pbLoading.Increment(10);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
