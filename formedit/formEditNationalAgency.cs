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
    public partial class formEditNationalAgency : Form
    {
        private modelNationalAgency originalData;
        private modelNationalAgency newData;
        public modelNationalAgency savedData;

        private int posX;
        private int posY;
        private int posW;
        private int posH;

        public formEditNationalAgency()
        {
            InitializeComponent();
        }

        public formEditNationalAgency(modelNationalAgency agency)
        {
            InitializeComponent();

            originalData = new modelNationalAgency();
            originalData = agency.DeepClone();
            newData = new modelNationalAgency();
            newData = agency.DeepClone();
            savedData = null;

            ShowCountries();
            ShowData(originalData);
        }

        private void ShowData(modelNationalAgency agency)
        {
            textNACode.Text = agency.NACode;
            textAgencyName.Text = agency.AgencyName;
            comboCountry.Text = Program.GData.dataLOV.getCountries.First(c => c.ID == agency.Country).CountryCode();
        }
        private void GetData(ref modelNationalAgency agency)
        {
            agency.NACode = textNACode.Text;
            agency.AgencyName = textAgencyName.Text;
            agency.Country = Program.GData.dataLOV.getCountries.First(c => c.CountryCode() == comboCountry.Text).ID;
        }
        private void ShowCountries()
        {
            comboCountry.Items.Clear();

            foreach (var country in Program.GData.dataLOV.getCountries)
            {
                var item = comboCountry.Items.Add(country.CountryCode());
            }
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            if(!Program.Compare<modelNationalAgency>(originalData, newData))
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
            
            savedData = new modelNationalAgency();
            savedData = newData.DeepClone();
            this.Hide();
        }

        private void textNACode_TextChanged(object sender, EventArgs e)
        {
            bool ok = false; ;
            if(textNACode.Text.Length > 2 && comboCountry.Text.Length > 2)
                if( textNACode.Text.Substring(0,2) == comboCountry.Text.Substring(0, 2))
                    ok = true;

            if (ok)
            {
                ibuttonSave.Visible = true;
                textNACode.BackColor = Color.White;
            }
            else
            {
                ibuttonSave.Visible = false;
                textNACode.BackColor = Color.Red;
            }
        }
    }
}
