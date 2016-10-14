using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace KnockKnock.Core
{
    public class RedPillService : IRedPillService
    {
        private const string Token = "97c72c91-a9bf-40ed-9788-df359c6bedfa";

        public string GetToken()
        {
            return Token;
        }

        public long GetFibonacciLinq(long number)
        {
            if (number == 0)
            {
                return 0;
            }

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Invalid number for Fibonacci");
            }

            var numbers = GetLongRange(1, number);
            var fibo = numbers.Aggregate((f, s) => f*s);

            return fibo;
        }

        public long GetFibonacci(long number)
        {
            var threshold = 92;

            if (number > threshold)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"Value cannot be greater than {threshold}, since the result will cause a 64-bit integer overflow.");
            }

            if (number < -threshold)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"Value cannot be less than {-threshold}, since the result will cause a 64-bit integer overflow.");
            }

            var key = $"FibonacciNumber{number}";
            var cacheItem = MemoryCache.Default.GetCacheItem(key);

            long result;

            if (cacheItem != null)
            {
                result = (long) cacheItem.Value;
            }
            else
            {
                result = CalculateBinetFormula(number);
                MemoryCache.Default.Add(new CacheItem(key, result),
                    new CacheItemPolicy() {SlidingExpiration = TimeSpan.FromHours(6)});
            }

            return result;
        }

        private long CalculateBinetFormula(long n)
        {
            var numerator = Math.Pow((1.0 + Math.Sqrt(5.0)), n) - Math.Pow((1.0 - Math.Sqrt(5.0)), n);
            var denominator = Math.Pow(2.0, n) * Math.Sqrt(5.0);
            var result = numerator / denominator;

            var roundedResult = Math.Round(result);

            return (long) roundedResult;
        }


        public string ReverseWords(string sentence)
        {
            if (sentence == null)
            {
                throw new ArgumentNullException(nameof(sentence), "Input is null");
            }
            var key = $"ReverseWords{sentence.GetHashCode()}";
            var cacheItem = MemoryCache.Default.GetCacheItem(key);

            string result;

            if (cacheItem != null)
            {
                result = (string) cacheItem.Value;
            }
            else
            {
                result = string.Join(" ", sentence.Split(' ').Select(w => new string(w.Reverse().ToArray())));

                MemoryCache.Default.Add(new CacheItem(key, result),
                    new CacheItemPolicy {SlidingExpiration = TimeSpan.FromHours(6)});
            }

            return result;
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
