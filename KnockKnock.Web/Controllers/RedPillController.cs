﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KnockKnock.Core;

namespace KnockKnock.Web.Controllers
{
    [RoutePrefix("api/red-pill")]
    public class RedPillController : ApiController
    {
        private readonly IRedPillService redPillService;

        public RedPillController()
        {
            redPillService = new RedPillService();
        }

        [HttpGet]
        [Route("token")]
        public string GetToken()
        {
            return redPillService.GetToken();
        }

        [HttpGet]
        [Route("fibonacci/{number:long}")]
        public long GetFibonacci(long number)
        {
            return redPillService.GetFibonacci(number);
        }

        [HttpGet]
        [Route("reverse-words")]
        public string ReverseWords(string sentence)
        {
            return redPillService.ReverseWords(sentence);
        }

        [HttpGet]
        [Route("triangle-type")]
        public string GetTriangleType(int a, int b, int c)
        {
            return redPillService.GetTriangleType(a, b, c).ToString();
        }
    }
}
