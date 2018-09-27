namespace erasmDB
{
    partial class formMessageBox
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
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonANO = new System.Windows.Forms.Button();
            this.buttonNIE = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textInput = new System.Windows.Forms.TextBox();
            this.timerAutoClose = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI Light", 25F);
            this.labelInfo.ForeColor = System.Drawing.Color.Gray;
            this.labelInfo.Location = new System.Drawing.Point(27, 9);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(726, 154);
            this.labelInfo.TabIndex = 86;
            this.labelInfo.Text = "opakovanie:";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInfo.Click += new System.EventHandler(this.labelInfo_Click);
            // 
            // buttonANO
            // 
            this.buttonANO.AutoSize = true;
            this.buttonANO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.buttonANO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonANO.Font = new System.Drawing.Font("Segoe UI Light", 25F);
            this.buttonANO.Location = new System.Drawing.Point(192, 235);
            this.buttonANO.Name = "buttonANO";
            this.buttonANO.Size = new System.Drawing.Size(175, 67);
            this.buttonANO.TabIndex = 87;
            this.buttonANO.Text = "ÁNO";
            this.buttonANO.UseVisualStyleBackColor = false;
            this.buttonANO.Click += new System.EventHandler(this.buttonANO_Click);
            // 
            // buttonNIE
            // 
            this.buttonNIE.AutoSize = true;
            this.buttonNIE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.buttonNIE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonNIE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNIE.Font = new System.Drawing.Font("Segoe UI Light", 25F);
            this.buttonNIE.Location = new System.Drawing.Point(386, 235);
            this.buttonNIE.Name = "buttonNIE";
            this.buttonNIE.Size = new System.Drawing.Size(175, 67);
            this.buttonNIE.TabIndex = 88;
            this.buttonNIE.Text = "NIE";
            this.buttonNIE.UseVisualStyleBackColor = false;
            this.buttonNIE.Click += new System.EventHandler(this.buttonNIE_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI Light", 25F);
            this.buttonOK.Location = new System.Drawing.Point(297, 235);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(175, 67);
            this.buttonOK.TabIndex = 89;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textInput);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 326);
            this.panel1.TabIndex = 90;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textInput
            // 
            this.textInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textInput.Font = new System.Drawing.Font("Segoe UI Light", 25F);
            this.textInput.Location = new System.Drawing.Point(11, 166);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(752, 52);
            this.textInput.TabIndex = 0;
            // 
            // timerAutoClose
            // 
            this.timerAutoClose.Tick += new System.EventHandler(this.timerAutoClose_Tick);
            // 
            // formMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CancelButton = this.buttonNIE;
            this.ClientSize = new System.Drawing.Size(776, 329);
            this.ControlBox = false;
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonNIE);
            this.Controls.Add(this.buttonANO);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formMessageBox";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonANO;
        private System.Windows.Forms.Button buttonNIE;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Timer timerAutoClose;
    }
}