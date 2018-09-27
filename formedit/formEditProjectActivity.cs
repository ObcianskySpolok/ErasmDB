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
    public partial class formEditProjectActivity : Form
    {
        private modelProjectActivity originalData;
        private modelProjectActivity newData;
        public modelProjectActivity savedData;

        private int posX;
        private int posY;
        private int posW;
        private int posH;

        public formEditProjectActivity()
        {
            InitializeComponent();
        }

        public formEditProjectActivity(modelProjectActivity projectActivity)
        {
            InitializeComponent();

            originalData = new modelProjectActivity();
            originalData = projectActivity.DeepClone();
            newData = new modelProjectActivity();
            newData = projectActivity.DeepClone();
            savedData = null;

            ShowActivities();
            ShowData(originalData);
        }

        private void ShowData(modelProjectActivity projectActivity)
        {
            labelProject.Text = Program.GData.dataProject.getProjects.First(c => c.ID == projectActivity.ProjectID).Title;
            textTitle.Text = projectActivity.Title;
            textDuration.Text = projectActivity.Duration.ToString();
            comboActivities.Text = Program.GData.dataActivity.getActivityTypes.First(c => c.ID == projectActivity.ActivityID).ActivityType;
        }
        private void GetData(ref modelProjectActivity projectActivity)
        {
            projectActivity.Title = textTitle.Text;
            projectActivity.ActivityID = Program.GData.dataActivity.getActivityTypes.First(c => c.ActivityType == comboActivities.Text).ID;
            int duration;
            if (int.TryParse(textDuration.Text, out duration))
                projectActivity.Duration = duration;

        }
        private void ShowActivities()
        {
            comboActivities.Items.Clear();

            foreach (var act in Program.GData.dataActivity.getActivityTypes)
            {
                var item = comboActivities.Items.Add(act.ActivityType);
            }
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            if(!Program.Compare<modelProjectActivity>(originalData, newData))
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
            
            savedData = new modelProjectActivity();
            savedData = newData.DeepClone();
            this.Hide();
        }


    }
}
