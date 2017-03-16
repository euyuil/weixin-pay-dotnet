using System;

namespace Euyuil.Weixin.Pay
{
    internal class WeixinPayPropertyAttribute : Attribute
    {
        public WeixinPayPropertyAttribute()
        {
        }

        public WeixinPayPropertyAttribute(string name)
        {
            Name = name;
        }

        public WeixinPayPropertyAttribute(string name, bool required)
        {
            Name = name;
            Required = required;
        }

        public WeixinPayPropertyAttribute(string name, int maxLength)
        {
            Name = name;
            MaxLength = maxLength;
        }

        public WeixinPayPropertyAttribute(string name, int maxLength, bool required)
        {
            Name = name;
            MaxLength = maxLength;
            Required = required;
        }

        public WeixinPayPropertyAttribute(string name, string format)
        {
            Name = name;
            Format = format;
        }

        public WeixinPayPropertyAttribute(string name, string format, bool required)
        {
            Name = name;
            Format = format;
            Required = required;
        }

        public string Name { get; set; }

        public bool Required { get; set; }

        public int MaxLength { get; set; }

        public string Format { get; set; }
    }
}
