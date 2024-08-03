using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace RMS
{
    class Retrieval
    {
        public static string userRole { get; set; }
        public static string userName { get; set; }

        
        public static bool getUserloginDetails(string u_username, string password)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("getUserlogin", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@u_username", u_username);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        if (sdr["u_password"].Equals(password))
                        {
                            userRole = sdr["r_name"].ToString();
                            userName = sdr["u_name"].ToString();
                            sdr.Close();
                            return true;
                        }
                        else
                        {
                            Main.showMessage("Invalid password....", "error");
                        }
                    }
                }
                else
                {
                    Main.showMessage("Invlid User....", "error");
                }
                sdr.Close();
                Main.con.Close();
                return false;

            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
                return false;
            }
        }
        public static void getRoles(DataGridView dgv)
        {
            try
            {
                DataSet ds = null;
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "select * from Roles";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                ds = new DataSet();
                sda.Fill(ds);
                Main.con.Close();

                DataRow[] dr = ds.Tables[0].Select();
                dgv.Rows.Clear();
                int count = 0;
                foreach (DataRow row in dr)
                {
                    count++;
                    dgv.Rows.Add(count, row[0].ToString(), row[1].ToString());

                }
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }

        public static void getUsers(DataGridView dgv)
        {
            try
            {
                DataSet ds = null;
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "select u.u_id,u.u_name,u.u_username,u.u_password,u.u_phone,u.u_address,u.u_roleID,r.r_name from Users u inner join Roles r on u.u_roleID = r.r_id";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                ds = new DataSet();
                sda.Fill(ds);
                Main.con.Close();

                DataRow[] dr = ds.Tables[0].Select();
                dgv.Rows.Clear();
                foreach (DataRow row in dr)
                {
                    dgv.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[7].ToString(), row[4].ToString(), row[5].ToString());
                }
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }


        public static void getCustomers(DataGridView dgv)
        {
            try
            {
                DataSet ds = null;
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "select * from Customers";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                ds = new DataSet();
                sda.Fill(ds);
                Main.con.Close();

                DataRow[] dr = ds.Tables[0].Select();
                dgv.Rows.Clear();
                int count = 0;
                foreach (DataRow row in dr)
                {
                    count++;
                    dgv.Rows.Add(count, row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }


        public static void getTables(DataGridView dgv)
        {
            try
            {
                DataSet ds = null;
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "select * from Tables";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                ds = new DataSet();
                sda.Fill(ds);
                Main.con.Close();

                DataRow[] dr = ds.Tables[0].Select();
                dgv.Rows.Clear();
                int count = 0;
                foreach (DataRow row in dr)
                {
                    count++;
                    dgv.Rows.Add(count, row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }


        public static void getCategories(DataGridView dgv)
        {
            try
            {
                DataSet ds = null;
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "select * from Category";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                ds = new DataSet();
                sda.Fill(ds);
                Main.con.Close();

                DataRow[] dr = ds.Tables[0].Select();
                dgv.Rows.Clear();
                int count = 0;
                foreach (DataRow row in dr)
                {
                    count++;
                    dgv.Rows.Add(count, row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }


        public static void getMenuItems(DataGridView dgv)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getMenu", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Main.con.Close();
                DataRow[] dr = dt.Select();
                dgv.Rows.Clear();

                int count = 0;
                foreach (DataRow row in dr)
                {
                    count++;
                    dgv.Rows.Add(count, row[0].ToString(), row[1].ToString(), Math.Floor(double.Parse(row[2].ToString())), row[4].ToString(), row[5].ToString(), row[3].ToString());
                }
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }

        public static string getMenuItemImagePath(int m_id)
        {
            string imagePath = null;
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getItemImagePath", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mid", m_id);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                imagePath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)) + sdr["ImagePath"].ToString();
                Main.con.Close();

            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
            return imagePath;
        }

        private static int categoryID;
        private static string categoryName;
        public static int CATEGORYID
        {
            get
            {
                return categoryID;
            }
            private set
            {
                categoryID = value;
            }
        }
        public static string CATEGORYNAME
        {
            get
            {
                return categoryName;
            }
            private set
            {
                categoryName = value;
            }
        }

        public static void loadCategoryWRTItem(string item)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getCategoryWRTItem", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", item);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        CATEGORYID = int.Parse(sdr[0].ToString());
                        CATEGORYNAME = sdr[1].ToString();

                    }
                }
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }

        public static Int64 lastOrderID()
        {
            Int64 orderID = 0;
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getLastOrderId", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                orderID = Int64.Parse(cmd.ExecuteScalar().ToString());
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
            return orderID;
        }

        public static void loadItems(string query, ComboBox cb, string dMember, string vMember)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, Main.con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cb.DisplayMember = dMember;
                cb.ValueMember = vMember;
                cb.DataSource = dt;
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }
        public static void loadItemsWithProc(string proc, ComboBox cb, string dMember, string vMember, string param = null, int val = 0)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand(proc, Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (!(param == null && val == 0))
                {
                    cmd.Parameters.AddWithValue(param, val);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Main.con.Close();
                cb.DisplayMember = dMember;
                cb.ValueMember = vMember;
                cb.DataSource = dt;

            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
            Main.con.Close();
        }
        public static void loadItemsWithProc(string proc, ListBox cb, string dMember, string vMember, string param = null, int val = 0)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand(proc, Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (!(param == null && val == 0))
                {
                    cmd.Parameters.AddWithValue(param, val);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cb.DisplayMember = dMember;
                cb.ValueMember = vMember;
                cb.DataSource = dt;
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }



        public static void getOrderIDsWRTDate(DateTime date, ComboBox cb)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getOrderWRTDate", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@date", date);
                
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cb.DisplayMember = "IDTable";
                cb.ValueMember = "ID";
                cb.DataSource = dt;
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }
        public static void getOrderIDsWRTDate(DateTime date, ListBox cb )
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getOrderWRTDate", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@date", date);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cb.DisplayMember = "IDTable";
                cb.ValueMember = "ID";
                cb.DataSource = dt;
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }

        public static bool checkTableStatus(int tableID)
        {
            bool stat = false;
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_checkTableBusyFree", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tableID", tableID);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                    stat = true;
                else
                    stat = false;
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
            return stat;
        }


        public static void getpendingOrders(DataGridView dataGridView1)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getOrders", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow[] dr = dt.Select();
                dataGridView1.Rows.Clear();

                foreach (DataRow row in dr)
                {
                    
                    dataGridView1.Rows.Add(null,row[0].ToString(), row[1].ToString().ToUpper());
                }
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }

        public static void getpendingOrderDetails(Int64 orderID, DataGridView dataGridView1)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getOrderDetails", Main.con);
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
                    dataGridView1.Rows.Add(count, row[0].ToString(), row[1].ToString());
                }
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }


        public static void getOrder4Bill(int tableID, DataGridView dataGridView1, TextBox tbOrder)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getOrderDetailsWRTTable", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tableID", tableID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow[] dr = dt.Select();
                dataGridView1.Rows.Clear();

                int count = 0;
                foreach (DataRow row in dr)
                {
                    count++;
                    dataGridView1.Rows.Add(count, row["Item"].ToString(), row["Quantity"].ToString(), Math.Floor(double.Parse(row["Price"].ToString())), row["Total Amount"].ToString());

                    tbOrder.Text = row["ID"].ToString();
                }
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }

        public static void getOrder4BillWRTPhone(Int64 customerID, DataGridView dataGridView1, TextBox tbOrder)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getOrderDetailsWRTPhone", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerID", customerID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow[] dr = dt.Select();
                dataGridView1.Rows.Clear();

                int count = 0;
                foreach (DataRow row in dr)
                {
                    count++;
                    dataGridView1.Rows.Add(count, row["Item"].ToString(), row["Quantity"].ToString(), Math.Floor(double.Parse(row["Price"].ToString())), row["Total Amount"].ToString());

                    tbOrder.Text = row["ID"].ToString();
                }
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }


        public static void loadBillReport(ReportDocument rd, CrystalReportViewer crv, Int64 orderID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_getOrderReport", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                    
                cmd.Parameters.AddWithValue("@orderID", orderID);
                

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rd.Load(Application.StartupPath + "\\reports\\billreport.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();
            }
            catch (Exception ex)
            {
                if (rd != null)
                {
                    rd.Close();
                }
                Main.showMessage(ex.Message, "error");
            }
            Main.con.Close();
        }
    }
}
