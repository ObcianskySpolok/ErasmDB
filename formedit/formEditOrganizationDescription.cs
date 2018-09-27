using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erasmDB.formedit
{
    public partial class formEditOrganizationDescription : Form
    {
        private modelOrganizationDescription originalData;
        private modelOrganizationDescription newData;
        public modelOrganizationDescription savedData;

        private int posX;
        private int posY;
        private int posW;
        private int posH;

        public formEditOrganizationDescription()
        {
            InitializeComponent();
        }

        public formEditOrganizationDescription(modelOrganizationDescription orgdesc)
        {
            InitializeComponent();

            originalData = new modelOrganizationDescription();
            originalData = orgdesc.DeepClone();
            newData = new modelOrganizationDescription();
            newData = orgdesc.DeepClone();
            savedData = null;

            ShowTypeOfOrganization();
            ShowData(originalData);
        }

        private void ShowData(modelOrganizationDescription orgdesc)
        {
            labelOrganization.Text = Program.GData.dataOrganization.getOrganizations.First(c => c.ID == orgdesc.Organization).LegalName;

            htmlBackgroundAndExperience.InnerHtml = orgdesc.BackgroundAndExperience;
            htmlBriefActivities.InnerHtml = orgdesc.BriefActivities;
            htmlBriefDescription.InnerHtml = orgdesc.BriefDescription;
            htmlStaffInvolved.InnerHtml = orgdesc.StaffInvolved;
            comboTypeOfOrganization.Text = Program.GData.dataLOV.getOrganizationTypes.First(c => c.ID == orgdesc.Type).OrganizationType;
        }
        private void GetData(ref modelOrganizationDescription orgdesc)
        {
            orgdesc.BackgroundAndExperience = htmlBackgroundAndExperience.InnerHtml;
            orgdesc.BriefActivities = htmlBriefActivities.InnerHtml;
            orgdesc.BriefDescription = htmlBriefDescription.InnerHtml;
            orgdesc.StaffInvolved = htmlStaffInvolved.InnerHtml;
            orgdesc.Type = Program.GData.dataLOV.getOrganizationTypes.First(c => c.OrganizationType == comboTypeOfOrganization.Text).ID;

        }
        private void ShowTypeOfOrganization()
        {
            comboTypeOfOrganization.Items.Clear();

            foreach (var org in Program.GData.dataLOV.getOrganizationTypes)
            {
                var item = comboTypeOfOrganization.Items.Add(org.OrganizationType);
            }
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            if(!Program.Compare<modelOrganizationDescription>(originalData, newData))
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

            savedData = new modelOrganizationDescription();
            savedData = newData.DeepClone();
            this.Hide();
        }

        private void ShowAllEditors(bool visibility)
        {
            UserControl[] panels = { htmlBriefDescription, htmlBriefActivities, htmlBackgroundAndExperience, htmlStaffInvolved };

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

            editor.Left = 116;
            editor.Top = 12;
            editor.Height = 400;

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

        private void ibuttonMaximizeBackground_Click(object sender, EventArgs e)
        {
            MaximizeHTML(htmlBackgroundAndExperience, ibuttonMaximizeBackground, ibuttonMinimizeBackground);
        }

        private void ibuttonMinimizeBackground_Click(object sender, EventArgs e)
        {
            MinimizeHTML(htmlBackgroundAndExperience, ibuttonMaximizeBackground, ibuttonMinimizeBackground);
        }
    }
}
