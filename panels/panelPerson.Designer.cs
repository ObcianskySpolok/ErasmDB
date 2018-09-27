namespace erasmDB.panels
{
    partial class panelPerson
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
            this.ibuttonPersonEdit = new erasmDB.IconButton();
            this.ibuttonPersonRemove = new erasmDB.IconButton();
            this.ibuttonPersonAdd = new erasmDB.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonPersonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonPersonRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonPersonAdd)).BeginInit();
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
            this.panelMenu.Controls.Add(this.ibuttonPersonEdit);
            this.panelMenu.Controls.Add(this.ibuttonPersonRemove);
            this.panelMenu.Controls.Add(this.ibuttonPersonAdd);
            this.panelMenu.Location = new System.Drawing.Point(519, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(149, 35);
            this.panelMenu.TabIndex = 30;
            // 
            // ibuttonPersonEdit
            // 
            this.ibuttonPersonEdit.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonPersonEdit.AllowAutoSize = false;
            this.ibuttonPersonEdit.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonPersonEdit.Caption = "";
            this.ibuttonPersonEdit.IconTypeInt = 61504;
            this.ibuttonPersonEdit.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonPersonEdit.Location = new System.Drawing.Point(99, 4);
            this.ibuttonPersonEdit.Name = "ibuttonPersonEdit";
            this.ibuttonPersonEdit.ReadOnly = true;
            this.ibuttonPersonEdit.Size = new System.Drawing.Size(42, 28);
            this.ibuttonPersonEdit.TabIndex = 105;
            this.ibuttonPersonEdit.TabStop = false;
            this.ibuttonPersonEdit.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonPersonEdit.TextFontSize = 12;
            this.ibuttonPersonEdit.ToolTipText = null;
            this.ibuttonPersonEdit.Click += new System.EventHandler(this.ibuttonPersonEdit_Click);
            // 
            // ibuttonPersonRemove
            // 
            this.ibuttonPersonRemove.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonPersonRemove.AllowAutoSize = false;
            this.ibuttonPersonRemove.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonPersonRemove.Caption = "";
            this.ibuttonPersonRemove.IconTypeInt = 61544;
            this.ibuttonPersonRemove.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonPersonRemove.Location = new System.Drawing.Point(51, 4);
            this.ibuttonPersonRemove.Name = "ibuttonPersonRemove";
            this.ibuttonPersonRemove.ReadOnly = true;
            this.ibuttonPersonRemove.Size = new System.Drawing.Size(42, 28);
            this.ibuttonPersonRemove.TabIndex = 103;
            this.ibuttonPersonRemove.TabStop = false;
            this.ibuttonPersonRemove.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonPersonRemove.TextFontSize = 12;
            this.ibuttonPersonRemove.ToolTipText = null;
            this.ibuttonPersonRemove.Click += new System.EventHandler(this.ibuttonPersonRemove_Click);
            // 
            // ibuttonPersonAdd
            // 
            this.ibuttonPersonAdd.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonPersonAdd.AllowAutoSize = false;
            this.ibuttonPersonAdd.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonPersonAdd.Caption = "";
            this.ibuttonPersonAdd.IconTypeInt = 61543;
            this.ibuttonPersonAdd.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonPersonAdd.Location = new System.Drawing.Point(3, 4);
            this.ibuttonPersonAdd.Name = "ibuttonPersonAdd";
            this.ibuttonPersonAdd.ReadOnly = true;
            this.ibuttonPersonAdd.Size = new System.Drawing.Size(42, 28);
            this.ibuttonPersonAdd.TabIndex = 102;
            this.ibuttonPersonAdd.TabStop = false;
            this.ibuttonPersonAdd.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonPersonAdd.TextFontSize = 12;
            this.ibuttonPersonAdd.ToolTipText = null;
            this.ibuttonPersonAdd.Click += new System.EventHandler(this.ibuttonPersonAdd_Click);
            // 
            // panelPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.gridData);
            this.Name = "panelPerson";
            this.Size = new System.Drawing.Size(719, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonPersonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonPersonRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonPersonAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedDataGridView gridData;
        private System.Windows.Forms.Panel panelMenu;
        private IconButton ibuttonPersonAdd;
        private IconButton ibuttonPersonRemove;
        private IconButton ibuttonPersonEdit;
    }
}
