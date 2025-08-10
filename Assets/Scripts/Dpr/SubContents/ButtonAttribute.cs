using System;
using UnityEngine;

namespace Dpr.SubContents
{
    [AttributeUsage(validOn: AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public sealed class ButtonAttribute : PropertyAttribute
    {
	    public string Function { get; private set; }
        public string Name { get; private set; }
        public object[] Parameters { get; private set; }

        public ButtonAttribute(string function, string name, object[] parameters)
        {
            Function = function;
            Name = name;
            Parameters = parameters;
        }
    }
}