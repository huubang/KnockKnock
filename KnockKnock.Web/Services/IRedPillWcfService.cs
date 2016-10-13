using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KnockKnock.Core;

namespace KnockKnock.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRedPillWcfService" in both code and config file together.
    [ServiceContract]
    public interface IRedPillWcfService
    {
        [OperationContract]
        Guid WhatIsYourToken();
        [OperationContract]
        long FibonacciNumber(long n);
        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);
        [OperationContract]
        string ReverseWords(string s);
    }
}
