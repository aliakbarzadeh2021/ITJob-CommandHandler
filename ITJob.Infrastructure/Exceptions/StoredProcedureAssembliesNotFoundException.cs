using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJob.Infrastructure.Exceptions
{
    public class StoredProcedureAssembliesNotFoundException : Exception
    {
        public override string Message
        {
            get { return "ابتدا اسمبلی رویه های خود را به پروایدر اضافه کنید"; }
        }
    }
}
