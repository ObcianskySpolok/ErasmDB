using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace erasmDB
{
    public partial class formMessageBox : Form
    {
        public bool returnValue { get; set; }
        public string returnText { get; set; }

        public formMessageBox(string info,bool ShowYesNo,bool inputBox, string YesButtonText, string NoButtonText, string defaultText, int autoCloseInterval)
        {
            InitializeComponent();

            if (autoCloseInterval != -1)
            {
                timerAutoClose.Interval = autoCloseInterval;
                timerAutoClose.Enabled = true;
            }
            else
            {
                timerAutoClose.Enabled = false;                
            }

            labelInfo.Text = info;
            if (inputBox){
                textInput.Text = defaultText;
                textInput.Visible = true;
                ShowYesNo = false;
            }
            else
            {
                textInput.Text = "";
                textInput.Visible = false;                
            }
            if (ShowYesNo)
            {
                buttonOK.Visible = false;
                buttonANO.Text = YesButtonText;
                buttonANO.Update();
                buttonNIE.Text = NoButtonText;
                buttonNIE.Update();
                int w = this.Width;
                buttonANO.Left = w / 2 - buttonANO.Width-25;
                buttonNIE.Left = w / 2 + 25;
            }
            else
            {
                buttonANO.Visible = false;
                buttonNIE.Visible = false;
            }
        }


        private void buttonNIE_Click(object sender, EventArgs e)
        {
            returnValue = false;
            this.Hide();
        }

        private void buttonANO_Click(object sender, EventArgs e)
        {
            returnValue = true;
            this.Hide();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            returnValue = true;
            returnText = textInput.Text;
            this.Hide();
        }

        private void labelInfo_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timerAutoClose_Tick(object sender, EventArgs e)
        {
            returnValue = false;
            this.Hide();
        }

    }
}
