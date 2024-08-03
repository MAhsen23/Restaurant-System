using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace RMS
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void tbServer_TextChanged(object sender, EventArgs e)
        {
            if (tbServer.Text == "")
                tbServerError.Visible = true;
            else
                tbServerError.Visible = false;
        }

        private void tbDatabase_TextChanged(object sender, EventArgs e)
        {
            if (tbDatabase.Text == "")
                tbDatabaseError.Visible = true;
            else
                tbDatabaseError.Visible = false;
        }

        private void cbIntegSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIntegSecurity.Checked) {
                tbUserIdError.Visible = false;
                tbDbPasswordError.Visible = false;
                tbUserID.Enabled = false;
                tbDbPassword.Enabled = false;
                tbDbPassword.Text = "";
                tbUserID.Text = "";
            }
            else
            {
                tbUserID.Enabled = true;
                tbDbPassword.Enabled = true;
            }
        }

        private void tbUserID_TextChanged(object sender, EventArgs e)
        {
            if (cbIntegSecurity.Checked)
            {
                if (tbUserID.Text == "")
                    tbUserIdError.Visible = true;
                else
                    tbUserIdError.Visible = false;
            }
        }

        private void tbDbPassword_TextChanged(object sender, EventArgs e)
        {
            if (cbIntegSecurity.Checked)
            {
                if (tbDbPassword.Text == "")
                    tbDbPasswordError.Visible = true;
                else
                    tbDbPasswordError.Visible = false;
            }
        }

        string conStr;
        
        private void saveConection()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\rms_connect";
            File.WriteAllText(path, conStr);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbIntegSecurity.Checked)
            {
                if (tbServer.Text == "")
                    tbServerError.Visible = true;
                else
                    tbServerError.Visible = false;

                if (tbDatabase.Text == "")
                    tbDatabaseError.Visible = true;
                else
                    tbDatabaseError.Visible = false;

                if(tbServerError.Visible || tbDatabaseError.Visible)
                {
                    Main.showMessage("Fields with * are mendatory","error");
                }
                else
                {
                    conStr = "Data Source=" + tbServer.Text + ";Initial Catalog=" + tbDatabase.Text + ";Integrated Security=true;MultipleActiveResultSets=ture;";
                    saveConection();

                    DialogResult dr = MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        Login ls = new Login();
                        ls.ShowDialog();
                        this.Close();
                    }
                }
            }
            else
            {
                if (tbServer.Text == "")
                    tbServerError.Visible = true;
                else
                    tbServerError.Visible = false;

                if (tbDatabase.Text == "")
                    tbDatabaseError.Visible = true;
                else
                    tbDatabaseError.Visible = false;

                if (tbUserID.Text == "")
                    tbUserIdError.Visible = true;
                else
                    tbUserIdError.Visible = false;

                if (tbDbPassword.Text == "")
                    tbDbPasswordError.Visible = true;
                else
                    tbDbPasswordError.Visible = false;

                if(tbServerError.Visible || tbDatabaseError.Visible || tbUserIdError.Visible || tbDbPasswordError.Visible)
                    Main.showMessage("Fields with * are mendatory", "error");
            }
        }
    }
}
