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
    class Assessment_Utility
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter SDA = new SqlDataAdapter();
        DataTable data = new DataTable();
        SqlCommand cmd = new SqlCommand();
        public Assessment_Utility()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }

        public DataTable Load_Data()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id AS [Assessment ID], Title AS [Assessment Title]," +
                    "DATENAME(WEEKDAY, DateCreated) + ', ' + DATENAME(MONTH, DateCreated) + " +
                    "' ' + DATENAME(DAY, DateCreated) + ', ' + DATENAME(YEAR, DateCreated) " +
                    "AS [Created Date], TotalMarks AS [Assessment Marks]," +
                    "TotalWeightage AS [Assessment Weightage] " +
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

        public bool Delete_Data(int id)
        {
            try
            {
                if(con.State == ConnectionState.Closed) { con.Open(); }
                string query = "DELETE FROM StudentResult " +
                    "WHERE AssessmentComponentId IN (SELECT Id " +
                    "                                FROM AssessmentComponent " +
                    "                                WHERE AssessmentId IN (SELECT Id" +
                    "                                                       FROM Assessment " +
                    "                                                       WHERE Id = '"+ id +"')) ";
                query += "DELETE FROM AssessmentComponent " +
                    "WHERE AssessmentId = '"+id+"' ";
                query += "DELETE FROM Assessment " +
                    "WHERE Id = '"+ id +"'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return false;
        }

        public bool Update_Data(string title, int total_marks, int total_weightage,
            int id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "UPDATE Assessment SET Title = '" + title + "'," +
                    "TotalMarks = '" + total_marks + "', TotalWeightage = '" + total_weightage + "' " +
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

        public int Insert_Data(string title, int total_marks, int total_weightage)
        {
            int inserted_id = -1;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "INSERT INTO Assessment " +
                    "(Title, DateCreated, TotalMarks, TotalWeightage) " +
                    "VALUES ('"+title+"', '"+DateTime.Now.ToShortDateString()+"'," +
                    "'"+total_marks+"', '"+total_weightage+"')";
                query += "SELECT MAX(Id) FROM Assessment";
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

        public DataTable Search_Data(int filter_by_ind, string value)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id AS [Assessment ID], Title AS [Assessment Title]," +
                    "DateCreated AS [Created Date], TotalMarks AS [Assessment Marks]," +
                    "TotalWeightage AS [Assessment Weightage] " +
                    "FROM Assessment " + 
                    Select_Condition(filter_by_ind, value);
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

        public string Select_Condition(int i, string str)
        {
            string condition = "";
            switch (i)
            {
                case 0:
                    condition = "WHERE Title LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 1:
                    condition = "WHERE TotalMarks LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 2:
                    condition = "WHERE TotalWeightage LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 3:
                    condition = "WHERE DateCreated LIKE '" + Functions.char_condition(str) + "'";
                    break;

                default:
                    break;
            }
            return condition;
        }
    }
}