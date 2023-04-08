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
using Students_Evaluation_System.Forms;
using Students_Evaluation_System.DatabaseUtility;

namespace Students_Evaluation_System.Controls
{
    public partial class Student_Assessment_Evaluation : UserControl
    {
        Student_Evaluation_Utility Database = new Student_Evaluation_Utility();
        DataTable Student_RegNo_DataTable = new DataTable();
        DataTable Assessments_DataTable = new DataTable();
        Runner runner;

        public Student_Assessment_Evaluation(int i)
        {
            InitializeComponent();
        }

        public Student_Assessment_Evaluation(Runner runner)
        {
            InitializeComponent();
            this.runner = runner;
        }

        private void Student_Evaluation_Load(object sender, EventArgs e)
        {
            Load_RegNo_Combobox();
            Load_Assessment_Cards();
        }

        private void Load_RegNo_Combobox()
        {
            try
            {
                Student_RegNo_DataTable = Database.Load_Student_RegNos();
                Student_Reg_No_Combobox.DisplayMember = "RegistrationNumber";
                Student_Reg_No_Combobox.ValueMember = "Id";
                Student_Reg_No_Combobox.DataSource = Student_RegNo_DataTable;
                if(Student_Reg_No_Combobox.Items.Count > 0)
                {
                    Student_Reg_No_Combobox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Load_Assessment_Cards()
        {
            try
            {
                Assessment_Cards_FlowLayoutPanel.Controls.Clear();
                Assessments_DataTable = Database.Load_Assessments();
                if (Assessments_DataTable.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Assessment and Hence, its " +
                        "related Component...\n First Go and Create Assessment\n" +
                        "to Evaluate Students!!!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                for (int i = 0; i < Assessments_DataTable.Rows.Count; i++)
                {
                    Set_Cards(Assessments_DataTable.Rows[i], i + 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Set_Cards(DataRow data_row, int assessment_count)
        {
            Assessment_Cards card = new Assessment_Cards(assessment_count,
                Convert.ToInt32(data_row["Id"]),
                Convert.ToInt32(data_row["TotalMarks"]),
                Convert.ToInt32(data_row["TotalWeightage"]), data_row["Title"].ToString(),
                Convert.ToDateTime(data_row["DateCreated"]),
                Convert.ToInt32(Student_Reg_No_Combobox.SelectedValue),
                Student_Reg_No_Combobox.Text, runner);
            card.Margin = new Padding(40, 30, 3, 0);
            Assessment_Cards_FlowLayoutPanel.Controls.Add(card);
        }

        private void Student_Reg_No_Combobox_SelectedValueChanged(object sender, EventArgs e)
        {
            Load_Assessment_Cards();
        }
    }
}
