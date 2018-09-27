namespace erasmDB
{
    partial class formWordTemplateEdit
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
            this.listVariables = new System.Windows.Forms.ListBox();
            this.listWordVars = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelInsert = new System.Windows.Forms.Panel();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.ibuttonNext = new erasmDB.IconButton();
            this.ibuttonPrev = new erasmDB.IconButton();
            this.ibuttonReplace = new erasmDB.IconButton();
            this.ibuttonInsert = new erasmDB.IconButton();
            this.ibuttonExportSQL = new erasmDB.IconButton();
            this.ibuttonUpdateWordVars = new erasmDB.IconButton();
            this.ibuttonExportExcel = new erasmDB.IconButton();
            this.ibuttonUpdateFields = new erasmDB.IconButton();
            this.iconSelectMandate = new erasmDB.IconButton();
            this.ibuttonClose = new erasmDB.IconButton();
            this.panelInsert.SuspendLayout();
            this.panelUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonReplace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonExportSQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonUpdateWordVars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonUpdateFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSelectMandate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 40);
            this.label1.TabIndex = 83;
            this.label1.Text = "Document Template";
            // 
            // textTemplate
            // 
            this.textTemplate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTemplate.Location = new System.Drawing.Point(146, 13);
            this.textTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.textTemplate.Name = "textTemplate";
            this.textTemplate.Size = new System.Drawing.Size(801, 33);
            this.textTemplate.TabIndex = 89;
            // 
            // buttonSelectTemplate
            // 
            this.buttonSelectTemplate.Location = new System.Drawing.Point(947, 13);
            this.buttonSelectTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelectTemplate.Name = "buttonSelectTemplate";
            this.buttonSelectTemplate.Size = new System.Drawing.Size(37, 33);
            this.buttonSelectTemplate.TabIndex = 90;
            this.buttonSelectTemplate.Text = "...";
            this.buttonSelectTemplate.UseVisualStyleBackColor = true;
            this.buttonSelectTemplate.Click += new System.EventHandler(this.buttonSelectTemplate_Click);
            // 
            // listVariables
            // 
            this.listVariables.Font = new System.Drawing.Font("Consolas", 11F);
            this.listVariables.FormattingEnabled = true;
            this.listVariables.ItemHeight = 18;
            this.listVariables.Location = new System.Drawing.Point(22, 97);
            this.listVariables.Margin = new System.Windows.Forms.Padding(0);
            this.listVariables.Name = "listVariables";
            this.listVariables.Size = new System.Drawing.Size(789, 382);
            this.listVariables.TabIndex = 93;
            this.listVariables.SelectedIndexChanged += new System.EventHandler(this.listVariables_SelectedIndexChanged);
            this.listVariables.DoubleClick += new System.EventHandler(this.listVariables_DoubleClick);
            // 
            // listWordVars
            // 
            this.listWordVars.Font = new System.Drawing.Font("Consolas", 10F);
            this.listWordVars.FormattingEnabled = true;
            this.listWordVars.ItemHeight = 15;
            this.listWordVars.Location = new System.Drawing.Point(22, 495);
            this.listWordVars.Margin = new System.Windows.Forms.Padding(0);
            this.listWordVars.Name = "listWordVars";
            this.listWordVars.Size = new System.Drawing.Size(789, 409);
            this.listWordVars.TabIndex = 165;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 55);
            this.label2.TabIndex = 169;
            this.label2.Text = "update word document from old variables and header to new structure";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(4, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 63);
            this.label3.TabIndex = 170;
            this.label3.Text = "insert selected field to word document (mail merge field can be encapsulated in w" +
    "ord field)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelInsert
            // 
            this.panelInsert.Controls.Add(this.label3);
            this.panelInsert.Controls.Add(this.ibuttonInsert);
            this.panelInsert.Location = new System.Drawing.Point(816, 97);
            this.panelInsert.Name = "panelInsert";
            this.panelInsert.Size = new System.Drawing.Size(174, 141);
            this.panelInsert.TabIndex = 171;
            // 
            // panelUpdate
            // 
            this.panelUpdate.Controls.Add(this.ibuttonReplace);
            this.panelUpdate.Controls.Add(this.label2);
            this.panelUpdate.Location = new System.Drawing.Point(814, 244);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(174, 105);
            this.panelUpdate.TabIndex = 172;
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(7, 54);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(712, 33);
            this.labelStatus.TabIndex = 173;
            this.labelStatus.Text = "Document Template";
            // 
            // ibuttonNext
            // 
            this.ibuttonNext.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonNext.AllowAutoSize = false;
            this.ibuttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonNext.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonNext.Caption = "";
            this.ibuttonNext.CustomMargin = 2;
            this.ibuttonNext.IconTypeInt = 61518;
            this.ibuttonNext.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonNext.Location = new System.Drawing.Point(778, 74);
            this.ibuttonNext.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonNext.Name = "ibuttonNext";
            this.ibuttonNext.ReadOnly = true;
            this.ibuttonNext.Size = new System.Drawing.Size(33, 23);
            this.ibuttonNext.TabIndex = 175;
            this.ibuttonNext.TabStop = false;
            this.ibuttonNext.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonNext.TextFontSize = 12;
            this.ibuttonNext.ToolTipText = null;
            this.ibuttonNext.Visible = false;
            this.ibuttonNext.Click += new System.EventHandler(this.ibuttonNext_Click);
            // 
            // ibuttonPrev
            // 
            this.ibuttonPrev.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonPrev.AllowAutoSize = false;
            this.ibuttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonPrev.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonPrev.Caption = "";
            this.ibuttonPrev.CustomMargin = 2;
            this.ibuttonPrev.IconTypeInt = 61514;
            this.ibuttonPrev.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonPrev.Location = new System.Drawing.Point(745, 74);
            this.ibuttonPrev.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonPrev.Name = "ibuttonPrev";
            this.ibuttonPrev.ReadOnly = true;
            this.ibuttonPrev.Size = new System.Drawing.Size(33, 23);
            this.ibuttonPrev.TabIndex = 174;
            this.ibuttonPrev.TabStop = false;
            this.ibuttonPrev.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonPrev.TextFontSize = 12;
            this.ibuttonPrev.ToolTipText = null;
            this.ibuttonPrev.Visible = false;
            this.ibuttonPrev.Click += new System.EventHandler(this.ibuttonPrev_Click);
            // 
            // ibuttonReplace
            // 
            this.ibuttonReplace.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonReplace.AllowAutoSize = false;
            this.ibuttonReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonReplace.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonReplace.Caption = "update doc";
            this.ibuttonReplace.CustomMargin = 5;
            this.ibuttonReplace.IconTypeInt = 61637;
            this.ibuttonReplace.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonReplace.Location = new System.Drawing.Point(2, 0);
            this.ibuttonReplace.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonReplace.Name = "ibuttonReplace";
            this.ibuttonReplace.ReadOnly = true;
            this.ibuttonReplace.Size = new System.Drawing.Size(169, 49);
            this.ibuttonReplace.TabIndex = 167;
            this.ibuttonReplace.TabStop = false;
            this.ibuttonReplace.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonReplace.TextFontSize = 12;
            this.ibuttonReplace.ToolTipText = null;
            this.ibuttonReplace.Click += new System.EventHandler(this.ibuttonReplace_Click);
            // 
            // ibuttonInsert
            // 
            this.ibuttonInsert.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonInsert.AllowAutoSize = false;
            this.ibuttonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonInsert.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonInsert.Caption = "insert field";
            this.ibuttonInsert.CustomMargin = 5;
            this.ibuttonInsert.IconTypeInt = 61697;
            this.ibuttonInsert.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonInsert.Location = new System.Drawing.Point(0, 0);
            this.ibuttonInsert.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonInsert.Name = "ibuttonInsert";
            this.ibuttonInsert.ReadOnly = true;
            this.ibuttonInsert.Size = new System.Drawing.Size(173, 59);
            this.ibuttonInsert.TabIndex = 95;
            this.ibuttonInsert.TabStop = false;
            this.ibuttonInsert.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonInsert.TextFontSize = 12;
            this.ibuttonInsert.ToolTipText = null;
            this.ibuttonInsert.Visible = false;
            this.ibuttonInsert.Click += new System.EventHandler(this.ibuttonInsert_Click);
            // 
            // ibuttonExportSQL
            // 
            this.ibuttonExportSQL.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonExportSQL.AllowAutoSize = false;
            this.ibuttonExportSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonExportSQL.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonExportSQL.Caption = "export SQL";
            this.ibuttonExportSQL.CustomMargin = 5;
            this.ibuttonExportSQL.IconTypeInt = 62830;
            this.ibuttonExportSQL.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonExportSQL.Location = new System.Drawing.Point(824, 701);
            this.ibuttonExportSQL.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonExportSQL.Name = "ibuttonExportSQL";
            this.ibuttonExportSQL.ReadOnly = true;
            this.ibuttonExportSQL.Size = new System.Drawing.Size(66, 37);
            this.ibuttonExportSQL.TabIndex = 168;
            this.ibuttonExportSQL.TabStop = false;
            this.ibuttonExportSQL.TextFont = null;
            this.ibuttonExportSQL.TextFontSize = 12;
            this.ibuttonExportSQL.ToolTipText = null;
            this.ibuttonExportSQL.Visible = false;
            this.ibuttonExportSQL.Click += new System.EventHandler(this.ibuttonExportSQL_Click);
            // 
            // ibuttonUpdateWordVars
            // 
            this.ibuttonUpdateWordVars.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonUpdateWordVars.AllowAutoSize = false;
            this.ibuttonUpdateWordVars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonUpdateWordVars.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonUpdateWordVars.Caption = "";
            this.ibuttonUpdateWordVars.CustomMargin = 2;
            this.ibuttonUpdateWordVars.IconTypeInt = 61473;
            this.ibuttonUpdateWordVars.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonUpdateWordVars.Location = new System.Drawing.Point(811, 495);
            this.ibuttonUpdateWordVars.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonUpdateWordVars.Name = "ibuttonUpdateWordVars";
            this.ibuttonUpdateWordVars.ReadOnly = true;
            this.ibuttonUpdateWordVars.Size = new System.Drawing.Size(33, 35);
            this.ibuttonUpdateWordVars.TabIndex = 166;
            this.ibuttonUpdateWordVars.TabStop = false;
            this.ibuttonUpdateWordVars.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonUpdateWordVars.TextFontSize = 12;
            this.ibuttonUpdateWordVars.ToolTipText = null;
            this.ibuttonUpdateWordVars.Visible = false;
            this.ibuttonUpdateWordVars.Click += new System.EventHandler(this.ibuttonUpdateWordVars_Click);
            // 
            // ibuttonExportExcel
            // 
            this.ibuttonExportExcel.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonExportExcel.AllowAutoSize = false;
            this.ibuttonExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonExportExcel.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonExportExcel.Caption = "export excel";
            this.ibuttonExportExcel.CustomMargin = 5;
            this.ibuttonExportExcel.IconTypeInt = 62830;
            this.ibuttonExportExcel.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonExportExcel.Location = new System.Drawing.Point(897, 748);
            this.ibuttonExportExcel.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonExportExcel.Name = "ibuttonExportExcel";
            this.ibuttonExportExcel.ReadOnly = true;
            this.ibuttonExportExcel.Size = new System.Drawing.Size(67, 32);
            this.ibuttonExportExcel.TabIndex = 164;
            this.ibuttonExportExcel.TabStop = false;
            this.ibuttonExportExcel.TextFont = null;
            this.ibuttonExportExcel.TextFontSize = 12;
            this.ibuttonExportExcel.ToolTipText = null;
            this.ibuttonExportExcel.Visible = false;
            this.ibuttonExportExcel.Click += new System.EventHandler(this.ibuttonExportExcel_Click);
            // 
            // ibuttonUpdateFields
            // 
            this.ibuttonUpdateFields.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonUpdateFields.AllowAutoSize = false;
            this.ibuttonUpdateFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonUpdateFields.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonUpdateFields.Caption = "update fields";
            this.ibuttonUpdateFields.CustomMargin = 2;
            this.ibuttonUpdateFields.IconTypeInt = 61473;
            this.ibuttonUpdateFields.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonUpdateFields.Location = new System.Drawing.Point(824, 396);
            this.ibuttonUpdateFields.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonUpdateFields.Name = "ibuttonUpdateFields";
            this.ibuttonUpdateFields.ReadOnly = true;
            this.ibuttonUpdateFields.Size = new System.Drawing.Size(66, 32);
            this.ibuttonUpdateFields.TabIndex = 163;
            this.ibuttonUpdateFields.TabStop = false;
            this.ibuttonUpdateFields.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonUpdateFields.TextFontSize = 12;
            this.ibuttonUpdateFields.ToolTipText = null;
            this.ibuttonUpdateFields.Visible = false;
            this.ibuttonUpdateFields.Click += new System.EventHandler(this.ibuttonUpdateFields_Click);
            // 
            // iconSelectMandate
            // 
            this.iconSelectMandate.ActiveColor = System.Drawing.Color.Black;
            this.iconSelectMandate.AllowAutoSize = false;
            this.iconSelectMandate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconSelectMandate.BackColor = System.Drawing.Color.Transparent;
            this.iconSelectMandate.Caption = "mandate";
            this.iconSelectMandate.CustomMargin = 5;
            this.iconSelectMandate.IconTypeInt = 61639;
            this.iconSelectMandate.InActiveColor = System.Drawing.Color.DimGray;
            this.iconSelectMandate.Location = new System.Drawing.Point(843, 587);
            this.iconSelectMandate.Margin = new System.Windows.Forms.Padding(0);
            this.iconSelectMandate.Name = "iconSelectMandate";
            this.iconSelectMandate.ReadOnly = true;
            this.iconSelectMandate.Size = new System.Drawing.Size(104, 30);
            this.iconSelectMandate.TabIndex = 94;
            this.iconSelectMandate.TabStop = false;
            this.iconSelectMandate.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.iconSelectMandate.TextFontSize = 12;
            this.iconSelectMandate.ToolTipText = null;
            this.iconSelectMandate.Visible = false;
            this.iconSelectMandate.Click += new System.EventHandler(this.iconSelectMandate_Click);
            // 
            // ibuttonClose
            // 
            this.ibuttonClose.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonClose.AllowAutoSize = false;
            this.ibuttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonClose.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonClose.Caption = "cancel";
            this.ibuttonClose.CustomMargin = 5;
            this.ibuttonClose.IconTypeInt = 61534;
            this.ibuttonClose.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonClose.Location = new System.Drawing.Point(897, 810);
            this.ibuttonClose.Name = "ibuttonClose";
            this.ibuttonClose.ReadOnly = true;
            this.ibuttonClose.Size = new System.Drawing.Size(82, 94);
            this.ibuttonClose.TabIndex = 18;
            this.ibuttonClose.TabStop = false;
            this.ibuttonClose.TextFont = null;
            this.ibuttonClose.TextFontSize = 12;
            this.ibuttonClose.ToolTipText = null;
            this.ibuttonClose.Click += new System.EventHandler(this.ibuttonClose_Click);
            // 
            // formWordTemplateEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 921);
            this.Controls.Add(this.ibuttonNext);
            this.Controls.Add(this.ibuttonPrev);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.panelUpdate);
            this.Controls.Add(this.panelInsert);
            this.Controls.Add(this.ibuttonExportSQL);
            this.Controls.Add(this.ibuttonUpdateWordVars);
            this.Controls.Add(this.listWordVars);
            this.Controls.Add(this.ibuttonExportExcel);
            this.Controls.Add(this.ibuttonUpdateFields);
            this.Controls.Add(this.iconSelectMandate);
            this.Controls.Add(this.listVariables);
            this.Controls.Add(this.buttonSelectTemplate);
            this.Controls.Add(this.textTemplate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ibuttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formWordTemplateEdit";
            this.Text = "Template editor";
            this.Load += new System.EventHandler(this.formWordTemplateEdit_Load);
            this.panelInsert.ResumeLayout(false);
            this.panelUpdate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonReplace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonExportSQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonUpdateWordVars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonUpdateFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSelectMandate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private IconButton ibuttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTemplate;
        private System.Windows.Forms.Button buttonSelectTemplate;
        private IconButton iconSelectMandate;
        private System.Windows.Forms.ListBox listVariables;
        private IconButton ibuttonUpdateFields;
        private IconButton ibuttonInsert;
        private IconButton ibuttonExportExcel;
        private System.Windows.Forms.ListBox listWordVars;
        private IconButton ibuttonUpdateWordVars;
        private IconButton ibuttonReplace;
        private IconButton ibuttonExportSQL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelInsert;
        private System.Windows.Forms.Panel panelUpdate;
        private System.Windows.Forms.Label labelStatus;
        private IconButton ibuttonPrev;
        private IconButton ibuttonNext;
    }
}