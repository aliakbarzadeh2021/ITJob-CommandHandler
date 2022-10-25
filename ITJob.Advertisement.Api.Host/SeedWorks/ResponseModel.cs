using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJob.Advertisement.Api.Host.SeedWorks
{
    public class ResponseModel
    {
        public string Message { get; set; }

        public ResponseMessageType Type { get; set; }

        public bool Success { get; set; }
    }
}
