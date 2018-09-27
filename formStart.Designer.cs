namespace erasmDB
{
    partial class formStart
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formStart));
            this.ibuttonLocal = new erasmDB.IconButton();
            this.ibuttonStdSQL = new erasmDB.IconButton();
            this.ibuttonAzure = new erasmDB.IconButton();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonStdSQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonAzure)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ibuttonLocal
            // 
            this.ibuttonLocal.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonLocal.AllowAutoSize = false;
            this.ibuttonLocal.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonLocal.Caption = "local database";
            this.ibuttonLocal.CustomMargin = 5;
            this.ibuttonLocal.IconTypeInt = 61705;
            this.ibuttonLocal.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonLocal.Location = new System.Drawing.Point(12, 42);
            this.ibuttonLocal.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonLocal.Name = "ibuttonLocal";
            this.ibuttonLocal.ReadOnly = false;
            this.ibuttonLocal.Size = new System.Drawing.Size(322, 116);
            this.ibuttonLocal.TabIndex = 0;
            this.ibuttonLocal.TabStop = false;
            this.ibuttonLocal.TextFont = new System.Drawing.Font("Segoe UI", 20F);
            this.ibuttonLocal.TextFontSize = 20;
            this.ibuttonLocal.ToolTipText = null;
            this.ibuttonLocal.Click += new System.EventHandler(this.ibuttonLocal_Click);
            // 
            // ibuttonStdSQL
            // 
            this.ibuttonStdSQL.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonStdSQL.AllowAutoSize = false;
            this.ibuttonStdSQL.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonStdSQL.Caption = "standart server";
            this.ibuttonStdSQL.CustomMargin = 5;
            this.ibuttonStdSQL.IconTypeInt = 61461;
            this.ibuttonStdSQL.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonStdSQL.Location = new System.Drawing.Point(334, 42);
            this.ibuttonStdSQL.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonStdSQL.Name = "ibuttonStdSQL";
            this.ibuttonStdSQL.ReadOnly = false;
            this.ibuttonStdSQL.Size = new System.Drawing.Size(322, 116);
            this.ibuttonStdSQL.TabIndex = 1;
            this.ibuttonStdSQL.TabStop = false;
            this.ibuttonStdSQL.TextFont = new System.Drawing.Font("Segoe UI", 20F);
            this.ibuttonStdSQL.TextFontSize = 20;
            this.ibuttonStdSQL.ToolTipText = null;
            this.ibuttonStdSQL.Click += new System.EventHandler(this.ibuttonStdSQL_Click);
            // 
            // ibuttonAzure
            // 
            this.ibuttonAzure.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonAzure.AllowAutoSize = false;
            this.ibuttonAzure.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ibuttonAzure.Caption = "cloud database";
            this.ibuttonAzure.CustomMargin = 5;
            this.ibuttonAzure.IconTypeInt = 61634;
            this.ibuttonAzure.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonAzure.Location = new System.Drawing.Point(656, 42);
            this.ibuttonAzure.Margin = new System.Windows.Forms.Padding(0);
            this.ibuttonAzure.Name = "ibuttonAzure";
            this.ibuttonAzure.ReadOnly = false;
            this.ibuttonAzure.Size = new System.Drawing.Size(322, 116);
            this.ibuttonAzure.TabIndex = 2;
            this.ibuttonAzure.TabStop = false;
            this.ibuttonAzure.TextFont = new System.Drawing.Font("Segoe UI", 20F);
            this.ibuttonAzure.TextFontSize = 20;
            this.ibuttonAzure.ToolTipText = null;
            this.ibuttonAzure.Click += new System.EventHandler(this.ibuttonAzure_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.Red;
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClose.BackgroundImage")));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(923, 8);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(60, 26);
            this.buttonClose.TabIndex = 18;
            this.buttonClose.TabStop = false;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.ibuttonAzure);
            this.panel1.Controls.Add(this.ibuttonLocal);
            this.panel1.Controls.Add(this.ibuttonStdSQL);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 169);
            this.panel1.TabIndex = 19;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 3000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // formStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 169);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formStart";
            this.Text = "formStart";
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonStdSQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonAzure)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IconButton ibuttonLocal;
        private IconButton ibuttonStdSQL;
        private IconButton ibuttonAzure;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerRefresh;
    }
}