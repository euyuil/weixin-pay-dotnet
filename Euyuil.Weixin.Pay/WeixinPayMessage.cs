using System;
using System.Collections.Generic;
using System.IO;

namespace Euyuil.Weixin.Pay
{
    internal class WeixinPayMessage
    {
        private readonly Dictionary<string, string> _messageDictionary = new Dictionary<string, string>();

        public T GetValue<T>(string key, T defaultValue = default(T))
        {
            if (_messageDictionary.TryGetValue(key, out string stringValue))
            {
                return (T)Convert.ChangeType(stringValue, typeof(T));
            }

            return defaultValue;
        }

        public void SetValue<T>(string key, T value)
        {
            _messageDictionary[key] = value.ToString();
        }

        public void ReadFromObject(object obj)
        {
        }

        public void WriteToObject(object obj)
        {
        }

        public void ReadFromStream(Stream stream)
        {
        }

        public void WriteToStream(Stream stream)
        {
        }
    }
}
