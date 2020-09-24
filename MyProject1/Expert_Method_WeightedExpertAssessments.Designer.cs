namespace MyProject1
{
    partial class Expert_Method_WeightedExpertAssessments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Expert_Method_WeightedExpertAssessments));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExpertLoginClose = new System.Windows.Forms.Button();
            this.buttonExpertLoginTurn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxProblem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewAlternatives = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSaveTest = new System.Windows.Forms.Button();
            this.labelHelp = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelError = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlternatives)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(680, 32);
            this.panel1.TabIndex = 46;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // buttonExpertLoginClose
            // 
            this.buttonExpertLoginClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpertLoginClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExpertLoginClose.BackgroundImage")));
            this.buttonExpertLoginClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExpertLoginClose.FlatAppearance.BorderSize = 0;
            this.buttonExpertLoginClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonExpertLoginClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertLoginClose.Location = new System.Drawing.Point(633, 2);
            this.buttonExpertLoginClose.Name = "buttonExpertLoginClose";
            this.buttonExpertLoginClose.Size = new System.Drawing.Size(47, 30);
            this.buttonExpertLoginClose.TabIndex = 45;
            this.buttonExpertLoginClose.UseVisualStyleBackColor = false;
            this.buttonExpertLoginClose.Click += new System.EventHandler(this.buttonExpertLoginClose_Click);
            // 
            // buttonExpertLoginTurn
            // 
            this.buttonExpertLoginTurn.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpertLoginTurn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExpertLoginTurn.BackgroundImage")));
            this.buttonExpertLoginTurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExpertLoginTurn.FlatAppearance.BorderSize = 0;
            this.buttonExpertLoginTurn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonExpertLoginTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpertLoginTurn.Location = new System.Drawing.Point(580, 2);
            this.buttonExpertLoginTurn.Name = "buttonExpertLoginTurn";
            this.buttonExpertLoginTurn.Size = new System.Drawing.Size(47, 30);
            this.buttonExpertLoginTurn.TabIndex = 48;
            this.buttonExpertLoginTurn.UseVisualStyleBackColor = false;
            this.buttonExpertLoginTurn.Click += new System.EventHandler(this.buttonExpertLoginTurn_Click);
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
            this.label24.Size = new System.Drawing.Size(331, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Эксперт - Метод взвешенных экспертных оценок";
            // 
            // textBoxProblem
            // 
            this.textBoxProblem.BackColor = System.Drawing.Color.White;
            this.textBoxProblem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxProblem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProblem.ForeColor = System.Drawing.Color.Black;
            this.textBoxProblem.Location = new System.Drawing.Point(67, 85);
            this.textBoxProblem.MaxLength = 20;
            this.textBoxProblem.Name = "textBoxProblem";
            this.textBoxProblem.ReadOnly = true;
            this.textBoxProblem.Size = new System.Drawing.Size(541, 18);
            this.textBoxProblem.TabIndex = 134;
            this.textBoxProblem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(272, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 133;
            this.label2.Text = "Альтернативы";
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(205)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAlternatives.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewAlternatives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlternatives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAlternatives.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewAlternatives.EnableHeadersVisualStyles = false;
            this.dataGridViewAlternatives.Location = new System.Drawing.Point(67, 157);
            this.dataGridViewAlternatives.Name = "dataGridViewAlternatives";
            this.dataGridViewAlternatives.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(218)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAlternatives.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(8, 4, 0, 0);
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewAlternatives.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewAlternatives.Size = new System.Drawing.Size(585, 247);
            this.dataGridViewAlternatives.TabIndex = 132;
            this.dataGridViewAlternatives.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAlternatives_CellEndEdit);
            this.dataGridViewAlternatives.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewAlternatives_EditingControlShowing);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Альтернативы";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 400;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Оценка";
            this.Column2.MaxInputLength = 5;
            this.Column2.Name = "Column2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(285, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 131;
            this.label3.Text = "Проблема";
            // 
            // buttonSaveTest
            // 
            this.buttonSaveTest.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonSaveTest.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonSaveTest.FlatAppearance.BorderSize = 0;
            this.buttonSaveTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveTest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveTest.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveTest.Location = new System.Drawing.Point(166, 458);
            this.buttonSaveTest.Name = "buttonSaveTest";
            this.buttonSaveTest.Size = new System.Drawing.Size(335, 33);
            this.buttonSaveTest.TabIndex = 135;
            this.buttonSaveTest.Text = "Завершить и отправить результаты";
            this.buttonSaveTest.UseVisualStyleBackColor = false;
            this.buttonSaveTest.Click += new System.EventHandler(this.buttonSaveTest_Click);
            // 
            // labelHelp
            // 
            this.labelHelp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labelHelp.Image = global::MyProject1.Properties.Resources.icons8_question_mark_20;
            this.labelHelp.Location = new System.Drawing.Point(574, 120);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(34, 34);
            this.labelHelp.TabIndex = 137;
            this.toolTip1.SetToolTip(this.labelHelp, "Диапазон каждой оценки должен быть от 0 до 100.\r\nПри этом сумма всех оценок должн" +
        "а быть равна 100");
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // labelError
            // 
            this.labelError.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(67, 419);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(541, 20);
            this.labelError.TabIndex = 138;
            this.labelError.Text = "Необходимо заполнить оценки для каждой альтернативы!";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelError.Visible = false;
            // 
            // Expert_Method_WeightedExpertAssessments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 535);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.buttonSaveTest);
            this.Controls.Add(this.textBoxProblem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewAlternatives);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Expert_Method_WeightedExpertAssessments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Эксперт- Метод взвешенных экспертных оценок";
            this.Load += new System.EventHandler(this.Expert_Method_WeightedExpertAssessments_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlternatives)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExpertLoginClose;
        private System.Windows.Forms.Button buttonExpertLoginTurn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxProblem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewAlternatives;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSaveTest;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label labelError;
    }
}