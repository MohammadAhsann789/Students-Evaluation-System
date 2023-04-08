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
using Students_Evaluation_System.Controls;
using System;

namespace Students_Evaluation_System.Controls
{
    public partial class Student_Component_Evaluation : UserControl
    {
        Student_Evaluation_Utility Database = new Student_Evaluation_Utility();
        DataTable Components_DataTable = new DataTable();
        int assessment_id = -1, student_id = -1;
        public Student_Component_Evaluation(int assessment_id, int student_id, 
            string assessment_title, int assessment_marks, int assessment_weightage,
            string student_reg)
        {
            InitializeComponent();
            this.assessment_id = assessment_id;
            this.student_id = student_id;
            Assessment_Title_Label.Text = assessment_title;
            Total_Marks_Label.Text = assessment_marks.ToString();
            Total_Weightage_Label.Text = assessment_weightage.ToString();
            Student_RegNo_Label.Text = student_reg;
            Load_Component_Cards();
        }

        private void Load_Component_Cards()
        {
            try
            {
                Component_Cards_FlowLayoutPanel.Controls.Clear();
                Components_DataTable = Database.Load_Assessment_Components(assessment_id);
                if (Components_DataTable.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Assessment " +
                        "Component...\n" +
                        "First Add Component of this Particular Assessment!!!",
                        "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                for (int i = 0; i < Components_DataTable.Rows.Count; i++)
                {
                    Set_Cards(Components_DataTable.Rows[i], i + 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Set_Cards(DataRow data_row, int component_count)
        {
            Component_Cards card = new Component_Cards(assessment_id,
                Convert.ToInt32(data_row["Id"]),
                Convert.ToInt32(data_row["RubricId"]),
                Convert.ToInt32(data_row["TotalMarks"]), student_id,
                Convert.ToDateTime(data_row["DateCreated"]), data_row["Name"].ToString(),
                data_row["Rubric Name"].ToString(), component_count);
            card.Margin = new Padding(40, 30, 3, 0);
            Component_Cards_FlowLayoutPanel.Controls.Add(card);
        }
    }
}
