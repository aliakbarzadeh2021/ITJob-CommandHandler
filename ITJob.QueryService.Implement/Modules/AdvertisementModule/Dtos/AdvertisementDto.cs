using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.Message.QueryModel;

namespace ITJob.QueryService.Implement.Modules.AdvertisementModule.Dtos
{
    public class AdvertisementDto : IAdvertisementDto
    {
        public string AdvertisementStatus { get; set; }
        public string AdvertisementType { get; set; }
        public string JobTitle { get; set; }
        public string JobCategory { get; set; }
        public string CooperationType { get; set; }
        public string MilitaryStatusNeed { get; set; }
        public string WorkExperienceNeed { get; set; }
        public string EducationNeed { get; set; }
        public string GenderNeed { get; set; }
        public string CompanyDescription { get; set; }
        public string JobDescription { get; set; }
        public string SkillsNeed { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
        public bool JobPromotion { get; set; }
        public bool InsuranceStatus { get; set; }
        public bool Training { get; set; }
        public bool Food { get; set; }
        public bool FlexibleTime { get; set; }
        public string ContactForSendRezume { get; set; }
    }
}
