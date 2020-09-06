namespace MyProject1
{
    partial class Analyst_ExpertChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analyst_ExpertChoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.buttonTurnAnalystAlternative = new System.Windows.Forms.Button();
            this.buttonCloseAnalystAlternative = new System.Windows.Forms.Button();
            this.dataGridViewAnalyst_ExpertChoice = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.кРезультатамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAnalystNext = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnalyst_ExpertChoice)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.buttonTurnAnalystAlternative);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.buttonCloseAnalystAlternative);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 32);
            this.panel1.TabIndex = 45;
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
            this.label24.Size = new System.Drawing.Size(196, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Аналитик - Выбор экспертов";
            // 
            // buttonTurnAnalystAlternative
            // 
            this.buttonTurnAnalystAlternative.BackColor = System.Drawing.Color.Transparent;
            this.buttonTurnAnalystAlternative.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTurnAnalystAlternative.BackgroundImage")));
            this.buttonTurnAnalystAlternative.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTurnAnalystAlternative.FlatAppearance.BorderSize = 0;
            this.buttonTurnAnalystAlternative.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonTurnAnalystAlternative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTurnAnalystAlternative.Location = new System.Drawing.Point(700, 0);
            this.buttonTurnAnalystAlternative.Name = "buttonTurnAnalystAlternative";
            this.buttonTurnAnalystAlternative.Size = new System.Drawing.Size(47, 30);
            this.buttonTurnAnalystAlternative.TabIndex = 45;
            this.buttonTurnAnalystAlternative.UseVisualStyleBackColor = false;
            this.buttonTurnAnalystAlternative.Click += new System.EventHandler(this.buttonTurnAnalystAlternative_Click);
            // 
            // buttonCloseAnalystAlternative
            // 
            this.buttonCloseAnalystAlternative.BackColor = System.Drawing.Color.Transparent;
            this.buttonCloseAnalystAlternative.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCloseAnalystAlternative.BackgroundImage")));
            this.buttonCloseAnalystAlternative.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCloseAnalystAlternative.FlatAppearance.BorderSize = 0;
            this.buttonCloseAnalystAlternative.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonCloseAnalystAlternative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseAnalystAlternative.Location = new System.Drawing.Point(753, 1);
            this.buttonCloseAnalystAlternative.Name = "buttonCloseAnalystAlternative";
            this.buttonCloseAnalystAlternative.Size = new System.Drawing.Size(47, 30);
            this.buttonCloseAnalystAlternative.TabIndex = 44;
            this.buttonCloseAnalystAlternative.UseVisualStyleBackColor = false;
            this.buttonCloseAnalystAlternative.Click += new System.EventHandler(this.buttonCloseAnalystAlternative_Click);
            // 
            // dataGridViewAnalyst_ExpertChoice
            // 
            this.dataGridViewAnalyst_ExpertChoice.AllowUserToAddRows = false;
            this.dataGridViewAnalyst_ExpertChoice.AllowUserToDeleteRows = false;
            this.dataGridViewAnalyst_ExpertChoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewAnalyst_ExpertChoice.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewAnalyst_ExpertChoice.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAnalyst_ExpertChoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewAnalyst_ExpertChoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(205)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAnalyst_ExpertChoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAnalyst_ExpertChoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnalyst_ExpertChoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column11,
            this.dataGridViewTextBoxColumn2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAnalyst_ExpertChoice.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAnalyst_ExpertChoice.EnableHeadersVisualStyles = false;
            this.dataGridViewAnalyst_ExpertChoice.Location = new System.Drawing.Point(19, 107);
            this.dataGridViewAnalyst_ExpertChoice.Name = "dataGridViewAnalyst_ExpertChoice";
            this.dataGridViewAnalyst_ExpertChoice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(218)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAnalyst_ExpertChoice.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(8, 4, 0, 0);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewAnalyst_ExpertChoice.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewAnalyst_ExpertChoice.Size = new System.Drawing.Size(761, 461);
            this.dataGridViewAnalyst_ExpertChoice.TabIndex = 88;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "";
            this.Column9.Name = "Column9";
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column9.Width = 30;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "№";
            this.Column11.Name = "Column11";
            this.Column11.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Эксперт";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Должность";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
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
            this.toolStrip1.Location = new System.Drawing.Point(19, 79);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(88, 25);
            this.toolStrip1.TabIndex = 96;
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
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кРезультатамToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 32);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 97;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // кРезультатамToolStripMenuItem
            // 
            this.кРезультатамToolStripMenuItem.Name = "кРезультатамToolStripMenuItem";
            this.кРезультатамToolStripMenuItem.Size = new System.Drawing.Size(106, 21);
            this.кРезультатамToolStripMenuItem.Text = "К результатам";
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
            this.buttonAnalystNext.TabIndex = 98;
            this.buttonAnalystNext.Text = "Далее";
            this.buttonAnalystNext.UseVisualStyleBackColor = false;
            this.buttonAnalystNext.Click += new System.EventHandler(this.buttonAnalystNext_Click);
            // 
            // Analyst_ExpertChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 683);
            this.Controls.Add(this.buttonAnalystNext);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridViewAnalyst_ExpertChoice);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Analyst_ExpertChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналитик - Выбор экспертов";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnalyst_ExpertChoice)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonTurnAnalystAlternative;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button buttonCloseAnalystAlternative;
        private System.Windows.Forms.DataGridView dataGridViewAnalyst_ExpertChoice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem кРезультатамToolStripMenuItem;
        private System.Windows.Forms.Button buttonAnalystNext;
    }
}