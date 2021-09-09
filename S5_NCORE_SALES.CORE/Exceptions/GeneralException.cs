using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_NCORE_SALES.CORE.Exceptions
{
    public class GeneralException: Exception
    {

        public GeneralException()
        {

        }


        public GeneralException(string message): base(message)
        {

        }

    }
}
