namespace MyProject1
{
    partial class AuthorizationExpert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationExpert));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonExpertLogin = new System.Windows.Forms.Button();
            this.comboBoxFIO = new System.Windows.Forms.ComboBox();
            this.buttonExpertLoginClose = new System.Windows.Forms.Button();
            this.buttonExpertLoginTurn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.buttonExpertLoginClose);
            this.panel1.Controls.Add(this.buttonExpertLoginTurn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 32);
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
            this.label24.Size = new System.Drawing.Size(106, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Эксперт - Вход";
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFIO.Location = new System.Drawing.Point(93, 107);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(49, 21);
            this.labelFIO.TabIndex = 45;
            this.labelFIO.Text = "ФИО:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(93, 148);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(66, 21);
            this.labelPassword.TabIndex = 46;
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.Black;
            this.textBoxPassword.Location = new System.Drawing.Point(177, 144);
            this.textBoxPassword.MaxLength = 20;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(188, 25);
            this.textBoxPassword.TabIndex = 48;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonExpertLogin
            // 
            this.buttonExpertLogin.BackColor = System.Drawing.Color.Orange;
            this.buttonExpertLogin.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonExpertLogin.FlatAppearance.BorderSize = 0;
            this.buttonExpertLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExpertLogin.ForeColor = System.Drawing.Color.Black;
            this.buttonExpertLogin.Location = new System.Drawing.Point(207, 208);
            this.buttonExpertLogin.Name = "buttonExpertLogin";
            this.buttonExpertLogin.Size = new System.Drawing.Size(84, 33);
            this.buttonExpertLogin.TabIndex = 91;
            this.buttonExpertLogin.Text = "Войти";
            this.buttonExpertLogin.UseVisualStyleBackColor = false;
            this.buttonExpertLogin.Click += new System.EventHandler(this.buttonExpertLogin_Click);
            // 
            // comboBoxFIO
            // 
            this.comboBoxFIO.BackColor = System.Drawing.Color.White;
            this.comboBoxFIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFIO.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxFIO.ForeColor = System.Drawing.Color.Black;
            this.comboBoxFIO.FormattingEnabled = true;
            this.comboBoxFIO.Location = new System.Drawing.Point(177, 103);
            this.comboBoxFIO.Name = "comboBoxFIO";
            this.comboBoxFIO.Size = new System.Drawing.Size(188, 25);
            this.comboBoxFIO.TabIndex = 92;
            // 
            // buttonExpertLoginClose
            // 
            this.buttonExpertLoginClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpertLoginClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExpertLoginClose.BackgroundImage")));
            this.buttonExpertLoginClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExpertLoginClose.FlatAppearance.BorderSize = 0;
            this.buttonExpertLoginClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonExpertLoginClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertLoginClose.Location = new System.Drawing.Point(449, 1);
            this.buttonExpertLoginClose.Name = "buttonExpertLoginClose";
            this.buttonExpertLoginClose.Size = new System.Drawing.Size(47, 30);
            this.buttonExpertLoginClose.TabIndex = 45;
            this.buttonExpertLoginClose.UseVisualStyleBackColor = false;
            this.buttonExpertLoginClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonExpertLoginTurn
            // 
            this.buttonExpertLoginTurn.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpertLoginTurn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExpertLoginTurn.BackgroundImage")));
            this.buttonExpertLoginTurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExpertLoginTurn.FlatAppearance.BorderSize = 0;
            this.buttonExpertLoginTurn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonExpertLoginTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertLoginTurn.Location = new System.Drawing.Point(396, 1);
            this.buttonExpertLoginTurn.Name = "buttonExpertLoginTurn";
            this.buttonExpertLoginTurn.Size = new System.Drawing.Size(47, 30);
            this.buttonExpertLoginTurn.TabIndex = 48;
            this.buttonExpertLoginTurn.UseVisualStyleBackColor = false;
            this.buttonExpertLoginTurn.Click += new System.EventHandler(this.button1_Click);
            // 
            // AuthorizationExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(499, 271);
            this.Controls.Add(this.comboBoxFIO);
            this.Controls.Add(this.buttonExpertLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthorizationExpert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button buttonExpertLoginTurn;
        private System.Windows.Forms.Button buttonExpertLoginClose;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonExpertLogin;
        private System.Windows.Forms.ComboBox comboBoxFIO;
    }
}