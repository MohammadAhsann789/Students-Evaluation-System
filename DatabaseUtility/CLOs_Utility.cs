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
    class CLOs_Utility
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter SDA = new SqlDataAdapter();
        DataTable data = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public CLOs_Utility()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }

        public DataTable Load_Data()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id, Name AS [CLO Name]," +
                    "DATENAME(WEEKDAY, DateCreated) + ', ' + DATENAME(MONTH, DateCreated) + " +
                    "' ' + DATENAME(DAY, DateCreated) + ', ' + DATENAME(YEAR, DateCreated) " +
                    "AS [CLO Created Date], " +
                    "DATENAME(WEEKDAY, DateUpdated) + ', ' + DATENAME(MONTH, DateUpdated) + " +
                    "' ' + DATENAME(DAY, DateUpdated) + ', ' + DATENAME(YEAR, DateUpdated) " +
                    "AS [CLO Updated Date] " +
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

        public int Insert_Data(string name, string date_created)
        {
            int clo_id = -1;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "INSERT INTO Clo " +
                    "(Name, DateCreated, DateUpdated) " +
                    "VALUES ('"+name+"', '"+date_created+"', '"+date_created+"') ";
                query += "SELECT MAX(Id) FROM Clo";
                cmd = new SqlCommand(query, con);
                clo_id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return clo_id;
        }

        public bool Delete_Data(int clo_id)
        {
            try
            {
                string query = "DELETE FROM StudentResult " +
                          "WHERE AssessmentComponentId IN (SELECT Id " +
                                                           "FROM AssessmentComponent " +
                                                           "WHERE RubricId IN (SELECT Id " +
                                                                               "FROM Rubric " +
                                                                               "WHERE CloId IN (SELECT Id " +
                                                                                                "FROM Clo " +
                                                                                                "WHERE Id = '" + clo_id + "'))) ";
                query += "DELETE FROM AssessmentComponent " +
                          "WHERE RubricId IN (SELECT Id " +
                          "                   FROM Rubric " +
                          "                   WHERE CloId IN (SELECT Id " +
                          "                                   FROM Clo " +
                          "                                   WHERE Id = '" + clo_id + "')) ";



                query += "DELETE FROM RubricLevel " +
                         "WHERE RubricId IN (SELECT Id " +
                         "                   FROM Rubric " +
                         "                   WHERE CloId IN (SELECT Id " +
                         "                                   FROM Clo " +
                         "                                   WHERE Id = '" + clo_id + "')) ";



                query += "DELETE FROM Rubric " +
                    "WHERE CloId = '" + clo_id + "' ";



                query += "DELETE FROM Clo " +
                    "WHERE Id = '" + clo_id + "'";
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

        public DataTable Search_Data(int filter_by_ind, string searched_value)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id, Name AS [CLO Name]," +
                    "Convert(nvarchar, DateCreated, 107) AS [CLO Created Date]," +
                    "Convert(nvarchar, DateUpdated, 107) AS [CLO Updated Date] " +
                    "FROM Clo " +
                    Select_Condition(filter_by_ind, searched_value);
                SDA = new SqlDataAdapter(query, con);
                data = new DataTable();
                SDA.Fill(data);
                con.Close();
            }
            catch(Exception ex)
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
                    condition = "WHERE Name LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 1:
                    condition = "WHERE DateCreated LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 2:
                    condition = "WHERE DateUpdated LIKE '" + Functions.char_condition(str) + "'";
                    break;

                default:
                    break;
            }
            return condition;
        }

        public bool Update_Data(string clo_name, string updated_date, int clo_id)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "UPDATE Clo " +
                    "SET Name = '"+clo_name+ "', DateUpdated = '"+updated_date+"' " +
                    "WHERE Id = '"+ clo_id + "'";
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
