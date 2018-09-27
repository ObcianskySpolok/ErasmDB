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
    public partial class formEditMobility : Form
    {
        private modelMobility originalData;
        private modelMobility newData;
        public modelMobility savedData;

        private int posX;
        private int posY;
        private int posW;
        private int posH;

        public formEditMobility()
        {
            InitializeComponent();
        }

        public formEditMobility(modelMobility mobility)
        {
            InitializeComponent();

            originalData = new modelMobility();
            originalData = mobility.DeepClone();
            newData = new modelMobility();
            newData = mobility.DeepClone();
            savedData = null;

            ShowDistanceBands();
            ShowData(originalData);
        }

        private void ShowCountries()
        {
            labelCountryOfOrigin.Text = Program.GData.dataLOV.getCountries.First(c => c.ID == newData.CountryOfOrigin).CountryCode();
        }
        private void ShowDistanceBands()
        {
            comboDistanceBand.Items.Clear();

            foreach (var country in Program.GData.dataLOV.getDistanceBands)
            {
                var item = comboDistanceBand.Items.Add(country.DistanceBand);
            }
        }
        private void ibuttonLookupOrigin_Click(object sender, EventArgs e)
        {
            int id = Program.SelectCountry();
            if (id == -1) return;

            var c = Program.GData.dataLOV.getCountry(id);
            newData.CountryOfOrigin = id;
            newData.Rate = c.Rate;
            textRate.Text = c.Rate.ToString();
            ShowCountries();
        }

        private void ShowData(modelMobility mobility)
        {
            ShowCountries();
            textTravelDays.Text = mobility.TravelDays.ToString();
            textParticipants.Text = mobility.Participants.ToString();
            textFewerOpportunities.Text = mobility.FewerOpportunities.ToString();
            textGroupLeaders.Text = mobility.GroupLeaders.ToString();
            textTrainers.Text = mobility.Trainers.ToString();
            textFacilitators.Text = mobility.Facilitators.ToString();
            textOthers.Text = mobility.Others.ToString();
            textRate.Text = mobility.Rate.ToString();
            textPrice.Text = mobility.Price.ToString();
            comboDistanceBand.Text = Program.GData.dataLOV.getDistanceBands.First(c => c.ID == mobility.DistanceBand).DistanceBand;
        }
        private void GetData(ref modelMobility mobility)
        {
            int tmp; float fmp;

            if (int.TryParse(textTravelDays.Text, out tmp)) mobility.TravelDays = tmp;
            if (int.TryParse(textParticipants.Text, out tmp)) mobility.Participants = tmp;
            if (int.TryParse(textFewerOpportunities.Text, out tmp)) mobility.FewerOpportunities = tmp;
            if (int.TryParse(textGroupLeaders.Text, out tmp)) mobility.GroupLeaders = tmp;
            if (int.TryParse(textTrainers.Text, out tmp)) mobility.Trainers = tmp;
            if (int.TryParse(textFacilitators.Text, out tmp)) mobility.Facilitators = tmp;
            if (int.TryParse(textOthers.Text, out tmp)) mobility.Others = tmp;
            if (float.TryParse(textRate.Text, out fmp)) mobility.Rate = fmp;

            //mobility.DistanceBand = Program.GData.dataLOV.getDistanceBands.First(c => c.DistanceBand == comboDistanceBand.Text).ID;
            var db = Program.GData.dataLOV.getDistanceBands.First(c => c.DistanceBand == comboDistanceBand.Text);
            mobility.DistanceBand = db.ID;
            mobility.Price = db.Price;
        }


        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            if(!Program.Compare<modelMobility>(originalData, newData))
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
            
            savedData = new modelMobility();
            savedData = newData.DeepClone();
            this.Hide();
        }

        private void ibuttonRecalc_Click(object sender, EventArgs e)
        {
            int participants;
            if (!int.TryParse(textParticipants.Text, out participants))
                return;

            if (participants < 10)
                textGroupLeaders.Text = "1";
            else if(participants < 20)
                textGroupLeaders.Text = "2";
            else
                textGroupLeaders.Text = "4";
        }

        private void comboDistanceBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = Program.GData.dataLOV.getDistanceBands.First(c => c.DistanceBand == comboDistanceBand.Text);
            textPrice.Text = db.Price.ToString();
        }
    }
}
