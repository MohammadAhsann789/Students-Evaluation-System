using Students_Evaluation_System.Forms;
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

namespace Students_Evaluation_System.Controls
{
    public partial class Assessment_Components : UserControl
    {
        Runner form;
        Assessment_Components_Utility Database = new Assessment_Components_Utility();
        DataTable Assessment_Components_DataTable = new DataTable();
        DataTable Component_Rubrics_DataTable = new DataTable();
        DataTable Other_Assessments_DataTable = new DataTable();
        DataTable Searched_Data_DataTable = new DataTable();
        int assessment_id = -1;
        bool update_flag = false;
        int upd_ind = -1;
        string comp_name = "";
        int comp_marks = -1;
        int selected_rubric = -1;

        public Assessment_Components(Runner form, int assessment_id, string assessment_title,
            string assessment_date)
        {
            InitializeComponent();
            this.assessment_id = assessment_id;
            Assessment_Title_Label.Text = assessment_title;
            Created_On_Label.Text = assessment_date;
            Filter_By_Combobox.SelectedIndex = 0;
            this.form = form;
            form.msg = "Open";
            form.reserved_control = form.assessment;
            Theme_Color.Apply_Color(this.Controls);
            Assessment_Components_DataGridView.ColumnHeadersDefaultCellStyle.BackColor = Theme_Color.primary_color;
            Assessment_Components_DataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme_Color.primary_color;
            Assessment_Components_DataGridView.ColumnHeadersHeight = 52;
        }

        private void Assessment_Components_Load(object sender, EventArgs e)
        {
            Load_Assessment_Components();
            Load_Component_Rubrics_Combobox();
            Load_Other_Assessments_Combobox();
        }

        private void Load_Assessment_Components()
        {
            try
            {
                Assessment_Components_DataTable = Database.Load_Data(assessment_id);
                Assessment_Components_DataGridView.DataSource = Assessment_Components_DataTable;
                Assessment_Components_DataGridView.Columns["Component ID"].Visible = false;
                Assessment_Components_DataGridView.Columns["Component Rubric ID"].Visible = false;
                Add_Columns_In_Assessments_Components_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Load_Component_Rubrics_Combobox()
        {
            try
            {
                Component_Rubrics_DataTable = Database.Load_Rubrics();
                Component_Rubrics_Combobox.DisplayMember = "Details";
                Component_Rubrics_Combobox.ValueMember = "Id";
                Component_Rubrics_Combobox.DataSource = Component_Rubrics_DataTable;
                if(Component_Rubrics_Combobox.Items.Count > 0)
                {
                    Component_Rubrics_Combobox.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Load_Other_Assessments_Combobox()
        {
            try
            {
                Other_Assessments_DataTable = Database.Load_Other_Assessments(assessment_id);
                Other_Assessments_Combobox.DisplayMember = "Title";
                Other_Assessments_Combobox.ValueMember = "Id";
                Other_Assessments_Combobox.DataSource = Other_Assessments_DataTable;
                Other_Assessments_Combobox.Text = "--Select--";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Add_Columns_In_Assessments_Components_DataGridView()
        {
            DataGridViewImageColumn delete_column = new DataGridViewImageColumn();
            delete_column.Name = "Delete";
            delete_column.HeaderText = "Delete";
            delete_column.Image = new Bitmap(Properties.Resources.Delete_30px_black, 30, 30);
            Assessment_Components_DataGridView.Columns.Add(delete_column);

            DataGridViewImageColumn update_column = new DataGridViewImageColumn();
            update_column.Name = "Update";
            update_column.HeaderText = "Update";
            update_column.Image = new Bitmap(Properties.Resources.Edit_30px_black, 29, 28);
            Assessment_Components_DataGridView.Columns.Add(update_column);
        }

        private void Add_Component_Button_Click(object sender, EventArgs e)
        {
            if (Component_Name_Textbox.Text.Trim() == "" ||
                Component_Marks_Textbox.Text.Trim() == "" ||
                Component_Rubrics_Combobox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Provide all the Fields!!!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }

            try
            {
                int inserted_id = Database.Insert_Data(Component_Name_Textbox.Text.Trim(),
                    Convert.ToInt32(Component_Rubrics_Combobox.SelectedValue),
                    Convert.ToInt32(Component_Marks_Textbox.Text.Trim()),
                    DateTime.Now, DateTime.Now, assessment_id);
                if (inserted_id != -1)
                {
                    int i = Assessment_Components_DataTable.Rows.Count;
                    Assessment_Components_DataTable.Rows.Add();
                    Assessment_Components_DataTable.Rows[i]["Component ID"] = inserted_id;
                    Assessment_Components_DataTable.Rows[i]["Component Name"] = Component_Name_Textbox.Text.Trim();
                    Assessment_Components_DataTable.Rows[i]["Component Marks"] = Component_Marks_Textbox.Text.Trim();
                    Assessment_Components_DataTable.Rows[i]["Created Date"] = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
                    Assessment_Components_DataTable.Rows[i]["Updated Date"] = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
                    Assessment_Components_DataTable.Rows[i]["Component Rubric ID"] = Component_Rubrics_Combobox.SelectedValue;
                    Assessment_Components_DataTable.Rows[i]["Rubric Details"] = Component_Rubrics_Combobox.Text;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Assessment_Components_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int del_ind = Functions.Get_Actual_Index_From_DataSource(Assessment_Components_DataTable,
                    "Component ID",
                    Assessment_Components_DataGridView.Rows[e.RowIndex].Cells["Component ID"].Value.ToString());
                Delete_Assessment_Component(del_ind);
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                update_flag = true;
                upd_ind = Functions.Get_Actual_Index_From_DataSource(Assessment_Components_DataTable,
                    "Component ID",
                    Assessment_Components_DataGridView.Rows[e.RowIndex].Cells["Component ID"].Value.ToString());

                Component_Name_Textbox.Text = comp_name = Assessment_Components_DataTable.Rows[upd_ind]["Component Name"].ToString();

                Component_Marks_Textbox.Text = Assessment_Components_DataTable.Rows[upd_ind]["Component Marks"].ToString();
                comp_marks = Convert.ToInt32(Assessment_Components_DataTable.Rows[upd_ind]["Component Marks"]);

                Component_Rubrics_Combobox.SelectedValue = selected_rubric = Convert.ToInt32(Assessment_Components_DataTable.Rows[upd_ind]["Component Rubric ID"]);
            }
        }

        private void Delete_Assessment_Component(int del_ind)
        {
            if (MessageBox.Show("Are you sure to Delete Assessment Component?" +
                "\nIt will be deleted from Student Result too!!!",
                 "Error", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                bool is_deleted = Database.Delete_Data(
                Convert.ToInt32(Assessment_Components_DataTable.Rows[del_ind]["Component ID"]));
                if (is_deleted)
                {

                    if (Searched_Data_DataTable != null)
                    {
                        int i = Functions.Get_Actual_Index_From_DataSource(Searched_Data_DataTable, "Assessment ID",
                            Assessment_Components_DataTable.Rows[del_ind]["Component ID"].ToString());
                        if (i != -1)
                        {
                            Searched_Data_DataTable.Rows.RemoveAt(i);
                        }
                    }
                    Assessment_Components_DataTable.Rows.RemoveAt(del_ind);
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
            Component_Name_Textbox.Text = comp_name = "";

            Component_Marks_Textbox.Text = "";
            comp_marks = -1;

            Component_Rubrics_Combobox.SelectedIndex = selected_rubric = 0;
        }

        private void Update_Component_Button_Click(object sender, EventArgs e)
        {
            if (update_flag == true)
            {
                Update_Assessment_Component();
            }
            else
            {
                MessageBox.Show("Please Select Assessment From List!!!", "Error",
                    MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }

        private void Update_Assessment_Component()
        {
            update_flag = false;
            if (comp_name == Component_Name_Textbox.Text.Trim() &&
                comp_marks.ToString() == Component_Marks_Textbox.Text.Trim() &&
                selected_rubric == Convert.ToInt32(Component_Rubrics_Combobox.SelectedValue))
            {
                MessageBox.Show("Cannot Updated!!!\n" +
                    "Beacause you didn't made any change", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }

            try
            {
                bool is_updated = Database.Update_Data(Component_Name_Textbox.Text.Trim(),
                    Convert.ToInt32(Component_Marks_Textbox.Text.Trim()),
                    Convert.ToInt32(Component_Rubrics_Combobox.SelectedValue),
                    Convert.ToInt32(Assessment_Components_DataTable.Rows[upd_ind]["Component ID"]));
                if (is_updated)
                {
                    Assessment_Components_DataTable.Rows[upd_ind]["Component Name"] = Component_Name_Textbox.Text.Trim();
                    Assessment_Components_DataTable.Rows[upd_ind]["Component Marks"] = Convert.ToInt32(Component_Marks_Textbox.Text.Trim());
                    Assessment_Components_DataTable.Rows[upd_ind]["Component Rubric ID"] = Convert.ToInt32(Component_Rubrics_Combobox.SelectedValue);
                    Assessment_Components_DataTable.Rows[upd_ind]["Rubric Details"] = Component_Rubrics_Combobox.Text;
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

        private void Assign_To_Button_Click(object sender, EventArgs e)
        {
            if (Component_Name_Textbox.Text.Trim() == "" ||
                Component_Marks_Textbox.Text.Trim() == "" ||
                Component_Rubrics_Combobox.SelectedIndex < 0)
            {
                MessageBox.Show("Please Provide all the Fields!!!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }

            try
            {
                int inserted_id = Database.Insert_Data(Component_Name_Textbox.Text.Trim(),
                    Convert.ToInt32(Component_Rubrics_Combobox.SelectedValue),
                    Convert.ToInt32(Component_Marks_Textbox.Text.Trim()),
                    DateTime.Now, DateTime.Now, Convert.ToInt32(Other_Assessments_Combobox.SelectedValue));

                MessageBox.Show("Component has been Assigned To Component: " +
                    Other_Assessments_Combobox.Text + " Sucessfully!!!",
                    "Success", MessageBoxButtons.OK,
                   MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.RightAlign);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Filter_By_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if(Filter_By_Combobox.SelectedIndex == 3 || Filter_By_Combobox.SelectedIndex == 4)
            {
                Search_Textbox.Visible = false;
                Search_Date_DatePicker.Visible = true;
            }
            else
            {
                Search_Textbox.Visible = true;
                Search_Date_DatePicker.Visible = false;
            }*/
        }

        private void Search_Textbox_TextChange_1(object sender, EventArgs e)
        {
            if (Search_Textbox.Text == "")
            {
                Assessment_Components_DataGridView.DataSource = Assessment_Components_DataTable;
                return;
            }

            try
            {
                Searched_Data_DataTable = Database.Search_Data(Convert.ToInt32(Filter_By_Combobox.SelectedIndex),
                    Search_Textbox.Text, assessment_id);
                Assessment_Components_DataGridView.DataSource = Searched_Data_DataTable;
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
