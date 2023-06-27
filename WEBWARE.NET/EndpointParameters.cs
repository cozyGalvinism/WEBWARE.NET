using System.Collections.Generic;
// ReSharper disable HeuristicUnreachableCode

namespace WEBWARE.NET
{
    public class EndpointParameters
    {
        private readonly Dictionary<string, dynamic> _parameter;
        public EndpointParameters()
        {
            _parameter = new Dictionary<string, dynamic>();
        }
        
        public EndpointParameters AddParameter(string key, dynamic value)
        {
            if (_parameter.ContainsKey(key)) return this;
            if (value == null) return this;
            var val = value as string;
            if (value is string && string.IsNullOrEmpty(val))
            {
                return this;
            }
            if (value is bool b)
            {
                if (!b) return this;
                _parameter.Add(key, 1);
                return this;
            }
            _parameter.Add(key, value);
            return this;
        }

        public EndpointParameters AddParameterList(Dictionary<string, dynamic> list)
        {
            list.Each(e => AddParameter(e.Key, e.Value));
            return this;
        }

        public EndpointParameters AddParameterList<TKey, TValue>(Dictionary<TKey, TValue> list)
        {
            list.Each(e => AddParameter(e.Key.ToString(), e.Value));
            return this;
        }

        public Dictionary<string, dynamic> GetParameters()
        {
            return _parameter;
        }
    }
}
