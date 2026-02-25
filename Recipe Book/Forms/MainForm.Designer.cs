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
            BtnEdit = new Button();
            BtnDelete = new Button();
            BtnShow = new Button();
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
            // BtnEdit
            // 
            BtnEdit.Anchor = AnchorStyles.None;
            BtnEdit.BackColor = Color.DarkTurquoise;
            BtnEdit.Cursor = Cursors.Hand;
            BtnEdit.FlatAppearance.BorderSize = 0;
            BtnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 119, 242);
            BtnEdit.FlatStyle = FlatStyle.Flat;
            BtnEdit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            BtnEdit.ForeColor = Color.White;
            BtnEdit.Location = new Point(56, 254);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(180, 55);
            BtnEdit.TabIndex = 2;
            BtnEdit.Text = "Edit";
            BtnEdit.UseVisualStyleBackColor = false;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Anchor = AnchorStyles.None;
            BtnDelete.BackColor = Color.FromArgb(233, 30, 99);
            BtnDelete.Cursor = Cursors.Hand;
            BtnDelete.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 24, 78);
            BtnDelete.FlatStyle = FlatStyle.Flat;
            BtnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            BtnDelete.ForeColor = Color.White;
            BtnDelete.Location = new Point(56, 339);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(180, 55);
            BtnDelete.TabIndex = 3;
            BtnDelete.Text = "Delete";
            BtnDelete.UseVisualStyleBackColor = false;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnShow
            // 
            BtnShow.Anchor = AnchorStyles.None;
            BtnShow.BackColor = Color.FromArgb(76, 175, 80);
            BtnShow.Cursor = Cursors.Hand;
            BtnShow.FlatAppearance.BorderSize = 0;
            BtnShow.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
            BtnShow.FlatStyle = FlatStyle.Flat;
            BtnShow.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            BtnShow.ForeColor = Color.White;
            BtnShow.Location = new Point(56, 424);
            BtnShow.Name = "BtnShow";
            BtnShow.Size = new Size(180, 55);
            BtnShow.TabIndex = 4;
            BtnShow.Text = "Show";
            BtnShow.UseVisualStyleBackColor = false;
            BtnShow.Click += BtnShow_Click;
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
            dgvRecipes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecipes.Size = new Size(836, 487);
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
            Controls.Add(BtnShow);
            Controls.Add(BtnDelete);
            Controls.Add(BtnEdit);
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
        private Button BtnEdit;
        private Button BtnDelete;
        private Button BtnShow;
        private DataGridView dgvRecipes;
        private DataGridViewTextBoxColumn RecipeId;
        private DataGridViewTextBoxColumn RecipeName;
        private DataGridViewTextBoxColumn UpdateAt;
    }
}
