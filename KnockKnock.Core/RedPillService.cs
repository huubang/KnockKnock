using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnock.Core
{
    public class RedPillService : IRedPillService
    {
        private const string Token = "97c72c91-a9bf-40ed-9788-df359c6bedfa";

        public string GetToken()
        {
            return Token;
        }

        public long GetFibonacci(long number)
        {
            var numbers = GetLongRange(1, number);
            var fibo = numbers.Aggregate((f, s) => f*s);

            return fibo;
        }

        public string ReverseWords(string sentence)
        {
            var reversedSentence = string.Join(" ", sentence.Split(' ').Select(w => new string(w.Reverse().ToArray())));
            return reversedSentence;
        }

        public TriangleType GetTriangleType(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return TriangleType.Invalid;                
            }

            if (a + b <= c || b + c <= a || a + c <= b)
            {
                return TriangleType.Invalid;
            }

            if (a == b && b == c)
            {
                return TriangleType.Equilateral;
            }

            if (a == b || b == c || a == c)
            {
                return TriangleType.Isosceles;
            }

            return TriangleType.Scalene;
        }

        private IEnumerable<long> GetLongRange(long source, long length)
        {
            for (var i = source; i <= length; i++)
            {
                yield return i;
            }
        }
    }

    public interface IRedPillService
    {
        string GetToken();
        long GetFibonacci(long number);
        string ReverseWords(string sentence);
        TriangleType GetTriangleType(int a, int b, int c);
    }

    public enum TriangleType
    {
        Scalene,
        Isosceles,
        Equilateral,
        Invalid
    }
}
