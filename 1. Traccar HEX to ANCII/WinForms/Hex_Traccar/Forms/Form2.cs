using System;
using System.Windows.Forms;

namespace Hex_Traccar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tutorials.techrad.co.za/");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
