
namespace Students_Evaluation_System.Controls
{
    partial class Student_Assessment_Evaluation
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Reg_No_Label = new System.Windows.Forms.Label();
            this.Student_Reg_No_Combobox = new Bunifu.UI.WinForms.BunifuDropdown();
            this.Back_Panel = new System.Windows.Forms.Panel();
            this.Assessment_Cards_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.Back_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.59597F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.40403F));
            this.tableLayoutPanel1.Controls.Add(this.Reg_No_Label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Student_Reg_No_Combobox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1141, 69);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // Reg_No_Label
            // 
            this.Reg_No_Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Reg_No_Label.AutoSize = true;
            this.Reg_No_Label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reg_No_Label.Location = new System.Drawing.Point(59, 23);
            this.Reg_No_Label.Name = "Reg_No_Label";
            this.Reg_No_Label.Size = new System.Drawing.Size(173, 23);
            this.Reg_No_Label.TabIndex = 14;
            this.Reg_No_Label.Text = "Registration Number:";
            // 
            // Student_Reg_No_Combobox
            // 
            this.Student_Reg_No_Combobox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Student_Reg_No_Combobox.BackColor = System.Drawing.Color.White;
            this.Student_Reg_No_Combobox.BorderRadius = 1;
            this.Student_Reg_No_Combobox.Color = System.Drawing.Color.Silver;
            this.Student_Reg_No_Combobox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Student_Reg_No_Combobox.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.Student_Reg_No_Combobox.DisabledColor = System.Drawing.Color.Gray;
            this.Student_Reg_No_Combobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Student_Reg_No_Combobox.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.Student_Reg_No_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Student_Reg_No_Combobox.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.Student_Reg_No_Combobox.FillDropDown = false;
            this.Student_Reg_No_Combobox.FillIndicator = false;
            this.Student_Reg_No_Combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Student_Reg_No_Combobox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Student_Reg_No_Combobox.ForeColor = System.Drawing.Color.Black;
            this.Student_Reg_No_Combobox.FormattingEnabled = true;
            this.Student_Reg_No_Combobox.Icon = null;
            this.Student_Reg_No_Combobox.IndicatorColor = System.Drawing.Color.Black;
            this.Student_Reg_No_Combobox.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.Student_Reg_No_Combobox.ItemBackColor = System.Drawing.Color.White;
            this.Student_Reg_No_Combobox.ItemBorderColor = System.Drawing.Color.White;
            this.Student_Reg_No_Combobox.ItemForeColor = System.Drawing.Color.Black;
            this.Student_Reg_No_Combobox.ItemHeight = 26;
            this.Student_Reg_No_Combobox.ItemHighLightColor = System.Drawing.Color.LightBlue;
            this.Student_Reg_No_Combobox.Location = new System.Drawing.Point(238, 18);
            this.Student_Reg_No_Combobox.Name = "Student_Reg_No_Combobox";
            this.Student_Reg_No_Combobox.Size = new System.Drawing.Size(288, 32);
            this.Student_Reg_No_Combobox.TabIndex = 13;
            this.Student_Reg_No_Combobox.Text = null;
            this.Student_Reg_No_Combobox.SelectedValueChanged += new System.EventHandler(this.Student_Reg_No_Combobox_SelectedValueChanged);
            // 
            // Back_Panel
            // 
            this.Back_Panel.Controls.Add(this.Assessment_Cards_FlowLayoutPanel);
            this.Back_Panel.Controls.Add(this.tableLayoutPanel1);
            this.Back_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Back_Panel.Location = new System.Drawing.Point(0, 0);
            this.Back_Panel.Name = "Back_Panel";
            this.Back_Panel.Size = new System.Drawing.Size(1141, 643);
            this.Back_Panel.TabIndex = 0;
            // 
            // Assessment_Cards_FlowLayoutPanel
            // 
            this.Assessment_Cards_FlowLayoutPanel.AutoScroll = true;
            this.Assessment_Cards_FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Assessment_Cards_FlowLayoutPanel.Location = new System.Drawing.Point(0, 69);
            this.Assessment_Cards_FlowLayoutPanel.Name = "Assessment_Cards_FlowLayoutPanel";
            this.Assessment_Cards_FlowLayoutPanel.Size = new System.Drawing.Size(1141, 574);
            this.Assessment_Cards_FlowLayoutPanel.TabIndex = 17;
            // 
            // Student_Assessment_Evaluation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Back_Panel);
            this.Name = "Student_Assessment_Evaluation";
            this.Size = new System.Drawing.Size(1141, 643);
            this.Load += new System.EventHandler(this.Student_Evaluation_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Back_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Reg_No_Label;
        private Bunifu.UI.WinForms.BunifuDropdown Student_Reg_No_Combobox;
        private System.Windows.Forms.Panel Back_Panel;
        private System.Windows.Forms.FlowLayoutPanel Assessment_Cards_FlowLayoutPanel;
    }
}
