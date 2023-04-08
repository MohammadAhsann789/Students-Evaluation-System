using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Students_Evaluation_System.Utility;

namespace Students_Evaluation_System.DatabaseUtility
{
    class Student_Evaluation_Utility
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter SDA = new SqlDataAdapter();
        DataTable data = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public Student_Evaluation_Utility()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }

        public DataTable Load_Student_RegNos()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id, RegistrationNumber " +
                    "FROM Student";
                SDA = new SqlDataAdapter(query, con);
                data = new DataTable();
                SDA.Fill(data);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return data;
        }

        public DataTable Load_Assessments()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id, Title, DateCreated, TotalMarks, TotalWeightage " +
                    "FROM Assessment";
                SDA = new SqlDataAdapter(query, con);
                data = new DataTable();
                SDA.Fill(data);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return data;
        }

        public DataTable Load_Assessment_Components(int assessment_id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT AC.Id [Id], AC.Name, AC.RubricId," +
                    "R.Details AS [Rubric Name]," +
                    "AC.TotalMarks, AC.DateCreated " +
                    "FROM AssessmentComponent AS AC " +
                    "JOIN Rubric AS R " +
                    "ON R.Id = RubricId " +
                    "WHERE AssessmentId = '" + assessment_id + "'";
                SDA = new SqlDataAdapter(query, con);
                data = new DataTable();
                SDA.Fill(data);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return data;
        }

        public DataTable Load_Rubric_Levels(int rubric_id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id, MeasurementLevel " +
                    "FROM RubricLevel " +
                    "WHERE RubricId = '"+ rubric_id +"'";
                SDA = new SqlDataAdapter(query, con);
                data = new DataTable();
                SDA.Fill(data);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return data;
        } 

        public bool Insert_Data(int student_id, int component_id,
            int rubric_measuremet_id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "INSERT INTO StudentResult " +
                    "(StudentId, AssessmentComponentId, RubricMeasurementId," +
                    "EvaluationDate) " +
                    "VALUES ('"+student_id+"', '"+component_id+"'," +
                    "'"+rubric_measuremet_id+"', '"+DateTime.Now.ToShortDateString()+"')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return false;
        }

        public bool Update_Data(int student_id, int component_id,
            int rubric_measuremet_id)
        {
            int val = -1;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                // To check if data exists or not
                string query = "SELECT StudentId " +
                    "FROM StudentResult " +
                    "WHERE StudentId = '" + student_id + "' AND " +
                    "AssessmentComponentId = '" + component_id + "'";
                cmd = new SqlCommand(query, con);
                val = Convert.ToInt32(cmd.ExecuteScalar());
                if(val <= 0)
                {
                    return false;
                }
                
                query = "UPDATE StudentResult " +
                    "SET RubricMeasurementId = '"+ rubric_measuremet_id + "' " +
                    "WHERE StudentId = '"+ student_id + "' AND " +
                    "AssessmentComponentId = '"+ component_id + "'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return false;
        }

        public int Get_Max_Rubric_Level(int rubric_id)
        {
            int max = -1;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT MAX(MeasurementLevel) " +
                    "FROM RubricLevel " +
                    "WHERE RubricId = '" + rubric_id + "'";
                cmd = new SqlCommand(query, con);
                max = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return max;
        }

        public int Get_Obtained_Rubric_Level(int student_id, int component_id)
        {
            int val = -1;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT RL.Id " +
                    "FROM RubricLevel AS RL " +
                    "JOIN StudentResult AS S " +
                    "ON S.RubricMeasurementId = RL.Id " +
                    "WHERE S.StudentId = '" + student_id + "' AND " +
                    "S.AssessmentComponentId = '"+ component_id + "'";
                cmd = new SqlCommand(query, con);
                val = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return val;
        }

        public bool Delete_Data(int student_id, int component_id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "DELETE FROM StudentResult " +
                    "WHERE StudentId = '"+ student_id + "' AND " +
                    "AssessmentComponentId = '"+ component_id + "'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return false;
        }
    }
}