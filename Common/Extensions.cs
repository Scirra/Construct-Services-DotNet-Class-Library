using System;
using System.Collections.Generic;
using System.Linq;

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
    internal static List<T> ToList<T>() where T : Enum
        => Enum.GetValues(typeof(T)).Cast<T>().ToList();
    internal static bool IsAlphaNumeric(this char c)
        => char.IsLetter(c) || char.IsNumber(c);
}