using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.Message.QueryModel;

namespace ITJob.QueryService.Interface.AdvertisementModule
{
    public interface IAdvertisementQueryService
    {
        IAdvertisementDto GetAdvertisementById(Guid id);
        IEnumerable<IAdvertisementDto> SearchAdvertisement(Expression<Func<IAdvertisementDto, bool>> query);
    }
}
