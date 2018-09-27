namespace erasmDB.formedit
{
    partial class formEditMobility
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
            this.ibuttonClose = new erasmDB.IconButton();
            this.ibuttonSave = new erasmDB.IconButton();
            this.comboDistanceBand = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textTravelDays = new System.Windows.Forms.TextBox();
            this.ibuttonLookupOrigin = new erasmDB.IconButton();
            this.labelCountryOfOrigin = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textParticipants = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textFewerOpportunities = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textGTF000 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textGroupLeaders = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTrainers = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textFacilitators = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textOthers = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ibuttonRecalc = new erasmDB.IconButton();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.textRate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonLookupOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonRecalc)).BeginInit();
            this.SuspendLayout();
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
            this.ibuttonClose.Location = new System.Drawing.Point(482, 287);
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
            this.ibuttonSave.Location = new System.Drawing.Point(570, 287);
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
            // comboDistanceBand
            // 
            this.comboDistanceBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDistanceBand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDistanceBand.FormattingEnabled = true;
            this.comboDistanceBand.Location = new System.Drawing.Point(160, 67);
            this.comboDistanceBand.Name = "comboDistanceBand";
            this.comboDistanceBand.Size = new System.Drawing.Size(460, 29);
            this.comboDistanceBand.TabIndex = 40;
            this.comboDistanceBand.SelectedIndexChanged += new System.EventHandler(this.comboDistanceBand_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 20);
            this.label17.TabIndex = 41;
            this.label17.Text = "Distance Band";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 27);
            this.label1.TabIndex = 83;
            this.label1.Text = "Travel days";
            // 
            // textTravelDays
            // 
            this.textTravelDays.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTravelDays.Location = new System.Drawing.Point(160, 102);
            this.textTravelDays.Name = "textTravelDays";
            this.textTravelDays.Size = new System.Drawing.Size(100, 33);
            this.textTravelDays.TabIndex = 89;
            // 
            // ibuttonLookupOrigin
            // 
            this.ibuttonLookupOrigin.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonLookupOrigin.AllowAutoSize = false;
            this.ibuttonLookupOrigin.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonLookupOrigin.Caption = "";
            this.ibuttonLookupOrigin.CustomMargin = 5;
            this.ibuttonLookupOrigin.IconTypeInt = 61442;
            this.ibuttonLookupOrigin.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonLookupOrigin.Location = new System.Drawing.Point(112, 12);
            this.ibuttonLookupOrigin.Name = "ibuttonLookupOrigin";
            this.ibuttonLookupOrigin.ReadOnly = true;
            this.ibuttonLookupOrigin.Size = new System.Drawing.Size(28, 34);
            this.ibuttonLookupOrigin.TabIndex = 119;
            this.ibuttonLookupOrigin.TabStop = false;
            this.ibuttonLookupOrigin.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonLookupOrigin.TextFontSize = 12;
            this.ibuttonLookupOrigin.ToolTipText = null;
            this.ibuttonLookupOrigin.Click += new System.EventHandler(this.ibuttonLookupOrigin_Click);
            // 
            // labelCountryOfOrigin
            // 
            this.labelCountryOfOrigin.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.labelCountryOfOrigin.Location = new System.Drawing.Point(153, 12);
            this.labelCountryOfOrigin.Name = "labelCountryOfOrigin";
            this.labelCountryOfOrigin.Size = new System.Drawing.Size(498, 37);
            this.labelCountryOfOrigin.TabIndex = 118;
            this.labelCountryOfOrigin.Text = "Title";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 48);
            this.label9.TabIndex = 117;
            this.label9.Text = "Country of Origin";
            // 
            // textParticipants
            // 
            this.textParticipants.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textParticipants.Location = new System.Drawing.Point(160, 155);
            this.textParticipants.Name = "textParticipants";
            this.textParticipants.ReadOnly = true;
            this.textParticipants.Size = new System.Drawing.Size(100, 33);
            this.textParticipants.TabIndex = 121;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 27);
            this.label3.TabIndex = 120;
            this.label3.Text = "Participants";
            // 
            // textFewerOpportunities
            // 
            this.textFewerOpportunities.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFewerOpportunities.Location = new System.Drawing.Point(160, 194);
            this.textFewerOpportunities.Name = "textFewerOpportunities";
            this.textFewerOpportunities.ReadOnly = true;
            this.textFewerOpportunities.Size = new System.Drawing.Size(100, 33);
            this.textFewerOpportunities.TabIndex = 123;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 27);
            this.label4.TabIndex = 122;
            this.label4.Text = "Fewer Opportunities";
            // 
            // textGTF000
            // 
            this.textGTF000.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGTF000.Location = new System.Drawing.Point(482, 161);
            this.textGTF000.Name = "textGTF000";
            this.textGTF000.Size = new System.Drawing.Size(100, 33);
            this.textGTF000.TabIndex = 125;
            this.textGTF000.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(334, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 27);
            this.label5.TabIndex = 124;
            this.label5.Text = "GTF";
            this.label5.Visible = false;
            // 
            // textGroupLeaders
            // 
            this.textGroupLeaders.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGroupLeaders.Location = new System.Drawing.Point(160, 233);
            this.textGroupLeaders.Name = "textGroupLeaders";
            this.textGroupLeaders.ReadOnly = true;
            this.textGroupLeaders.Size = new System.Drawing.Size(100, 33);
            this.textGroupLeaders.TabIndex = 127;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 27);
            this.label2.TabIndex = 126;
            this.label2.Text = "Group Leaders";
            // 
            // textTrainers
            // 
            this.textTrainers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTrainers.Location = new System.Drawing.Point(160, 272);
            this.textTrainers.Name = "textTrainers";
            this.textTrainers.ReadOnly = true;
            this.textTrainers.Size = new System.Drawing.Size(100, 33);
            this.textTrainers.TabIndex = 129;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 27);
            this.label6.TabIndex = 128;
            this.label6.Text = "Trainers";
            // 
            // textFacilitators
            // 
            this.textFacilitators.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFacilitators.Location = new System.Drawing.Point(160, 311);
            this.textFacilitators.Name = "textFacilitators";
            this.textFacilitators.Size = new System.Drawing.Size(100, 33);
            this.textFacilitators.TabIndex = 131;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 27);
            this.label7.TabIndex = 130;
            this.label7.Text = "Facilitators";
            // 
            // textOthers
            // 
            this.textOthers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOthers.Location = new System.Drawing.Point(160, 350);
            this.textOthers.Name = "textOthers";
            this.textOthers.Size = new System.Drawing.Size(100, 33);
            this.textOthers.TabIndex = 133;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 356);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 27);
            this.label8.TabIndex = 132;
            this.label8.Text = "Others";
            // 
            // ibuttonRecalc
            // 
            this.ibuttonRecalc.ActiveColor = System.Drawing.Color.Black;
            this.ibuttonRecalc.AllowAutoSize = false;
            this.ibuttonRecalc.BackColor = System.Drawing.Color.Transparent;
            this.ibuttonRecalc.Caption = "";
            this.ibuttonRecalc.CustomMargin = 2;
            this.ibuttonRecalc.IconTypeInt = 61473;
            this.ibuttonRecalc.InActiveColor = System.Drawing.Color.DimGray;
            this.ibuttonRecalc.Location = new System.Drawing.Point(266, 155);
            this.ibuttonRecalc.Name = "ibuttonRecalc";
            this.ibuttonRecalc.ReadOnly = true;
            this.ibuttonRecalc.Size = new System.Drawing.Size(28, 34);
            this.ibuttonRecalc.TabIndex = 134;
            this.ibuttonRecalc.TabStop = false;
            this.ibuttonRecalc.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.ibuttonRecalc.TextFontSize = 12;
            this.ibuttonRecalc.ToolTipText = null;
            this.ibuttonRecalc.Click += new System.EventHandler(this.ibuttonRecalc_Click);
            // 
            // textPrice
            // 
            this.textPrice.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textPrice.Location = new System.Drawing.Point(482, 108);
            this.textPrice.Name = "textPrice";
            this.textPrice.ReadOnly = true;
            this.textPrice.Size = new System.Drawing.Size(58, 22);
            this.textPrice.TabIndex = 135;
            // 
            // textRate
            // 
            this.textRate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textRate.Location = new System.Drawing.Point(546, 108);
            this.textRate.Name = "textRate";
            this.textRate.ReadOnly = true;
            this.textRate.Size = new System.Drawing.Size(58, 22);
            this.textRate.TabIndex = 136;
            // 
            // formEditMobility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 393);
            this.Controls.Add(this.textRate);
            this.Controls.Add(this.textPrice);
            this.Controls.Add(this.ibuttonRecalc);
            this.Controls.Add(this.textOthers);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textFacilitators);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textTrainers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textGroupLeaders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textGTF000);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textFewerOpportunities);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textParticipants);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ibuttonLookupOrigin);
            this.Controls.Add(this.labelCountryOfOrigin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textTravelDays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDistanceBand);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ibuttonClose);
            this.Controls.Add(this.ibuttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formEditMobility";
            this.Text = "Mobility";
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonLookupOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuttonRecalc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private IconButton ibuttonSave;
        private IconButton ibuttonClose;
        private System.Windows.Forms.ComboBox comboDistanceBand;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTravelDays;
        private IconButton ibuttonLookupOrigin;
        private System.Windows.Forms.Label labelCountryOfOrigin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textParticipants;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textFewerOpportunities;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textGTF000;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textGroupLeaders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTrainers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textFacilitators;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textOthers;
        private System.Windows.Forms.Label label8;
        private IconButton ibuttonRecalc;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.TextBox textRate;
    }
}