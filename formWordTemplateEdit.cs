using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSWord = Microsoft.Office.Interop.Word;
using PetaPoco;

namespace erasmDB
{
    public partial class formWordTemplateEdit : Form
    {
        MSWord.Application winword = null;
        MSWord.Document actualDocument = null;

        private modelMailMargeVariables MMvars;
        private Dictionary<string, string> varItem;

        private modelProject actualProject;

        public formWordTemplateEdit()
        {
            InitializeComponent();
            actualProject = null;

            MMvars = new modelMailMargeVariables();
            varItem = MMvars.usedVariables;

            panelInsert.Visible = false;
            panelUpdate.Visible = true;
            ibuttonPrev.Visible = false;
            ibuttonNext.Visible = false;
            //DisableButtons();
            FillList();
        }

        public formWordTemplateEdit(modelProject project)
        {
            InitializeComponent();
            actualProject = project;
            MMvars = new modelMailMargeVariables();
            varItem = MMvars.usedVariables;
            MMvars.prepareMailMergeData(project);

            panelInsert.Visible = true;
            panelUpdate.Visible = false;
            ibuttonPrev.Visible = true;
            ibuttonNext.Visible = true;
            //DisableButtons();
            //mandateItem = Program.GData.getMandateDataItem(_projvar, _applicant, _partner, _agency);
            FillList();

        }

        private string FormatListLine(string key, string varname, string value) {
            int part1 = 60;
            int part2 = 25;
            //string s1 = (string)(key + new String(' ', part1)).Substring(0, part1);
            string s2 = (string)(varname + new String(' ', part1)).Substring(0, part1) + "  :";
            return s2 + value;
        }

        private void FillList()
        {
            listVariables.Items.Clear();
            varItem.ForEach(c => {
                string varvalue = "";
                if(MMvars.mailMergeVars != null)
                {
                    if (MMvars.mailMergeVars.ContainsKey(c.Value))
                        varvalue = MMvars.mailMergeVars[c.Value];
                }
                else
                {
                    varvalue = "";
                }

                listVariables.Items.Add(FormatListLine(c.Key, c.Value, varvalue));
            });

            iconSelectMandate.Visible = false;
        }
        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ProcessFile(string fileNameTemplate)
        {
            SetStatus("ms word....");
            winword = new MSWord.Application();
            MSWord.Document docNew = null;

            SetStatus("Opening file " + fileNameTemplate);

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
            SetStatus("document ok");

            ReadWordVars();

            //finally
            //{
            //    if (docTemplate != null)
            //        docTemplate.Close(false);

            //    if (docNew != null)
            //        docNew.Close();

            //    if (winword != null)
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(winword);

            //    winword = null;
            //    docTemplate = null;
            //    docNew = null;

            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}
        }

        private void ReadWordVars()
        {

            MSWord.MailMergeFields wrdMergeFields;
            MSWord.ContentControls controls;

            List<modelField> wrdFields = new List<modelField>();

            SetStatus("reading fields from template");
            controls = actualDocument.ContentControls;
            foreach( MSWord.ContentControl ctl in controls)
            {
                var fld = new modelField(ctl.Tag, ctl.Range.Start);
                wrdFields.Add(fld);
                
            }

            SetStatus("reading mailmerge variables from template");
            var wrdMailMerge = actualDocument.MailMerge;
            wrdMergeFields = wrdMailMerge.Fields;
            foreach(MSWord.MailMergeField mrgfld in wrdMergeFields)
            {
                var fld = new modelField("  " + mrgfld.Code.Text, mrgfld.Code.Start);
                wrdFields.Add(fld);
            }

            listWordVars.Items.Clear();
            var flds = wrdFields.OrderBy(c => c.Index).ToArray();

            foreach (modelField fld in flds)
            {
                string str = fld.Field == null ? "" : fld.Field;
                listWordVars.Items.Add(str);
            }
        }


        private void buttonSelectTemplate_Click(object sender, EventArgs e)
        {
            SetStatus("Select file");
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Select document template";
            theDialog.Filter = "Word files|*.docx";
            theDialog.InitialDirectory = @"C:\temp";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                textTemplate.Text = theDialog.FileName.ToString();
            }

            ProcessFile(textTemplate.Text);

            if (actualProject != null) {
                panelInsert.Visible = true;
                ibuttonInsert.Visible = true;
            }
            else
                panelUpdate.Visible = true;

            SetStatus("");
        }

        private void iconSelectMandate_Click(object sender, EventArgs e)
        {
            //prepareMandateData();
            //listVariables.Items.Clear();
            //mandateItem.ForEach(c => listVariables.Items.Add((string)(c.Key + " [" + c.Value + "]")));
        }

        private void InsertText(string text, string tag)
        {
            if (winword == null) return;
            
            MSWord.Selection objSelection = winword.Selection;
            MSWord.Range objRange = objSelection.Range;
            MSWord.MailMergeFields wrdMergeFields;
            MSWord.ContentControls controls;

            if(tag != "")
            {
                controls = actualDocument.ContentControls;
                var contentctl = controls.Add(MSWord.WdContentControlType.wdContentControlRichText, objRange);
                contentctl.Tag = tag;
                var wrdMailMerge = actualDocument.MailMerge;
                wrdMergeFields = wrdMailMerge.Fields;
                wrdMergeFields.Add(contentctl.Range, text);
            }
            else
            {
                var wrdMailMerge = actualDocument.MailMerge;
                wrdMergeFields = wrdMailMerge.Fields;
                wrdMergeFields.Add(objRange, text);
            }

        }
        private void listVariables_DoubleClick(object sender, EventArgs e)
        {
            ibuttonInsert_Click(null, null);
        }

        private void ibuttonInsert_Click(object sender, EventArgs e)
        {
            string selected = listVariables.Text;
            if (selected == "")
            {
                MessageBox.Show("Select variable to insert");
                return;
            }

            int i = selected.IndexOf(" :");
            string variable = selected.Substring(0,i).Trim();

            string desc = "Enter field name\nif field name is empty, insert only mailmerge without encapsulating field";
            string tag = Microsoft.VisualBasic.Interaction.InputBox(desc, "field name:", "E00", -1, -1);
            InsertText(variable,tag);

            ReadWordVars();
        }

        private void listVariables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ibuttonUpdateFields_Click(object sender, EventArgs e)
        {
            UpdateAllFields();
        }

        private void UpdateAllFields()
        {
            if (varItem.Count == 0) return;

            MSWord.Selection objSelection = winword.Selection;
            //objSelection.Document.Content.Select();            
            //MSWord.Range objRange = objSelection.Range;
            foreach(MSWord.Field fld in actualDocument.Fields)
            {
                string fieldText = fld.Code.Text;
                // ONLY GETTING THE MAILMERGE FIELDS
                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    string fieldName = fieldText.Replace("MERGEFIELD", "").Replace("\"", "").Trim();

                    Console.WriteLine(fieldName);                    

                    string varvalue = "";
                    if (MMvars.mailMergeVars.ContainsKey(fieldName))
                    {
                        varvalue = MMvars.mailMergeVars[fieldName];
                        if (varvalue == null) varvalue = "";
                        if (varvalue == "") varvalue = " ";                        
                    }
                        

                    fld.Select();
                    objSelection.TypeText(varvalue);

                }

            }

        }

        private void ibuttonExportExcel_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
            saveDialog.FileName = "export.xlsx";
            saveDialog.Filter = "Excel file (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            saveDialog.FilterIndex = 1;

            if (saveDialog.ShowDialog() != DialogResult.OK) return;


            var excp = new ExcelPackage();
            var ws = excp.Workbook.Worksheets.Add("Export");

            int row = 1;
            int column = 1;

            var row1 = MMvars.usedVariables.ToArray();
            foreach( var mmvar in row1)
            {
                string fieldName = mmvar.Value;

                ws.Cells[row, column].Value = fieldName;

                string varvalue = "";
                if (MMvars.mailMergeVars.ContainsKey(fieldName))
                {
                    varvalue = MMvars.mailMergeVars[fieldName];
                    ws.Cells[row+1, column].Value = varvalue;
                }
                    
                column++;
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

        private void ibuttonUpdateWordVars_Click(object sender, EventArgs e)
        {
            ReadWordVars();
        }

        private void ibuttonReplace_Click(object sender, EventArgs e)
        {
            string headerDocument = "";
            string newtemplate = textTemplate.Text.Replace(".docx", "-newheader.docx");
            string newheader = Program.GData.CFGFolderLocal + "\\NewDocHeader.docx";
            string tmpfile = Program.GData.CFGFolderLocal + "\\tmp.docx";
            MessageBox.Show("Allow designer mode");

            SetStatus("Saving temporary file" + tmpfile);
            actualDocument.SaveAs2(tmpfile);

            SetStatus("Deleting first 2 pages");
            DeleteFirstPage();
            DeleteFirstPage();
            actualDocument.Close();

            headerDocument = Program.GData.CFGFolderLocal + @"\assets\NewHeader.docx";
            ProcessFile(headerDocument);
            SetStatus("Saving temporary file" + newheader);
            actualDocument.SaveAs2(newheader);

            SetStatus("replace old variables");
            ReplaceOldVars();

            //LockFields();

            actualDocument.Save();
            actualDocument.Close();

            string[] docs = new string[2];
            docs[0] = newheader;
            docs[1] = tmpfile;

            SetStatus("merge document " + newheader + " / " + tmpfile);
            MergeWordDocs(docs, newtemplate,true);

            textTemplate.Text = newtemplate;
            ProcessFile(textTemplate.Text);

            SetStatus("replace old variables");
            ReplaceOldVars();
            actualDocument.Save();
            SetStatus("");

        }

        private void ReplaceOldVars()
        {
            var changedVars = MMvars.ChangedVariables();

            var wrdMailMerge = actualDocument.MailMerge;
            var wrdMergeFields = wrdMailMerge.Fields;

            for (int idx = wrdMergeFields.Count; idx > 0; idx--)
            {
                MSWord.MailMergeField mrgfld = wrdMergeFields[idx];                

                string txt = mrgfld.Code.Text.Trim();
                txt = txt.Replace("  ", " ");
                foreach (var ch in changedVars)
                {
                    string t = "MERGEFIELD " + ch.Item2;
                    if (txt==t)
                    {
                        string newfield = txt.Replace(ch.Item2, ch.Item1);
                        var pos = mrgfld.Code;
                        mrgfld.Delete();

                        wrdMergeFields = wrdMailMerge.Fields;
                        wrdMergeFields.Add(pos, ch.Item1);
                    }
                }
            }

        }

        private void LockFields()
        {
            var wrdMailMerge = actualDocument.MailMerge;
            var wrdMergeFields = wrdMailMerge.Fields;

            int GsectionStart = -1;
            int GsectionEnd = -1;

            var controls = actualDocument.ContentControls;
            foreach (MSWord.ContentControl ctl in controls)
            {
                if(ctl.Tag != null)
                {
                    if (ctl.Tag.Trim().StartsWith("G"))
                    {
                        GsectionEnd = ctl.Range.Start;
                        if (GsectionStart == -1) GsectionStart = ctl.Range.Start;
                    }
                }
            }
           
            foreach (MSWord.MailMergeField mrgfld in wrdMergeFields)
            {
                if(mrgfld.Code.Start>GsectionStart && mrgfld.Code.Start < GsectionEnd)
                {
                    string text = mrgfld.Code.Text;
                    mrgfld.Locked = true;
                }
            }
        }

        private void DeleteFirstPage()
        {
            MSWord.Selection objSelection = winword.Selection;
            objSelection.GoTo(MSWord.WdGoToItem.wdGoToPage, MSWord.WdGoToDirection.wdGoToAbsolute, 1, 1);
            objSelection.Bookmarks[@"\Page"].Select();
            objSelection.Delete();
        }

        private void MergeWordDocs(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
        {
            object missing = System.Type.Missing;
            object pageBreak = MSWord.WdBreakType.wdSectionBreakNextPage;
            object outputFile = outputFilename;
            object template = @"Normal.dot";

            try
            {
                // Create a new file based on our template
                MSWord.Document wordDocument = winword.Documents.Add(
                                                ref missing
                                                , ref missing
                                                , ref missing
                                                , ref missing);

                // Make a Word selection object.
                MSWord.Selection selection = winword.Selection;

                //Count the number of documents to insert;
                int documentCount = filesToMerge.Length;

                //A counter that signals that we shoudn't insert a page break at the end of document.
                int breakStop = 0;

                // Loop thru each of the Word documents
                foreach (string file in filesToMerge)
                {
                    breakStop++;
                    // Insert the files to our template
                    selection.InsertFile(
                                                file
                                            , ref missing
                                            , ref missing
                                            , ref missing
                                            , ref missing);

                    //Do we want page breaks added after each documents?
                    if (insertPageBreaks && breakStop != documentCount)
                    {
                        selection.InsertBreak(ref pageBreak);
                    }
                }

                // Save the document to it's output file.
                wordDocument.SaveAs(
                                ref outputFile
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing);

                // Clean up!
                wordDocument = null;
            }
            catch (Exception ex)
            {
                //I didn't include a default error handler so i'm just throwing the error
                throw ex;
            }
            finally
            {
                // Finally, Close our Word application
                winword.Quit(ref missing, ref missing, ref missing);
            }
        }

        private void ibuttonExportSQL_Click(object sender, EventArgs e)
        {
            int column = 1;
            string sqlInsert = "INSERT INTO tblWordMailMerge (ProjectID,";
            string sqlFields = "(@ProjectID,";

            var db = Program.GData.ChooseDB();
            db.EnableNamedParams = false;

            var row1 = MMvars.usedVariables.ToArray();
            foreach (var mmvar in row1)
            {
                string fieldName = mmvar.Value;
                sqlInsert += fieldName + ",";
                sqlFields += "@" + fieldName + ",";
                column++;
            }

            sqlInsert = sqlInsert.Substring(0,sqlInsert.Length - 1);
            sqlFields = sqlFields.Substring(0,sqlFields.Length - 1);

            string sql = sqlInsert + ") VALUES " + sqlFields + ")";
            List<object> args = new List<object>();
            args.Add(actualProject.ID);
            foreach (var mmvar in row1)
            {
                string fieldName = mmvar.Value;

                string varvalue = "";
                if (MMvars.mailMergeVars.ContainsKey(fieldName))
                {
                    varvalue = MMvars.mailMergeVars[fieldName];
                    args.Add(varvalue);
                }
                else
                {
                    args.Add("");
                }
                column++;
            }

            string sqlDelete = "DELETE FROM tblWordMailMerge WHERE ProjectID=@ProjectID";
            List<object> argsDelete= new List<object>();
            argsDelete.Add(actualProject.ID);
            db.Execute(sqlDelete, argsDelete.ToArray());

            db.Execute(sql, args.ToArray());
        }

        private void formWordTemplateEdit_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
        }

        private void SetStatus(string text)
        {
            labelStatus.Text = text;
            Application.DoEvents();
        }

        private void ibuttonPrev_Click(object sender, EventArgs e)
        {
            MMvars.mailMergeVarsIndex = MMvars.mailMergeVarsIndex - 1;
            FillList();
        }

        private void ibuttonNext_Click(object sender, EventArgs e)
        {
            MMvars.mailMergeVarsIndex = MMvars.mailMergeVarsIndex + 1;
            FillList();
        }
    }

}
