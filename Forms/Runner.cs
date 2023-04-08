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
using Students_Evaluation_System.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace Students_Evaluation_System.Forms
{
    public partial class Runner : Form
    {
        Student student_control = new Student(-1);
        public Student student;
        CLOs clo_control = new CLOs(-1);
        Rubrics rubrics_control = new Rubrics(-1);
        Rubric_Levels rubric_levels_control = new Rubric_Levels(-1);
        Assessments assessments_control = new Assessments(-1);
        public Assessments assessment;
        Student_Assessment_Evaluation student_evaluation = new Student_Assessment_Evaluation(-1);
        public Student_Assessment_Evaluation student_evaluation_control;

        public Control active_control = new Control();
        int border_size = 2;
        Button current_button = new Button();
        Random random = new Random();
        int temp_ind = -1;
        SqlConnection con = new SqlConnection();
        public string msg = "";
        public Control reserved_control = new Control();

        public Runner()
        {
            InitializeComponent();
            student = new Student(this);
            con.ConnectionString = ConfigurationManager.
                ConnectionStrings["DatabaseConnection"].ConnectionString;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private Color Select_Color()
        {
            int index = random.Next(Theme_Color.color_list.Count);
            while (temp_ind == index)
            {
                index = random.Next(Theme_Color.color_list.Count);
            }
            temp_ind = index;
            string color = Theme_Color.color_list[index];
            return ColorTranslator.FromHtml(color);
        }

        private void Activate_Button(object button_sender, string sub_title, Bitmap img)
        {
            if (button_sender != null)
            {
                if (current_button != (Button)button_sender)
                {
                    Deactivate_Button();
                    Color color = Select_Color();
                    current_button = (Button)button_sender;
                    current_button.BackColor = color;
                    current_button.ForeColor = Color.White;
                    Title_Panel.BackColor = color;
                    Logo_Panel.BackColor = Theme_Color.Change_Color_Brightness(color, -0.3);
                    Theme_Color.primary_color = color;
                    Theme_Color.secondary_color = Theme_Color.Change_Color_Brightness(color, -0.3);
                    current_button.Font = new Font("Segoe UI Semibold",
                        11.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    SubTitle_Label.Text = sub_title;
                    Image_Label.Image = img;
                }
            }
        }

        private void Deactivate_Button()
        {
            foreach (Control previous_button in Menu_Buttons_FlowLayoutPanel.Controls)
            {
                if (previous_button.GetType() == typeof(Button))
                {
                    previous_button.BackColor = Color.FromArgb(41, 39, 40);
                    previous_button.ForeColor = Color.White;
                    previous_button.Font = new System.Drawing.Font("Segoe UI Semibold",
                        10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    Title_Panel.BackColor = Color.FromArgb(0, 134, 138);
                }
            }
        }

        private void Add_Control(Control control)
        {
            active_control = control;
            Controls_Panel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            Controls_Panel.Controls.Add(control);
        }

        private void Manage_Students_Button_Click(object sender, EventArgs e)
        {
            if (active_control.Name != student_control.Name || msg == "")
            {
                msg = "";
                Activate_Button(sender, "Manage Students",
                    new Bitmap(Properties.Resources.students_40px_black, 50, 50));
                student = new Student(this);
                Add_Control(student);
            }
            else if(msg != "")
            {
                Add_Control(reserved_control);
            }
        }

        private void Manage_Clos_Button_Click(object sender, EventArgs e)
        {
            if(active_control.Name != clo_control.Name)
            {
                Activate_Button(sender, "Manage CLO's",
                   new Bitmap(Properties.Resources.course_40px_black, 50, 50));
                Add_Control(new CLOs());
            }
        }

        private void Manage_Rubrics_Button_Click(object sender, EventArgs e)
        {
            if (active_control.Name != rubrics_control.Name)
            {
                Activate_Button(sender, "Manage Rubrics",
                   new Bitmap(Properties.Resources.combo_chart_40px_black, 50, 50));
                Add_Control(new Rubrics());
            }
        }

        private void Manage_Assessments_Button_Click(object sender, EventArgs e)
        {
            if(active_control.Name != assessments_control.Name)
            {
                Activate_Button(sender, "Manage Assessments",
                    new Bitmap(Properties.Resources.assessments_40px_black, 50, 50));
                assessment = new Assessments(this);
                Add_Control(assessment);
            }
            else if (msg != "")
            {
                Add_Control(reserved_control);
            }
        }

        private void Manage_RubricLevels_Button_Click(object sender, EventArgs e)
        {
            if(active_control.Name != rubric_levels_control.Name)
            {
                Activate_Button(sender, "Manage Rubric Levels",
                    new Bitmap(Properties.Resources.signal_40px_black, 50, 50));
                Add_Control(new Rubric_Levels());
            }
        }

        private void Evaluate_Students_Button_Click(object sender, EventArgs e)
        {
            if(student_evaluation.Name != active_control.Name || msg == "")
            {
                msg = "";
                Activate_Button(sender, "Evaluate Students",
                    new Bitmap(Properties.Resources.test_40px_black, 50, 50));
                student_evaluation_control = new Student_Assessment_Evaluation(this);
                Add_Control(student_evaluation_control);
            }
            else if(msg != "")
            {
                Add_Control(reserved_control);
            }
        }

        private void Title_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Runner_Load(object sender, EventArgs e)
        {
            Manage_Students_Button.PerformClick();
        }

        //
        // Working to enabling resizing and draggig the Borderless winform
        //
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(41, 39, 40)))
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
        }

        // For dragging
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg,
            int wParam, int lParam);

        // Resize Code
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;

            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          

                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            base.WndProc(ref m);
        } // End of Resize Code 

        private void Runner_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.Padding = new Padding(8, 8, 8, 0);
            }
            else
            {
                if(this.Padding.Top != border_size)
                {
                    this.Padding = new Padding(border_size);
                }
            }
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Maximize_Button_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
