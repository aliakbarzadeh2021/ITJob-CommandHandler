using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJob.Infrastructure.Exceptions
{
    public class DataProviderAssembliesNotFoundException : Exception
    {
        public override string Message
        {
            get { return "ابتدا اسمبلی مدل های خود را به دیتا پروایدر اضافه کنید"; }
        }
    }
}
