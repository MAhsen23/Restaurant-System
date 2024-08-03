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
    public partial class Customers : Sample2
    {
        public Customers()
        {
            InitializeComponent();
        }
        Int64 customerID;
        

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                errorLabelName.Visible = true;
            }
            else
            {
                errorLabelName.Visible = false;
            }
            if (tbPhone.Text == "")
            {
                errorLabelPhone.Visible = true;
            }
            else
            {
                errorLabelPhone.Visible = false;
            }
            if (tbAddress.Text == "")
            {
                errorLabelAddress.Visible = true;

            }
            else
            {
                errorLabelAddress.Visible = false;
            }

            if (errorLabelPhone.Visible || errorLabelName.Visible || errorLabelAddress.Visible)
            {
                Main.showMessage("Fields with * are mandatory", "error");
            }
            else
            {
                if (edit == 0)
                {
                   
                    Insertion.insertCustomer(tbName.Text.ToUpper(), tbPhone.Text, tbAddress.Text);
                    Main.resetDisable(leftPanel);
                    Retrieval.getCustomers(dataGridView1);
                }
                else if (edit == 1)
                {
                    Updation.updateCustomer(tbName.Text.ToUpper(), tbPhone.Text, tbAddress.Text,customerID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getCustomers(dataGridView1);
                }
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                errorLabelName.Visible = true;
            }
            else
            {
                errorLabelName.Visible = false;
            }

        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            if (tbPhone.Text == "")
            {
                errorLabelPhone.Visible = true;
            }
            else
            {
                errorLabelPhone.Visible = false;
            }
        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            if (tbAddress.Text == "")
            {
                errorLabelAddress.Visible = true;

            }
            else
            {
                errorLabelAddress.Visible = false;
            }
        }

        private void cell_click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    edit = 1;
                    delStatus = 1;
                    Main.DisableControls(leftPanel);
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    customerID = Int64.Parse(row.Cells[1].Value.ToString());
                    tbName.Text = row.Cells[2].Value.ToString();
                    tbPhone.Text = row.Cells[3].Value.ToString();
                    tbAddress.Text = row.Cells[4].Value.ToString();           
                }
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        public override void btnDelete_Click(object sender, EventArgs e)
        {
            if (delStatus == 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure, you want to delete this Customer ? ", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Deletion.deleteCustomer(customerID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getCustomers(dataGridView1);
                }
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            Main.resetDisable(leftPanel);
            Retrieval.getCustomers(dataGridView1);
        }
    }
}
