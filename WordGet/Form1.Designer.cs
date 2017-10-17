namespace WordGet
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_SaveWordInfo = new System.Windows.Forms.Button();
            this.defegslist = new System.Windows.Forms.DataGridView();
            this.Save = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Definition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Example = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.defegslist)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Exit.Location = new System.Drawing.Point(1212, 11);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(81, 30);
            this.button_Exit.TabIndex = 0;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_SaveWordInfo
            // 
            this.button_SaveWordInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SaveWordInfo.Location = new System.Drawing.Point(10, 11);
            this.button_SaveWordInfo.Name = "button_SaveWordInfo";
            this.button_SaveWordInfo.Size = new System.Drawing.Size(429, 30);
            this.button_SaveWordInfo.TabIndex = 1;
            this.button_SaveWordInfo.Text = "Save word infomation";
            this.button_SaveWordInfo.UseVisualStyleBackColor = true;
            this.button_SaveWordInfo.Click += new System.EventHandler(this.button_SaveWordInfo_Click);
            // 
            // defegslist
            // 
            this.defegslist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.defegslist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.defegslist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Save,
            this.Word,
            this.Definition,
            this.Example});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.defegslist.DefaultCellStyle = dataGridViewCellStyle5;
            this.defegslist.Location = new System.Drawing.Point(10, 47);
            this.defegslist.Name = "defegslist";
            this.defegslist.Size = new System.Drawing.Size(1283, 552);
            this.defegslist.TabIndex = 2;
            // 
            // Save
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Save.DefaultCellStyle = dataGridViewCellStyle1;
            this.Save.HeaderText = "Y=Save";
            this.Save.MaxInputLength = 1;
            this.Save.Name = "Save";
            this.Save.Width = 60;
            // 
            // Word
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Word.DefaultCellStyle = dataGridViewCellStyle2;
            this.Word.FillWeight = 150F;
            this.Word.HeaderText = "Word";
            this.Word.Name = "Word";
            this.Word.Width = 150;
            // 
            // Definition
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Definition.DefaultCellStyle = dataGridViewCellStyle3;
            this.Definition.HeaderText = "Definition";
            this.Definition.Name = "Definition";
            this.Definition.Width = 500;
            // 
            // Example
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Example.DefaultCellStyle = dataGridViewCellStyle4;
            this.Example.HeaderText = "Example";
            this.Example.Name = "Example";
            this.Example.Width = 500;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1305, 611);
            this.Controls.Add(this.defegslist);
            this.Controls.Add(this.button_SaveWordInfo);
            this.Controls.Add(this.button_Exit);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.defegslist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_SaveWordInfo;
        private System.Windows.Forms.DataGridView defegslist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn Definition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Example;
    }
}

