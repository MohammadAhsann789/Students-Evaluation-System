using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Students_Evaluation_System.Utility;
using System.Data.SqlClient;
using System.Configuration;
using Students_Evaluation_System.DatabaseUtility;

namespace Students_Evaluation_System.Controls
{
    public partial class Rubrics : UserControl
    {
        Rubrics_Utility Database = new Rubrics_Utility();
        DataTable Rubrics_DataTable = new DataTable();
        DataTable searched_rubrics = new DataTable();
        DataTable Clos_DataTable = new DataTable();
        int upd_ind = -1;
        bool update_flag = false;
        int selected_value = 0;
        string rubric_details = "";

        public Rubrics(int i)
        {
            InitializeComponent();
        }

        public Rubrics()
        {
            InitializeComponent();
            Filter_By_Combobox.SelectedIndex = 0;
            Theme_Color.Apply_Color(this.Controls);
            Rubrics_DataGridView.ColumnHeadersDefaultCellStyle.BackColor =
                Theme_Color.primary_color;
            Rubrics_DataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Theme_Color.primary_color;
        }

        private void Rubrics_Load(object sender, EventArgs e)
        {
            Load_Rubrics();
            Load_Clos();
        }

        private void Load_Rubrics()
        {
            try
            {
                Rubrics_DataTable = Database.Load_Data();
                Rubrics_DataGridView.DataSource = Rubrics_DataTable;
                Rubrics_DataGridView.Columns["CLO ID"].Visible = false;
                Rubrics_DataGridView.Columns["Rubric ID"].Visible = false;
                Add_Columns_In_Rubrics_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Load_Clos()
        {
            try
            {
                Clos_DataTable = Database.Load_Clos();
                CLOs_Combobox.DisplayMember = "Name";
                CLOs_Combobox.ValueMember = "Id";
                CLOs_Combobox.DataSource = Clos_DataTable;
                if (CLOs_Combobox.Items.Count > 0)
                {
                    CLOs_Combobox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Add_Rubric_Button_Click(object sender, EventArgs e)
        {
            if(Rubric_Details_Textbox.Text.Trim() == "" || 
                CLOs_Combobox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Fill all the Fields!!!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }

            try
            {
                int rubric_id = Database.Insert_Data(Rubric_Details_Textbox.Text.Trim(),
                    Convert.ToInt32(CLOs_Combobox.SelectedValue));
                if (rubric_id > 0)
                {
                    int i = Rubrics_DataTable.Rows.Count;
                    Rubrics_DataTable.Rows.Add();
                    Rubrics_DataTable.Rows[i]["CLO ID"] = CLOs_Combobox.SelectedValue;
                    Rubrics_DataTable.Rows[i]["CLO Name"] = CLOs_Combobox.Text;
                    Rubrics_DataTable.Rows[i]["Rubric ID"] = rubric_id;
                    Rubrics_DataTable.Rows[i]["Rubric Details"] = Rubric_Details_Textbox.Text.Trim();
                    MessageBox.Show("Data Inserted Successfully!!!",
                        "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                }
                else
                {
                    MessageBox.Show("There is something an Error!!!",
                        "Success", MessageBoxButtons.OK,
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

        private void Add_Columns_In_Rubrics_DataGridView()
        {
            DataGridViewImageColumn delete_column = new DataGridViewImageColumn();
            delete_column.Name = "Delete";
            delete_column.HeaderText = "Delete";
            delete_column.Image = new Bitmap(Properties.Resources.Delete_30px_black, 30, 30);
            Rubrics_DataGridView.Columns.Add(delete_column);

            DataGridViewImageColumn update_column = new DataGridViewImageColumn();
            update_column.Name = "Update";
            update_column.HeaderText = "Update";
            update_column.Image = new Bitmap(Properties.Resources.Edit_30px_black, 29, 28);
            Rubrics_DataGridView.Columns.Add(update_column);
        }

        private void Rubrics_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int del_ind = Functions.Get_Actual_Index_From_DataSource(Rubrics_DataTable,
                    "Rubric ID", Rubrics_DataGridView.Rows[e.RowIndex].Cells["Rubric ID"].Value.ToString());
                Delete_Rubric(del_ind);
            }
            else if(e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                update_flag = true;
                upd_ind = Functions.Get_Actual_Index_From_DataSource(Rubrics_DataTable,
                    "Rubric ID", Rubrics_DataGridView.Rows[e.RowIndex].Cells["Rubric ID"].Value.ToString());
                Rubric_Details_Textbox.Text = rubric_details = Rubrics_DataTable.
                    Rows[upd_ind]["Rubric Details"].ToString();
                CLOs_Combobox.SelectedValue = selected_value = Convert.ToInt32(Rubrics_DataTable.
                    Rows[upd_ind]["CLO ID"]);
            }
        }

        private void Delete_Rubric(int del_ind)
        {
            if (MessageBox.Show("Are you sure to Delete Rubric?" +
                "\nIt will delete its related RubricLevel,\n" +
                "Assessment Component, and Student Result too!!!",
                "Error", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                bool is_deleted = Database.Delete_Data(
                Convert.ToInt32(Rubrics_DataTable.Rows[del_ind]["Rubric ID"]));
                if (is_deleted)
                {

                    if (searched_rubrics != null)
                    {
                        int i = Functions.Get_Actual_Index_From_DataSource(searched_rubrics, "Id",
                            Rubrics_DataTable.Rows[del_ind]["Rubric ID"].ToString());
                        if (i != -1)
                        {
                            searched_rubrics.Rows.RemoveAt(i);
                        }
                    }
                    Rubrics_DataTable.Rows.RemoveAt(del_ind);
                    MessageBox.Show("Rubric Deleted Successfully with its related info from\n" +
                        "RubricLevels, AssessmentComponents and StudentResult!!!", "Success", MessageBoxButtons.OK,
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

        private void Update_Rubric()
        {
            if (Rubric_Details_Textbox.Text.Trim() == rubric_details.Trim() &&
                Convert.ToInt32(CLOs_Combobox.SelectedValue) == selected_value)
            {
                MessageBox.Show("Can't Updated!!!\n" +
                    "You didn't make any change", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                bool is_updated = Database.Update_Data(Rubric_Details_Textbox.Text.Trim(),
                    Convert.ToInt32(CLOs_Combobox.SelectedValue),
                    Convert.ToInt32(Rubrics_DataTable.Rows[upd_ind]["Rubric ID"]));
                if (is_updated)
                {
                    update_flag = false;
                    Rubrics_DataTable.Rows[upd_ind]["Rubric Details"] = Rubric_Details_Textbox.Text.Trim();
                    Rubrics_DataTable.Rows[upd_ind]["CLO ID"] = Convert.ToInt32(CLOs_Combobox.SelectedValue);
                    Rubric_Details_Textbox.Text = rubric_details = "";
                    CLOs_Combobox.SelectedIndex = selected_value = 0;
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

        private void Update_Rubric_Button_Click(object sender, EventArgs e)
        {
            if (update_flag == true)
            {
                Update_Rubric();
            }
            else
            {
                MessageBox.Show("Please Select CLO From List!!!", "Error",
                    MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                return;
            }
        }

        private void Search_Textbox_TextChange(object sender, EventArgs e)
        {
            if (Search_Textbox.Text == "")
            {
                Rubrics_DataGridView.DataSource = Rubrics_DataTable;
                return;
            }

            try
            {
                searched_rubrics = Database.Search_Data(Convert.ToInt32(Filter_By_Combobox.SelectedIndex),
                    Search_Textbox.Text);
                Rubrics_DataGridView.DataSource = searched_rubrics;
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
