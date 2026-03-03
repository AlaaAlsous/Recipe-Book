namespace Recipe_Book.Forms
{
    partial class ShowForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowForm));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            buttonPrint = new Button();
            buttonDelete = new Button();
            pnlDetails = new Panel();
            lblDetailTitle = new Label();
            lblDetailDescription = new Label();
            rtbDetailInstructions = new RichTextBox();
            dgvDetailIngredients = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetailIngredients).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(33, 37, 41);
            label1.Location = new Point(535, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(113, 41);
            label1.TabIndex = 0;
            label1.Text = "Show";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.FromArgb(33, 150, 243);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 119, 242);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(129, 131);
            button1.Name = "button1";
            button1.Size = new Size(180, 55);
            button1.TabIndex = 1;
            button1.Text = "Show Recipes";
            button1.UseVisualStyleBackColor = false;
            button1.Click += BtnShowRecipes_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.FromArgb(156, 39, 176);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(123, 31, 162);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(501, 131);
            button2.Name = "button2";
            button2.Size = new Size(180, 55);
            button2.TabIndex = 2;
            button2.Text = "Show Ingredients";
            button2.UseVisualStyleBackColor = false;
            button2.Click += BtnShowIngredients_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.BackColor = Color.FromArgb(76, 175, 80);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(687, 131);
            button3.Name = "button3";
            button3.Size = new Size(180, 55);
            button3.TabIndex = 3;
            button3.Text = "Show Categories";
            button3.UseVisualStyleBackColor = false;
            button3.Click += BtnShowCategories_Click;
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
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(39, 210);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1105, 416);
            dataGridView1.TabIndex = 4;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.BackColor = Color.IndianRed;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(315, 131);
            button4.Name = "button4";
            button4.Size = new Size(180, 55);
            button4.TabIndex = 5;
            button4.Text = "Show Recipe";
            button4.UseVisualStyleBackColor = false;
            button4.Visible = false;
            button4.Click += BtnShowRecipeIngredients_Click;
            // 
            // buttonPrint
            // 
            buttonPrint.Anchor = AnchorStyles.None;
            buttonPrint.BackColor = Color.SteelBlue;
            buttonPrint.Cursor = Cursors.Hand;
            buttonPrint.FlatAppearance.BorderSize = 0;
            buttonPrint.FlatStyle = FlatStyle.Flat;
            buttonPrint.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPrint.ForeColor = Color.White;
            buttonPrint.Location = new Point(873, 132);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(180, 55);
            buttonPrint.TabIndex = 7;
            buttonPrint.Text = "Print Recipe";
            buttonPrint.UseVisualStyleBackColor = false;
            buttonPrint.Visible = false;
            buttonPrint.Click += BtnPrint_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.None;
            buttonDelete.BackColor = Color.DarkRed;
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(873, 131);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(180, 55);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Visible = false;
            buttonDelete.Click += BtnDelete_Click;
            // 
            // pnlDetails
            // 
            pnlDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDetails.BackColor = Color.WhiteSmoke;
            pnlDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlDetails.Controls.Add(lblDetailTitle);
            pnlDetails.Controls.Add(lblDetailDescription);
            pnlDetails.Controls.Add(rtbDetailInstructions);
            pnlDetails.Controls.Add(dgvDetailIngredients);
            pnlDetails.Location = new Point(39, 210);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(1105, 416);
            pnlDetails.TabIndex = 8;
            pnlDetails.Visible = false;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDetailTitle.Location = new Point(12, 12);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(1080, 36);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDetailDescription
            // 
            lblDetailDescription.Font = new Font("Segoe UI", 10F);
            lblDetailDescription.Location = new Point(12, 56);
            lblDetailDescription.Name = "lblDetailDescription";
            lblDetailDescription.Size = new Size(1080, 40);
            lblDetailDescription.TabIndex = 1;
            // 
            // rtbDetailInstructions
            // 
            rtbDetailInstructions.Location = new Point(12, 102);
            rtbDetailInstructions.Name = "rtbDetailInstructions";
            rtbDetailInstructions.ReadOnly = true;
            rtbDetailInstructions.Size = new Size(720, 264);
            rtbDetailInstructions.TabIndex = 2;
            rtbDetailInstructions.Text = "";
            // 
            // dgvDetailIngredients
            // 
            dgvDetailIngredients.AllowUserToAddRows = false;
            dgvDetailIngredients.AllowUserToDeleteRows = false;
            dgvDetailIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetailIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailIngredients.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvDetailIngredients.Location = new Point(744, 102);
            dgvDetailIngredients.Name = "dgvDetailIngredients";
            dgvDetailIngredients.ReadOnly = true;
            dgvDetailIngredients.RowHeadersVisible = false;
            dgvDetailIngredients.RowHeadersWidth = 51;
            dgvDetailIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetailIngredients.Size = new Size(348, 264);
            dgvDetailIngredients.TabIndex = 3;
            // 
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Name";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Quantity";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Unit";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // ShowForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1182, 653);
            Controls.Add(pnlDetails);
            Controls.Add(button4);
            Controls.Add(buttonPrint);
            Controls.Add(buttonDelete);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ShowForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Show";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetailIngredients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
    	private Button button4;
        private Button buttonPrint;
    	private Button buttonDelete;
        private Panel pnlDetails;
        private Label lblDetailTitle;
        private Label lblDetailDescription;
        private RichTextBox rtbDetailInstructions;
        private DataGridView dgvDetailIngredients;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}