namespace Recipe_Book.Forms
{
    partial class EditRecipeForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRecipeForm));
            label1 = new Label();
            BtnSave = new Button();
            txtCategories = new TextBox();
            txtIngName = new TextBox();
            txtInstructions = new TextBox();
            txtDescription = new TextBox();
            txtName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtIngQuantity = new TextBox();
            txtIngUnit = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            BtnAddIng = new Button();
            BtnRemoveIng = new Button();
            dataGridView1 = new DataGridView();
            IngredientName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Unit = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(33, 37, 41);
            label1.Location = new Point(491, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(189, 46);
            label1.TabIndex = 3;
            label1.Text = "Edit Recipe";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnSave
            // 
            BtnSave.Anchor = AnchorStyles.None;
            BtnSave.BackColor = Color.FromArgb(33, 150, 243);
            BtnSave.Cursor = Cursors.Hand;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 119, 242);
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(501, 573);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(180, 55);
            BtnSave.TabIndex = 11;
            BtnSave.Text = "Save Changes";
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSaveChanges_Click;
            // 
            // txtCategories
            // 
            txtCategories.Anchor = AnchorStyles.None;
            txtCategories.BackColor = Color.White;
            txtCategories.BorderStyle = BorderStyle.FixedSingle;
            txtCategories.Cursor = Cursors.IBeam;
            txtCategories.Font = new Font("Segoe UI", 10F);
            txtCategories.Location = new Point(189, 171);
            txtCategories.Name = "txtCategories";
            txtCategories.PlaceholderText = "Enter categories separated by commas (e.g., Dessert, Main Course)...";
            txtCategories.Size = new Size(759, 30);
            txtCategories.TabIndex = 9;
            // 
            // txtIngName
            // 
            txtIngName.Anchor = AnchorStyles.None;
            txtIngName.BackColor = Color.White;
            txtIngName.BorderStyle = BorderStyle.FixedSingle;
            txtIngName.Cursor = Cursors.IBeam;
            txtIngName.Font = new Font("Segoe UI", 10F);
            txtIngName.Location = new Point(292, 322);
            txtIngName.Name = "txtIngName";
            txtIngName.PlaceholderText = "Enter ingredient name...";
            txtIngName.Size = new Size(410, 30);
            txtIngName.TabIndex = 8;
            // 
            // txtInstructions
            // 
            txtInstructions.Anchor = AnchorStyles.None;
            txtInstructions.BackColor = Color.White;
            txtInstructions.BorderStyle = BorderStyle.FixedSingle;
            txtInstructions.Cursor = Cursors.IBeam;
            txtInstructions.Font = new Font("Segoe UI", 10F);
            txtInstructions.Location = new Point(189, 117);
            txtInstructions.Name = "txtInstructions";
            txtInstructions.PlaceholderText = "Enter cooking instructions (optional)...";
            txtInstructions.Size = new Size(759, 30);
            txtInstructions.TabIndex = 7;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.None;
            txtDescription.BackColor = Color.White;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Cursor = Cursors.IBeam;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(189, 64);
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Enter a short description (optional)...";
            txtDescription.Size = new Size(759, 30);
            txtDescription.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.None;
            txtName.BackColor = Color.White;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Cursor = Cursors.IBeam;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(189, 11);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Enter recipe name...";
            txtName.Size = new Size(759, 30);
            txtName.TabIndex = 5;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(33, 37, 41);
            label6.Location = new Point(3, 172);
            label6.Name = "label6";
            label6.Size = new Size(113, 28);
            label6.TabIndex = 4;
            label6.Text = "Categories:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(33, 37, 41);
            label5.Location = new Point(109, 324);
            label5.Name = "label5";
            label5.Size = new Size(121, 28);
            label5.TabIndex = 3;
            label5.Text = "Ingredients:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(33, 37, 41);
            label4.Location = new Point(3, 118);
            label4.Name = "label4";
            label4.Size = new Size(124, 28);
            label4.TabIndex = 2;
            label4.Text = "Instructions:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(33, 37, 41);
            label3.Location = new Point(3, 65);
            label3.Name = "label3";
            label3.Size = new Size(120, 28);
            label3.TabIndex = 1;
            label3.Text = "Description:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(33, 37, 41);
            label2.Location = new Point(3, 12);
            label2.Name = "label2";
            label2.Size = new Size(136, 28);
            label2.TabIndex = 0;
            label2.Text = "Recipe Name:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.59836F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.40164F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(txtName, 1, 0);
            tableLayoutPanel1.Controls.Add(txtDescription, 1, 1);
            tableLayoutPanel1.Controls.Add(txtInstructions, 1, 2);
            tableLayoutPanel1.Controls.Add(label6, 0, 3);
            tableLayoutPanel1.Controls.Add(txtCategories, 1, 3);
            tableLayoutPanel1.Location = new Point(103, 73);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(976, 213);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // txtIngQuantity
            // 
            txtIngQuantity.Anchor = AnchorStyles.None;
            txtIngQuantity.BackColor = Color.White;
            txtIngQuantity.BorderStyle = BorderStyle.FixedSingle;
            txtIngQuantity.Cursor = Cursors.IBeam;
            txtIngQuantity.Font = new Font("Segoe UI", 10F);
            txtIngQuantity.Location = new Point(708, 322);
            txtIngQuantity.Name = "txtIngQuantity";
            txtIngQuantity.Size = new Size(74, 30);
            txtIngQuantity.TabIndex = 12;
            // 
            // txtIngUnit
            // 
            txtIngUnit.Anchor = AnchorStyles.None;
            txtIngUnit.BackColor = Color.White;
            txtIngUnit.BorderStyle = BorderStyle.FixedSingle;
            txtIngUnit.Cursor = Cursors.IBeam;
            txtIngUnit.Font = new Font("Segoe UI", 10F);
            txtIngUnit.Location = new Point(788, 322);
            txtIngUnit.Name = "txtIngUnit";
            txtIngUnit.Size = new Size(74, 30);
            txtIngUnit.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(80, 80, 80);
            label7.Location = new Point(429, 299);
            label7.Name = "label7";
            label7.Size = new Size(128, 20);
            label7.TabIndex = 14;
            label7.Text = "Ingredient Name";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(80, 80, 80);
            label8.Location = new Point(712, 299);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 15;
            label8.Text = "Quantity";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(80, 80, 80);
            label9.Location = new Point(806, 299);
            label9.Name = "label9";
            label9.Size = new Size(39, 20);
            label9.TabIndex = 16;
            label9.Text = "Unit";
            // 
            // BtnAddIng
            // 
            BtnAddIng.BackColor = Color.FromArgb(33, 150, 243);
            BtnAddIng.Cursor = Cursors.Hand;
            BtnAddIng.FlatAppearance.BorderSize = 0;
            BtnAddIng.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 119, 242);
            BtnAddIng.FlatStyle = FlatStyle.Flat;
            BtnAddIng.Font = new Font("Segoe UI", 9F);
            BtnAddIng.ForeColor = Color.White;
            BtnAddIng.Location = new Point(868, 322);
            BtnAddIng.Name = "BtnAddIng";
            BtnAddIng.Size = new Size(88, 30);
            BtnAddIng.TabIndex = 17;
            BtnAddIng.Text = "Add";
            BtnAddIng.UseVisualStyleBackColor = false;
            BtnAddIng.Click += BtnAddIng_Click;
            // 
            // BtnRemoveIng
            // 
            BtnRemoveIng.BackColor = Color.FromArgb(244, 67, 54);
            BtnRemoveIng.Cursor = Cursors.Hand;
            BtnRemoveIng.FlatAppearance.BorderSize = 0;
            BtnRemoveIng.FlatAppearance.MouseOverBackColor = Color.FromArgb(211, 47, 47);
            BtnRemoveIng.FlatStyle = FlatStyle.Flat;
            BtnRemoveIng.Font = new Font("Segoe UI", 9F);
            BtnRemoveIng.ForeColor = Color.White;
            BtnRemoveIng.Location = new Point(962, 321);
            BtnRemoveIng.Name = "BtnRemoveIng";
            BtnRemoveIng.Size = new Size(88, 30);
            BtnRemoveIng.TabIndex = 19;
            BtnRemoveIng.Text = "Remove";
            BtnRemoveIng.UseVisualStyleBackColor = false;
            BtnRemoveIng.Click += BtnRemoveIng_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IngredientName, Quantity, Unit });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(164, 395);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(854, 172);
            dataGridView1.TabIndex = 18;
            // 
            // IngredientName
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            IngredientName.DefaultCellStyle = dataGridViewCellStyle2;
            IngredientName.HeaderText = "Ingredient";
            IngredientName.MinimumWidth = 6;
            IngredientName.Name = "IngredientName";
            IngredientName.ReadOnly = true;
            IngredientName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Quantity
            // 
            Quantity.FillWeight = 25F;
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Unit
            // 
            Unit.FillWeight = 25F;
            Unit.HeaderText = "Unit";
            Unit.MinimumWidth = 6;
            Unit.Name = "Unit";
            Unit.ReadOnly = true;
            Unit.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // EditRecipeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1182, 653);
            Controls.Add(dataGridView1);
            Controls.Add(BtnAddIng);
            Controls.Add(BtnRemoveIng);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtIngUnit);
            Controls.Add(txtIngQuantity);
            Controls.Add(BtnSave);
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label5);
            Controls.Add(txtIngName);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EditRecipeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Recipe";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button BtnSave;
        private TextBox txtCategories;
        private TextBox txtIngName;
        private TextBox txtInstructions;
        private TextBox txtDescription;
        private TextBox txtName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtIngQuantity;
        private TextBox txtIngUnit;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button BtnAddIng;
        private Button BtnRemoveIng;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IngredientName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Unit;
    }
}
