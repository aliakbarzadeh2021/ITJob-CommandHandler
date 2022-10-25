using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ITJob.Domain.Modules.AdvertisementModule.Aggregate;
using ITJob.Message.QueryModel;

namespace ITJob.QueryService.Implement.Modules.AdvertisementModule.Mappers
{
    public class AdvertismentMapperProfile : Profile
    {
        public AdvertismentMapperProfile()
        {
            CreateMap<Advertisement, IAdvertisementDto>();
            CreateMap<IAdvertisementDto, Advertisement>();
        }
    }
}
