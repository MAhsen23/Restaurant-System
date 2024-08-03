using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace RMS
{
    class Insertion
    {
        public static void insertRole(string role)
        {
            try
            {
                if(Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "insert into Roles values('" + role + "')";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                Main.showMessage(role.ToUpper()+" role has been successfully added " + rows + " rows effected", "success");
                Main.con.Close();
            }
            catch (Exception  ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        public static void insertUser(string u_name,string u_username, string u_password, string u_phone, string u_address, int u_roleID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "insert into Users values('" + u_name + "','" + u_username + "','" + u_password + "','" + u_phone + "','" + u_address + "',"+u_roleID+")";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                Main.showMessage("New user "+ u_name.ToUpper() + " has been successfully added " + rows + " rows effected", "success");
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }


        public static void insertCustomer(string c_name, string c_phone, string c_address)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "insert into Customers values('" + c_name + "','" + c_phone + "','"+c_address+"')";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                Main.showMessage("New customer " + c_name.ToUpper() + " has been successfully added " + rows + " rows effected", "success");
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        public static void insertTable(int t_number, int t_chairs)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "insert into Tables values(" + t_number + "," + t_chairs + ")";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                if (rows >= 1)
                {
                    Main.showMessage("New table has been successfully added ", "success");
                }
                else
                {
                    Main.showMessage("Error", "error");
                }
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }



        public static void insertCategory(string c_name)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "insert into Category values('" + c_name + "')";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                if (rows >= 1)
                {
                    Main.showMessage("New category has been successfully added ", "success");
                }
                else
                {
                    Main.showMessage("Error", "error");
                }
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }
        
        public static void insertMenuItem(string m_name, int m_catID, float m_price, string m_status,string m_imagePath)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_insertMenuItem", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name",m_name);
                cmd.Parameters.AddWithValue("@catID",m_catID);
                cmd.Parameters.AddWithValue("@price",m_price);
                cmd.Parameters.AddWithValue("@status",m_status);
                cmd.Parameters.AddWithValue("@imagePath", m_imagePath);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Main.showMessage("Menuitem has been successfully added " + rows + " rows effected", "success");
                }
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }


        public static void insertOrder(DateTime date, Int64 custID, string orderType, int tableID, float tAmount, float amountPaid, float amountReturned, string status)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_insertOrder", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@custID", custID);
                cmd.Parameters.AddWithValue("@orderType", orderType);
                cmd.Parameters.AddWithValue("@tableID", tableID);
                cmd.Parameters.AddWithValue("@tAmount", tAmount);
                cmd.Parameters.AddWithValue("@amountPaid", amountPaid);
                cmd.Parameters.AddWithValue("@amountReturned", amountReturned);
                cmd.Parameters.AddWithValue("@status", status);
                
                int rows = cmd.ExecuteNonQuery();
                Main.con.Close();
            } 
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }


        public static int  insertOrderDetails(Int64 orderID, int proID, int quan)
        {
            int rows = 0;
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_insertOrderDetails", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@oid", orderID);
                cmd.Parameters.AddWithValue("@proID", proID);
                cmd.Parameters.AddWithValue("@quan", quan);
                 
                rows = cmd.ExecuteNonQuery();
                
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
            return rows;
        }

    }
}
