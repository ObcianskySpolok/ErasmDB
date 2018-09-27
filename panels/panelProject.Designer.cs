namespace erasmDB.panels
{
    partial class panelProject
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
            this.ibuttonProjectEdit = new erasmDB.IconButton();
            this.ibuttonProjectRemove = new erasmDB.IconButton();
            this.ibuttonProjectAdd = new erasmDB.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonProjectEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonProjectRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonProjectAdd)).BeginInit();
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
            this.panelMenu.Controls.Add(this.ibuttonProjectEdit);
            this.panelMenu.Controls.Add(this.ibuttonProjectRemove);
            this.panelMenu.Controls.Add(this.ibuttonProjectAdd);
            this.panelMenu.Location = new System.Drawing.Point(508, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(149, 35);
            this.panelMenu.TabIndex = 32;
            // 
            // ibuttonProjectEdit
            // 
            this.ibuttonProjectEdit.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonProjectEdit.AllowAutoSize = false;
            this.ibuttonProjectEdit.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonProjectEdit.Caption = "";
            this.ibuttonProjectEdit.CustomMargin = 5;
            this.ibuttonProjectEdit.IconTypeInt = 61508;
            this.ibuttonProjectEdit.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonProjectEdit.Location = new System.Drawing.Point(99, 4);
            this.ibuttonProjectEdit.Name = "ibuttonProjectEdit";
            this.ibuttonProjectEdit.ReadOnly = true;
            this.ibuttonProjectEdit.Size = new System.Drawing.Size(42, 28);
            this.ibuttonProjectEdit.TabIndex = 105;
            this.ibuttonProjectEdit.TabStop = false;
            this.ibuttonProjectEdit.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonProjectEdit.TextFontSize = 12;
            this.ibuttonProjectEdit.ToolTipText = null;
            this.ibuttonProjectEdit.Click += new System.EventHandler(this.ibuttonProjectEdit_Click);
            // 
            // ibuttonProjectRemove
            // 
            this.ibuttonProjectRemove.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonProjectRemove.AllowAutoSize = false;
            this.ibuttonProjectRemove.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonProjectRemove.Caption = "";
            this.ibuttonProjectRemove.CustomMargin = 5;
            this.ibuttonProjectRemove.IconTypeInt = 61544;
            this.ibuttonProjectRemove.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonProjectRemove.Location = new System.Drawing.Point(51, 4);
            this.ibuttonProjectRemove.Name = "ibuttonProjectRemove";
            this.ibuttonProjectRemove.ReadOnly = true;
            this.ibuttonProjectRemove.Size = new System.Drawing.Size(42, 28);
            this.ibuttonProjectRemove.TabIndex = 103;
            this.ibuttonProjectRemove.TabStop = false;
            this.ibuttonProjectRemove.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonProjectRemove.TextFontSize = 12;
            this.ibuttonProjectRemove.ToolTipText = null;
            this.ibuttonProjectRemove.Click += new System.EventHandler(this.ibuttonProjectRemove_Click);
            // 
            // ibuttonProjectAdd
            // 
            this.ibuttonProjectAdd.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonProjectAdd.AllowAutoSize = false;
            this.ibuttonProjectAdd.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonProjectAdd.Caption = "";
            this.ibuttonProjectAdd.CustomMargin = 5;
            this.ibuttonProjectAdd.IconTypeInt = 61543;
            this.ibuttonProjectAdd.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonProjectAdd.Location = new System.Drawing.Point(3, 4);
            this.ibuttonProjectAdd.Name = "ibuttonProjectAdd";
            this.ibuttonProjectAdd.ReadOnly = true;
            this.ibuttonProjectAdd.Size = new System.Drawing.Size(42, 28);
            this.ibuttonProjectAdd.TabIndex = 102;
            this.ibuttonProjectAdd.TabStop = false;
            this.ibuttonProjectAdd.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonProjectAdd.TextFontSize = 12;
            this.ibuttonProjectAdd.ToolTipText = null;
            this.ibuttonProjectAdd.Click += new System.EventHandler(this.ibuttonProjectAdd_Click);
            // 
            // panelProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.gridData);
            this.Name = "panelProject";
            this.Size = new System.Drawing.Size(719, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonProjectEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonProjectRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonProjectAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedDataGridView gridData;
        private System.Windows.Forms.Panel panelMenu;
        private IconButton ibuttonProjectEdit;
        private IconButton ibuttonProjectRemove;
        private IconButton ibuttonProjectAdd;
    }
}
