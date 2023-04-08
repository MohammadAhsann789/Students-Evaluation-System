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
    class Rubric_Levels_Utility
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter SDA = new SqlDataAdapter();
        DataTable data = new DataTable();
        SqlCommand cmd = new SqlCommand();
        
        public Rubric_Levels_Utility()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }

        public DataTable Load_Data()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT RL.Id AS [Rubric Level ID]," +
                    "RL.RubricId AS [Rubric ID]," +
                    "R.Details AS [Rubric Details]," +
                    "RL.Details AS [Rubric Level Details]," +
                    "RL.MeasurementLevel AS [Measurement Level] " +
                    "FROM RubricLevel AS RL " +
                    "JOIN Rubric AS R " +
                    "ON R.Id = RL.RubricId";
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

        public int Insert_Data(string rubric_level_details, int measurement_level,
            int rubric_id)
        {
            int id = -1;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "INSERT INTO RubricLevel " +
                    "(RubricId, Details, MeasurementLevel) " +
                    "VALUES ('"+ rubric_id + "', '"+ rubric_level_details + "'," +
                    "'"+ measurement_level + "')";

                query += "SELECT MAX(Id) FROM RubricLevel";
                cmd = new SqlCommand(query, con);
                id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return id;
        }

        public bool Delete_Data(int rub_lev_id)
        {
            try
            {
                string query = "DELETE FROM StudentResult " +
                          "WHERE RubricMeasurementId = '" + rub_lev_id + "' ";


                query += "DELETE FROM RubricLevel " +
                         "WHERE Id = '" + rub_lev_id + "' ";

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

        public bool Update_Data(int rub_id, string rub_details, int rub_mea_level, 
            int rub_level_id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "UPDATE RubricLevel SET RubricId = '"+rub_id+"'," +
                    "Details = '"+ rub_details + "', MeasurementLevel = '"+ rub_mea_level + "' " +
                    "WHERE Id = '"+ rub_level_id + "'";
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
                string query = "SELECT RL.Id AS [Rubric Level ID]," +
                    "RL.RubricId AS [Rubric ID]," +
                    "R.Details AS [Rubric Details]," +
                    "RL.Details AS [Rubric Level Details]," +
                    "RL.MeasurementLevel AS [Measurement Level] " +
                    "FROM RubricLevel AS RL " +
                    "JOIN Rubric AS R " +
                    "ON R.Id = RL.RubricId " +
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
                    condition = "WHERE RL.Details LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 1:
                    condition = "WHERE RL.MeasurementLevel LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 2:
                    condition = "WHERE RL.RubricId LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 3:
                    condition = "WHERE R.Details LIKE '" + Functions.char_condition(str) + "'";
                    break;

                default:
                    break;
            }
            return condition;
        }
    }
}
