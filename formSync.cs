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

    public partial class formSync: Form
    {

        domainPerson local_dataPerson;
        domainPerson sql_dataPerson;

        domainOrganization local_dataOrganization;
        domainOrganization sql_dataOrganization;

        domainListOfValues local_dataLOV;
        domainListOfValues sql_dataLOV;

        domainProject local_dataProject;
        domainProject sql_dataProject;

        domainActivity local_dataActivity;
        domainActivity sql_dataActivity;


        tableChanges<modelLanguage> changedLanguages;
        tableChanges<modelCountry> changedCountries;
        tableChanges<modelDistanceBand> changedDistBands;
        tableChanges<modelNationalAgency> changedNatAgencies;
        tableChanges<modelOrganizationType> changedOrgTypes;
        tableChanges<modelRole> changedRoles;
        tableChanges<modelTopic> changedTopics;
        tableChanges<modelPerson> changedPerson;
        tableChanges<modelOrganization> changedOrganization;
        tableChanges<modelProjectActivity> changedProjectActivity;
        tableChanges<modelProjectActivityVariation> changedProjActVariation;
        tableChanges<modelProject> changedProjects;
        tableChanges<modelProjectTopic> changedProjTopics;
        tableChanges<modelProjectVariationOrganization> changedProjVariationOrg;
        tableChanges<modelProjectVariation> changedProjVariation;
        tableChanges<modelActivityType> changedActivityTypes;
        tableChanges<modelMobility> changedMobility;
        tableChanges<modelClient> changedClients;

        IEnumerable<ChangesInfo> allChanges;

        public formSync()
        {
            InitializeComponent();

        }

        private void LoadAll()
        {
            local_dataLOV = new domainListOfValues();
            local_dataLOV.LoadData(true);
            sql_dataLOV = new domainListOfValues();
            sql_dataLOV.LoadData(false);
            ProgressBarAdd();

            local_dataPerson = new domainPerson();
            local_dataPerson.LoadData(true);
            sql_dataPerson = new domainPerson();
            sql_dataPerson.LoadData(false);
            ProgressBarAdd();

            local_dataOrganization = new domainOrganization();
            local_dataOrganization.LoadData(true);
            sql_dataOrganization = new domainOrganization();
            sql_dataOrganization.LoadData(false);
            ProgressBarAdd();

            local_dataProject = new domainProject();
            local_dataProject.LoadData(true);
            sql_dataProject = new domainProject();
            sql_dataProject.LoadData(false);
            ProgressBarAdd();

            local_dataActivity = new domainActivity();
            local_dataActivity.LoadData(true);
            sql_dataActivity = new domainActivity();
            sql_dataActivity.LoadData(false);
            ProgressBarAdd();
        }

        private void ibuttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }



        private void ibuttonRefresh_Click(object sender, EventArgs e)
        {
            SetProgressBar(5+17+17);
            LoadAll();
            LoadChanges();
            PrepareChanges();
            LoadChangesGrid();

            ibuttonNew2SQL.Caption = ibuttonNew2SQL.Tag + " (" + allChanges.Count(c => c.newAccess == true) + ")";
            ibuttonNew2Access.Caption = ibuttonNew2Access.Tag + " (" + allChanges.Count(c => c.newSQL == true) + ")";
            ibuttonWriteChanges.Caption = ibuttonWriteChanges.Tag + " (" + allChanges.Count(c => c.newSQL == false && c.newAccess == false) + ")";
        }

        private void ibuttonCleanData_Click(object sender, EventArgs e)
        {
            SetProgressBar(5+16+5+16+16+16);

            SetStatus("Load data");
            LoadAll();
            SetStatus("clean local database");
            CleanAccessDB();
            SetStatus("reload data");
            LoadAll();
            SetStatus("load changes");
            LoadChanges();
            SetStatus("write data to local database");
            WriteNewToLocal();
            SetStatus("");
            SetProgressBar(0);
        }

        private void CleanAccessDB()
        {
            CleanLocalDB(local_dataLOV.getCountries, (toDel => { local_dataLOV.Delete(toDel, false); }));
            CleanLocalDB(local_dataLOV.getDistanceBands, (toDel => { local_dataLOV.Delete(toDel, false); }));
            CleanLocalDB(local_dataLOV.getLanguages, (toDel => { local_dataLOV.Delete(toDel, false); }));
            CleanLocalDB(local_dataLOV.getNationalAgencies, (toDel => { local_dataLOV.Delete(toDel, false); }));
            CleanLocalDB(local_dataLOV.getOrganizationTypes, (toDel => { local_dataLOV.Delete(toDel, false); }));
            CleanLocalDB(local_dataLOV.getRoles, (toDel => { local_dataLOV.Delete(toDel, false); }));
            CleanLocalDB(local_dataLOV.getTopics, (toDel => { local_dataLOV.Delete(toDel, false); }));
            local_dataLOV.LoadData();

            CleanLocalDB(local_dataPerson.getPersons, (toDel => { local_dataPerson.Delete(toDel, false); }));
            local_dataPerson.LoadData();

            CleanLocalDB(local_dataOrganization.getOrganizations, (toDel => { local_dataOrganization.Delete(toDel, false); }));
            local_dataOrganization.LoadData();

            CleanLocalDB(local_dataProject.getProjectActivities, (toDel => { local_dataProject.Delete(toDel, false); }));
            CleanLocalDB(local_dataProject.getProjectActivityVariations, (toDel => { local_dataProject.Delete(toDel, false); }));
            CleanLocalDB(local_dataProject.getProjects, (toDel => { local_dataProject.Delete(toDel, false); }));
            CleanLocalDB(local_dataProject.getProjectTopics, (toDel => { local_dataProject.Delete(toDel, false); }));
            CleanLocalDB(local_dataProject.getProjectVariationOrganizations, (toDel => { local_dataProject.Delete(toDel, false); }));
            CleanLocalDB(local_dataProject.getProjectVariations, (toDel => { local_dataProject.Delete(toDel, false); }));
            local_dataProject.LoadData();

            CleanLocalDB(local_dataActivity.getActivityTypes, (toDel => { local_dataActivity.Delete(toDel, false); }));
            CleanLocalDB(local_dataActivity.getMobilities, (toDel => { local_dataActivity.Delete(toDel, false); }));
            local_dataActivity.LoadData();

        }
        private void LoadChanges()
        {
            changedLanguages = new tableChanges<modelLanguage>(sql_dataLOV.getLanguages, local_dataLOV.getLanguages);
            ProgressBarAdd();
            changedCountries = new tableChanges<modelCountry>(sql_dataLOV.getCountries, local_dataLOV.getCountries);
            ProgressBarAdd();
            changedDistBands = new tableChanges<modelDistanceBand>(sql_dataLOV.getDistanceBands, local_dataLOV.getDistanceBands);
            ProgressBarAdd();
            changedNatAgencies = new tableChanges<modelNationalAgency>(sql_dataLOV.getNationalAgencies, local_dataLOV.getNationalAgencies);
            ProgressBarAdd();
            changedOrgTypes = new tableChanges<modelOrganizationType>(sql_dataLOV.getOrganizationTypes, local_dataLOV.getOrganizationTypes);
            ProgressBarAdd();
            changedRoles = new tableChanges<modelRole>(sql_dataLOV.getRoles, local_dataLOV.getRoles);
            ProgressBarAdd();
            changedTopics = new tableChanges<modelTopic>(sql_dataLOV.getTopics, local_dataLOV.getTopics);
            ProgressBarAdd();
            changedClients= new tableChanges<modelClient>(sql_dataLOV.getClients, local_dataLOV.getClients);
            ProgressBarAdd();

            changedPerson = new tableChanges<modelPerson>(sql_dataPerson.getPersons, local_dataPerson.getPersons);
            ProgressBarAdd();

            changedOrganization = new tableChanges<modelOrganization>(sql_dataOrganization.getOrganizations, local_dataOrganization.getOrganizations);
            ProgressBarAdd();

            changedProjectActivity = new tableChanges<modelProjectActivity>(sql_dataProject.getProjectActivities, local_dataProject.getProjectActivities);
            ProgressBarAdd();
            changedProjActVariation = new tableChanges<modelProjectActivityVariation>(sql_dataProject.getProjectActivityVariations, local_dataProject.getProjectActivityVariations);
            ProgressBarAdd();
            changedProjects = new tableChanges<modelProject>(sql_dataProject.getProjects, local_dataProject.getProjects);
            ProgressBarAdd();
            changedProjTopics = new tableChanges<modelProjectTopic>(sql_dataProject.getProjectTopics, local_dataProject.getProjectTopics);
            ProgressBarAdd();
            changedProjVariationOrg = new tableChanges<modelProjectVariationOrganization>(sql_dataProject.getProjectVariationOrganizations, local_dataProject.getProjectVariationOrganizations);
            ProgressBarAdd();
            changedProjVariation = new tableChanges<modelProjectVariation>(sql_dataProject.getProjectVariations, local_dataProject.getProjectVariations);
            ProgressBarAdd();

            changedActivityTypes = new tableChanges<modelActivityType>(sql_dataActivity.getActivityTypes, local_dataActivity.getActivityTypes);
            ProgressBarAdd();
            changedMobility = new tableChanges<modelMobility>(sql_dataActivity.getMobilities, local_dataActivity.getMobilities);
            ProgressBarAdd();



        }
        private void PrepareChanges()
        {
            allChanges = changedLanguages.GetChangedData;
            allChanges = changedLanguages.GetNewData;
            ProgressBarAdd();
            allChanges = allChanges.Concat(changedCountries.GetChangedData);
            allChanges = allChanges.Concat(changedCountries.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(changedDistBands.GetChangedData);
            allChanges = allChanges.Concat(changedDistBands.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(changedNatAgencies.GetChangedData);
            allChanges = allChanges.Concat(changedNatAgencies.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(changedOrgTypes.GetChangedData);
            allChanges = allChanges.Concat(changedOrgTypes.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(changedActivityTypes.GetChangedData);
            allChanges = allChanges.Concat(changedActivityTypes.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(changedRoles.GetChangedData);
            allChanges = allChanges.Concat(changedRoles.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(changedTopics.GetChangedData);
            allChanges = allChanges.Concat(changedTopics.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(changedClients.GetChangedData);
            allChanges = allChanges.Concat(changedClients.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(changedPerson.GetChangedData);
            allChanges = allChanges.Concat(changedPerson.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(changedOrganization.GetChangedData);
            allChanges = allChanges.Concat(changedOrganization.GetNewData);
            ProgressBarAdd();

            allChanges = allChanges.Concat(changedProjects.GetChangedData);
            allChanges = allChanges.Concat(changedProjects.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(GetChangedData(changedProjectActivity));
            allChanges = allChanges.Concat(changedProjectActivity.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(GetChangedData(changedProjVariation));
            allChanges = allChanges.Concat(changedProjVariation.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(GetChangedData(changedProjActVariation));
            allChanges = allChanges.Concat(changedProjActVariation.GetNewData);
            ProgressBarAdd();
            allChanges = allChanges.Concat(GetChangedData(changedProjVariationOrg));
            allChanges = allChanges.Concat(changedProjVariationOrg.GetNewData);
            ProgressBarAdd();

            allChanges = allChanges.Concat(GetChangedData(changedMobility));
            allChanges = allChanges.Concat(changedMobility.GetNewData);
            ProgressBarAdd();

            allChanges = allChanges.Concat(changedProjTopics.GetChangedData);
            allChanges = allChanges.Concat(changedProjTopics.GetNewData);
            ProgressBarAdd();
        }

        private void WriteNewToLocal()
        {
            WriteNewItems(changedLanguages.newSQLIDs, sql_dataLOV.getLanguages, (toInsert => { local_dataLOV.Insert(toInsert, false); }));
            WriteNewItems(changedCountries.newSQLIDs, sql_dataLOV.getCountries, (toInsert => { local_dataLOV.Insert(toInsert, false); }));
            WriteNewItems(changedDistBands.newSQLIDs, sql_dataLOV.getDistanceBands, (toInsert => { local_dataLOV.Insert(toInsert, false); }));
            WriteNewItems(changedNatAgencies.newSQLIDs, sql_dataLOV.getNationalAgencies, (toInsert => { local_dataLOV.Insert(toInsert, false); }));
            WriteNewItems(changedOrgTypes.newSQLIDs, sql_dataLOV.getOrganizationTypes, (toInsert => { local_dataLOV.Insert(toInsert, false); }));
            WriteNewItems(changedRoles.newSQLIDs, sql_dataLOV.getRoles, (toInsert => { local_dataLOV.Insert(toInsert, false); }));
            WriteNewItems(changedTopics.newSQLIDs, sql_dataLOV.getTopics, (toInsert => { local_dataLOV.Insert(toInsert, false); }));

            WriteNewItems(changedPerson.newSQLIDs, sql_dataPerson.getPersons, (toInsert => { local_dataPerson.Insert(toInsert, false); }));

            WriteNewItems(changedOrganization.newSQLIDs, sql_dataOrganization.getOrganizations, (toInsert => { local_dataOrganization.Insert(toInsert, false); }));

            WriteNewItems(changedProjectActivity.newSQLIDs, sql_dataProject.getProjectActivities, (toInsert => { local_dataProject.Insert(toInsert, false); }));
            WriteNewItems(changedProjActVariation.newSQLIDs, sql_dataProject.getProjectActivityVariations, (toInsert => { local_dataProject.Insert(toInsert, false); }));
            WriteNewItems(changedProjects.newSQLIDs, sql_dataProject.getProjects, (toInsert => { local_dataProject.Insert(toInsert, false); }));
            WriteNewItems(changedProjTopics.newSQLIDs, sql_dataProject.getProjectTopics, (toInsert => { local_dataProject.Insert(toInsert, false); }));
            WriteNewItems(changedProjVariationOrg.newSQLIDs, sql_dataProject.getProjectVariationOrganizations, (toInsert => { local_dataProject.Insert(toInsert, false); }));
            WriteNewItems(changedProjVariation.newSQLIDs, sql_dataProject.getProjectVariations, (toInsert => { local_dataProject.Insert(toInsert, false); }));


            WriteNewItems(changedActivityTypes.newSQLIDs, sql_dataActivity.getActivityTypes, (toInsert => { local_dataActivity.Insert(toInsert, false); }));
            WriteNewItems(changedMobility.newSQLIDs, sql_dataActivity.getMobilities, (toInsert => { local_dataActivity.Insert(toInsert, false); }));
        }
        private void WriteNewToSQL()
        {
            WriteNewItems(changedLanguages.newLocalIDs, local_dataLOV.getLanguages, (toInsert => { sql_dataLOV.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedCountries.newLocalIDs, local_dataLOV.getCountries, (toInsert => { sql_dataLOV.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedDistBands.newLocalIDs, local_dataLOV.getDistanceBands, (toInsert => { sql_dataLOV.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedNatAgencies.newLocalIDs, local_dataLOV.getNationalAgencies, (toInsert => { sql_dataLOV.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedOrgTypes.newLocalIDs, local_dataLOV.getOrganizationTypes, (toInsert => { sql_dataLOV.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedRoles.newLocalIDs, local_dataLOV.getRoles, (toInsert => { sql_dataLOV.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedTopics.newLocalIDs, local_dataLOV.getTopics, (toInsert => { sql_dataLOV.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedClients.newLocalIDs, local_dataLOV.getClients, (toInsert => { sql_dataLOV.Insert(toInsert, false); }));
            ProgressBarAdd();

            WriteNewItems(changedPerson.newLocalIDs, local_dataPerson.getPersons, (toInsert => { sql_dataPerson.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedOrganization.newLocalIDs, local_dataOrganization.getOrganizations, (toInsert => { sql_dataOrganization.Insert(toInsert, false); }));
            ProgressBarAdd();

            WriteNewItems(changedProjectActivity.newLocalIDs, local_dataProject.getProjectActivities, (toInsert => { sql_dataProject.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedProjActVariation.newLocalIDs, local_dataProject.getProjectActivityVariations, (toInsert => { sql_dataProject.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedProjects.newLocalIDs, local_dataProject.getProjects, (toInsert => { sql_dataProject.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedProjTopics.newLocalIDs, local_dataProject.getProjectTopics, (toInsert => { sql_dataProject.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedProjVariationOrg.newLocalIDs, local_dataProject.getProjectVariationOrganizations, (toInsert => { sql_dataProject.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedProjVariation.newLocalIDs, local_dataProject.getProjectVariations, (toInsert => { sql_dataProject.Insert(toInsert, false); }));
            ProgressBarAdd();

            WriteNewItems(changedActivityTypes.newLocalIDs, local_dataActivity.getActivityTypes, (toInsert => { sql_dataActivity.Insert(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedMobility.newLocalIDs, local_dataActivity.getMobilities, (toInsert => { sql_dataActivity.Insert(toInsert, false); }));
            ProgressBarAdd();
        }
        private void WriteNewToAccess()
        {
            WriteNewItems(changedLanguages.newSQLIDs, sql_dataLOV.getLanguages, (toInsert => { local_dataLOV.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedCountries.newSQLIDs, sql_dataLOV.getCountries, (toInsert => { local_dataLOV.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedDistBands.newSQLIDs, sql_dataLOV.getDistanceBands, (toInsert => { local_dataLOV.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedNatAgencies.newSQLIDs, sql_dataLOV.getNationalAgencies, (toInsert => { local_dataLOV.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedOrgTypes.newSQLIDs, sql_dataLOV.getOrganizationTypes, (toInsert => { local_dataLOV.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedRoles.newSQLIDs, sql_dataLOV.getRoles, (toInsert => { local_dataLOV.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedTopics.newSQLIDs, sql_dataLOV.getTopics, (toInsert => { local_dataLOV.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedClients.newSQLIDs, sql_dataLOV.getClients, (toInsert => { local_dataLOV.Insert(toInsert, false); }));
            ProgressBarAdd();

            WriteNewItems(changedPerson.newSQLIDs, sql_dataPerson.getPersons, (toInsert => { local_dataPerson.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedOrganization.newSQLIDs, sql_dataOrganization.getOrganizations, (toInsert => { local_dataOrganization.Insert(toInsert, false); }));
            ProgressBarAdd();

            WriteNewItems(changedProjectActivity.newSQLIDs, sql_dataProject.getProjectActivities, (toInsert => { local_dataProject.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedProjActVariation.newSQLIDs, sql_dataProject.getProjectActivityVariations, (toInsert => { local_dataProject.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedProjects.newSQLIDs, sql_dataProject.getProjects, (toInsert => { local_dataProject.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedProjTopics.newSQLIDs, sql_dataProject.getProjectTopics, (toInsert => { local_dataProject.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedProjVariationOrg.newSQLIDs, sql_dataProject.getProjectVariationOrganizations, (toInsert => { local_dataProject.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedProjVariation.newSQLIDs, sql_dataProject.getProjectVariations, (toInsert => { local_dataProject.Write(toInsert, false); }));
            ProgressBarAdd();

            WriteNewItems(changedActivityTypes.newSQLIDs, sql_dataActivity.getActivityTypes, (toInsert => { local_dataActivity.Write(toInsert, false); }));
            ProgressBarAdd();
            WriteNewItems(changedMobility.newSQLIDs, sql_dataActivity.getMobilities, (toInsert => { local_dataActivity.Write(toInsert, false); }));
            ProgressBarAdd();
        }
        private void SetProgressBar(int steps)
        {
            if (steps > 0)
            {
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = steps;
                progressBar1.Visible = true;
            }
            else
            {
                progressBar1.Visible = false;
            }
        }
        private void ProgressBarAdd()
        {
            if(progressBar1.Value < progressBar1.Maximum)
                progressBar1.Value = progressBar1.Value+1;
        }
        private void SetStatus(string status)
        {
            labelStatus.Text = status;
        }
        private void WriteNewItems<T>(long[] ids, IEnumerable<T> dSQL, Action<T> insertLocalAction) where T : modelData
        {
            foreach (long id in ids)
            {
                var item = dSQL.First(c => c.ID == id);
                insertLocalAction(item);
            }
            ProgressBarAdd();
        }
        private void CleanLocalDB<T>(IEnumerable<T> dSQL, Action<T> deleteAction) where T : modelData
        {
            var ids = dSQL.Select(c => c.ID).ToArray();

            foreach(long id in ids)
            {
                var item = dSQL.First(c => c.ID == id);
                deleteAction(item);
                
            }
            ProgressBarAdd();
        }

        private void ibuttonNew2SQL_Click(object sender, EventArgs e)
        {
            SetProgressBar(32);
            SetStatus("write data to SQL server");
            WriteNewToSQL();
            SetStatus("");
            SetProgressBar(0);
        }

        private void LoadChangesGrid()
        {
            gridChanges.SetupLinq += GridChanges_SetupLinq;
            gridChanges.SetupGrid += GridChanges_SetupGrid;
            gridChanges.LoadGrid();
        }
        private void GridChanges_SetupGrid()
        {
            var fntHeadline = new Font("Segoe UI Light", 14);
            var fntNormal = new Font("Segoe UI Light", 12);
            var fntSmaller = new Font("Segoe UI Light", 10);

            gridChanges.ColumnHeadersDefaultCellStyle.Font = fntHeadline;
            gridChanges.DefaultCellStyle.Font = fntNormal;

            //gridChanges.Columns["StartDate"].DefaultCellStyle.Font = fntSmaller;

            gridChanges.Columns["ID"].Visible = false;

            //gridChanges.Columns["ID"].Width = 80;
            gridChanges.Columns["Abbrev"].Width = 220;
            gridChanges.Columns["DescriptionAccess"].Width = 300;
            gridChanges.Columns["DescriptionSQL"].Width = 300;

            //gridChanges.Columns["Acronym"].Width = 100;
            //gridChanges.Columns["StartDate"].Width = 100;
            //gridChanges.Columns["EndDate"].Width = 100;
            //gridChanges.Columns["Duration"].Width = 80;

            gridChanges.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private IEnumerable<object> GridChanges_SetupLinq(string filter)
        {
            var od = (from changes in allChanges
                        select new
                        {
                            changes.ID,
                            changes.Abbrev,
                            changes.DescriptionAccess,
                            changes.DescriptionSQL,
                            changes.TimeChangedAccess,
                            changes.TimeChangeSQL,
                            changes.syncAccessToSQL,
                            changes.newAccess,
                            changes.newSQL
                        });

            if (od == null) return null;

            return od.ToArray();
        }

        private List<ChangesInfo> GetChangedData(tableChanges<modelProjectActivity> changes)
        {
            var changeInfos = new List<ChangesInfo>();
            foreach (long changedid in changes.changedIDs)
            {

                var objacc = local_dataProject.getProjectActivity(changedid);
                var objsql = sql_dataProject.getProjectActivity(changedid);

                var prjacc = local_dataProject.getProject(objacc.ProjectID);
                var prjsql = sql_dataProject.getProject(objsql.ProjectID);

                string acc_desc = prjacc.GetTitleInfo() + " / " + objacc.Title;
                string sql_desc = prjsql.GetTitleInfo() + " / " + objsql.Title;

                var inf = new ChangesInfo(changedid, "Project Activity", acc_desc, sql_desc, objacc.UpdatedDate, objsql.UpdatedDate, objacc.UpdatedDate > objsql.UpdatedDate,false,false);
                changeInfos.Add(inf);
            }
            return changeInfos;

        }
        private List<ChangesInfo> GetChangedData(tableChanges<modelProjectVariation> changes)
        {
            var changeInfos = new List<ChangesInfo>();
            foreach (long changedid in changes.changedIDs)
            {

                var objacc = local_dataProject.getProjectVariation(changedid);
                var objsql = sql_dataProject.getProjectVariation(changedid);

                var prjacc = local_dataProject.getProject(objacc.ProjectID);
                var prjsql = sql_dataProject.getProject(objsql.ProjectID);

                string acc_desc = prjacc.GetTitleInfo() + " / " + objacc.Title;
                string sql_desc = prjsql.GetTitleInfo() + " / " + objsql.Title;

                var inf = new ChangesInfo(changedid, "Project Variation", acc_desc, sql_desc, objacc.UpdatedDate, objsql.UpdatedDate, objacc.UpdatedDate > objsql.UpdatedDate, false, false);
                changeInfos.Add(inf);
            }
            return changeInfos;

        }
        private List<ChangesInfo> GetChangedData(tableChanges<modelProjectActivityVariation> changes)
        {
            var changeInfos = new List<ChangesInfo>();
            foreach (long changedid in changes.changedIDs)
            {

                var objacc = local_dataProject.getProjectActivityVariation(changedid);
                var objsql = sql_dataProject.getProjectActivityVariation(changedid);

                var varacc = local_dataProject.getProjectVariation(objacc.ProjectVariation);
                var varsql = sql_dataProject.getProjectVariation(objsql.ProjectVariation);
                var actacc = local_dataProject.getProjectActivity(objacc.ProjectActivity);
                var actsql = sql_dataProject.getProjectActivity(objsql.ProjectActivity);
                var prjacc = local_dataProject.getProject(varacc.ProjectID);
                var prjsql = sql_dataProject.getProject(varsql.ProjectID);

                string acc_desc = prjacc.GetTitleInfo() + " / " + actacc.Title + " / " + varacc.Title + " / " + objacc.CityOfDestination + " - " + objacc.StudyVisit;
                string sql_desc = prjsql.GetTitleInfo() + " / " + actsql.Title + " / " + varsql.Title + " / " + objsql.CityOfDestination + " - " + objsql.StudyVisit;

                var inf = new ChangesInfo(changedid, "Project Activity Variation", acc_desc, sql_desc, objacc.UpdatedDate, objsql.UpdatedDate, objacc.UpdatedDate > objsql.UpdatedDate, false, false);
                changeInfos.Add(inf);
            }
            return changeInfos;

        }
        private List<ChangesInfo> GetChangedData(tableChanges<modelProjectVariationOrganization> changes)
        {
            var changeInfos = new List<ChangesInfo>();
            foreach (long changedid in changes.changedIDs)
            {

                var objacc = local_dataProject.getProjectVariationOrganization(changedid);
                var objsql = sql_dataProject.getProjectVariationOrganization(changedid);

                var orgacc = local_dataOrganization.getOrganization(objacc.Organization);
                var orgsql = sql_dataOrganization.getOrganization(objsql.Organization);

                var varacc = local_dataProject.getProjectVariation(objacc.ProjectVariation);
                var varsql = sql_dataProject.getProjectVariation(objsql.ProjectVariation);
                var prjacc = local_dataProject.getProject(varacc.ProjectID);
                var prjsql = sql_dataProject.getProject(varsql.ProjectID);

                string acc_desc = prjacc.GetTitleInfo() + " / " + varacc.Title + " / " + orgacc.FriendlyName + " - " + objacc.OrganizationOrder;
                string sql_desc = prjsql.GetTitleInfo() + " / " + varsql.Title + " / " + orgsql.FriendlyName + " - " + objsql.OrganizationOrder;

                var inf = new ChangesInfo(changedid, "Project Activity Variation Organization", acc_desc, sql_desc, objacc.UpdatedDate, objsql.UpdatedDate, objacc.UpdatedDate > objsql.UpdatedDate, false, false);
                changeInfos.Add(inf);
            }
            return changeInfos;

        }
        private List<ChangesInfo> GetChangedData(tableChanges<modelMobility> changes)
        {
            var changeInfos = new List<ChangesInfo>();
            foreach (long changedid in changes.changedIDs)
            {

                var objacc = local_dataActivity.getMobility(changedid);
                var objsql = sql_dataActivity.getMobility(changedid);

                var varactacc = local_dataProject.getProjectActivityVariation(objacc.ActivityVariation);
                var varactsql = sql_dataProject.getProjectActivityVariation(objsql.ActivityVariation);

                var varacc = local_dataProject.getProjectVariation(varactacc.ProjectVariation);
                var varsql = sql_dataProject.getProjectVariation(varactsql.ProjectVariation);
                var actacc = local_dataProject.getProjectActivity(varactacc.ProjectActivity);
                var actsql = sql_dataProject.getProjectActivity(varactsql.ProjectActivity);
                var prjacc = local_dataProject.getProject(varacc.ProjectID);
                var prjsql = sql_dataProject.getProject(varsql.ProjectID);

                var ctracc = local_dataLOV.getCountry(objacc.CountryOfOrigin);
                var ctrsql = sql_dataLOV.getCountry(objsql.CountryOfOrigin);

                string acc_desc = prjacc.GetTitleInfo() + " / " + actacc.Title + " / " + varacc.Title + " / " + varactacc.CityOfDestination + " - " + varactacc.StudyVisit + " / " + ctracc.Country;
                string sql_desc = prjsql.GetTitleInfo() + " / " + actsql.Title + " / " + varsql.Title + " / " + varactsql.CityOfDestination + " - " + varactsql.StudyVisit + " / " + ctrsql.Country;

                var inf = new ChangesInfo(changedid, "Project Activity Variation Mobility", acc_desc, sql_desc, objacc.UpdatedDate, objsql.UpdatedDate, objacc.UpdatedDate > objsql.UpdatedDate, false, false);
                changeInfos.Add(inf);
            }
            return changeInfos;

        }

        private void gridChanges_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                string id = gridChanges.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                string abbrev = gridChanges.Rows[e.RowIndex].Cells["Abbrev"].Value.ToString();

                var row = allChanges.First(c => c.ID.ToString() == id && c.Abbrev == abbrev);

                row.syncAccessToSQL = !row.syncAccessToSQL;
                LoadChangesGrid();
            }

        }

        private void ibuttonWriteChanges_Click(object sender, EventArgs e)
        {
            foreach(var change in allChanges.Where(c=> c.newSQL==false && c.newAccess==false))
            {
                if (change.Abbrev == "modelCountry")
                {
                    if (change.syncAccessToSQL)
                    {
                        var country = local_dataLOV.getCountry(change.ID);
                        sql_dataLOV.Write(country, false);
                    }
                    else
                    {
                        var country = sql_dataLOV.getCountry(change.ID);
                        local_dataLOV.Write(country, false);
                    }
                }
                if (change.Abbrev == "modelLanguage")
                {
                    if (change.syncAccessToSQL)
                    {
                        var lang = local_dataLOV.getLanguage(change.ID);
                        sql_dataLOV.Write(lang, false);
                    }
                    else
                    {
                        var lang = sql_dataLOV.getLanguage(change.ID);
                        local_dataLOV.Write(lang, false);
                    }
                }
                if (change.Abbrev == "modelNationalAgency")
                {
                    if (change.syncAccessToSQL)
                    {
                        var natagency = local_dataLOV.getNationalAgency(change.ID);
                        sql_dataLOV.Write(natagency,false);
                    }
                    else
                    {
                        var natagency = sql_dataLOV.getNationalAgency(change.ID);
                        local_dataLOV.Write(natagency,false);
                    }
                }
                if (change.Abbrev == "modelDistanceBand")
                {
                    if (change.syncAccessToSQL)
                    {
                        var distband = local_dataLOV.getDistanceBand(change.ID);
                        sql_dataLOV.Write(distband, false);
                    }
                    else
                    {
                        var distband = sql_dataLOV.getDistanceBand(change.ID);
                        local_dataLOV.Write(distband, false);
                    }
                }
                if (change.Abbrev == "modelPerson")
                {
                    if (change.syncAccessToSQL)
                    {
                        var pers = local_dataPerson.getPerson(change.ID);
                        sql_dataPerson.Write(pers, false);
                    }
                    else
                    {
                        var pers = sql_dataPerson.getPerson(change.ID);
                        local_dataPerson.Write(pers, false);
                    }
                }
                if (change.Abbrev == "modelRole")
                {
                    if (change.syncAccessToSQL)
                    {
                        var role = local_dataLOV.getRole(change.ID);
                        sql_dataLOV.Write(role, false);
                    }
                    else
                    {
                        var role = sql_dataLOV.getRole(change.ID);
                        local_dataLOV.Write(role, false);
                    }
                }
                if (change.Abbrev == "modelTopic")
                {
                    if (change.syncAccessToSQL)
                    {
                        var topic = local_dataLOV.getTopic(change.ID);
                        sql_dataLOV.Write(topic, false);
                    }
                    else
                    {
                        var topic = sql_dataLOV.getTopic(change.ID);
                        local_dataLOV.Write(topic, false);
                    }
                }
                if (change.Abbrev == "modelClient")
                {
                    if (change.syncAccessToSQL)
                    {
                        var client = local_dataLOV.getClient(change.ID);
                        sql_dataLOV.Write(client, false);
                    }
                    else
                    {
                        var client = sql_dataLOV.getClient(change.ID);
                        local_dataLOV.Write(client, false);
                    }
                }
                if (change.Abbrev == "modelOrganization")
                {
                    if (change.syncAccessToSQL)
                    {
                        var pers = local_dataOrganization.getOrganization(change.ID);
                        sql_dataOrganization.Write(pers, false);
                    }
                    else
                    {
                        var pers = sql_dataOrganization.getOrganization(change.ID);
                        local_dataOrganization.Write(pers, false);
                    }
                }
                if (change.Abbrev == "modelOrganizationType")
                {
                    if (change.syncAccessToSQL)
                    {
                        var orgtype = local_dataLOV.getOrganizationType(change.ID);
                        sql_dataLOV.Write(orgtype, false);
                    }
                    else
                    {
                        var orgtype = sql_dataLOV.getOrganizationType(change.ID);
                        local_dataLOV.Write(orgtype, false);
                    }
                }
                if (change.Abbrev == "modelActivityType")
                {
                    if (change.syncAccessToSQL)
                    {
                        var acttype = local_dataActivity.getActivityType(change.ID);
                        sql_dataActivity.Write(acttype, false);
                    }
                    else
                    {
                        var acttype = sql_dataActivity.getActivityType(change.ID);
                        local_dataActivity.Write(acttype, false);
                    }
                }
                if (change.Abbrev == "modelProject")
                {
                    if (change.syncAccessToSQL)
                    {
                        var prj = local_dataProject.getProject(change.ID);
                        sql_dataProject.Write(prj, false);
                    }
                    else
                    {
                        var prj = sql_dataProject.getProject(change.ID);
                        local_dataProject.Write(prj, false);
                    }
                }

                if (change.Abbrev == "Project Activity")
                {
                    if (change.syncAccessToSQL)
                    {
                        var prjact = local_dataProject.getProjectActivity(change.ID);
                        sql_dataProject.Write(prjact, false);
                    }
                    else
                    {
                        var prjact = sql_dataProject.getProjectActivity(change.ID);
                        local_dataProject.Write(prjact, false);
                    }
                }
                if (change.Abbrev == "Project Variation")
                {
                    if (change.syncAccessToSQL)
                    {
                        var prjvar = local_dataProject.getProjectVariation(change.ID);
                        sql_dataProject.Write(prjvar, false);
                    }
                    else
                    {
                        var prjvar = sql_dataProject.getProjectVariation(change.ID);
                        local_dataProject.Write(prjvar, false);
                    }
                }
                if (change.Abbrev == "Project Activity Variation")
                {
                    if (change.syncAccessToSQL)
                    {
                        var prjactvar = local_dataProject.getProjectActivityVariation(change.ID);
                        sql_dataProject.Write(prjactvar, false);
                    }
                    else
                    {
                        var prjactvar = sql_dataProject.getProjectActivityVariation(change.ID);
                        local_dataProject.Write(prjactvar, false);
                    }
                }
                if (change.Abbrev == "Project Activity Variation Organization")
                {
                    if (change.syncAccessToSQL)
                    {
                        var prjactvarorg = local_dataProject.getProjectVariationOrganization(change.ID);
                        sql_dataProject.Write(prjactvarorg, false);
                    }
                    else
                    {
                        var prjactvarorg = sql_dataProject.getProjectVariationOrganization(change.ID);
                        local_dataProject.Write(prjactvarorg, false);
                    }
                }
                if (change.Abbrev == "Project Activity Variation Mobility")
                {
                    if (change.syncAccessToSQL)
                    {
                        
                        var mob = local_dataActivity.getMobility(change.ID);
                        sql_dataActivity.Write(mob, false);
                    }
                    else
                    {
                        var mob = sql_dataActivity.getMobility(change.ID);
                        local_dataActivity.Write(mob, false);
                    }
                }
            }

            local_dataLOV.LoadData();
            sql_dataLOV.LoadData();
        }

        private void ibuttonNew2Access_Click(object sender, EventArgs e)
        {
            SetProgressBar(16);
            SetStatus("write data to local database");
            WriteNewToAccess();
            SetStatus("");
            SetProgressBar(0);

        }
    }
}
