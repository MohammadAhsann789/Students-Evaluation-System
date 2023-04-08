
namespace Students_Evaluation_System.Controls
{
    partial class Attendence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendence));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Back_Panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Search_Textbox = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.Filter_By_Combobox = new Bunifu.UI.WinForms.BunifuDropdown();
            this.Search_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Attendence_Status_Combobox = new Bunifu.UI.WinForms.BunifuDropdown();
            this.Filter_By_Label = new System.Windows.Forms.Label();
            this.Attendence_Label = new System.Windows.Forms.Label();
            this.Attendences_Date_Combobox = new Bunifu.UI.WinForms.BunifuDropdown();
            this.Create_Date_Button = new System.Windows.Forms.Button();
            this.Class_Attendence_Date_DateTime = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Delet_All_Attendences_Button = new System.Windows.Forms.Button();
            this.Data_Panel = new System.Windows.Forms.Panel();
            this.Attendences_DataGridView = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.Create_Date_Btn_Ellipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Delete_All_Attendences_Btn_Ellipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Attendence_Report_Button = new System.Windows.Forms.Button();
            this.Attendence_Report_Btn_Ellipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Back_Panel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.Data_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Attendences_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Back_Panel
            // 
            this.Back_Panel.Controls.Add(this.tableLayoutPanel1);
            this.Back_Panel.Controls.Add(this.flowLayoutPanel1);
            this.Back_Panel.Controls.Add(this.Data_Panel);
            this.Back_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Back_Panel.Location = new System.Drawing.Point(0, 0);
            this.Back_Panel.Name = "Back_Panel";
            this.Back_Panel.Size = new System.Drawing.Size(980, 640);
            this.Back_Panel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.99591F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.60736F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.31493F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0818F));
            this.tableLayoutPanel1.Controls.Add(this.Search_Textbox, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Filter_By_Combobox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Search_Label, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Attendence_Status_Combobox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Filter_By_Label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Attendence_Label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Attendences_Date_Combobox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Create_Date_Button, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Class_Attendence_Date_DateTime, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(980, 213);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // Search_Textbox
            // 
            this.Search_Textbox.AcceptsReturn = false;
            this.Search_Textbox.AcceptsTab = false;
            this.Search_Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Search_Textbox.AnimationSpeed = 200;
            this.Search_Textbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.Search_Textbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.Search_Textbox.BackColor = System.Drawing.Color.Transparent;
            this.Search_Textbox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Search_Textbox.BackgroundImage")));
            this.Search_Textbox.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.Search_Textbox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.Search_Textbox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.Search_Textbox.BorderColorIdle = System.Drawing.Color.Silver;
            this.Search_Textbox.BorderRadius = 15;
            this.Search_Textbox.BorderThickness = 1;
            this.Search_Textbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Search_Textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Search_Textbox.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.Search_Textbox.DefaultText = "";
            this.Search_Textbox.FillColor = System.Drawing.Color.White;
            this.Search_Textbox.HideSelection = true;
            this.Search_Textbox.IconLeft = null;
            this.Search_Textbox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.Search_Textbox.IconPadding = 10;
            this.Search_Textbox.IconRight = null;
            this.Search_Textbox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.Search_Textbox.Lines = new string[0];
            this.Search_Textbox.Location = new System.Drawing.Point(589, 158);
            this.Search_Textbox.Margin = new System.Windows.Forms.Padding(3, 3, 145, 3);
            this.Search_Textbox.MaxLength = 32767;
            this.Search_Textbox.MinimumSize = new System.Drawing.Size(100, 35);
            this.Search_Textbox.Modified = false;
            this.Search_Textbox.Multiline = false;
            this.Search_Textbox.Name = "Search_Textbox";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.Search_Textbox.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.Empty;
            stateProperties6.FillColor = System.Drawing.Color.White;
            stateProperties6.ForeColor = System.Drawing.Color.Empty;
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.Search_Textbox.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.Search_Textbox.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.Search_Textbox.OnIdleState = stateProperties8;
            this.Search_Textbox.PasswordChar = '\0';
            this.Search_Textbox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.Search_Textbox.PlaceholderText = "";
            this.Search_Textbox.ReadOnly = false;
            this.Search_Textbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Search_Textbox.SelectedText = "";
            this.Search_Textbox.SelectionLength = 0;
            this.Search_Textbox.SelectionStart = 0;
            this.Search_Textbox.ShortcutsEnabled = true;
            this.Search_Textbox.Size = new System.Drawing.Size(246, 38);
            this.Search_Textbox.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.Search_Textbox.TabIndex = 4;
            this.Search_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Search_Textbox.TextMarginBottom = 0;
            this.Search_Textbox.TextMarginLeft = 5;
            this.Search_Textbox.TextMarginTop = 0;
            this.Search_Textbox.TextPlaceholder = "";
            this.Search_Textbox.UseSystemPasswordChar = false;
            this.Search_Textbox.WordWrap = true;
            this.Search_Textbox.TextChange += new System.EventHandler(this.Search_Textbox_TextChange);
            // 
            // Filter_By_Combobox
            // 
            this.Filter_By_Combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Filter_By_Combobox.BackColor = System.Drawing.Color.White;
            this.Filter_By_Combobox.BorderRadius = 1;
            this.Filter_By_Combobox.Color = System.Drawing.Color.Silver;
            this.Filter_By_Combobox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Filter_By_Combobox.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.Filter_By_Combobox.DisabledColor = System.Drawing.Color.Gray;
            this.Filter_By_Combobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Filter_By_Combobox.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.Filter_By_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Filter_By_Combobox.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.Filter_By_Combobox.FillDropDown = false;
            this.Filter_By_Combobox.FillIndicator = false;
            this.Filter_By_Combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Filter_By_Combobox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Filter_By_Combobox.ForeColor = System.Drawing.Color.Black;
            this.Filter_By_Combobox.FormattingEnabled = true;
            this.Filter_By_Combobox.Icon = null;
            this.Filter_By_Combobox.IndicatorColor = System.Drawing.Color.Black;
            this.Filter_By_Combobox.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.Filter_By_Combobox.ItemBackColor = System.Drawing.Color.White;
            this.Filter_By_Combobox.ItemBorderColor = System.Drawing.Color.White;
            this.Filter_By_Combobox.ItemForeColor = System.Drawing.Color.Black;
            this.Filter_By_Combobox.ItemHeight = 26;
            this.Filter_By_Combobox.ItemHighLightColor = System.Drawing.Color.LightBlue;
            this.Filter_By_Combobox.Items.AddRange(new object[] {
            "Registration Number",
            "First Name",
            "Last Name",
            "Contact",
            "Email"});
            this.Filter_By_Combobox.Location = new System.Drawing.Point(179, 161);
            this.Filter_By_Combobox.Name = "Filter_By_Combobox";
            this.Filter_By_Combobox.Size = new System.Drawing.Size(264, 32);
            this.Filter_By_Combobox.TabIndex = 8;
            this.Filter_By_Combobox.Text = null;
            // 
            // Search_Label
            // 
            this.Search_Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Search_Label.AutoSize = true;
            this.Search_Label.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_Label.Location = new System.Drawing.Point(510, 165);
            this.Search_Label.Name = "Search_Label";
            this.Search_Label.Size = new System.Drawing.Size(73, 25);
            this.Search_Label.TabIndex = 5;
            this.Search_Label.Text = "Search:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(483, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Date:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "Class Attednece Date:";
            // 
            // Attendence_Status_Combobox
            // 
            this.Attendence_Status_Combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Attendence_Status_Combobox.BackColor = System.Drawing.Color.White;
            this.Attendence_Status_Combobox.BorderRadius = 1;
            this.Attendence_Status_Combobox.Color = System.Drawing.Color.Silver;
            this.Attendence_Status_Combobox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Attendence_Status_Combobox.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.Attendence_Status_Combobox.DisabledColor = System.Drawing.Color.Gray;
            this.Attendence_Status_Combobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Attendence_Status_Combobox.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.Attendence_Status_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Attendence_Status_Combobox.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.Attendence_Status_Combobox.FillDropDown = false;
            this.Attendence_Status_Combobox.FillIndicator = false;
            this.Attendence_Status_Combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Attendence_Status_Combobox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Attendence_Status_Combobox.ForeColor = System.Drawing.Color.Black;
            this.Attendence_Status_Combobox.FormattingEnabled = true;
            this.Attendence_Status_Combobox.Icon = null;
            this.Attendence_Status_Combobox.IndicatorColor = System.Drawing.Color.Black;
            this.Attendence_Status_Combobox.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.Attendence_Status_Combobox.ItemBackColor = System.Drawing.Color.White;
            this.Attendence_Status_Combobox.ItemBorderColor = System.Drawing.Color.White;
            this.Attendence_Status_Combobox.ItemForeColor = System.Drawing.Color.Black;
            this.Attendence_Status_Combobox.ItemHeight = 26;
            this.Attendence_Status_Combobox.ItemHighLightColor = System.Drawing.Color.LightBlue;
            this.Attendence_Status_Combobox.Location = new System.Drawing.Point(179, 90);
            this.Attendence_Status_Combobox.Name = "Attendence_Status_Combobox";
            this.Attendence_Status_Combobox.Size = new System.Drawing.Size(264, 32);
            this.Attendence_Status_Combobox.TabIndex = 3;
            this.Attendence_Status_Combobox.Text = null;
            // 
            // Filter_By_Label
            // 
            this.Filter_By_Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Filter_By_Label.AutoSize = true;
            this.Filter_By_Label.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_By_Label.Location = new System.Drawing.Point(90, 165);
            this.Filter_By_Label.Name = "Filter_By_Label";
            this.Filter_By_Label.Size = new System.Drawing.Size(83, 25);
            this.Filter_By_Label.TabIndex = 6;
            this.Filter_By_Label.Text = "Filter By:";
            // 
            // Attendence_Label
            // 
            this.Attendence_Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Attendence_Label.AutoSize = true;
            this.Attendence_Label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attendence_Label.Location = new System.Drawing.Point(20, 96);
            this.Attendence_Label.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Attendence_Label.Name = "Attendence_Label";
            this.Attendence_Label.Size = new System.Drawing.Size(153, 23);
            this.Attendence_Label.TabIndex = 7;
            this.Attendence_Label.Text = "Attendence Status:";
            // 
            // Attendences_Date_Combobox
            // 
            this.Attendences_Date_Combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Attendences_Date_Combobox.BackColor = System.Drawing.Color.White;
            this.Attendences_Date_Combobox.BorderRadius = 1;
            this.Attendences_Date_Combobox.Color = System.Drawing.Color.Silver;
            this.Attendences_Date_Combobox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Attendences_Date_Combobox.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.Attendences_Date_Combobox.DisabledColor = System.Drawing.Color.Gray;
            this.Attendences_Date_Combobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Attendences_Date_Combobox.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.Attendences_Date_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Attendences_Date_Combobox.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.Attendences_Date_Combobox.FillDropDown = false;
            this.Attendences_Date_Combobox.FillIndicator = false;
            this.Attendences_Date_Combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Attendences_Date_Combobox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Attendences_Date_Combobox.ForeColor = System.Drawing.Color.Black;
            this.Attendences_Date_Combobox.FormattingEnabled = true;
            this.Attendences_Date_Combobox.Icon = null;
            this.Attendences_Date_Combobox.IndicatorColor = System.Drawing.Color.Black;
            this.Attendences_Date_Combobox.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.Attendences_Date_Combobox.ItemBackColor = System.Drawing.Color.White;
            this.Attendences_Date_Combobox.ItemBorderColor = System.Drawing.Color.White;
            this.Attendences_Date_Combobox.ItemForeColor = System.Drawing.Color.Black;
            this.Attendences_Date_Combobox.ItemHeight = 26;
            this.Attendences_Date_Combobox.ItemHighLightColor = System.Drawing.Color.LightBlue;
            this.Attendences_Date_Combobox.Location = new System.Drawing.Point(589, 90);
            this.Attendences_Date_Combobox.Margin = new System.Windows.Forms.Padding(3, 3, 145, 3);
            this.Attendences_Date_Combobox.Name = "Attendences_Date_Combobox";
            this.Attendences_Date_Combobox.Size = new System.Drawing.Size(246, 32);
            this.Attendences_Date_Combobox.TabIndex = 10;
            this.Attendences_Date_Combobox.Text = null;
            this.Attendences_Date_Combobox.SelectedValueChanged += new System.EventHandler(this.Attendences_Date_Combobox_SelectedValueChanged);
            // 
            // Create_Date_Button
            // 
            this.Create_Date_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Create_Date_Button.BackColor = System.Drawing.Color.DodgerBlue;
            this.Create_Date_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Create_Date_Button.FlatAppearance.BorderSize = 0;
            this.Create_Date_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_Date_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_Date_Button.ForeColor = System.Drawing.Color.White;
            this.Create_Date_Button.Location = new System.Drawing.Point(452, 15);
            this.Create_Date_Button.Name = "Create_Date_Button";
            this.Create_Date_Button.Size = new System.Drawing.Size(131, 40);
            this.Create_Date_Button.TabIndex = 12;
            this.Create_Date_Button.Text = "Create Date";
            this.Create_Date_Button.UseVisualStyleBackColor = false;
            this.Create_Date_Button.Click += new System.EventHandler(this.Create_Date_Button_Click);
            // 
            // Class_Attendence_Date_DateTime
            // 
            this.Class_Attendence_Date_DateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Class_Attendence_Date_DateTime.BorderRadius = 1;
            this.Class_Attendence_Date_DateTime.Color = System.Drawing.Color.Silver;
            this.Class_Attendence_Date_DateTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Class_Attendence_Date_DateTime.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.Class_Attendence_Date_DateTime.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.Class_Attendence_Date_DateTime.DisabledColor = System.Drawing.Color.Gray;
            this.Class_Attendence_Date_DateTime.DisplayWeekNumbers = false;
            this.Class_Attendence_Date_DateTime.DPHeight = 0;
            this.Class_Attendence_Date_DateTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.Class_Attendence_Date_DateTime.FillDatePicker = false;
            this.Class_Attendence_Date_DateTime.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Class_Attendence_Date_DateTime.ForeColor = System.Drawing.Color.Black;
            this.Class_Attendence_Date_DateTime.Icon = ((System.Drawing.Image)(resources.GetObject("Class_Attendence_Date_DateTime.Icon")));
            this.Class_Attendence_Date_DateTime.IconColor = System.Drawing.Color.Black;
            this.Class_Attendence_Date_DateTime.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.Class_Attendence_Date_DateTime.Location = new System.Drawing.Point(179, 19);
            this.Class_Attendence_Date_DateTime.MinimumSize = new System.Drawing.Size(217, 32);
            this.Class_Attendence_Date_DateTime.Name = "Class_Attendence_Date_DateTime";
            this.Class_Attendence_Date_DateTime.Size = new System.Drawing.Size(264, 32);
            this.Class_Attendence_Date_DateTime.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Delet_All_Attendences_Button);
            this.flowLayoutPanel1.Controls.Add(this.Attendence_Report_Button);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 561);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(980, 79);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // Delet_All_Attendences_Button
            // 
            this.Delet_All_Attendences_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Delet_All_Attendences_Button.BackColor = System.Drawing.Color.DodgerBlue;
            this.Delet_All_Attendences_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delet_All_Attendences_Button.FlatAppearance.BorderSize = 0;
            this.Delet_All_Attendences_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delet_All_Attendences_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delet_All_Attendences_Button.ForeColor = System.Drawing.Color.White;
            this.Delet_All_Attendences_Button.Location = new System.Drawing.Point(788, 3);
            this.Delet_All_Attendences_Button.Margin = new System.Windows.Forms.Padding(3, 3, 70, 3);
            this.Delet_All_Attendences_Button.Name = "Delet_All_Attendences_Button";
            this.Delet_All_Attendences_Button.Size = new System.Drawing.Size(122, 40);
            this.Delet_All_Attendences_Button.TabIndex = 13;
            this.Delet_All_Attendences_Button.Text = "Delete All";
            this.Delet_All_Attendences_Button.UseVisualStyleBackColor = false;
            this.Delet_All_Attendences_Button.Click += new System.EventHandler(this.Delet_All_Attendences_Button_Click);
            // 
            // Data_Panel
            // 
            this.Data_Panel.Controls.Add(this.Attendences_DataGridView);
            this.Data_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Data_Panel.Location = new System.Drawing.Point(0, 0);
            this.Data_Panel.Name = "Data_Panel";
            this.Data_Panel.Size = new System.Drawing.Size(980, 640);
            this.Data_Panel.TabIndex = 3;
            // 
            // Attendences_DataGridView
            // 
            this.Attendences_DataGridView.AllowCustomTheming = false;
            this.Attendences_DataGridView.AllowUserToAddRows = false;
            this.Attendences_DataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.Attendences_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Attendences_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Attendences_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Attendences_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Attendences_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Attendences_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Attendences_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Attendences_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Attendences_DataGridView.ColumnHeadersHeight = 40;
            this.Attendences_DataGridView.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.Attendences_DataGridView.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Attendences_DataGridView.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.Attendences_DataGridView.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.Attendences_DataGridView.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.Attendences_DataGridView.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.Attendences_DataGridView.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.Attendences_DataGridView.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.Attendences_DataGridView.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.Attendences_DataGridView.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Attendences_DataGridView.CurrentTheme.Name = null;
            this.Attendences_DataGridView.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.Attendences_DataGridView.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Attendences_DataGridView.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.Attendences_DataGridView.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.Attendences_DataGridView.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.Attendences_DataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Attendences_DataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.Attendences_DataGridView.EnableHeadersVisualStyles = false;
            this.Attendences_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.Attendences_DataGridView.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.Attendences_DataGridView.HeaderBgColor = System.Drawing.Color.Empty;
            this.Attendences_DataGridView.HeaderForeColor = System.Drawing.Color.White;
            this.Attendences_DataGridView.Location = new System.Drawing.Point(39, 219);
            this.Attendences_DataGridView.Name = "Attendences_DataGridView";
            this.Attendences_DataGridView.ReadOnly = true;
            this.Attendences_DataGridView.RowHeadersVisible = false;
            this.Attendences_DataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Attendences_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.Attendences_DataGridView.RowTemplate.Height = 40;
            this.Attendences_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Attendences_DataGridView.Size = new System.Drawing.Size(904, 336);
            this.Attendences_DataGridView.TabIndex = 1;
            this.Attendences_DataGridView.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.Attendences_DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Attendences_DataGridView_CellClick);
            // 
            // Create_Date_Btn_Ellipse
            // 
            this.Create_Date_Btn_Ellipse.ElipseRadius = 15;
            this.Create_Date_Btn_Ellipse.TargetControl = this.Create_Date_Button;
            // 
            // Delete_All_Attendences_Btn_Ellipse
            // 
            this.Delete_All_Attendences_Btn_Ellipse.ElipseRadius = 15;
            this.Delete_All_Attendences_Btn_Ellipse.TargetControl = this.Delet_All_Attendences_Button;
            // 
            // Attendence_Report_Button
            // 
            this.Attendence_Report_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Attendence_Report_Button.BackColor = System.Drawing.Color.DodgerBlue;
            this.Attendence_Report_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Attendence_Report_Button.FlatAppearance.BorderSize = 0;
            this.Attendence_Report_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Attendence_Report_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attendence_Report_Button.ForeColor = System.Drawing.Color.White;
            this.Attendence_Report_Button.Location = new System.Drawing.Point(557, 3);
            this.Attendence_Report_Button.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.Attendence_Report_Button.Name = "Attendence_Report_Button";
            this.Attendence_Report_Button.Size = new System.Drawing.Size(208, 40);
            this.Attendence_Report_Button.TabIndex = 14;
            this.Attendence_Report_Button.Text = "Attedndence Report";
            this.Attendence_Report_Button.UseVisualStyleBackColor = false;
            this.Attendence_Report_Button.Click += new System.EventHandler(this.Attendence_Report_Button_Click);
            // 
            // Attendence_Report_Btn_Ellipse
            // 
            this.Attendence_Report_Btn_Ellipse.ElipseRadius = 15;
            this.Attendence_Report_Btn_Ellipse.TargetControl = this.Attendence_Report_Button;
            // 
            // Attendence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Back_Panel);
            this.Name = "Attendence";
            this.Size = new System.Drawing.Size(980, 640);
            this.Load += new System.EventHandler(this.Attendence_Load);
            this.Back_Panel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.Data_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Attendences_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Back_Panel;
        private System.Windows.Forms.Panel Data_Panel;
        private Bunifu.UI.WinForms.BunifuDataGridView Attendences_DataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.UI.WinForms.BunifuDropdown Attendence_Status_Combobox;
        private System.Windows.Forms.Label Attendence_Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuDropdown Attendences_Date_Combobox;
        private Bunifu.UI.WinForms.BunifuDatePicker Class_Attendence_Date_DateTime;
        private Bunifu.Framework.UI.BunifuElipse Create_Date_Btn_Ellipse;
        private System.Windows.Forms.Button Create_Date_Button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Delet_All_Attendences_Button;
        private Bunifu.Framework.UI.BunifuElipse Delete_All_Attendences_Btn_Ellipse;
        private Bunifu.UI.WinForms.BunifuDropdown Filter_By_Combobox;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox Search_Textbox;
        private System.Windows.Forms.Label Search_Label;
        private System.Windows.Forms.Label Filter_By_Label;
        private System.Windows.Forms.Button Attendence_Report_Button;
        private Bunifu.Framework.UI.BunifuElipse Attendence_Report_Btn_Ellipse;
    }
}
