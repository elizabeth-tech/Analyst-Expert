namespace MyProject1
{
    partial class Analyst_Experts
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analyst_Experts));
            this.comboBoxExpert = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPositionExpert = new System.Windows.Forms.TextBox();
            this.textBoxCompetence = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewExpertProblems = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTurnAnalystProblem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.buttonCloseAnalystProblem = new System.Windows.Forms.Button();
            this.buttonEditExpert = new System.Windows.Forms.Button();
            this.buttonAddExpert = new System.Windows.Forms.Button();
            this.buttonDeleteExpert = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonAddAssignProblem = new System.Windows.Forms.Button();
            this.buttonDeleteAssignProblem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpertProblems)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxExpert
            // 
            this.comboBoxExpert.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxExpert.FormattingEnabled = true;
            this.comboBoxExpert.Location = new System.Drawing.Point(168, 92);
            this.comboBoxExpert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxExpert.Name = "comboBoxExpert";
            this.comboBoxExpert.Size = new System.Drawing.Size(297, 25);
            this.comboBoxExpert.TabIndex = 120;
            this.comboBoxExpert.SelectedIndexChanged += new System.EventHandler(this.comboBoxExpert_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(168, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 111;
            this.label3.Text = "Эксперт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(168, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 123;
            this.label2.Text = "Должность";
            // 
            // textBoxPositionExpert
            // 
            this.textBoxPositionExpert.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPositionExpert.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPositionExpert.Enabled = false;
            this.textBoxPositionExpert.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPositionExpert.Location = new System.Drawing.Point(168, 156);
            this.textBoxPositionExpert.Multiline = true;
            this.textBoxPositionExpert.Name = "textBoxPositionExpert";
            this.textBoxPositionExpert.ReadOnly = true;
            this.textBoxPositionExpert.Size = new System.Drawing.Size(297, 23);
            this.textBoxPositionExpert.TabIndex = 122;
            // 
            // textBoxCompetence
            // 
            this.textBoxCompetence.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxCompetence.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCompetence.Enabled = false;
            this.textBoxCompetence.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCompetence.Location = new System.Drawing.Point(168, 219);
            this.textBoxCompetence.Multiline = true;
            this.textBoxCompetence.Name = "textBoxCompetence";
            this.textBoxCompetence.ReadOnly = true;
            this.textBoxCompetence.Size = new System.Drawing.Size(134, 23);
            this.textBoxCompetence.TabIndex = 124;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(168, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 125;
            this.label4.Text = "Компетентность";
            // 
            // dataGridViewExpertProblems
            // 
            this.dataGridViewExpertProblems.AllowUserToAddRows = false;
            this.dataGridViewExpertProblems.AllowUserToDeleteRows = false;
            this.dataGridViewExpertProblems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewExpertProblems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewExpertProblems.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewExpertProblems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewExpertProblems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(205)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExpertProblems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewExpertProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpertProblems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExpertProblems.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewExpertProblems.EnableHeadersVisualStyles = false;
            this.dataGridViewExpertProblems.Location = new System.Drawing.Point(57, 334);
            this.dataGridViewExpertProblems.Name = "dataGridViewExpertProblems";
            this.dataGridViewExpertProblems.ReadOnly = true;
            this.dataGridViewExpertProblems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(218)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExpertProblems.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(8, 4, 0, 0);
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewExpertProblems.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewExpertProblems.Size = new System.Drawing.Size(584, 270);
            this.dataGridViewExpertProblems.TabIndex = 126;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Назначенные проблемы";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 500;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.buttonTurnAnalystProblem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.buttonCloseAnalystProblem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 32);
            this.panel1.TabIndex = 127;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown_1);
            // 
            // buttonTurnAnalystProblem
            // 
            this.buttonTurnAnalystProblem.BackColor = System.Drawing.Color.Transparent;
            this.buttonTurnAnalystProblem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTurnAnalystProblem.BackgroundImage")));
            this.buttonTurnAnalystProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTurnAnalystProblem.FlatAppearance.BorderSize = 0;
            this.buttonTurnAnalystProblem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonTurnAnalystProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTurnAnalystProblem.Location = new System.Drawing.Point(593, 0);
            this.buttonTurnAnalystProblem.Name = "buttonTurnAnalystProblem";
            this.buttonTurnAnalystProblem.Size = new System.Drawing.Size(47, 32);
            this.buttonTurnAnalystProblem.TabIndex = 45;
            this.buttonTurnAnalystProblem.UseVisualStyleBackColor = false;
            this.buttonTurnAnalystProblem.Click += new System.EventHandler(this.buttonTurnAnalystProblem_Click);
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
            this.label24.Size = new System.Drawing.Size(146, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Аналитик - Эксперты";
            // 
            // buttonCloseAnalystProblem
            // 
            this.buttonCloseAnalystProblem.BackColor = System.Drawing.Color.Transparent;
            this.buttonCloseAnalystProblem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCloseAnalystProblem.BackgroundImage")));
            this.buttonCloseAnalystProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCloseAnalystProblem.FlatAppearance.BorderSize = 0;
            this.buttonCloseAnalystProblem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonCloseAnalystProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseAnalystProblem.Location = new System.Drawing.Point(646, 0);
            this.buttonCloseAnalystProblem.Name = "buttonCloseAnalystProblem";
            this.buttonCloseAnalystProblem.Size = new System.Drawing.Size(47, 32);
            this.buttonCloseAnalystProblem.TabIndex = 44;
            this.buttonCloseAnalystProblem.UseVisualStyleBackColor = false;
            this.buttonCloseAnalystProblem.Click += new System.EventHandler(this.buttonCloseAnalystProblem_Click);
            // 
            // buttonEditExpert
            // 
            this.buttonEditExpert.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonEditExpert.BackgroundImage = global::MyProject1.Properties.Resources.icons8_edit_20;
            this.buttonEditExpert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonEditExpert.FlatAppearance.BorderSize = 0;
            this.buttonEditExpert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditExpert.Location = new System.Drawing.Point(120, 84);
            this.buttonEditExpert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEditExpert.Name = "buttonEditExpert";
            this.buttonEditExpert.Size = new System.Drawing.Size(41, 38);
            this.buttonEditExpert.TabIndex = 114;
            this.toolTip1.SetToolTip(this.buttonEditExpert, "Редактировать эксперта");
            this.buttonEditExpert.UseVisualStyleBackColor = false;
            this.buttonEditExpert.Click += new System.EventHandler(this.buttonEditExpert_Click);
            // 
            // buttonAddExpert
            // 
            this.buttonAddExpert.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAddExpert.BackgroundImage = global::MyProject1.Properties.Resources.icons8_plus_20;
            this.buttonAddExpert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAddExpert.FlatAppearance.BorderSize = 0;
            this.buttonAddExpert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddExpert.Location = new System.Drawing.Point(71, 84);
            this.buttonAddExpert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAddExpert.Name = "buttonAddExpert";
            this.buttonAddExpert.Size = new System.Drawing.Size(41, 38);
            this.buttonAddExpert.TabIndex = 113;
            this.toolTip1.SetToolTip(this.buttonAddExpert, "Добавить эксперта");
            this.buttonAddExpert.UseVisualStyleBackColor = false;
            this.buttonAddExpert.Click += new System.EventHandler(this.buttonAddExpert_Click);
            // 
            // buttonDeleteExpert
            // 
            this.buttonDeleteExpert.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonDeleteExpert.BackgroundImage = global::MyProject1.Properties.Resources.icons8_delete_20;
            this.buttonDeleteExpert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDeleteExpert.FlatAppearance.BorderSize = 0;
            this.buttonDeleteExpert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteExpert.Location = new System.Drawing.Point(473, 84);
            this.buttonDeleteExpert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDeleteExpert.Name = "buttonDeleteExpert";
            this.buttonDeleteExpert.Size = new System.Drawing.Size(41, 38);
            this.buttonDeleteExpert.TabIndex = 112;
            this.toolTip1.SetToolTip(this.buttonDeleteExpert, "Удалить эксперта");
            this.buttonDeleteExpert.UseVisualStyleBackColor = false;
            this.buttonDeleteExpert.Click += new System.EventHandler(this.buttonDeleteExpert_Click);
            // 
            // buttonAddAssignProblem
            // 
            this.buttonAddAssignProblem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAddAssignProblem.BackgroundImage = global::MyProject1.Properties.Resources.icons8_plus_20;
            this.buttonAddAssignProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAddAssignProblem.FlatAppearance.BorderSize = 0;
            this.buttonAddAssignProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAssignProblem.Location = new System.Drawing.Point(57, 289);
            this.buttonAddAssignProblem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAddAssignProblem.Name = "buttonAddAssignProblem";
            this.buttonAddAssignProblem.Size = new System.Drawing.Size(41, 38);
            this.buttonAddAssignProblem.TabIndex = 129;
            this.toolTip1.SetToolTip(this.buttonAddAssignProblem, "Назначить эксперту проблему");
            this.buttonAddAssignProblem.UseVisualStyleBackColor = false;
            this.buttonAddAssignProblem.Click += new System.EventHandler(this.buttonAddAssignProblem_Click);
            // 
            // buttonDeleteAssignProblem
            // 
            this.buttonDeleteAssignProblem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonDeleteAssignProblem.BackgroundImage = global::MyProject1.Properties.Resources.icons8_delete_20;
            this.buttonDeleteAssignProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDeleteAssignProblem.FlatAppearance.BorderSize = 0;
            this.buttonDeleteAssignProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteAssignProblem.Location = new System.Drawing.Point(104, 289);
            this.buttonDeleteAssignProblem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDeleteAssignProblem.Name = "buttonDeleteAssignProblem";
            this.buttonDeleteAssignProblem.Size = new System.Drawing.Size(41, 38);
            this.buttonDeleteAssignProblem.TabIndex = 131;
            this.toolTip1.SetToolTip(this.buttonDeleteAssignProblem, "Удалить назначенную проблему");
            this.buttonDeleteAssignProblem.UseVisualStyleBackColor = false;
            this.buttonDeleteAssignProblem.Click += new System.EventHandler(this.buttonDeleteAssignProblem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(249, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 20);
            this.label5.TabIndex = 128;
            this.label5.Text = "Назначенные проблемы";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(54, 607);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(493, 17);
            this.label6.TabIndex = 132;
            this.label6.Text = "*при помощи ПКМ выберите назначенную проблему, которую желаете удалить\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(53, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(416, 20);
            this.label7.TabIndex = 139;
            this.label7.Text = "Данному эксперту еще не назначено ни одной проблемы";
            this.label7.Visible = false;
            // 
            // Analyst_Experts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(693, 702);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonDeleteAssignProblem);
            this.Controls.Add(this.buttonAddAssignProblem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewExpertProblems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCompetence);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPositionExpert);
            this.Controls.Add(this.comboBoxExpert);
            this.Controls.Add(this.buttonEditExpert);
            this.Controls.Add(this.buttonAddExpert);
            this.Controls.Add(this.buttonDeleteExpert);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Analyst_Experts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналитик - Компентность экспертов";
            this.Activated += new System.EventHandler(this.Analyst_Experts_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpertProblems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxExpert;
        private System.Windows.Forms.Button buttonEditExpert;
        private System.Windows.Forms.Button buttonAddExpert;
        private System.Windows.Forms.Button buttonDeleteExpert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPositionExpert;
        private System.Windows.Forms.TextBox textBoxCompetence;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewExpertProblems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonTurnAnalystProblem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button buttonCloseAnalystProblem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddAssignProblem;
        private System.Windows.Forms.Button buttonDeleteAssignProblem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}