﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KnockKnock.Core;

namespace KnockKnock.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RedPillWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RedPillWcfService.svc or RedPillWcfService.svc.cs at the Solution Explorer and start debugging.
    public class RedPillWcfService : IRedPillWcfService
    {
        private IRedPillService redPillService;

        public RedPillWcfService()
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
            return redPillService.GetTriangleType(a, b, c);
        }

        public string ReverseWords(string s)
        {
            return redPillService.ReverseWords(s);
        }
    }
}
