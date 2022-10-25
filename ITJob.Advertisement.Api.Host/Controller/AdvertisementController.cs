using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ITJob.CommandHandler.Modules.AdvertisementModule;
using ITJob.Message.Command.AdvertisementModule.Messages;
using ITJob.Message.QueryModel;
using ITJob.QueryService.Implement.Modules.AdvertisementModule.Dtos;
using ITJob.QueryService.Interface.AdvertisementModule;
using SAF.SSN.Kernel.Infrastructure.Domain;

namespace ITJob.Advertisement.Api.Host.Controller
{
    public class AdvertisementController : ApiController
    {
        private readonly IAdvertisementQueryService _advertisementQueryService;
        private readonly AdvertisementCommandHandler _commandHandler;

        public AdvertisementController(IAdvertisementQueryService advertisementQueryService, AdvertisementCommandHandler commandHandler)
        {
            _advertisementQueryService = advertisementQueryService;
            _commandHandler = commandHandler;
        }


        public HttpResponseMessage Post([FromBody] CreateAdvertisementCommand advertisement)
        {
            try
            {
                _commandHandler.Handle(advertisement);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (DomainException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ex.Message));
            }
            catch (Exception ex)
            {
                //ExceptionLogger.SaveException(ex, "_studentService.SaveOrUpdate");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "خطا در پردازش اطلاعات."));
            }
        }
        public void Put(UpdateAdvertisementCommand command)
        {
            _commandHandler.Handle(command);
        }
        public void Delete(DeleteAdvertisementCommand command)
        {
            _commandHandler.Handle(command);
        }
        public IEnumerable<IAdvertisementDto> Get()
        {
            return _advertisementQueryService.SearchAdvertisement(x => true);
        }
        public IAdvertisementDto Get(Guid id)
        {
            return _advertisementQueryService.GetAdvertisementById(id);
        }
    }
}
