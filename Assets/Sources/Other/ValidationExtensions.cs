using System;
using UnityEngine;

public static class ValidationExtensions
{
    public static void ValidateIfNull(this object obj)
    {
        if(obj == null)
            throw new ArgumentNullException(nameof(obj));
    }
}
