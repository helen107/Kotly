using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyrsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void k1_Click(object sender, EventArgs e)
        {
            GM5014gas k1GM5014 = new GM5014gas();
            this.Visible = false;
            k1GM5014.ShowDialog();
        }

        private void k2_Click(object sender, EventArgs e)
        {
            Rex200DataInputForm rex200DataInputForm = new Rex200DataInputForm();
            this.Visible = false;
            rex200DataInputForm.ShowDialog();
        }

        private void k4_Click(object sender, EventArgs e)
        {
            PTVM50 k3PTVM50 = new PTVM50();
            this.Visible = false;
            k3PTVM50.ShowDialog();
        }

        private void k3_Click(object sender, EventArgs e)
        {
            DE6514GMgas k1DE6514GM = new DE6514GMgas();
            this.Visible = false;
            k1DE6514GM.ShowDialog();
        }

        private void k1KVGM100_Click(object sender, EventArgs e)
        {
            KVGM100mazut k1KVGM100 = new KVGM100mazut();
            this.Visible = false;
            k1KVGM100.ShowDialog();
        }

        private void k3KVGM100_Click(object sender, EventArgs e)
        {
            KVGM100mazut k1KVGM100 = new KVGM100mazut();
            this.Visible = false;
            k1KVGM100.ShowDialog();
        }

        private void k3DEGM_Click(object sender, EventArgs e)
        {
            DE6514GMgas k3DE6514GM = new DE6514GMgas();
            this.Visible = false;
            k3DE6514GM.ShowDialog();
        }


        private void k4PTVM100_Click(object sender, EventArgs e)
        {
            PTVM50 k3PTVM50 = new PTVM50();
            this.Visible = false;
            k3PTVM50.ShowDialog();
        }

        private void k4BKZ_Click(object sender, EventArgs e)
        {
            BKZ5039gas k4BKZ5039gas = new BKZ5039gas();
            this.Visible = false;
            k4BKZ5039gas.ShowDialog();
        }
    }
}
