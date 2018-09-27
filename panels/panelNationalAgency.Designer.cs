namespace erasmDB.panels
{
    partial class panelNationalAgency
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridData = new erasmDB.ExtendedDataGridView();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.ibuttonEdit = new erasmDB.IconButton();
            this.ibuttonRemove = new erasmDB.IconButton();
            this.ibuttonAdd = new erasmDB.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.FilterColumns = new string[0];
            this.gridData.Location = new System.Drawing.Point(0, 3);
            this.gridData.Name = "gridData";
            this.gridData.Size = new System.Drawing.Size(716, 594);
            this.gridData.TabIndex = 29;
            this.gridData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_CellDoubleClick);
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMenu.Controls.Add(this.ibuttonEdit);
            this.panelMenu.Controls.Add(this.ibuttonRemove);
            this.panelMenu.Controls.Add(this.ibuttonAdd);
            this.panelMenu.Location = new System.Drawing.Point(519, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(149, 35);
            this.panelMenu.TabIndex = 30;
            // 
            // ibuttonEdit
            // 
            this.ibuttonEdit.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonEdit.AllowAutoSize = false;
            this.ibuttonEdit.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonEdit.Caption = "";
            this.ibuttonEdit.IconTypeInt = 61504;
            this.ibuttonEdit.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonEdit.Location = new System.Drawing.Point(99, 4);
            this.ibuttonEdit.Name = "ibuttonEdit";
            this.ibuttonEdit.ReadOnly = true;
            this.ibuttonEdit.Size = new System.Drawing.Size(42, 28);
            this.ibuttonEdit.TabIndex = 105;
            this.ibuttonEdit.TabStop = false;
            this.ibuttonEdit.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonEdit.TextFontSize = 12;
            this.ibuttonEdit.ToolTipText = null;
            this.ibuttonEdit.Click += new System.EventHandler(this.ibuttonEdit_Click);
            // 
            // ibuttonRemove
            // 
            this.ibuttonRemove.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonRemove.AllowAutoSize = false;
            this.ibuttonRemove.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonRemove.Caption = "";
            this.ibuttonRemove.IconTypeInt = 61544;
            this.ibuttonRemove.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonRemove.Location = new System.Drawing.Point(51, 4);
            this.ibuttonRemove.Name = "ibuttonRemove";
            this.ibuttonRemove.ReadOnly = true;
            this.ibuttonRemove.Size = new System.Drawing.Size(42, 28);
            this.ibuttonRemove.TabIndex = 103;
            this.ibuttonRemove.TabStop = false;
            this.ibuttonRemove.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonRemove.TextFontSize = 12;
            this.ibuttonRemove.ToolTipText = null;
            this.ibuttonRemove.Click += new System.EventHandler(this.ibuttonRemove_Click);
            // 
            // ibuttonAdd
            // 
            this.ibuttonAdd.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonAdd.AllowAutoSize = false;
            this.ibuttonAdd.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonAdd.Caption = "";
            this.ibuttonAdd.IconTypeInt = 61543;
            this.ibuttonAdd.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonAdd.Location = new System.Drawing.Point(3, 4);
            this.ibuttonAdd.Name = "ibuttonAdd";
            this.ibuttonAdd.ReadOnly = true;
            this.ibuttonAdd.Size = new System.Drawing.Size(42, 28);
            this.ibuttonAdd.TabIndex = 102;
            this.ibuttonAdd.TabStop = false;
            this.ibuttonAdd.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonAdd.TextFontSize = 12;
            this.ibuttonAdd.ToolTipText = null;
            this.ibuttonAdd.Click += new System.EventHandler(this.ibuttonAdd_Click);
            // 
            // panelNationalAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.gridData);
            this.Name = "panelNationalAgency";
            this.Size = new System.Drawing.Size(719, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedDataGridView gridData;
        private System.Windows.Forms.Panel panelMenu;
        private IconButton ibuttonAdd;
        private IconButton ibuttonRemove;
        private IconButton ibuttonEdit;
    }
}
