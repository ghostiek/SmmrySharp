using System;

namespace SmmrySharp.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class SmmryParameterAttribute : Attribute
    {
        public string Name { get; set; }
        public bool HasParameter { get; private set; }
        public SmmryParameterAttribute(string name, bool hasParameter)
        {
            Name = name;
            HasParameter = hasParameter;
        }
        public override string ToString() => Name;
    }
}
