namespace Kommisionierung
{
    partial class Consignment_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.docnummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linenum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Soll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Beshreibung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelivDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docentry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMinus = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbPackageNumber = new System.Windows.Forms.Label();
            this.tbPackageNumber = new System.Windows.Forms.TextBox();
            this.btnMainButton = new System.Windows.Forms.Button();
            this.btnFirstRecord = new System.Windows.Forms.Button();
            this.btnLastRecord = new System.Windows.Forms.Button();
            this.btnNextRecord = new System.Windows.Forms.Button();
            this.btnPrevRecord = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cobStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblpostdate = new System.Windows.Forms.Label();
            this.tbScannedCode2 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docnummer,
            this.Linenum,
            this.colItemCode,
            this.SerialNumber,
            this.Ist,
            this.Soll,
            this.Beshreibung,
            this.DelivDate,
            this.docentry,
            this.rn});
            this.dataGridView.Location = new System.Drawing.Point(16, 121);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1214, 540);
            this.dataGridView.TabIndex = 0;
            // 
            // docnummer
            // 
            this.docnummer.HeaderText = "Packnummer";
            this.docnummer.Name = "docnummer";
            this.docnummer.Visible = false;
            // 
            // Linenum
            // 
            this.Linenum.HeaderText = "Linenum";
            this.Linenum.Name = "Linenum";
            // 
            // colItemCode
            // 
            this.colItemCode.HeaderText = "Artikelnummer";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            this.colItemCode.Width = 150;
            // 
            // SerialNumber
            // 
            this.SerialNumber.HeaderText = "Seriennummer";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.Width = 150;
            // 
            // Ist
            // 
            this.Ist.HeaderText = "Ist";
            this.Ist.Name = "Ist";
            this.Ist.ReadOnly = true;
            this.Ist.Width = 60;
            // 
            // Soll
            // 
            this.Soll.HeaderText = "Soll";
            this.Soll.Name = "Soll";
            this.Soll.Width = 60;
            // 
            // Beshreibung
            // 
            this.Beshreibung.HeaderText = "Beschreibung";
            this.Beshreibung.Name = "Beshreibung";
            this.Beshreibung.ReadOnly = true;
            this.Beshreibung.Width = 400;
            // 
            // DelivDate
            // 
            this.DelivDate.HeaderText = "Lieferdatum";
            this.DelivDate.Name = "DelivDate";
            this.DelivDate.Width = 150;
            // 
            // docentry
            // 
            this.docentry.HeaderText = "docentry";
            this.docentry.Name = "docentry";
            this.docentry.Visible = false;
            // 
            // rn
            // 
            this.rn.HeaderText = "rn";
            this.rn.Name = "rn";
            this.rn.Visible = false;
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.Location = new System.Drawing.Point(963, 686);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(71, 53);
            this.btnMinus.TabIndex = 4;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(13, 80);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(65, 24);
            this.lbStatus.TabIndex = 6;
            this.lbStatus.Text = "Status:";
            // 
            // lbPackageNumber
            // 
            this.lbPackageNumber.AutoSize = true;
            this.lbPackageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPackageNumber.Location = new System.Drawing.Point(767, 24);
            this.lbPackageNumber.Name = "lbPackageNumber";
            this.lbPackageNumber.Size = new System.Drawing.Size(127, 24);
            this.lbPackageNumber.TabIndex = 8;
            this.lbPackageNumber.Text = "Packnummer:";
            this.lbPackageNumber.Click += new System.EventHandler(this.lbPackageNumber_Click);
            // 
            // tbPackageNumber
            // 
            this.tbPackageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPackageNumber.Location = new System.Drawing.Point(900, 24);
            this.tbPackageNumber.Name = "tbPackageNumber";
            this.tbPackageNumber.Size = new System.Drawing.Size(188, 29);
            this.tbPackageNumber.TabIndex = 7;
            this.tbPackageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPackageNumber.TextChanged += new System.EventHandler(this.tbPackageNumber_TextChanged);
            this.tbPackageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPackageNumber_KeyPress);
            // 
            // btnMainButton
            // 
            this.btnMainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainButton.Location = new System.Drawing.Point(16, 732);
            this.btnMainButton.Name = "btnMainButton";
            this.btnMainButton.Size = new System.Drawing.Size(217, 41);
            this.btnMainButton.TabIndex = 9;
            this.btnMainButton.Text = "Packliste aktualisieren";
            this.btnMainButton.UseVisualStyleBackColor = true;
            this.btnMainButton.Click += new System.EventHandler(this.btnMainButton_Click);
            // 
            // btnFirstRecord
            // 
            this.btnFirstRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirstRecord.Location = new System.Drawing.Point(17, 12);
            this.btnFirstRecord.Name = "btnFirstRecord";
            this.btnFirstRecord.Size = new System.Drawing.Size(92, 41);
            this.btnFirstRecord.TabIndex = 13;
            this.btnFirstRecord.Text = "|<<";
            this.btnFirstRecord.UseVisualStyleBackColor = true;
            this.btnFirstRecord.Click += new System.EventHandler(this.btnFirstRecord_Click);
            // 
            // btnLastRecord
            // 
            this.btnLastRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastRecord.Location = new System.Drawing.Point(311, 12);
            this.btnLastRecord.Name = "btnLastRecord";
            this.btnLastRecord.Size = new System.Drawing.Size(92, 41);
            this.btnLastRecord.TabIndex = 14;
            this.btnLastRecord.Text = ">>|";
            this.btnLastRecord.UseVisualStyleBackColor = true;
            this.btnLastRecord.Click += new System.EventHandler(this.btnLastRecord_Click);
            // 
            // btnNextRecord
            // 
            this.btnNextRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextRecord.Location = new System.Drawing.Point(213, 12);
            this.btnNextRecord.Name = "btnNextRecord";
            this.btnNextRecord.Size = new System.Drawing.Size(92, 41);
            this.btnNextRecord.TabIndex = 15;
            this.btnNextRecord.Text = ">";
            this.btnNextRecord.UseVisualStyleBackColor = true;
            this.btnNextRecord.Click += new System.EventHandler(this.btnNextRecord_Click);
            // 
            // btnPrevRecord
            // 
            this.btnPrevRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevRecord.Location = new System.Drawing.Point(115, 12);
            this.btnPrevRecord.Name = "btnPrevRecord";
            this.btnPrevRecord.Size = new System.Drawing.Size(92, 41);
            this.btnPrevRecord.TabIndex = 16;
            this.btnPrevRecord.Text = "<";
            this.btnPrevRecord.UseVisualStyleBackColor = true;
            this.btnPrevRecord.Click += new System.EventHandler(this.btnPrevRecord_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.Location = new System.Drawing.Point(879, 686);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(78, 53);
            this.btnPlus.TabIndex = 17;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1115, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 49);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Suche";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cobStatus
            // 
            this.cobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobStatus.Enabled = false;
            this.cobStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cobStatus.FormattingEnabled = true;
            this.cobStatus.Items.AddRange(new object[] {
            "Offen",
            "In Bearbeitung",
            "Geschlossen"});
            this.cobStatus.Location = new System.Drawing.Point(84, 77);
            this.cobStatus.Name = "cobStatus";
            this.cobStatus.Size = new System.Drawing.Size(221, 32);
            this.cobStatus.TabIndex = 19;
            this.cobStatus.SelectedIndexChanged += new System.EventHandler(this.cobStatus_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(767, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Buchungsdatum:";
            // 
            // lblpostdate
            // 
            this.lblpostdate.AutoSize = true;
            this.lblpostdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpostdate.Location = new System.Drawing.Point(926, 77);
            this.lblpostdate.Name = "lblpostdate";
            this.lblpostdate.Size = new System.Drawing.Size(0, 24);
            this.lblpostdate.TabIndex = 21;
            // 
            // tbScannedCode2
            // 
            this.tbScannedCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.tbScannedCode2.Location = new System.Drawing.Point(16, 686);
            this.tbScannedCode2.Name = "tbScannedCode2";
            this.tbScannedCode2.Size = new System.Drawing.Size(857, 29);
            this.tbScannedCode2.TabIndex = 2;
            this.tbScannedCode2.AcceptsTabChanged += new System.EventHandler(this.tbScannedCode2_AcceptsTabChanged);
            this.tbScannedCode2.ModifiedChanged += new System.EventHandler(this.tbScannedCode2_ModifiedChanged);
            this.tbScannedCode2.BindingContextChanged += new System.EventHandler(this.tbScannedCode2_BindingContextChanged);
            this.tbScannedCode2.CausesValidationChanged += new System.EventHandler(this.tbScannedCode2_CausesValidationChanged);
            this.tbScannedCode2.CursorChanged += new System.EventHandler(this.tbScannedCode2_CursorChanged);
            this.tbScannedCode2.TextChanged += new System.EventHandler(this.tbScannedCode2_TextChanged);
            this.tbScannedCode2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbScannedCode2_KeyPress);
            this.tbScannedCode2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbScannedCode2_KeyUp);
            this.tbScannedCode2.Leave += new System.EventHandler(this.tbScannedCode2_Leave);
            this.tbScannedCode2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbScannedCode2_PreviewKeyDown);
            this.tbScannedCode2.Validating += new System.ComponentModel.CancelEventHandler(this.tbScannedCode2_Validating);
            this.tbScannedCode2.Validated += new System.EventHandler(this.tbScannedCode2_Validated);
            this.tbScannedCode2.ParentChanged += new System.EventHandler(this.tbScannedCode2_ParentChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Consignment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 826);
            this.Controls.Add(this.tbScannedCode2);
            this.Controls.Add(this.lblpostdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cobStatus);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnPrevRecord);
            this.Controls.Add(this.btnNextRecord);
            this.Controls.Add(this.btnLastRecord);
            this.Controls.Add(this.btnFirstRecord);
            this.Controls.Add(this.btnMainButton);
            this.Controls.Add(this.lbPackageNumber);
            this.Controls.Add(this.tbPackageNumber);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.dataGridView);
            this.KeyPreview = true;
            this.Name = "Consignment_Form";
            this.Text = "Scann-Kommissionierung und Packliste";
            this.Activated += new System.EventHandler(this.Consignment_Form_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Consignment_Form_FormClosed);
            this.Load += new System.EventHandler(this.Consignment_Form_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Consignment_Form_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbPackageNumber;
        private System.Windows.Forms.Button btnMainButton;
        private System.Windows.Forms.Button btnFirstRecord;
        private System.Windows.Forms.Button btnLastRecord;
        private System.Windows.Forms.Button btnNextRecord;
        private System.Windows.Forms.Button btnPrevRecord;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.ComboBox cobStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblpostdate;
        private System.Windows.Forms.TextBox tbScannedCode2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn docnummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linenum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beshreibung;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelivDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn docentry;
        private System.Windows.Forms.DataGridViewTextBoxColumn rn;
        public System.Windows.Forms.TextBox tbPackageNumber;
        public System.Windows.Forms.Button btnSearch;
    }
}

