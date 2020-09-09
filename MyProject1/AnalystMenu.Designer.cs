namespace MyProject1
{
    partial class AnalystMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalystMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.buttonAnalystProblemsAlternatives = new System.Windows.Forms.Button();
            this.buttonExperts = new System.Windows.Forms.Button();
            this.buttonExpertsProblems = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonInterrogation = new System.Windows.Forms.Button();
            this.системаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьПарольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTurnAnalystProblem = new System.Windows.Forms.Button();
            this.buttonCloseAnalystProblem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(389, 32);
            this.panel1.TabIndex = 44;
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
            this.label24.Size = new System.Drawing.Size(190, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Аналитик - Основное меню";
            // 
            // buttonAnalystProblemsAlternatives
            // 
            this.buttonAnalystProblemsAlternatives.BackColor = System.Drawing.Color.NavajoWhite;
            this.buttonAnalystProblemsAlternatives.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonAnalystProblemsAlternatives.FlatAppearance.BorderSize = 0;
            this.buttonAnalystProblemsAlternatives.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.buttonAnalystProblemsAlternatives.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.buttonAnalystProblemsAlternatives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnalystProblemsAlternatives.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAnalystProblemsAlternatives.ForeColor = System.Drawing.Color.Black;
            this.buttonAnalystProblemsAlternatives.Location = new System.Drawing.Point(66, 97);
            this.buttonAnalystProblemsAlternatives.Name = "buttonAnalystProblemsAlternatives";
            this.buttonAnalystProblemsAlternatives.Size = new System.Drawing.Size(261, 30);
            this.buttonAnalystProblemsAlternatives.TabIndex = 91;
            this.buttonAnalystProblemsAlternatives.Text = "Проблемы и их альтернативы";
            this.buttonAnalystProblemsAlternatives.UseVisualStyleBackColor = false;
            this.buttonAnalystProblemsAlternatives.Click += new System.EventHandler(this.buttonAnalystProblemsAlternatives_Click);
            // 
            // buttonExperts
            // 
            this.buttonExperts.BackColor = System.Drawing.Color.NavajoWhite;
            this.buttonExperts.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonExperts.FlatAppearance.BorderSize = 0;
            this.buttonExperts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.buttonExperts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.buttonExperts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExperts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExperts.ForeColor = System.Drawing.Color.Black;
            this.buttonExperts.Location = new System.Drawing.Point(66, 148);
            this.buttonExperts.Name = "buttonExperts";
            this.buttonExperts.Size = new System.Drawing.Size(261, 30);
            this.buttonExperts.TabIndex = 92;
            this.buttonExperts.Text = "Эксперты и их компетентность";
            this.buttonExperts.UseVisualStyleBackColor = false;
            this.buttonExperts.Click += new System.EventHandler(this.buttonExperts_Click);
            // 
            // buttonExpertsProblems
            // 
            this.buttonExpertsProblems.BackColor = System.Drawing.Color.NavajoWhite;
            this.buttonExpertsProblems.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonExpertsProblems.FlatAppearance.BorderSize = 0;
            this.buttonExpertsProblems.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.buttonExpertsProblems.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.buttonExpertsProblems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertsProblems.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExpertsProblems.ForeColor = System.Drawing.Color.Black;
            this.buttonExpertsProblems.Location = new System.Drawing.Point(66, 199);
            this.buttonExpertsProblems.Name = "buttonExpertsProblems";
            this.buttonExpertsProblems.Size = new System.Drawing.Size(261, 30);
            this.buttonExpertsProblems.TabIndex = 93;
            this.buttonExpertsProblems.Text = "Назначить проблемы экспертам";
            this.buttonExpertsProblems.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.системаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 32);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(389, 34);
            this.menuStrip1.TabIndex = 101;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buttonInterrogation
            // 
            this.buttonInterrogation.BackColor = System.Drawing.Color.NavajoWhite;
            this.buttonInterrogation.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonInterrogation.FlatAppearance.BorderSize = 0;
            this.buttonInterrogation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.buttonInterrogation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.buttonInterrogation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInterrogation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInterrogation.ForeColor = System.Drawing.Color.Black;
            this.buttonInterrogation.Location = new System.Drawing.Point(66, 248);
            this.buttonInterrogation.Name = "buttonInterrogation";
            this.buttonInterrogation.Size = new System.Drawing.Size(261, 30);
            this.buttonInterrogation.TabIndex = 102;
            this.buttonInterrogation.Text = "К результатам опросов";
            this.buttonInterrogation.UseVisualStyleBackColor = false;
            this.buttonInterrogation.Click += new System.EventHandler(this.buttonInterrogation_Click);
            // 
            // системаToolStripMenuItem
            // 
            this.системаToolStripMenuItem.BackgroundImage = global::MyProject1.Properties.Resources.icons8_menu_20;
            this.системаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьПарольToolStripMenuItem});
            this.системаToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.системаToolStripMenuItem.Name = "системаToolStripMenuItem";
            this.системаToolStripMenuItem.Size = new System.Drawing.Size(24, 21);
            this.системаToolStripMenuItem.Text = " ";
            // 
            // изменитьПарольToolStripMenuItem
            // 
            this.изменитьПарольToolStripMenuItem.Name = "изменитьПарольToolStripMenuItem";
            this.изменитьПарольToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.изменитьПарольToolStripMenuItem.Text = "Изменить пароль";
            // 
            // buttonTurnAnalystProblem
            // 
            this.buttonTurnAnalystProblem.BackColor = System.Drawing.Color.Transparent;
            this.buttonTurnAnalystProblem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTurnAnalystProblem.BackgroundImage")));
            this.buttonTurnAnalystProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTurnAnalystProblem.FlatAppearance.BorderSize = 0;
            this.buttonTurnAnalystProblem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonTurnAnalystProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTurnAnalystProblem.Location = new System.Drawing.Point(289, 0);
            this.buttonTurnAnalystProblem.Name = "buttonTurnAnalystProblem";
            this.buttonTurnAnalystProblem.Size = new System.Drawing.Size(47, 32);
            this.buttonTurnAnalystProblem.TabIndex = 45;
            this.buttonTurnAnalystProblem.UseVisualStyleBackColor = false;
            this.buttonTurnAnalystProblem.Click += new System.EventHandler(this.buttonTurnAnalystProblem_Click);
            // 
            // buttonCloseAnalystProblem
            // 
            this.buttonCloseAnalystProblem.BackColor = System.Drawing.Color.Transparent;
            this.buttonCloseAnalystProblem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCloseAnalystProblem.BackgroundImage")));
            this.buttonCloseAnalystProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCloseAnalystProblem.FlatAppearance.BorderSize = 0;
            this.buttonCloseAnalystProblem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonCloseAnalystProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseAnalystProblem.Location = new System.Drawing.Point(342, 0);
            this.buttonCloseAnalystProblem.Name = "buttonCloseAnalystProblem";
            this.buttonCloseAnalystProblem.Size = new System.Drawing.Size(47, 32);
            this.buttonCloseAnalystProblem.TabIndex = 44;
            this.buttonCloseAnalystProblem.UseVisualStyleBackColor = false;
            this.buttonCloseAnalystProblem.Click += new System.EventHandler(this.buttonCloseAnalystProblem_Click);
            // 
            // AnalystMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(389, 324);
            this.Controls.Add(this.buttonInterrogation);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonExpertsProblems);
            this.Controls.Add(this.buttonExperts);
            this.Controls.Add(this.buttonAnalystProblemsAlternatives);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnalystMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналитик - Основное меню";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonTurnAnalystProblem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button buttonCloseAnalystProblem;
        private System.Windows.Forms.Button buttonAnalystProblemsAlternatives;
        private System.Windows.Forms.Button buttonExperts;
        private System.Windows.Forms.Button buttonExpertsProblems;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem системаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьПарольToolStripMenuItem;
        private System.Windows.Forms.Button buttonInterrogation;
    }
}