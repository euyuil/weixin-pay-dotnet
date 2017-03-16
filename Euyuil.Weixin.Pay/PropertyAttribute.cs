using System;

namespace Euyuil.Weixin.Pay
{
    internal class PropertyAttribute : Attribute
    {
        public PropertyAttribute()
        {
        }

        public PropertyAttribute(string name)
        {
            Name = name;
        }

        public PropertyAttribute(string name, bool required)
        {
            Name = name;
            Required = required;
        }

        public string Name { get; set; }

        public bool Required { get; set; }
    }
}
