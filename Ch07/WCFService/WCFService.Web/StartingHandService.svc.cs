using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;

namespace WCFService.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = 
        AspNetCompatibilityRequirementsMode.Allowed)]
    public class StartingHandService
    {
        [OperationContract]
        public List<StartingHands> GetHands()        {
                return StartingHands.GetHands();
        }
        // Add more operations here and mark them 
        // with [OperationContract]
    }
}

