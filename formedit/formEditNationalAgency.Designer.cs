namespace erasmDB.formedit
{
    partial class formEditNationalAgency
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
            this.comboCountry = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textAgencyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textNACode = new System.Windows.Forms.TextBox();
            this.ibuttonClose = new erasmDB.IconButton();
            this.ibuttonSave = new erasmDB.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonSave)).BeginInit();
            this.SuspendLayout();
            // 
            // comboCountry
            // 
            this.comboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCountry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCountry.FormattingEnabled = true;
            this.comboCountry.Location = new System.Drawing.Point(132, 116);
            this.comboCountry.Name = "comboCountry";
            this.comboCountry.Size = new System.Drawing.Size(460, 29);
            this.comboCountry.TabIndex = 40;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(19, 120);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 20);
            this.label17.TabIndex = 41;
            this.label17.Text = "Country";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 27);
            this.label1.TabIndex = 83;
            this.label1.Text = "NACode";
            // 
            // textAgencyName
            // 
            this.textAgencyName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAgencyName.Location = new System.Drawing.Point(132, 63);
            this.textAgencyName.Name = "textAgencyName";
            this.textAgencyName.Size = new System.Drawing.Size(387, 33);
            this.textAgencyName.TabIndex = 88;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 87;
            this.label2.Text = "Agency Name";
            // 
            // textNACode
            // 
            this.textNACode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNACode.Location = new System.Drawing.Point(132, 13);
            this.textNACode.Name = "textNACode";
            this.textNACode.Size = new System.Drawing.Size(233, 33);
            this.textNACode.TabIndex = 89;
            this.textNACode.TextChanged += new System.EventHandler(this.textNACode_TextChanged);
            // 
            // ibuttonClose
            // 
            this.ibuttonClose.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonClose.AllowAutoSize = false;
            this.ibuttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonClose.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonClose.Caption = "cancel";
            this.ibuttonClose.IconTypeInt = 61534;
            this.ibuttonClose.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonClose.Location = new System.Drawing.Point(663, 71);
            this.ibuttonClose.Name = "ibuttonClose";
            this.ibuttonClose.ReadOnly = true;
            this.ibuttonClose.Size = new System.Drawing.Size(82, 94);
            this.ibuttonClose.TabIndex = 18;
            this.ibuttonClose.TabStop = false;
            this.ibuttonClose.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonClose.TextFontSize = 12;
            this.ibuttonClose.ToolTipText = null;
            this.ibuttonClose.Click += new System.EventHandler(this.ibuttonClose_Click);
            // 
            // ibuttonSave
            // 
            this.ibuttonSave.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonSave.AllowAutoSize = false;
            this.ibuttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonSave.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonSave.Caption = "save";
            this.ibuttonSave.IconTypeInt = 61639;
            this.ibuttonSave.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonSave.Location = new System.Drawing.Point(751, 71);
            this.ibuttonSave.Name = "ibuttonSave";
            this.ibuttonSave.ReadOnly = true;
            this.ibuttonSave.Size = new System.Drawing.Size(82, 94);
            this.ibuttonSave.TabIndex = 17;
            this.ibuttonSave.TabStop = false;
            this.ibuttonSave.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonSave.TextFontSize = 12;
            this.ibuttonSave.ToolTipText = null;
            this.ibuttonSave.Click += new System.EventHandler(this.ibuttonSave_Click);
            // 
            // formEditNationalAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 177);
            this.Controls.Add(this.textNACode);
            this.Controls.Add(this.textAgencyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboCountry);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ibuttonClose);
            this.Controls.Add(this.ibuttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formEditNationalAgency";
            this.Text = "National Agency";
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private IconButton ibuttonSave;
        private IconButton ibuttonClose;
        private System.Windows.Forms.ComboBox comboCountry;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAgencyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNACode;
    }
}