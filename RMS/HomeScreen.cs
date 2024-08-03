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
    public partial class HomeScreen : Sample
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            Roles roles = new Roles();
            this.Close();
            roles.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            this.Close();
            users.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            this.Close();
            customers.Show();
        }

        private void btnFoodCategory_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            this.Close();
            categories.Show();
        }

        private void btnFoodMenu_Click(object sender, EventArgs e)
        {
            FoodMenu foodmenu = new FoodMenu();
            this.Close();
            foodmenu.Show();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            Tables tables = new Tables();
            tables.Show();
            this.Close();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderCompletionWindow ocw = new OrderCompletionWindow();
            ocw.Show();
            this.Close();
        }

        private void leftPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderModification obj = new OrderModification();
            obj.Show();
            this.Close();
        }
    }
}
