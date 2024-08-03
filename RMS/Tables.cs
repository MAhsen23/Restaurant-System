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
    public partial class Tables : Sample2

    {
        public Tables()
        {
            InitializeComponent();
        }

        int tableID;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                errorLabelTNo.Visible = true;
            }
            else
            {
                errorLabelTNo.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                errorLabelNumberChairs.Visible = true;
            }
            else
            {
                errorLabelNumberChairs.Visible = false;
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == -1)
            {
                errorLabelTNo.Visible = true;
            }
            else
            {
                errorLabelTNo.Visible = false;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                errorLabelNumberChairs.Visible = true;
            }
            else
            {
                errorLabelNumberChairs.Visible = false;
            }

            if (errorLabelNumberChairs.Visible || errorLabelTNo.Visible)
            {
                Main.showMessage("Fields with * are mandatory", "error");
            }
            else
            {
                if (edit == 0)
                {
                    Insertion.insertTable(int.Parse(comboBox1.SelectedItem.ToString()),int.Parse(comboBox2.SelectedItem.ToString()));
                    Main.resetDisable(leftPanel);
                    Retrieval.getTables(dataGridView1);
                }
                else if (edit == 1)
                {
                    Updation.updateTable(int.Parse(comboBox1.SelectedItem.ToString()), int.Parse(comboBox2.SelectedItem.ToString()), tableID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getTables(dataGridView1);
                }
            }

        }

        public override void btnDelete_Click(object sender, EventArgs e)
        {
            if (delStatus == 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure, you want to delete this Table ? ", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Deletion.deleteTable(tableID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getTables(dataGridView1);
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
                    tableID = int.Parse(row.Cells[1].Value.ToString());
                    comboBox1.Text = row.Cells[2].Value.ToString();
                    comboBox2.Text = row.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            Main.resetDisable(leftPanel);
            Retrieval.getTables(dataGridView1);
        }
    }
}
