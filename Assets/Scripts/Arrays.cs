using System;

public static class Arrays
{
    public static T[] InitializeWithDefaultInstances<T>(int length)
    {
        var array = new T[length];

        for (int i=0; i<length; i++)
            array[i] = Activator.CreateInstance<T>();

        return array;
    }
}