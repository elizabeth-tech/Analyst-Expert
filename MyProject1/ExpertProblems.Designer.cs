namespace MyProject1
{
    partial class ExpertProblems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpertProblems));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.dataGridViewProblemsExpert = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonExpertNext = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonExpertProblemClose = new System.Windows.Forms.Button();
            this.buttonExpertProblemTurn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProblemsExpert)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.buttonExpertProblemClose);
            this.panel1.Controls.Add(this.buttonExpertProblemTurn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 32);
            this.panel1.TabIndex = 45;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 22);
            this.label1.TabIndex = 47;
            this.label1.Text = "S";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(32, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(193, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Эксперт - Выбор проблемы";
            // 
            // dataGridViewProblemsExpert
            // 
            this.dataGridViewProblemsExpert.AllowUserToAddRows = false;
            this.dataGridViewProblemsExpert.AllowUserToDeleteRows = false;
            this.dataGridViewProblemsExpert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewProblemsExpert.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewProblemsExpert.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProblemsExpert.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewProblemsExpert.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(205)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProblemsExpert.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewProblemsExpert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProblemsExpert.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column10,
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProblemsExpert.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewProblemsExpert.EnableHeadersVisualStyles = false;
            this.dataGridViewProblemsExpert.Location = new System.Drawing.Point(35, 60);
            this.dataGridViewProblemsExpert.Name = "dataGridViewProblemsExpert";
            this.dataGridViewProblemsExpert.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(218)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProblemsExpert.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(8, 4, 0, 0);
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewProblemsExpert.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewProblemsExpert.Size = new System.Drawing.Size(767, 289);
            this.dataGridViewProblemsExpert.TabIndex = 89;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 30;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "№";
            this.Column10.Name = "Column10";
            this.Column10.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Проблемы";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 600;
            // 
            // buttonExpertNext
            // 
            this.buttonExpertNext.BackColor = System.Drawing.Color.Orange;
            this.buttonExpertNext.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonExpertNext.FlatAppearance.BorderSize = 0;
            this.buttonExpertNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertNext.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExpertNext.ForeColor = System.Drawing.Color.Black;
            this.buttonExpertNext.Location = new System.Drawing.Point(704, 370);
            this.buttonExpertNext.Name = "buttonExpertNext";
            this.buttonExpertNext.Size = new System.Drawing.Size(98, 35);
            this.buttonExpertNext.TabIndex = 91;
            this.buttonExpertNext.Text = "Далее";
            this.buttonExpertNext.UseVisualStyleBackColor = false;
            this.buttonExpertNext.Click += new System.EventHandler(this.buttonExpertNext_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Orange;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.ForeColor = System.Drawing.Color.Black;
            this.buttonBack.Location = new System.Drawing.Point(580, 370);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(98, 35);
            this.buttonBack.TabIndex = 92;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonExpertProblemClose
            // 
            this.buttonExpertProblemClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpertProblemClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExpertProblemClose.BackgroundImage")));
            this.buttonExpertProblemClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExpertProblemClose.FlatAppearance.BorderSize = 0;
            this.buttonExpertProblemClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonExpertProblemClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertProblemClose.Location = new System.Drawing.Point(791, 0);
            this.buttonExpertProblemClose.Name = "buttonExpertProblemClose";
            this.buttonExpertProblemClose.Size = new System.Drawing.Size(47, 30);
            this.buttonExpertProblemClose.TabIndex = 45;
            this.buttonExpertProblemClose.UseVisualStyleBackColor = false;
            this.buttonExpertProblemClose.Click += new System.EventHandler(this.buttonExpertProblemClose_Click);
            // 
            // buttonExpertProblemTurn
            // 
            this.buttonExpertProblemTurn.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpertProblemTurn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExpertProblemTurn.BackgroundImage")));
            this.buttonExpertProblemTurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExpertProblemTurn.FlatAppearance.BorderSize = 0;
            this.buttonExpertProblemTurn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonExpertProblemTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertProblemTurn.Location = new System.Drawing.Point(738, 0);
            this.buttonExpertProblemTurn.Name = "buttonExpertProblemTurn";
            this.buttonExpertProblemTurn.Size = new System.Drawing.Size(47, 30);
            this.buttonExpertProblemTurn.TabIndex = 48;
            this.buttonExpertProblemTurn.UseVisualStyleBackColor = false;
            this.buttonExpertProblemTurn.Click += new System.EventHandler(this.buttonExpertProblemTurn_Click);
            // 
            // ProblemsExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(838, 425);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonExpertNext);
            this.Controls.Add(this.dataGridViewProblemsExpert);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProblemsExpert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Эксперт - выбор проблемы";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProblemsExpert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExpertProblemClose;
        private System.Windows.Forms.Button buttonExpertProblemTurn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView dataGridViewProblemsExpert;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button buttonExpertNext;
        private System.Windows.Forms.Button buttonBack;
    }
}