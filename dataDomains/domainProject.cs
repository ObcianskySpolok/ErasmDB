using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace erasmDB
{
    class domainProject
    {
        IEnumerable<modelProject> tableProject;
        IEnumerable<modelProjectActivity> tableProjectActivity;
        IEnumerable<modelProjectVariation> tableProjectVariation;
        IEnumerable<modelProjectTopic> tableProjectTopic;
        IEnumerable<modelProjectVariationOrganization> tableProjectVariationOrganization;
        IEnumerable<modelProjectActivityVariation> tableProjectActivityVariation;

        PetaPoco.IDatabase db;
        PetaPoco.IDatabase db2;
        PetaPoco.IDatabase db3;
        PetaPoco.IDatabase db4;

        public void Update(modelProject project, bool reload = true)
        {
            if (project.CreatedDate.Year < 2000) project.CreatedDate = new DateTime(2000, 1, 1);
            project.UpdatedDate = DateTime.Now;
            db.Update("tblProject", "ID", project);
            if (reload) LoadProjects();
        }
        public void Write(modelProject project, bool reload = true)
        {
            db.Update("tblProject", "ID", project);
            if (reload) LoadProjects();
        }
        public void Insert(modelProject project, bool reload = true)
        {
            if(project.ID == 0)
            {
                project.ID = Program.GData.LongID();
                project.CreatedDate = DateTime.Now;
                project.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblProject", "ID", false, project);
            if (reload) LoadProjects();
        }
        public void Delete(modelProject project, bool reload = true)
        {   
            
            db.Delete("tblProject", "ID", project);
            if (reload) LoadProjects();
        }
        private void LoadProjects()
        {
            tableProject = db.Query<modelProject>("SELECT * FROM tblProject");
        }

        public void Update(modelProjectActivity projactivity, bool reload = true)
        {
            if (projactivity.CreatedDate.Year < 2000) projactivity.CreatedDate = new DateTime(2000, 1, 1);
            projactivity.UpdatedDate = DateTime.Now;
            db4.Update("tblProjectActivity", "ID", projactivity);
            if (reload) LoadProjectActivities();
        }
        public void Write(modelProjectActivity projactivity, bool reload = true)
        {
            db4.Update("tblProjectActivity", "ID", projactivity);
            if (reload) LoadProjectActivities();
        }
        public void Insert(modelProjectActivity projactivity, bool reload = true)
        {
            if(projactivity.ID == 0)
            {
                projactivity.ID = Program.GData.LongID();
                projactivity.CreatedDate = DateTime.Now;
                projactivity.UpdatedDate = DateTime.Now;
            }
            db4.Insert("tblProjectActivity", "ID", false, projactivity);
            if (reload) LoadProjectActivities();
        }
        public void Delete(modelProjectActivity projactivity, bool reload = true)
        {
            db4.Delete("tblProjectActivity", "ID", projactivity);
            if (reload) LoadProjectActivities();
        }
        private void LoadProjectActivities()
        {
            tableProjectActivity = db4.Query<modelProjectActivity>("SELECT * FROM tblProjectActivity");
        }

        public void Update(modelProjectVariation projectVariation, bool reload = true)
        {
            if (projectVariation.CreatedDate.Year < 2000) projectVariation.CreatedDate = new DateTime(2000, 1, 1);
            projectVariation.UpdatedDate = DateTime.Now;
            db.Update("tblProjectVariation", "ID", projectVariation);
            if (reload) LoadProjectVariations();
        }
        public void Write(modelProjectVariation projectVariation, bool reload = true)
        {
            db.Update("tblProjectVariation", "ID", projectVariation);
            if (reload) LoadProjectVariations();
        }
        public void Insert(modelProjectVariation projectVariation, bool reload = true)
        {
            if(projectVariation.ID == 0)
            {
                projectVariation.ID = Program.GData.LongID();
                projectVariation.CreatedDate = DateTime.Now;
                projectVariation.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblProjectVariation", "ID", false, projectVariation);
            if (reload) LoadProjectVariations();
        }
        public void Delete(modelProjectVariation projectVariation, bool reload = true)
        {
            db.Delete("tblProjectVariation", "ID", projectVariation);
            if (reload) LoadProjectVariations();
        }
        private void LoadProjectVariations()
        {
            tableProjectVariation = db.Query<modelProjectVariation>("SELECT * FROM tblProjectVariation");
        }

        public void Update(modelProjectVariationOrganization projectVariationOrg, bool reload=true)
        {
            if (projectVariationOrg.CreatedDate.Year < 2000) projectVariationOrg.CreatedDate = new DateTime(2000, 1, 1);
            projectVariationOrg.UpdatedDate = DateTime.Now;
            db3.Update("tblProjectVariationOrganization", "ID", projectVariationOrg);
            if (reload) LoadProjectVariationOrganizations();
        }
        public void Write(modelProjectVariationOrganization projectVariationOrg, bool reload = true)
        {
            db3.Update("tblProjectVariationOrganization", "ID", projectVariationOrg);
            if (reload) LoadProjectVariationOrganizations();
        }
        public void Insert(modelProjectVariationOrganization projectVariationOrg, bool reload = true)
        {
            if(projectVariationOrg.ID == 0)
            {
                projectVariationOrg.ID = Program.GData.LongID();
                projectVariationOrg.CreatedDate = DateTime.Now;
                projectVariationOrg.UpdatedDate = DateTime.Now;
            }
            db3.Insert("tblProjectVariationOrganization", "ID", false, projectVariationOrg);
            if (reload) LoadProjectVariationOrganizations();
        }
        public void Delete(modelProjectVariationOrganization projectVariationOrg, bool reload = true)
        {
            db3.Delete("tblProjectVariationOrganization", "ID", projectVariationOrg);
            if (reload) LoadProjectVariationOrganizations();
        }
        public void LoadProjectVariationOrganizations()
        {
            tableProjectVariationOrganization = db3.Query<modelProjectVariationOrganization>("SELECT * FROM tblProjectVariationOrganization");
        }

        public void Update(modelProjectTopic projectTopic, bool reload = true)
        {
            if (projectTopic.CreatedDate.Year < 2000) projectTopic.CreatedDate = new DateTime(2000, 1, 1);
            projectTopic.UpdatedDate = DateTime.Now;
            db.Update("tblProjectTopic", "ID", projectTopic);
            if (reload) LoadProjectTopics();
        }
        public void Write(modelProjectTopic projectTopic, bool reload = true)
        {
            db.Update("tblProjectTopic", "ID", projectTopic);
            if (reload) LoadProjectTopics();
        }
        public void Insert(modelProjectTopic projectTopic, bool reload = true)
        {
            if(projectTopic.ID == 0)
            {
                projectTopic.ID = Program.GData.LongID();
                projectTopic.CreatedDate = DateTime.Now;
                projectTopic.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblProjectTopic", "ID", false, projectTopic);
            if (reload) LoadProjectTopics();
        }
        public void Delete(modelProjectTopic projectTopic, bool reload = true)
        {
            db.Delete("tblProjectTopic", "ID", projectTopic);
            if (reload) LoadProjectTopics();
        }
        private void LoadProjectTopics()
        {
            tableProjectTopic = db.Query<modelProjectTopic>("SELECT * FROM tblProjectTopic");
        }


        public void Update(modelProjectActivityVariation activityvariation, bool reload = true)
        {
            if (activityvariation.CreatedDate.Year < 2000) activityvariation.CreatedDate = new DateTime(2000, 1, 1);
            activityvariation.UpdatedDate = DateTime.Now;
            db2.Update("tblProjectActivityVariation", "ID", activityvariation);
            if (reload) LoadProjectActivityVariations();
        }
        public void Write(modelProjectActivityVariation activityvariation, bool reload = true)
        {
            db2.Update("tblProjectActivityVariation", "ID", activityvariation);
            if (reload) LoadProjectActivityVariations();
        }
        public void Insert(modelProjectActivityVariation activityvariation, bool reload = true)
        {
            if(activityvariation.ID == 0)
            {
                activityvariation.ID = Program.GData.LongID();
                activityvariation.CreatedDate = DateTime.Now;
                activityvariation.UpdatedDate = DateTime.Now;
            }
            db2.Insert("tblProjectActivityVariation", "ID", false, activityvariation);
            if (reload) LoadProjectActivityVariations();
        }
        public void Delete(modelProjectActivityVariation activityvariation, bool reload = true)
        {
            db2.Delete("tblProjectActivityVariation", "ID", activityvariation);
            if (reload) LoadProjectActivityVariations();
        }
        private void LoadProjectActivityVariations()
        {
            tableProjectActivityVariation = db2.Query<modelProjectActivityVariation>("SELECT * FROM tblProjectActivityVariation");
        }

        public IEnumerable<modelProject> getProjects
        {
            get { return tableProject; }
        }
        public modelProject getProject(long ID)
        {
            return getProjects.First(c => c.ID == ID);
        }
        public IEnumerable<modelProjectActivity> getProjectActivities
        {
            get { return tableProjectActivity; }
        }
        public modelProjectActivity getProjectActivity(long ID)
        {
            if (ID == 0) return null;
            return getProjectActivities.First(c => c.ID == ID);
        }
        public IEnumerable<modelProjectVariation> getProjectVariations
        {
            get { return tableProjectVariation; }
        }
        public modelProjectVariation getProjectVariation(long ID)
        {
            return getProjectVariations.First(c => c.ID == ID);
        }
        public IEnumerable<modelProjectVariationOrganization> getProjectVariationOrganizations
        {
            get { return tableProjectVariationOrganization; }
        }
        public modelProjectVariationOrganization getProjectVariationOrganization(long ID)
        {
            return getProjectVariationOrganizations.First(c => c.ID == ID);
        }
        public IEnumerable<modelProjectTopic> getProjectTopics
        {
            get { return tableProjectTopic; }
        }
        public IEnumerable<modelProjectActivityVariation> getProjectActivityVariations
        {
            get { return tableProjectActivityVariation; }
        }
        public modelProjectActivityVariation getProjectActivityVariation(long ID)
        {
            return getProjectActivityVariations.First(c => c.ID == ID);
        }

        public void LoadData(bool? overideLocal = null)
        {
            db = Program.GData.ChooseDB(overideLocal);
            db2 = Program.GData.ChooseDB(overideLocal);
            db3 = Program.GData.ChooseDB(overideLocal);
            db4 = Program.GData.ChooseDB(overideLocal);

            LoadProjects();
            LoadProjectActivities();
            LoadProjectVariations();
            LoadProjectActivityVariations();
            LoadProjectTopics();
            LoadProjectVariationOrganizations();
        }

        public void DeleteProjectWithAllDetails(modelProject proj)
        {

            var variations = getProjectVariations.Where(c => c.ProjectID == proj.ID).Select(c => c.ID).ToArray(); 
            foreach(var variationID in variations)
            {
                DeleteProjectVaration(variationID);
            }

            var activities = getProjectActivities.Where(c => c.ProjectID == proj.ID).Select(c => c.ID).ToArray(); 
            foreach(var activity in activities)
            {
                db.Delete("tblProjectActivity", "ID",null, activity);
            }

            db.Delete("tblProject", "ID", null, proj.ID);
        }

        public void DeleteProjectVaration(long projvarID)
        {
            var projactvar = Program.GData.dataProject.getProjectVariations.First(c => c.ID == projvarID);

            var projorgs = getProjectVariationOrganizations.Where(c => c.ProjectVariation == projvarID).Select(c => c.ID).ToArray();
            foreach (var orgID in projorgs)
            {
                db.Delete("tblProjectVariationOrganization", "ID", null, orgID);
            }

            var projactvars = getProjectActivityVariations.Where(c => c.ProjectVariation == projvarID).Select(c => c.ID).ToArray();
            foreach (var actvarID in projactvars)
            {
                DeleteProjectVarationMobility(actvarID);
                db.Delete("tblProjectActivityVariation", "ID",null, actvarID);
            }
            db.Delete("tblProjectVariation", "ID",null, projvarID);            
        }

        public void DeleteProjectVarationMobility(long projvarID)
        {
            var mobilities = Program.GData.dataActivity.getMobilities.Where(c => c.ActivityVariation == projvarID).Select(c=>c.ID).ToArray();
            foreach(var mobID in mobilities)
            {
                db.Delete("tblMobility", "ID",null, mobID);
            }
        }

    }
}
