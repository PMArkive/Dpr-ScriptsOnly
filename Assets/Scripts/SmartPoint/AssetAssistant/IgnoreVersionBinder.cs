using System;
using System.Runtime.Serialization;

namespace SmartPoint.AssetAssistant
{
    public class IgnoreVersionBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            // The code here is not super clear, but it appears to be something like this
            Type type = Type.GetType(string.Join(", ", typeName, "AssetAssistant, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"), false);
            if (type != null)
                return type;

            return Type.GetType(typeName, false);
        }
    }
}