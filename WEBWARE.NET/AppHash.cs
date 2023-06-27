using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WEBWARE.NET
{
    public class AppHash
    {
        public string Hash { get; set; }
        public string DateFormatted { get; set; }
        public int NewRequestId { get; set; }

        public static AppHash GenerateAppHash(int requestId, string appSecret)
        {
            var nr = requestId + 1;
            var now = DateTime.UtcNow.ToString("R");
            var hashBuilder = new StringBuilder();
            MD5.Create().ComputeHash(Encoding.Default.GetBytes((appSecret ?? "") + now))
                .Each(b => hashBuilder.Append(b.ToString("X2")));
            return new AppHash(hashBuilder.ToString().ToLower(), now, nr);
        }

        internal AppHash(string hash, string dateFormatted, int newRequestId)
        {
            Hash = hash;
            DateFormatted = dateFormatted;
            NewRequestId = newRequestId;
        }
    }
}
