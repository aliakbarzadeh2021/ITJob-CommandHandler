using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.Domain.Modules.AdvertisementModule.Aggregate;
using ITJob.EntityFramework.Read.Context.Interfaces;
using ITJob.Message.QueryModel;
using ITJob.QueryService.Implement.Modules.AdvertisementModule.Mappers;
using ITJob.QueryService.Interface.AdvertisementModule;

namespace ITJob.QueryService.Implement.Modules.AdvertisementModule.Services
{
    public class AdvertisementQueryService : IAdvertisementQueryService
    {
        private readonly IReadOnlyRepository<Advertisement> _advertisementRepository;

        public AdvertisementQueryService(IReadOnlyRepository<Advertisement> advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public IAdvertisementDto GetAdvertisementById(Guid id)
        {
            return _advertisementRepository.Find(id).ToDto();
        }

        public IEnumerable<IAdvertisementDto> SearchAdvertisement(Expression<Func<IAdvertisementDto, bool>> query)
        {
            var newQuery = AdvertisementMapper.ToDomain(query);
            return _advertisementRepository.AsQuery().Where(newQuery).AsEnumerable().ToDto();
        }
    }
}
