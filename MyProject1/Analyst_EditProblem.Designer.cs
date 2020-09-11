namespace MyProject1
{
    partial class Analyst_EditProblem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analyst_EditProblem));
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTurnAnalystProblem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.buttonCloseAnalystProblem = new System.Windows.Forms.Button();
            this.textBoxProblemName = new System.Windows.Forms.TextBox();
            this.textBoxNewProblemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(49, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 100;
            this.label3.Text = "Проблема";
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
            this.panel1.Size = new System.Drawing.Size(563, 32);
            this.panel1.TabIndex = 128;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // buttonTurnAnalystProblem
            // 
            this.buttonTurnAnalystProblem.BackColor = System.Drawing.Color.Transparent;
            this.buttonTurnAnalystProblem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTurnAnalystProblem.BackgroundImage")));
            this.buttonTurnAnalystProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTurnAnalystProblem.FlatAppearance.BorderSize = 0;
            this.buttonTurnAnalystProblem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonTurnAnalystProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTurnAnalystProblem.Location = new System.Drawing.Point(463, 1);
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
            this.label24.Size = new System.Drawing.Size(265, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Аналитик - Редактирование проблемы";
            // 
            // buttonCloseAnalystProblem
            // 
            this.buttonCloseAnalystProblem.BackColor = System.Drawing.Color.Transparent;
            this.buttonCloseAnalystProblem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCloseAnalystProblem.BackgroundImage")));
            this.buttonCloseAnalystProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCloseAnalystProblem.FlatAppearance.BorderSize = 0;
            this.buttonCloseAnalystProblem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonCloseAnalystProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseAnalystProblem.Location = new System.Drawing.Point(516, 0);
            this.buttonCloseAnalystProblem.Name = "buttonCloseAnalystProblem";
            this.buttonCloseAnalystProblem.Size = new System.Drawing.Size(47, 32);
            this.buttonCloseAnalystProblem.TabIndex = 44;
            this.buttonCloseAnalystProblem.UseVisualStyleBackColor = false;
            this.buttonCloseAnalystProblem.Click += new System.EventHandler(this.buttonCloseAnalystProblem_Click);
            // 
            // textBoxProblemName
            // 
            this.textBoxProblemName.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxProblemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxProblemName.Enabled = false;
            this.textBoxProblemName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProblemName.Location = new System.Drawing.Point(53, 94);
            this.textBoxProblemName.Multiline = true;
            this.textBoxProblemName.Name = "textBoxProblemName";
            this.textBoxProblemName.ReadOnly = true;
            this.textBoxProblemName.Size = new System.Drawing.Size(449, 23);
            this.textBoxProblemName.TabIndex = 129;
            // 
            // textBoxNewProblemName
            // 
            this.textBoxNewProblemName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNewProblemName.Location = new System.Drawing.Point(53, 154);
            this.textBoxNewProblemName.Name = "textBoxNewProblemName";
            this.textBoxNewProblemName.Size = new System.Drawing.Size(449, 25);
            this.textBoxNewProblemName.TabIndex = 131;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(49, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 130;
            this.label2.Text = "Изменить на";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Orange;
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(139, 218);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(107, 29);
            this.buttonSave.TabIndex = 133;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Orange;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancel.Location = new System.Drawing.Point(304, 218);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(107, 29);
            this.buttonCancel.TabIndex = 134;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Analyst_EditProblem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(563, 278);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxNewProblemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxProblemName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Analyst_EditProblem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналитик - Редактирование проблемы";
            this.Load += new System.EventHandler(this.Analyst_EditProblem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonTurnAnalystProblem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button buttonCloseAnalystProblem;
        private System.Windows.Forms.TextBox textBoxProblemName;
        private System.Windows.Forms.TextBox textBoxNewProblemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}