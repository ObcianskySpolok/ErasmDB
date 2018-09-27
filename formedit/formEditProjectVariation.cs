using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSWord = Microsoft.Office.Interop.Word;


namespace erasmDB.formedit
{
    public partial class formEditProjectVariation : Form
    {
        private modelProjectVariation originalData;
        private modelProjectVariation newData;
        public modelProjectVariation savedData;

        public formEditProjectVariation()
        {
            InitializeComponent();
            PrepareCallCombo();
        }

        public formEditProjectVariation(modelProjectVariation projectVariation)
        {
            InitializeComponent();

            PrepareCallCombo();

            originalData = new modelProjectVariation();
            originalData = projectVariation.DeepClone();
            newData = new modelProjectVariation();
            newData = projectVariation.DeepClone();
            savedData = null;

            ShowLanguages();
            ShowNationalAgency();
            ShowStatuses();

            ShowData(originalData);

            gridOrganizations.SetupLinq += GridOrganizations_SetupLinq;
            gridOrganizations.SetupGrid += GridOrganizations_SetupGrid;
            gridOrganizations.LoadGrid();

            gridActivities.SetupLinq += GridActivities_SetupLinq;
            gridActivities.SetupGrid += GridActivities_SetupGrid;
            gridActivities.LoadGrid();
        }

        private void GridActivities_SetupGrid()
        {
            var fntHeadline = new Font("Segoe UI Light", 14);
            var fntNormal = new Font("Segoe UI Light", 12);
            var fntSmaller = new Font("Segoe UI Light", 10);

            gridActivities.ColumnHeadersDefaultCellStyle.Font = fntHeadline;
            gridActivities.DefaultCellStyle.Font = fntNormal;

            gridActivities.Columns["ActivityType"].DefaultCellStyle.Font = fntSmaller;
            gridActivities.Columns["Dest"].DefaultCellStyle.Font = fntSmaller;

            gridActivities.Columns["ID"].Visible = false;

            //gridActivities.Columns["ActivityNo"].Width = 90;
            //gridActivities.Columns["ActivityTitle"].Width = 250;
            gridActivities.Columns["ActivityType"].Width = 150;
            gridActivities.Columns["Dest"].Width = 120;
            gridActivities.Columns["StartDate"].Width = 100;
            gridActivities.Columns["Duration"].Width = 80;

            gridActivities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private IEnumerable<object> GridActivities_SetupLinq(string filter)
        {
            var activities = from projacts in Program.GData.dataProject.getProjectActivities
                            join acts in Program.GData.dataActivity.getActivityTypes on projacts.ActivityID equals acts.ID
                       select new
                       {
                           projacts.ID,
                           acts.ActivityType
                       };
            // var orgs = Program.GData.dataProject.getProjectVariationOrganizations.Where(c => c.ProjectVariation == projvarID).OrderBy(c => c.OrganizationOrder);
            var od = (from actvars in Program.GData.dataProject.getProjectActivityVariations
                      join acts in activities on actvars.ProjectActivity equals acts.ID
                      join countryDEST in Program.GData.dataLOV.getCountries on actvars.CountryOfDestination equals countryDEST.ID
                      orderby actvars.ID descending
                      where actvars.ProjectVariation == originalData.ID
                      select new
                      {
                          actvars.ID,
                          acts.ActivityType,
                          Dest = countryDEST.CountryCode(),
                          StartDate = actvars.StartDate.ToShortDateString(),
                          actvars.Duration,
                          actvars.OrgSupport,
                          actvars.Travel
                      });

            if (od == null) return null;

            return od.ToArray();
        }
        private void GridOrganizations_SetupGrid()
        {
            var fntHeadline = new Font("Segoe UI Light", 14);
            var fntNormal = new Font("Segoe UI Light", 12);
            var fntSmaller = new Font("Segoe UI Light", 10);

            gridOrganizations.ColumnHeadersDefaultCellStyle.Font = fntHeadline;
            gridOrganizations.DefaultCellStyle.Font = fntNormal;

            gridOrganizations.Columns["Address"].DefaultCellStyle.Font = fntSmaller;
            gridOrganizations.Columns["City"].DefaultCellStyle.Font = fntSmaller;
            gridOrganizations.Columns["Country"].DefaultCellStyle.Font = fntSmaller;

            gridOrganizations.Columns["ID"].Visible = false;
            //gridOrganizations.Columns["OrganizationOrder"].Visible = false;

            gridOrganizations.Columns["LegalName"].Width = 250;
            gridOrganizations.Columns["Address"].Width = 250;
            gridOrganizations.Columns["City"].Width = 100;
            gridOrganizations.Columns["Country"].Width = 100;
            gridOrganizations.Columns["Code"].Width = 80;
            gridOrganizations.Columns["OrganizationOrder"].Width = 50;

            gridOrganizations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private IEnumerable<object> GridOrganizations_SetupLinq(string filter)
        {
            var orgs = from organizations in Program.GData.dataOrganization.getOrganizations
                       join countries in Program.GData.dataLOV.getCountries on organizations.Country equals countries.ID
                       select new
                       {
                           organizations.ID,
                           organizations.LegalName,
                           organizations.Address,
                           organizations.City,
                           countries.Country,
                           countries.Code
                       };

            var od = (from projvarorgs in Program.GData.dataProject.getProjectVariationOrganizations
                      join organization in orgs on projvarorgs.Organization equals organization.ID
                      orderby projvarorgs.OrganizationOrder
                      where projvarorgs.ProjectVariation == originalData.ID
                      select new
                      {
                          projvarorgs.ID,
                          organization.LegalName,
                          organization.Address,
                          organization.City,
                          organization.Country,
                          organization.Code,
                          projvarorgs.OrganizationOrder
                      });

            if (od == null) return null;

            return od.ToArray();
        }
        private void GridTopics_SetupGrid()
        {
            throw new NotImplementedException();
        }
        private IEnumerable<object> GridTopics_SetupLinq(string filter)
        {
            throw new NotImplementedException();
        }

        private void ShowData(modelProjectVariation projectVariation)
        {
            labelProject.Text = Program.GData.dataProject.getProjects.First(c => c.ID == projectVariation.ProjectID).Title;
            labelApplicant.Text = Program.GData.dataOrganization.getOrganizations.First(c => c.ID == projectVariation.ApplicantOrganization).LegalName;
            
            comboLanguage.Text = Program.GData.dataLOV.getLanguages.First(c => c.ID == projectVariation.Language).Language;
            comboNationalAgency.Text = Program.GData.dataLOV.getNationalAgencies.First(c => c.ID == projectVariation.NationalAgency).AgencyName;
            comboStatus.Text = projectVariation.Status;
            dateStartDate.Value = projectVariation.StartDate;
            dateEndDate.Value = projectVariation.EndDate;

            comboCall.Text = projectVariation.Call;
            textTitle.Text = projectVariation.Title;
            textAcronym.Text = projectVariation.Acronym;
            textDuration.Text = projectVariation.Duration.ToString();
            textCode.Text = projectVariation.Code;
            textPhase.Text = projectVariation.Phase;

            textCustomVariable1.Text = projectVariation.CustomVariable1;
            textCustomVariable2.Text = projectVariation.CustomVariable2;
            textCustomVariable3.Text = projectVariation.CustomVariable3;
            textCustomVariable4.Text = projectVariation.CustomVariable4;

        }

        private void PrepareCallCombo()
        {
            int y = DateTime.Now.Year;
            comboCall.Items.Clear();

            foreach(var call in Program.GData.projectCalls)
            {
                comboCall.Items.Add(call.Call);
            }
        }
        private void GetData(ref modelProjectVariation projectVariation)
        {
            projectVariation.Language = Program.GData.dataLOV.getLanguages.First(c => c.Language == comboLanguage.Text).ID;
            projectVariation.NationalAgency = Program.GData.dataLOV.getNationalAgencies.First(c => c.AgencyName == comboNationalAgency.Text).ID;

            projectVariation.StartDate = dateStartDate.Value;
            projectVariation.Duration = 1;
            int duration;
            if (int.TryParse(textDuration.Text, out duration))
                projectVariation.Duration = duration;
            projectVariation.EndDate = projectVariation.StartDate.AddMonths(duration);

            projectVariation.Call = comboCall.Text;
            projectVariation.Title = textTitle.Text;
            projectVariation.Acronym = textAcronym.Text;
            projectVariation.Code = textCode.Text;
            projectVariation.Phase = textPhase.Text;

            projectVariation.Status = comboStatus.Text;

            projectVariation.CustomVariable1 = textCustomVariable1.Text;
            projectVariation.CustomVariable2 = textCustomVariable2.Text;
            projectVariation.CustomVariable3 = textCustomVariable3.Text;
            projectVariation.CustomVariable4 = textCustomVariable4.Text;
        }

        private void ShowStatuses()
        {
            comboStatus.Items.Clear();
            comboStatus.Items.Add("passed");
            comboStatus.Items.Add("applied");
            comboStatus.Items.Add("rejected");
            comboStatus.Items.Add("waiting list");
        }
        private void ShowLanguages()
        {
            comboLanguage.Items.Clear();

            foreach (var lng in Program.GData.dataLOV.getLanguages)
            {
                var item = comboLanguage.Items.Add(lng.Language);
            }
        }
        private void ShowNationalAgency()
        {
            comboNationalAgency.Items.Clear();

            foreach (var ag in Program.GData.dataLOV.getNationalAgencies)
            {
                var item = comboNationalAgency.Items.Add(ag.AgencyName);
            }
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            if(!Program.Compare<modelProjectVariation>(originalData, newData))
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
            savedData = new modelProjectVariation();
            savedData = newData.DeepClone();
            this.Hide();
        }

        private void ibuttonLookupApplicant_Click(object sender, EventArgs e)
        {
            var ids = Program.SelectOrganization();
            if (ids.Count == 0) return;

            newData.ApplicantOrganization = ids.ElementAt(0);

            var org = Program.GData.dataOrganization.getOrganizations.First(c => c.ID == newData.ApplicantOrganization);
            var country = Program.GData.dataLOV.getCountries.First(c => c.ID == org.Country);

            labelApplicant.Text = org.LegalName;
            comboNationalAgency.Text = Program.GData.dataLOV.getNationalAgencies.Where(c=>c.Country == country.ID).First().AgencyName;
        }

        private void ShowEndDate()
        {
            int duration;
            if (int.TryParse(textDuration.Text, out duration))
            {
                dateEndDate.Value = dateStartDate.Value.AddMonths(duration).AddDays(-1);
            }
        }
        private void dateStartDate_ValueChanged(object sender, EventArgs e)
        {
            ShowEndDate();
        }

        private void textDuration_TextChanged(object sender, EventArgs e)
        {
            ShowEndDate();
        }

        private void ibuttonOrganizationAdd_Click(object sender, EventArgs e)
        {
            var ids = Program.SelectOrganization();
            if (ids.Count() == 0) return;

            foreach(int id in ids)
            {
                var pvo = new modelProjectVariationOrganization();
                pvo.Active = true;
                pvo.ProjectVariation = originalData.ID;
                pvo.Organization = id;

                Program.GData.dataProject.Insert(pvo);
            }
            CreateOrder();

            gridOrganizations.LoadGrid();
        }

        private void ibuttonOrganizationRemove_Click(object sender, EventArgs e)
        {
            if (gridOrganizations.SelectedRows.Count > 0)
            {
                long id = (long)gridOrganizations.SelectedRows[0].Cells["ID"].Value;
                var projectOrg = Program.GData.dataProject.getProjectVariationOrganizations.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove Project - Variation - Organization?", true, "Yes", "No") == true)
                {
                    Program.GData.dataProject.Delete(projectOrg);
                    gridOrganizations.LoadGrid();
                }
            }
        }

        private void ibuttonActivityRefresh_Click(object sender, EventArgs e)
        {
            var projectActivities = Program.GData.dataProject.getProjectActivities.Where(c => c.ProjectID == originalData.ProjectID);
            //var variationActivities = Program.GData.dataProject.getProjectActivityVariations.Where(c => c.ProjectVariation == originalData.ID);

            foreach( var activity in projectActivities)
            {
                if (Program.GData.dataProject.getProjectActivityVariations.Count(c => c.ProjectVariation == newData.ID) == 0)
                {
                    var org = Program.GData.dataOrganization.getOrganization(newData.ApplicantOrganization);
                    var country = Program.GData.dataLOV.getCountry(org.Country);

                    var va = new modelProjectActivityVariation();
                    va.ProjectVariation = originalData.ID;
                    va.ProjectActivity = activity.ID;
                    va.CountryOfDestination = org.Country;
                    if (country.Code == "CZ")
                    {
                        va.CityOfDestination = "Velke Pavlovice";
                        va.StudyVisit = "Brno";
                    } else if(country.Code == "CZ")
                    {
                        va.CityOfDestination = "Pocuvadlianske jazero";
                        va.StudyVisit = "Banska Stiavnica";
                    }
                    else if (country.Code == "AT")
                    {
                        va.CityOfDestination = "Wagrain";
                        va.StudyVisit = "Salzburg";
                    }
                    else if (country.Code == "LT")
                    {
                        va.CityOfDestination = "Moletai";
                        va.StudyVisit = "Vilnius";
                    }
                    else
                    {
                        va.CityOfDestination = "";
                        va.StudyVisit = "";
                    }

                    va.StartDate = DateTime.Now;
                    va.EndDate = DateTime.Now.AddDays(activity.Duration);
                    va.Duration = activity.Duration;
                    va.PeriodDates = "";
                    va.ParticipantsPerCountry = 0;
                    va.ParticipantsTotal = 0;
                    va.FewerOpportunitiePerCountry = 0;
                    va.FewerOpportunitieTotal = 0;
                    va.GTFPerCountry = 0;
                    va.GTFTotal = 0;

                    Program.GData.dataProject.Insert(va);
                }
            }
            gridActivities.LoadGrid();
        }

        private void ibuttonActivityEdit_Click(object sender, EventArgs e)
        {
            if (gridActivities.SelectedRows.Count > 0)
            {
                long id = (long)gridActivities.SelectedRows[0].Cells["ID"].Value;
                EditProjectVariationActivities(id);
            }
        }

        private void EditProjectVariationActivities(long ID)
        {
            //this.Cursor = Cursors.WaitCursor;
            var activityVariation = Program.GData.dataProject.getProjectActivityVariations.First(c => c.ID == ID);
            var formedit = new formEditProjectActivityVariation(activityVariation);
            //this.Cursor = Cursors.Default;

            formedit.ShowDialog(this);

            if (formedit.savedData != null)
            {
                Program.GData.dataProject.Update(formedit.savedData);
            }
            gridActivities.LoadGrid();

        }

        private void gridActivities_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridActivities.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            EditProjectVariationActivities(ID);
        }

        private void iButtonMandate_Click(object sender, EventArgs e)
        {
            var prj = Program.GData.dataProject.getProjects.First(c => c.ID == newData.ProjectID);

            var frm = new formMandate(newData);
            frm.ShowDialog();
        }

        private void iconDefineTemplate_Click(object sender, EventArgs e)
        {
            this.Hide();
            var project = Program.GData.dataProject.getProject(originalData.ProjectID);
            var frm = new formWordTemplateEdit(project);
            //var projvar = originalData;
            //modelOrganization applicant = Program.GData.dataOrganization.getOrganizations.First(c => c.ID == projvar.ApplicantOrganization);
            //var partners = Program.GData.dataProject.getProjectVariationOrganizations.Where(c => c.ProjectVariation == projvar.ID);
            //modelOrganization partner = Program.GData.dataOrganization.getOrganizations.First(c => c.ID == partners.ElementAt(0).Organization);
            //var agency = Program.GData.dataLOV.getNationalAgencies.First(c => c.ID == projvar.NationalAgency);

            //var frm = new formWordTemplateEdit(newData, applicant, partner, agency);

            frm.ShowDialog();

            this.Show();
        }

        private void CreateOrder()
        {
            long projvarID = originalData.ID;
            var orgs = Program.GData.dataProject.getProjectVariationOrganizations.Where(c => c.ProjectVariation == projvarID).OrderBy(c => c.OrganizationOrder);
            for (int n = 0; n < orgs.Count(); n++)
            {
                var varorg = orgs.ElementAt(n);
                varorg.OrganizationOrder = n;
            }
        }

        private void SaveOrder()
        {
            long projvarID = originalData.ID;
            var orgs = Program.GData.dataProject.getProjectVariationOrganizations.Where(c => c.ProjectVariation == projvarID).OrderBy(c => c.OrganizationOrder);
            for (int n = 0; n < orgs.Count(); n++)
            {
                var varorg = orgs.ElementAt(n);
                varorg.OrganizationOrder = n;
                Program.GData.dataProject.Update(varorg);
            }
        }

        private void ibuttonOrganizationUp_Click(object sender, EventArgs e)
        {
            SwitchElements(0,-1);
        }

        private void ibuttonOrganizationDown_Click(object sender, EventArgs e)
        {
            SwitchElements(gridOrganizations.Rows.Count-1,+1);
        }

        private void SwitchElements(int checkIndex, int switchIndex)
        {
            if (gridOrganizations.CurrentRow == null) return;
            if (gridOrganizations.CurrentRow.Index == checkIndex) return;

            long ID = long.Parse(gridOrganizations.Rows[gridOrganizations.CurrentRow.Index].Cells["ID"].Value.ToString());
            long projvarID = originalData.ID;

            var orgs = Program.GData.dataProject.getProjectVariationOrganizations.Where(c => c.ProjectVariation == projvarID).OrderBy(c => c.OrganizationOrder);

            int foundID = -1;
            for (int idx = 0; idx < orgs.Count(); idx++)
            {
                if (orgs.ElementAt(idx).ID == ID)
                    foundID = idx;
            }

            var varorg1 = orgs.ElementAt(foundID + switchIndex);
            var varorg2 = orgs.ElementAt(foundID);
            int n = varorg1.OrganizationOrder;
            varorg1.OrganizationOrder = varorg2.OrganizationOrder;
            varorg2.OrganizationOrder = n;
            Program.GData.dataProject.Update(varorg1,false);
            Program.GData.dataProject.Update(varorg2,false);
            Program.GData.dataProject.LoadProjectVariationOrganizations();

            gridOrganizations.LoadGrid();
        }

        private void ibuttonActivityVariationRemove_Click(object sender, EventArgs e)
        {
            if (gridActivities.SelectedRows.Count > 0)
            {
                long id = (long)gridActivities.SelectedRows[0].Cells["ID"].Value;
                var activityVariation = Program.GData.dataProject.getProjectActivityVariations.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove Project - Variation - Activity?", true, "Yes", "No") == true)
                {
                    Program.GData.dataProject.Delete(activityVariation);
                    gridActivities.LoadGrid();
                }
            }

        }

        private void comboCall_Click(object sender, EventArgs e)
        {

        }

        private void comboCall_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.GData.projectCalls.Count(c => c.Call == comboCall.Text) == 0) return;
            var call = Program.GData.projectCalls.First(c => c.Call == comboCall.Text);
            dateStartDate.Value = call.Date.Date;
        }

    }
}
