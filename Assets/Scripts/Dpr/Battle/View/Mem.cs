using System;
using System.Collections;
using System.Collections.Generic;

namespace Dpr.Battle.View
{
    public static class Mem
    {
        // TODO
        public static void Del<T>(ref T p) { }

        public static void Del<T>(T p)
        {
            Del(ref p);
        }

        // TODO
        public static void DelAry<T>(ref T[] p) { }

        // TODO
        public static void DelAry<T>(T[] p) { }

        // TODO
        public static void DelICollection<T>(ref List<T> p) { }

        // TODO
        public static void DelICollection<T>(List<T> p) { }

        // TODO
        public static void DelICollection(ref IDictionary p) { }

        // TODO
        public static void DelICollection(IDictionary p) { }

        // TODO
        public static void DelICollection<T>(ref Queue<T> p) { }

        // TODO
        public static void DelICollection<T>(Queue<T> p) { }

        // TODO: Double check
        public static void DelIDisposable<T>(ref T p) where T : IDisposable
        {
            /*p.Dispose();
            Del(ref p);*/
        }

        // TODO
        public static void DelAryIDisposable<T>(T[] p) { }

        // TODO
        public static void DelAryIDisposable<T>(ref T[] p) { }

        public static void DelIDisposable<T>(T p) where T : IDisposable
        {
            DelIDisposable(ref p);
        }

        // TODO
        public static void ClearICollection<T>(ref List<T> p) { }

        // TODO
        public static void ClearICollection<T>(List<T> p) { }

        // TODO
        public static void ClearICollection<T>(ref Queue<T> p) { }

        // TODO
        public static void ClearICollection<T>(Queue<T> p) { }
    }
}