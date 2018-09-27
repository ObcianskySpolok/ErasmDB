namespace erasmDB.panels
{
    partial class panelOrganization
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
            this.ibuttonImport = new erasmDB.IconButton();
            this.ibuttonOrganizationEdit = new erasmDB.IconButton();
            this.ibuttonOrganizationRemove = new erasmDB.IconButton();
            this.ibuttonOrganizationAdd = new erasmDB.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonOrganizationEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonOrganizationRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonOrganizationAdd)).BeginInit();
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
            this.panelMenu.Controls.Add(this.ibuttonImport);
            this.panelMenu.Controls.Add(this.ibuttonOrganizationEdit);
            this.panelMenu.Controls.Add(this.ibuttonOrganizationRemove);
            this.panelMenu.Controls.Add(this.ibuttonOrganizationAdd);
            this.panelMenu.Location = new System.Drawing.Point(523, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(193, 35);
            this.panelMenu.TabIndex = 31;
            // 
            // ibuttonImport
            // 
            this.ibuttonImport.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonImport.AllowAutoSize = false;
            this.ibuttonImport.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonImport.Caption = "";
            this.ibuttonImport.IconTypeInt = 61587;
            this.ibuttonImport.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonImport.Location = new System.Drawing.Point(147, 4);
            this.ibuttonImport.Name = "ibuttonImport";
            this.ibuttonImport.ReadOnly = true;
            this.ibuttonImport.Size = new System.Drawing.Size(42, 28);
            this.ibuttonImport.TabIndex = 106;
            this.ibuttonImport.TabStop = false;
            this.ibuttonImport.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonImport.TextFontSize = 12;
            this.ibuttonImport.ToolTipText = "Import";
            this.ibuttonImport.Click += new System.EventHandler(this.ibuttonImport_Click);
            // 
            // ibuttonOrganizationEdit
            // 
            this.ibuttonOrganizationEdit.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonOrganizationEdit.AllowAutoSize = false;
            this.ibuttonOrganizationEdit.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonOrganizationEdit.Caption = "";
            this.ibuttonOrganizationEdit.IconTypeInt = 61504;
            this.ibuttonOrganizationEdit.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonOrganizationEdit.Location = new System.Drawing.Point(99, 4);
            this.ibuttonOrganizationEdit.Name = "ibuttonOrganizationEdit";
            this.ibuttonOrganizationEdit.ReadOnly = true;
            this.ibuttonOrganizationEdit.Size = new System.Drawing.Size(42, 28);
            this.ibuttonOrganizationEdit.TabIndex = 105;
            this.ibuttonOrganizationEdit.TabStop = false;
            this.ibuttonOrganizationEdit.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonOrganizationEdit.TextFontSize = 12;
            this.ibuttonOrganizationEdit.ToolTipText = "Edit";
            this.ibuttonOrganizationEdit.Click += new System.EventHandler(this.ibuttonOrganizationEdit_Click);
            // 
            // ibuttonOrganizationRemove
            // 
            this.ibuttonOrganizationRemove.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonOrganizationRemove.AllowAutoSize = false;
            this.ibuttonOrganizationRemove.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonOrganizationRemove.Caption = "";
            this.ibuttonOrganizationRemove.IconTypeInt = 61544;
            this.ibuttonOrganizationRemove.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonOrganizationRemove.Location = new System.Drawing.Point(51, 4);
            this.ibuttonOrganizationRemove.Name = "ibuttonOrganizationRemove";
            this.ibuttonOrganizationRemove.ReadOnly = true;
            this.ibuttonOrganizationRemove.Size = new System.Drawing.Size(42, 28);
            this.ibuttonOrganizationRemove.TabIndex = 103;
            this.ibuttonOrganizationRemove.TabStop = false;
            this.ibuttonOrganizationRemove.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonOrganizationRemove.TextFontSize = 12;
            this.ibuttonOrganizationRemove.ToolTipText = "Delete";
            this.ibuttonOrganizationRemove.Click += new System.EventHandler(this.ibuttonOrganizationRemove_Click);
            // 
            // ibuttonOrganizationAdd
            // 
            this.ibuttonOrganizationAdd.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonOrganizationAdd.AllowAutoSize = false;
            this.ibuttonOrganizationAdd.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonOrganizationAdd.Caption = "";
            this.ibuttonOrganizationAdd.IconTypeInt = 61543;
            this.ibuttonOrganizationAdd.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonOrganizationAdd.Location = new System.Drawing.Point(3, 4);
            this.ibuttonOrganizationAdd.Name = "ibuttonOrganizationAdd";
            this.ibuttonOrganizationAdd.ReadOnly = true;
            this.ibuttonOrganizationAdd.Size = new System.Drawing.Size(42, 28);
            this.ibuttonOrganizationAdd.TabIndex = 102;
            this.ibuttonOrganizationAdd.TabStop = false;
            this.ibuttonOrganizationAdd.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonOrganizationAdd.TextFontSize = 12;
            this.ibuttonOrganizationAdd.ToolTipText = "Add";
            this.ibuttonOrganizationAdd.Click += new System.EventHandler(this.ibuttonOrganizationAdd_Click);
            // 
            // panelOrganization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.gridData);
            this.Name = "panelOrganization";
            this.Size = new System.Drawing.Size(719, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonOrganizationEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonOrganizationRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonOrganizationAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedDataGridView gridData;
        private System.Windows.Forms.Panel panelMenu;
        private IconButton ibuttonOrganizationEdit;
        private IconButton ibuttonOrganizationRemove;
        private IconButton ibuttonOrganizationAdd;
        private IconButton ibuttonImport;
    }
}
