namespace MyProject1
{
    partial class GeneralLogin
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralLogin));
            this.buttonCloseLogin = new System.Windows.Forms.Button();
            this.buttonTurnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonExpertLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAnalystLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCloseLogin
            // 
            this.buttonCloseLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonCloseLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCloseLogin.BackgroundImage")));
            this.buttonCloseLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCloseLogin.FlatAppearance.BorderSize = 0;
            this.buttonCloseLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonCloseLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseLogin.Location = new System.Drawing.Point(364, 3);
            this.buttonCloseLogin.Name = "buttonCloseLogin";
            this.buttonCloseLogin.Size = new System.Drawing.Size(43, 29);
            this.buttonCloseLogin.TabIndex = 0;
            this.buttonCloseLogin.UseVisualStyleBackColor = false;
            this.buttonCloseLogin.Click += new System.EventHandler(this.buttonCloseLogin_Click);
            // 
            // buttonTurnLogin
            // 
            this.buttonTurnLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonTurnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTurnLogin.BackgroundImage")));
            this.buttonTurnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTurnLogin.FlatAppearance.BorderSize = 0;
            this.buttonTurnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonTurnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTurnLogin.Location = new System.Drawing.Point(315, 1);
            this.buttonTurnLogin.Name = "buttonTurnLogin";
            this.buttonTurnLogin.Size = new System.Drawing.Size(43, 29);
            this.buttonTurnLogin.TabIndex = 1;
            this.buttonTurnLogin.UseVisualStyleBackColor = false;
            this.buttonTurnLogin.Click += new System.EventHandler(this.buttonTurnLogin_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Системный анализ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Orange;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 22);
            this.label2.TabIndex = 46;
            this.label2.Text = "S";
            // 
            // buttonExpertLogin
            // 
            this.buttonExpertLogin.BackColor = System.Drawing.Color.Orange;
            this.buttonExpertLogin.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonExpertLogin.FlatAppearance.BorderSize = 0;
            this.buttonExpertLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExpertLogin.ForeColor = System.Drawing.Color.Black;
            this.buttonExpertLogin.Location = new System.Drawing.Point(60, 145);
            this.buttonExpertLogin.Name = "buttonExpertLogin";
            this.buttonExpertLogin.Size = new System.Drawing.Size(122, 40);
            this.buttonExpertLogin.TabIndex = 47;
            this.buttonExpertLogin.Text = "Эксперт";
            this.buttonExpertLogin.UseVisualStyleBackColor = false;
            this.buttonExpertLogin.Click += new System.EventHandler(this.buttonExpertLogin_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(144, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 48;
            this.label3.Text = "Войти как:";
            // 
            // buttonAnalystLogin
            // 
            this.buttonAnalystLogin.BackColor = System.Drawing.Color.Orange;
            this.buttonAnalystLogin.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonAnalystLogin.FlatAppearance.BorderSize = 0;
            this.buttonAnalystLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnalystLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAnalystLogin.ForeColor = System.Drawing.Color.Black;
            this.buttonAnalystLogin.Location = new System.Drawing.Point(215, 145);
            this.buttonAnalystLogin.Name = "buttonAnalystLogin";
            this.buttonAnalystLogin.Size = new System.Drawing.Size(122, 40);
            this.buttonAnalystLogin.TabIndex = 49;
            this.buttonAnalystLogin.Text = "Аналитик";
            this.buttonAnalystLogin.UseVisualStyleBackColor = false;
            this.buttonAnalystLogin.Click += new System.EventHandler(this.buttonAnalystLogin_Click);
            // 
            // GeneralLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(409, 244);
            this.Controls.Add(this.buttonAnalystLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonExpertLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTurnLogin);
            this.Controls.Add(this.buttonCloseLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneralLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Системный анализ";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GeneralLogin_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCloseLogin;
        private System.Windows.Forms.Button buttonTurnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExpertLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAnalystLogin;
    }
}

