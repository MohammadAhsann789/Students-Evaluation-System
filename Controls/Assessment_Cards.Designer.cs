
namespace Students_Evaluation_System.Controls
{
    partial class Assessment_Cards
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
            this.Back_Panel = new System.Windows.Forms.Panel();
            this.Card = new Bunifu.Framework.UI.BunifuCards();
            this.Date_Label = new System.Windows.Forms.Label();
            this.Assessment_Title_Label = new System.Windows.Forms.Label();
            this.Counter_Label = new System.Windows.Forms.Label();
            this.Assessments_Cards_PictureBox = new System.Windows.Forms.PictureBox();
            this.Marks_Label = new System.Windows.Forms.Label();
            this.Weightage_Label = new System.Windows.Forms.Label();
            this.Assessment_Counter_Label = new System.Windows.Forms.Label();
            this.Total_Marks_Label = new System.Windows.Forms.Label();
            this.Total_Weightage_Label = new System.Windows.Forms.Label();
            this.Created_Date_Label = new System.Windows.Forms.Label();
            this.Back_Panel.SuspendLayout();
            this.Card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Assessments_Cards_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Back_Panel
            // 
            this.Back_Panel.Controls.Add(this.Card);
            this.Back_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Back_Panel.Location = new System.Drawing.Point(0, 0);
            this.Back_Panel.Name = "Back_Panel";
            this.Back_Panel.Size = new System.Drawing.Size(360, 244);
            this.Back_Panel.TabIndex = 0;
            // 
            // Card
            // 
            this.Card.BackColor = System.Drawing.Color.White;
            this.Card.BorderRadius = 8;
            this.Card.BottomSahddow = true;
            this.Card.color = System.Drawing.Color.Black;
            this.Card.Controls.Add(this.Created_Date_Label);
            this.Card.Controls.Add(this.Total_Weightage_Label);
            this.Card.Controls.Add(this.Total_Marks_Label);
            this.Card.Controls.Add(this.Assessment_Counter_Label);
            this.Card.Controls.Add(this.Weightage_Label);
            this.Card.Controls.Add(this.Marks_Label);
            this.Card.Controls.Add(this.Date_Label);
            this.Card.Controls.Add(this.Assessment_Title_Label);
            this.Card.Controls.Add(this.Counter_Label);
            this.Card.Controls.Add(this.Assessments_Cards_PictureBox);
            this.Card.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Card.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card.LeftSahddow = true;
            this.Card.Location = new System.Drawing.Point(0, 0);
            this.Card.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.Card.Name = "Card";
            this.Card.RightSahddow = true;
            this.Card.ShadowDepth = 25;
            this.Card.Size = new System.Drawing.Size(360, 244);
            this.Card.TabIndex = 1;
            this.Card.Click += new System.EventHandler(this.Card_Click);
            // 
            // Date_Label
            // 
            this.Date_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Date_Label.AutoSize = true;
            this.Date_Label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_Label.Location = new System.Drawing.Point(64, 165);
            this.Date_Label.Name = "Date_Label";
            this.Date_Label.Size = new System.Drawing.Size(120, 23);
            this.Date_Label.TabIndex = 4;
            this.Date_Label.Text = "Created Date: ";
            this.Date_Label.Click += new System.EventHandler(this.Card_Click);
            // 
            // Assessment_Title_Label
            // 
            this.Assessment_Title_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Assessment_Title_Label.AutoSize = true;
            this.Assessment_Title_Label.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Assessment_Title_Label.Location = new System.Drawing.Point(98, 134);
            this.Assessment_Title_Label.Name = "Assessment_Title_Label";
            this.Assessment_Title_Label.Size = new System.Drawing.Size(156, 31);
            this.Assessment_Title_Label.TabIndex = 3;
            this.Assessment_Title_Label.Text = "DB Lab Quiz 1";
            this.Assessment_Title_Label.Click += new System.EventHandler(this.Card_Click);
            // 
            // Counter_Label
            // 
            this.Counter_Label.AutoSize = true;
            this.Counter_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Counter_Label.Location = new System.Drawing.Point(3, 6);
            this.Counter_Label.Name = "Counter_Label";
            this.Counter_Label.Size = new System.Drawing.Size(103, 23);
            this.Counter_Label.TabIndex = 2;
            this.Counter_Label.Text = "Assessmet #";
            this.Counter_Label.Click += new System.EventHandler(this.Card_Click);
            // 
            // Assessments_Cards_PictureBox
            // 
            this.Assessments_Cards_PictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Assessments_Cards_PictureBox.Image = global::Students_Evaluation_System.Properties.Resources.assessments_100px;
            this.Assessments_Cards_PictureBox.Location = new System.Drawing.Point(135, 31);
            this.Assessments_Cards_PictureBox.Name = "Assessments_Cards_PictureBox";
            this.Assessments_Cards_PictureBox.Size = new System.Drawing.Size(100, 100);
            this.Assessments_Cards_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Assessments_Cards_PictureBox.TabIndex = 1;
            this.Assessments_Cards_PictureBox.TabStop = false;
            this.Assessments_Cards_PictureBox.Click += new System.EventHandler(this.Card_Click);
            // 
            // Marks_Label
            // 
            this.Marks_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Marks_Label.AutoSize = true;
            this.Marks_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Marks_Label.Location = new System.Drawing.Point(19, 208);
            this.Marks_Label.Name = "Marks_Label";
            this.Marks_Label.Size = new System.Drawing.Size(100, 23);
            this.Marks_Label.TabIndex = 5;
            this.Marks_Label.Text = "Total Marks:";
            this.Marks_Label.Click += new System.EventHandler(this.Card_Click);
            // 
            // Weightage_Label
            // 
            this.Weightage_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Weightage_Label.AutoSize = true;
            this.Weightage_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Weightage_Label.Location = new System.Drawing.Point(176, 208);
            this.Weightage_Label.Name = "Weightage_Label";
            this.Weightage_Label.Size = new System.Drawing.Size(137, 23);
            this.Weightage_Label.TabIndex = 6;
            this.Weightage_Label.Text = "Total Weightage:";
            this.Weightage_Label.Click += new System.EventHandler(this.Card_Click);
            // 
            // Assessment_Counter_Label
            // 
            this.Assessment_Counter_Label.AutoSize = true;
            this.Assessment_Counter_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Assessment_Counter_Label.Location = new System.Drawing.Point(110, 6);
            this.Assessment_Counter_Label.Name = "Assessment_Counter_Label";
            this.Assessment_Counter_Label.Size = new System.Drawing.Size(19, 23);
            this.Assessment_Counter_Label.TabIndex = 7;
            this.Assessment_Counter_Label.Text = "1";
            this.Assessment_Counter_Label.Click += new System.EventHandler(this.Card_Click);
            // 
            // Total_Marks_Label
            // 
            this.Total_Marks_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Total_Marks_Label.AutoSize = true;
            this.Total_Marks_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_Marks_Label.Location = new System.Drawing.Point(124, 208);
            this.Total_Marks_Label.Name = "Total_Marks_Label";
            this.Total_Marks_Label.Size = new System.Drawing.Size(28, 23);
            this.Total_Marks_Label.TabIndex = 8;
            this.Total_Marks_Label.Text = "50";
            this.Total_Marks_Label.Click += new System.EventHandler(this.Card_Click);
            // 
            // Total_Weightage_Label
            // 
            this.Total_Weightage_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Total_Weightage_Label.AutoSize = true;
            this.Total_Weightage_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_Weightage_Label.Location = new System.Drawing.Point(319, 208);
            this.Total_Weightage_Label.Name = "Total_Weightage_Label";
            this.Total_Weightage_Label.Size = new System.Drawing.Size(28, 23);
            this.Total_Weightage_Label.TabIndex = 9;
            this.Total_Weightage_Label.Text = "50";
            this.Total_Weightage_Label.Click += new System.EventHandler(this.Card_Click);
            // 
            // Created_Date_Label
            // 
            this.Created_Date_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Created_Date_Label.AutoSize = true;
            this.Created_Date_Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Created_Date_Label.Location = new System.Drawing.Point(176, 165);
            this.Created_Date_Label.Name = "Created_Date_Label";
            this.Created_Date_Label.Size = new System.Drawing.Size(126, 23);
            this.Created_Date_Label.TabIndex = 10;
            this.Created_Date_Label.Text = "March 25, 2022";
            this.Created_Date_Label.Click += new System.EventHandler(this.Card_Click);
            // 
            // Assessment_Cards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Back_Panel);
            this.Name = "Assessment_Cards";
            this.Size = new System.Drawing.Size(360, 244);
            this.Back_Panel.ResumeLayout(false);
            this.Card.ResumeLayout(false);
            this.Card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Assessments_Cards_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Back_Panel;
        private Bunifu.Framework.UI.BunifuCards Card;
        private System.Windows.Forms.Label Date_Label;
        private System.Windows.Forms.Label Assessment_Title_Label;
        private System.Windows.Forms.Label Counter_Label;
        private System.Windows.Forms.PictureBox Assessments_Cards_PictureBox;
        private System.Windows.Forms.Label Marks_Label;
        private System.Windows.Forms.Label Weightage_Label;
        private System.Windows.Forms.Label Assessment_Counter_Label;
        private System.Windows.Forms.Label Total_Marks_Label;
        private System.Windows.Forms.Label Total_Weightage_Label;
        private System.Windows.Forms.Label Created_Date_Label;
    }
}
