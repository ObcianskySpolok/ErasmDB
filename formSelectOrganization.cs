using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace erasmDB
{

    public partial class formSelectOrganization : Form
    {
        public List<long> SelectedRows;
        public DataGridView grid;

        public formSelectOrganization(string nazov)
        {
            InitializeComponent();
            SelectedRows = new List<long>();
            grid = gridData;
            gridData.DefaultCellStyle.Font = new Font("Segoe UI Light",15);
            labelCaption.Text = nazov;

            SetupGrid();
        }

        private void SetupGrid()
        {
            var dataArray = from organization in Program.GData.dataOrganization.getOrganizations
                            join countries in Program.GData.dataLOV.getCountries on organization.Country equals countries.ID
                            orderby countries.Code
                            select new OrganizationSelect
                            {
                                Selected = false,
                                Code = countries.Code,
                                ID = organization.ID,
                                LegalName = organization.LegalName,
                                Acronym = organization.Acronym,
                                Address = organization.Address,
                                City = organization.City,
                                Country = countries.Country,

                            };
            if (dataArray.IsEmpty())
                return;

            //List<OrganizationSelect> data = new List<OrganizationSelect>();
            //foreach (var item in dataArray)
            //    data.Add(item);
            SortableBindingList<Object> dataSortable = new SortableBindingList<Object>(dataArray.ToArray());

            grid.DataBindings.Clear();
            grid.DataSource = dataArray.ToList();

            grid.Columns["ID"].Visible = false;

            grid.Columns["Code"].Width = 80;
            grid.Columns["LegalName"].Width = 200;
            grid.Columns["Acronym"].Width = 80;
            grid.Columns["Address"].Width = 15;
            grid.Columns["City"].Width = 150;
            grid.Columns["Country"].Width = 150;
        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow != null)
            {
                SelectedRows = new List<long>();
                SelectedRows.Add((long)gridData.CurrentRow.Cells["ID"].Value);
            }
                
            this.Close();
        }

        private void formSelect_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null) return;

            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (grid.Columns[col].Name == "Selected")
                gridData.Rows[row].Cells[col].Value = !(bool)(gridData.Rows[row].Cells[col].Value);
        }

        private void ibuttonOK_Click(object sender, EventArgs e)
        {
            SelectedRows = new List<long>();
            foreach(DataGridViewRow datarow in grid.Rows)
            {
                if((bool)(datarow.Cells["Selected"].Value) == true)
                    SelectedRows.Add((long)(datarow.Cells["ID"].Value));
            }
                
            this.Hide();
        }
    }
}