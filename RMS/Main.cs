using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace RMS
{
    class Main
    {

        private static string constr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RMS;Data Source=DESKTOP-TV1U6PA\\SQLEXPRESS";
        public static SqlConnection con = new SqlConnection(constr);

        //public static void showWindow(Form openWin, Form closeWindow, Form MDI)
        //{
        //    closeWindow.Close();
        //    openWin.WindowState = FormWindowState.Maximized;
        //    openWin.MdiParent = MDI;
        //    openWin.Show();
        //}

        //public static void showWindow(Form openWin, Form MDI)
        //{

        //    openWin.WindowState = FormWindowState.Maximized;
        //    openWin.MdiParent = MDI;
        //    openWin.Show();
            
        //}

        //public static void SerialNoShow(DataGridView dgv)
        //{
        //    int count = 0;
        //    foreach(DataGridViewRow row in dgv.Rows)
        //    {
        //        count++;
        //        row.Cells[0].Value = count;
        //    }
        //}

        public static void showMessage(string msg, string type)
        {
            if (type == "success")
            {
                MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(type == "error")
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void resetEnable(Panel p)
        {
            foreach (Control c in p.Controls)
            {
                if (c is DateTimePicker)
                {
                    DateTimePicker tb = (DateTimePicker)c;
                    tb.Enabled = true;
                }

                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    tb.Text = "";
                    tb.Enabled = true;
                }
                if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.SelectedIndex = -1;
                    cb.Enabled = true;
                }
                if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    rb.Checked = false;
                    rb.Enabled = true;
                }

                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.Checked = false;
                    cb.Enabled = true;
                }

                if (c is Button)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                }

                if (c is NumericUpDown)
                {
                    NumericUpDown n = (NumericUpDown)c;
                    n.Enabled = true;
                }
            }
        }

        public static void resetDisable(Panel p)
        {
            foreach (Control c in p.Controls)
            {
                if (c is DateTimePicker)
                {
                    DateTimePicker tb = (DateTimePicker)c;
                    tb.Enabled = false;
                }
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    tb.Text = "";
                    tb.Enabled = false;
                }
                if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.SelectedIndex = -1;
                    cb.Enabled = false;
                }
                if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    rb.Checked = false;
                    rb.Enabled = false;
                }

                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.Checked = false;
                    cb.Enabled = false;
                }

                if (c is Button)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }

                if (c is NumericUpDown)
                {
                    NumericUpDown n = (NumericUpDown)c;
                    n.Enabled = false;
                }

            }
        }

        public static void EnableControls(Panel p)
        {
            foreach (Control c in p.Controls)
            {
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    tb.Enabled = true;
                }
                if (c is DateTimePicker)
                {
                    DateTimePicker tb = (DateTimePicker)c;
                    tb.Enabled = true;
                }
                if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.Enabled = true;
                }
                if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    rb.Enabled = true;
                }

                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.Enabled = true;
                }

                if (c is Button)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                }

                if(c is NumericUpDown)
                {
                    NumericUpDown n = (NumericUpDown)c;
                    n.Enabled = true;
                }
            }
        }

        public static void DisableControls(Panel p)
        {
            foreach (Control c in p.Controls)
            {
                if (c is DateTimePicker)
                {
                    DateTimePicker tb = (DateTimePicker)c;
                    tb.Enabled = false;
                }
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    tb.Enabled = false;
                }
                if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.Enabled = false;
                }
                if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    rb.Enabled = false;
                }

                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.Enabled = false;
                }
                if (c is Button)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                    
                }
                if (c is NumericUpDown)
                {
                    NumericUpDown n = (NumericUpDown)c;
                    n.Enabled = false;
                }
            }
        }


    }
}
