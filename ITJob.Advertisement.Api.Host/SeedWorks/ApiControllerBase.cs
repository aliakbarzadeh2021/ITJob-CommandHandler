using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SAF.SSN.Kernel.CommandBus;

namespace ITJob.Advertisement.Api.Host.SeedWorks
{
    public abstract class ApiControllerBase : ApiController
    {
        private readonly ICommandBus _bus;

        protected ApiControllerBase()
        {
        }

        protected ApiControllerBase(ICommandBus bus)
        {
            _bus = bus;
        }


        protected Guid UserId
        {
            get
            {

                var s = RequestContext.Principal.Identity as ClaimsIdentity;
                if (s != null)
                {
                    var userId = s.Claims.FirstOrDefault(i => i.Type.Equals("personId"));
                    if (userId != null)
                    {
                        return Guid.Parse(userId.Value);
                    }
                    return Guid.Empty;
                }
                return Guid.Empty;
            }
        }


        protected string AuthorizationToken
        {
            get
            {
                if (Request.Headers.Contains("Authorization"))
                    return Request.Headers.GetValues("Authorization").First();
                return null;
            }
        }


        protected ICommandBus Bus
        {
            get { return _bus; }
        }

        protected ResponseModel CreateResponseModel(string message, ResponseMessageType type, bool success = false,
            object content = null) => (content != null
                ? new ResponseContentModel
                {
                    Content = content,
                    Message = message,
                    Success = success,
                    Type = type
                }
                : new ResponseModel
                {
                    Message = message,
                    Success = success,
                    Type = type
                });

        private class InterfaceContractResolver<T> : CamelCasePropertyNamesContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var properties = base.CreateProperties(typeof(T), memberSerialization);
                return properties;
            }
        }

        protected IHttpActionResult ToJson<TResolver>(object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new InterfaceContractResolver<TResolver>()
            };

            return Json(obj, settings);
        }
    }
}
