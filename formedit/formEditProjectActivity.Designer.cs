namespace erasmDB.formedit
{
    partial class formEditProjectActivity
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
            this.labelProject = new System.Windows.Forms.Label();
            this.ibuttonClose = new erasmDB.IconButton();
            this.ibuttonSave = new erasmDB.IconButton();
            this.comboActivities = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textDuration = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonSave)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProject
            // 
            this.labelProject.AutoSize = true;
            this.labelProject.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.labelProject.Location = new System.Drawing.Point(30, 94);
            this.labelProject.Name = "labelProject";
            this.labelProject.Size = new System.Drawing.Size(68, 37);
            this.labelProject.TabIndex = 1;
            this.labelProject.Text = "Title";
            // 
            // ibuttonClose
            // 
            this.ibuttonClose.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonClose.AllowAutoSize = false;
            this.ibuttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ibuttonClose.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonClose.Caption = "cancel";
            this.ibuttonClose.CustomMargin = 5;
            this.ibuttonClose.IconTypeInt = 61534;
            this.ibuttonClose.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonClose.Location = new System.Drawing.Point(663, 77);
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
            this.ibuttonSave.CustomMargin = 5;
            this.ibuttonSave.IconTypeInt = 61639;
            this.ibuttonSave.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonSave.Location = new System.Drawing.Point(751, 77);
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
            // comboActivities
            // 
            this.comboActivities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboActivities.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboActivities.FormattingEnabled = true;
            this.comboActivities.Location = new System.Drawing.Point(116, 142);
            this.comboActivities.Name = "comboActivities";
            this.comboActivities.Size = new System.Drawing.Size(534, 29);
            this.comboActivities.TabIndex = 40;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(28, 151);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 20);
            this.label17.TabIndex = 41;
            this.label17.Text = "Activity";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 45);
            this.label1.TabIndex = 83;
            this.label1.Text = "Title";
            // 
            // textDuration
            // 
            this.textDuration.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDuration.Location = new System.Drawing.Point(116, 51);
            this.textDuration.Name = "textDuration";
            this.textDuration.Size = new System.Drawing.Size(442, 33);
            this.textDuration.TabIndex = 88;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(33, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 87;
            this.label2.Text = "Duration";
            // 
            // textTitle
            // 
            this.textTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitle.Location = new System.Drawing.Point(116, 12);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(387, 33);
            this.textTitle.TabIndex = 90;
            // 
            // formEditProjectActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 183);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.textDuration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboActivities);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ibuttonClose);
            this.Controls.Add(this.ibuttonSave);
            this.Controls.Add(this.labelProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formEditProjectActivity";
            this.Text = "Project Activity";
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelProject;
        private IconButton ibuttonSave;
        private IconButton ibuttonClose;
        private System.Windows.Forms.ComboBox comboActivities;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTitle;
    }
}