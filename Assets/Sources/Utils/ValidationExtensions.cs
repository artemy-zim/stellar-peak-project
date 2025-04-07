using System;

public static class ValidationExtensions
{
    public static void ValidateIfNull(this object obj)
    {
        if(obj == null)
            throw new ArgumentNullException(nameof(obj));
    }
}
