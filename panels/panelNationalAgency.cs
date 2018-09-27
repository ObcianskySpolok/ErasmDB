using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erasmDB.panels
{
    public partial class panelNationalAgency : UserControl
    {
        public panelNationalAgency()
        {
            InitializeComponent();
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
        public void LoadData()
        {
            gridData.RowTemplate.Height = 30;
            gridData.SetupLinq += GridData_SetupLinq;
            gridData.SetupGrid += GridData_SetupGrid;
            gridData.LoadGrid();
        }

        private void GridData_SetupGrid()
        {
            var fntHeader = new Font("Segoe UI Light", 18);
            var fntBold = new Font("Segoe UI Light", 16,FontStyle.Bold);
            var fntNormal = new Font("Segoe UI Light", 16);
            var fntSmall = new Font("Segoe UI Light", 13);

            gridData.ColumnHeadersDefaultCellStyle.Font = fntHeader;

            gridData.DefaultCellStyle.Font = fntNormal;


            gridData.Columns["ID"].Visible = false;
            gridData.Columns["Active"].Visible = false;

            gridData.Columns["NACode"].Width = 250;
            gridData.Columns["AgencyName"].Width = 400;
            gridData.Columns["Country"].Width = 200;
            gridData.Columns["Code"].Width = 100;

            gridData.Columns["AgencyName"].DefaultCellStyle.Font = fntBold;
            gridData.Columns["Country"].DefaultCellStyle.Font = fntSmall;
            gridData.Columns["Code"].DefaultCellStyle.Font = fntSmall;

            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private IEnumerable<object> GridData_SetupLinq(string filter)
        {
            var pers = (from agencies in Program.GData.dataLOV.getNationalAgencies
                        join countries in Program.GData.dataLOV.getCountries on agencies.Country equals countries.ID
                        orderby agencies.ID descending
                        select new
                        {
                            agencies.ID,
                            agencies.NACode,
                            agencies.AgencyName,
                            countries.Country,
                            countries.Code,
                            agencies.Active
                        }).ToList();

            if (pers == null) return null;

            var filterUp = filter.ToUpper();
            var dataFiltered = (filter == "")
                ? pers
                : pers.Where(c => (
                                            c.NACode.ToString().ToUpper().Contains(filterUp) ||
                                            c.AgencyName.ToString().ToUpper().Contains(filterUp) ||
                                            c.Country.ToString().ToUpper().Contains(filterUp) ||
                                            c.Code.ToString().ToUpper().Contains(filterUp)
                                       )
                                 );

            return dataFiltered.ToArray();

        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridData.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            EditNationalAgency(ID);
        }

        private void EditNationalAgency(long ID)
        {
            var frmEditAgency = new formedit.formEditNationalAgency(Program.GData.dataLOV.getNationalAgencies.First(c => c.ID == ID));
            frmEditAgency.ShowDialog();

            if (frmEditAgency.savedData != null)
            {
                Program.GData.dataLOV.Update(frmEditAgency.savedData);
            }

            gridData.LoadGrid();
            SelectRow(ID);
        }

        private void ibuttonAdd_Click(object sender, EventArgs e)
        {
            var agency = new modelNationalAgency();
            agency.CreateNewEmpty();

            Program.GData.dataLOV.Insert(agency);
            gridData.LoadGrid();

        }

        private void ibuttonRemove_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                var agency = Program.GData.dataLOV.getNationalAgencies.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove national agency?", true, "Yes", "No") == true)
                {
                    Program.GData.dataLOV.Delete(agency);
                    gridData.LoadGrid();
                }
            }

        }

        private void ibuttonEdit_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                EditNationalAgency(id);
            }

        }
    }
}
