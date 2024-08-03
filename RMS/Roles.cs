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
    public partial class Roles : Sample2
    {
        public Roles()
        {
            InitializeComponent();
        }

        private void tbRole_TextChanged(object sender, EventArgs e)
        {
            if(tbRole.Text == "")
            {
                errorLabelRole.Visible = true;

            }
            else
            {
                errorLabelRole.Visible = false;
            }
        }

        
        public override void btnDelete_Click(object sender, EventArgs e)
        {
            if (delStatus == 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure, you want to delete this role ? ", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Deletion.deleteRole(roleID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getRoles(dataGridView1);
                }
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (tbRole.Text == "") { errorLabelRole.Visible = true; } else { errorLabelRole.Visible = false; }
            if (errorLabelRole.Visible)
            {
                Main.showMessage("Fields with * are mandatory", "error");
            }
            else
            {
                if (edit == 0)
                {
                    Insertion.insertRole(tbRole.Text.ToUpper());
                    Main.resetDisable(leftPanel);
                    Retrieval.getRoles(dataGridView1);
                }
                else if(edit == 1)
                {
                    Updation.updateRole(tbRole.Text.ToUpper(), roleID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getRoles(dataGridView1);
                }
            } 
        }

        int roleID;
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
                    roleID = int.Parse(row.Cells[1].Value.ToString());
                    tbRole.Text = row.Cells[2].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            Main.resetDisable(leftPanel);
            Retrieval.getRoles(dataGridView1);
        }
    }
}
