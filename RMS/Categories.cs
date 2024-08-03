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
    public partial class Categories : Sample2
    {
        public Categories()
        {
            InitializeComponent();
        }

        int categoryID;
        private void tbCategory_TextChanged(object sender, EventArgs e)
        {
            if (tbCategory.Text == "")
            {
                errorLabelCategory.Visible = true;
            }
            else
            {
                errorLabelCategory.Visible = false;
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {

            if (tbCategory.Text == "")
            {
                errorLabelCategory.Visible = true;
            }
            else
            {
                errorLabelCategory.Visible = false;
            }

            if (errorLabelCategory.Visible)
            {
                Main.showMessage("Fields with * are mandatory", "error");
            }
            else
            {
                if (edit == 0)
                {

                    Insertion.insertCategory(tbCategory.Text.ToUpper());
                    Main.resetDisable(leftPanel);
                    Retrieval.getCategories(dataGridView1);
                }
                else if (edit == 1)
                {
                    Updation.updateCategory(tbCategory.Text.ToUpper(),categoryID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getCategories(dataGridView1);
                }
            }
        }


        public override void btnDelete_Click(object sender, EventArgs e)
        {
            if (delStatus == 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure, you want to delete this Category ? ", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Deletion.deleteCategory(categoryID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getCategories(dataGridView1);
                }
            }
        }

        

        private void Categories_Load(object sender, EventArgs e)
        {
            Main.resetDisable(leftPanel);
            Retrieval.getCategories(dataGridView1);
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
                    categoryID = int.Parse(row.Cells[1].Value.ToString());
                    tbCategory.Text = row.Cells[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }
    }
}
