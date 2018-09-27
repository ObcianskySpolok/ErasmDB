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
    public partial class formEditProjectActivityVariation : Form
    {
        private modelProjectActivityVariation originalData;
        private modelProjectActivityVariation newData;
        public modelProjectActivityVariation savedData;

        public formEditProjectActivityVariation()
        {
            InitializeComponent();
        }

        public formEditProjectActivityVariation(modelProjectActivityVariation activityVariation)
        {
            InitializeComponent();

            originalData = new modelProjectActivityVariation();
            originalData = activityVariation.DeepClone();
            newData = new modelProjectActivityVariation();
            newData = activityVariation.DeepClone();
            savedData = null;

            ShowData(originalData);
            ShowCountries();
            ShowEndDate();
            ShowProjectTitle();

            gridMobility.SetupLinq += GridMobility_SetupLinq;
            gridMobility.SetupGrid += GridMobility_SetupGrid;
            gridMobility.LoadGrid();
        }

        private void GridMobility_SetupGrid()
        {
            var fntHeadline = new Font("Segoe UI Light", 11);
            var fntNormal = new Font("Segoe UI Light", 12);
            var fntSmaller = new Font("Segoe UI Light", 10);

            gridMobility.ColumnHeadersDefaultCellStyle.Font = fntHeadline;
            gridMobility.DefaultCellStyle.Font = fntNormal;

            gridMobility.Columns["DistanceBand"].DefaultCellStyle.Font = fntSmaller;
            gridMobility.Columns["CountryCode"].DefaultCellStyle.Font = fntSmaller;

            gridMobility.Columns["ID"].Visible = false;
            gridMobility.Columns["MobilityOrder"].Visible = false;
            
            gridMobility.Columns["CountryCode"].Width = 140;
            gridMobility.Columns["DistanceBand"].Width = 110;
            gridMobility.Columns["TravelDays"].Width = 75;
            gridMobility.Columns["Participants"].Width = 75;
            gridMobility.Columns["FewerOpportunities"].Width = 75;
            gridMobility.Columns["GroupLeaders"].Width = 75;
            gridMobility.Columns["Trainers"].Width = 75;
            gridMobility.Columns["Facilitators"].Width = 75;
            gridMobility.Columns["Others"].Width = 75;

            //gridMobility.Columns["Rate"].HeaderText = "CountryRate";
            gridMobility.Columns["Price"].HeaderText = "DistBandRate";

            gridMobility.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private IEnumerable<object> GridMobility_SetupLinq(string filter)
        {
            var cod = Program.GData.dataLOV.getCountry(newData.CountryOfDestination);

            var mobs = (from mobilities in Program.GData.dataActivity.getMobilities
                        join countries in Program.GData.dataLOV.getCountries on mobilities.CountryOfOrigin equals countries.ID
                        join distbands in Program.GData.dataLOV.getDistanceBands on mobilities.DistanceBand equals distbands.ID
                        orderby mobilities.MobilityOrder
                        where mobilities.ActivityVariation == originalData.ID
                        let TotalParticipants = mobilities.Participants + mobilities.FewerOpportunities + mobilities.GroupLeaders + mobilities.Trainers + mobilities.Facilitators + mobilities.Others
                        select new
                        {
                            mobilities.ID,
                            CountryCode = countries.CountryCode(),
                            distbands.DistanceBand,
                            TotalParticipants,
                            mobilities.TravelDays,
                            mobilities.Participants,
                            mobilities.FewerOpportunities,
                            mobilities.GroupLeaders,
                            mobilities.Trainers,
                            mobilities.Facilitators,
                            mobilities.Others,
                            mobilities.MobilityOrder,
                            OrgSupport = mobilities.Rate * (originalData.Duration + mobilities.TravelDays) * TotalParticipants,
                            Travel = mobilities.Price * mobilities.Participants,
                            distbands.Price,
                          });

            if (mobs == null) return null;
            CountTotals();

            newData.OrgSupport = mobs.Sum(c => c.OrgSupport);
            newData.Travel = mobs.Sum(c => c.Travel);
            labelOrgSupport.Text = newData.OrgSupport.ToString();
            labelTravel.Text = newData.Travel.ToString();
            labelMoneyTotal.Text = (newData.OrgSupport + newData.Travel).ToString();

            return mobs.ToArray();
        }

        private void ShowData(modelProjectActivityVariation activityVariation)
        {
            textCityOfDestination.Text = activityVariation.CityOfDestination;
            dateStartDate.Value = activityVariation.StartDate;
            textDuration.Text = activityVariation.Duration.ToString();
            textPeriodDates.Text = activityVariation.PeriodDates;
            textStudyVisit.Text = activityVariation.StudyVisit;
            //htmlStudyVisit.InnerHtml = activityVariation.StudyVisit;
            textParticipantsPerCountry.Text = activityVariation.ParticipantsPerCountry.ToString(); 
            labelParticipantsTotal.Text = activityVariation.ParticipantsTotal.ToString(); 
            labelFewerOpportunitiesTotal.Text = activityVariation.FewerOpportunitieTotal.ToString(); 
            textFewerOpportunitiePerCountry.Text = activityVariation.FewerOpportunitiePerCountry.ToString(); ;
            textGroupLeadersPerCountry.Text = activityVariation.GTFPerCountry.ToString();

            labelGTFTotal.Text = activityVariation.GTFTotal.ToString();
        }

        private void GetData(ref modelProjectActivityVariation activityVariation)
        {
            int tmp;

            activityVariation.CityOfDestination = textCityOfDestination.Text;
            activityVariation.StartDate = dateStartDate.Value;
            activityVariation.EndDate = dateEndDate.Value;

            activityVariation.PeriodDates = textPeriodDates.Text;
            activityVariation.StudyVisit = textStudyVisit.Text;
            //activityVariation.StudyVisit = htmlStudyVisit.InnerHtml;

            if (int.TryParse(textDuration.Text, out tmp)) activityVariation.Duration = tmp;
            if (int.TryParse(textParticipantsPerCountry.Text, out tmp)) activityVariation.ParticipantsPerCountry = tmp;
            if (int.TryParse(labelParticipantsTotal.Text, out tmp)) activityVariation.ParticipantsTotal = tmp;
            if (int.TryParse(labelFewerOpportunitiesTotal.Text, out tmp)) activityVariation.FewerOpportunitieTotal = tmp;
            if (int.TryParse(textFewerOpportunitiePerCountry.Text, out tmp)) activityVariation.FewerOpportunitiePerCountry = tmp;
            if (int.TryParse(textGroupLeadersPerCountry.Text, out tmp)) activityVariation.GTFPerCountry = tmp;
            if (int.TryParse(labelGTFTotal.Text, out tmp)) activityVariation.GTFTotal = tmp;

        }


        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            if(!Program.Compare<modelProjectActivityVariation>(originalData, newData))
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
            SaveOrder();

            savedData = new modelProjectActivityVariation();
            savedData = newData.DeepClone();
            this.Hide();
        }

        private void ShowEndDate()
        {
            int duration;
            if (int.TryParse(textDuration.Text, out duration))
            {
                dateEndDate.Value = dateStartDate.Value.AddDays(duration-1);
            }
        }

        private void ShowProjectTitle()
        {
            long projectID  = Program.GData.dataProject.getProjectVariations.First(c => c.ID == originalData.ProjectVariation).ProjectID;
            labelProject.Text = Program.GData.dataProject.getProjects.First(c => c.ID == projectID).Title;
            labelActivity.Text = Program.GData.dataProject.getProjectActivities.First(c => c.ID == originalData.ProjectActivity).Title;
        }
        private void ShowCountries()
        {
            labelCountryOfDestination.Text = Program.GData.dataLOV.getCountries.First(c => c.ID == newData.CountryOfDestination).CountryCode();
        }

        private void ibuttonLookupDestination_Click(object sender, EventArgs e)
        {
            int id = Program.SelectCountry();
            if (id == -1) return;
            newData.CountryOfDestination = id;

            ShowCountries();
        }

        private void textDuration_TextChanged(object sender, EventArgs e)
        {
            ShowEndDate();
        }

        private void dateStartDate_ValueChanged(object sender, EventArgs e)
        {
            ShowEndDate();
        }

        private void AddMobility(long actvariation,long country, bool FirstTwo) {
            var projact = Program.GData.dataProject.getProjectActivity(newData.ProjectActivity);
            var mobility = new modelMobility();
            mobility.ActivityVariation = actvariation;
            mobility.CountryOfOrigin = country;
            mobility.DistanceBand = 4;
            mobility.TravelDays = 2;
            mobility.Participants = newData.ParticipantsPerCountry;
            mobility.FewerOpportunities = newData.FewerOpportunitiePerCountry;
            mobility.GroupLeaders = newData.GTFPerCountry;
            mobility.Trainers = projact.ActivityID==1 ? 0 : 1;
            mobility.Facilitators = FirstTwo ? 1 : 0;
            mobility.Others = FirstTwo ? 1 : 0;

            Program.GData.dataActivity.Insert(mobility);
        }

        private void ibuttonMobilityAdd_Click(object sender, EventArgs e)
        {
            bool firstTwoRows = true;
            if (gridMobility.Rows.Count > 2) firstTwoRows = false;

            AddMobility(originalData.ID, Program.GData.dataLOV.getCountries.ElementAt(0).ID, firstTwoRows);
            gridMobility.LoadGrid();
        }

        private void ibuttonMobilityCopy_Click(object sender, EventArgs e)
        {
            if (gridMobility.SelectedRows.Count > 0)
            {
                long id = (long)gridMobility.SelectedRows[0].Cells["ID"].Value;
                var mobility = Program.GData.dataActivity.getMobilities.First(c => c.ID == id);
                var newmobility = new modelMobility();
                newmobility = mobility.DeepClone();
                Program.GData.dataActivity.Insert(newmobility);
                gridMobility.LoadGrid();
            }
        }

        private void ibuttonMobilityEdit_Click(object sender, EventArgs e)
        {
            if (gridMobility.SelectedRows.Count > 0)
            {
                long id = (long)gridMobility.SelectedRows[0].Cells["ID"].Value;
                EditMobility(id);
            }
        }
        private void EditMobility(long id)
        {
            //this.Cursor = Cursors.WaitCursor;
            var mobility = Program.GData.dataActivity.getMobilities.First(c => c.ID == id);
            var formedit = new formEditMobility(mobility);
            //this.Cursor = Cursors.Default;

            formedit.ShowDialog(this);

            if (formedit.savedData != null)
            {
                Program.GData.dataActivity.Update(formedit.savedData);
            }
            gridMobility.LoadGrid();
            CountTotals();
        }

        private void gridMobility_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridMobility.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            EditMobility(ID);

        }

        private void ibutonMobilityRemove_Click(object sender, EventArgs e)
        {
            if (gridMobility.SelectedRows.Count > 0)
            {
                long id = (long)gridMobility.SelectedRows[0].Cells["ID"].Value;
                var mobility = Program.GData.dataActivity.getMobilities.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove Mobility?", true, "Yes", "No") == true)
                {
                    Program.GData.dataActivity.Delete(mobility);
                    gridMobility.LoadGrid();
                }
            }
        }

        private void ibuttonActivityRefresh_Click(object sender, EventArgs e)
        {
            var orgs = (from varorgs in Program.GData.dataProject.getProjectVariationOrganizations
                        join organizations in Program.GData.dataOrganization.getOrganizations on varorgs.Organization equals organizations.ID
                        where varorgs.ProjectVariation == originalData.ProjectVariation
                        orderby varorgs.OrganizationOrder
                        select new
                      {
                          varorgs.ID,
                          country  = organizations.Country
                        });

            var prjvar = Program.GData.dataProject.getProjectVariations.First(c => c.ID == originalData.ProjectVariation);
            var org = Program.GData.dataOrganization.getOrganizations.First(c => c.ID == prjvar.ApplicantOrganization);

            AddMobility(originalData.ID, org.Country,true);
            int rows = 1;
            foreach (var organization in orgs)
            {
                AddMobility(originalData.ID, organization.country, rows>2 ? false : true);
                rows++;
            }
            SaveOrder();

            gridMobility.LoadGrid();
        }

        private void textParticipantsPerCountry_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            if (int.TryParse(textParticipantsPerCountry.Text, out tmp))
            {
                newData.ParticipantsPerCountry = tmp;
                if (tmp > 9)
                    textGroupLeadersPerCountry.Text = "2";
                else
                    textGroupLeadersPerCountry.Text = "1";
            }

            
        }

        private void textFewerOpportunitiePerCountry_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            if (int.TryParse(textFewerOpportunitiePerCountry.Text, out tmp)) newData.FewerOpportunitiePerCountry = tmp;

        }

        private int CountTotals()
        {
            var mobs = from mobilities in Program.GData.dataActivity.getMobilities.Where(c => c.ActivityVariation == originalData.ID)
                       select new {
                           mobilities.Participants,
                           mobilities.FewerOpportunities,
                           mobilities.Trainers,
                           mobilities.GroupLeaders,
                           mobilities.Facilitators,
                           mobilities.Others
                       };

            int parts = mobs.Sum(c => c.Participants);
            int fewer = mobs.Sum(c => c.FewerOpportunities);
            int trainers = mobs.Sum(c => c.Trainers);
            int gleaders = mobs.Sum(c => c.GroupLeaders);
            int facs = mobs.Sum(c => c.Facilitators);
            int others = mobs.Sum(c => c.Others);

            labelParticipantsTotal.Text = parts.ToString();
            labelFewerOpportunitiesTotal.Text = fewer.ToString();
            labelGTFTotal.Text = (trainers + gleaders + facs + others).ToString();

            return -1;
        }

        private void SaveOrder()
        {
            long projvarID = originalData.ID;
            var orgs = Program.GData.dataActivity.getMobilities.Where(c => c.ActivityVariation == projvarID).OrderBy(c => c.MobilityOrder);
            List<modelMobility> mobs = new List<modelMobility>();

            for (int n = 0; n < orgs.Count(); n++)
                mobs.Add(orgs.ElementAt(n));

            int idx = 0;
            foreach(var mob in mobs)
            {
                mob.MobilityOrder = idx;
                Program.GData.dataActivity.Update(mob, false);
                idx++;
            }
        }

        private void ibuttonMobilityUp_Click(object sender, EventArgs e)
        {
            SwitchElements(0, -1);
        }

        private void ibuttonMobilityDown_Click(object sender, EventArgs e)
        {
            SwitchElements(gridMobility.Rows.Count - 1, +1);
        }

        private void SwitchElements(int checkIndex, int switchIndex)
        {
            if (gridMobility.CurrentRow == null) return;
            if (gridMobility.CurrentRow.Index == checkIndex) return;

            long ID = long.Parse(gridMobility.Rows[gridMobility.CurrentRow.Index].Cells["ID"].Value.ToString());
            long actvarID = originalData.ID;

            var mobs = Program.GData.dataActivity.getMobilities.Where(c => c.ActivityVariation == actvarID).OrderBy(c => c.MobilityOrder);

            int foundID = -1;
            for (int idx = 0; idx < mobs.Count(); idx++)
            {
                if (mobs.ElementAt(idx).ID == ID)
                    foundID = idx;
            }

            var varorg1 = mobs.ElementAt(foundID + switchIndex);
            var varorg2 = mobs.ElementAt(foundID);
            int n = varorg1.MobilityOrder;
            varorg1.MobilityOrder = varorg2.MobilityOrder;
            varorg2.MobilityOrder = n;
            Program.GData.dataActivity.Update(varorg1, false);
            Program.GData.dataActivity.Update(varorg2, false);
            Program.GData.dataActivity.LoadMobility();

            gridMobility.LoadGrid();
        }

        private void textGroupLeadersPerCountry_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            if (int.TryParse(textGroupLeadersPerCountry.Text, out tmp)) newData.GTFPerCountry = tmp;
        }
    }
}
