using Core.Results.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.BusinessRules
{
    public class BusinessRules
    {                                       
        public static IResult Run(params IResult[] logics)  //method engine for business methods (logic:Rules)
        {
            foreach (var logic in logics)
            {
                if (!logic.Succes)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
