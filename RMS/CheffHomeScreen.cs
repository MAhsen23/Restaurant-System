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
    public partial class CheffHomeScreen : Sample
    {
        public CheffHomeScreen()
        {
            InitializeComponent();
        }

        private void CheffHomeScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Retrieval.getpendingOrders(dataGridView1);
        }

        Int64 orderID;
        private void cell_click(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1 && e.ColumnIndex != -1)
             {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                orderID = Int64.Parse(row.Cells[1].Value.ToString());
                Retrieval.getpendingOrderDetails(orderID, dataGridView2);
                if (e.ColumnIndex == 0 )
                {
                    DialogResult dr = MessageBox.Show("Are you sure?", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dr == DialogResult.Yes)
                    {
                        Updation.updateOrderStatus(orderID, "served");
                        Retrieval.getpendingOrders(dataGridView1);
                        dataGridView2.Rows.Clear();
                    }     
                }
            } 
        }

        int count = 0;
        private void timer_tick(object sender, EventArgs e)
        {
            count++;
            if (count == 600)
            {
                Retrieval.getpendingOrders(dataGridView1);
                count = 0;
            }

        }
        private void CheffHomeScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();  
        }
    }
}
