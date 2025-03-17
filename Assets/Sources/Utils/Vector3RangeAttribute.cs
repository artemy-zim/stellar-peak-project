using UnityEngine;

public class Vector3RangeAttribute : PropertyAttribute
{
    public float Min { get; private set; }
    public float Max { get; private set; }

    public Vector3RangeAttribute(float min, float max)
    {
        Min = min;
        Max = max;
    }
}
