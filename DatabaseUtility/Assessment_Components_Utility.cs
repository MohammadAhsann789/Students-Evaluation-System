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
    class Assessment_Components_Utility
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter SDA = new SqlDataAdapter();
        DataTable data = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public Assessment_Components_Utility()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }

        public DataTable Load_Data(int assessment_id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT AC.Id AS [Component ID], AC.Name AS [Component Name]," +
                    "AC.TotalMarks AS [Component Marks], " +
                    "DATENAME(WEEKDAY, AC.DateCreated) + ', ' + DATENAME(MONTH, AC.DateCreated) + " +
                    "' ' + DATENAME(DAY, AC.DateCreated) + ', ' + DATENAME(YEAR, AC.DateCreated) " +
                    "AS [Created Date]," +
                    "DATENAME(WEEKDAY, AC.DateUpdated) + ', ' + DATENAME(MONTH, AC.DateUpdated) + " +
                    "' ' + DATENAME(DAY, AC.DateUpdated) + ', ' + DATENAME(YEAR, AC.DateUpdated) " +
                    "AS [Updated Date], " +
                    "AC.RubricId AS [Component Rubric ID], R.Details AS [Rubric Details] " +
                    "FROM AssessmentComponent AS AC " +
                    "JOIN Rubric AS R " +
                    "ON AC.RubricId = R.Id " +
                    "WHERE AssessmentId = '" + assessment_id + "'";
                SDA = new SqlDataAdapter(query, con);
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

        public DataTable Load_Rubrics()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id, Details " +
                    "FROM Rubric";
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

        public DataTable Load_Other_Assessments(int assessment_id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id, Title " +
                    "FROM Assessment " +
                    "WHERE Id <> '" + assessment_id + "'";
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

        public int Insert_Data(string comp_name, int rub_id, int total_marks,
            DateTime created_date, DateTime updated_time, int assessment_id)
        {
            int inserted_id = -1;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "INSERT INTO AssessmentComponent " +
                    "(Name, RubricId, TotalMarks, DateCreated, DateUpdated, AssessmentId) " +
                    "VALUES ('" + comp_name + "', '" + rub_id + "', '" + total_marks + "', " +
                    "'" + created_date.ToShortDateString() + "', '" + updated_time.ToShortDateString() + "'," +
                    "'" + assessment_id + "') ";
                query += "SELECT MAX(Id) FROM AssessmentComponent";
                cmd = new SqlCommand(query, con);
                inserted_id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return inserted_id;
        }

        public bool Delete_Data(int id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "DELETE FROM StudentResult " +
                    "WHERE AssessmentComponentId = '" + id + "' ";
                query += "DELETE FROM AssessmentComponent " +
                    "WHERE Id = '" + id + "'";
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

        public bool Update_Data(string comp_name, int comp_marks, int rubric_id,
            int id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "UPDATE AssessmentComponent " +
                    "SET Name = '" + comp_name + "', RubricId = '" + rubric_id + "'," +
                    "TotalMarks = '" + comp_marks + "', " +
                    "DateUpdated = '" + DateTime.Now.ToShortDateString() + "' " +
                    "WHERE Id = '" + id + "'";
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

        public DataTable Search_Data(int filter_by_ind, string value, int assessment_id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT AC.Id AS [Component ID], AC.Name AS [Component Name]," +
                    "AC.TotalMarks AS [Component Marks], " +
                    "DATENAME(WEEKDAY, AC.DateCreated) + ', ' + DATENAME(MONTH, AC.DateCreated) + " +
                    "' ' + DATENAME(DAY, AC.DateCreated) + ', ' + DATENAME(YEAR, AC.DateCreated) " +
                    "AS [Created Date]," +
                    "DATENAME(WEEKDAY, AC.DateUpdated) + ', ' + DATENAME(MONTH, AC.DateUpdated) + " +
                    "' ' + DATENAME(DAY, AC.DateUpdated) + ', ' + DATENAME(YEAR, AC.DateUpdated) " +
                    "AS [Updated Date], " +
                    "AC.RubricId AS [Component Rubric ID], R.Details AS [Rubric Details] " +
                    "FROM AssessmentComponent AS AC " +
                    "JOIN Rubric AS R " +
                    "ON AC.RubricId = R.Id " +
                     Select_Condition(filter_by_ind, value, assessment_id);
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

        public string Select_Condition(int i, string str, int assessment_id)
        {
            string condition = "";
            switch (i)
            {
                case 0:
                    condition = "WHERE AssessmentId = '" + assessment_id + "' AND " +
                        "AC.Name LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 1:
                    condition = "WHERE AssessmentId = '" + assessment_id + "' AND " +
                        "AC.TotalMarks LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 2:
                    condition = "WHERE AssessmentId = '" + assessment_id + "' AND " +
                        "R.Details LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 3:
                    condition = "WHERE AssessmentId = '" + assessment_id + "' AND " +
                        "AC.DateCreated LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 4:
                    condition = "WHERE AssessmentId = '" + assessment_id + "' AND " +
                        "AC.DateUpdated LIKE '" + Functions.char_condition(str) + "'";
                    break;

                default:
                    break;
            }
            return condition;
        }
    }
}
