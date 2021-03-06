﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KnockKnock.Core;

namespace KnockKnock.Web.Controllers
{
    /// <summary>
    /// A creative implementation based on reference web service https://knockknock.readify.net/RedPill.svc
    /// For source code, visit https://github.com/huubang/KnockKnock
    /// </summary>
    [RoutePrefix("api/red-pill")]
    public class RedPillController : ApiController
    {
        private readonly IRedPillService redPillService;

        public RedPillController()
        {
            redPillService = new RedPillService();
        }

        /// <summary>
        /// Get the Readify recruitment token
        /// </summary>
        /// <returns>The recruitment token generated by Readify</returns>
        [HttpGet]
        [Route("token")]
        public string GetToken()
        {
            return redPillService.GetToken();
        }

        /// <summary>
        /// Get the nth Fibonacci number
        /// </summary>
        /// <param name="number">The value of n</param>
        /// <returns>The nth Fibonacci number</returns>
        [HttpGet]
        [Route("fibonacci/{number:long}")]
        public long GetFibonacci(long number)
        {
            return redPillService.GetFibonacci(number);
        }

        /// <summary>
        /// Reverse the character order of each words in a sentence while preserving the word order
        /// </summary>
        /// <param name="sentence">The sentence to apply</param>
        /// <returns>The sentence with words reversed</returns>
        [HttpGet]
        [Route("reverse-words")]
        public string ReverseWords(string sentence)
        {
            return redPillService.ReverseWords(sentence);
        }

        /// <summary>
        /// Identify the type of a triangle
        /// </summary>
        /// <param name="a">First side of the triangle</param>
        /// <param name="b">Second side of the triangle</param>
        /// <param name="c">Third side of the triangle</param>
        /// <returns>The type of the triangle</returns>
        [HttpGet]
        [Route("triangle-type")]
        public string GetTriangleType(int a, int b, int c)
        {
            return redPillService.GetTriangleType(a, b, c).ToString();
        }
    }
}
