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
    public partial class formSelect : Form
    {
        public int SelectedRow;
        public DataGridView grid;

        public formSelect(string nazov)
        {
            InitializeComponent();
            SelectedRow = -1;
            grid = gridData;
            gridData.DefaultCellStyle.Font = new Font("Segoe UI Light",15);
            labelCaption.Text = nazov;
        }


        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow != null) SelectedRow = gridData.CurrentRow.Index;
            this.Close();
        }

        private void formSelect_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void gridData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}