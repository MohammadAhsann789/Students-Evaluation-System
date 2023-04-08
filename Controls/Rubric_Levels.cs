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
using Students_Evaluation_System.Utility;
using Students_Evaluation_System.DatabaseUtility;
using System.Configuration;

namespace Students_Evaluation_System.Controls
{
    public partial class Rubric_Levels : UserControl
    {
        Rubric_Levels_Utility Database = new Rubric_Levels_Utility();
        DataTable Rubric_Levels_DataTable = new DataTable();
        DataTable Searched_Data_DataTable = new DataTable();
        DataTable Rubrics_DataTable = new DataTable();
        int upd_ind = -1;
        bool update_flag = false;
        string rubric_level_details = "";
        int selected_rubric = -1;
        int rubric_meas_level = -1;

        public Rubric_Levels(int i)
        {
            InitializeComponent();
        }

        public Rubric_Levels()
        {
            InitializeComponent();
            Rubric_Combobox.SelectedIndex = -1;
            Filter_By_Combobox.SelectedIndex = 0;
            Rubric_Levels_DataGridView.ColumnHeadersDefaultCellStyle.BackColor = Theme_Color.primary_color;
            Rubric_Levels_DataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme_Color.primary_color;
            Theme_Color.Apply_Color(this.Controls);
        }

        private void Rubric_Levels_Load(object sender, EventArgs e)
        {
            Load_Rubric_Levels();
            Load_Rubrics();
        }

        private void Load_Rubric_Levels()
        {
            try
            {
                Rubric_Levels_DataTable = Database.Load_Data();
                Rubric_Levels_DataGridView.DataSource = Rubric_Levels_DataTable;
                Rubric_Levels_DataGridView.Columns["Rubric Level ID"].Visible = false;
                Add_Columns_In_Students_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Add_Columns_In_Students_DataGridView()
        {
            DataGridViewImageColumn delete_column = new DataGridViewImageColumn();
            delete_column.Name = "Delete";
            delete_column.HeaderText = "Delete";
            delete_column.Image = new Bitmap(Properties.Resources.Delete_30px_black, 30, 30);
            Rubric_Levels_DataGridView.Columns.Add(delete_column);

            DataGridViewImageColumn update_column = new DataGridViewImageColumn();
            update_column.Name = "Update";
            update_column.HeaderText = "Update";
            update_column.Image = new Bitmap(Properties.Resources.Edit_30px_black, 29, 28);
            Rubric_Levels_DataGridView.Columns.Add(update_column);
        }

        private void Load_Rubrics()
        {
            try
            {
                Rubrics_DataTable = Database.Load_Rubrics();
                Rubric_Combobox.DisplayMember = "Details";
                Rubric_Combobox.ValueMember = "Id";
                Rubric_Combobox.DataSource = Rubrics_DataTable;
                if (Rubric_Combobox.Items.Count > 0)
                {
                    Rubric_Combobox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Add_Rubric_Level_Button_Click(object sender, EventArgs e)
        {
            if (Rubric_Levels_Details_Textbox.Text.Trim() == "" ||
                Rubric_Measurement_Level_Textbox.Text.Trim() == "" ||
                Rubric_Combobox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Fill all the Fields!!!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }

            try
            {
                int id = Database.Insert_Data(Rubric_Levels_Details_Textbox.Text.Trim(),
                    Convert.ToInt32(Rubric_Measurement_Level_Textbox.Text.Trim()),
                    Convert.ToInt32(Rubric_Combobox.SelectedValue));
                if(id != -1)
                {
                    int i = Rubric_Levels_DataTable.Rows.Count;
                    Rubric_Levels_DataTable.Rows.Add();
                    Rubric_Levels_DataTable.Rows[i]["Rubric Level ID"] = id;
                    Rubric_Levels_DataTable.Rows[i]["Rubric Details"] = Rubric_Combobox.Text;
                    Rubric_Levels_DataTable.Rows[i]["Rubric ID"] = Rubric_Combobox.SelectedValue;
                    Rubric_Levels_DataTable.Rows[i]["Rubric Level Details"] = Rubric_Levels_Details_Textbox.Text.Trim();
                    Rubric_Levels_DataTable.Rows[i]["Measurement Level"] = Convert.ToInt32(Rubric_Measurement_Level_Textbox.Text.Trim());
                    MessageBox.Show("Data Inserted Successfully!!!",
                        "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                }
                else
                {
                    MessageBox.Show("Some Error has been occurred in" +
                        " System!!!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Rubric_Levels_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int del_ind = Functions.Get_Actual_Index_From_DataSource(Rubric_Levels_DataTable,
                    "Rubric Level ID",
                    Rubric_Levels_DataGridView.Rows[e.RowIndex].Cells["Rubric Level ID"].Value.ToString());
                Delete_Rubric_Level(del_ind);
            }
            else if(e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                update_flag = true;
                upd_ind = Functions.Get_Actual_Index_From_DataSource(Rubric_Levels_DataTable,
                    "Rubric Level ID", Rubric_Levels_DataGridView.Rows[e.RowIndex].Cells["Rubric Level ID"].Value.ToString());
                Rubric_Levels_Details_Textbox.Text = rubric_level_details =
                    Rubric_Levels_DataTable.Rows[upd_ind]["Rubric Level Details"].ToString();
                Rubric_Combobox.SelectedValue = selected_rubric = Convert.ToInt32(Rubric_Levels_DataTable.Rows[upd_ind]["Rubric ID"]);
                rubric_meas_level = Convert.ToInt32(Rubric_Levels_DataTable.Rows[upd_ind]["Measurement Level"]);
                Rubric_Measurement_Level_Textbox.Text = rubric_meas_level.ToString();
            }
        }

        private void Update_Level_Button_Click(object sender, EventArgs e)
        {
            if (update_flag == true)
            {
                Update_Rubric_Level();
            }
            else
            {
                MessageBox.Show("Please Select Rubric Level From List!!!", "Error",
                    MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }

        private void Update_Rubric_Level()
        {
            if (rubric_level_details == Rubric_Levels_Details_Textbox.Text.Trim() &&
                rubric_meas_level.ToString() == Rubric_Measurement_Level_Textbox.Text.Trim() &&
                selected_rubric == Convert.ToInt32(Rubric_Combobox.SelectedValue))
            {
                MessageBox.Show("Cannot Updated!!!\n" +
                    "Beacause you didn't made any change", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }

            try
            {
                bool is_updated = Database.Update_Data(Convert.ToInt32(Rubric_Combobox.SelectedValue),
                    Rubric_Levels_Details_Textbox.Text.Trim(),
                    Convert.ToInt32(Rubric_Measurement_Level_Textbox.Text.Trim()),
                    Convert.ToInt32(Rubric_Levels_DataTable.Rows[upd_ind]["Rubric Level ID"]));
                if (is_updated)
                {
                    Rubric_Levels_DataTable.Rows[upd_ind]["Rubric Details"] = Rubric_Combobox.Text;
                    Rubric_Levels_DataTable.Rows[upd_ind]["Rubric ID"] = Convert.ToInt32(Rubric_Combobox.SelectedValue);
                    Rubric_Levels_DataTable.Rows[upd_ind]["Rubric Level Details"] = Rubric_Levels_Details_Textbox.Text.Trim();
                    Rubric_Levels_DataTable.Rows[upd_ind]["Measurement Level"] = Convert.ToInt32(Rubric_Measurement_Level_Textbox.Text.Trim());
                    update_flag = false;
                    Reset_Fields();
                    MessageBox.Show("Updated Successfully!!!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Reset_Fields()
        {
            Rubric_Levels_Details_Textbox.Text = rubric_level_details = "";

            Rubric_Measurement_Level_Textbox.Text = "";
            rubric_meas_level = -1;
            
            Rubric_Combobox.SelectedIndex = 0;
            selected_rubric = 0;
        }

        private void Search_Textbox_TextChange(object sender, EventArgs e)
        {
            if (Search_Textbox.Text == "")
            {
                Rubric_Levels_DataGridView.DataSource = Rubric_Levels_DataTable;
                return;
            }

            try
            {
                Searched_Data_DataTable = Database.Search_Data(Convert.ToInt32(Filter_By_Combobox.SelectedIndex),
                    Search_Textbox.Text);
                Rubric_Levels_DataGridView.DataSource = Searched_Data_DataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }

        private void Delete_Rubric_Level(int del_ind)
        {
            if (MessageBox.Show("Are you sure to Delete Rubric Level?" +
                "\nIt will delete its related RubricLevel Component\n" +
                "From Student Result too!!!",
                "Error", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                bool is_deleted = Database.Delete_Data(
                Convert.ToInt32(Rubric_Levels_DataTable.Rows[del_ind]["Rubric Level ID"]));
                if (is_deleted)
                {

                    if (Searched_Data_DataTable != null)
                    {
                        int i = Functions.Get_Actual_Index_From_DataSource(Searched_Data_DataTable, "Rubric Level ID",
                            Rubric_Levels_DataTable.Rows[del_ind]["Rubric Level ID"].ToString());
                        if (i != -1)
                        {
                            Searched_Data_DataTable.Rows.RemoveAt(i);
                        }
                    }
                    Rubric_Levels_DataTable.Rows.RemoveAt(del_ind);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }
    }
}
