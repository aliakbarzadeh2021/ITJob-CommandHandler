using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.Domain.Modules.AdvertisementModule.Aggregate;
using ITJob.Message.QueryModel;

namespace ITJob.QueryService.Implement.Modules.AdvertisementModule.Mappers
{
    public static class AdvertisementMapper
    {
        public static IAdvertisementDto ToDto(this Advertisement ad)
        {
            return AutoMapper.Mapper.Map<IAdvertisementDto>(ad);
        }

        public static IEnumerable<IAdvertisementDto> ToDto(this IEnumerable<Advertisement> adList)
        {
            var resultList = new List<IAdvertisementDto>();
            foreach (var ad in adList)
            {
                var dto =AutoMapper.Mapper.Map<IAdvertisementDto>(ad);
                resultList.Add(dto);
            }
            return resultList;
        }

        public static Advertisement ToDomain(this IAdvertisementDto dto)
        {
            return AutoMapper.Mapper.Map<Advertisement>(dto);
        }

        public static Expression<Func<Advertisement, bool>> ToDomain( Expression<Func<IAdvertisementDto, bool>> query)
        {
            Expression<Func<Advertisement, bool>> newQuery = dto => true;
            return newQuery;
        }
    }
}
