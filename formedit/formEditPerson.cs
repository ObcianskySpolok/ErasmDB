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
    public partial class formEditPerson : Form
    {
        private modelPerson originalData;
        private modelPerson newData;
        public modelPerson savedData;

        public formEditPerson()
        {
            InitializeComponent();
        }

        public formEditPerson(modelPerson person)
        {
            InitializeComponent();

            originalData = new modelPerson();
            originalData = person.DeepClone();
            newData = new modelPerson();
            newData = person.DeepClone();
            savedData = null;

            ShowRoles();
            ShowData(originalData);
        }

        private void ShowData(modelPerson person)
        {
            textTitle.Text = person.Title;
            textGender.Text = person.Gender;
            textFirstName.Text = person.FirstName;
            textLastname.Text = person.LastName;
            textEmail.Text = person.Email;
            textFacebook.Text = person.Facebook;
            textTelephone.Text = person.Telephone;
            listRole.Text = Program.GData.dataLOV.getRoles.First(c => c.ID == person.Role).Role;
        }
        private void GetData(ref modelPerson person)
        {
            person.Title = textTitle.Text;
            person.Gender = textGender.Text;
            person.FirstName = textFirstName.Text;
            person.LastName = textLastname.Text;
            person.Email = textEmail.Text;
            person.Facebook = textFacebook.Text;
            person.Telephone = textTelephone.Text;
            person.Role = Program.GData.dataLOV.getRoles.First(c => c.Role == listRole.Text).ID;
        }
        private void ShowRoles()
        {
            listRole.Items.Clear();

            foreach(var role in Program.GData.dataLOV.getRoles)
            {
                var item = listRole.Items.Add(role.Role);                
            }
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            GetData(ref newData);
            
            if(!Program.Compare<modelPerson>(originalData, newData))
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

            savedData = new modelPerson();
            savedData = newData.DeepClone();
            this.Hide();
        }
    }
}
