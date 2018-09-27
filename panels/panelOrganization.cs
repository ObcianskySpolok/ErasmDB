using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace erasmDB.panels
{
    public partial class panelOrganization : UserControl
    {
        public panelOrganization()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            gridData.RowTemplate.Height = 30;
            gridData.SetupLinq += GridData_SetupLinq;
            gridData.SetupGrid += GridData_SetupGrid;
            gridData.LoadGrid();
        }

        private void SelectRow(long id)
        {
            DataGridViewRow row;
            try
            {
                row = gridData.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["ID"].Value.Equals(id))
                    .First();

                foreach (DataGridViewRow rw in this.gridData.SelectedRows)
                    rw.Selected = false;

                gridData.FirstDisplayedScrollingRowIndex = row.Index;
                row.Selected = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void GridData_SetupGrid()
        {
            var fntHeadline = new Font("Segoe UI Light", 20);
            var fntBold = new Font("Segoe UI Light", 16,FontStyle.Bold);
            var fntNormal = new Font("Segoe UI Light", 16);
            var fntSmaller = new Font("Segoe UI Light", 12);

            gridData.ColumnHeadersDefaultCellStyle.Font = fntHeadline;
            gridData.DefaultCellStyle.Font = fntSmaller;

            gridData.Columns["LegalName"].DefaultCellStyle.Font = fntBold;
            gridData.Columns["PIC"].DefaultCellStyle.Font = fntSmaller;
            gridData.Columns["Acronym"].DefaultCellStyle.Font = fntNormal;
            gridData.Columns["Address"].DefaultCellStyle.Font = fntNormal;


            gridData.Columns["ID"].Visible = false;
            gridData.Columns["Active"].Visible = false;
            gridData.Columns["LegalNameLatinChar"].Visible = false;
            gridData.Columns["EnglishName"].Visible = false;
            gridData.Columns["FriendlyName"].Visible = false;
            gridData.Columns["GeneralDescription"].Visible = false;
            gridData.Columns["Description"].Visible = false;
            gridData.Columns["Activities"].Visible = false;
            gridData.Columns["ContractNumber"].Visible = false;

            gridData.Columns["PIC"].Width = 100;
            gridData.Columns["LegalName"].Width = 400;
            gridData.Columns["LegalNameLatinChar"].Width = 150;
            gridData.Columns["EnglishName"].Width = 150;
            gridData.Columns["FriendlyName"].Width = 150;
            gridData.Columns["Acronym"].Width = 150;
            gridData.Columns["LegalForm"].Width = 150;
            gridData.Columns["Address"].Width = 200;
            gridData.Columns["PostCode"].Width = 100;
            gridData.Columns["City"].Width = 200;
            gridData.Columns["Code"].Width = 100;
            gridData.Columns["Country"].Width = 200;
            gridData.Columns["Email"].Width = 200;
            gridData.Columns["Website"].Width = 200;
            gridData.Columns["Phone"].Width = 200;
            gridData.Columns["OrganizationType"].Width = 200;
            gridData.Columns["PublicBody"].Width = 70;
            gridData.Columns["NonProfit"].Width = 70;
            gridData.Columns["Accreditation"].Width = 200;
            gridData.Columns["FirstName"].Width = 200;
            gridData.Columns["SurName"].Width = 200;
            gridData.Columns["Gender"].Width = 200;
            gridData.Columns["RepresentativeFunction"].Width = 200;
            gridData.Columns["LegalStatus"].Width = 200;
            gridData.Columns["RegistrationNumber"].Width = 200;
            gridData.Columns["VAT"].Width = 200;
            gridData.Columns["GeneralDescription"].Width = 200;
            gridData.Columns["Description"].Width = 200;
            gridData.Columns["Activities"].Width = 200;
            gridData.Columns["KeyStaff"].Width = 200;
            gridData.Columns["ContractNumber"].Width = 200;

            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private IEnumerable<object> GridData_SetupLinq(string filter)
        {
            var pers = (from organizations in Program.GData.dataOrganization.getOrganizations
                        join types in Program.GData.dataLOV.getOrganizationTypes on organizations.TypeOfOrganization equals types.ID
                        join countries in Program.GData.dataLOV.getCountries on organizations.Country equals countries.ID
                        orderby organizations.ID
                        select new
                        {
                            organizations.ID,
                            organizations.PIC,
                            organizations.LegalName,
                            organizations.Acronym,
                            organizations.LegalNameLatinChar,
                            organizations.EnglishName,
                            organizations.FriendlyName,
                            organizations.LegalForm,
                            organizations.Address,
                            organizations.PostCode,
                            organizations.City,
                            countries.Code,
                            countries.Country,
                            organizations.Email,
                            organizations.Website,
                            organizations.Phone,
                            types.OrganizationType,
                            organizations.PublicBody,
                            organizations.NonProfit,
                            organizations.Accreditation,
                            organizations.FirstName,
                            organizations.SurName,
                            organizations.Gender,
                            organizations.RepresentativeFunction,
                            organizations.LegalStatus,
                            organizations.RegistrationNumber,
                            organizations.VAT,
                            organizations.GeneralDescription,
                            organizations.Description,
                            organizations.Activities,
                            organizations.KeyStaff,
                            organizations.ContractNumber,                            
                            organizations.Active
                        }).ToList();

            if (pers == null) return null;

            var filterUp = filter.ToUpper();
            var dataFiltered = (filter == "")
                ? pers
                : pers.Where(c => (
                                            c.FirstName.ToString().ToUpper().Contains(filterUp) ||
                                            c.SurName.ToString().ToUpper().Contains(filterUp) ||
                                            c.Email.ToString().ToUpper().Contains(filterUp) ||
                                            c.EnglishName.ToString().ToUpper().Contains(filterUp)
                                       )
                                 );

            return dataFiltered.ToArray();

        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridData.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            EditOrganization(ID);
        }

        private void EditOrganization(long ID)
        {
            //this.Cursor = Cursors.WaitCursor;
            var frmEditOrg = new formedit.formEditOrganization(Program.GData.dataOrganization.getOrganizations.First(c => c.ID == ID));
            //this.Cursor = Cursors.Default;
            frmEditOrg.ShowDialog(this);

            if (frmEditOrg.savedData != null)
            {
                Program.GData.dataOrganization.Update(frmEditOrg.savedData);
            }

            gridData.LoadGrid();
            SelectRow(ID);
        }

        private void ibuttonOrganizationEdit_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                EditOrganization(id);
            }
        }

        private void ibuttonOrganizationRemove_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                var organization = Program.GData.dataOrganization.getOrganizations.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove organzation?", true, "Yes", "No") == true)
                {
                    Program.GData.dataOrganization.Delete(organization);
                    gridData.LoadGrid();
                }
            }

        }

        private void ibuttonOrganizationAdd_Click(object sender, EventArgs e)
        {
            var organization = new modelOrganization();
            organization.CreateNewEmpty();

            Program.GData.dataOrganization.Insert(organization);
            gridData.LoadGrid();
        }

        private MSExcel.Workbook FindWorkbook(MSExcel.Application exApp,string fname)
        {
            MSExcel.Workbook wbook = null;
            foreach (MSExcel.Workbook wb in exApp.Workbooks)
            {
                if ((wb.Name).ToUpper() == fname.ToUpper())
                    wbook = wb;
            }
            return wbook;
        }


        private void ibuttonImport_Click(object sender, EventArgs e)
        {
            MSExcel.Application exApp;

            string fname = @"Partners.V15.xlsx";
            string sheet = "Hárok1";
            exApp = (MSExcel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");

            object missing = System.Reflection.Missing.Value;
            if(exApp == null)
                exApp = new MSExcel.Application();
            if (FindWorkbook(exApp, fname) == null)
            {
                exApp.Workbooks.Open(fname, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            }

            exApp.Visible = true;

            MSExcel.Workbook wbook = FindWorkbook(exApp, fname);
            if (wbook == null) return;

            MSExcel.Worksheet ws = (MSExcel.Worksheet)wbook.Sheets[sheet];
            Program.GData.dataOrganization.getOrganizations.ForEach(c => {
                c.Active = false;
                Program.GData.dataOrganization.Update(c,false);
                });

            for (int row=2; row<200; row++)
            {
                var org = GetOrganization(ws, row);
                if (org == null)
                {
                    break;
                }
                if(Program.GData.dataOrganization.getOrganizations.Count(c => c.PIC == org.PIC) == 0)
                {
                    org.Active = true;
                    Program.GData.dataOrganization.Insert(org);
                }
                else
                {
                    var orgold = Program.GData.dataOrganization.getOrganizations.First(c => c.PIC == org.PIC);
                    org.ID = orgold.ID;
                    org.Active = true;
                    Program.GData.dataOrganization.Update(org);
                }

            }
        }

        private modelOrganization GetOrganization(MSExcel.Worksheet ws, int row)
        {
            string pic = ws.Cells[row, 1].Text;
            if (pic == "") return null;

            string partnername = ws.Cells[row, 2].Text;
            string acronym = ws.Cells[row, 3].Text;
            string country = ws.Cells[row, 4].Text;
            string representative_firstname = ws.Cells[row, 5].Text;
            string representative_surname = ws.Cells[row, 6].Text;
            string representative_gender = ws.Cells[row, 7].Text;
            string representative_function = ws.Cells[row, 8].Text;
            string legal_status = ws.Cells[row, 9].Text;
            string regno = ws.Cells[row, 10].Text;
            string address = ws.Cells[row, 11].Text;
            string zip = ws.Cells[row, 12].Text;
            string city = ws.Cells[row, 13].Text;
            string vat = ws.Cells[row, 14].Text;
            string email = ws.Cells[row, 15].Text;
            string phone = ws.Cells[row, 16].Text;
            string partner_type = ws.Cells[row, 17].Text;
            string partner_description = ws.Cells[row, 18].Text;
            string org_description = ws.Cells[row, 19].Text;
            string activities = ws.Cells[row, 20].Text;
            string keystaff = ws.Cells[row, 21].Text;
            string contractnum = ws.Cells[row, 22].Text;
            var organization = new modelOrganization();

            if (int.TryParse(pic, out int pc))
                organization.PIC = pc;

            organization.LegalName = partnername;
            organization.LegalNameLatinChar = "";
            organization.EnglishName = "";
            organization.FriendlyName = partnername;
            organization.Acronym = acronym;
            organization.LegalForm = legal_status;
            organization.Address = address;
            organization.PostCode = zip;
            organization.City = city;
            organization.Country = Program.GData.dataLOV.getCountries.First(c => c.Country == country).ID;
            organization.Email = email;
            organization.Website = "";
            organization.Phone = phone;
            organization.TypeOfOrganization = 1;
            organization.PublicBody = false;
            organization.NonProfit = false;
            organization.Accreditation = "";
            organization.FirstName = representative_firstname;
            organization.SurName = representative_surname;
            organization.Gender = representative_gender;
            organization.RepresentativeFunction = representative_function;
            organization.LegalStatus = legal_status;
            organization.RegistrationNumber = regno;
            organization.VAT = vat;
            organization.GeneralDescription = partner_description;
            organization.Description = org_description;
            organization.Activities = activities;
            organization.KeyStaff = keystaff;
            organization.ContractNumber = contractnum;

            return organization;
        }
    }
}
