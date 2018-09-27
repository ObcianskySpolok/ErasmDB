using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    public class modelMailMargeVariables
    {
        public List<string> allVariables;
        private Dictionary<string, string> newVariables;
        public Dictionary<string, string> oldVariables;

        private List<string> excludedVars;
        private int mmVarsIndex = 0;
        private List<Dictionary<string, string>> mmVariationVars;

        public modelMailMargeVariables()
        {
            mmVariationVars = new List<Dictionary<string, string>>();

            allVariables = new List<string>() {
                { "[@PROJECTVARIATION-Round]" },
                { "[@PROJECTVARIATION-ProjectTitle]" },
                { "[@PROJECTVARIATION-Acronym]" },
                { "[@PROJECTVARIATION-PartnerCount]" },
                { "[@PROJECTVARIATION-PartnerCountriesList]" },
                { "[@PROJECTVARIATION-ParticipantsCount]" },
                { "[@PROJECTVARIATION-ParticipantsPerCountry]" },
                { "[@PROJECTVARIATION-ParticipantsFewerOpportunitiesCount]" },
                { "[@PROJECTVARIATION-ParticipantsFewerOpportunitiesPerCountry]" },
                { "[@PROJECTVARIATION-StaffGroupLeadersTotal]" },
                { "[@PROJECTVARIATION-StaffGroupLeadersPerCountry]" },
                { "[@PROJECTVARIATION-StaffFacilitators]" },
                { "[@PROJECTVARIATION-StaffOther]" },
                { "[@PROJECTVARIATION-Dates]" },
                { "[@PROJECTVARIATION-DatesCount]" },
                { "[@PROJECTVARIATION-Location]" },
                { "[@PROJECTVARIATION-LocationCountry]" },
                { "[@PROJECTVARIATION-StudyVisit]" },
                { "[@PROJECTVARIATION-Custom1]" },
                { "[@PROJECTVARIATION-Custom2]" },
                { "[@PROJECTVARIATION2-ParticipantsCount]" },
                { "[@PROJECTVARIATION2-ParticipantsPerCountry]" },
                { "[@PROJECTVARIATION2-ParticipantsFewerOpportunitiesCount]" },
                { "[@PROJECTVARIATION2-ParticipantsFewerOpportunitiesPerCountry]" },
                { "[@PROJECTVARIATION2-StaffGroupLeadersTotal]" },
                { "[@PROJECTVARIATION2-StaffGroupLeadersPerCountry]" },
                { "[@PROJECTVARIATION2-StaffFacilitators]" },
                { "[@PROJECTVARIATION2-StaffOther]" },
                { "[@PROJECTVARIATION2-Dates]" },
                { "[@PROJECTVARIATION2-DatesCount]" },
                { "[@PROJECTVARIATION2-Location]" },
                { "[@PROJECTVARIATION2-LocationCountry]" },
                { "[@PROJECTVARIATION2-StudyVisit]" },
                { "[@PROJECTVARIATION2-Custom1]" },
                { "[@PROJECTVARIATION2-Custom2]" },
                { "[@APPLICANT-legal-name]"},
                { "[@APPLICANT-acronym]"},
                { "[@APPLICANT-registration-no]"},
                { "[@APPLICANT-country]"},
                { "[@APPLICANT-country-code]"},
                { "[@PARTNER01-legal-name]" },
                { "[@PARTNER01-acronym]" },
                { "[@PARTNER01-registration-no]"},
                { "[@PARTNER01-country]"},
                { "[@PARTNER01-country-code]"},
                { "[@PARTNER02-legal-name]" },
                { "[@PARTNER02-acronym]" },
                { "[@PARTNER02-registration-no]"},
                { "[@PARTNER02-country]"},
                { "[@PARTNER02-country-code]"},
                { "[@PARTNER03-legal-name]" },
                { "[@PARTNER03-acronym]" },
                { "[@PARTNER03-registration-no]"},
                { "[@PARTNER03-country]"},
                { "[@PARTNER03-country-code]"},
                { "[@PARTNER04-legal-name]" },
                { "[@PARTNER04-acronym]" },
                { "[@PARTNER04-registration-no]"},
                { "[@PARTNER04-country]"},
                { "[@PARTNER04-country-code]"},
                { "[@PARTNER05-legal-name]" },
                { "[@PARTNER05-acronym]" },
                { "[@PARTNER05-registration-no]"},
                { "[@PARTNER05-country]"},
                { "[@PARTNER05-country-code]"},
                { "[@PARTNER06-legal-name]" },
                { "[@PARTNER06-acronym]" },
                { "[@PARTNER06-registration-no]"},
                { "[@PARTNER06-country]"},
                { "[@PARTNER06-country-code]"},
                { "[@PARTNER07-legal-name]" },
                { "[@PARTNER07-acronym]" },
                { "[@PARTNER07-registration-no]"},
                { "[@PARTNER07-country]"},
                { "[@PARTNER07-country-code]"},
            };

            oldVariables = new Dictionary<string, string>() {
                { "[@PROJECTVARIATION-Round]", "round" },
                { "[@PROJECTVARIATION-ProjectTitle]","project_name" },
                { "[@PROJECTVARIATION-Acronym]","project_name_acronym" },
                { "[@PROJECTVARIATION-PartnerCount]", "partner_count" },
                { "[@PROJECTVARIATION-PartnerCountriesList]", "partners_list" },
                { "[@PROJECTVARIATION-ParticipantsCount]", "a1_participnats_count" },
                { "[@PROJECTVARIATION-ParticipantsPerCountry]", "a1_participnats_count_per_country" },
                { "[@PROJECTVARIATION-ParticipantsFewerOpportunitiesCount]", "a1_participnats_obstacle_count" },
                { "[@PROJECTVARIATION-ParticipantsFewerOpportunitiesPerCountry]", "a1_participnats_obstacle_per_country" },
                { "[@PROJECTVARIATION-StaffGroupLeadersTotal]", "a1_staff_group_leaders_total" },
                { "[@PROJECTVARIATION-StaffGroupLeadersPerCountry]", "" },
                { "[@PROJECTVARIATION-StaffFacilitators]", "a1_staff_facilitators" },
                { "[@PROJECTVARIATION-StaffOther]", "a1_staff_other" },
                { "[@PROJECTVARIATION-Dates]", "a1_dates" },
                { "[@PROJECTVARIATION-DatesCount]", "a1_dates_count" },
                { "[@PROJECTVARIATION-Location]", "a1_location" },
                { "[@PROJECTVARIATION-LocationCountry]", "a1_location_country" },
                { "[@PROJECTVARIATION-StudyVisit]", "a1_study_visit" },
                { "[@PROJECTVARIATION-Custom1]", "custom_variable1" },
                { "[@PROJECTVARIATION-Custom2]", "custom_variable2" },
                { "[@PROJECTVARIATION2-ParticipantsCount]", "" },
                { "[@PROJECTVARIATION2-ParticipantsPerCountry]", "" },
                { "[@PROJECTVARIATION2-ParticipantsFewerOpportunitiesCount]", "" },
                { "[@PROJECTVARIATION2-ParticipantsFewerOpportunitiesPerCountry]", "" },
                { "[@PROJECTVARIATION2-StaffGroupLeadersTotal]", "" },
                { "[@PROJECTVARIATION2-StaffGroupLeadersPerCountry]", "" },
                { "[@PROJECTVARIATION2-StaffFacilitators]", "" },
                { "[@PROJECTVARIATION2-StaffOther]", "" },
                { "[@PROJECTVARIATION2-Dates]", "" },
                { "[@PROJECTVARIATION2-DatesCount]", "" },
                { "[@PROJECTVARIATION2-Location]", "" },
                { "[@PROJECTVARIATION2-LocationCountry]", "" },
                { "[@PROJECTVARIATION2-StudyVisit]", "" },
                { "[@PARTNER01-legal-name]", "partner01_ngo_name" },
                { "[@PARTNER01-acronym]", "partner01_ngo_acronym" },
                { "[@PARTNER01-registration-no]", "partner01_ngo_pic"},
                { "[@PARTNER01-country]", ""},
                { "[@PARTNER01-country-code]", "partner01_country_iso"},
                { "[@PARTNER02-legal-name]", "partner02_ngo_name" },
                { "[@PARTNER02-acronym]", "partner02_ngo_acronym" },
                { "[@PARTNER02-registration-no]", "partner02_ngo_pic"},
                { "[@PARTNER02-country]", ""},
                { "[@PARTNER02-country-code]", "partner02_country_iso"},
                { "[@PARTNER03-legal-name]", "partner03_ngo_name" },
                { "[@PARTNER03-acronym]", "partner03_ngo_acronym" },
                { "[@PARTNER03-registration-no]", "partner03_ngo_pic"},
                { "[@PARTNER03-country]", ""},
                { "[@PARTNER03-country-code]", "partner03_country_iso"},
                { "[@PARTNER04-legal-name]", "partner04_ngo_name" },
                { "[@PARTNER04-acronym]", "partner04_ngo_acronym" },
                { "[@PARTNER04-registration-no]", "partner04_ngo_pic"},
                { "[@PARTNER04-country]", ""},
                { "[@PARTNER04-country-code]", "partner04_country_iso"},
                { "[@PARTNER05-legal-name]", "partner05_ngo_name" },
                { "[@PARTNER05-acronym]", "partner05_ngo_acronym" },
                { "[@PARTNER05-registration-no]", "partner05_ngo_pic"},
                { "[@PARTNER05-country]", ""},
                { "[@PARTNER05-country-code]", "partner05_country_iso"},
                { "[@PARTNER06-legal-name]", "partner06_ngo_name" },
                { "[@PARTNER06-acronym]", "partner06_ngo_acronym" },
                { "[@PARTNER06-registration-no]", "partner06_ngo_pic"},
                { "[@PARTNER06-country]", ""},
                { "[@PARTNER06-country-code]", "partner06_country_iso"},
                { "[@PARTNER07-legal-name]", "partner07_ngo_name" },
                { "[@PARTNER07-acronym]", "partner07_ngo_acronym" },
                { "[@PARTNER07-registration-no]", "partner07_ngo_pic"},
                { "[@PARTNER07-country]", ""},
                { "[@PARTNER07-country-code]", "partner07_country_iso"},
                { "[@APPLICANT-legal-name]","applicant_ngo" },
                { "[@APPLICANT-acronym]","applicant_ngo_acronym" },
                { "[@APPLICANT-registration-no]", "applicant_ngo_pic"},
                { "[@APPLICANT-country]","applicant_country" },
                { "[@APPLICANT-country-code]","applicant_country_iso" },
            };
            newVariables = new Dictionary<string, string>() {
                { "[@PROJECTVARIATION-Round]", "round" },
                { "[@PROJECTVARIATION-ProjectTitle]","project_name" },
                { "[@PROJECTVARIATION-Acronym]","project_name_acronym" },
                { "[@PROJECTVARIATION-PartnerCount]", "partner_count" },
                { "[@PROJECTVARIATION-PartnerCountriesList]", "partners_countries_list" },
                { "[@PROJECTVARIATION-NationalAgency]", "national_agency" },                
                { "[@PROJECTVARIATION-Custom1]", "custom_variable1" },
                { "[@PROJECTVARIATION-Custom2]", "custom_variable2" },


            };

            excludedVars = new List<string>(new string[] {
                "a2_participants_count",
                "a2_participants_count_per_country",
                "a2_participants_obstacle",
                "a2_participants_obstacle_per_country",
                "a2_group_leaders_total",
                "a2_group_leaders_per_country",
                "a2_staff_facilitators",
                "a2_staff_other",
                "a2_dates",
                "a2_dates_count",
                "a2_location_city",
                "a2_location_country",
                "a2_study_visit",
                "a2_activity_type",
                "a2_start_date",
                "a2_end_date",
                "a2_euro_travel",
                "a2_euro_orgsupport",
                "a2_euro_total",
                "a2_sum_facilitators",
                "a2_sum_staff",
                "a2_sum_gltf",
                "a2_sum_participants",
                "a2_mob1_country",
                "a2_mob1_dist_band",
                "a2_mob1_travel_days",
                "a2_mob1_facilitator",
                "a2_mob1_staff",
                "a2_mob1_gltf",
                "a2_mob1_total_participants",
                "a2_mob2_country",
                "a2_mob2_dist_band",
                "a2_mob2_travel_days",
                "a2_mob2_facilitator",
                "a2_mob2_staff",
                "a2_mob2_gltf",
                "a2_mob2_total_participants",
                "a2_mob3_country",
                "a2_mob3_dist_band",
                "a2_mob3_travel_days",
                "a2_mob3_facilitator",
                "a2_mob3_staff",
                "a2_mob3_gltf",
                "a2_mob3_total_participants",
                "a2_mob4_country",
                "a2_mob4_dist_band",
                "a2_mob4_travel_days",
                "a2_mob4_facilitator",
                "a2_mob4_staff",
                "a2_mob4_gltf",
                "a2_mob4_total_participants",
                "a2_mob5_country",
                "a2_mob5_dist_band",
                "a2_mob5_travel_days",
                "a2_mob5_facilitator",
                "a2_mob5_staff",
                "a2_mob5_gltf",
                "a2_mob5_total_participants",
                "a2_mob6_country",
                "a2_mob6_dist_band",
                "a2_mob6_travel_days",
                "a2_mob6_facilitator",
                "a2_mob6_staff",
                "a2_mob6_gltf",
                "a2_mob6_total_participants",
                "a2_mob7_country",
                "a2_mob7_dist_band",
                "a2_mob7_travel_days",
                "a2_mob7_facilitator",
                "a2_mob7_staff",
                "a2_mob7_gltf",
                "a2_mob7_total_participants",
                "national_agency",
                "a1_activity_type",
                "a1_euro_travel",
                "a1_euro_orgsupport",
                "a1_euro_total",
                "a1_sum_facilitators",
                "a1_sum_staff",
                "a1_sum_gltf",
                "a1_sum_participants",
                "a1_mob1_country",
                "a1_mob1_dist_band",
                "a1_mob1_travel_days",
                "a1_mob1_facilitator",
                "a1_mob1_staff",
                "a1_mob1_gltf",
                "a1_mob1_total_participants",
                "a1_mob2_country",
                "a1_mob2_dist_band",
                "a1_mob2_travel_days",
                "a1_mob2_facilitator",
                "a1_mob2_staff",
                "a1_mob2_gltf",
                "a1_mob2_total_participants",
                "a1_mob3_country",
                "a1_mob3_dist_band",
                "a1_mob3_travel_days",
                "a1_mob3_facilitator",
                "a1_mob3_staff",
                "a1_mob3_gltf",
                "a1_mob3_total_participants",
                "a1_mob4_country",
                "a1_mob4_dist_band",
                "a1_mob4_travel_days",
                "a1_mob4_facilitator",
                "a1_mob4_staff",
                "a1_mob4_gltf",
                "a1_mob4_total_participants",
                "a1_mob5_country",
                "a1_mob5_dist_band",
                "a1_mob5_travel_days",
                "a1_mob5_facilitator",
                "a1_mob5_staff",
                "a1_mob5_gltf",
                "a1_mob5_total_participants",
                "a1_mob6_country",
                "a1_mob6_dist_band",
                "a1_mob6_travel_days",
                "a1_mob6_facilitator",
                "a1_mob6_staff",
                "a1_mob6_gltf",
                "a1_mob6_total_participants",
                "a1_mob7_country",
                "a1_mob7_dist_band",
                "a1_mob7_travel_days",
                "a1_mob7_facilitator",
                "a1_mob7_staff",
                "a1_mob7_gltf",
                "a1_mob7_total_participants",
                "partner06_ngo_name",
                "partner06_ngo_acronym",
                "partner06_general_description",
                "partner06_ngo_pic",
                "partner06_country_name",
                "partner06_country_iso",
                "partner07_ngo_name",
                "partner07_ngo_acronym",
                "partner07_general_description",
                "partner07_ngo_pic",
                "partner07_country_name",
                "partner07_country_iso",
            });

            AddProjectVariationDefinition("PROJECTVARIATION", "a1_");
            AddProjectMobility("PROJECTVARIATION-Mobility1", "a1_mob1_");
            AddProjectMobility("PROJECTVARIATION-Mobility2", "a1_mob2_");
            AddProjectMobility("PROJECTVARIATION-Mobility3", "a1_mob3_");
            AddProjectMobility("PROJECTVARIATION-Mobility4", "a1_mob4_");
            AddProjectMobility("PROJECTVARIATION-Mobility5", "a1_mob5_");
            AddProjectMobility("PROJECTVARIATION-Mobility6", "a1_mob6_");
            AddProjectMobility("PROJECTVARIATION-Mobility7", "a1_mob7_");

            AddProjectVariationDefinition("PROJECTVARIATION2", "a2_");
            AddProjectMobility("PROJECTVARIATION2-Mobility1", "a2_mob1_");
            AddProjectMobility("PROJECTVARIATION2-Mobility2", "a2_mob2_");
            AddProjectMobility("PROJECTVARIATION2-Mobility3", "a2_mob3_");
            AddProjectMobility("PROJECTVARIATION2-Mobility4", "a2_mob4_");
            AddProjectMobility("PROJECTVARIATION2-Mobility5", "a2_mob5_");
            AddProjectMobility("PROJECTVARIATION2-Mobility6", "a2_mob6_");
            AddProjectMobility("PROJECTVARIATION2-Mobility7", "a2_mob7_");

            AddApplicantDefinition();
            AddPartnerDefinition("PARTNER01", "partner01_");
            AddPartnerDefinition("PARTNER02", "partner02_");
            AddPartnerDefinition("PARTNER03", "partner03_");
            AddPartnerDefinition("PARTNER04", "partner04_");
            AddPartnerDefinition("PARTNER05", "partner05_");
            AddPartnerDefinition("PARTNER06", "partner06_");
            AddPartnerDefinition("PARTNER07", "partner07_");

        }


        public Dictionary<string, string> mailMergeVars
        {
            get {
                if (mmVariationVars.Count() == 0) return null;

                return mmVariationVars.ElementAt(mmVarsIndex);
            }
        }
        public int mailMergeVarsCount
        {
            get { return mmVariationVars.Count(); }
        }
        public int mailMergeVarsIndex
        {
            get { return mmVarsIndex; }
            set {
                if (value < 0 || value > mailMergeVarsCount-1) return;
                mmVarsIndex = value;
            }

        }

        public Dictionary<string, string> usedVariables
        {
            get
            {
                var filtered = newVariables.Where(c => !excludedVars.Contains(c.Value)).ToDictionary(i => i.Key, i => i.Value);
                return filtered;
            }
        }


        public void prepareMailMergeData(modelProject project)
        {
            mmVariationVars = new List<Dictionary<string, string>>();
            foreach (var variation in Program.GData.dataProject.getProjectVariations.Where(c => c.ProjectID == project.ID))
            {
                var mailMergeVars = new Dictionary<string, string>();
                prepareMailMergeDataVariation(variation, ref mailMergeVars);

                mmVariationVars.Add(mailMergeVars);
            }
        }

        public void prepareMailMergeDataVariation(modelProjectVariation prjVariation, ref Dictionary<string, string> mailMergeVars)
        {
            modelOrganization emptyOrg = new modelOrganization();

            //modelProjectVariation projvar1 = null;
            modelProjectActivityVariation projactvar1 = null;
            //modelProjectVariation projvar2 = null;
            modelProjectActivityVariation projactvar2 = null;
            modelOrganization applicant = emptyOrg;
            modelOrganization partner01 = emptyOrg;
            modelOrganization partner02 = emptyOrg;
            modelOrganization partner03 = emptyOrg;
            modelOrganization partner04 = emptyOrg;
            modelOrganization partner05 = emptyOrg;
            modelOrganization partner06 = emptyOrg;
            modelOrganization partner07 = emptyOrg;
            modelMobility emptyMobility = new modelMobility();

            var actvars = Program.GData.dataProject.getProjectActivityVariations.Where(c => c.ProjectVariation == prjVariation.ID).ToArray();
            if (actvars.Count() == 0) return;
            if (actvars.Count() == 1)
            {
                projactvar1 = actvars[0];
                projactvar2 = new modelProjectActivityVariation();
                projactvar2.Duration = 1;
            }
            if (actvars.Count() == 2)
            {
                projactvar1 = actvars[0];
                projactvar2 = actvars[1];
            }

            applicant = Program.GData.dataOrganization.getOrganization(prjVariation.ApplicantOrganization);
            var partners = Program.GData.dataProject.getProjectVariationOrganizations.Where(c => c.ProjectVariation == prjVariation.ID).OrderBy(d => d.OrganizationOrder).ToArray();
            if (partners.Count() > 0) partner01 = Program.GData.dataOrganization.getOrganization(partners[0].Organization);
            if (partners.Count() > 1) partner02 = Program.GData.dataOrganization.getOrganization(partners[1].Organization);
            if (partners.Count() > 2) partner03 = Program.GData.dataOrganization.getOrganization(partners[2].Organization);
            if (partners.Count() > 3) partner04 = Program.GData.dataOrganization.getOrganization(partners[3].Organization);
            if (partners.Count() > 4) partner05 = Program.GData.dataOrganization.getOrganization(partners[4].Organization);
            if (partners.Count() > 5) partner06 = Program.GData.dataOrganization.getOrganization(partners[5].Organization);
            if (partners.Count() > 6) partner07 = Program.GData.dataOrganization.getOrganization(partners[6].Organization);

            string countryList = applicant.getCountryCode() + "," + partner01.getCountryCode() + "," + partner02.getCountryCode() + "," + partner03.getCountryCode() + "," + partner04.getCountryCode() + "," + partner05.getCountryCode() + "," + partner06.getCountryCode() + "," + partner07.getCountryCode();
            while (countryList.Contains(",,")) countryList = countryList.Replace(",,", ",");
            if (countryList.Substring(countryList.Length - 1) == ",") countryList = countryList.Substring(0, countryList.Length - 1);

            var mobilities1 = Program.GData.dataActivity.getMobilities.Where(c => c.ActivityVariation == projactvar1.ID).OrderBy(c => c.MobilityOrder).ToArray();
            var mobilities2 = Program.GData.dataActivity.getMobilities.Where(c => c.ActivityVariation == projactvar2.ID).OrderBy(c => c.MobilityOrder).ToArray();

            AddProjectVariationVariables(ref mailMergeVars,prjVariation, partners, countryList);
            AddProjectActivityVariationVariables(ref mailMergeVars, projactvar1,partners, "a1_");
            AddProjectActivityVariationVariables(ref mailMergeVars, projactvar2,partners, "a2_");

            int sum1_facilitators = 0;
            int sum1_stuff = 0;
            int sum1_gtl = 0;
            int sum1_participants = 0;
            for (int idx=0; idx<8; idx++)
            {
                if (mobilities1.Count() > idx)
                {
                    AddMobilityVariables(ref mailMergeVars, mobilities1[idx], "a1_mob" + (idx + 1).ToString() + "_");
                    sum1_facilitators += mobilities1[idx].Facilitators;
                    sum1_stuff += mobilities1[idx].Others;
                    sum1_gtl += mobilities1[idx].GroupLeaders+ mobilities1[idx].Trainers + mobilities1[idx].Facilitators;
                    sum1_participants += mobilities1[idx].Participants;
                }                    
                else
                    AddMobilityVariables(ref mailMergeVars, emptyMobility, "a1_mob" + (idx + 1).ToString() + "_");
            }
            AddMobilitySumsVariables(ref mailMergeVars, sum1_facilitators, sum1_stuff, sum1_gtl, sum1_participants, "a1_");

            int sum2_facilitators = 0;
            int sum2_stuff = 0;
            int sum2_gtl = 0;
            int sum2_participants = 0;
            for (int idx = 0; idx < 8; idx++)
            {
                if (mobilities2.Count() > idx)
                {
                    AddMobilityVariables(ref mailMergeVars, mobilities2[idx], "a2_mob" + (idx + 1).ToString() + "_");
                    sum2_facilitators += mobilities2[idx].Facilitators;
                    sum2_stuff += mobilities2[idx].Others;
                    sum2_gtl += mobilities2[idx].GroupLeaders + mobilities2[idx].Trainers + mobilities2[idx].Facilitators;
                    sum2_participants += mobilities2[idx].Participants;
                }                    
                else
                    AddMobilityVariables(ref mailMergeVars, emptyMobility, "a2_mob" + (idx + 1).ToString() + "_");
            }
            AddMobilitySumsVariables(ref mailMergeVars, sum2_facilitators, sum2_stuff, sum2_gtl, sum2_participants, "a2_");

            AddApplicantVariables(ref mailMergeVars, applicant, "applicant_");
            AddPartnerVariables(ref mailMergeVars, partner01, "partner01_");
            AddPartnerVariables(ref mailMergeVars, partner02, "partner02_");
            AddPartnerVariables(ref mailMergeVars, partner03, "partner03_");
            AddPartnerVariables(ref mailMergeVars, partner04, "partner04_");
            AddPartnerVariables(ref mailMergeVars, partner05, "partner05_");
            AddPartnerVariables(ref mailMergeVars, partner06, "partner06_");
            AddPartnerVariables(ref mailMergeVars, partner07, "partner07_");
        }

        private void AddPartnerVariables(ref Dictionary<string, string> mailMergeVars, modelOrganization org, string prefix)
        {
            AddToVariablesDictionary(ref mailMergeVars, prefix + "ngo_name", org.LegalName);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "ngo_acronym", org.Acronym);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "general_description", org.GeneralDescription);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "ngo_pic", org.PIC.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "country_name", org.getCountry());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "country_iso", org.getCountryCode());
        }
        private void AddApplicantVariables(ref Dictionary<string, string> mailMergeVars, modelOrganization org, string prefix)
        {
            AddToVariablesDictionary(ref mailMergeVars, prefix + "ngo", org.LegalName);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "ngo_acronym", org.Acronym);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "ngo_pic", org.PIC.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "country_name", org.getCountry());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "country_iso", org.getCountryCode());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "ngo_description", org.Description);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "ngo_activities", org.Activities);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "ngo_staff", org.KeyStaff);
        }
        private void AddProjectVariationVariables(ref Dictionary<string, string> mailMergeVars, modelProjectVariation projvar, modelProjectVariationOrganization[] partners,string countryList)
        {
            string na = "";
            var natagency = Program.GData.dataLOV.getNationalAgency(projvar.NationalAgency);
            if (natagency != null) na = natagency.AgencyName;

            AddToVariablesDictionary(ref mailMergeVars, "round", projvar.Call);
            AddToVariablesDictionary(ref mailMergeVars, "project_name", projvar.Title);
            AddToVariablesDictionary(ref mailMergeVars, "project_name_acronym", projvar.Acronym);
            AddToVariablesDictionary(ref mailMergeVars, "partner_count", partners.Count().ToString());
            AddToVariablesDictionary(ref mailMergeVars, "partners_countries_list", countryList);
            AddToVariablesDictionary(ref mailMergeVars, "national_agency", na);
            AddToVariablesDictionary(ref mailMergeVars, "custom_variable1", projvar.CustomVariable1);
            AddToVariablesDictionary(ref mailMergeVars, "custom_variable2", projvar.CustomVariable2);
        }
        private void AddProjectActivityVariationVariables(ref Dictionary<string, string> mailMergeVars, modelProjectActivityVariation projactvar,modelProjectVariationOrganization[] partners, string prefix)
        {
            var country = Program.GData.dataLOV.getCountry(projactvar.CountryOfDestination);
            string cc;
            if (country == null)
                cc = "";
            else
                cc = country.Code;

            var at = Program.GData.dataProject.getProjectActivity(projactvar.ProjectActivity);
            string atype;
            if (at == null)
                atype = "";
            else
                atype = Program.GData.dataActivity.getActivityType(at.ActivityID).ActivityType;

            AddToVariablesDictionary(ref mailMergeVars, prefix + "participants_total", projactvar.ParticipantsTotal.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "participants_count_per_country", projactvar.ParticipantsPerCountry.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "participants_obstacle_total", projactvar.FewerOpportunitieTotal.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "participants_obstacle_per_country", projactvar.FewerOpportunitiePerCountry.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "group_leaders_total", projactvar.GTFTotal.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "group_leaders_per_country", projactvar.GTFPerCountry.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "staff_facilitators", "0");
            AddToVariablesDictionary(ref mailMergeVars, prefix + "staff_other", "0");
            AddToVariablesDictionary(ref mailMergeVars, prefix + "dates", projactvar.StartDate.ToString("dd.MM.") + "-" + projactvar.StartDate.AddDays(projactvar.Duration - 1).ToString("dd.MM.yyyy"));
            AddToVariablesDictionary(ref mailMergeVars, prefix + "dates_count", projactvar.Duration.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "location_city", projactvar.CityOfDestination);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "location_country", cc);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "study_visit", projactvar.StudyVisit);

            AddToVariablesDictionary(ref mailMergeVars, prefix + "activity_type", atype);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "start_date", projactvar.StartDate.ToString("dd.MM.yyyy"));
            AddToVariablesDictionary(ref mailMergeVars, prefix + "end_date", projactvar.EndDate.ToString("dd.MM.yyyy"));

            AddToVariablesDictionary(ref mailMergeVars, prefix + "euro_travel", projactvar.Travel.ToString("n2"));
            AddToVariablesDictionary(ref mailMergeVars, prefix + "euro_orgsupport", projactvar.OrgSupport.ToString("n2"));
            AddToVariablesDictionary(ref mailMergeVars, prefix + "euro_total", (projactvar.OrgSupport + projactvar.Travel).ToString("n2"));

        }
        private void AddMobilityVariables(ref Dictionary<string, string> mailMergeVars, modelMobility mob, string prefix)
        {
            var country = Program.GData.dataLOV.getCountry(mob.CountryOfOrigin);
            string cc;
            if (country == null)
                cc = "";
            else
                cc = country.Code;

            var dband = Program.GData.dataLOV.getDistanceBand(mob.DistanceBand);
            string db;
            if (dband == null)
                db = "";
            else
                db = dband.DistanceBand;

            AddToVariablesDictionary(ref mailMergeVars, prefix + "country", cc);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "dist_band", db);
            AddToVariablesDictionary(ref mailMergeVars, prefix + "travel_days", mob.TravelDays.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "facilitator", mob.Facilitators.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "staff", mob.Others.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "gltf", (mob.Trainers + mob.Others + mob.Facilitators + mob.GroupLeaders).ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "total_participants", (mob.FewerOpportunities + mob.Participants + mob.Trainers + mob.Others + mob.Facilitators + mob.GroupLeaders).ToString());

        }
        private void AddMobilitySumsVariables(ref Dictionary<string, string> mailMergeVars, int sumFacilitators, int sumStaff,int sumTGF, int sumParticipants, string prefix)
        {
            AddToVariablesDictionary(ref mailMergeVars, prefix + "sum_facilitators", sumFacilitators.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "sum_staff", sumStaff.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "sum_gltf", sumTGF.ToString());
            AddToVariablesDictionary(ref mailMergeVars, prefix + "sum_participants", sumParticipants.ToString());

        }

        private void AddPartnerDefinition(string prefix1, string prefix2)
        {
            AddToVariablesDictionary(ref newVariables, "[" + prefix1 + "-legal-name]", prefix2 + "ngo_name");
            AddToVariablesDictionary(ref newVariables, "[" + prefix1 + "-acronym]", prefix2 + "ngo_acronym");
            AddToVariablesDictionary(ref newVariables, "[" + prefix1 + "-general-desc]", prefix2 + "general_description");
            AddToVariablesDictionary(ref newVariables, "[" + prefix1 + "-registration-no]", prefix2 + "ngo_pic");
            AddToVariablesDictionary(ref newVariables, "[" + prefix1 + "-country]", prefix2 + "country_name");
            AddToVariablesDictionary(ref newVariables, "[" + prefix1 + "-country-code]", prefix2 + "country_iso");

        }
        private void AddApplicantDefinition()
        {
            AddToVariablesDictionary(ref newVariables, "[@APPLICANT-legal-name]", "applicant_ngo");
            AddToVariablesDictionary(ref newVariables, "[@APPLICANT-description]", "applicant_ngo_description");
            AddToVariablesDictionary(ref newVariables, "[@APPLICANT-activities]", "applicant_ngo_activities");
            AddToVariablesDictionary(ref newVariables, "[@APPLICANT-key-staff]", "applicant_ngo_staff");
            AddToVariablesDictionary(ref newVariables, "[@APPLICANT-acronym]", "applicant_ngo_acronym");
            AddToVariablesDictionary(ref newVariables, "[@APPLICANT-registration-no]", "applicant_ngo_pic");
            AddToVariablesDictionary(ref newVariables, "[@APPLICANT-country]", "applicant_country_name");
            AddToVariablesDictionary(ref newVariables, "[@APPLICANT-country-code]", "applicant_country_iso");

        }
        private void AddProjectVariationDefinition(string prefix1, string prefix2)
        {
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-ParticipantsCount]", prefix2 + "participants_total");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-ParticipantsPerCountry]", prefix2 + "participants_count_per_country");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-ParticipantsFewerOpportunitiesCount]", prefix2 + "participants_obstacle_total");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-ParticipantsFewerOpportunitiesPerCountry]", prefix2 + "participants_obstacle_per_country");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-StaffGroupLeadersTotal]", prefix2 + "group_leaders_total");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-StaffGroupLeadersPerCountry]", prefix2 + "group_leaders_per_country");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-StaffFacilitators]", prefix2 + "staff_facilitators");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-StaffOther]", prefix2 + "staff_other");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-Dates]", prefix2 + "dates");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-DatesCount]", prefix2 + "dates_count");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-Location]", prefix2 + "location_city");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-LocationCountry]", prefix2 + "location_country");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-StudyVisit]", prefix2 + "study_visit");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-ActivityType]", prefix2 + "activity_type");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-StartDate]", prefix2 + "start_date");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-EndDate]", prefix2 + "end_date");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-Euro-Travel]", prefix2 + "euro_travel");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-Euro-OrgSupport]", prefix2 + "euro_orgsupport");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-Euro-Total]", prefix2 + "euro_total");

            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-SumFacilitators]", prefix2 + "sum_facilitators");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-SumStaff]", prefix2 + "sum_staff");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-SumGLTF]", prefix2 + "sum_gltf");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-SumParticipants]", prefix2 + "sum_participants");
        }

        private void AddProjectMobility(string prefix1, string prefix2)
        {
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-Country]", prefix2 + "country");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-DistanceBand]", prefix2 + "dist_band");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-TravelDays]", prefix2 + "travel_days");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-Facilitators]", prefix2 + "facilitator");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-Staff]", prefix2 + "staff");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-LeadersTrainersFacilitators]", prefix2 + "gltf");
            AddToVariablesDictionary(ref newVariables, "[@" + prefix1 + "-TotalParticipants]", prefix2 + "total_participants");
        }

        private void AddToVariablesDictionary(ref Dictionary<string, string> dict, string varname, string varvalue)
        {
            dict.Add(varname, varvalue);
        }

        public List<Tuple<string, string>> ChangedVariables()
        {
            List<Tuple<string,string>> dif = new List<Tuple<string, string>>();

            foreach(var oldvar in oldVariables)
            {
                string o_k = oldvar.Key;
                string o_v = oldvar.Value;

                if(o_v !="" && newVariables.ContainsKey(o_k))
                {
                    string n_v = newVariables[o_k];
                    if (n_v != o_v)
                        dif.Add(new Tuple<string, string>(n_v,o_v));
                }
                

            }

            return dif;
        }
    }
}

