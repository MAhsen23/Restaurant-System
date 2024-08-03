using RMS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class OrderModification : Sample
    {
        public OrderModification()
        {
            InitializeComponent();
        }

        private void OrderModification_Load(object sender, EventArgs e)
        {
            Retrieval.getOrderIDsWRTDate(dateTimePicker1.Value, cbOrderID);
            Retrieval.getOrderIDsWRTDate(dateTimePicker1.Value, listBox1);
            cbOrderID.SelectedIndex = -1;
            dataGridView1.Rows.Clear();

            Retrieval.loadItemsWithProc("st_getCategories", cbSelectCategory, "categoryName", "categoryID");
            cbSelectCategory.SelectedIndex = -1;
            cbSelectItem.SelectedIndex = -1;
        }


        private void getOrderDetails(Int64 orderID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_getOrderDetailsWRTOrderID", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderID", orderID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow[] dr = dt.Select();
                dataGridView1.Rows.Clear();
                int count = 0;
                foreach (DataRow row in dr)
                {
                    count++;
                    dataGridView1.Rows.Add(count, row[3].ToString(), row[2].ToString(), Math.Floor(double.Parse(row[6].ToString())), row[4].ToString(), Math.Floor(double.Parse(row[5].ToString())), row[0].ToString(), row[1].ToString());
                }

            }
            catch(Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }


        int PreviousRecordCount;
        private void cbOrderID_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbOrderID.SelectedIndex != -1)
            {
                getOrderDetails(Int64.Parse(cbOrderID.SelectedValue.ToString()));
                PreviousRecordCount = dataGridView1.Rows.Count;
                totalAmount = float.Parse(dataGridView1.Rows[0].Cells[7].Value.ToString());
                totalAmountLabel.Text = totalAmount.ToString();
                
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            Retrieval.getOrderIDsWRTDate(dateTimePicker1.Value, cbOrderID);
            Retrieval.getOrderIDsWRTDate(dateTimePicker1.Value, listBox1);
            cbOrderID.SelectedIndex = -1;
            dataGridView1.Rows.Clear();
            totalAmountLabel.Text = "0.0";
        }

        private void cbSelectItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSelectItem.SelectedIndex != -1)
                {
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
                }
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }

        private void cbSelectCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSelectCategory.SelectedIndex == -1)
                {
                    cbSelectItem.DataSource = null;
                    cbSelectItem.Items.Clear();
                }
                else
                {
                    Retrieval.loadItemsWithProc("st_getMenuWRTCategory", cbSelectItem, "Menu Item", "MenuID", "@cid", int.Parse(cbSelectCategory.SelectedValue.ToString()));
                    cbSelectItem.SelectedIndex = -1;
                    tbPrice.Text = "";
                    pictureBox3.Image = Resources.catering_icon_7__1_;
                }
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        float totalAmount = 0;
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSelectCategory.SelectedIndex == -1 || cbSelectItem.SelectedIndex == -1 || cbOrderID.SelectedIndex == -1 || tbPrice.Text == "" || tbQuantity.Value == 0)
                {
                    Main.showMessage("All fields are mandatory", "error");
                }
                else
                {
                    int count = dataGridView1.Rows.Count + 1;
                    bool itemExist = false;

                    //foreach (DataGridViewRow row in dataGridView1.Rows)
                    //{
                    //    if (row.Cells[1].Value.ToString() == cbSelectItem.SelectedValue.ToString())
                    //    {
                    //        itemExist = true;
                    //        break;
                    //    }
                    //}

                    for (int i = PreviousRecordCount; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() == cbSelectItem.SelectedValue.ToString())
                        {
                            itemExist = true;
                            break;
                        }
                    }


                    if (itemExist == false)
                    {
                        dataGridView1.Rows.Add(count,cbSelectItem.SelectedValue.ToString(),cbSelectItem.Text.ToString(),
                            double.Parse(tbPrice.Text),tbQuantity.Value.ToString(),
                            (double.Parse(tbQuantity.Value.ToString())*double.Parse(tbPrice.Text)), cbOrderID.SelectedValue.ToString(),null);
                        totalAmount += float.Parse(tbPrice.Text) * float.Parse(tbQuantity.Value.ToString());
                        totalAmountLabel.Text = totalAmount.ToString();
                    }
                    else
                    {
                        Main.showMessage("item added already", "error");
                    }
                }
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }
        
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > PreviousRecordCount)
                {
                    insertOrderDetails();
                    Updation.updateOrder(totalAmount, Int64.Parse(cbOrderID.SelectedValue.ToString()));
                }
            }catch(Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }
        private void insertOrderDetails()
        {
            try
            {
                Int64 orderID = Int64.Parse(cbOrderID.SelectedValue.ToString());
                int count = 0;
                for(int i = PreviousRecordCount; i < dataGridView1.Rows.Count; i++)
                {
                    count += Insertion.insertOrderDetails(orderID, int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()), int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                }
                if (count > 0)
                {
                    Main.showMessage("Order Uptaded", "success");
                }
                else
                {
                    Main.showMessage("Error Occured", "error");
                }
            }catch(Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (Retrieval.userRole == "ADMIN")
            {
                HomeScreen sc = new HomeScreen();
                sc.Show();
                this.Close();
            }
            else if(Retrieval.userRole=="WAITER")
            {
                WaiterHomeScreen sc = new WaiterHomeScreen();
                sc.Show();
                this.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1 && e.RowIndex>PreviousRecordCount-1)
                {
                    if (e.ColumnIndex == 8)
                    {
                        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                        float price = float.Parse(row.Cells[3].Value.ToString()) * float.Parse(row.Cells[4].Value.ToString());
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
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }
    }
}
