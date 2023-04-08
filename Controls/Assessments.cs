using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Students_Evaluation_System.DatabaseUtility;
using Students_Evaluation_System.Utility;
using Students_Evaluation_System.Forms;

namespace Students_Evaluation_System.Controls
{
    public partial class Assessments : UserControl
    {
        Assessment_Utility Database = new Assessment_Utility();
        DataTable Assessments_DataTable = new DataTable();
        DataTable Searched_Data_DataTable = new DataTable();
        int total_marks = -1, total_wightage = -1;
        string assessment_title = "";
        int upd_ind = -1;
        bool update_flag = false;
        Runner runner;

        public Assessments(int i)
        {
            InitializeComponent();
        }

        public Assessments(Runner runner)
        {
            InitializeComponent();
            this.runner = runner;
            Theme_Color.Apply_Color(this.Controls);
            Filter_By_Combobox.SelectedIndex = 0;
            Assessments_DataGridView.ColumnHeadersDefaultCellStyle.BackColor = Theme_Color.primary_color;
            Assessments_DataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme_Color.primary_color;
            Assessments_DataGridView.ColumnHeadersHeight = 52;
        }

        private void Assessments_Load(object sender, EventArgs e)
        {
            try
            {
                Assessments_DataTable = Database.Load_Data();
                Assessments_DataGridView.DataSource = Assessments_DataTable;
                Assessments_DataGridView.Columns["Assessment ID"].Visible = false;
                Add_Columns_In_Assessments_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Add_Columns_In_Assessments_DataGridView()
        {
            DataGridViewImageColumn delete_column = new DataGridViewImageColumn();
            delete_column.Name = "Delete";
            delete_column.HeaderText = "Delete";
            delete_column.Image = new Bitmap(Properties.Resources.Delete_30px_black, 30, 30);
            Assessments_DataGridView.Columns.Add(delete_column);

            DataGridViewImageColumn update_column = new DataGridViewImageColumn();
            update_column.Name = "Update";
            update_column.HeaderText = "Update";
            update_column.Image = new Bitmap(Properties.Resources.Edit_30px_black, 29, 28);
            Assessments_DataGridView.Columns.Add(update_column);

            DataGridViewImageColumn assessment_components = new DataGridViewImageColumn();
            assessment_components.Name = "Assessment_Components";
            assessment_components.HeaderText = "Manage Assessment Components";
            assessment_components.Image = new Bitmap(Properties.Resources.add_node_30px_black, 37, 32);
            Assessments_DataGridView.Columns.Add(assessment_components);
        }

        private void Assessments_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int del_ind = Functions.Get_Actual_Index_From_DataSource(Assessments_DataTable,
                    "Assessment ID",
                    Assessments_DataGridView.Rows[e.RowIndex].Cells["Assessment ID"].Value.ToString());
                Delete_Assessment(del_ind);
            }
            else if(e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                update_flag = true;
                upd_ind = Functions.Get_Actual_Index_From_DataSource(Assessments_DataTable,
                    "Assessment ID",
                    Assessments_DataGridView.Rows[e.RowIndex].Cells["Assessment ID"].Value.ToString());

                Assessment_Title_Textbox.Text = assessment_title = Assessments_DataTable.Rows[upd_ind]["Assessment Title"].ToString();
                
                Total_Marks_Textbox.Text = Assessments_DataTable.Rows[upd_ind]["Assessment Marks"].ToString();
                total_marks = Convert.ToInt32(Assessments_DataTable.Rows[upd_ind]["Assessment Marks"]);

                Total_Weightage_Textbox.Text = Assessments_DataTable.Rows[upd_ind]["Assessment Weightage"].ToString();
                total_wightage = Convert.ToInt32(Assessments_DataTable.Rows[upd_ind]["Assessment Weightage"]);
            }
            else if (e.ColumnIndex == 2 && e.RowIndex != -1)
            {
                int row_ind = Functions.Get_Actual_Index_From_DataSource(Assessments_DataTable,
                    "Assessment ID",
                    Assessments_DataGridView.Rows[e.RowIndex].Cells["Assessment ID"].Value.ToString());
                
                runner.Controls_Panel.Controls.Clear();
                Assessment_Components assessment_component = new Assessment_Components(runner,
                    Convert.ToInt32(Assessments_DataTable.Rows[row_ind]["Assessment ID"]),
                    Assessments_DataTable.Rows[row_ind]["Assessment Title"].ToString(),
                    Convert.ToDateTime(Assessments_DataTable.Rows[row_ind]["Created Date"]).ToString("dddd, MMMM dd, yyyy"));
                assessment_component.Dock = DockStyle.Fill;
                runner.Controls_Panel.Controls.Add(assessment_component);
            }
        }

        private void Update_Assessment_Button_Click(object sender, EventArgs e)
        {
            if (update_flag == true)
            {
                Update_Assessment();
            }
            else
            {
                MessageBox.Show("Please Select Assessment From List!!!", "Error",
                    MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }

        private void Update_Assessment()
        {
            if (assessment_title == Assessment_Title_Textbox.Text.Trim() &&
                total_marks.ToString() == Total_Marks_Textbox.Text.Trim() &&
                total_wightage.ToString() == Total_Weightage_Textbox.Text.Trim())
            {
                MessageBox.Show("Cannot Updated!!!\n" +
                    "Beacause you didn't made any change", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }

            try
            {
                bool is_updated = Database.Update_Data(Assessment_Title_Textbox.Text.Trim(),
                    Convert.ToInt32(Total_Marks_Textbox.Text.Trim()),
                    Convert.ToInt32(Total_Weightage_Textbox.Text.Trim()),
                    Convert.ToInt32(Assessments_DataTable.Rows[upd_ind]["Assessment ID"]));
                if (is_updated)
                {
                    Assessments_DataTable.Rows[upd_ind]["Assessment Title"] = Assessment_Title_Textbox.Text.Trim();
                    Assessments_DataTable.Rows[upd_ind]["Assessment Marks"] = Convert.ToInt32(Total_Marks_Textbox.Text.Trim());
                    Assessments_DataTable.Rows[upd_ind]["Assessment Weightage"] = Convert.ToInt32(Total_Weightage_Textbox.Text.Trim());
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
            Assessment_Title_Textbox.Text = assessment_title = "";

            Total_Marks_Textbox.Text = "";
            total_marks = -1;

            Total_Weightage_Textbox.Text = "";
            total_wightage = -1;
        }

        private void Create_Assessment_Button_Click(object sender, EventArgs e)
        {
            if(Assessment_Title_Textbox.Text.Trim() == "" || 
                Total_Marks_Textbox.Text.Trim() == "" || 
                Total_Weightage_Textbox.Text.Trim() == "")
            {
                MessageBox.Show("Please Provide all the Fields!!!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }

            try 
            {
                int inserted_id = Database.Insert_Data(Assessment_Title_Textbox.Text.Trim(),
                    Convert.ToInt32(Total_Marks_Textbox.Text.Trim()),
                    Convert.ToInt32(Total_Weightage_Textbox.Text.Trim()));
                if(inserted_id != -1)
                {
                    int i = Assessments_DataTable.Rows.Count;
                    Assessments_DataTable.Rows.Add();
                    Assessments_DataTable.Rows[i]["Assessment ID"] = inserted_id;
                    Assessments_DataTable.Rows[i]["Assessment Title"] = Assessment_Title_Textbox.Text.Trim();
                    Assessments_DataTable.Rows[i]["Assessment Marks"] = Total_Marks_Textbox.Text.Trim();
                    Assessments_DataTable.Rows[i]["Assessment Weightage"] = Total_Weightage_Textbox.Text.Trim();
                    Assessments_DataTable.Rows[i]["Created Date"] = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
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

        private void Search_Textbox_TextChange(object sender, EventArgs e)
        {
            if (Search_Textbox.Text == "")
            {
                Assessments_DataGridView.DataSource = Assessments_DataTable;
                return;
            }

            try
            {
                Searched_Data_DataTable = Database.Search_Data(Convert.ToInt32(Filter_By_Combobox.SelectedIndex),
                    Search_Textbox.Text);
                Assessments_DataGridView.DataSource = Searched_Data_DataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }

        private void Delete_Assessment(int del_ind)
        {
            if (MessageBox.Show("Are you sure to Delete Assessment?" +
                "\nIt will delete its related Assessment Components and\n" +
                "Assessment Components From Student Result too!!!",
                "Error", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                bool is_deleted = Database.Delete_Data(
                Convert.ToInt32(Assessments_DataTable.Rows[del_ind]["Assessment ID"]));
                if (is_deleted)
                {

                    if (Searched_Data_DataTable != null)
                    {
                        int i = Functions.Get_Actual_Index_From_DataSource(Searched_Data_DataTable, "Assessment ID",
                            Assessments_DataTable.Rows[del_ind]["Assessment ID"].ToString());
                        if (i != -1)
                        {
                            Searched_Data_DataTable.Rows.RemoveAt(i);
                        }
                    }
                    Assessments_DataTable.Rows.RemoveAt(del_ind);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }
    }
}
