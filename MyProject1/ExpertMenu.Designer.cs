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
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.buttonExpertMenuClose = new System.Windows.Forms.Button();
            this.buttonExpertMenuTurn = new System.Windows.Forms.Button();
            this.tabControlExpertMenu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.buttonBack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControlExpertMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.buttonExpertMenuClose);
            this.panel1.Controls.Add(this.buttonExpertMenuTurn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1247, 32);
            this.panel1.TabIndex = 46;
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
            this.label24.Size = new System.Drawing.Size(185, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Эксперт - Основное меню";
            // 
            // buttonExpertMenuClose
            // 
            this.buttonExpertMenuClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpertMenuClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExpertMenuClose.BackgroundImage")));
            this.buttonExpertMenuClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExpertMenuClose.FlatAppearance.BorderSize = 0;
            this.buttonExpertMenuClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonExpertMenuClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertMenuClose.Location = new System.Drawing.Point(1200, 0);
            this.buttonExpertMenuClose.Name = "buttonExpertMenuClose";
            this.buttonExpertMenuClose.Size = new System.Drawing.Size(47, 30);
            this.buttonExpertMenuClose.TabIndex = 45;
            this.buttonExpertMenuClose.UseVisualStyleBackColor = false;
            this.buttonExpertMenuClose.Click += new System.EventHandler(this.buttonExpertProblemClose_Click);
            // 
            // buttonExpertMenuTurn
            // 
            this.buttonExpertMenuTurn.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpertMenuTurn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExpertMenuTurn.BackgroundImage")));
            this.buttonExpertMenuTurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExpertMenuTurn.FlatAppearance.BorderSize = 0;
            this.buttonExpertMenuTurn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonExpertMenuTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertMenuTurn.Location = new System.Drawing.Point(1147, 1);
            this.buttonExpertMenuTurn.Name = "buttonExpertMenuTurn";
            this.buttonExpertMenuTurn.Size = new System.Drawing.Size(47, 30);
            this.buttonExpertMenuTurn.TabIndex = 48;
            this.buttonExpertMenuTurn.UseVisualStyleBackColor = false;
            this.buttonExpertMenuTurn.Click += new System.EventHandler(this.buttonExpertProblemTurn_Click);
            // 
            // tabControlExpertMenu
            // 
            this.tabControlExpertMenu.Controls.Add(this.tabPage1);
            this.tabControlExpertMenu.Controls.Add(this.tabPage2);
            this.tabControlExpertMenu.Controls.Add(this.tabPage3);
            this.tabControlExpertMenu.Controls.Add(this.tabPage4);
            this.tabControlExpertMenu.Controls.Add(this.tabPage5);
            this.tabControlExpertMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlExpertMenu.Location = new System.Drawing.Point(10, 72);
            this.tabControlExpertMenu.Name = "tabControlExpertMenu";
            this.tabControlExpertMenu.SelectedIndex = 0;
            this.tabControlExpertMenu.Size = new System.Drawing.Size(1225, 551);
            this.tabControlExpertMenu.TabIndex = 47;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1217, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Парных сравнений";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1167, 525);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Взвешенных экспертных оценок";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(12, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(171, 21);
            this.label16.TabIndex = 48;
            this.label16.Text = "Оценивание методом:";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1167, 525);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Предпочтения";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1167, 525);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Ранга";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1167, 525);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Полного попарного сопоставления";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Orange;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.ForeColor = System.Drawing.Color.Black;
            this.buttonBack.Location = new System.Drawing.Point(14, 648);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(167, 35);
            this.buttonBack.TabIndex = 93;
            this.buttonBack.Text = "К выбору проблемы";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(990, 648);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 35);
            this.button1.TabIndex = 94;
            this.button1.Text = "Отправить результаты аналитику";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // MenuForExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1247, 720);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tabControlExpertMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForExpert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Эксперт - основное меню";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlExpertMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExpertMenuClose;
        private System.Windows.Forms.Button buttonExpertMenuTurn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TabControl tabControlExpertMenu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button button1;
    }
}