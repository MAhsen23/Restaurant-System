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
    public partial class Sample2 : Sample
    {
        public Sample2()
        {
            InitializeComponent();
        }
        

        protected int edit = 0;
        protected int delStatus = 0;

        public virtual void btnAdd_Click(object sender, EventArgs e)
        {
            edit = 0;
            Main.resetEnable(leftPanel);
            delStatus = 0;
        }

        public virtual void btnEdit_Click(object sender, EventArgs e)
        {
            if (edit == 1)
            {
                Main.EnableControls(leftPanel);
            }
        }

        public virtual void btnDelete_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void backButton_click(object sender, EventArgs e)
        {
            if (Orders.backBtnForOrders == 0)
            {
                HomeScreen obj = new HomeScreen();
                obj.Show();
                this.Close();
            }
            else
            {
                Orders obj = new Orders();
                obj.Show();
                this.Close();
            }
        }
    }
}
