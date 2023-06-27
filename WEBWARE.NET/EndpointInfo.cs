using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBWARE.NET
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class EndpointInfo : Attribute
    {
        public string Funktionsname { get; }
        public int Version { get; }

        public EndpointInfo(string funktionsname, int version)
        {
            Funktionsname = funktionsname;
            Version = version;
        }
    }
}
