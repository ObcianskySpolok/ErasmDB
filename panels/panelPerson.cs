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
    public partial class panelPerson : UserControl
    {
        public panelPerson()
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
            var fnt = new Font("Segoe UI Light", 20);
            var fnt1 = new Font("Segoe UI Light", 16,FontStyle.Bold);
            var fnt2 = new Font("Segoe UI Light", 16);
            var fnt3 = new Font("Segoe UI Light", 13);

            gridData.ColumnHeadersDefaultCellStyle.Font = fnt;

            gridData.DefaultCellStyle.Font = fnt2;


            gridData.Columns["ID"].Visible = false;
            gridData.Columns["Active"].Visible = false;

            gridData.Columns["Gender"].Width = 100;
            gridData.Columns["Title"].Width = 100;
            gridData.Columns["FirstName"].Width = 200;
            gridData.Columns["LastName"].Width = 300;
            gridData.Columns["Email"].Width = 250;
            gridData.Columns["Telephone"].Width = 250;
            gridData.Columns["Facebook"].Width = 250;
            gridData.Columns["Role"].Width = 200;

            gridData.Columns["LastName"].DefaultCellStyle.Font = fnt1;
            gridData.Columns["Email"].DefaultCellStyle.Font = fnt3;
            gridData.Columns["Telephone"].DefaultCellStyle.Font = fnt3;
            gridData.Columns["Facebook"].DefaultCellStyle.Font = fnt3;

            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private IEnumerable<object> GridData_SetupLinq(string filter)
        {
            var pers = (from persons in Program.GData.dataPerson.getPersons
                        join roles in Program.GData.dataLOV.getRoles on persons.Role equals roles.ID
                        orderby persons.ID descending
                        select new
                        {
                            persons.ID,
                            persons.Gender,
                            persons.Title,
                            persons.LastName,
                            persons.FirstName,
                            persons.Email,
                            persons.Telephone,
                            persons.Facebook,
                            roles.Role,
                            persons.Active
                        }).ToList();

            if (pers == null) return null;

            var filterUp = filter.ToUpper();
            var dataFiltered = (filter == "")
                ? pers
                : pers.Where(c => (
                                            c.FirstName.ToString().ToUpper().Contains(filterUp) ||
                                            c.LastName.ToString().ToUpper().Contains(filterUp) ||
                                            c.Email.ToString().ToUpper().Contains(filterUp) ||
                                            c.Telephone.ToString().ToUpper().Contains(filterUp)
                                       )
                                 );

            return dataFiltered.ToArray();

        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridData.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            EditPerson(ID);
        }

        private void EditPerson(long ID)
        {
            var frmEditPerson = new formedit.formEditPerson(Program.GData.dataPerson.getPersons.First(c => c.ID == ID));
            frmEditPerson.ShowDialog();

            if (frmEditPerson.savedData != null)
            {
                Program.GData.dataPerson.Update(frmEditPerson.savedData);
            }

            gridData.LoadGrid();
            SelectRow(ID);
        }
        private void ibuttonPersonAdd_Click(object sender, EventArgs e)
        {
            var person = new modelPerson();
            person.CreateNewEmpty();

            Program.GData.dataPerson.Insert(person);
            gridData.LoadGrid();
        }

        private void ibuttonPersonEdit_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                EditPerson(id);
            }
        }

        private void ibuttonPersonRemove_Click(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count > 0)
            {
                long id = (long)gridData.SelectedRows[0].Cells["ID"].Value;
                var person = Program.GData.dataPerson.getPersons.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove person?", true, "Yes", "No") == true)
                {
                    Program.GData.dataPerson.Delete(person);
                    gridData.LoadGrid();
                }
            }

        }
    }
}
