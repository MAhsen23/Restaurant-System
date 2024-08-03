using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RMS
{
    class Deletion
    {
        public static void deleteRole(int roleID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "delete from Roles where r_id = "+roleID+"";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                if (rows >= 1)
                {
                    Main.showMessage("Role deleted " + rows + " rows effected", "success");
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

        public static void deleteUser(int userID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "delete from Users where u_id = " + userID + "";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                if (rows >= 1)
                {
                    Main.showMessage("User deleted " + rows + " rows effected", "success");
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

        public static void deleteCustomer(Int64 customerID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "delete from Customers where c_id = " + customerID + "";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                if (rows >= 1)
                {
                    Main.showMessage("Customer deleted " + rows + " rows effected", "success");
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


        public static void deleteTable(int tableID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "delete from Tables where t_id = " + tableID + "";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                if (rows >= 1)
                {
                    Main.showMessage("Table deleted " + rows + " rows effected", "success");
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





        public static void deleteCategory(int customerID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                string query = "delete from Category where c_id = " + customerID + "";
                SqlCommand cmd = new SqlCommand(query, Main.con);
                int rows = cmd.ExecuteNonQuery();
                if (rows >= 1)
                {
                    Main.showMessage("Category deleted " + rows + " rows effected", "success");
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


        public static void deleteMenuItem(int menuID)
        {
            try
            {
                if (Main.con.State == ConnectionState.Closed)
                {
                    Main.con.Open();
                }
                
                SqlCommand cmd = new SqlCommand("st_deleteMenuItem", Main.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mid", menuID);
                int rows = cmd.ExecuteNonQuery();
                if (rows >= 1)
                {
                    Main.showMessage("Menuitem deleted " + rows + " rows effected", "success");
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
    }
}
