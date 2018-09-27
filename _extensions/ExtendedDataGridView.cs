using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
//using halaTN_APP.extensions;
using OfficeOpenXml;

namespace erasmDB
{
    partial class ExtendedDataGridView : DataGridView
    {
        Panel _filterPanel = new Panel();
        TextBox _filterText = new TextBox();
        Button _filterButton = new Button();

        private Timer _keyTimer;

        const int panelWidth = 300;

        private IEnumerable<object> data;
        public delegate IEnumerable<object> setupLinqCallback(string filter);
        public delegate void setupGridCallback();

        public event setupLinqCallback SetupLinq;
        public event setupGridCallback SetupGrid;

        private SortableBindingList<Object> _dataSortable;

        public void LoadGrid(string flt="")
        {
            _filter = flt;
            data = SetupLinq(_filter);
            if (data.IsEmpty())
            {
                base.DataSource = null;
            }
            else
            {
                _dataSortable = new SortableBindingList<Object>(data);

                base.DataBindings.Clear();
                base.DataSource = _dataSortable;
                SetupGrid();                
            }
        }

        private string _filter = "";
        private string[] _filterColumns = {};
        public string[] FilterColumns
        {
            get
            {
                return this._filterColumns;
            }
            set
            {
                _filterColumns = value;
            }
        }

        public ExtendedDataGridView()
        {
            _filterPanel.Controls.Add(_filterText);
            _filterPanel.Controls.Add(_filterButton);
            base.Controls.Add(_filterPanel);

            _filterPanel.Left = 0;
            _filterPanel.Top = 0;
            _filterPanel.Width = panelWidth;
            _filterPanel.Visible = false;
            _filterPanel.BorderStyle = BorderStyle.FixedSingle;            

            _filterText.Left = 2;
            _filterText.Top = 2;
            //if (Program.GData != null)
            //    _filterText.Font = Program.GData.defaultGridFont;
            _filterText.Width = panelWidth-50;
            _filterText.BorderStyle = BorderStyle.FixedSingle;
            _filterText.Visible = true;
            _filterPanel.Height = _filterText.Height + 10;

            _filterButton.FlatStyle = FlatStyle.Flat;
            //_filterButton.Image = Properties.Resources.close;
            _filterButton.Top = 2;
            _filterButton.Width = 40;
            _filterButton.Left = panelWidth - _filterButton.Width - 5;
            _filterButton.Height = _filterText.Height;
            _keyTimer = new Timer() { Interval = 500 };
            _keyTimer.Tick += keyTimerTick;            

            _filterText.TextChanged += FilterTextChanged;
            _filterText.KeyPress += FilterKeyPress;
            _filterText.KeyDown += FilterKeyDown;

            _filterButton.Click += FilterCloseButton;

            base.ColumnHeaderMouseDoubleClick += gridColumnHeaderMouseDoubleClick;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if ((char) e.KeyValue == 'F')
            {
                if (e.Modifiers == Keys.Control)
                {
                    _lastFilter = _filter;
                    if (_filter != "")
                    {
                        _filterText.Text = _filter;
                        _filterButton.Visible = true;
                    }
                    else
                    {
                        _filterButton.Visible = false;
                    }
                        
                    _filterPanel.Visible = true;
                    _filterText.Focus();
                }
            }

        }

        private string _lastFilter;
        private void FilterTextChanged(object sender, EventArgs e)
        {
            _keyTimer.Stop();
            if (_lastFilter == _filterText.Text)
                return;

            _keyTimer.Start();
            _lastFilter = _filterText.Text;
        }

        private void FilterKeyPress(object sender, KeyPressEventArgs e)
        {
        }


        private void FilterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                HidePanel();
            }
            if (e.KeyCode == Keys.Enter)
            {
                FilterNow();
            }
        }

        private void FilterCloseButton(object sender, EventArgs e)
        {
            _filterText.Text = "";
        }

        private void gridColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int a = 1;
        }

        private void keyTimerTick(object sender, EventArgs e)
        {
            FilterNow();
        }

        private void HidePanel()
        {
            _filterText.Text = "";
            _keyTimer.Stop();
            base.Focus();
            _filterPanel.Visible = false;            
        }
        private void FilterNow()
        {
            var searchText = _filterText.Text;
            HidePanel();
            _filter = searchText;
            LoadGrid(searchText);
        }

        public void ExportToExcel()
        {


            //foreach (var row in data)
            //{
            //    foreach (var prop in row.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            //    {
            //        Console.WriteLine("Name: {0}, Value: {1}", prop.Name, prop.GetValue(row, null));
            //    }            
                
            //}
            var excp = new ExcelPackage();
            var ws = excp.Workbook.Worksheets.Add("Export");            

            int row = 1;
            int column = 1;
            foreach (var prop in data.First().GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (base.Columns[prop.Name].Visible)
                {
                    ws.Cells[row, column].Value = prop.Name;
                    column++;                    
                }
            }
            row++;
            foreach (var rowData in data)
            {
                column = 1;
                foreach (var prop in rowData.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (base.Columns[prop.Name].Visible)
                    {
                        string propvalue = Convert.ToString(prop.GetValue(rowData, null));
                        ws.Cells[row, column].Value = propvalue;
                        column++;
                    }
                }
                row++;
            }

            var saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
            saveDialog.FileName = "export.xlsx";
            saveDialog.Filter = "Excel file (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            saveDialog.FilterIndex = 1;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Byte[] bin = excp.GetAsByteArray();
                File.WriteAllBytes(saveDialog.FileName, bin);
            }
            //MessageBox.Show("OK");
            OpenFile(saveDialog.FileName);


        }
        private void OpenFile(string fname)
        {
            System.Diagnostics.Process.Start(fname);
        }
    }
}
