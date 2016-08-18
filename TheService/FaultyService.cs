using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TheContracts;

namespace TheService
{
    public class FaultyService : IFaultyService
    {
        public int Sum(int a, int b)
        {
            return checked(a + b);
        }

        public int SumWithFault(int a, int b)
        {
            try
            {
                return checked(a + b);
            }
            catch(Exception ex)
            {
                throw new FaultException<UnhandledError>(new UnhandledError(ex));
            }
        }
    }
}
