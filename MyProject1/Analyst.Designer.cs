namespace MyProject1
{
    partial class Analyst
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analyst));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.dataGridViewProblems = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAnalystNext = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.buttonTurnAnalystProblem = new System.Windows.Forms.Button();
            this.buttonCloseAnalystProblem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProblems)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(800, 32);
            this.panel1.TabIndex = 43;
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
            this.label24.Size = new System.Drawing.Size(197, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Аналитик - выбор проблемы";
            // 
            // dataGridViewProblems
            // 
            this.dataGridViewProblems.AllowUserToAddRows = false;
            this.dataGridViewProblems.AllowUserToDeleteRows = false;
            this.dataGridViewProblems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewProblems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewProblems.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProblems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewProblems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(205)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProblems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProblems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column10,
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProblems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProblems.EnableHeadersVisualStyles = false;
            this.dataGridViewProblems.Location = new System.Drawing.Point(23, 100);
            this.dataGridViewProblems.Name = "dataGridViewProblems";
            this.dataGridViewProblems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(218)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProblems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(8, 4, 0, 0);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewProblems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewProblems.Size = new System.Drawing.Size(757, 476);
            this.dataGridViewProblems.TabIndex = 88;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 30;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "№";
            this.Column10.Name = "Column10";
            this.Column10.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Проблемы";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 600;
            // 
            // buttonAnalystNext
            // 
            this.buttonAnalystNext.BackColor = System.Drawing.Color.Orange;
            this.buttonAnalystNext.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonAnalystNext.FlatAppearance.BorderSize = 0;
            this.buttonAnalystNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnalystNext.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAnalystNext.ForeColor = System.Drawing.Color.Black;
            this.buttonAnalystNext.Location = new System.Drawing.Point(682, 609);
            this.buttonAnalystNext.Name = "buttonAnalystNext";
            this.buttonAnalystNext.Size = new System.Drawing.Size(98, 35);
            this.buttonAnalystNext.TabIndex = 90;
            this.buttonAnalystNext.Text = "Далее";
            this.buttonAnalystNext.UseVisualStyleBackColor = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(23, 72);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(96, 25);
            this.toolStrip1.TabIndex = 91;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::MyProject1.Properties.Resources.icons8_plus_16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Добавить новую проблему";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::MyProject1.Properties.Resources.icons8_edit_16;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Редактировать выбранную проблему";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::MyProject1.Properties.Resources.icons8_clear_symbol_16;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Удалить выбранную проблему";
            // 
            // buttonTurnAnalystProblem
            // 
            this.buttonTurnAnalystProblem.BackColor = System.Drawing.Color.Transparent;
            this.buttonTurnAnalystProblem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTurnAnalystProblem.BackgroundImage")));
            this.buttonTurnAnalystProblem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTurnAnalystProblem.FlatAppearance.BorderSize = 0;
            this.buttonTurnAnalystProblem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonTurnAnalystProblem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTurnAnalystProblem.Location = new System.Drawing.Point(700, 1);
            this.buttonTurnAnalystProblem.Name = "buttonTurnAnalystProblem";
            this.buttonTurnAnalystProblem.Size = new System.Drawing.Size(47, 30);
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
            this.buttonCloseAnalystProblem.Location = new System.Drawing.Point(753, 1);
            this.buttonCloseAnalystProblem.Name = "buttonCloseAnalystProblem";
            this.buttonCloseAnalystProblem.Size = new System.Drawing.Size(47, 30);
            this.buttonCloseAnalystProblem.TabIndex = 44;
            this.buttonCloseAnalystProblem.UseVisualStyleBackColor = false;
            this.buttonCloseAnalystProblem.Click += new System.EventHandler(this.buttonCloseAnalystProblem_Click);
            // 
            // Analyst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 683);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonAnalystNext);
            this.Controls.Add(this.dataGridViewProblems);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Analyst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProblems)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTurnAnalystProblem;
        private System.Windows.Forms.Button buttonCloseAnalystProblem;
        private System.Windows.Forms.DataGridView dataGridViewProblems;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button buttonAnalystNext;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}