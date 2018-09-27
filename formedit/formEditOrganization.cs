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
    public partial class formEditOrganization : Form
    {
        private modelOrganization originalData;
        private modelOrganization newData;
        public modelOrganization savedData;

        private int posX;
        private int posY;
        private int posW;
        private int posH;

        public formEditOrganization()
        {
            InitializeComponent();
        }

        public formEditOrganization(modelOrganization organization)
        {
            InitializeComponent();

            originalData = new modelOrganization();
            originalData = organization.DeepClone();
            newData = new modelOrganization();
            newData = organization.DeepClone();
            savedData = null;

            ShowTypeOfOrganization();
            ShowCountry();
            ShowData(originalData);

            //gridPersons.SetupLinq += GridPersons_SetupLinq;
            //gridPersons.SetupGrid += GridPersons_SetupGrid;
            //gridPersons.LoadGrid();

            //gridDescriptions.SetupLinq += GridDescriptions_SetupLinq;
            //gridDescriptions.SetupGrid += GridDescriptions_SetupGrid;
            //gridDescriptions.LoadGrid();
        }

        //private void GridDescriptions_SetupGrid()
        //{
        //    gridDescriptions.Columns["ID"].Visible = false;
        //    gridDescriptions.Columns["Organization"].Visible = false;
        //    gridDescriptions.Columns["Type"].Visible = false;
        //    gridDescriptions.Columns["Active"].Visible = false;

        //    gridDescriptions.Columns["BackgroundAndExperience"].Width = 200;
        //    gridDescriptions.Columns["BriefDescription"].Width = 200;
        //    gridDescriptions.Columns["StaffInvolved"].Width = 200;
        //    gridDescriptions.Columns["BriefActivities"].Width = 200;

        //    gridDescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //}

        //private IEnumerable<object> GridDescriptions_SetupLinq(string filter)
        //{
        //    var od = (from orgdesc in Program.GData.dataOrganization.getOrganizationDescriptions
        //                orderby orgdesc.ID
        //                where orgdesc.Organization == originalData.ID
        //                select new
        //                {
        //                    orgdesc.ID,
        //                    orgdesc.Organization,
        //                    orgdesc.Type,
        //                    orgdesc.BackgroundAndExperience,
        //                    orgdesc.BriefDescription,
        //                    orgdesc.BriefActivities,
        //                    orgdesc.StaffInvolved,
        //                    orgdesc.Active
        //                });

        //    if (od == null) return null;

        //    return od.ToArray();
        //}

        //private void GridPersons_SetupGrid()
        //{
        //    gridPersons.Columns["ID"].Visible = false;
        //    gridPersons.Columns["Organization"].Visible = false;
        //    gridPersons.Columns["Person"].Visible = false;
        //    gridPersons.Columns["Active"].Visible = false;

        //    gridPersons.Columns["LastName"].Width = 150;
        //    gridPersons.Columns["FirstName"].Width = 100;
        //    gridPersons.Columns["Telephone"].Width = 100;
        //    gridPersons.Columns["Email"].Width = 100;

        //    gridPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //}

        //private IEnumerable<object> GridPersons_SetupLinq(string filter)
        //{
        //    var pers = (from orgpersons in Program.GData.dataOrganization.getOrganizationPersons
        //                join person in Program.GData.dataPerson.getPersons on orgpersons.Person equals person.ID
        //                orderby orgpersons.ID
        //                where orgpersons.Organization == originalData.ID
        //                select new
        //                {
        //                    orgpersons.ID,
        //                    orgpersons.Organization,
        //                    orgpersons.Person,
        //                    person.LastName,
        //                    person.FirstName,
        //                    person.Telephone,
        //                    person.Email,
        //                    orgpersons.Active
        //                });

        //    if (pers == null) return null;

        //    return pers.ToArray();
        //}

        private void SetupPersonsGrid()
        {

        }

        private void ShowTypeOfOrganization()
        {
            comboTypeOfOrganization.Items.Clear();

            foreach (var org in Program.GData.dataLOV.getOrganizationTypes)
            {
                var item = comboTypeOfOrganization.Items.Add(org.OrganizationType);
            }
        }
        private void ShowCountry()
        {
            comboCountry.Items.Clear();

            foreach (var country in Program.GData.dataLOV.getCountries)
            {
                var item = comboCountry.Items.Add(country.CountryCode());
            }
        }
        private void ShowData(modelOrganization organization)
        {
            textPIC.Text = organization.PIC.ToString();
            textLegalName.Text = organization.LegalName;
            textLegalNameLatinChar.Text = organization.LegalNameLatinChar;
            textEnglishName.Text = organization.EnglishName;
            textFriendlyName.Text = organization.FriendlyName;
            textAcronym.Text = organization.Acronym;
            textLegalForm.Text = organization.LegalForm;
            textAddress.Text = organization.Address;
            textPostCode.Text = organization.PostCode;
            textCity.Text = organization.City;
            comboCountry.Text = Program.GData.dataLOV.getCountries.First(c => c.ID == organization.Country).CountryCode();
            textEmail.Text = organization.Email;
            textWebsite.Text = organization.Website;
            textPhone.Text = organization.Phone;
            comboTypeOfOrganization.Text = Program.GData.dataLOV.getOrganizationTypes.First(c => c.ID == organization.TypeOfOrganization).OrganizationType;
            checkPublicBody.Checked = organization.PublicBody;
            checkNonProfit.Checked = organization.NonProfit;
            textAccreditation.Text = organization.Accreditation;
            textFirstName.Text = organization.FirstName;
            textSurName.Text = organization.SurName;
            textGender.Text = organization.Gender;
            textRepresentativeFunction.Text = organization.RepresentativeFunction;
            textLegalStatus.Text = organization.LegalStatus;
            textRegistrationNumber.Text = organization.RegistrationNumber;
            textVAT.Text = organization.VAT;
            htmlGeneralDescription.InnerHtml = organization.GeneralDescription;
            htmlDescription.InnerHtml = organization.Description;
            htmlActivities.InnerHtml = organization.Activities;
            htmlKeyStaff.InnerHtml = organization.KeyStaff;
            textContractNumber.Text = organization.ContractNumber;
        }
        private void GetData(ref modelOrganization organization)
        {
            int pic;
            if (int.TryParse(textPIC.Text, out pic))
                organization.PIC = pic;

            organization.LegalName = textLegalName.Text;
            organization.LegalNameLatinChar = textLegalNameLatinChar.Text;
            organization.EnglishName = textEnglishName.Text;
            organization.FriendlyName = textFriendlyName.Text;
            organization.Acronym = textAcronym.Text;
            organization.LegalForm = textLegalForm.Text;
            organization.Address = textAddress.Text;
            organization.PostCode = textPostCode.Text;
            organization.City = textCity.Text;
            organization.Country = Program.GData.dataLOV.getCountries.First(c => c.CountryCode() == comboCountry.Text).ID;
            organization.Email = textEmail.Text;
            organization.Website = textWebsite.Text;
            organization.Phone = textPhone.Text;
            organization.TypeOfOrganization = Program.GData.dataLOV.getOrganizationTypes.First(c => c.OrganizationType == comboTypeOfOrganization.Text).ID;
            organization.PublicBody = checkPublicBody.Checked;
            organization.NonProfit = checkNonProfit.Checked;
            organization.Accreditation = textAccreditation.Text;
            organization.FirstName = textFirstName.Text;
            organization.SurName = textSurName.Text;
            organization.Gender = textGender.Text;
            organization.RepresentativeFunction = textRepresentativeFunction.Text;
            organization.LegalStatus = textLegalStatus.Text;
            organization.RegistrationNumber = textRegistrationNumber.Text;
            organization.VAT = textVAT.Text;
            organization.GeneralDescription = htmlGeneralDescription.InnerHtml;
            organization.Description = htmlDescription.InnerHtml;
            organization.Activities = htmlActivities.InnerHtml;
            organization.KeyStaff = htmlKeyStaff.InnerHtml;
            organization.ContractNumber = textContractNumber.Text;
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            if(!Program.Compare<modelOrganization>(originalData, newData))
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

            savedData = new modelOrganization();
            savedData = newData.DeepClone();
            this.Hide();
        }

        private void ShowAllEditors(bool visibility)
        {
            UserControl[] panels = { htmlGeneralDescription, htmlDescription, htmlActivities, htmlKeyStaff};

            foreach (var panel in panels)
                panel.Visible = visibility;
        }
        private void MaximizeHTML(MSDN.Html.Editor.HtmlEditorControl editor,IconButton buttonMax, IconButton buttonMin)
        {
            buttonMax.Visible = false;
            buttonMin.Visible = true;

            ShowAllEditors(false);

            posX = editor.Left;
            posY = editor.Top;
            posW = editor.Width;
            posH = editor.Height;

            editor.Left = 545;
            editor.Top = 337;
            editor.Height = 313;

            editor.ToolbarVisible = true;
            editor.Visible = true;
        }
        private void MinimizeHTML(MSDN.Html.Editor.HtmlEditorControl editor, IconButton buttonMax, IconButton buttonMin)
        {
            buttonMax.Visible = true;
            buttonMin.Visible = false;

            editor.Left = posX;
            editor.Top = posY;
            editor.Height = posH;

            ShowAllEditors(true);

            editor.ToolbarVisible = false;
        }

        private void ibuttonMaximizeGeneralDescription_Click(object sender, EventArgs e)
        {
            MaximizeHTML(htmlGeneralDescription, ibuttonMaximizeGeneralDescription, ibuttonClosGeneralDescription);
        }
        private void ibuttonClosGeneralDescription_Click(object sender, EventArgs e)
        {
            MinimizeHTML(htmlGeneralDescription, ibuttonMaximizeGeneralDescription, ibuttonClosGeneralDescription);
        }

        private void ibuttonMaximizeDescription_Click(object sender, EventArgs e)
        {
            MaximizeHTML(htmlDescription, ibuttonMaximizeDescription, ibuttonMinimizeDescription);
        }
        private void ibuttonMinimizeDescription_Click(object sender, EventArgs e)
        {
            MinimizeHTML(htmlDescription, ibuttonMaximizeDescription, ibuttonMinimizeDescription);
        }
        private void ibuttonMaximizeActivities_Click(object sender, EventArgs e)
        {
            MaximizeHTML(htmlActivities, ibuttonMaximizeActivities, ibuttonMinimizeActivities);
        }
        private void ibuttonMinimizeActivities_Click(object sender, EventArgs e)
        {
            MinimizeHTML(htmlActivities, ibuttonMaximizeActivities, ibuttonMinimizeActivities);
        }
        private void ibuttonMaximizeKeyStaff_Click(object sender, EventArgs e)
        {
            MaximizeHTML(htmlKeyStaff, ibuttonMaximizeKeyStaff, ibuttonMinimizeKeyStaff);
        }
        private void ibuttonMinimizeKeyStaff_Click(object sender, EventArgs e)
        {
            MinimizeHTML(htmlKeyStaff, ibuttonMaximizeKeyStaff, ibuttonMinimizeKeyStaff);
        }

        private void ibuttonPersonAdd_Click(object sender, EventArgs e)
        {
            //int id = Program.SelectPerson();
            //if (id == -1) return;

            //var op = new modelOrganizationPerson();
            //op.Active = true;
            //op.Organization = originalData.ID;
            //op.Person = id;

            //Program.GData.dataOrganization.Insert(op);
            //gridPersons.LoadGrid();
        }

        private void ibuttonPersonRemove_Click(object sender, EventArgs e)
        {
            //if (gridPersons.SelectedRows.Count > 0)
            //{
            //    int id = (int)gridPersons.SelectedRows[0].Cells["ID"].Value;
            //    var orgperson = Program.GData.dataOrganization.getOrganizationPersons.First(c => c.ID == id);
            //    if(Program.ShowMessageBox("Do you really want to remove Organization-Person?",true,"Yes","No")== true)
            //    {
            //        Program.GData.dataOrganization.Delete(orgperson);
            //        gridPersons.LoadGrid();
            //    }
            //}

        }

        private void ibuttonDescriptionAdd_Click(object sender, EventArgs e)
        {
            //var orgdesc = new modelOrganizationDescription();
            //orgdesc.Active = true;
            //orgdesc.Organization = originalData.ID;
            //orgdesc.Type = originalData.TypeOfOrganization;

            //Program.GData.dataOrganization.Insert(orgdesc);

            //gridDescriptions.LoadGrid();
        }

        private void ibuttonDescriptionRemove_Click(object sender, EventArgs e)
        {
            //if (gridDescriptions.SelectedRows.Count > 0)
            //{
            //    int id = (int)gridDescriptions.SelectedRows[0].Cells["ID"].Value;
            //    var orgdesc = Program.GData.dataOrganization.getOrganizationDescriptions.First(c => c.ID == id);
            //    if (Program.ShowMessageBox("Do you really want to remove Organization-Description?",true, "Yes", "No") == true)
            //    {
            //        Program.GData.dataOrganization.Delete(orgdesc);
            //        gridDescriptions.LoadGrid();
            //    }
            //}

        }

        private void ibuttonDescriptionEdit_Click(object sender, EventArgs e)
        {
            //if (gridDescriptions.SelectedRows.Count > 0)
            //{
            //    int id = (int)gridDescriptions.SelectedRows[0].Cells["ID"].Value;
            //    var orgdesc = Program.GData.dataOrganization.getOrganizationDescriptions.First(c => c.ID == id);
            //    var formedit = new formEditOrganizationDescription(orgdesc);
            //    formedit.ShowDialog();

            //    if (formedit.savedData != null)
            //    {
            //        Program.GData.dataOrganization.Update(formedit.savedData);
            //    }
            //    gridDescriptions.LoadGrid();
            //}
        }
    }
}
