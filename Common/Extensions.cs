using System;

namespace ConstructServices.Common;

internal static class Extensions
{        
    internal static T GetAttribute<T>(this Enum value) where T : Attribute
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name == null) throw new Exception();
        var field = type.GetField(name);
        if (field == null) throw new Exception();
        return Attribute.GetCustomAttribute(field, typeof(T)) as T;
    }
}