using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void Sample_Load(object sender, EventArgs e)
        {
            if(Retrieval.userRole!=null && Retrieval.userName!=null)
            label2.Text = Retrieval.userName + " ["+Retrieval.userRole+"]";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Are you sure you want to exit?", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
                Application.Exit();
        }
    }
}
