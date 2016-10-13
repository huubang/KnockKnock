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
    }

    public interface IRedPillService
    {
        string GetToken();
    }
}
