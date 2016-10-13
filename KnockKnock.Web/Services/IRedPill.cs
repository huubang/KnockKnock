using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KnockKnock.Core;

namespace KnockKnock.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRedPill" in both code and config file together.
    [ServiceContract(Namespace = "http://KnockKnock.readify.net")]
    public interface IRedPill
    {
        [OperationContract]
        Guid WhatIsYourToken();
        [OperationContract]
        [FaultContract(typeof(ArgumentOutOfRangeException))]
        long FibonacciNumber(long n);
        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);
        [OperationContract]
        [FaultContract(typeof(ArgumentNullException))]
        string ReverseWords(string s);
    }

    [DataContract(Name = "TriangleType", Namespace = "http://KnockKnock.readify.net")]
    public enum TriangleType : int
    {
        [EnumMember]
        Scalene = 3,
        [EnumMember]
        Isosceles = 2,
        [EnumMember]
        Equilateral = 1,
        [EnumMember]
        Error = 0
    }
}
