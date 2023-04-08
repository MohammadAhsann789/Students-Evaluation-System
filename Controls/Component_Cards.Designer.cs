
namespace Students_Evaluation_System.Controls
{
    partial class Component_Cards
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Evaluate_Btn_Ellipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Evaluate_Button = new System.Windows.Forms.Button();
            this.Back_Panel = new System.Windows.Forms.Panel();
            this.Card = new Bunifu.Framework.UI.BunifuCards();
            this.Achieved_Level_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Obtained_Marks_Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Rubric_Levels_Combobox = new Bunifu.UI.WinForms.BunifuDropdown();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Total_Marks_Label = new System.Windows.Forms.Label();
            this.Marks_Label = new System.Windows.Forms.Label();
            this.Update_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Component_Rubric_Name_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Componnt_Name_Label = new System.Windows.Forms.Label();
            this.Component_Label = new System.Windows.Forms.Label();
            this.Assessments_Cards_PictureBox = new System.Windows.Forms.PictureBox();
            this.Counter_Label = new System.Windows.Forms.Label();
            this.Component_Counter_Label = new System.Windows.Forms.Label();
            this.Created_Date_Label = new System.Windows.Forms.Label();
            this.Date_Label = new System.Windows.Forms.Label();
            this.Update_Btn_Ellipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Delete_Btn_Ellipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Back_Panel.SuspendLayout();
            this.Card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Assessments_Cards_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Evaluate_Btn_Ellipse
            // 
            this.Evaluate_Btn_Ellipse.ElipseRadius = 15;
            this.Evaluate_Btn_Ellipse.TargetControl = this.Evaluate_Button;
            // 
            // Evaluate_Button
            // 
            this.Evaluate_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Evaluate_Button.BackColor = System.Drawing.Color.DodgerBlue;
            this.Evaluate_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Evaluate_Button.FlatAppearance.BorderSize = 0;
            this.Evaluate_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Evaluate_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Evaluate_Button.ForeColor = System.Drawing.Color.White;
            this.Evaluate_Button.Location = new System.Drawing.Point(583, 282);
            this.Evaluate_Button.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Evaluate_Button.Name = "Evaluate_Button";
            this.Evaluate_Button.Size = new System.Drawing.Size(139, 40);
            this.Evaluate_Button.TabIndex = 16;
            this.Evaluate_Button.Text = "Evaluate";
            this.Evaluate_Button.UseVisualStyleBackColor = false;
            this.Evaluate_Button.Click += new System.EventHandler(this.Evaluate_Button_Click);
            // 
            // Back_Panel
            // 
            this.Back_Panel.Controls.Add(this.Card);
            this.Back_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Back_Panel.Location = new System.Drawing.Point(0, 0);
            this.Back_Panel.Name = "Back_Panel";
            this.Back_Panel.Size = new System.Drawing.Size(747, 341);
            this.Back_Panel.TabIndex = 0;
            // 
            // Card
            // 
            this.Card.BackColor = System.Drawing.Color.White;
            this.Card.BorderRadius = 8;
            this.Card.BottomSahddow = true;
            this.Card.color = System.Drawing.Color.Black;
            this.Card.Controls.Add(this.Achieved_Level_Label);
            this.Card.Controls.Add(this.label2);
            this.Card.Controls.Add(this.Obtained_Marks_Label);
            this.Card.Controls.Add(this.label4);
            this.Card.Controls.Add(this.Rubric_Levels_Combobox);
            this.Card.Controls.Add(this.Delete_Button);
            this.Card.Controls.Add(this.Total_Marks_Label);
            this.Card.Controls.Add(this.Marks_Label);
            this.Card.Controls.Add(this.Update_Button);
            this.Card.Controls.Add(this.Evaluate_Button);
            this.Card.Controls.Add(this.label3);
            this.Card.Controls.Add(this.Component_Rubric_Name_Label);
            this.Card.Controls.Add(this.label1);
            this.Card.Controls.Add(this.Componnt_Name_Label);
            this.Card.Controls.Add(this.Component_Label);
            this.Card.Controls.Add(this.Assessments_Cards_PictureBox);
            this.Card.Controls.Add(this.Counter_Label);
            this.Card.Controls.Add(this.Component_Counter_Label);
            this.Card.Controls.Add(this.Created_Date_Label);
            this.Card.Controls.Add(this.Date_Label);
            this.Card.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Card.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card.LeftSahddow = true;
            this.Card.Location = new System.Drawing.Point(0, 0);
            this.Card.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.Card.Name = "Card";
            this.Card.RightSahddow = true;
            this.Card.ShadowDepth = 25;
            this.Card.Size = new System.Drawing.Size(747, 341);
            this.Card.TabIndex = 3;
            // 
            // Achieved_Level_Label
            // 
            this.Achieved_Level_Label.AutoSize = true;
            this.Achieved_Level_Label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Achieved_Level_Label.Location = new System.Drawing.Point(330, 172);
            this.Achieved_Level_Label.Name = "Achieved_Level_Label";
            this.Achieved_Level_Label.Size = new System.Drawing.Size(28, 23);
            this.Achieved_Level_Label.TabIndex = 25;
            this.Achieved_Level_Label.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 28);
            this.label2.TabIndex = 24;
            this.label2.Text = "Achieved Measurement Level:";
            // 
            // Obtained_Marks_Label
            // 
            this.Obtained_Marks_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Obtained_Marks_Label.AutoSize = true;
            this.Obtained_Marks_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Obtained_Marks_Label.Location = new System.Drawing.Point(701, 60);
            this.Obtained_Marks_Label.Name = "Obtained_Marks_Label";
            this.Obtained_Marks_Label.Size = new System.Drawing.Size(41, 23);
            this.Obtained_Marks_Label.TabIndex = 23;
            this.Obtained_Marks_Label.Text = "N/A";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(554, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Obtained Marks:";
            // 
            // Rubric_Levels_Combobox
            // 
            this.Rubric_Levels_Combobox.BackColor = System.Drawing.Color.White;
            this.Rubric_Levels_Combobox.BorderRadius = 1;
            this.Rubric_Levels_Combobox.Color = System.Drawing.Color.Silver;
            this.Rubric_Levels_Combobox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rubric_Levels_Combobox.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.Rubric_Levels_Combobox.DisabledColor = System.Drawing.Color.Gray;
            this.Rubric_Levels_Combobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Rubric_Levels_Combobox.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.Rubric_Levels_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Rubric_Levels_Combobox.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.Rubric_Levels_Combobox.FillDropDown = false;
            this.Rubric_Levels_Combobox.FillIndicator = false;
            this.Rubric_Levels_Combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Rubric_Levels_Combobox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Rubric_Levels_Combobox.ForeColor = System.Drawing.Color.Black;
            this.Rubric_Levels_Combobox.FormattingEnabled = true;
            this.Rubric_Levels_Combobox.Icon = null;
            this.Rubric_Levels_Combobox.IndicatorColor = System.Drawing.Color.Black;
            this.Rubric_Levels_Combobox.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.Rubric_Levels_Combobox.ItemBackColor = System.Drawing.Color.White;
            this.Rubric_Levels_Combobox.ItemBorderColor = System.Drawing.Color.White;
            this.Rubric_Levels_Combobox.ItemForeColor = System.Drawing.Color.Black;
            this.Rubric_Levels_Combobox.ItemHeight = 26;
            this.Rubric_Levels_Combobox.ItemHighLightColor = System.Drawing.Color.LightBlue;
            this.Rubric_Levels_Combobox.Items.AddRange(new object[] {
            "CLO Name",
            "Created Date",
            "Updated Date"});
            this.Rubric_Levels_Combobox.Location = new System.Drawing.Point(337, 218);
            this.Rubric_Levels_Combobox.Name = "Rubric_Levels_Combobox";
            this.Rubric_Levels_Combobox.Size = new System.Drawing.Size(282, 32);
            this.Rubric_Levels_Combobox.TabIndex = 21;
            this.Rubric_Levels_Combobox.Text = null;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.BackColor = System.Drawing.Color.DodgerBlue;
            this.Delete_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_Button.FlatAppearance.BorderSize = 0;
            this.Delete_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_Button.ForeColor = System.Drawing.Color.White;
            this.Delete_Button.Location = new System.Drawing.Point(292, 282);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(139, 40);
            this.Delete_Button.TabIndex = 20;
            this.Delete_Button.Text = "Delete";
            this.Delete_Button.UseVisualStyleBackColor = false;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Total_Marks_Label
            // 
            this.Total_Marks_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Total_Marks_Label.AutoSize = true;
            this.Total_Marks_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_Marks_Label.Location = new System.Drawing.Point(701, 37);
            this.Total_Marks_Label.Name = "Total_Marks_Label";
            this.Total_Marks_Label.Size = new System.Drawing.Size(28, 23);
            this.Total_Marks_Label.TabIndex = 19;
            this.Total_Marks_Label.Text = "50";
            // 
            // Marks_Label
            // 
            this.Marks_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Marks_Label.AutoSize = true;
            this.Marks_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Marks_Label.Location = new System.Drawing.Point(589, 36);
            this.Marks_Label.Name = "Marks_Label";
            this.Marks_Label.Size = new System.Drawing.Size(100, 23);
            this.Marks_Label.TabIndex = 18;
            this.Marks_Label.Text = "Total Marks:";
            // 
            // Update_Button
            // 
            this.Update_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Update_Button.BackColor = System.Drawing.Color.DodgerBlue;
            this.Update_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Update_Button.FlatAppearance.BorderSize = 0;
            this.Update_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_Button.ForeColor = System.Drawing.Color.White;
            this.Update_Button.Location = new System.Drawing.Point(437, 282);
            this.Update_Button.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Update_Button.Name = "Update_Button";
            this.Update_Button.Size = new System.Drawing.Size(139, 40);
            this.Update_Button.TabIndex = 17;
            this.Update_Button.Text = "Update";
            this.Update_Button.UseVisualStyleBackColor = false;
            this.Update_Button.Click += new System.EventHandler(this.Update_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "Rubric Measurement Level:";
            // 
            // Component_Rubric_Name_Label
            // 
            this.Component_Rubric_Name_Label.AutoSize = true;
            this.Component_Rubric_Name_Label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Component_Rubric_Name_Label.Location = new System.Drawing.Point(224, 132);
            this.Component_Rubric_Name_Label.Name = "Component_Rubric_Name_Label";
            this.Component_Rubric_Name_Label.Size = new System.Drawing.Size(128, 23);
            this.Component_Rubric_Name_Label.TabIndex = 13;
            this.Component_Rubric_Name_Label.Text = "Rubric of CLO 7";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 131);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Component Rubric:";
            // 
            // Componnt_Name_Label
            // 
            this.Componnt_Name_Label.AutoSize = true;
            this.Componnt_Name_Label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Componnt_Name_Label.Location = new System.Drawing.Point(161, 94);
            this.Componnt_Name_Label.Name = "Componnt_Name_Label";
            this.Componnt_Name_Label.Size = new System.Drawing.Size(357, 23);
            this.Componnt_Name_Label.TabIndex = 5;
            this.Componnt_Name_Label.Text = "How will you find the height of Tree in  node?";
            // 
            // Component_Label
            // 
            this.Component_Label.AutoSize = true;
            this.Component_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Component_Label.Location = new System.Drawing.Point(30, 90);
            this.Component_Label.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.Component_Label.Name = "Component_Label";
            this.Component_Label.Size = new System.Drawing.Size(125, 28);
            this.Component_Label.TabIndex = 4;
            this.Component_Label.Text = "Component:";
            // 
            // Assessments_Cards_PictureBox
            // 
            this.Assessments_Cards_PictureBox.Image = global::Students_Evaluation_System.Properties.Resources.assessments_100px;
            this.Assessments_Cards_PictureBox.Location = new System.Drawing.Point(15, 26);
            this.Assessments_Cards_PictureBox.Name = "Assessments_Cards_PictureBox";
            this.Assessments_Cards_PictureBox.Size = new System.Drawing.Size(40, 40);
            this.Assessments_Cards_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Assessments_Cards_PictureBox.TabIndex = 1;
            this.Assessments_Cards_PictureBox.TabStop = false;
            // 
            // Counter_Label
            // 
            this.Counter_Label.AutoSize = true;
            this.Counter_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Counter_Label.Location = new System.Drawing.Point(61, 35);
            this.Counter_Label.Name = "Counter_Label";
            this.Counter_Label.Size = new System.Drawing.Size(116, 23);
            this.Counter_Label.TabIndex = 2;
            this.Counter_Label.Text = "Component #";
            // 
            // Component_Counter_Label
            // 
            this.Component_Counter_Label.AutoSize = true;
            this.Component_Counter_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Component_Counter_Label.Location = new System.Drawing.Point(181, 36);
            this.Component_Counter_Label.Name = "Component_Counter_Label";
            this.Component_Counter_Label.Size = new System.Drawing.Size(19, 23);
            this.Component_Counter_Label.TabIndex = 7;
            this.Component_Counter_Label.Text = "1";
            // 
            // Created_Date_Label
            // 
            this.Created_Date_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Created_Date_Label.AutoSize = true;
            this.Created_Date_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Created_Date_Label.Location = new System.Drawing.Point(383, 13);
            this.Created_Date_Label.Name = "Created_Date_Label";
            this.Created_Date_Label.Size = new System.Drawing.Size(126, 23);
            this.Created_Date_Label.TabIndex = 10;
            this.Created_Date_Label.Text = "March 25, 2022";
            // 
            // Date_Label
            // 
            this.Date_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Date_Label.AutoSize = true;
            this.Date_Label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_Label.Location = new System.Drawing.Point(262, 14);
            this.Date_Label.Name = "Date_Label";
            this.Date_Label.Size = new System.Drawing.Size(120, 23);
            this.Date_Label.TabIndex = 4;
            this.Date_Label.Text = "Created Date: ";
            // 
            // Update_Btn_Ellipse
            // 
            this.Update_Btn_Ellipse.ElipseRadius = 15;
            this.Update_Btn_Ellipse.TargetControl = this.Update_Button;
            // 
            // Delete_Btn_Ellipse
            // 
            this.Delete_Btn_Ellipse.ElipseRadius = 15;
            this.Delete_Btn_Ellipse.TargetControl = this.Delete_Button;
            // 
            // Component_Cards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Back_Panel);
            this.Name = "Component_Cards";
            this.Size = new System.Drawing.Size(747, 341);
            this.Load += new System.EventHandler(this.Component_Cards_Load);
            this.Back_Panel.ResumeLayout(false);
            this.Card.ResumeLayout(false);
            this.Card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Assessments_Cards_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse Evaluate_Btn_Ellipse;
        private System.Windows.Forms.Panel Back_Panel;
        private Bunifu.Framework.UI.BunifuCards Card;
        private System.Windows.Forms.Button Update_Button;
        private System.Windows.Forms.Button Evaluate_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Component_Rubric_Name_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Componnt_Name_Label;
        private System.Windows.Forms.Label Component_Label;
        private System.Windows.Forms.PictureBox Assessments_Cards_PictureBox;
        private System.Windows.Forms.Label Counter_Label;
        private System.Windows.Forms.Label Component_Counter_Label;
        private System.Windows.Forms.Label Created_Date_Label;
        private System.Windows.Forms.Label Date_Label;
        private Bunifu.Framework.UI.BunifuElipse Update_Btn_Ellipse;
        private System.Windows.Forms.Label Total_Marks_Label;
        private System.Windows.Forms.Label Marks_Label;
        private System.Windows.Forms.Button Delete_Button;
        private Bunifu.Framework.UI.BunifuElipse Delete_Btn_Ellipse;
        private Bunifu.UI.WinForms.BunifuDropdown Rubric_Levels_Combobox;
        private System.Windows.Forms.Label Obtained_Marks_Label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Achieved_Level_Label;
        private System.Windows.Forms.Label label2;
    }
}
