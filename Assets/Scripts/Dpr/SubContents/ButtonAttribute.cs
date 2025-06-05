using System;
using UnityEngine;

namespace Dpr.SubContents
{
    [AttributeUsage(validOn: AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public sealed class ButtonAttribute : PropertyAttribute
    {
	    public string Function { get; set; }
        public string Name { get; set; }
        public object[] Parameters { get; set; }

        public ButtonAttribute(string function, string name, object[] parameters)
        {
            Function = function;
            Name = name;
            Parameters = parameters;
        }
    }
}