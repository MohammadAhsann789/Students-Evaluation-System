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

namespace Students_Evaluation_System.Controls
{
    public partial class Assessment_Cards : UserControl
    {
        int assessment_id = -1, assessment_total_marks = -1,
            assessment_total_weightage = -1, student_id = -1;
        string assessment_title = "", student_reg_no = "";
        DateTime assessment_created_date;
        Runner runner;

        public Assessment_Cards(int counter, int assessment_id, int assessment_total_marks,
            int assessment_total_weightage, string assessment_title,
            DateTime assessment_created_date, int student_id, string student_reg_no,
            Runner runner)
        {
            InitializeComponent();
            Card.color = Theme_Color.primary_color;
            this.assessment_id = assessment_id;
            this.assessment_total_marks = assessment_total_marks;
            this.assessment_total_weightage = assessment_total_weightage;
            this.assessment_title = assessment_title;
            this.assessment_created_date = assessment_created_date;
            this.student_id = student_id;
            this.student_reg_no = student_reg_no;
            Initialize_Card(counter);
            this.runner = runner;
        }

        private void Initialize_Card(int counter)
        {
            Assessment_Counter_Label.Text = counter.ToString();
            Assessment_Title_Label.Text = assessment_title;
            Created_Date_Label.Text = assessment_created_date.ToString("MMMM dd, yyyy");
            Total_Marks_Label.Text = assessment_total_marks.ToString();
            Total_Weightage_Label.Text = assessment_total_weightage.ToString();
        }

        private void Card_Click(object sender, EventArgs e)
        {
            runner.Controls_Panel.Controls.Clear();
            Student_Component_Evaluation components = new Student_Component_Evaluation(
                assessment_id, student_id, assessment_title, assessment_total_marks,
                assessment_total_weightage, student_reg_no);
            components.Dock = DockStyle.Fill;
            runner.Controls_Panel.Controls.Add(components);
        }
    }
}
