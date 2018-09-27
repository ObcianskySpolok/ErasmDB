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
    public partial class panelCountry : UserControl
    {
        public panelCountry()
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
            var fntHeader = new Font("Segoe UI Light", 20);
            var fntBold = new Font("Segoe UI Light", 16,FontStyle.Bold);
            var fntNormal = new Font("Segoe UI Light", 16);
            var fntSmall = new Font("Segoe UI Light", 13);

            gridData.ColumnHeadersDefaultCellStyle.Font = fntHeader;

            gridData.DefaultCellStyle.Font = fntNormal;


            gridData.Columns["ID"].Visible = false;
            gridData.Columns["Active"].Visible = false;

            gridData.Columns["Country"].Width = 400;
            gridData.Columns["Code"].Width = 100;

            gridData.Columns["Country"].DefaultCellStyle.Font = fntBold;

            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private IEnumerable<object> GridData_SetupLinq(string filter)
        {
            var pers = (from countries in Program.GData.dataLOV.getCountries
                        orderby countries.Country descending
                        select new
                        {
                            countries.ID,
                            countries.Code,
                            countries.Country,
                            countries.Rate,
                            countries.Active
                        }).ToList();

            if (pers == null) return null;

            var filterUp = filter.ToUpper();
            var dataFiltered = (filter == "")
                ? pers
                : pers.Where(c => (
                                            c.Country.ToString().ToUpper().Contains(filterUp) ||
                                            c.Code.ToString().ToUpper().Contains(filterUp)
                                       )
                                 );

            return dataFiltered.ToArray();

        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridData.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            EditCountry(ID);
        }

        private void EditCountry(long ID)
        {
            var frmEditCountry = new formedit.formEditCountry(Program.GData.dataLOV.getCountries.First(c => c.ID == ID));
            frmEditCountry.ShowDialog();

            if (frmEditCountry.savedData != null)
            {
                Program.GData.dataLOV.Update(frmEditCountry.savedData);
            }

            gridData.LoadGrid();
            SelectRow(ID);
        }

        private void ibuttonAdd_Click(object sender, EventArgs e)
        {
            var country = new modelCountry();
            country.CreateNewEmpty();

            Program.GData.dataLOV.Insert(country);
            gridData.LoadGrid();

        }

        private void ibuttonRemove_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                var country = Program.GData.dataLOV.getCountries.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove country?", true, "Yes", "No") == true)
                {
                    Program.GData.dataLOV.Delete(country);
                    gridData.LoadGrid();
                }
            }

        }

        private void ibuttonEdit_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                EditCountry(id);
            }

        }
    }
}
