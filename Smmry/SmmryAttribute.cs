using System;

namespace Smmry.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class SmmryParameterAttribute : Attribute
    {
        private readonly string _name;
        public SmmryParameterAttribute(string name) { _name = name; }
        public override string ToString() => _name;
    }
}
