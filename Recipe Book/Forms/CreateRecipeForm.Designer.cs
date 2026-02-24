namespace Recipe_Book.Forms
{
    partial class CreateRecipeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRecipeForm));
            label1 = new Label();
            BtnAdd = new Button();
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
            label1.BackColor = Color.LightCyan;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(396, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(390, 48);
            label1.TabIndex = 3;
            label1.Text = "🍽️  New Recipe  🍽️";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnAdd
            // 
            BtnAdd.Anchor = AnchorStyles.None;
            BtnAdd.BackColor = Color.Gainsboro;
            BtnAdd.Cursor = Cursors.Hand;
            BtnAdd.Font = new Font("Arial Rounded MT Bold", 13.8F);
            BtnAdd.ForeColor = SystemColors.HotTrack;
            BtnAdd.Location = new Point(501, 559);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(180, 55);
            BtnAdd.TabIndex = 11;
            BtnAdd.Text = "Add Recipe";
            BtnAdd.UseVisualStyleBackColor = false;
            BtnAdd.Click += BtnAddRecipe_Click;
            // 
            // txtCategories
            // 
            txtCategories.Anchor = AnchorStyles.None;
            txtCategories.BackColor = SystemColors.Menu;
            txtCategories.BorderStyle = BorderStyle.None;
            txtCategories.Cursor = Cursors.IBeam;
            txtCategories.Font = new Font("Arial Rounded MT Bold", 13.8F);
            txtCategories.Location = new Point(263, 172);
            txtCategories.Name = "txtCategories";
            txtCategories.Size = new Size(672, 27);
            txtCategories.TabIndex = 9;
            // 
            // txtIngName
            // 
            txtIngName.Anchor = AnchorStyles.None;
            txtIngName.BackColor = SystemColors.Menu;
            txtIngName.BorderStyle = BorderStyle.None;
            txtIngName.Cursor = Cursors.IBeam;
            txtIngName.Font = new Font("Arial Rounded MT Bold", 13.8F);
            txtIngName.Location = new Point(382, 316);
            txtIngName.Name = "txtIngName";
            txtIngName.Size = new Size(410, 27);
            txtIngName.TabIndex = 8;
            // 
            // txtInstructions
            // 
            txtInstructions.Anchor = AnchorStyles.None;
            txtInstructions.BackColor = SystemColors.Menu;
            txtInstructions.BorderStyle = BorderStyle.None;
            txtInstructions.Cursor = Cursors.IBeam;
            txtInstructions.Font = new Font("Arial Rounded MT Bold", 13.8F);
            txtInstructions.Location = new Point(263, 119);
            txtInstructions.Name = "txtInstructions";
            txtInstructions.Size = new Size(672, 27);
            txtInstructions.TabIndex = 7;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.None;
            txtDescription.BackColor = SystemColors.Menu;
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.Cursor = Cursors.IBeam;
            txtDescription.Font = new Font("Arial Rounded MT Bold", 13.8F);
            txtDescription.Location = new Point(263, 66);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(672, 27);
            txtDescription.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.None;
            txtName.BackColor = SystemColors.Menu;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Cursor = Cursors.IBeam;
            txtName.Font = new Font("Arial Rounded MT Bold", 13.8F);
            txtName.Location = new Point(263, 13);
            txtName.Name = "txtName";
            txtName.Size = new Size(672, 27);
            txtName.TabIndex = 5;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 16.2F);
            label6.Location = new Point(3, 170);
            label6.Name = "label6";
            label6.Size = new Size(175, 32);
            label6.TabIndex = 4;
            label6.Text = "Categories:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 16.2F);
            label5.Location = new Point(119, 311);
            label5.Name = "label5";
            label5.Size = new Size(181, 32);
            label5.TabIndex = 3;
            label5.Text = "Ingredients:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 16.2F);
            label4.Location = new Point(3, 116);
            label4.Name = "label4";
            label4.Size = new Size(187, 32);
            label4.TabIndex = 2;
            label4.Text = "Instructions:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 16.2F);
            label3.Location = new Point(3, 63);
            label3.Name = "label3";
            label3.Size = new Size(183, 32);
            label3.TabIndex = 1;
            label3.Text = "Description:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 16.2F);
            label2.Location = new Point(3, 10);
            label2.Name = "label2";
            label2.Size = new Size(207, 32);
            label2.TabIndex = 0;
            label2.Text = "Recipe Name:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.90678F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.09322F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(txtName, 1, 0);
            tableLayoutPanel1.Controls.Add(txtDescription, 1, 1);
            tableLayoutPanel1.Controls.Add(txtInstructions, 1, 2);
            tableLayoutPanel1.Controls.Add(label6, 0, 3);
            tableLayoutPanel1.Controls.Add(txtCategories, 1, 3);
            tableLayoutPanel1.Location = new Point(119, 73);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(944, 213);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // txtIngQuantity
            // 
            txtIngQuantity.Anchor = AnchorStyles.None;
            txtIngQuantity.BackColor = SystemColors.Menu;
            txtIngQuantity.BorderStyle = BorderStyle.None;
            txtIngQuantity.Cursor = Cursors.IBeam;
            txtIngQuantity.Font = new Font("Arial Rounded MT Bold", 13.8F);
            txtIngQuantity.Location = new Point(798, 316);
            txtIngQuantity.Name = "txtIngQuantity";
            txtIngQuantity.Size = new Size(74, 27);
            txtIngQuantity.TabIndex = 12;
            // 
            // txtIngUnit
            // 
            txtIngUnit.Anchor = AnchorStyles.None;
            txtIngUnit.BackColor = SystemColors.Menu;
            txtIngUnit.BorderStyle = BorderStyle.None;
            txtIngUnit.Cursor = Cursors.IBeam;
            txtIngUnit.Font = new Font("Arial Rounded MT Bold", 13.8F);
            txtIngUnit.Location = new Point(878, 316);
            txtIngUnit.Name = "txtIngUnit";
            txtIngUnit.Size = new Size(74, 27);
            txtIngUnit.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(535, 293);
            label7.Name = "label7";
            label7.Size = new Size(146, 20);
            label7.TabIndex = 14;
            label7.Text = "Ingredient Name";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(798, 293);
            label8.Name = "label8";
            label8.Size = new Size(78, 20);
            label8.TabIndex = 15;
            label8.Text = "Quantity";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(891, 293);
            label9.Name = "label9";
            label9.Size = new Size(43, 20);
            label9.TabIndex = 16;
            label9.Text = "Unit";
            // 
            // BtnAddIng
            // 
            BtnAddIng.Location = new Point(969, 314);
            BtnAddIng.Name = "BtnAddIng";
            BtnAddIng.Size = new Size(94, 29);
            BtnAddIng.TabIndex = 17;
            BtnAddIng.Text = "Add";
            BtnAddIng.UseVisualStyleBackColor = true;
            BtnAddIng.Click += BtnAddIng_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.PaleTurquoise;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IngredientName, Quantity, Unit });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(164, 363);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            // 
            // Quantity
            // 
            Quantity.FillWeight = 25F;
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // Unit
            // 
            Unit.FillWeight = 25F;
            Unit.HeaderText = "Unit";
            Unit.MinimumWidth = 6;
            Unit.Name = "Unit";
            Unit.ReadOnly = true;
            // 
            // CreateRecipeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(1182, 653);
            Controls.Add(dataGridView1);
            Controls.Add(BtnAddIng);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtIngUnit);
            Controls.Add(txtIngQuantity);
            Controls.Add(BtnAdd);
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label5);
            Controls.Add(txtIngName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateRecipeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateRecipeForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button BtnAdd;
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
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IngredientName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Unit;
    }
}