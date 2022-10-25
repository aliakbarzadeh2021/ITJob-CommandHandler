using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.Advertisement.Api.Host.ServiceHost;

namespace ITJob.Advertisement.Api.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHostFactory.Run();
        }
    }
}
