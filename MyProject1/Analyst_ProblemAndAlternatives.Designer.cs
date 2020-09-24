namespace MyProject1
{
    partial class Analyst_ProblemAndAlternatives
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analyst_ProblemAndAlternatives));
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDeleteAlternative = new System.Windows.Forms.Button();
            this.buttonEditAlternative = new System.Windows.Forms.Button();
            this.buttonEditProblem = new System.Windows.Forms.Button();
            this.buttonAddProblem = new System.Windows.Forms.Button();
            this.buttonDeleteProblem = new System.Windows.Forms.Button();
            this.textBoxAlternativeAdd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddAlternative = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewAlternatives = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxProblem = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTurnAnalystProblem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.buttonCloseAnalystProblem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlternatives)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(394, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 99;
            this.label3.Text = "Проблема";
            // 
            // buttonDeleteAlternative
            // 
            this.buttonDeleteAlternative.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonDeleteAlternative.BackgroundImage = global::MyProject1.Properties.Resources.icons8_delete_20;
            this.buttonDeleteAlternative.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDeleteAlternative.FlatAppearance.BorderSize = 0;
            this.buttonDeleteAlternative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteAlternative.Location = new System.Drawing.Point(175, 300);
            this.buttonDeleteAlternative.Name = "buttonDeleteAlternative";
            this.buttonDeleteAlternative.Size = new System.Drawing.Size(35, 33);
            this.buttonDeleteAlternative.TabIndex = 112;
            this.toolTip1.SetToolTip(this.buttonDeleteAlternative, "Удалить альтернативу");
            this.buttonDeleteAlternative.UseVisualStyleBackColor = false;
            this.buttonDeleteAlternative.Click += new System.EventHandler(this.buttonDeleteAlternative_Click);
            // 
            // buttonEditAlternative
            // 
            this.buttonEditAlternative.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonEditAlternative.BackgroundImage = global::MyProject1.Properties.Resources.icons8_edit_20;
            this.buttonEditAlternative.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonEditAlternative.FlatAppearance.BorderSize = 0;
            this.buttonEditAlternative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditAlternative.Location = new System.Drawing.Point(134, 300);
            this.buttonEditAlternative.Name = "buttonEditAlternative";
            this.buttonEditAlternative.Size = new System.Drawing.Size(35, 33);
            this.buttonEditAlternative.TabIndex = 111;
            this.toolTip1.SetToolTip(this.buttonEditAlternative, "Изменить альтернативу");
            this.buttonEditAlternative.UseVisualStyleBackColor = false;
            this.buttonEditAlternative.Click += new System.EventHandler(this.buttonEditAlternative_Click);
            // 
            // buttonEditProblem
            // 
            this.buttonEditProblem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonEditProblem.BackgroundImage = global::MyProject1.Properties.Resources.icons8_edit_20;
            this.buttonEditProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonEditProblem.FlatAppearance.BorderSize = 0;
            this.buttonEditProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditProblem.Location = new System.Drawing.Point(92, 94);
            this.buttonEditProblem.Name = "buttonEditProblem";
            this.buttonEditProblem.Size = new System.Drawing.Size(35, 33);
            this.buttonEditProblem.TabIndex = 102;
            this.toolTip1.SetToolTip(this.buttonEditProblem, "Изменить проблему");
            this.buttonEditProblem.UseVisualStyleBackColor = false;
            this.buttonEditProblem.Click += new System.EventHandler(this.buttonEditProblem_Click);
            // 
            // buttonAddProblem
            // 
            this.buttonAddProblem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAddProblem.BackgroundImage = global::MyProject1.Properties.Resources.icons8_plus_20;
            this.buttonAddProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAddProblem.FlatAppearance.BorderSize = 0;
            this.buttonAddProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddProblem.Location = new System.Drawing.Point(50, 94);
            this.buttonAddProblem.Name = "buttonAddProblem";
            this.buttonAddProblem.Size = new System.Drawing.Size(35, 33);
            this.buttonAddProblem.TabIndex = 101;
            this.toolTip1.SetToolTip(this.buttonAddProblem, "Добавить проблему");
            this.buttonAddProblem.UseVisualStyleBackColor = false;
            this.buttonAddProblem.Click += new System.EventHandler(this.buttonAddProblem_Click);
            // 
            // buttonDeleteProblem
            // 
            this.buttonDeleteProblem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonDeleteProblem.BackgroundImage = global::MyProject1.Properties.Resources.icons8_delete_20;
            this.buttonDeleteProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDeleteProblem.FlatAppearance.BorderSize = 0;
            this.buttonDeleteProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteProblem.Location = new System.Drawing.Point(727, 94);
            this.buttonDeleteProblem.Name = "buttonDeleteProblem";
            this.buttonDeleteProblem.Size = new System.Drawing.Size(35, 33);
            this.buttonDeleteProblem.TabIndex = 100;
            this.toolTip1.SetToolTip(this.buttonDeleteProblem, "Удалить проблему");
            this.buttonDeleteProblem.UseVisualStyleBackColor = false;
            this.buttonDeleteProblem.Click += new System.EventHandler(this.buttonDeleteProblem_Click);
            // 
            // textBoxAlternativeAdd
            // 
            this.textBoxAlternativeAdd.Location = new System.Drawing.Point(134, 181);
            this.textBoxAlternativeAdd.Name = "textBoxAlternativeAdd";
            this.textBoxAlternativeAdd.Size = new System.Drawing.Size(585, 23);
            this.textBoxAlternativeAdd.TabIndex = 103;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(338, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 104;
            this.label2.Text = "Добавление альтернативы";
            // 
            // buttonAddAlternative
            // 
            this.buttonAddAlternative.BackColor = System.Drawing.Color.Orange;
            this.buttonAddAlternative.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonAddAlternative.FlatAppearance.BorderSize = 0;
            this.buttonAddAlternative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAlternative.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddAlternative.ForeColor = System.Drawing.Color.Black;
            this.buttonAddAlternative.Location = new System.Drawing.Point(328, 210);
            this.buttonAddAlternative.Name = "buttonAddAlternative";
            this.buttonAddAlternative.Size = new System.Drawing.Size(222, 29);
            this.buttonAddAlternative.TabIndex = 105;
            this.buttonAddAlternative.Text = "Добавить альтернативу";
            this.buttonAddAlternative.UseVisualStyleBackColor = false;
            this.buttonAddAlternative.Click += new System.EventHandler(this.buttonAddAlternative_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(376, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 106;
            this.label4.Text = "Альтернативы";
            // 
            // dataGridViewAlternatives
            // 
            this.dataGridViewAlternatives.AllowUserToAddRows = false;
            this.dataGridViewAlternatives.AllowUserToDeleteRows = false;
            this.dataGridViewAlternatives.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewAlternatives.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewAlternatives.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAlternatives.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAlternatives.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(205)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAlternatives.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAlternatives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlternatives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAlternatives.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAlternatives.EnableHeadersVisualStyles = false;
            this.dataGridViewAlternatives.Location = new System.Drawing.Point(134, 339);
            this.dataGridViewAlternatives.Name = "dataGridViewAlternatives";
            this.dataGridViewAlternatives.ReadOnly = true;
            this.dataGridViewAlternatives.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(218)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAlternatives.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(8, 4, 0, 0);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewAlternatives.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewAlternatives.Size = new System.Drawing.Size(628, 243);
            this.dataGridViewAlternatives.TabIndex = 108;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Альтернативы";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 500;
            // 
            // comboBoxProblem
            // 
            this.comboBoxProblem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProblem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxProblem.FormattingEnabled = true;
            this.comboBoxProblem.Location = new System.Drawing.Point(133, 100);
            this.comboBoxProblem.Name = "comboBoxProblem";
            this.comboBoxProblem.Size = new System.Drawing.Size(586, 23);
            this.comboBoxProblem.TabIndex = 109;
            this.comboBoxProblem.SelectedIndexChanged += new System.EventHandler(this.comboBoxProblem_SelectedIndexChanged);
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
            this.panel1.Size = new System.Drawing.Size(831, 32);
            this.panel1.TabIndex = 110;
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
            this.buttonTurnAnalystProblem.Location = new System.Drawing.Point(731, 0);
            this.buttonTurnAnalystProblem.Name = "buttonTurnAnalystProblem";
            this.buttonTurnAnalystProblem.Size = new System.Drawing.Size(47, 32);
            this.buttonTurnAnalystProblem.TabIndex = 45;
            this.buttonTurnAnalystProblem.UseVisualStyleBackColor = false;
            this.buttonTurnAnalystProblem.Click += new System.EventHandler(this.buttonTurnAnalystProblem_Click_1);
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
            this.label24.Size = new System.Drawing.Size(257, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Аналитик - Проблемы и альтернативы";
            // 
            // buttonCloseAnalystProblem
            // 
            this.buttonCloseAnalystProblem.BackColor = System.Drawing.Color.Transparent;
            this.buttonCloseAnalystProblem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCloseAnalystProblem.BackgroundImage")));
            this.buttonCloseAnalystProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCloseAnalystProblem.FlatAppearance.BorderSize = 0;
            this.buttonCloseAnalystProblem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonCloseAnalystProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseAnalystProblem.Location = new System.Drawing.Point(784, 0);
            this.buttonCloseAnalystProblem.Name = "buttonCloseAnalystProblem";
            this.buttonCloseAnalystProblem.Size = new System.Drawing.Size(47, 32);
            this.buttonCloseAnalystProblem.TabIndex = 44;
            this.buttonCloseAnalystProblem.UseVisualStyleBackColor = false;
            this.buttonCloseAnalystProblem.Click += new System.EventHandler(this.buttonCloseAnalystProblem_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(131, 585);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(548, 17);
            this.label5.TabIndex = 113;
            this.label5.Text = "*при помощи ПКМ выберите альтернативу, которую желаете удалить или редактировать";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(129, 421);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(502, 60);
            this.labelError.TabIndex = 139;
            this.labelError.Text = "Для данной проблемы еще не добавлены альтернативы.\r\nНеобходимо внести как минимум" +
    " две альтернативы, чтобы проблема\r\nстала доступна для назначения экспертов.";
            this.labelError.Visible = false;
            // 
            // Analyst_ProblemAndAlternatives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(831, 651);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonDeleteAlternative);
            this.Controls.Add(this.buttonEditAlternative);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBoxProblem);
            this.Controls.Add(this.dataGridViewAlternatives);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAddAlternative);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAlternativeAdd);
            this.Controls.Add(this.buttonEditProblem);
            this.Controls.Add(this.buttonAddProblem);
            this.Controls.Add(this.buttonDeleteProblem);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Analyst_ProblemAndAlternatives";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналитик - Проблемы и их альтернативы";
            this.Activated += new System.EventHandler(this.Analyst_ProblemAndAlternatives_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlternatives)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDeleteProblem;
        private System.Windows.Forms.Button buttonAddProblem;
        private System.Windows.Forms.Button buttonEditProblem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxAlternativeAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddAlternative;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewAlternatives;
        private System.Windows.Forms.ComboBox comboBoxProblem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonTurnAnalystProblem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button buttonCloseAnalystProblem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button buttonEditAlternative;
        private System.Windows.Forms.Button buttonDeleteAlternative;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelError;
    }
}