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
using System.IO;
namespace RMS
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\rms_connect"))
            {
                Settings obj = new Settings();
                obj.Show();
                
            }
            else
            {
                
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == ""){errorLabelUsername.Visible = true;}
            else{errorLabelUsername.Visible = false;}

            if (tbPassword.Text == ""){errorLabelPass.Visible = true;}
            else{errorLabelPass.Visible = false;}

            if (errorLabelPass.Visible || errorLabelUsername.Visible)
            {
                Main.showMessage("Fields with * are mandatory", "error");
            }
            else
            {
                if (Retrieval.getUserloginDetails(tbUsername.Text, tbPassword.Text))
                {
                    if (Retrieval.userRole.Equals("ADMIN"))
                    {
                        HomeScreen hs = new HomeScreen();
                        hs.Show();
                        this.Hide();
                    }
                    else if (Retrieval.userRole.Equals("CHEFF"))
                    {
                        CheffHomeScreen hs = new CheffHomeScreen();
                        hs.Show();
                        this.Hide();

                    }else if (Retrieval.userRole.Equals("WAITER"))
                    {
                        WaiterHomeScreen obj = new WaiterHomeScreen();
                        obj.Show();
                        this.Hide();
                    }
                }
                
            }
            
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                errorLabelUsername.Visible = true;
            }
            else
            {
                errorLabelUsername.Visible = false;
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                errorLabelPass.Visible = true;
            }
            else
            {
                errorLabelPass.Visible = false;
            }
        }
    }
}
