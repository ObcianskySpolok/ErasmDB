namespace erasmDB
{
    partial class formMandate
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
            this.label1 = new System.Windows.Forms.Label();
            this.textTemplate = new System.Windows.Forms.TextBox();
            this.buttonSelectTemplate = new System.Windows.Forms.Button();
            this.ibuttonClose = new erasmDB.IconButton();
            this.ibuttonSignSingle = new erasmDB.IconButton();
            this.ibuttonSignMultiple = new erasmDB.IconButton();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonSignSingle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonSignMultiple)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 40);
            this.label1.TabIndex = 83;
            this.label1.Text = "Mandate Template";
            // 
            // textTemplate
            // 
            this.textTemplate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTemplate.Location = new System.Drawing.Point(112, 13);
            this.textTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.textTemplate.Name = "textTemplate";
            this.textTemplate.Size = new System.Drawing.Size(501, 33);
            this.textTemplate.TabIndex = 89;
            // 
            // buttonSelectTemplate
            // 
            this.buttonSelectTemplate.Location = new System.Drawing.Point(613, 13);
            this.buttonSelectTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelectTemplate.Name = "buttonSelectTemplate";
            this.buttonSelectTemplate.Size = new System.Drawing.Size(37, 33);
            this.buttonSelectTemplate.TabIndex = 90;
            this.buttonSelectTemplate.Text = "...";
            this.buttonSelectTemplate.UseVisualStyleBackColor = true;
            this.buttonSelectTemplate.Click += new System.EventHandler(this.buttonSelectTemplate_Click);
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
            this.ibuttonClose.Location = new System.Drawing.Point(568, 74);
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
            // ibuttonSignSingle
            // 
            this.ibuttonSignSingle.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonSignSingle.AllowAutoSize = false;
            this.ibuttonSignSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonSignSingle.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonSignSingle.Caption = "sign single file";
            this.ibuttonSignSingle.IconTypeInt = 61771;
            this.ibuttonSignSingle.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonSignSingle.Location = new System.Drawing.Point(14, 75);
            this.ibuttonSignSingle.Name = "ibuttonSignSingle";
            this.ibuttonSignSingle.ReadOnly = true;
            this.ibuttonSignSingle.Size = new System.Drawing.Size(184, 68);
            this.ibuttonSignSingle.TabIndex = 17;
            this.ibuttonSignSingle.TabStop = false;
            this.ibuttonSignSingle.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonSignSingle.TextFontSize = 12;
            this.ibuttonSignSingle.ToolTipText = null;
            this.ibuttonSignSingle.Click += new System.EventHandler(this.ibuttonSignSingle_Click);
            // 
            // ibuttonSignMultiple
            // 
            this.ibuttonSignMultiple.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonSignMultiple.AllowAutoSize = false;
            this.ibuttonSignMultiple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonSignMultiple.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonSignMultiple.Caption = "sign separate files";
            this.ibuttonSignMultiple.IconTypeInt = 61508;
            this.ibuttonSignMultiple.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonSignMultiple.Location = new System.Drawing.Point(204, 74);
            this.ibuttonSignMultiple.Name = "ibuttonSignMultiple";
            this.ibuttonSignMultiple.ReadOnly = true;
            this.ibuttonSignMultiple.Size = new System.Drawing.Size(218, 68);
            this.ibuttonSignMultiple.TabIndex = 91;
            this.ibuttonSignMultiple.TabStop = false;
            this.ibuttonSignMultiple.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonSignMultiple.TextFontSize = 12;
            this.ibuttonSignMultiple.ToolTipText = null;
            this.ibuttonSignMultiple.Click += new System.EventHandler(this.ibuttonSignMultiple_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(10, 149);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(552, 24);
            this.labelStatus.TabIndex = 92;
            this.labelStatus.Text = "status";
            // 
            // formMandate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 179);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.ibuttonSignMultiple);
            this.Controls.Add(this.buttonSelectTemplate);
            this.Controls.Add(this.textTemplate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ibuttonClose);
            this.Controls.Add(this.ibuttonSignSingle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formMandate";
            this.Text = "Mandate";
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonSignSingle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonSignMultiple)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private IconButton ibuttonSignSingle;
        private IconButton ibuttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTemplate;
        private System.Windows.Forms.Button buttonSelectTemplate;
        private IconButton ibuttonSignMultiple;
        private System.Windows.Forms.Label labelStatus;
    }
}