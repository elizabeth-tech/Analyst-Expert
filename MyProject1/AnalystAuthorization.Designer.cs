namespace MyProject1
{
    partial class AnalystAuthorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalystAuthorization));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAnalystLoginClose = new System.Windows.Forms.Button();
            this.buttonAnalystLoginTurn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.buttonAnalystLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.buttonAnalystLoginClose);
            this.panel1.Controls.Add(this.buttonAnalystLoginTurn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 32);
            this.panel1.TabIndex = 45;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // buttonAnalystLoginClose
            // 
            this.buttonAnalystLoginClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonAnalystLoginClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAnalystLoginClose.BackgroundImage")));
            this.buttonAnalystLoginClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAnalystLoginClose.FlatAppearance.BorderSize = 0;
            this.buttonAnalystLoginClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonAnalystLoginClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnalystLoginClose.Location = new System.Drawing.Point(452, 1);
            this.buttonAnalystLoginClose.Name = "buttonAnalystLoginClose";
            this.buttonAnalystLoginClose.Size = new System.Drawing.Size(47, 31);
            this.buttonAnalystLoginClose.TabIndex = 45;
            this.buttonAnalystLoginClose.UseVisualStyleBackColor = false;
            this.buttonAnalystLoginClose.Click += new System.EventHandler(this.buttonAnalystLoginClose_Click);
            // 
            // buttonAnalystLoginTurn
            // 
            this.buttonAnalystLoginTurn.BackColor = System.Drawing.Color.Transparent;
            this.buttonAnalystLoginTurn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAnalystLoginTurn.BackgroundImage")));
            this.buttonAnalystLoginTurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAnalystLoginTurn.FlatAppearance.BorderSize = 0;
            this.buttonAnalystLoginTurn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonAnalystLoginTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnalystLoginTurn.Location = new System.Drawing.Point(399, 1);
            this.buttonAnalystLoginTurn.Name = "buttonAnalystLoginTurn";
            this.buttonAnalystLoginTurn.Size = new System.Drawing.Size(47, 31);
            this.buttonAnalystLoginTurn.TabIndex = 48;
            this.buttonAnalystLoginTurn.UseVisualStyleBackColor = false;
            this.buttonAnalystLoginTurn.Click += new System.EventHandler(this.buttonExpertLoginTurn_Click);
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
            this.label24.Size = new System.Drawing.Size(111, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Аналитик - Вход";
            // 
            // buttonAnalystLogin
            // 
            this.buttonAnalystLogin.BackColor = System.Drawing.Color.Orange;
            this.buttonAnalystLogin.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonAnalystLogin.FlatAppearance.BorderSize = 0;
            this.buttonAnalystLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnalystLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAnalystLogin.ForeColor = System.Drawing.Color.Black;
            this.buttonAnalystLogin.Location = new System.Drawing.Point(209, 162);
            this.buttonAnalystLogin.Name = "buttonAnalystLogin";
            this.buttonAnalystLogin.Size = new System.Drawing.Size(84, 33);
            this.buttonAnalystLogin.TabIndex = 96;
            this.buttonAnalystLogin.Text = "Войти";
            this.buttonAnalystLogin.UseVisualStyleBackColor = false;
            this.buttonAnalystLogin.Click += new System.EventHandler(this.buttonAnalystLogin_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.Black;
            this.textBoxPassword.Location = new System.Drawing.Point(162, 112);
            this.textBoxPassword.MaxLength = 20;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(188, 25);
            this.textBoxPassword.TabIndex = 95;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(93, 112);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(63, 21);
            this.labelPassword.TabIndex = 94;
            this.labelPassword.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(176, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 21);
            this.label2.TabIndex = 97;
            this.label2.Text = "Добро пожаловать!";
            // 
            // AnalystAuthorization
            // 
            this.AcceptButton = this.buttonAnalystLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(499, 223);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAnalystLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnalystAuthorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналитик - Вход";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAnalystLoginClose;
        private System.Windows.Forms.Button buttonAnalystLoginTurn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button buttonAnalystLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label label2;
    }
}