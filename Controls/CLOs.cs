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
using System.Configuration;
using Students_Evaluation_System.Utility;
using Students_Evaluation_System.DatabaseUtility;

namespace Students_Evaluation_System.Controls
{
    public partial class CLOs : UserControl
    {
        CLOs_Utility Database = new CLOs_Utility();
        DataTable CLOs_DataTable = new DataTable();
        DataTable searched_data = new DataTable();
        string clo_name = "";
        int upd_ind = -1;
        bool update_flag = false;

        public CLOs(int i)
        {
            InitializeComponent();
        }

        public CLOs()
        {
            InitializeComponent();
            Filter_By_Combobox.SelectedIndex = 0;
            Theme_Color.Apply_Color(this.Controls);
            CLOs_DataGridView.ColumnHeadersDefaultCellStyle.BackColor = 
                Theme_Color.primary_color;
            CLOs_DataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Theme_Color.primary_color;
        }

        private void CLOs_Load(object sender, EventArgs e)
        {
            Load_CLOs();
        }

        private void Load_CLOs()
        {
            try
            {
                CLOs_DataTable = Database.Load_Data();
                CLOs_DataGridView.DataSource = CLOs_DataTable;
                CLOs_DataGridView.Columns["Id"].Visible = false;
                Add_Columns_In_Students_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Add_CLO_Button_Click(object sender, EventArgs e)
        {
            if (CLO_Name_Textbox.Text.Trim() == "")
            {
                MessageBox.Show("Enter all the fields!!!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }

            try
            {
                string name = CLO_Name_Textbox.Text.Trim();
                string date = Convert.ToDateTime(CLO_Date_Created_DatePicker.Value).ToShortDateString();
                int clo_id = Database.Insert_Data(name, date);
                if (clo_id != -1)
                {
                    int i = CLOs_DataTable.Rows.Count;
                    CLOs_DataTable.Rows.Add();
                    CLOs_DataTable.Rows[i]["Id"] = clo_id;
                    CLOs_DataTable.Rows[i]["CLO Name"] = name;
                    CLOs_DataTable.Rows[i]["CLO Created Date"] = Convert.ToDateTime(date).ToString("dddd, MMMM dd, yyyy");
                    CLOs_DataTable.Rows[i]["CLO Updated Date"] = Convert.ToDateTime(date).ToString("dddd, MMMM dd, yyyy");
                    MessageBox.Show(CLOs_DataTable.Rows[i]["Id"].ToString());
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

        private void Add_Columns_In_Students_DataGridView()
        {
            DataGridViewImageColumn delete_column = new DataGridViewImageColumn();
            delete_column.Name = "Delete";
            delete_column.HeaderText = "Delete";
            delete_column.Image = new Bitmap(Properties.Resources.Delete_30px_black, 30, 30);
            CLOs_DataGridView.Columns.Add(delete_column);

            DataGridViewImageColumn update_column = new DataGridViewImageColumn();
            update_column.Name = "Update";
            update_column.HeaderText = "Update";
            update_column.Image = new Bitmap(Properties.Resources.Edit_30px_black, 29, 28);
            CLOs_DataGridView.Columns.Add(update_column);
        }

        private void CLOs_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int del_ind = Functions.Get_Actual_Index_From_DataSource(CLOs_DataTable,
                    "Id", CLOs_DataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                Delete_CLO(del_ind);
            }
            else if(e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                update_flag = true;
                upd_ind = Functions.Get_Actual_Index_From_DataSource(CLOs_DataTable,
                    "Id", CLOs_DataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                CLO_Name_Textbox.Text = clo_name = CLOs_DataTable.Rows[upd_ind]["CLO Name"].ToString();
            }
        }

        private void Delete_CLO(int del_ind)
        {
            if (MessageBox.Show("Are you sure to Delete CLO?" +
                "\nIt will delete its related Rubric, RubricLevel,\n" +
                "Assessment Component, and Student Result too!!!",
                "Error", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                bool is_deleted = Database.Delete_Data(
                Convert.ToInt32(CLOs_DataTable.Rows[del_ind]["Id"]));
                if (is_deleted)
                {

                    if (searched_data != null)
                    {
                        int i = Functions.Get_Actual_Index_From_DataSource(searched_data, "Id",
                            CLOs_DataTable.Rows[del_ind]["Id"].ToString());
                        if (i != -1)
                        {
                            searched_data.Rows.RemoveAt(i);
                        }
                    }
                    CLOs_DataTable.Rows.RemoveAt(del_ind);
                    /*MessageBox.Show("Clo Deleted Successfully with its related info from\n" +
                        "Rubric, RubricLevels, AssessmentComponents and StudentResult!!!", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);*/
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Update_CLO()
        {
            if(clo_name == CLO_Name_Textbox.Text.Trim())
            {
                MessageBox.Show("Cannot Updated!!!\n" +
                    "Beacause you didn't made any change", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }

            try
            {
                bool is_updated = Database.Update_Data(CLO_Name_Textbox.Text.Trim(),
                    DateTime.Now.ToShortDateString(), 
                    Convert.ToInt32(CLOs_DataTable.Rows[upd_ind]["Id"]));
                if (is_updated)
                {
                    CLOs_DataTable.Rows[upd_ind]["CLO Name"] = CLO_Name_Textbox.Text.Trim();
                    CLOs_DataTable.Rows[upd_ind]["CLO Updated Date"] = DateTime.Now.ToString("MMM dd, yyyy");
                    update_flag = false;
                    CLO_Name_Textbox.Text = clo_name = "";
                    MessageBox.Show("Updated Successfully!!!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
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
                CLOs_DataGridView.DataSource = CLOs_DataTable;
                return;
            }

            try
            {
                searched_data = Database.Search_Data(Convert.ToInt32(Filter_By_Combobox.SelectedIndex),
                    Search_Textbox.Text);
                CLOs_DataGridView.DataSource = searched_data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }

        private void Update_CLO_Button_Click(object sender, EventArgs e)
        {
            if (update_flag == true)
            {
                Update_CLO();
            }
            else
            {
                MessageBox.Show("Please Select CLO From List!!!", "Error",
                    MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }
    }
}
