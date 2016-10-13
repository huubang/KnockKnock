using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KnockKnock.Core;

namespace KnockKnock.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RedPill" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RedPill.svc or RedPill.svc.cs at the Solution Explorer and start debugging.
    public class RedPill : IRedPill
    {
        private readonly IRedPillService redPillService;

        public RedPill()
        {
            redPillService = new RedPillService();
        }
        public Guid WhatIsYourToken()
        {
            return new Guid(redPillService.GetToken());
        }

        public long FibonacciNumber(long n)
        {
            return redPillService.GetFibonacci(n);
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            var result = redPillService.GetTriangleType(a, b, c);
            switch (result)
            {
                case Core.TriangleType.Equilateral:
                    return TriangleType.Equilateral;
                case Core.TriangleType.Isosceles:
                    return TriangleType.Isosceles;
                case Core.TriangleType.Scalene:
                    return TriangleType.Scalene;
                case Core.TriangleType.Invalid:
                    return TriangleType.Error;
                default:
                    return TriangleType.Error;
            }
        }

        public string ReverseWords(string s)
        {
            return redPillService.ReverseWords(s);
        }
    }
}
