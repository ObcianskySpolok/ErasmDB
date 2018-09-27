namespace erasmDB
{
    partial class formSelectOrganization
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.labelCaption = new System.Windows.Forms.Label();
            this.ibuttonClose = new erasmDB.IconButton();
            this.ibuttonOK = new erasmDB.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonOK)).BeginInit();
            this.SuspendLayout();
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridData.ColumnHeadersHeight = 42;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridData.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridData.Location = new System.Drawing.Point(9, 56);
            this.gridData.Margin = new System.Windows.Forms.Padding(0);
            this.gridData.Name = "gridData";
            this.gridData.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridData.RowHeadersVisible = false;
            this.gridData.RowTemplate.Height = 30;
            this.gridData.RowTemplate.ReadOnly = true;
            this.gridData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridData.Size = new System.Drawing.Size(811, 446);
            this.gridData.TabIndex = 96;
            this.gridData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_CellClick);
            this.gridData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_CellDoubleClick);
            // 
            // labelCaption
            // 
            this.labelCaption.BackColor = System.Drawing.Color.Transparent;
            this.labelCaption.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.labelCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(100)))));
            this.labelCaption.Location = new System.Drawing.Point(9, 0);
            this.labelCaption.Margin = new System.Windows.Forms.Padding(0);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(302, 52);
            this.labelCaption.TabIndex = 97;
            this.labelCaption.Text = "zoznam odberatelia";
            this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ibuttonClose
            // 
            this.ibuttonClose.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ibuttonClose.AllowAutoSize = false;
            this.ibuttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonClose.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonClose.Caption = "";
            this.ibuttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibuttonClose.IconTypeInt = 61527;
            this.ibuttonClose.InActiveColor = System.Drawing.Color.Black;
            this.ibuttonClose.Location = new System.Drawing.Point(767, 0);
            this.ibuttonClose.Name = "ibuttonClose";
            this.ibuttonClose.ReadOnly = false;
            this.ibuttonClose.Size = new System.Drawing.Size(50, 52);
            this.ibuttonClose.TabIndex = 98;
            this.ibuttonClose.TabStop = false;
            this.ibuttonClose.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonClose.TextFontSize = 12;
            this.ibuttonClose.ToolTipText = null;
            this.ibuttonClose.Click += new System.EventHandler(this.ibuttonClose_Click);
            // 
            // ibuttonOK
            // 
            this.ibuttonOK.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ibuttonOK.AllowAutoSize = false;
            this.ibuttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonOK.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonOK.Caption = "";
            this.ibuttonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibuttonOK.IconTypeInt = 61639;
            this.ibuttonOK.InActiveColor = System.Drawing.Color.Black;
            this.ibuttonOK.Location = new System.Drawing.Point(711, 0);
            this.ibuttonOK.Name = "ibuttonOK";
            this.ibuttonOK.ReadOnly = false;
            this.ibuttonOK.Size = new System.Drawing.Size(50, 52);
            this.ibuttonOK.TabIndex = 99;
            this.ibuttonOK.TabStop = false;
            this.ibuttonOK.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonOK.TextFontSize = 12;
            this.ibuttonOK.ToolTipText = null;
            this.ibuttonOK.Click += new System.EventHandler(this.ibuttonOK_Click);
            // 
            // formSelectOrganization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(829, 511);
            this.Controls.Add(this.ibuttonOK);
            this.Controls.Add(this.ibuttonClose);
            this.Controls.Add(this.labelCaption);
            this.Controls.Add(this.gridData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formSelectOrganization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "formSelect";
            this.Load += new System.EventHandler(this.formSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonOK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.Label labelCaption;
        private IconButton ibuttonClose;
        private IconButton ibuttonOK;
    }
}