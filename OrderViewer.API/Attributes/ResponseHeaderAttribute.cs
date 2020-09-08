using System;

namespace OrderViewer.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ResponseHeaderAttribute : Attribute
    {
        public ResponseHeaderAttribute(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }

        public Type Type { get; }
    }
}
