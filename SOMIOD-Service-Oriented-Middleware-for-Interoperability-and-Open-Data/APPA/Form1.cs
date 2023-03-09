
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPA
{
    public partial class Form1 : Form
    {
        private bool isCollpased;
        private Form activeForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            childForm.BringToFront();
            childForm.Show();
        }

        private void ButtonAppDrop_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormApplication(), sender);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormApplication(), sender);
        }

        private void BtnModules_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormModules(), sender);
        }

        private void BtnData_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormData(), sender);
        }

        private void BtnSubscription_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSubscription(), sender);
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
