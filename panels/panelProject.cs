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
    public partial class panelProject : UserControl
    {
        public panelProject()
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
            gridData.DefaultCellStyle.Font = fntNormal;

            gridData.Columns["Title"].DefaultCellStyle.Font = fntBold;
            gridData.Columns["WrittenBy"].DefaultCellStyle.Font = fntBold;
            gridData.Columns["Description"].DefaultCellStyle.Font = fntSmaller;
            gridData.Columns["Comments"].DefaultCellStyle.Font = fntSmaller;


            gridData.Columns["ID"].Visible = false;
            gridData.Columns["Active"].Visible = false;

            gridData.Columns["Title"].Width = 400;
            gridData.Columns["KeyAction"].Width = 250;
            gridData.Columns["Action"].Width = 250;
            gridData.Columns["WrittenBy"].Width = 200;
            gridData.Columns["Description"].Width = 200;
            gridData.Columns["Comments"].Width = 200;

            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private IEnumerable<object> GridData_SetupLinq(string filter)
        {
            var pers = (from projects in Program.GData.dataProject.getProjects
                        orderby projects.ID descending
                        select new
                        {
                            projects.ID,
                            projects.Title,
                            projects.KeyAction,
                            projects.Action,
                            projects.WrittenBy,
                            projects.Description,
                            projects.Comments,
                            projects.Active
                        }).ToList();

            if (pers == null) return null;

            var filterUp = filter.ToUpper();
            var dataFiltered = (filter == "")
                ? pers
                : pers.Where(c => (
                                            c.Title.ToString().ToUpper().Contains(filterUp) ||
                                            c.KeyAction.ToString().ToUpper().Contains(filterUp) ||
                                            c.Action.ToString().ToUpper().Contains(filterUp) ||
                                            c.WrittenBy.ToString().ToUpper().Contains(filterUp)
                                       )
                                 );

            return dataFiltered.ToArray();

        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridData.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            EditProject(ID);
        }

        private void EditProject(long ID)
        {
            //this.Cursor = Cursors.WaitCursor;
            var frmEditProject = new formedit.formEditProject(Program.GData.dataProject.getProjects.First(c => c.ID == ID));
            //this.Cursor = Cursors.Default;
            frmEditProject.ShowDialog(this);

            if (frmEditProject.savedData != null)
            {
                Program.GData.dataProject.Update(frmEditProject.savedData);
            }

            gridData.LoadGrid();
            SelectRow(ID);
        }

        private void ibuttonProjectEdit_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                EditProject(id);
            }
        }

        private void ibuttonProjectRemove_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                var project = Program.GData.dataProject.getProjects.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove project?", true, "Yes", "No") == true)
                {
                    Program.GData.dataProject.DeleteProjectWithAllDetails(project);
                    gridData.LoadGrid();
                }
            }
        }

        private void ibuttonProjectAdd_Click(object sender, EventArgs e)
        {
            var project = new modelProject();
            project.CreateNewEmpty();

            Program.GData.dataProject.Insert(project);
            gridData.LoadGrid();
        }
    }
}
