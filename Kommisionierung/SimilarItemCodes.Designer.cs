namespace Kommisionierung
{
    partial class SimilarItemCodes
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Linenummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artikelnummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Beshreibung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U_Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U_Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Packnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Linenummer,
            this.Artikelnummer,
            this.Beshreibung,
            this.U_Credit,
            this.U_Debit,
            this.Packnumber});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(708, 519);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Linenummer
            // 
            this.Linenummer.HeaderText = "Linenummer";
            this.Linenummer.Name = "Linenummer";
            // 
            // Artikelnummer
            // 
            this.Artikelnummer.HeaderText = "Artikelnummer";
            this.Artikelnummer.Name = "Artikelnummer";
            this.Artikelnummer.Width = 150;
            // 
            // Beshreibung
            // 
            this.Beshreibung.HeaderText = "Beshreibung";
            this.Beshreibung.Name = "Beshreibung";
            this.Beshreibung.Width = 400;
            // 
            // U_Credit
            // 
            this.U_Credit.HeaderText = "U_Credit";
            this.U_Credit.Name = "U_Credit";
            this.U_Credit.Visible = false;
            // 
            // U_Debit
            // 
            this.U_Debit.HeaderText = "U_Debit";
            this.U_Debit.Name = "U_Debit";
            this.U_Debit.Visible = false;
            // 
            // Packnumber
            // 
            this.Packnumber.HeaderText = "Packnumber";
            this.Packnumber.Name = "Packnumber";
            this.Packnumber.Visible = false;
            // 
            // SimilarItemCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 573);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SimilarItemCodes";
            this.Text = "SimilarItemCodes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SimilarItemCodes_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linenummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artikelnummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beshreibung;
        private System.Windows.Forms.DataGridViewTextBoxColumn U_Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn U_Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Packnumber;
    }
}