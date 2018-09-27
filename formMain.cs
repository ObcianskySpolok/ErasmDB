using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erasmDB
{
    public partial class formMain : Form
    {
        panels.panelOrganization panelOrganization  = new panels.panelOrganization();
        panels.panelPerson panelPerson = new panels.panelPerson();
        panels.panelProject panelProject = new panels.panelProject();
        panels.panelActivityType panelActivityType = new panels.panelActivityType();
        panels.panelRole panelRole = new panels.panelRole();
        panels.panelLanguage panelLanguage = new panels.panelLanguage();
        panels.panelDistanceBand panelDistanceBand = new panels.panelDistanceBand();
        panels.panelCountry panelCountry = new panels.panelCountry();
        panels.panelNationalAgency panelNationalAgency = new panels.panelNationalAgency();


        public formMain()
        {
            InitializeComponent();
            ShowConnection();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            labelVerzia.Text = Program.CurrentVersion;

            SetupPanel(panelOrganization);
            SetupPanel(panelPerson);
            SetupPanel(panelProject);
            SetupPanel(panelActivityType);
            SetupPanel(panelRole);
            SetupPanel(panelLanguage);
            SetupPanel(panelDistanceBand);
            SetupPanel(panelCountry);
            SetupPanel(panelNationalAgency);

            panelPerson.LoadData();
            panelOrganization.LoadData();
            panelProject.LoadData();
            panelActivityType.LoadData();
            panelRole.LoadData();
            panelLanguage.LoadData();
            panelDistanceBand.LoadData();
            panelCountry.LoadData();
            panelNationalAgency.LoadData();

            SwitchPanel(panelProject);
            SwitchButton(ibuttonProjects);

            if (Program.GData.CFGisAdmin)
            {
                ibuttonActivityTypes.Visible = true;
                ibuttonRoles.Visible = true;
                ibuttonNationalAgencies.Visible = true;
                ibuttonCountries.Visible = true;
                ibuttonDistanceBands.Visible = true;
                ibuttonLanguages.Visible = true;
            }
        }

        private void SetupPanel(UserControl panel)
        {
            panel.Left = 0;
            panel.Top = ibuttonProjects.Top + ibuttonProjects.Height;
            panel.Width = this.Width;
            panel.Height = this.Height - panel.Top;
            panel.Visible = false;
            this.Controls.Add(panel);
        }

        private void ibuttonPerson_Click(object sender, EventArgs e)
        {
            SwitchPanel(panelPerson);
            SwitchButton(ibuttonPerson);
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ibuttonOrganizations_Click(object sender, EventArgs e)
        {
            SwitchPanel(panelOrganization);
            SwitchButton(ibuttonOrganizations);
        }

        private void SwitchPanel(UserControl panelToShow)
        {
            UserControl[] panels = {
                panelOrganization, panelPerson, panelProject, 
                panelActivityType, panelRole, panelLanguage,
                panelDistanceBand, panelCountry, panelNationalAgency
            };

            foreach(var panel in panels)
            {
                if (panel.Equals(panelToShow))
                    panel.Visible = true;
                else
                    panel.Visible = false;
            }
        }
        private void SwitchButton(IconButton buttonToHighLight)
        {
            IconButton[] buttons = {
                ibuttonPerson, ibuttonOrganizations, ibuttonProjects,
                ibuttonActivityTypes, ibuttonRoles, ibuttonLanguages,
                ibuttonDistanceBands, ibuttonNationalAgencies, ibuttonCountries
            };

            foreach (var button in buttons)
            {
                if (button.Equals(buttonToHighLight))
                    button.InActiveColor = Color.Yellow;
                else
                    button.InActiveColor = Color.White;
            }
        }

        private void ibuttonProjects_Click(object sender, EventArgs e)
        {
            SwitchPanel(panelProject);
            SwitchButton(ibuttonProjects);
        }
        
        private void ibuttonActivityTypes_Click(object sender, EventArgs e)
        {
            SwitchPanel(panelActivityType);
            SwitchButton(ibuttonActivityTypes);
        }

        private void ibuttonRoles_Click(object sender, EventArgs e)
        {
            SwitchPanel(panelRole);
            SwitchButton(ibuttonRoles);
        }

        private void ibuttonLanguages_Click(object sender, EventArgs e)
        {
            SwitchPanel(panelLanguage);
            SwitchButton(ibuttonLanguages);
        }

        private void ibuttonDistanceBands_Click(object sender, EventArgs e)
        {
            SwitchPanel(panelDistanceBand);
            SwitchButton(ibuttonDistanceBands);
        }

        private void ibuttonNationalAgencies_Click(object sender, EventArgs e)
        {
            SwitchPanel(panelNationalAgency);
            SwitchButton(ibuttonNationalAgencies);
        }

        private void ibuttonCountries_Click(object sender, EventArgs e)
        {
            SwitchPanel(panelCountry);
            SwitchButton(ibuttonCountries);
        }

        private void ibuttonTemplateEditors_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = new formWordTemplateEdit();
            frm.ShowDialog();

            this.Show();
        }

        private void ibuttonSynchronize_Click(object sender, EventArgs e)
        {
            //this.Hide();

            var frm = new formSync();
            frm.ShowDialog();

            //this.Show();

        }

        private void ShowConnection()
        {
            switch (Program.GData.CFG_DB_USE)
            {
                case 0:
                    ibuttonConnection.IconTypeInt = 61705;
                    ibuttonConnection.Caption = "local database";
                    break;
                case 1:
                    ibuttonConnection.IconTypeInt = 61461;
                    ibuttonConnection.Caption = "standart server";
                    break;
                case 2:
                    ibuttonConnection.IconTypeInt = 61634;
                    ibuttonConnection.Caption = "azure database";
                    break;
            }
        }
    }
}
