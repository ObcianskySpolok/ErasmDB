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
    public partial class panelDistanceBand : UserControl
    {
        public panelDistanceBand()
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

            gridData.Columns["DistanceBand"].Width = 1200;

            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private IEnumerable<object> GridData_SetupLinq(string filter)
        {
            var pers = (from distbands in Program.GData.dataLOV.getDistanceBands
                        orderby distbands.ID descending
                        select new
                        {
                            distbands.ID,
                            distbands.DistanceBand,
                            distbands.Price,
                            distbands.Active
                        }).ToList();

            if (pers == null) return null;

            var filterUp = filter.ToUpper();
            var dataFiltered = (filter == "")
                ? pers
                : pers.Where(c => (
                                            c.DistanceBand.ToString().ToUpper().Contains(filterUp)
                                       )
                                 );

            return dataFiltered.ToArray();

        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridData.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            EditDistanceBand(ID);
        }

        private void EditDistanceBand(long ID)
        {
            var band = Program.GData.dataLOV.getDistanceBands.First(c => c.ID == ID);
            string newband = Program.ShowInputBox("Distance band:", band.DistanceBand);
            string tmp = Program.ShowInputBox("Rate:", band.Price.ToString());

            if (band.DistanceBand != newband)
            {
                float tmpf;
                if (float.TryParse(tmp, out tmpf)) band.Price = tmpf;

                band.DistanceBand = newband;
                Program.GData.dataLOV.Update(band);
            }

            gridData.LoadGrid();
            SelectRow(ID);
        }

        private void ibuttonAdd_Click(object sender, EventArgs e)
        {
            var band = new modelDistanceBand();
            band.CreateNewEmpty();

            Program.GData.dataLOV.Insert(band);
            gridData.LoadGrid();
        }

        private void ibuttonEdit_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                EditDistanceBand(id);
            }
        }

        private void ibuttonRemove_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                var band = Program.GData.dataLOV.getDistanceBands.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove distance band?", true, "Yes", "No") == true)
                {
                    Program.GData.dataLOV.Delete(band);
                    gridData.LoadGrid();
                }
            }
        }
    }
}
