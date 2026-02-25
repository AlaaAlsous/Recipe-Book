namespace Recipe_Book
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new Label();
            BtnCreate = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dgvRecipes = new DataGridView();
            RecipeId = new DataGridViewTextBoxColumn();
            RecipeName = new DataGridViewTextBoxColumn();
            UpdateAt = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvRecipes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(33, 37, 41);
            label1.Location = new Point(485, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(209, 46);
            label1.TabIndex = 0;
            label1.Text = "Recipe Book";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnCreate
            // 
            BtnCreate.Anchor = AnchorStyles.None;
            BtnCreate.BackColor = Color.FromArgb(33, 150, 243);
            BtnCreate.Cursor = Cursors.Hand;
            BtnCreate.FlatAppearance.BorderSize = 0;
            BtnCreate.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 119, 242);
            BtnCreate.FlatStyle = FlatStyle.Flat;
            BtnCreate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            BtnCreate.ForeColor = Color.White;
            BtnCreate.Location = new Point(56, 169);
            BtnCreate.Name = "BtnCreate";
            BtnCreate.Size = new Size(180, 55);
            BtnCreate.TabIndex = 1;
            BtnCreate.Text = "Create";
            BtnCreate.UseVisualStyleBackColor = false;
            BtnCreate.Click += BtnCreate_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.FromArgb(33, 150, 243);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 119, 242);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(56, 254);
            button2.Name = "button2";
            button2.Size = new Size(180, 55);
            button2.TabIndex = 2;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.BackColor = Color.FromArgb(233, 30, 99);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 24, 78);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(56, 339);
            button3.Name = "button3";
            button3.Size = new Size(180, 55);
            button3.TabIndex = 3;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.BackColor = Color.FromArgb(76, 175, 80);
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(56, 424);
            button4.Name = "button4";
            button4.Size = new Size(180, 55);
            button4.TabIndex = 4;
            button4.Text = "Show";
            button4.UseVisualStyleBackColor = false;
            // 
            // dgvRecipes
            // 
            dgvRecipes.AllowUserToAddRows = false;
            dgvRecipes.BackgroundColor = Color.White;
            dgvRecipes.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.Padding = new Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRecipes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecipes.Columns.AddRange(new DataGridViewColumn[] { RecipeId, RecipeName, UpdateAt });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.Padding = new Padding(1);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRecipes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRecipes.EnableHeadersVisualStyles = false;
            dgvRecipes.GridColor = Color.LightGray;
            dgvRecipes.Location = new Point(276, 131);
            dgvRecipes.MultiSelect = false;
            dgvRecipes.Name = "dgvRecipes";
            dgvRecipes.ReadOnly = true;
            dgvRecipes.RowHeadersVisible = false;
            dgvRecipes.RowHeadersWidth = 51;
            dgvRecipes.Size = new Size(864, 487);
            dgvRecipes.TabIndex = 5;
            // 
            // RecipeId
            // 
            RecipeId.HeaderText = "ID";
            RecipeId.MinimumWidth = 6;
            RecipeId.Name = "RecipeId";
            RecipeId.ReadOnly = true;
            RecipeId.Width = 60;
            // 
            // RecipeName
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            RecipeName.DefaultCellStyle = dataGridViewCellStyle2;
            RecipeName.HeaderText = "Recipe Name";
            RecipeName.MinimumWidth = 6;
            RecipeName.Name = "RecipeName";
            RecipeName.ReadOnly = true;
            RecipeName.Width = 575;
            // 
            // UpdateAt
            // 
            UpdateAt.HeaderText = "UpdateDate";
            UpdateAt.MinimumWidth = 6;
            UpdateAt.Name = "UpdateAt";
            UpdateAt.ReadOnly = true;
            UpdateAt.Width = 200;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1178, 649);
            Controls.Add(dgvRecipes);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(BtnCreate);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recipe Book";
            ((System.ComponentModel.ISupportInitialize)dgvRecipes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BtnCreate;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dgvRecipes;
        private DataGridViewTextBoxColumn RecipeId;
        private DataGridViewTextBoxColumn RecipeName;
        private DataGridViewTextBoxColumn UpdateAt;
    }
}
