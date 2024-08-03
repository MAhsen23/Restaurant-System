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
    public partial class WaiterHomeScreen : Sample
    {
        public WaiterHomeScreen()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FoodMenu obj = new FoodMenu();
            obj.Show();
            this.Close();

        }

        

        private void btnOrder_Click_1(object sender, EventArgs e)
        {
            Orders obj = new Orders();
            obj.Show();
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            OrderModification obj = new OrderModification();
            obj.Show();
            this.Close();
        }
    }
}
