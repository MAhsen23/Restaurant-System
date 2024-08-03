using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RMS
{
    class Updation
    {
        public static void updateRole(string role, int roleID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "update Roles set r_name = '"+role+"' where r_id="+roleID+"";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                Main.showMessage(role.ToUpper() + " role has been successfully updated " + rows + " rows effected", "success");
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        public static void updateUser(string u_uname, string u_phone, string u_address, string u_username, string u_password, int roleID,int userID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "update Users set u_name = '"+u_uname+"', u_username='"+u_username+ "', u_password='" + u_password + "', u_phone='" + u_phone + "', u_address='" + u_address + "', u_roleID=" + roleID + " where u_id = "+userID+" ";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                Main.showMessage(u_uname.ToUpper() + " user has been successfully updated " + rows + " rows effected", "success");
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        public static void updateCustomer(string c_name, string c_phone , string c_address, Int64 customerID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "update Customers set c_name = '" + c_name + "', c_phone='" + c_phone + "', c_address='" + c_address + "' where c_id = " + customerID + " ";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                Main.showMessage(c_name.ToUpper() + " user has been successfully updated " + rows + " rows effected", "success");
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }


        public static void updateTable(int t_number, int t_chairs, int TableID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "update Tables set t_number = " + t_number + ", t_chairs = " + t_chairs + " where t_id = " + TableID + " ";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                Main.showMessage("Table no "+t_number + " has been successfully updated " + rows + " rows effected", "success");
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }



        public static void updateCategory(string c_name, int categoryID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "update Category set c_name = '" + c_name + "' where c_id = " + categoryID + " ";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                Main.showMessage("Category has been successfully updated " + rows + " rows effected", "success");
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }


        //public static void updateMenuItem(string m_name, int m_catID, float m_price, string m_status, int menuID)
        //{
        //    try
        //    {
        //        if (Main.con.State == ConnectionState.Closed)
        //        {
        //            Main.con.Open();
        //        }
        //        string query = "update Menu set m_name = '" + m_name + "',m_price = '" + m_price + "',m_status = '" + m_status + "', m_catID = '" + m_catID + "' where m_id = " + menuID + " ";
        //        SqlCommand cmd = new SqlCommand(query, Main.con);
        //        int rows = cmd.ExecuteNonQuery();
        //        Main.showMessage("Menuitem has been successfully updated " + rows + " rows effected", "success");
        //        Main.con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Main.showMessage(ex.Message, "error");
        //    }
        //}


        public static void updateMenuItem(string m_name, int m_catID, float m_price, string m_status, int m_id)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_updateMenuItem", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", m_name);
                cmd.Parameters.AddWithValue("@catID", m_catID);
                cmd.Parameters.AddWithValue("@price", m_price);
                cmd.Parameters.AddWithValue("@status", m_status);
                cmd.Parameters.AddWithValue("mid", m_id);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Main.showMessage("Menuitem has been successfully updated " + rows + " rows effected", "success");
                }
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        public static void updateOrderStatus(Int64 orderID, string status)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_updateOrderStatus", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@orderID", orderID);
               
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Main.showMessage("Order status updated..", "success");
                }
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
        }

        public static int updateOrder(float amountPaid, float amountReturned,string status,Int64 oid)
        {
            int rows = 0;
            try
            {  
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_updateOrder", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@amountPaid", amountPaid);
                cmd.Parameters.AddWithValue("@amountReturned", amountReturned);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@oid", oid);
                rows = cmd.ExecuteNonQuery();
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
            return rows;
        }


        public static int updateOrder(float amount,Int64 oid)
        {
            int rows = 0;
            try
            {  
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                SqlCommand cmd = new SqlCommand("st_updateOrderTotalAmount", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderID", oid);
                cmd.Parameters.AddWithValue("@totalAmount", amount);
                rows = cmd.ExecuteNonQuery();
                Main.con.Close();
            }
            catch (Exception ex)
            {
                Main.con.Close();
                Main.showMessage(ex.Message, "error");
            }
            return rows;
        }
    }
}
