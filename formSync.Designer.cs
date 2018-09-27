namespace erasmDB
{
    partial class formSync
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
            this.labelStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ibuttonNew2Access = new erasmDB.IconButton();
            this.ibuttonWriteChanges = new erasmDB.IconButton();
            this.gridChanges = new erasmDB.ExtendedDataGridView();
            this.ibuttonNew2SQL = new erasmDB.IconButton();
            this.ibuttonCleanData = new erasmDB.IconButton();
            this.ibuttonRefresh = new erasmDB.IconButton();
            this.ibuttonClose = new erasmDB.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonNew2Access)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonWriteChanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonNew2SQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonCleanData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(14, 768);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(663, 24);
            this.labelStatus.TabIndex = 92;
            this.labelStatus.Text = ".";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 745);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1468, 23);
            this.progressBar1.TabIndex = 96;
            // 
            // ibuttonNew2Access
            // 
            this.ibuttonNew2Access.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonNew2Access.AllowAutoSize = false;
            this.ibuttonNew2Access.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonNew2Access.Caption = "2. new data to local";
            this.ibuttonNew2Access.CustomMargin = 5;
            this.ibuttonNew2Access.IconTypeInt = 61699;
            this.ibuttonNew2Access.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonNew2Access.Location = new System.Drawing.Point(404, 4);
            this.ibuttonNew2Access.Name = "ibuttonNew2Access";
            this.ibuttonNew2Access.ReadOnly = true;
            this.ibuttonNew2Access.Size = new System.Drawing.Size(210, 215);
            this.ibuttonNew2Access.TabIndex = 100;
            this.ibuttonNew2Access.TabStop = false;
            this.ibuttonNew2Access.Tag = "2. new data to local";
            this.ibuttonNew2Access.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonNew2Access.TextFontSize = 12;
            this.ibuttonNew2Access.ToolTipText = null;
            this.ibuttonNew2Access.Click += new System.EventHandler(this.ibuttonNew2Access_Click);
            // 
            // ibuttonWriteChanges
            // 
            this.ibuttonWriteChanges.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonWriteChanges.AllowAutoSize = false;
            this.ibuttonWriteChanges.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonWriteChanges.Caption = "3. write changes";
            this.ibuttonWriteChanges.CustomMargin = 5;
            this.ibuttonWriteChanges.IconTypeInt = 61545;
            this.ibuttonWriteChanges.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonWriteChanges.Location = new System.Drawing.Point(651, 4);
            this.ibuttonWriteChanges.Name = "ibuttonWriteChanges";
            this.ibuttonWriteChanges.ReadOnly = true;
            this.ibuttonWriteChanges.Size = new System.Drawing.Size(210, 215);
            this.ibuttonWriteChanges.TabIndex = 99;
            this.ibuttonWriteChanges.TabStop = false;
            this.ibuttonWriteChanges.Tag = "3. write changes";
            this.ibuttonWriteChanges.TextFont = new System.Drawing.Font("Segoe UI", 10F);
            this.ibuttonWriteChanges.TextFontSize = 10;
            this.ibuttonWriteChanges.ToolTipText = null;
            this.ibuttonWriteChanges.Click += new System.EventHandler(this.ibuttonWriteChanges_Click);
            // 
            // gridChanges
            // 
            this.gridChanges.AllowUserToAddRows = false;
            this.gridChanges.AllowUserToDeleteRows = false;
            this.gridChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridChanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChanges.FilterColumns = new string[0];
            this.gridChanges.Location = new System.Drawing.Point(1, 225);
            this.gridChanges.Name = "gridChanges";
            this.gridChanges.Size = new System.Drawing.Size(1488, 514);
            this.gridChanges.TabIndex = 98;
            this.gridChanges.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridChanges_CellDoubleClick);
            // 
            // ibuttonNew2SQL
            // 
            this.ibuttonNew2SQL.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonNew2SQL.AllowAutoSize = false;
            this.ibuttonNew2SQL.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonNew2SQL.Caption = "1. new data to server";
            this.ibuttonNew2SQL.CustomMargin = 5;
            this.ibuttonNew2SQL.IconTypeInt = 61698;
            this.ibuttonNew2SQL.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonNew2SQL.Location = new System.Drawing.Point(188, 4);
            this.ibuttonNew2SQL.Name = "ibuttonNew2SQL";
            this.ibuttonNew2SQL.ReadOnly = true;
            this.ibuttonNew2SQL.Size = new System.Drawing.Size(210, 215);
            this.ibuttonNew2SQL.TabIndex = 97;
            this.ibuttonNew2SQL.TabStop = false;
            this.ibuttonNew2SQL.Tag = "1. new data to server";
            this.ibuttonNew2SQL.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonNew2SQL.TextFontSize = 12;
            this.ibuttonNew2SQL.ToolTipText = null;
            this.ibuttonNew2SQL.Click += new System.EventHandler(this.ibuttonNew2SQL_Click);
            // 
            // ibuttonCleanData
            // 
            this.ibuttonCleanData.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonCleanData.AllowAutoSize = false;
            this.ibuttonCleanData.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonCleanData.Caption = "create fresh local copy";
            this.ibuttonCleanData.CustomMargin = 5;
            this.ibuttonCleanData.IconTypeInt = 61617;
            this.ibuttonCleanData.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonCleanData.Location = new System.Drawing.Point(1042, 4);
            this.ibuttonCleanData.Name = "ibuttonCleanData";
            this.ibuttonCleanData.ReadOnly = true;
            this.ibuttonCleanData.Size = new System.Drawing.Size(210, 215);
            this.ibuttonCleanData.TabIndex = 94;
            this.ibuttonCleanData.TabStop = false;
            this.ibuttonCleanData.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonCleanData.TextFontSize = 12;
            this.ibuttonCleanData.ToolTipText = null;
            this.ibuttonCleanData.Click += new System.EventHandler(this.ibuttonCleanData_Click);
            // 
            // ibuttonRefresh
            // 
            this.ibuttonRefresh.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonRefresh.AllowAutoSize = false;
            this.ibuttonRefresh.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonRefresh.Caption = "check for changes";
            this.ibuttonRefresh.CustomMargin = 5;
            this.ibuttonRefresh.IconTypeInt = 61473;
            this.ibuttonRefresh.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonRefresh.Location = new System.Drawing.Point(5, 4);
            this.ibuttonRefresh.Name = "ibuttonRefresh";
            this.ibuttonRefresh.ReadOnly = true;
            this.ibuttonRefresh.Size = new System.Drawing.Size(177, 215);
            this.ibuttonRefresh.TabIndex = 93;
            this.ibuttonRefresh.TabStop = false;
            this.ibuttonRefresh.TextFont = new System.Drawing.Font("Segoe UI", 10F);
            this.ibuttonRefresh.TextFontSize = 10;
            this.ibuttonRefresh.ToolTipText = null;
            this.ibuttonRefresh.Click += new System.EventHandler(this.ibuttonRefresh_Click);
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
            this.ibuttonClose.Location = new System.Drawing.Point(1407, 12);
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
            // formSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 799);
            this.Controls.Add(this.ibuttonNew2Access);
            this.Controls.Add(this.ibuttonWriteChanges);
            this.Controls.Add(this.gridChanges);
            this.Controls.Add(this.ibuttonNew2SQL);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ibuttonCleanData);
            this.Controls.Add(this.ibuttonRefresh);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.ibuttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSync";
            this.Text = "Sync";
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonNew2Access)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonWriteChanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonNew2SQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonCleanData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private IconButton ibuttonClose;
        private System.Windows.Forms.Label labelStatus;
        private IconButton ibuttonRefresh;
        private IconButton ibuttonCleanData;
        private System.Windows.Forms.ProgressBar progressBar1;
        private IconButton ibuttonNew2SQL;
        private ExtendedDataGridView gridChanges;
        private IconButton ibuttonWriteChanges;
        private IconButton ibuttonNew2Access;
    }
}