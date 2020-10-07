namespace MyProject1
{
    partial class ExpertMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpertMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExpertMenuTurn = new System.Windows.Forms.Button();
            this.buttonExpertMenuClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBoxProblems = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxTests = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.buttonExpertMenuTurn);
            this.panel1.Controls.Add(this.buttonExpertMenuClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 32);
            this.panel1.TabIndex = 46;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // buttonExpertMenuTurn
            // 
            this.buttonExpertMenuTurn.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpertMenuTurn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExpertMenuTurn.BackgroundImage")));
            this.buttonExpertMenuTurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExpertMenuTurn.FlatAppearance.BorderSize = 0;
            this.buttonExpertMenuTurn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonExpertMenuTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertMenuTurn.Location = new System.Drawing.Point(560, 1);
            this.buttonExpertMenuTurn.Name = "buttonExpertMenuTurn";
            this.buttonExpertMenuTurn.Size = new System.Drawing.Size(47, 32);
            this.buttonExpertMenuTurn.TabIndex = 50;
            this.buttonExpertMenuTurn.UseVisualStyleBackColor = false;
            // 
            // buttonExpertMenuClose
            // 
            this.buttonExpertMenuClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpertMenuClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExpertMenuClose.BackgroundImage")));
            this.buttonExpertMenuClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExpertMenuClose.FlatAppearance.BorderSize = 0;
            this.buttonExpertMenuClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonExpertMenuClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertMenuClose.Location = new System.Drawing.Point(613, 1);
            this.buttonExpertMenuClose.Name = "buttonExpertMenuClose";
            this.buttonExpertMenuClose.Size = new System.Drawing.Size(47, 32);
            this.buttonExpertMenuClose.TabIndex = 49;
            this.buttonExpertMenuClose.UseVisualStyleBackColor = false;
            this.buttonExpertMenuClose.Click += new System.EventHandler(this.buttonExpertProblemClose_Click);
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
            this.label24.Size = new System.Drawing.Size(185, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Эксперт - Основное меню";
            // 
            // comboBoxProblems
            // 
            this.comboBoxProblems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProblems.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxProblems.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProblems.FormattingEnabled = true;
            this.comboBoxProblems.Location = new System.Drawing.Point(132, 138);
            this.comboBoxProblems.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.comboBoxProblems.Name = "comboBoxProblems";
            this.comboBoxProblems.Size = new System.Drawing.Size(458, 25);
            this.comboBoxProblems.TabIndex = 95;
            this.comboBoxProblems.SelectionChangeCommitted += new System.EventHandler(this.comboBoxProblems_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(40, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 96;
            this.label3.Text = "Эксперт:";
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFIO.Location = new System.Drawing.Point(117, 65);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(0, 21);
            this.labelFIO.TabIndex = 98;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(40, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 21);
            this.label4.TabIndex = 99;
            this.label4.Text = "Проблема:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(40, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 21);
            this.label5.TabIndex = 102;
            this.label5.Text = "Доступность:";
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.Orange;
            this.buttonOk.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonOk.FlatAppearance.BorderSize = 0;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.ForeColor = System.Drawing.Color.Black;
            this.buttonOk.Location = new System.Drawing.Point(223, 302);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(207, 33);
            this.buttonOk.TabIndex = 109;
            this.buttonOk.TabStop = false;
            this.buttonOk.Text = "Открыть оценивание";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(150, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 21);
            this.label2.TabIndex = 114;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(128, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(377, 20);
            this.label7.TabIndex = 140;
            this.label7.Text = "Аналитик еще не назначил вам ни одной проблемы";
            this.label7.Visible = false;
            // 
            // comboBoxTests
            // 
            this.comboBoxTests.BackColor = System.Drawing.Color.White;
            this.comboBoxTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTests.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxTests.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTests.FormattingEnabled = true;
            this.comboBoxTests.Items.AddRange(new object[] {
            "Парных сравнений",
            "Взвешенных экспертных оценок",
            "Предпочтения",
            "Ранга",
            "Полного попарного сравнения"});
            this.comboBoxTests.Location = new System.Drawing.Point(106, 194);
            this.comboBoxTests.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.comboBoxTests.Name = "comboBoxTests";
            this.comboBoxTests.Size = new System.Drawing.Size(247, 25);
            this.comboBoxTests.TabIndex = 141;
            this.comboBoxTests.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTests_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(40, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 21);
            this.label6.TabIndex = 142;
            this.label6.Text = "Метод:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(40, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 21);
            this.label8.TabIndex = 143;
            this.label8.Text = "Статус оценивания:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(197, 243);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 21);
            this.labelStatus.TabIndex = 144;
            // 
            // ExpertMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(660, 370);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxTests);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxProblems);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ExpertMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Эксперт - основное меню";
            this.Load += new System.EventHandler(this.ExpertMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox comboBoxProblems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonExpertMenuClose;
        private System.Windows.Forms.Button buttonExpertMenuTurn;
        private System.Windows.Forms.ComboBox comboBoxTests;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelStatus;
    }
}