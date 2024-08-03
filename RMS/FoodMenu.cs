using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using RMS.Properties;

namespace RMS
{
    public partial class FoodMenu : Sample2
    {
        public FoodMenu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            string query = "select c_id as [categoryID],c_name as [categoryName] from Category";
            Retrieval.loadItems(query, comboBox1, "categoryName", "categoryID");
            comboBox1.SelectedIndex = -1;
            errorLabelSelectCategory.Visible = false;
            comboBox2.Items.Add("AVAILABLE");
            comboBox2.Items.Add("NOT-AVAILABLE");

            Main.resetDisable(leftPanel);
            Retrieval.getMenuItems(dataGridView1);
        }

        private void tbMenuItem_TextChanged(object sender, EventArgs e)
        {
            if (tbMenuItem.Text == "")
            {
                errorLabelMenuItem.Visible = true;
            }
            else
            {
                errorLabelMenuItem.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                errorLabelSelectCategory.Visible = true;
            }
            else
            {
                errorLabelSelectCategory.Visible = false;
            }
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbPrice.Text == "")
            {
                errorLabelPrice.Visible = true;
            }
            else
            {
                errorLabelPrice.Visible = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                errorLabelStatus.Visible = true;
            }
            else
            {
                errorLabelStatus.Visible = false;
            }
        }

        int menuID;
        public override void btnDelete_Click(object sender, EventArgs e)
        {
            if (delStatus == 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure, you want to delete this Menu Item ? ", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Deletion.deleteMenuItem(menuID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getMenuItems(dataGridView1);
                }
            }
        }


        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                errorLabelSelectCategory.Visible = true;
            }
            else
            {
                errorLabelSelectCategory.Visible = false;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                errorLabelStatus.Visible = true;
            }
            else
            {
                errorLabelStatus.Visible = false;
            }

            if (tbPrice.Text == "")
            {
                errorLabelPrice.Visible = true;
            }
            else
            {
                errorLabelPrice.Visible = false;
            }

            if (tbMenuItem.Text == "")
            {
                errorLabelMenuItem.Visible = true;
            }
            else
            {
                errorLabelMenuItem.Visible = false;
            }
            string path;
            string imgPath = string.Empty;
            if (errorLabelStatus.Visible || errorLabelPrice.Visible || errorLabelSelectCategory.Visible || errorLabelMenuItem.Visible )
            {
                Main.showMessage("Fields with * are mandatory", "error");
            }
            else
            {
                if (edit == 0)
                {
                    try
                    {
                        bool fileExist = false;
                        if (btnBrowse == 1)
                        {
                            path = Path.Combine(location, tbMenuItem.Text + ".jpg");
                            imgPath = "\\Images\\" + tbMenuItem.Text+".jpg";
                        }
                        else
                        {
                            
                            path = Path.Combine(location, "default.jpg");
                            if (File.Exists(path))
                            {
                                fileExist = true;
                            }
                            else
                            {
                                fileExist = false;
                            }
                        }
                        if (imgPath.Equals(string.Empty))
                        {
                            imgPath = imgPath = "\\Images\\default.jpg";
                        }

                        Insertion.insertMenuItem(tbMenuItem.Text.ToUpper(), int.Parse(comboBox1.SelectedValue.ToString()), (float.Parse(tbPrice.Text)), comboBox2.SelectedItem.ToString(),imgPath);
                        if (fileExist == false)
                        {
                            Image image = pictureBox3.Image;
                            image.Save(path);
                        }
                        
                        Main.resetDisable(leftPanel);
                        pictureBox3.Image = Resources.catering_icon_7__1_;
                        pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
                        Retrieval.getMenuItems(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        Main.showMessage(ex.Message, "error");
                    }
                }
                else if (edit == 1)
                {
                    Updation.updateMenuItem(tbMenuItem.Text.ToUpper(), int.Parse(comboBox1.SelectedValue.ToString()), (float.Parse(tbPrice.Text)), comboBox2.SelectedItem.ToString(), menuID);
                    Main.resetDisable(leftPanel);
                    Retrieval.getMenuItems(dataGridView1);
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
                    menuID = int.Parse(row.Cells[1].Value.ToString());
                    tbMenuItem.Text = row.Cells[2].Value.ToString();
                    comboBox1.Text = row.Cells[5].Value.ToString();
                    tbPrice.Text = row.Cells[3].Value.ToString();
                    comboBox2.Text = row.Cells[6].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Main.showMessage(ex.Message, "error");
            }
        }

        string location= Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10))+"\\Images";
        
        int btnBrowse = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbMenuItem.Text == "") { errorLabelMenuItem.Visible = true; } else { errorLabelMenuItem.Visible = false; }

            if (errorLabelMenuItem.Visible)
            {
                Main.showMessage("Fields with * are mandatory", "error");
            }
            else
            {
                try
                {
                    DialogResult dr = openFileDialog1.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
                        pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                        btnBrowse = 1;
                    }

                }
                catch (Exception ex)
                {
                    Main.showMessage(ex.Message, "error");
                }
            }
        }


        public override void btnAdd_Click(object sender, EventArgs e)
        {
            edit = 0;
            Main.resetEnable(leftPanel);
            pictureBox3.Image = Resources.catering_icon_7__1_;
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            delStatus = 0;

        }
    }
}
