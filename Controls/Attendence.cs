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
using System.Data.SqlClient;
using System.Configuration;
using Students_Evaluation_System.Forms;

namespace Students_Evaluation_System.Controls
{
    public partial class Attendence : UserControl
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter SDA = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable Attendences_DataTable = new DataTable();
        DataTable dt = new DataTable();
        DataTable Attendence_Status_DataTable = new DataTable();
        DataTable Class_Attendences_Date_DataTable = new DataTable();
        string status = "";
        int randomized_ind = -1;
        Runner form;
        public Attendence(Runner form)
        {
            InitializeComponent();
            Filter_By_Combobox.SelectedIndex = 0;
            this.form = form;
            form.msg = "Open";
            form.reserved_control = form.student;
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            Theme_Color.Apply_Color(this.Controls);
            Attendences_DataGridView.ColumnHeadersDefaultCellStyle.BackColor = Theme_Color.primary_color;
            Attendences_DataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Theme_Color.primary_color;
        }

        private void Attendence_Load(object sender, EventArgs e)
        {
            Load_Class_Attendences_Date();
            Load_Attendences();
            Load_Attendence_Status();
            //Set_Attendence_Status_In_DataGridView();
        }

        private void Load_Attendences()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT S.Id AS [Id] , S.FirstName AS [First Name], S.LastName " +
                    "AS [Last Name], S.Contact AS [Cell Number], S.Email AS [Email ID]," +
                    "S.RegistrationNumber AS [Reg Number] " +
                    "FROM Student AS S";
                SDA = new SqlDataAdapter(query, con);
                SDA.Fill(Attendences_DataTable);
                con.Close();
                Attendences_DataGridView.DataSource = Attendences_DataTable;
                Attendences_DataGridView.Columns["Id"].Visible = false;
                Add_Columns_In_Attendnences_DataGridView();
                Set_Attendence_Status_In_DataGridView(Attendences_DataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Load_Attendence_Status()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Name, LookupId " +
                    "FROM [Lookup] " +
                    "WHERE Category = 'ATTENDANCE_STATUS'";
                SDA = new SqlDataAdapter(query, con);
                SDA.Fill(Attendence_Status_DataTable);
                Attendence_Status_Combobox.DisplayMember = "Name";
                Attendence_Status_Combobox.ValueMember = "LookupId";
                Attendence_Status_Combobox.DataSource = Attendence_Status_DataTable;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Load_Class_Attendences_Date()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id, " +
                    "DATENAME(WEEKDAY, AttendanceDate) + ', ' + DATENAME(MONTH, AttendanceDate) + " +
                    "' ' + DATENAME(DAY, AttendanceDate) + ', ' + DATENAME(YEAR, AttendanceDate) " +
                    "AS [AttendanceDate] " +
                    "FROM ClassAttendance";
                SDA = new SqlDataAdapter(query, con);
                SDA.Fill(Class_Attendences_Date_DataTable);
                Attendences_Date_Combobox.DisplayMember = "AttendanceDate";
                Attendences_Date_Combobox.ValueMember = "Id";
                Attendences_Date_Combobox.DataSource = Class_Attendences_Date_DataTable;
                con.Close();
                Attendences_Date_Combobox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Add_Columns_In_Attendnences_DataGridView()
        {
            Attendences_DataTable.Columns.Add("Attendence Status", typeof(string));

            DataGridViewImageColumn mark_attendence = new DataGridViewImageColumn();
            mark_attendence.Name = "Mark_Attendence";
            mark_attendence.HeaderText = "Mark Attendence";
            mark_attendence.Image = new Bitmap(Properties.Resources.Edit_30px_black, 29, 28);
            Attendences_DataGridView.Columns.Add(mark_attendence);

            DataGridViewImageColumn delete_attendence = new DataGridViewImageColumn();
            delete_attendence.Name = "Delete_Attendence";
            delete_attendence.HeaderText = "Delete Attendence";
            delete_attendence.Image = new Bitmap(Properties.Resources.Delete_30px_black, 29, 28);
            Attendences_DataGridView.Columns.Add(delete_attendence);
        }

        private void Set_Attendence_Status_In_DataGridView(DataTable datatable)
        { 
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT SA.StudentId AS [SId], L.Name " +
                    "AS [Status] " +
                    "FROM StudentAttendance AS SA " +
                    "JOIN [Lookup] AS L " +
                    "ON SA.AttendanceStatus = L.LookupId " +
                    "JOIN ClassAttendance AS CA " +
                    "ON SA.AttendanceId = CA.Id " +
                    "WHERE CA.Id = '"+Attendences_Date_Combobox.SelectedValue+"'";
                SDA = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);

                // Double loop is used because the elements indexes will be different in 
                // dt 'DataTable' and Attendences_DataTable
                for (int i=0; i<dt.Rows.Count; i++)
                {
                    DataRow dt_row = dt.Rows[i];
                    for(int j=0; j< datatable.Rows.Count; j++)
                    {
                        DataRow at_row = datatable.Rows[j];
                        if (dt_row["SId"].ToString() == at_row["Id"].ToString())
                        {
                            datatable.Rows[j]["Attendence Status"] =
                            dt_row["Status"];
                        }
                    }
                }

                // This loop will also work for if there is no row in dt at selected date. 
                for(int i=0; i< datatable.Rows.Count; i++)
                {
                    if(datatable.Rows[i]["Attendence Status"].ToString()
                            == "")
                    {
                        datatable.Rows[i]["Attendence Status"] =
                            "Present***";
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Create_Date_Button_Click(object sender, EventArgs e)
        {
            if (Is_Date_Present())
            {
                MessageBox.Show("This Date is Already Inserted!!!",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "INSERT INTO ClassAttendance " +
                    "(AttendanceDate) " +
                    "VALUES ('"+ Convert.ToDateTime(Class_Attendence_Date_DateTime.Value).ToShortDateString() + "') ";
                query += "SELECT MAX(Id) AS Id FROM ClassAttendance";
                cmd = new SqlCommand(query, con);
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                int count = Class_Attendences_Date_DataTable.Rows.Count;
                Class_Attendences_Date_DataTable.Rows.Add();
                Class_Attendences_Date_DataTable.Rows[count]["Id"] = id;
                Class_Attendences_Date_DataTable.Rows[count]["AttendanceDate"] =
                    Convert.ToDateTime(Class_Attendence_Date_DateTime.Value).
                    ToString("MMM dd, yyyy");
                Attendences_Date_Combobox.SelectedValue = id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private bool Is_Date_Present()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT AttendanceDate " +
                    "FROM ClassAttendance " +
                    "WHERE AttendanceDate = '"+ Attendences_Date_Combobox.Text + "'";
                cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    con.Close();
                    return true;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            return false;
        }

        private void Attendences_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int ind = Functions.Get_Actual_Index_From_DataSource(Attendences_DataTable, "Reg Number",
                    Attendences_DataGridView.Rows[e.RowIndex].Cells["Reg Number"].Value.ToString());

                randomized_ind = e.RowIndex;
                if (Attendences_DataTable.Rows[ind]["Attendence Status"].ToString() ==
                    "Present***")
                {
                    Mark_Attendence(ind);                
                }
                else
                {
                    status = Attendences_DataGridView.Rows[e.RowIndex].
                        Cells["Attendence Status"].Value.ToString();
                    Edit_Attendence(ind);
                }
            }
            else if(e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                int del_ind = Functions.Get_Actual_Index_From_DataSource(Attendences_DataTable, "Reg Number",
                    Attendences_DataGridView.Rows[e.RowIndex].Cells["Reg Number"].Value.ToString());
                randomized_ind = e.RowIndex;
                Delete_Attendence(del_ind); // Here e.rowind is used for 
            }
        }

        private void Delete_Attendence(int del_ind)
        {
            try
            {
                if(con.State == ConnectionState.Closed) { con.Open(); }
                string query = "DELETE FROM StudentAttendance " +
                    "WHERE StudentId = '"+ Convert.ToInt32(Attendences_DataTable.
                    Rows[del_ind]["Id"]) + "' AND " +
                    "AttendanceId = '"+Attendences_Date_Combobox.SelectedValue+"'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Attendences_DataTable.Rows[del_ind]["Attendence Status"] = "Present***";
                if (dt != null)
                {
                    int i = Functions.Get_Actual_Index_From_DataSource(dt, "Reg Number",
                            Attendences_DataGridView.Rows[randomized_ind].Cells["Reg Number"].Value.ToString());
                    if (i != -1)
                    {
                        dt.Rows[i]["Attendence Status"] = "Present***";
                    }
                }
                MessageBox.Show("Attendence Deleted Successfully!!!", "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Edit_Attendence(int ind)
        {
            if(status == Attendence_Status_Combobox.Text)
            {
                MessageBox.Show("Cannot Edited!!!\n" +
                    "Because Attendence Status is not Changed",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "UPDATE StudentAttendance " +
                    "SET AttendanceStatus = '"+Attendence_Status_Combobox.SelectedValue+"' " +
                    "WHERE StudentId = '"+ Attendences_DataTable.Rows[ind]["Id"] + "' " +
                    "AND AttendanceId = '"+Attendences_Date_Combobox.SelectedValue+"'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Attendences_DataTable.Rows[ind]["Attendence Status"] =
                    Attendence_Status_Combobox.Text;
                if (dt != null)
                {
                    int i = Functions.Get_Actual_Index_From_DataSource(dt, "Reg Number",
                            Attendences_DataGridView.Rows[randomized_ind].Cells["Reg Number"].Value.ToString());
                    if (i != -1)
                    {
                        dt.Rows[i]["Attendence Status"] =
                        Attendence_Status_Combobox.Text;
                    }
                }
                MessageBox.Show("Edited!!!",
                    "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Mark_Attendence(int ind)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "INSERT INTO StudentAttendance " +
                    "(AttendanceId, StudentId, AttendanceStatus) " +
                    "VALUES ('"+ Attendences_Date_Combobox.SelectedValue + "', " +
                    "'"+ Attendences_DataTable.Rows[ind]["Id"] + "', " +
                    "'"+Attendence_Status_Combobox.SelectedValue+"')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Attendences_DataTable.Rows[ind]["Attendence Status"] =
                    Attendence_Status_Combobox.Text;

                if(dt != null)
                {
                    int i = Functions.Get_Actual_Index_From_DataSource(dt, "Reg Number",
                            Attendences_DataGridView.Rows[randomized_ind].Cells["Reg Number"].Value.ToString());
                    if (i != -1)
                    {
                        dt.Rows[i]["Attendence Status"] =
                        Attendence_Status_Combobox.Text;
                    }
                }
                MessageBox.Show("Attednece Marked Successfully!!!",
                    "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Attendences_Date_Combobox_SelectedValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Attendences_DataTable.Rows.Count; i++)
            {
                Attendences_DataTable.Rows[i]["Attendence Status"] = "";
            }
            Set_Attendence_Status_In_DataGridView(Attendences_DataTable);
        }

        private void Delet_All_Attendences_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "DELETE FROM StudentAttendance " +
                    "WHERE AttendanceId = '" + Attendences_Date_Combobox.SelectedValue + "'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                for (int i = 0; i < Attendences_DataTable.Rows.Count; i++)
                {
                    Attendences_DataTable.Rows[i]["Attendence Status"] =
                            "Present***";
                    if(dt != null && i < dt.Rows.Count)
                    {
                        dt.Rows[i]["Attendence Status"] = "Present***";
                    }
                }
                MessageBox.Show("All Student Attendences are Deleted Successfully\n" +
                    "of Selected Date!!!", "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Search_Textbox_TextChange(object sender, EventArgs e)
        {
            if (Search_Textbox.Text == "")
            {
                Attendences_DataGridView.DataSource = Attendences_DataTable;
                return;
            }

            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT S.Id AS [Id] , S.FirstName AS [First Name], S.LastName " +
                    "AS [Last Name], S.Contact AS [Cell Number], S.Email AS [Email ID]," +
                    "S.RegistrationNumber AS [Reg Number] " +
                    "FROM Student AS S " +
                    Select_Condition(Filter_By_Combobox.SelectedIndex, Search_Textbox.Text);
                SDA = new SqlDataAdapter(query, con);
                dt = new DataTable();
                SDA.Fill(dt);
                con.Close();
                dt.Columns.Add("Attendence Status", typeof(string));
                Attendences_DataGridView.DataSource = dt;
                Set_Attendence_Status_In_DataGridView(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }

        public string Select_Condition(int i, string str)
        {
            string condition = "";
            switch (i)
            {
                case 0:
                    condition = "WHERE RegistrationNumber LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 1:
                    condition = "WHERE FirstName LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 2:
                    condition = "WHERE LastName LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 3:
                    condition = "WHERE Contact LIKE '" + Functions.char_condition(str) + "'";
                    break;

                case 4:
                    condition = "WHERE Email LIKE '" + Functions.char_condition(str) + "'";
                    break;

                default:
                    break;
            }
            return condition;
        }

        private void Attendence_Report_Button_Click(object sender, EventArgs e)
        {
            
        }
    }
}
