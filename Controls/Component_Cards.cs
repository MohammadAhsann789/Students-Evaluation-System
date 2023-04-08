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
using Students_Evaluation_System.DatabaseUtility;

namespace Students_Evaluation_System.Controls
{
    public partial class Component_Cards : UserControl
    {
        Student_Evaluation_Utility Database = new Student_Evaluation_Utility();
        int assessment_id = -1, component_id = -1, component_rubric_id = -1,
            component_total_marks = -1, student_id = -1;
        DateTime component_date_created;
        string component_name = "", component_rubric_name = "";

        DataTable Rubric_Levels_DataTable = new DataTable();

        public Component_Cards(int assessment_id, int component_id,
            int component_rubric_id, int component_total_marks, int student_id,
            DateTime component_date_created, string component_name,
            string component_rubric_name, int counter)
        {
            InitializeComponent();
            Theme_Color.Apply_Color(this.Controls);
            Card.color = Theme_Color.primary_color;
            this.assessment_id = assessment_id;
            this.component_id = component_id;
            this.component_rubric_id = component_rubric_id;
            this.component_total_marks = component_total_marks;
            this.student_id = student_id;
            this.component_date_created = component_date_created;
            this.component_name = component_name;
            this.component_rubric_name = component_rubric_name;
            Initialize_Card(counter);
        }

        private void Initialize_Card(int counter)
        {
            Component_Counter_Label.Text = counter.ToString();
            Created_Date_Label.Text = component_date_created.ToString("MMMM dd, yyyy");
            Componnt_Name_Label.Text = component_name;
            Component_Rubric_Name_Label.Text = component_rubric_name;
            Total_Marks_Label.Text = component_total_marks.ToString();
        }

        private void Component_Cards_Load(object sender, EventArgs e)
        {
            Load_Rubric_Levels();
            Set_Obtained_Rubric_Level();
        }

        private void Set_Obtained_Rubric_Level()
        {
            try
            {
                int value = Convert.ToInt32(Database.Get_Obtained_Rubric_Level(student_id, component_id));
                if(value > 0)
                {
                    Rubric_Levels_Combobox.SelectedValue = value;
                    Achieved_Level_Label.Text = Rubric_Levels_Combobox.Text;
                    Calculate_Marks();
                }
                else
                {
                    Achieved_Level_Label.Text = "Not Evaluated Yet";
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.RightAlign);
            }
        }

        private void Load_Rubric_Levels()
        {
            try
            {
                Rubric_Levels_DataTable = Database.Load_Rubric_Levels(component_rubric_id);
                //Rubric_Levels_DataTable.Columns.Add("RubricLevel", typeof(string),
                  //  "'Measurement Level = ' + MeasurementLevel");
                Rubric_Levels_Combobox.DisplayMember = "MeasurementLevel";
                Rubric_Levels_Combobox.ValueMember = "Id";
                Rubric_Levels_Combobox.DataSource = Rubric_Levels_DataTable;
                if (Rubric_Levels_Combobox.Items.Count > 0)
                {
                    Rubric_Levels_Combobox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Evaluate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                bool is_inserted = Database.Insert_Data(student_id, component_id,
                    Convert.ToInt32(Rubric_Levels_Combobox.SelectedValue));
                if (is_inserted)
                {
                    Achieved_Level_Label.Text = Rubric_Levels_Combobox.Text;
                    Calculate_Marks();
                    MessageBox.Show("Data Inseted Successfully!!!",
                        "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
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

        private void Update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                bool is_updated = Database.Update_Data(student_id, component_id,
                    Convert.ToInt32(Rubric_Levels_Combobox.SelectedValue));
                if (is_updated)
                {
                    Achieved_Level_Label.Text = Rubric_Levels_Combobox.Text;
                    Calculate_Marks();
                    MessageBox.Show("Data Updated Successfully!!!",
                        "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                }
                else
                {
                    MessageBox.Show("Component is Not Evalueated Yet!!!",
                        "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
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

        private double Calculate_Marks()
        {
            double marks = 0.0d;
            try
            {
                double max_rubric_level = Database.Get_Max_Rubric_Level(component_rubric_id) + 0.00;
                double obtained_level = Convert.ToInt32(Achieved_Level_Label.Text) + 0.00;
                marks = (obtained_level / max_rubric_level) * component_total_marks;
                Obtained_Marks_Label.Text = marks.ToString();
            }
            catch(Exception ex)
            {
                Obtained_Marks_Label.Text = "N/A";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return marks;
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                bool is_deleted = Database.Delete_Data(student_id, component_id);
                if (is_deleted)
                {
                    Achieved_Level_Label.Text = "Not Evaluated Yet";
                    Obtained_Marks_Label.Text = "N/A";
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
