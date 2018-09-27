using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erasmDB.formedit
{
    public partial class formEditCountry : Form
    {
        private modelCountry originalData;
        private modelCountry newData;
        public modelCountry savedData;

        private int posX;
        private int posY;
        private int posW;
        private int posH;

        public formEditCountry()
        {
            InitializeComponent();
        }

        public formEditCountry(modelCountry country)
        {
            InitializeComponent();

            originalData = new modelCountry();
            originalData = country.DeepClone();
            newData = new modelCountry();
            newData = country.DeepClone();
            savedData = null;

            ShowData(originalData);
        }

        private void ShowData(modelCountry country)
        {
            textCode.Text = country.Code;
            textCountry.Text = country.Country;
            textRate.Text = country.Rate.ToString();
        }
        private void GetData(ref modelCountry country)
        {
            float tmp;
            if (float.TryParse(textRate.Text, out tmp)) country.Rate = tmp;

            country.Code = textCode.Text;
            country.Country = textCountry.Text;
        }


        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            if(!Program.Compare<modelCountry>(originalData, newData))
            {
                if(!Program.ShowMessageBox("Do you want to scrap changes?", true, "YES", "NO"))
                {
                    return;
                }
            }
            newData = null;
            this.Hide();
        }

        private void ibuttonSave_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            savedData = new modelCountry();
            savedData = newData.DeepClone();
            this.Hide();
        }

    }
}
