using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MSWord = Microsoft.Office.Interop.Word;

namespace erasmDB.formedit
{
    public partial class formEditProject : Form
    {
        private modelProject originalData;
        private modelProject newData;
        public modelProject savedData;

        private int posX;
        private int posY;
        private int posW;
        private int posH;

        public formEditProject()
        {
            InitializeComponent();
        }

        public formEditProject(modelProject project)
        {
            InitializeComponent();

            originalData = new modelProject();
            originalData = project.DeepClone();
            newData = new modelProject();
            newData = project.DeepClone();
            savedData = null;

            ShowTopics(comboTopic);
            ShowTopics(comboTopic2);
            ShowTopics(comboTopic3);

            ShowData(originalData);

            gridActivities.SetupLinq += GridActivities_SetupLinq;
            gridActivities.SetupGrid += GridActivities_SetupGrid;
            gridActivities.LoadGrid();

            gridVariations.SetupLinq += GridVariations_SetupLinq;
            gridVariations.SetupGrid += GridVariations_SetupGrid;
            gridVariations.LoadGrid();
        }

        private void ShowTopics(ComboBox combo)
        {
            combo.Items.Clear();

            foreach (var top in Program.GData.dataLOV.getTopics)
            {
                var item = combo.Items.Add(top.Topic);
            }
        }


        private void GridVariations_SetupGrid()
        {
            var fntHeadline = new Font("Segoe UI Light", 14);
            var fntNormal = new Font("Segoe UI Light", 12);
            var fntSmaller = new Font("Segoe UI Light", 10);

            gridVariations.ColumnHeadersDefaultCellStyle.Font = fntHeadline;
            gridVariations.DefaultCellStyle.Font = fntNormal;

            gridVariations.Columns["StartDate"].DefaultCellStyle.Font = fntSmaller;
            gridVariations.Columns["EndDate"].DefaultCellStyle.Font = fntSmaller;
            gridVariations.Columns["Duration"].DefaultCellStyle.Font = fntSmaller;

            gridVariations.Columns["ID"].Visible = false;
            gridVariations.Columns["Country"].Visible = false;

            gridVariations.Columns["Title"].Width = 250;
            gridVariations.Columns["Call"].Width = 250;
            gridVariations.Columns["Acronym"].Width = 100;
            gridVariations.Columns["StartDate"].Width = 100;
            gridVariations.Columns["EndDate"].Width = 100;
            gridVariations.Columns["Duration"].Width = 80;
            gridVariations.Columns["Language"].Width = 120;
            gridVariations.Columns["AgencyName"].Width = 300;
            gridVariations.Columns["NACode"].Width = 150;
            gridVariations.Columns["CountryCode"].Width = 120;
            gridVariations.Columns["Applicant"].Width = 300;
            gridVariations.Columns["Partner"].Width = 300;
            gridVariations.Columns["Code"].Width = 200;
            gridVariations.Columns["Status"].Width = 200;
            gridVariations.Columns["Phase"].Width = 200;

            gridVariations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private IEnumerable<object> GridVariations_SetupLinq(string filter)
        {
            var joinedNationalAgencies =
                        
                (from natagencies in Program.GData.dataLOV.getNationalAgencies
                 join countries in Program.GData.dataLOV.getCountries on natagencies.Country equals countries.ID
                                    select new
                                    {
                                        natagencies.ID,
                                        natagencies.NACode,
                                        natagencies.AgencyName,
                                        countries.Country,
                                        countries.Code
                                    }
                        );


            var od = (from projvars in Program.GData.dataProject.getProjectVariations
                      join languages in Program.GData.dataLOV.getLanguages on projvars.Language equals languages.ID
                      join applicantOrg in Program.GData.dataOrganization.getOrganizations on projvars.ApplicantOrganization equals applicantOrg.ID
                      join nationalagency in joinedNationalAgencies on projvars.NationalAgency equals nationalagency.ID
                      join partnerOrg in Program.GData.dataOrganization.getOrganizations on projvars.PartnerOrganization equals partnerOrg.ID
                      orderby projvars.ID
                      where projvars.ProjectID == originalData.ID
                      select new
                      {
                          projvars.ID,
                          projvars.Call,
                          projvars.Title,
                          projvars.Acronym,
                          StartDate = projvars.StartDate.ToString("dd.MM.yy"),
                          EndDate = projvars.EndDate.ToString("dd.MM.yy"),
                          projvars.Duration,
                          languages.Language,
                          nationalagency.AgencyName,
                          nationalagency.NACode,
                          nationalagency.Country,
                          CountryCode = nationalagency.Code,
                          Applicant = applicantOrg.LegalName,
                          Partner = partnerOrg.LegalName,
                          projvars.Code,
                          projvars.Status,
                          projvars.Phase
                      });

            if (od == null) return null;

            return od.ToArray();
        }

        private void GridActivities_SetupGrid()
        {
            var fntHeadline = new Font("Segoe UI Light", 14);
            var fntNormal = new Font("Segoe UI Light", 12);
            var fntSmaller = new Font("Segoe UI Light", 10);

            gridActivities.ColumnHeadersDefaultCellStyle.Font = fntHeadline;
            gridActivities.DefaultCellStyle.Font = fntNormal;

            gridActivities.Columns["ID"].Visible = false;
            gridActivities.Columns["ActivityType"].Visible = true;

            gridActivities.Columns["Title"].Width = 250;
            gridActivities.Columns["Duration"].Width = 110;            
            gridActivities.Columns["ActivityType"].Width = 200;

            gridActivities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private IEnumerable<object> GridActivities_SetupLinq(string filter)
        {
            var od = (from projacts in Program.GData.dataProject.getProjectActivities
                      join activities in Program.GData.dataActivity.getActivityTypes on projacts.ActivityID equals activities.ID
                      
                      orderby projacts.ID
                      where projacts.ProjectID == originalData.ID
                      select new
                      {
                          projacts.ID,
                          projacts.Title,
                          projacts.Duration,
                          activities.ActivityType,                      
                      });

            if (od == null) return null;

            return od.ToArray();
        }

        private void ShowData(modelProject project)
        {
            textTitle.Text = project.Title;
            textKeyAction.Text = project.KeyAction;
            textAction.Text = project.Action;
            textWrittenBy.Text = project.WrittenBy;
            comboTopic.Text = project.Topic;
            comboTopic2.Text = project.Topic2;
            comboTopic3.Text = project.Topic3;
            htmlComments.InnerHtml = project.Comments;
            htmlDescription.InnerHtml = project.Description;
        }
        private void GetData(ref modelProject project)
        {
            project.Title = textTitle.Text;
            project.KeyAction = textKeyAction.Text;
            project.Action = textAction.Text;
            project.WrittenBy = textWrittenBy.Text;
            project.Comments = htmlComments.InnerHtml;
            project.Description = htmlDescription.InnerHtml;
            project.Topic = comboTopic.Text;
            project.Topic2 = comboTopic2.Text;
            project.Topic3 = comboTopic3.Text;
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            if(!Program.Compare<modelProject>(originalData, newData))
            {
                if(!Program.ShowMessageBox("Do you want to scrap changes?", true, "YES", "NO"))
                {
                    return;
                }
            }
            newData = null;
            this.Hide();
        }

        private void ibuttonSave_Click(object sender, EventArgs e)
        {
            GetData(ref newData);

            SaveVarsForMailMerge();

            savedData = new modelProject();
            savedData = newData.DeepClone();
            this.Hide();
        }

        private void ShowAllEditors(bool visibility)
        {
            UserControl[] panels = { htmlComments, htmlDescription };

            foreach (var panel in panels)
                panel.Visible = visibility;
        }
        private void MaximizeHTML(MSDN.Html.Editor.HtmlEditorControl editor, IconButton buttonMax, IconButton buttonMin)
        {
            buttonMax.Visible = false;
            buttonMin.Visible = true;

            ShowAllEditors(false);

            posX = editor.Left;
            posY = editor.Top;
            posW = editor.Width;
            posH = editor.Height;

            editor.Left = 637;
            editor.Top = 12;
            editor.Height = 200;

            editor.ToolbarVisible = true;
            editor.Visible = true;
        }
        private void MinimizeHTML(MSDN.Html.Editor.HtmlEditorControl editor, IconButton buttonMax, IconButton buttonMin)
        {
            buttonMax.Visible = true;
            buttonMin.Visible = false;

            editor.Left = posX;
            editor.Top = posY;
            editor.Height = posH;

            ShowAllEditors(true);

            editor.ToolbarVisible = false;
        }

        private void formEditProject_Load(object sender, EventArgs e)
        {

        }

        private void ibuttonMaximizeDescription_Click(object sender, EventArgs e)
        {
            MaximizeHTML(htmlDescription, ibuttonMaximizeDescription, ibuttonMinimizeDescription);
        }

        private void ibuttonMinimizeDescription_Click(object sender, EventArgs e)
        {
            MinimizeHTML(htmlDescription, ibuttonMaximizeDescription, ibuttonMinimizeDescription);
        }

        private void ibuttonMaximizeComments_Click(object sender, EventArgs e)
        {
            MaximizeHTML(htmlComments, ibuttonMaximizeComments, ibuttonMinimizeComments);

        }

        private void ibuttonMinimizeComments_Click(object sender, EventArgs e)
        {
            MinimizeHTML(htmlComments, ibuttonMaximizeComments, ibuttonMinimizeComments);

        }

        private void gridActivities_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridActivities.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            EditProjectActivities(ID);
        }

        private void EditProjectActivities(long ID)
        {
            //this.Cursor = Cursors.WaitCursor;
            var projectActivity = Program.GData.dataProject.getProjectActivities.First(c => c.ID == ID);
            var formedit = new formEditProjectActivity(projectActivity);
           // this.Cursor = Cursors.Default;
            formedit.ShowDialog(this);

            if (formedit.savedData != null)
            {
                Program.GData.dataProject.Update(formedit.savedData);
            }
            gridActivities.LoadGrid();
            
        }

        private void EditProjectVariations(long ID)
        {
            //this.Cursor = Cursors.WaitCursor;
            var projectVariation = Program.GData.dataProject.getProjectVariations.First(c => c.ID == ID);
            var formedit = new formEditProjectVariation(projectVariation);
            //this.Cursor = Cursors.Default;
            formedit.ShowDialog(this);

            if (formedit.savedData != null)
            {
                Program.GData.dataProject.Update(formedit.savedData);
            }
            gridVariations.LoadGrid();

        }
        private void ibuttonProjectActivityEdit_Click(object sender, EventArgs e)
        {
            if (gridActivities.SelectedRows.Count > 0)
            {
                long id = (long)gridActivities.SelectedRows[0].Cells["ID"].Value;
                EditProjectActivities(id);
            }
        }

        private void ibuttonProjectActivityRemove_Click(object sender, EventArgs e)
        {
            if (gridActivities.SelectedRows.Count > 0)
            {
                long id = (long)gridActivities.SelectedRows[0].Cells["ID"].Value;
                var projectActivity = Program.GData.dataProject.getProjectActivities.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove Project - Activity?", true, "Yes", "No") == true)
                {
                    Program.GData.dataProject.Delete(projectActivity);
                    gridActivities.LoadGrid();
                }
            }
        }

        private void ibuttonProjectVariationAdd_Click(object sender, EventArgs e)
        {
            var projectVariation = new modelProjectVariation();
            projectVariation.ProjectID = originalData.ID;
            projectVariation.Call = "New Call";
            projectVariation.Title = "New Title";
            projectVariation.Acronym = "AA";
            projectVariation.StartDate = DateTime.Now;
            projectVariation.Duration = 7;
            projectVariation.EndDate = projectVariation.StartDate.AddDays(projectVariation.Duration);
            projectVariation.Language = Program.GData.dataLOV.getLanguages.ElementAt(0).ID;
            projectVariation.ApplicantOrganization = Program.GData.dataOrganization.getOrganizations.ElementAt(0).ID;
            projectVariation.NationalAgency = Program.GData.dataLOV.getNationalAgencies.ElementAt(0).ID;
            projectVariation.PartnerOrganization = Program.GData.dataOrganization.getOrganizations.ElementAt(0).ID;
            projectVariation.Code = "";
            projectVariation.Status = "";
            projectVariation.Phase = "";

            Program.GData.dataProject.Insert(projectVariation);

            gridVariations.LoadGrid();

        }

        private void ibuttonProjectActivityAdd_Click(object sender, EventArgs e)
        {
            var proact = new modelProjectActivity();
            proact.ProjectID = originalData.ID;
            proact.ActivityID = Program.GData.dataActivity.getActivityTypes.ElementAt(0).ID;
            proact.Duration = 10;
            proact.Title = originalData.Title;

            Program.GData.dataProject.Insert(proact);

            gridActivities.LoadGrid();
        }

        private void ibuttonVariationEdit_Click(object sender, EventArgs e)
        {
            if (gridVariations.SelectedRows.Count > 0)
            {
                long id = (long)gridVariations.SelectedRows[0].Cells["ID"].Value;
                EditProjectVariations(id);
            }
        }

        private void gridVariations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(gridVariations.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            EditProjectVariations(ID);
        }



        private void ibuttonProjectVariationRemove_Click(object sender, EventArgs e)
        {
            if (gridActivities.SelectedRows.Count > 0)
            {
                long id = (long)gridActivities.SelectedRows[0].Cells["ID"].Value;
                var projectVariation = Program.GData.dataProject.getProjectVariations.First(c => c.ID == id);
                if (Program.ShowMessageBox("Do you really want to remove Project - Variation?", true, "Yes", "No") == true)
                {
                    Program.GData.dataProject.Delete(projectVariation);
                    gridActivities.LoadGrid();
                }
            }
        }

        private Tuple<string,List<object>> SaveVarsForMailMergeVariation(int index, ref modelMailMargeVariables MMvars, bool namedParams)
        {
            int column = 1;
            string sqlInsert = "INSERT INTO tblWordMailMerge (ProjectID,";
            string sqlFields;
            if (namedParams)
                sqlFields = "(@ProjectID,";
            else
                sqlFields = "(@0,";
            var row1 = MMvars.usedVariables.ToArray();
            foreach (var mmvar in row1)
            {
                string fieldName = mmvar.Value;
                sqlInsert += fieldName + ",";
                if(namedParams)
                    sqlFields += "@" + fieldName + ",";
                else
                    sqlFields += "@" + column.ToString() + ",";
                column++;
            }

            sqlInsert = sqlInsert.Substring(0, sqlInsert.Length - 1);
            sqlFields = sqlFields.Substring(0, sqlFields.Length - 1);

            string sql = sqlInsert + ") VALUES " + sqlFields + ")";
            List<object> args = new List<object>();
            args.Add(newData.ID);
            foreach (var mmvar in row1)
            {
                string fieldName = mmvar.Value;

                string varvalue = "";
                if (MMvars.mailMergeVars.ContainsKey(fieldName))
                {
                    varvalue = MMvars.mailMergeVars[fieldName];
                    if (varvalue == null) varvalue = "";
                    //Console.WriteLine(varvalue.Length);
                    args.Add(varvalue);
                }
                else
                {
                    args.Add("");
                }
                column++;
            }

            return Tuple.Create(sql,args);
        }

        private void SaveVarsForMailMerge()
        {
            modelMailMargeVariables MMvars;
            MMvars = new modelMailMargeVariables();
            MMvars.prepareMailMergeData(newData);


            var db = Program.GData.ChooseDB();
            db.EnableNamedParams = false;

            string sqlDelete = "DELETE FROM tblWordMailMerge WHERE ProjectID=@0";
            List<object> argsDelete = new List<object>();
            argsDelete.Add(newData.ID);
            db.Execute(sqlDelete, argsDelete.ToArray());

            for ( int index=0; index < MMvars.mailMergeVarsCount; index++)
            {
                MMvars.mailMergeVarsIndex = index;
                Tuple<string, List<object>> data = SaveVarsForMailMergeVariation(index,ref MMvars, Program.GData.CFG_DB_USE==0 ? true :  false);
                db.Execute(data.Item1, data.Item2.ToArray());
            }

        }

        private string FormatListLine(string key, string varname, string value)
        {
            int part1 = 60;
            int part2 = 25;
            //string s1 = (string)(key + new String(' ', part1)).Substring(0, part1);
            string s2 = (string)(varname + new String(' ', part1)).Substring(0, part1) + "  :";
            return s2 + value;
        }

        private void WordMailMergeLink(string fileNameTemplate, string projectid)
        {
            MSWord.Application winword = null;
            MSWord.Document actualDocument = null;

            winword = new MSWord.Application();
            MSWord.Document docNew = null;

            winword.ShowAnimation = false;
            winword.Visible = true;
            object missing = System.Reflection.Missing.Value;

            try
            {
                docNew = winword.Documents.Open(fileNameTemplate);
                docNew.Activate();
                actualDocument = docNew;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var wrdMailMerge = actualDocument.MailMerge;
            wrdMailMerge.OpenDataSource(@"C:\ErasmDB\localDB.accdb", missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing,
                "SELECT * FROM [tblWordMailMerge] WHERE ProjectID='" + projectid +"'");

            actualDocument.Save();
            actualDocument.Close();
        }

        private void ibuttonWordLink_Click(object sender, EventArgs e)
        {
            string wordFile = "";

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Select word document for project";
            theDialog.Filter = "Word files|*.docx";
            theDialog.InitialDirectory = @"C:\temp";
            if (theDialog.ShowDialog() != DialogResult.OK)
                return;
            
            wordFile = theDialog.FileName.ToString();
            WordMailMergeLink(wordFile, newData.ID.ToString());
        }

        private void ibuttonTemplate_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new formWordTemplateEdit(newData);
            frm.ShowDialog();

            this.Show();

        }

        private void ibuttonExportExcel_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
            saveDialog.FileName = "export.xlsx";
            saveDialog.Filter = "Excel file (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            saveDialog.FilterIndex = 1;

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            modelMailMargeVariables MMvars;
            MMvars = new modelMailMargeVariables();
            MMvars.prepareMailMergeData(newData);

            var excp = new ExcelPackage();
            var ws = excp.Workbook.Worksheets.Add("Export");

            int row = 1;
            int column = 1;

            for (int index = 0; index < MMvars.mailMergeVarsCount; index++)
            {
                MMvars.mailMergeVarsIndex = index;
                column = 1;
                var row1 = MMvars.usedVariables.ToArray();
                foreach (var mmvar in row1)
                {
                    string fieldName = mmvar.Value;

                    if (row == 1)
                        ws.Cells[row, column].Value = fieldName;

                    string varvalue = "";
                    if (MMvars.mailMergeVars.ContainsKey(fieldName))
                    {
                        varvalue = MMvars.mailMergeVars[fieldName];
                        ws.Cells[row + 1, column].Value = varvalue;
                    }

                    column++;
                }

                row++;
                //Tuple<string, List<object>> data = SaveVarsForMailMergeVariation(index, ref MMvars, Program.GData.CFG_DB_USE == 0 ? true : false);
            }

            row++;

            Byte[] bin = excp.GetAsByteArray();
            File.WriteAllBytes(saveDialog.FileName, bin);

            OpenFile(saveDialog.FileName);
        }

        private void OpenFile(string fname)
        {
            System.Diagnostics.Process.Start(fname);
        }
    }
}
