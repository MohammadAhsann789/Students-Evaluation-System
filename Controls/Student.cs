using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
    public partial class Student : UserControl
    {
        SqlConnection con;
        SqlDataAdapter SDA;
        DataTable students_DataTable;
        SqlCommand cmd;
        DataTable dt;
        string first_name, last_name, contact, email, reg_no;
        int status = -1, updated_ind = -1, randomized_ind = -1;
        bool update_flag = false;
        Runner runner;

        public Student(int i)
        {
            InitializeComponent();
        }

        public Student(Runner runner)
        {
            InitializeComponent();
            this.runner = runner;
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            SDA = new SqlDataAdapter();
            students_DataTable = new DataTable();
            cmd = new SqlCommand();
            Theme_Color.Apply_Color(this.Controls);
        }

        private void Student_Load(object sender, EventArgs e)
        {
            Load_Status();
            Load_Students();
            Load_Others();
        }

        private void Load_Status()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT LookupId, Name " +
                    "FROM Lookup WHERE Category = 'STUDENT_STATUS'";
                SDA = new SqlDataAdapter(query, con);
                DataTable status_DataTable = new DataTable();
                SDA.Fill(status_DataTable);
                Status_Combobox.DisplayMember = "Name";
                Status_Combobox.ValueMember = "LookupId";
                Status_Combobox.DataSource = status_DataTable;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Load_Students()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT S.FirstName AS [First Name], S.LastName " +
                    "AS [Last Name], S.Contact AS [Cell Number], S.Email AS [Email ID]," +
                    "S.RegistrationNumber AS [Reg Number], L.Name AS [Status]," +
                    "L.LookupId AS [Lookup ID]" +
                    "FROM Student AS S " +
                    "JOIN [Lookup] AS L " +
                    "ON S.Status = L.LookupId";
                SDA = new SqlDataAdapter(query, con);
                SDA.Fill(students_DataTable);
                con.Close();
                Students_DataGridView.DataSource = students_DataTable;
                this.Students_DataGridView.Columns["Lookup ID"].Visible = false;
                Add_Columns_In_Students_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Load_Others()
        {
            Status_Combobox.SelectedIndex = 0;
            Filter_By_Combobox.SelectedIndex = 0;
            this.Students_DataGridView.ColumnHeadersDefaultCellStyle.BackColor =
                Theme_Color.primary_color;
            this.Students_DataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Theme_Color.primary_color;
        }

        private void Add_Columns_In_Students_DataGridView()
        {
            DataGridViewImageColumn delete_column = new DataGridViewImageColumn();
            delete_column.Name = "Delete";
            delete_column.HeaderText = "Delete";
            delete_column.Image = new Bitmap(Properties.Resources.Delete_30px_black, 30, 30);
            Students_DataGridView.Columns.Add(delete_column);

            DataGridViewImageColumn update_column = new DataGridViewImageColumn();
            update_column.Name = "Update";
            update_column.HeaderText = "Update";
            update_column.Image = new Bitmap(Properties.Resources.Edit_30px_black, 29, 28);
            Students_DataGridView.Columns.Add(update_column);

            DataGridViewImageColumn student_result = new DataGridViewImageColumn();
            student_result.Name = "StudentResult";
            student_result.HeaderText = "Result Report";
            student_result.Image = new Bitmap(Properties.Resources.pdf_30px, 28, 30);
            Students_DataGridView.Columns.Add(student_result);
        }

        private void Add_Student_Button_Click(object sender, EventArgs e)
        {
            string msg = Check_Field("Registration Number", 
                "RegistrationNumber = '" + Reg_No_Textbox.Text.Trim() + "'", Reg_No_Textbox.Text.Trim());
            msg += "\n" + "".TrimStart() + Check_Field("Contact Number",
                "Contact = '"+Contact_Num_Textbox.Text.Trim()+"'", Contact_Num_Textbox.Text.Trim());
            msg += "\n" + "".TrimStart() + Check_Field("Email ID",
                "Email = '"+ Email_ID_Textbox.Text.Trim() + "'", Email_ID_Textbox.Text.Trim());
            if (msg.Trim() != "")
            {
                MessageBox.Show(msg.Trim(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            if(Check_For_Empty_Fields() == true)
            {
                return;
            }

            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "INSERT INTO Student" +
                    "(FirstName, LastName, Contact, Email, RegistrationNumber, Status)" +
                    "VALUES ('"+First_Name_Textbox.Text.Trim()+"'," +
                    "'"+Last_Name_Textbox.Text.Trim()+"'," +
                    "'"+Contact_Num_Textbox.Text.Trim()+"'," +
                    "'"+Email_ID_Textbox.Text.Trim()+"'," +
                    "'"+Reg_No_Textbox.Text.Trim()+"'," +
                    "'"+ Status_Combobox.SelectedValue+"')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                // Setting The fields to automiatically keeping Record for Updating Criteria.
                // As after adding the student user can update the fields without pressing
                // the Update Button.
                Set_Fields();
                Add_Student_In_DataGridView();
                /*MessageBox.Show("Student Added Successfully!!!","Success!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Set_Fields()
        {
            reg_no = Reg_No_Textbox.Text.Trim();
            first_name = First_Name_Textbox.Text.Trim();
            last_name = Last_Name_Textbox.Text.Trim();
            email = Email_ID_Textbox.Text.Trim();
            contact = Contact_Num_Textbox.Text.Trim();
            status = Convert.ToInt32(Status_Combobox.SelectedValue);
            updated_ind = students_DataTable.Rows.Count;
        }

        private bool Check_For_Empty_Fields()
        {
            if (First_Name_Textbox.Text.Trim() == "" || Last_Name_Textbox.Text.Trim() == ""
                || Contact_Num_Textbox.Text.Trim() == "" ||
                Email_ID_Textbox.Text.Trim() == "" || Reg_No_Textbox.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill all the Fields!!!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return true;
            }
            return false;
        }

        private string Check_Field(string field_name, string condition, string field)
        {
            string msg = "";
            try
            {
                if(con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id FROM Student " +
                    "WHERE " + condition;
                cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows == false)
                {
                    msg = "";
                }
                else
                {
                    msg = "This " + field_name + ": " + field + " is Already Added!!!";
                }
                con.Close();
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        private void Add_Student_In_DataGridView()
        {
            int ind = students_DataTable.Rows.Count;
            students_DataTable.Rows.Add();
            students_DataTable.Rows[ind]["First Name"] = First_Name_Textbox.Text.Trim();
            students_DataTable.Rows[ind]["Last Name"] = Last_Name_Textbox.Text.Trim();
            students_DataTable.Rows[ind]["Cell Number"] = Contact_Num_Textbox.Text.Trim();
            students_DataTable.Rows[ind]["Email ID"] = Email_ID_Textbox.Text.Trim();
            students_DataTable.Rows[ind]["Reg Number"] = Reg_No_Textbox.Text.Trim();
            students_DataTable.Rows[ind]["Status"] = Status_Combobox.Text.Trim();
            students_DataTable.Rows[ind]["Lookup ID"] = Status_Combobox.SelectedValue;

            if(dt != null)
            {
                ind = dt.Rows.Count;
                dt.Rows.Add();
                dt.Rows[ind]["First Name"] = First_Name_Textbox.Text.Trim();
                dt.Rows[ind]["Last Name"] = Last_Name_Textbox.Text.Trim();
                dt.Rows[ind]["Cell Number"] = Contact_Num_Textbox.Text.Trim();
                dt.Rows[ind]["Email ID"] = Email_ID_Textbox.Text.Trim();
                dt.Rows[ind]["Reg Number"] = Reg_No_Textbox.Text.Trim();
                dt.Rows[ind]["Status"] = Status_Combobox.Text.Trim();
                dt.Rows[ind]["Lookup ID"] = Status_Combobox.SelectedValue;
            }
            MessageBox.Show("Please Select Student From List!!!", "Success",
                    MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
        }

        private void Update_Student_Button_Click(object sender, EventArgs e)
        {
            if(update_flag == true)
            {
                Update_Student();
            }
            else
            {
                MessageBox.Show("Please Select Student From List!!!", "Error",
                    MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }

        private void Students_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 && e.RowIndex != -1) // Delete Column Index
            {
                int delete_ind = Functions.Get_Actual_Index_From_DataSource(students_DataTable, "Reg Number",
                    Students_DataGridView.Rows[e.RowIndex].Cells["Reg Number"].Value.ToString());
                randomized_ind = e.RowIndex;
                Delete_Student(delete_ind);
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1) // Update Column Index
            {
                update_flag = true;
                /* As we can change the position of displayed data in datagridview
                // by sorting it. In this context the actual data value in DataSource
                // will not match. And alone updating the datagridview without updating
                // in datatable could create problems.
                // And you see by alone changing the data in DataSource. It automatically
                   changes the data in DataGridView */
                updated_ind = Functions.Get_Actual_Index_From_DataSource(students_DataTable, "Reg Number",
                    Students_DataGridView.
                    Rows[e.RowIndex].Cells["Reg Number"].Value.ToString());
                randomized_ind = e.RowIndex;
                Set_Textboxes();
            }
        }

        private void Set_Textboxes()
        {
            First_Name_Textbox.Text = first_name = students_DataTable.Rows[updated_ind]["First Name"].ToString();
            Last_Name_Textbox.Text = last_name = students_DataTable.Rows[updated_ind]["Last Name"].ToString();
            Contact_Num_Textbox.Text = contact = students_DataTable.Rows[updated_ind]["Cell Number"].ToString();
            Email_ID_Textbox.Text = email = students_DataTable.Rows[updated_ind]["Email ID"].ToString();
            Reg_No_Textbox.Text = reg_no = students_DataTable.Rows[updated_ind]["Reg Number"].ToString();
            Status_Combobox.SelectedValue = status = Convert.ToInt32(students_DataTable.Rows[updated_ind]["Lookup ID"]);
        }

        private void Students_DataGridView_Resize(object sender, EventArgs e)
        {
            if(Students_DataGridView.Size.Width <= 708)
            {
                Students_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                Students_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void Search_Textbox_TextChange(object sender, EventArgs e)
        {
            if (Search_Textbox.Text == "")
            {
                Students_DataGridView.DataSource = students_DataTable;
                return;
            }

            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT S.FirstName AS [First Name], S.LastName " +
                    "AS [Last Name], S.Contact AS [Cell Number], S.Email AS [Email ID]," +
                    "S.RegistrationNumber AS [Reg Number], L.Name AS [Status]," +
                    "L.LookupId AS [Lookup ID]" +
                    "FROM Student AS S " +
                    "JOIN [Lookup] AS L " +
                    "ON S.Status = L.LookupId " +
                    Functions.Select_Condition(Filter_By_Combobox.SelectedIndex, Search_Textbox.Text);
                SDA = new SqlDataAdapter(query, con);
                dt = new DataTable();
                SDA.Fill(dt);
                con.Close();
                Students_DataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }

        private void Reset_Fields_Button_Click(object sender, EventArgs e)
        {
            Reset_Textboxes();
        }

        private void Attendence_Button_Click(object sender, EventArgs e)
        {
            //runner.active_control = Attendence_Button;
            runner.Controls_Panel.Controls.Clear();
            Attendence attendence = new Attendence(runner);
            attendence.Dock = DockStyle.Fill;
            runner.Controls_Panel.Controls.Add(attendence);
        }

        private void Delete_Student(int ind)
        {
            if (MessageBox.Show("Are you sure to Delete Student?" +
                "\nIt will delete student's result, and all of its other records!!!",
                "Error", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RightAlign) == DialogResult.OK)
            {
                try
                {
                    string reg_num = students_DataTable.Rows[ind]["Reg Number"].ToString();
                    int student_id = Get_StudentID(reg_num);
                    if(student_id <= 0)
                    {
                        MessageBox.Show("Some Error has been Occurred", "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    string query = "DELETE FROM StudentResult " +
                        "WHERE StudentId = '"+student_id+"' ";

                    query += "DELETE FROM StudentAttendance " +
                        "WHERE StudentId = '"+student_id+"' ";

                    query += "DELETE FROM Student " +
                        "WHERE Id = '" + student_id + "'";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    students_DataTable.Rows.RemoveAt(ind);
                    // For Deletng in Search DataSource
                    if(dt != null)
                    {
                        int i = Functions.Get_Actual_Index_From_DataSource(dt, "Reg Number",
                            reg_num);
                        if (i != -1)
                        {
                            dt.Rows.RemoveAt(i);
                        }
                    }
                    /*MessageBox.Show("Student Deleted Successfully!!!", "Success!!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                }
            }
        }

        private int Get_StudentID(string reg_num)
        {
            int student_id = -1;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "SELECT Id FROM Student WHERE " +
                    "RegistrationNumber = '" + reg_num + "'";
                cmd = new SqlCommand(query, con);
                student_id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex) { }
            return student_id;
        }

        private void Update_Student()
        {
            if(Check_For_Empty_Fields() == true)
            {
                return;
            }

            string query = "";
            try
            {
                int student_id = Get_StudentID(reg_no);
                if(student_id <= 0)
                {
                    MessageBox.Show("Some Error has been Occurred!!!", "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (Reg_No_Textbox.Text.Trim() != reg_no)
                {
                    string msg = Check_Field("Registration Number",
                "RegistrationNumber = '" + Reg_No_Textbox.Text.Trim() + "'", Reg_No_Textbox.Text.Trim());
                    if (msg != "")
                    {
                        MessageBox.Show(msg,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        return;
                    }
                    query += "UPDATE Student SET RegistrationNumber = '" + Reg_No_Textbox.Text.Trim() + "'" +
                        " WHERE Id = '" + student_id + "' ";
                }

                if (First_Name_Textbox.Text.Trim() != first_name)
                {
                    query += "UPDATE Student SET FirstName = '"+First_Name_Textbox.Text.Trim()+"'" +
                        " WHERE Id = '"+student_id+"' ";
                }

                if (Last_Name_Textbox.Text.Trim() != last_name)
                {
                    query += "UPDATE Student SET LastName = '" + Last_Name_Textbox.Text.Trim() + "'" +
                        " WHERE Id = '" + student_id + "' ";
                }

                if (Contact_Num_Textbox.Text.Trim() != contact)
                {
                    query += "UPDATE Student SET Contact = '" + Contact_Num_Textbox.Text.Trim() + "'" +
                        " WHERE Id = '" + student_id + "' ";
                }

                if (Email_ID_Textbox.Text.Trim() != email)
                {
                    query += "UPDATE Student SET Email = '" + Email_ID_Textbox.Text.Trim() + "'" +
                        " WHERE Id = '" + student_id + "' ";
                }

                if (Convert.ToInt32(Status_Combobox.SelectedValue) != status)
                {
                    query += "UPDATE Student SET Status = '" + Convert.ToInt32(Status_Combobox.SelectedValue) + "'" +
                        " WHERE Id = '" + student_id + "'";
                }

                if (query == "")
                {
                    MessageBox.Show("You didn't made any Change!!!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button3, MessageBoxOptions.RightAlign);
                    return;
                }

                if(con.State == ConnectionState.Closed) { con.Open(); }
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                update_flag = false;
                // Updating DataTable After Updatig from Database.
                /* Important Note: One can also update the fields in dataTable in 
                   above if-conditions.
                   But it will not be a good method. As there some problems could be created
                   Because if some problem is occurred in executing the SQL Query.
                   Then the data will be changed only on Runtime in DataTable.
                   It will not vhange in database which then will lead to some
                   problems. So data in DataTable should be updated only after
                   updating in Database. */
                Update_Students_DataTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
            }
        }

        private void Update_Students_DataTable()
        {
            // dt DataTable is for searched data
            int i = -1;
            if (dt != null)
            {
                i = Functions.Get_Actual_Index_From_DataSource(dt, "Reg Number",
                    Students_DataGridView.Rows[randomized_ind].Cells["Reg Number"].Value.ToString());
            }
            // Here if condition is used to ensure that there will be no any overwritten,
            // only those fields will be updated which have been changed.
            if (Reg_No_Textbox.Text.Trim() != reg_no)
            {
                students_DataTable.Rows[updated_ind]["Reg Number"] = Reg_No_Textbox.Text.Trim();
                if (i != -1) { dt.Rows[i]["Reg Number"] = Reg_No_Textbox.Text.Trim(); } 
            }

            if (First_Name_Textbox.Text.Trim() != first_name)
            {
                students_DataTable.Rows[updated_ind]["First Name"] = First_Name_Textbox.Text.Trim();
                if(i != -1) { dt.Rows[i]["First Name"] = First_Name_Textbox.Text.Trim(); }
            }

            if (Last_Name_Textbox.Text.Trim() != last_name)
            {
                students_DataTable.Rows[updated_ind]["Last Name"] = Last_Name_Textbox.Text.Trim();
                if (i != -1) { dt.Rows[i]["Last Name"] = Last_Name_Textbox.Text.Trim(); }
            }

            if (Contact_Num_Textbox.Text.Trim() != contact)
            {
                students_DataTable.Rows[updated_ind]["Cell Number"] = Contact_Num_Textbox.Text.Trim();
                if (i != -1) { dt.Rows[i]["Cell Number"] = Contact_Num_Textbox.Text.Trim(); }
            }

            if (Email_ID_Textbox.Text.Trim() != email)
            {
                students_DataTable.Rows[updated_ind]["Email ID"] = Email_ID_Textbox.Text.Trim();

                if (i != -1) { dt.Rows[i]["Email ID"] = Email_ID_Textbox.Text.Trim(); }
            }

            if (Convert.ToInt32(Status_Combobox.SelectedValue) != status)
            {
                students_DataTable.Rows[updated_ind]["Lookup ID"] = Convert.ToInt32(Status_Combobox.SelectedValue);
                students_DataTable.Rows[updated_ind]["Status"] = Status_Combobox.Text;
                if (i != -1) {
                    dt.Rows[i]["Lookup ID"] = Convert.ToInt32(Status_Combobox.SelectedValue);
                    dt.Rows[i]["Status"] = Status_Combobox.Text;
                }
            }
            Reset_Textboxes();
        }

        private void Reset_Textboxes()
        {
            Reg_No_Textbox.Text = "";
            First_Name_Textbox.Text = "";
            Last_Name_Textbox.Text = "";
            Contact_Num_Textbox.Text = "";
            Email_ID_Textbox.Text = "";
            Status_Combobox.SelectedIndex = 0;
        }
    }
}
