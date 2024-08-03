using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RMS.Properties;
using System.Transactions;


namespace RMS
{
    public partial class Orders : Sample
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            backBtnForOrders = 0;
            
            cbOrderType.Items.Add("DINE-IN");
            cbOrderType.Items.Add("TAKE-AWAY");
            cbOrderType.Items.Add("HOME-DELIVERY");

            Retrieval.loadItemsWithProc("st_getCategories", cbSelectCategory, "categoryName", "categoryID");
            cbSelectCategory.SelectedIndex = -1;
            cbSelectItem.SelectedIndex = -1;
            errorLabelSelectCategory.Visible = false;


            Retrieval.loadItemsWithProc("st_getTables", cbTable , "t_number", "t_id");
            cbTable.SelectedIndex = -1;
            errorLabelTable.Visible = false;

            Retrieval.loadItemsWithProc("st_getCustomerWithPhoneNos", listBox1, "customerNamePhone", "CustomerID");
            Retrieval.loadItemsWithProc("st_getCustomerWithPhoneNos", cbSelectCustomer, "customerNamePhone", "CustomerID");
            cbSelectCustomer.SelectedIndex = -1;
            errorLabelCustomer.Visible = false;

            Main.resetEnable(leftPanel);
            
        }
        
        private void cbSelectItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSelectItem.SelectedIndex != -1)
                {
                    errorLabelSelectItem.Visible = false;

                    if (Main.con.State == ConnectionState.Closed)
                    {
                        Main.con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("st_getPriceWRTItem", Main.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mid", cbSelectItem.SelectedValue.ToString());
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    tbPrice.Text = Math.Floor((double.Parse(sdr["Price"].ToString()))).ToString();
                    Main.con.Close();
                    pictureBox3.Image = Image.FromFile(Retrieval.getMenuItemImagePath(int.Parse(cbSelectItem.SelectedValue.ToString())));
                    pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                    Retrieval.loadCategoryWRTItem(cbSelectItem.Text);
                }
                else
                {
                    tbPrice.Text = "";
                    pictureBox3.Image = Resources.catering_icon_7__1_;
                    errorLabelSelectItem.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }
        private void cbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbOrderType.SelectedIndex != -1)
                {
                    if (cbOrderType.SelectedIndex == 0)
                    {
                        cbTable.Enabled = true;
                        cbSelectCustomer.Visible = false;
                        selectCustomerLabel.Visible = false;
                        errorLabelTable.Visible = false;
                        //not fount
                        checkBox1.Visible = false;
                        
                    }
                    else
                    {               
                        cbTable.Enabled = false;
                        cbTable.SelectedIndex = -1;
                        errorLabelTable.Visible = false;
                        cbSelectCustomer.Visible = true;
                        selectCustomerLabel.Visible = true;
                        //not found
                        checkBox1.Visible = true;
                        
                    }
                    errorLabelOrderType.Visible = false;
                }
                else
                {
                    errorLabelOrderType.Visible = true;
                }
            }
            catch(Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        
        
        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTable.SelectedIndex != -1)
            {
                errorLabelTable.Visible = false;
                
                    if (Retrieval.checkTableStatus(int.Parse(cbTable.SelectedValue.ToString())))
                    {
                        cbTable.SelectedIndex = -1;
                    }
                
            }
            else
            {
                errorLabelTable.Visible = true;
            }
        }
        private void cbSelectCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectCustomer.Visible)
            {
                if (cbSelectCustomer.SelectedIndex == -1) { errorLabelCustomer.Visible = true; } else { errorLabelCustomer.Visible = false; }
            }
        }
        private void tbQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (tbQuantity.Value == 0)
            {
                errorLabelQuantity.Visible = true;
            }
            else
            {
                errorLabelQuantity.Visible = false;
            }
        }

        float totalAmount=0;
        int catID;
        string catName;
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbQuantity.Value == 0)
                {
                    errorLabelQuantity.Visible = true;
                }
                else
                {
                    errorLabelQuantity.Visible = false;
                }


                //order type validation
                if (cbOrderType.SelectedIndex == -1)
                {
                    errorLabelOrderType.Visible = true;
                }
                else
                {
                    errorLabelOrderType.Visible = false;
                    if (cbOrderType.SelectedIndex == 0)
                    {
                        if (cbTable.SelectedIndex == -1)
                        {
                            errorLabelTable.Visible = true;
                        }
                        else
                        {
                            errorLabelTable.Visible = false;
                        }

                    }
                    else
                    { 
                        if (cbSelectCustomer.SelectedIndex == -1) { errorLabelCustomer.Visible = true; } else { errorLabelCustomer.Visible = false; }
                    }
                }

                if (cbSelectCategory.SelectedIndex == -1) { errorLabelSelectCategory.Visible = true; }
                else{ errorLabelSelectCategory.Visible = false; }


                if (cbSelectItem.SelectedIndex == -1) { errorLabelSelectItem.Visible = true; } else { errorLabelSelectItem.Visible = false; }


                if (errorLabelSelectItem.Visible || errorLabelTable.Visible || errorLabelQuantity.Visible || errorLabelOrderType.Visible || errorLabelCustomer.Visible)
                {
                    Main.showMessage("Fields with * are mandatory", "error");
                }
                else
                {
                    int count = dataGridView1.Rows.Count + 1;
                    bool itemExist = false;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[3].Value.ToString() == cbSelectItem.SelectedValue.ToString())
                        {
                            itemExist = true;
                            break;
                        }
                    }
                    if (itemExist == false)
                    {
                        catID = Retrieval.CATEGORYID;
                        catName = Retrieval.CATEGORYNAME;

                        if (cbOrderType.SelectedIndex == 0)
                        {
                            dataGridView1.Rows.Add(count, catID.ToString(),
                                catName,
                                cbSelectItem.SelectedValue.ToString(),
                                cbSelectItem.Text.ToString(),
                                tbPrice.Text.ToString(),
                                tbQuantity.Value.ToString(),
                                cbOrderType.SelectedItem.ToString(),
                                cbTable.SelectedValue.ToString(),
                                cbTable.Text.ToString(), "", "");
                            totalAmount += float.Parse(tbPrice.Text)*float.Parse(tbQuantity.Value.ToString());
                            totalAmountLabel.Text = totalAmount.ToString();
                        }
                        else if (cbOrderType.SelectedIndex == 2 || cbOrderType.SelectedIndex == 1)
                        {
                            dataGridView1.Rows.Add(count, catID,
                               catName,
                               cbSelectItem.SelectedValue.ToString(),
                               cbSelectItem.Text.ToString(),
                               tbPrice.Text.ToString(),
                               tbQuantity.Value.ToString(),
                               cbOrderType.SelectedItem.ToString(),
                               "", "", cbSelectCustomer.SelectedValue.ToString(),
                                cbSelectCustomer.Text.ToString());
                            totalAmount += float.Parse(tbPrice.Text) * float.Parse(tbQuantity.Value.ToString());
                            totalAmountLabel.Text = totalAmount.ToString();

                        }
                    }
                    else
                    {
                        Main.showMessage("item added already", "error");
                    }

                }
            }catch(Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            } 
        }
        
        
        private void insertOrderDetails()
        {
            Int64 orderID = Retrieval.lastOrderID();
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                count += Insertion.insertOrderDetails(orderID, int.Parse(row.Cells[3].Value.ToString()), int.Parse(row.Cells[6].Value.ToString()));
            }
            if (count > 0)
            {
                Main.showMessage("Order Placed", "success");
            }
            else
            {
                Main.showMessage("Error Occured", "error");
            }
        }
        
        private void cell_click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    if (e.ColumnIndex == 12)
                    {
                        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                        float price = float.Parse(row.Cells[5].Value.ToString())*float.Parse(row.Cells[6].Value.ToString());
                        totalAmount -= price;
                        totalAmountLabel.Text = totalAmount.ToString();
                        dataGridView1.Rows.Remove(row);

                        int count = 1;
                        foreach (DataGridViewRow rowCount in dataGridView1.Rows)
                        {
                            rowCount.Cells[0].Value = count;
                        }
                    }
                }
            }catch(Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        private void cbSelectCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSelectCategory.SelectedIndex == -1)
                {
                    errorLabelSelectCategory.Visible = false;
                    cbSelectItem.DataSource = null;
                    cbSelectItem.Items.Clear();
                }
                else
                {
                    errorLabelSelectCategory.Visible = false;
                    Retrieval.loadItemsWithProc("st_getMenuWRTCategory", cbSelectItem, "Menu Item", "MenuID", "@cid", int.Parse(cbSelectCategory.SelectedValue.ToString()));
                    cbSelectItem.SelectedIndex = -1;
                    errorLabelSelectItem.Visible = false;
                    tbPrice.Text = "";
                    pictureBox3.Image = Resources.catering_icon_7__1_;
                }
            }
            catch(Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }
        public static int backBtnForOrders = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                backBtnForOrders = 1;
                Customers c = new Customers();
                c.Show();
                this.Close();
            }
            else{
                backBtnForOrders = 0;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                using (TransactionScope sc = new TransactionScope())
                {

                    try
                    {
                        if (cbOrderType.SelectedIndex == 0)
                        {
                            Insertion.insertOrder(DateTime.Today, 1, cbOrderType.Text,
                                int.Parse(cbTable.SelectedValue.ToString()),
                                float.Parse(totalAmountLabel.Text), 0, 0, "pending");

                            insertOrderDetails();
                        }
                        else
                        {
                            Insertion.insertOrder(DateTime.Today, int.Parse(cbSelectCustomer.SelectedValue.ToString()),
                                cbOrderType.Text,
                                0,
                                float.Parse(totalAmountLabel.Text), 0, 0, "pending");

                            insertOrderDetails();
                        }
                    }
                    catch (Exception ex)
                    {
                        Main.showMessage(ex.Message, "error");
                    }
                    sc.Complete();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Retrieval.userRole == "ADMIN")
            {
                HomeScreen sc = new HomeScreen();
                sc.Show();
                this.Close();
            }
            else if(Retrieval.userRole == "WAITER")
            {
                WaiterHomeScreen sc = new WaiterHomeScreen();
                sc.Show();
                this.Close();
            }
        }
    }
}
