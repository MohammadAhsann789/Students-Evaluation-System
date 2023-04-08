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
    class Rubrics_Utility
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter SDA = new SqlDataAdapter();
        DataTable data = new DataTable();
        SqlCommand cmd = new SqlCommand();
        public Rubrics_Utility()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }

        public DataTable Load_Data()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT R.CloId AS [CLO ID]," +
                    "C.Name AS [CLO Name]," +
                    "R.Id AS [Rubric ID]," +
                    "R.Details AS [Rubric Details] " +
                    "FROM Rubric AS R " +
                    "JOIN Clo AS C " +
                    "ON R.CloId = C.Id";
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

        public DataTable Load_Clos()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id, Name " +
                    "FROM Clo";
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

        public int Insert_Data(string rubric_detail, int clo_id)
        {
            int rub_id = -1;
            try
            {
                rub_id = Get_RubricID();
                if(rub_id < 0)
                {
                    return rub_id;
                }
                rub_id++;
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "INSERT INTO Rubric " +
                    "(Id, Details, CloId) " +
                    "VALUES ('"+ rub_id + "', '"+rubric_detail+"'," +
                    "'"+clo_id+"')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return rub_id;
        }

        public int Get_RubricID()
        {
            int rub_id = -1;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT MAX(Id) " +
                    "FROM Rubric";
                cmd = new SqlCommand(query, con);
                var id = cmd.ExecuteScalar();
                con.Close();
                if (id is DBNull)
                {
                    rub_id = 0;
                }
                else
                {
                    rub_id = Convert.ToInt32(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return rub_id;
        }

        public bool Delete_Data(int rubric_id)
        {
            try
            {
                string query = "DELETE FROM StudentResult " +
                          "WHERE AssessmentComponentId IN (SELECT Id " +
                                                           "FROM AssessmentComponent " +
                                                           "WHERE RubricId IN (SELECT Id " +
                                                                               "FROM Rubric " +
                                                                               "WHERE Id = '" + rubric_id + "')) ";
                query += "DELETE FROM AssessmentComponent " +
                          "WHERE RubricId IN (SELECT Id " +
                          "                   FROM Rubric " +
                          "                   WHERE Id = '" + rubric_id + "') ";



                query += "DELETE FROM RubricLevel " +
                         "WHERE RubricId IN (SELECT Id " +
                         "                   FROM Rubric " +
                         "                   WHERE Id = '" + rubric_id + "') ";



                query += "DELETE FROM Rubric " +
                    "WHERE Id = '" + rubric_id + "' ";

                if (con.State == ConnectionState.Closed) { con.Open(); }
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

        public bool Update_Data(string rubric_details, int clo_id, int rubric_id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "UPDATE Rubric " +
                    "SET Details = '" + rubric_details + "', CloId = '"+clo_id+"'" +
                    "WHERE Id = '" + rubric_id + "'";
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

        public DataTable Search_Data(int filter_by_ind, string searched_value)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT R.CloId AS [CLO ID]," +
                    "C.Name AS [CLO Name]," +
                    "R.Id AS [Rubric ID]," +
                    "R.Details AS [Rubric Details] " +
                    "FROM Rubric AS R " +
                    "JOIN Clo AS C " +
                    "ON R.CloId = C.Id " +
                    Select_Condition(filter_by_ind, searched_value);
                data = new DataTable();
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

        public string Select_Condition(int i, string str)
        {
            string condition = "";
            switch (i)
            {
                case 0:
                    condition = "WHERE R.Details LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 1:
                    condition = "WHERE C.Name LIKE '" + Functions.char_condition(str) + "'";
                    break;

                default:
                    break;
            }
            return condition;
        }
    }
}
