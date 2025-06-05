using System;
using System.Reflection;
using UnityEngine;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    [Serializable]
    public struct SerializedMethod
    {
        [SerializeField]
        private string _assemblyQualifiedName;
        [SerializeField]
        private string _methodName;
        [SerializeField]
        private bool _isStatic;

        public string AssemblyQualifiedName { get => _assemblyQualifiedName; }
        public string MethodName { get => _methodName; }
        public bool IsStatic { get => _isStatic; }

        public SerializedMethod(string assemblyQualifiedName, string methodName, bool isStatic)
        {
            _assemblyQualifiedName = assemblyQualifiedName;
            _methodName = methodName;
            _isStatic = isStatic;
        }

        public SerializedMethod(MethodInfo methodInfo)
        {
            _assemblyQualifiedName = methodInfo.DeclaringType.AssemblyQualifiedName;
            _methodName = methodInfo.Name;
            _isStatic = methodInfo.IsStatic;
        }

        public void Invoke()
        {
            GetMethodInfo()?.Invoke(null, null);
        }

        public void Invoke(object obj, object[] parameters)
        {
            GetMethodInfo()?.Invoke(obj, parameters);
        }

        public MethodInfo GetMethodInfo()
        {
            if (!string.IsNullOrEmpty(_assemblyQualifiedName))
            {
                string typeName = _assemblyQualifiedName + "AssetAssistant, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
                Type type = Type.GetType(typeName) ?? Type.GetType(_assemblyQualifiedName);
                if (type != null && !string.IsNullOrEmpty(_methodName))
                {
                    var bindingFlags = _isStatic ? BindingFlags.Static : BindingFlags.Instance;
                    return type.GetMethod(_methodName, bindingFlags | BindingFlags.Public | BindingFlags.NonPublic);
                }
            }

            return null;
        }

        public RuntimeMethodHandle GetMethod()
        {
            var methodInfo = GetMethodInfo();
            return methodInfo != null ? methodInfo.MethodHandle : default;
        }

        public T GetDelegate<T>() where T : Delegate
        {
            var type = typeof(T);
            if (!type.IsSubclassOf(typeof(Delegate)) && type != typeof(Delegate))
                return null;

            var method = GetMethodInfo();
            if (method == null)
                return null;

            return Delegate.CreateDelegate(type, method) as T;
        }
    }
}