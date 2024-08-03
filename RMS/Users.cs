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
    public partial class Users : Sample2
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            string query = "select r_id as [RoleID],r_name as [Role] from Roles";
            Retrieval.loadItems(query, comboBox1, "Role", "RoleID");
            comboBox1.SelectedIndex = -1;
            errorLabelRole.Visible = false;

            Main.resetDisable(leftPanel);
            Retrieval.getUsers(dataGridView1);
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                errorLabelName.Visible = true;
            }
            else
            {
                errorLabelName.Visible = false;
            }
        }

        

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            if (tbAddress.Text == "")
            {
                errorLabelAddress.Visible = true;
            }
            else
            {
                errorLabelAddress.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                errorLabelRole.Visible = true;
            }
            else
            {
                errorLabelRole.Visible = false; 
            }
        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            if (tbPhone.Text == "")
            {
                errorLabelPhone.Visible = true;
            }
            else
            {
                errorLabelPhone.Visible = false;
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                errorLabelUserName.Visible = true;
            }
            else
            {
                errorLabelUserName.Visible = false;
            }
        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            if (tbPass.Text == "")
            {
                errorLabelPass.Visible = true;
            }
            else
            {
                errorLabelPass.Visible = false;
            }
        }


        int userID;
        public override void btnDelete_Click(object sender, EventArgs e)
        {
            if (delStatus == 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure, you want to delete this User ? ", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Deletion.deleteUser(userID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getUsers(dataGridView1);
                }
            }
        }

        
        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                errorLabelName.Visible = true;
            }
            else
            {
                errorLabelName.Visible = false;
            }

            if (tbPhone.Text == "")
            {
                errorLabelPhone.Visible = true;
            }
            else
            {
                errorLabelPhone.Visible = false;
            }

            if (tbAddress.Text == "")
            {
                errorLabelAddress.Visible = true;
            }
            else
            {
                errorLabelAddress.Visible = false;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                errorLabelRole.Visible = true;
            }
            else
            {
                errorLabelRole.Visible = false;
            }

            if (tbUsername.Text == "")
            {
                errorLabelUserName.Visible = true;
            }
            else
            {
                errorLabelUserName.Visible = false;
            }

            if (tbPass.Text == "")
            {
                errorLabelPass.Visible = true;
            }
            else
            {
                errorLabelPass.Visible = false;
            }

            if (errorLabelRole.Visible || errorLabelPhone.Visible || errorLabelName.Visible || errorLabelAddress.Visible || errorLabelPass.Visible || errorLabelUserName.Visible)
            {
                Main.showMessage("Fields with * are mandatory", "error");
            }
            else
            {
                if (edit == 0)
                {
                    Insertion.insertUser(tbName.Text.ToUpper(),tbUsername.Text,tbPass.Text,tbPhone.Text,tbAddress.Text,int.Parse(comboBox1.SelectedValue.ToString()));
                    Main.resetDisable(leftPanel);
                    Retrieval.getUsers(dataGridView1);
                }
                else if(edit == 1)
                {
                    Updation.updateUser(tbName.Text.ToUpper(), tbPhone.Text, tbAddress.Text, tbUsername.Text, tbPass.Text, int.Parse(comboBox1.SelectedValue.ToString()), userID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getUsers(dataGridView1);
                }
            }

        }

        private void cell_click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    edit = 1;
                    delStatus = 1;
                    Main.DisableControls(leftPanel);
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    userID = int.Parse(row.Cells[0].Value.ToString());
                    tbName.Text = row.Cells[1].Value.ToString();
                    tbPhone.Text = row.Cells[5].Value.ToString();
                    tbAddress.Text = row.Cells[6].Value.ToString();
                    tbUsername.Text = row.Cells[2].Value.ToString();
                    tbPass.Text = row.Cells[3].Value.ToString();
                    comboBox1.Text = row.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }
    }
}
