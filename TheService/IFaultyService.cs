using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TheContracts;

namespace TheService
{
    [ServiceContract]
    public interface IFaultyService
    {
        [OperationContract]
        int Sum(int a, int b);

        [OperationContract]
        [FaultContract(typeof(UnhandledError))]
        int SumWithFault(int a, int b);
    }
}
