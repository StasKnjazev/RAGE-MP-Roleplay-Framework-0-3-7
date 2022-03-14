using System;
using System.Collections.Generic;
using System.Data;

namespace DerStr1k3r.SDK
{
    public class Config
    {
        private Dictionary<string, object> configs;
        private string Category;

        public Config(string category_)
        {
            configs = new Dictionary<string, object>();
            Category = category_;
        }
        public object Get(string param)
        {
            if (configs.ContainsKey(param))
                return configs[param];
            return null;
        }

        public T TryGet<T>(string param, object _default)
        {
            if (!configs.ContainsKey(param))
            {
                //Set(param, _default);
                return (T)Convert.ChangeType(configs[param], typeof(T));
            }
            else return (T)Convert.ChangeType(configs[param], typeof(T));
        }
    }
}
