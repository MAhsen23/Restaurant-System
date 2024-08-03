using CrystalDecisions.CrystalReports.Engine;
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
    public partial class OrderCompletionWindow : Sample
    {
        public OrderCompletionWindow()
        {
            InitializeComponent();
        }
        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTable.SelectedIndex != -1)
            {
                Retrieval.getOrder4Bill(int.Parse(cbTable.SelectedValue.ToString()),dataGridView1,tbOrder);
                if (dataGridView1.Rows.Count != 0)
                {
                    billLabel.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    label3.Visible = true;
                    billLabel.Visible = true;
                    label6.Visible = true;
                    tbAmountPaid.Visible = true;
                    label7.Visible = true;
                    tbAmountRet.Visible = true;
                }
                else
                {
                    tbOrder.Text = "";
                    label3.Visible = false;
                    billLabel.Visible = false;
                    label6.Visible = false;
                    tbAmountPaid.Visible = false;
                    label7.Visible = false;
                    tbAmountRet.Visible = false;
                }
            }
            else
            {
                label3.Visible = false;
                billLabel.Visible = false;
                label6.Visible = false;
                tbAmountPaid.Visible = false;
                label7.Visible = false;
                tbAmountRet.Visible = false;
                tbOrder.Text = "";
                dataGridView1.Rows.Clear();
                billLabel.Text = "";
            }
        }

        private void OrderCompletionWindow_Load(object sender, EventArgs e)
        {
            cbOrderType.Items.Add("DINE-IN");
            cbOrderType.Items.Add("TAKE-AWAY");
            cbOrderType.Items.Add("HOME-DELIVERY");

            Retrieval.loadItemsWithProc("st_getPendingOrderCustomer", cbSelectCustomer, "customerNamePhone", "CustomerID");
            cbSelectCustomer.SelectedIndex = -1;
            
            label3.Visible = false;
            billLabel.Visible = false;
            label6.Visible = false;
            tbAmountPaid.Visible = false;
            label7.Visible = false;
            tbAmountRet.Visible = false;
            Retrieval.loadItemsWithProc("st_getTables", cbTable, "t_number", "t_id");
            cbTable.SelectedIndex = -1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            HomeScreen sc = new HomeScreen();
            sc.Show();
            this.Close();
        }

        private void tbAmountPaid_TextChanged(object sender, EventArgs e)
        {
            tbAmountRet.Text = "";
            if (tbAmountPaid.Text != "")
            {
                if (double.Parse((tbAmountPaid.Text)) >= double.Parse(billLabel.Text))
                {
                    double amtPaid = double.Parse(tbAmountPaid.Text);
                    double amtRet = amtPaid - double.Parse(billLabel.Text);
                    tbAmountRet.Text = amtRet.ToString(); 
                }
            }
        }

        ReportDocument rd;
        private void billBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbAmountRet.Text != "")
                {
                    int ch = 0;
                    if (cbOrderType.SelectedIndex == 0)
                        ch = Updation.updateOrder(float.Parse(tbAmountPaid.Text), float.Parse(tbAmountRet.Text), "completed", Int64.Parse(tbOrder.Text));
                    else
                        ch = Updation.updateOrder(float.Parse(tbAmountPaid.Text), float.Parse(tbAmountRet.Text), "completed", Int64.Parse(tbOrder.Text));

                    if (ch > 0)
                    {
                        DialogResult dr = MessageBox.Show("Order completed successfully..", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            rd = new ReportDocument();                           
                            Retrieval.loadBillReport(rd, crystalReportViewer1,Int64.Parse(tbOrder.Text));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        private void cbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTable.SelectedIndex = -1;
            cbSelectCustomer.SelectedIndex = -1;
            label3.Visible = false;
            billLabel.Visible = false;
            label6.Visible = false;
            tbAmountPaid.Visible = false;
            label7.Visible = false;
            tbAmountRet.Visible = false;
            tbOrder.Text = "";
            dataGridView1.Rows.Clear();

            if (cbOrderType.SelectedIndex == 0)
            {
                tableLabel.Visible = true;
                cbTable.Visible = true;
                selectCustomerLabel.Visible = false;
                cbSelectCustomer.Visible = false;
                
            }
            else
            {
                selectCustomerLabel.Visible = true;
                cbSelectCustomer.Visible = true; 
                tableLabel.Visible = false;
                cbTable.Visible = false;   
            }
        }
        private void cbSelectCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectCustomer.SelectedIndex != -1)
            {
                Retrieval.getOrder4BillWRTPhone(Int64.Parse(cbSelectCustomer.SelectedValue.ToString()), dataGridView1, tbOrder);
                if (dataGridView1.Rows.Count != 0)
                {
                    billLabel.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    label3.Visible = true;
                    billLabel.Visible = true;
                    label6.Visible = true;
                    tbAmountPaid.Visible = true;
                    label7.Visible = true;
                    tbAmountRet.Visible = true;
                }
                else
                {
                    tbOrder.Text = "";
                    label3.Visible = false;
                    billLabel.Visible = false;
                    label6.Visible = false;
                    tbAmountPaid.Visible = false;
                    label7.Visible = false;
                    tbAmountRet.Visible = false;
                }
            }
            else
            {
                label3.Visible = false;
                billLabel.Visible = false;
                label6.Visible = false;
                tbAmountPaid.Visible = false;
                label7.Visible = false;
                tbAmountRet.Visible = false;
                tbOrder.Text = "";
                dataGridView1.Rows.Clear();
                billLabel.Text = "";
            }
        }

        private void OrderCompletionWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
}
