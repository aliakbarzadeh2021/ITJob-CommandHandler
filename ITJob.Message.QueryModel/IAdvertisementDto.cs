using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJob.Message.QueryModel
{
    public interface IAdvertisementDto
    {
         string AdvertisementStatus { get; set; }

         string AdvertisementType { get; set; }  // عادی ، برنزی ، نقره ای ، طلایی 

        // DateTime Date
        //{
        //    get; set;
        //}
         string JobTitle { get; set; }

         string JobCategory { get; set; }

         string CooperationType { get; set; }

         string MilitaryStatusNeed { get; set; }

         string WorkExperienceNeed { get; set; }

         string EducationNeed { get; set; }

         string GenderNeed { get; set; }

         string CompanyDescription { get; set; }

         string JobDescription { get; set; }

         string SkillsNeed { get; set; }

         string City { get; set; }

         string Salary { get; set; }

         bool JobPromotion { get; set; }  // امکان ترفیع سمت

         bool InsuranceStatus { get; set; } // داشتن بیمه

         bool Training { get; set; } // دوره های آموزشی حین کار

         bool Food { get; set; } // ناهار به عهده شرکت

         bool FlexibleTime { get; set; } // ساعت کاری منعطف یا شناور

         string ContactForSendRezume { get; set; }
    }

    
}
