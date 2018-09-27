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
using MSWord = Microsoft.Office.Interop.Word;

namespace erasmDB
{
    public partial class formMandate : Form
    {
        private modelProjectVariation projectVariation;
        //private modelProject project;
        private List<Dictionary<string, string>> mandateData;

        public formMandate(modelProjectVariation projVar)
        {
            InitializeComponent();

            SetStatus("");
            projectVariation = projVar;
            prepareMandateData();
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void prepareMandateData()
        {
            var applicant = Program.GData.dataOrganization.getOrganizations.First(c => c.ID == projectVariation.ApplicantOrganization);
            var agency = Program.GData.dataLOV.getNationalAgencies.First(c => c.ID == projectVariation.NationalAgency);
            IEnumerable<modelOrganization> partners = from orgs in Program.GData.dataOrganization.getOrganizations
                                                      join projvarorgs in Program.GData.dataProject.getProjectVariationOrganizations on orgs.ID equals projvarorgs.Organization
                                                      orderby projvarorgs.ID
                                                      where projvarorgs.ProjectVariation == projectVariation.ID
                                                      select orgs;

            mandateData = new List<Dictionary<string, string>>();
            foreach (var partner in partners)
            {
                var data = getMandateDataItem(projectVariation, applicant, partner, agency);
                mandateData.Add(data);
            }
        }

        private Dictionary<string,string> getMandateDataItem(modelProjectVariation projvar, modelOrganization applicant, modelOrganization partner, modelNationalAgency agency)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("[@PROJECTVARIATION-ProjectTitle]", projvar.getProjectTitle());
            data.Add("[@PROJECTVARIATION-Acronym]", projvar.Acronym);
            data.Add("[@PROJECTVARIATION-VariationTitle]", projvar.Title);

            data.Add("[@PARTNER-acronym]", partner.Acronym);
            data.Add("[@PARTNER-legal-name]", partner.LegalName);
            data.Add("[@PARTNER-legal-representative]", partner.Representative());
            data.Add("[@PARTNER-legal-status]", partner.LegalStatus);
            data.Add("[@PARTNER-registration-no]",partner.RegistrationNumber );
            data.Add("[@PARTNER-full-address]", partner.Address);
            data.Add("[@PARTNER-city]", partner.City);
            data.Add("[@PARTNER-country]", partner.getCountry());
            data.Add("[@PARTNER-country-code]", partner.getCountryCode());
            data.Add("[@APPLICANT-legal-name]", applicant.LegalName);
            data.Add("[@APPLICANT-acronym]", applicant.Acronym);
            data.Add("[@APPLICANT-legal-status]", applicant.LegalStatus);
            data.Add("[@APPLICANT-registration-no]", applicant.RegistrationNumber);
            data.Add("[@APPLICANT-full-address]", applicant.Address);
            data.Add("[@APPLICANT-country]", applicant.getCountry());
            data.Add("[@APPLICANT-country-code]", applicant.getCountryCode());
            data.Add("[@APPLICANT-legal-representative]", applicant.Representative());
            data.Add("[@APPLICANT-city]", applicant.City);
            data.Add("[@NATIONALAGENCY-AgencyName]", agency.AgencyName);
            data.Add("[@NATIONALAGENCY-Country]", agency.getCountry());

            return data;
        }

        private Dictionary<string,string> getDataSet(string[] fields, string[] values)
        {
            var data = new Dictionary<string, string>();

            if (fields.Count() == values.Count()) {
                for( int n=0; n<fields.Count(); n++)
                {
                    data.Add(fields[n], values[n]);
                }
            }

            return data;
        }

        // Helper
        private void searchAndReplaceInStory(MSWord.Range rngStory, string strSearch, string strReplace)
        {
            rngStory.Find.ClearFormatting();
            rngStory.Find.Replacement.ClearFormatting();
            rngStory.Find.Text = strSearch;
            rngStory.Find.Replacement.Text = strReplace;
            rngStory.Find.Wrap = MSWord.WdFindWrap.wdFindContinue;

            object Missing = System.Reflection.Missing.Value;

            object arg1 = Missing; // Find Pattern
            object arg2 = Missing; //MatchCase
            object arg3 = Missing; //MatchWholeWord
            object arg4 = Missing; //MatchWildcards
            object arg5 = Missing; //MatchSoundsLike
            object arg6 = Missing; //MatchAllWordForms
            object arg7 = Missing; //Forward
            object arg8 = Missing; //Wrap
            object arg9 = Missing; //Format
            object arg10 = Missing; //ReplaceWith
            object arg11 = MSWord.WdReplace.wdReplaceAll; //Replace
            object arg12 = Missing; //MatchKashida
            object arg13 = Missing; //MatchDiacritics
            object arg14 = Missing; //MatchAlefHamza
            object arg15 = Missing; //MatchControl

            try
            {
                rngStory.Find.Execute(ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6, ref arg7, ref arg8, ref arg9, ref arg10, ref arg11, ref arg12, ref arg13, ref arg14, ref arg15);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Main routine to find text and replace it,
        //   var app = new Microsoft.Office.Interop.Word.Application();
        //public void FindReplaceAnywhere(MSWord.Document doc, string findText, string replaceText)
        public void FindReplaceAnywhere(MSWord.Document doc, Dictionary<string,string> searchAndReplace)
        {
            // Fix the skipped blank Header/Footer problem
            //    http://msdn.microsoft.com/en-us/library/aa211923(office.11).aspx
            MSWord.WdStoryType lngJunk = doc.Sections[1].Headers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.StoryType;

            // Iterate through all story types in the current document
            foreach (Microsoft.Office.Interop.Word.Range rngStory in doc.StoryRanges)
            {

                // Iterate through all linked stories
                var internalRangeStory = rngStory;

                do
                {
                    foreach(var srch in searchAndReplace)
                    {
                        string findText = srch.Key;
                        string replaceText = srch.Value;
                        searchAndReplaceInStory(internalRangeStory, findText, replaceText);

                        try
                        {
                            //   6 , 7 , 8 , 9 , 10 , 11 -- http://msdn.microsoft.com/en-us/library/aa211923(office.11).aspx
                            switch (internalRangeStory.StoryType)
                            {
                                case MSWord.WdStoryType.wdEvenPagesHeaderStory: // 6
                                case MSWord.WdStoryType.wdPrimaryHeaderStory:   // 7
                                case MSWord.WdStoryType.wdEvenPagesFooterStory: // 8
                                case MSWord.WdStoryType.wdPrimaryFooterStory:   // 9
                                case MSWord.WdStoryType.wdFirstPageHeaderStory: // 10
                                case MSWord.WdStoryType.wdFirstPageFooterStory: // 11

                                    if (internalRangeStory.ShapeRange.Count > 0)
                                    {
                                        foreach (Microsoft.Office.Interop.Word.Shape oShp in internalRangeStory.ShapeRange)
                                        {
                                            if (oShp.TextFrame.HasText != 0)
                                            {
                                                searchAndReplaceInStory(oShp.TextFrame.TextRange, findText, replaceText);
                                            }
                                        }
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                        catch
                        {
                            // On Error Resume Next
                        }

                    }
                    // Get next linked story (if any)
                    internalRangeStory = internalRangeStory.NextStoryRange;

                } while (internalRangeStory != null);
            }

        }

        private void InsertDataPage(ref MSWord.Application winword, ref MSWord.Document newdoc, string fileNameTemplate, Dictionary<string,string> dataToInsert, Boolean lastPage)
        {
            winword.Selection.InsertFile(fileNameTemplate);

            FindReplaceAnywhere(newdoc, dataToInsert);

            //foreach( var data in dataToInsert)
            //    searchAndReplaceInStory(newdoc.Range(), data.Key, data.Value);
            
            var selection = winword.Selection;
            newdoc.Characters.Last.Select();  // Line 1                
            winword.Selection.Collapse();
            if(!lastPage)
                winword.Selection.InsertBreak(MSWord.WdBreakType.wdSectionBreakNextPage);

        }

        private void ProcessIntoSingleFile(string fileNameTemplate)
        {
            SetStatus("Choose output folder");
            string outputFolder;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath)) return;
                outputFolder = fbd.SelectedPath;
            }

            var firstpage = mandateData[0];
            string projtitle = firstpage["[@PROJECTVARIATION-ProjectTitle]"];
            string varacronym = firstpage["[@PROJECTVARIATION-Acronym]"];

            string nameTemplate = projtitle + "-" + varacronym;
            string nameTo = nameTemplate + ".docx";
            string nameToPDF = nameTemplate + ".pdf";
            string fileNameTo = outputFolder + "\\" + nameTo;
            string fileNameToPDF = outputFolder + "\\" + nameToPDF;

            SetStatus("Preparing MS Word");
            var winword = new MSWord.Application();
            MSWord.Document docTemplate = null;
            MSWord.Document docNew = null;

            winword.ShowAnimation = false;
            winword.Visible = true;
            object missing = System.Reflection.Missing.Value;

            try
            {
                docNew = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                int n = 1;
                foreach(var pageData in mandateData)
                {
                    bool lastpage = pageData.Equals(mandateData.Last());
                    SetStatus("Creating mandate: " + "[" + n.ToString() + "/" + mandateData.Count() + "]" + pageData["[@PARTNER-legal-name]"]);
                    InsertDataPage(ref winword, ref docNew, fileNameTemplate, pageData,lastpage);
                    n++;
                }
                winword.Selection.TypeBackspace();
                SetStatus("Saving...");
                docNew.SaveAs(fileNameTo);
                docNew.SaveAs2(fileNameToPDF, MSWord.WdSaveFormat.wdFormatPDF);
                SetStatus("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                if (docTemplate != null)
                    docTemplate.Close(false);

                if (docNew != null)
                    docNew.Close();

                if (winword != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(winword);

                winword = null;
                docTemplate = null;
                docNew = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            SetStatus("");
        }


        private void ProcessIntoMultipleFiles(string fileNameTemplate)
        {
            var firstpage = mandateData[0];
            string projtitle = firstpage["[@PROJECTVARIATION-ProjectTitle]"];
            string varacronym = firstpage["[@PROJECTVARIATION-Acronym]"];

            string nameTemplate = projtitle + "-" + varacronym + "-{0}";
            string nameTo = nameTemplate + ".docx";
            string nameToPDF = nameTemplate + ".pdf";

            MSWord.Document docNew = null;

            SetStatus("Choose output folder");
            string outputFolder;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath)) return;
                outputFolder = fbd.SelectedPath;
            }

            string fileNameTo = outputFolder + "\\" + nameTo;
            string fileNameToPDF = outputFolder + "\\" + nameToPDF;

            SetStatus("Preparing MS Word");
            var winword = new MSWord.Application();
            winword.ShowAnimation = false;
            winword.Visible = true;
            object missing = System.Reflection.Missing.Value;

            try
            {
                int n = 1;
                foreach (var pageData in mandateData)
                {
                    string partner = pageData["[@PARTNER-acronym]"];

                    SetStatus("Creating mandate: " + "[" + n.ToString() + "/" + mandateData.Count() + "]" + pageData["[@PARTNER-legal-name]"]);

                    docNew = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                    InsertDataPage(ref winword, ref docNew, fileNameTemplate, pageData, true);
                    
                    docNew.SaveAs(String.Format(fileNameTo, partner));
                    docNew.SaveAs2(String.Format(fileNameToPDF, partner), MSWord.WdSaveFormat.wdFormatPDF);
                    docNew.Close();
                    docNew = null;

                    n++;
                }
                SetStatus("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                if (docNew != null)
                    docNew.Close();

                if (winword != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(winword);

                winword = null;
                
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            SetStatus("");
        }
        private void buttonSelectTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Select Mandate template";
            theDialog.Filter = "Word files|*.docx";
            theDialog.InitialDirectory = @"C:\temp";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                textTemplate.Text = theDialog.FileName.ToString();
            }
        }

        private void ibuttonSignSingle_Click(object sender, EventArgs e)
        {
            prepareMandateData();
            ProcessIntoSingleFile(textTemplate.Text);
            this.Hide();
        }

        private void ibuttonSignMultiple_Click(object sender, EventArgs e)
        {
            prepareMandateData();
            ProcessIntoMultipleFiles(textTemplate.Text);
            this.Hide();

        }

        private void SetStatus(string status)
        {
            labelStatus.Text = status;
        }
    }
}
