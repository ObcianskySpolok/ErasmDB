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
    public partial class panelLanguage : UserControl
    {
        public panelLanguage()
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

            gridData.Columns["Language"].Width = 1200;

            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private IEnumerable<object> GridData_SetupLinq(string filter)
        {
            var pers = (from languages in Program.GData.dataLOV.getLanguages
                        orderby languages.ID descending
                        select new
                        {
                            languages.ID,
                            languages.Language,
                            languages.Active
                        }).ToList();

            if (pers == null) return null;

            var filterUp = filter.ToUpper();
            var dataFiltered = (filter == "")
                ? pers
                : pers.Where(c => (
                                            c.Language.ToString().ToUpper().Contains(filterUp)
                                       )
                                 );

            return dataFiltered.ToArray();

        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridData.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            EditLanguage(ID);
        }

        private void EditLanguage(long ID)
        {
            var lang = Program.GData.dataLOV.getLanguages.First(c => c.ID == ID);
            string newlang = Program.ShowInputBox("Language:", lang.Language);
            
            if (lang.Language != newlang)
            {
                lang.Language = newlang;
                Program.GData.dataLOV.Update(lang);
            }

            gridData.LoadGrid();
            SelectRow(ID);
        }

        private void ibuttonAdd_Click(object sender, EventArgs e)
        {
            var lang = new modelLanguage();
            lang.CreateNewEmpty();

            Program.GData.dataLOV.Insert(lang);
            gridData.LoadGrid();
        }

        private void ibuttonEdit_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                EditLanguage(id);
            }
        }

        private void ibuttonRemove_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                var lang = Program.GData.dataLOV.getLanguages.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove language?", true, "Yes", "No") == true)
                {
                    Program.GData.dataLOV.Delete(lang);
                    gridData.LoadGrid();
                }
            }
        }
    }
}
