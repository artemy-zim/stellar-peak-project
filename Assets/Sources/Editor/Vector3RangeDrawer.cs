using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Vector3RangeAttribute))]
public class Vector3RangeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Vector3RangeAttribute range = attribute as Vector3RangeAttribute;
        if (property.propertyType == SerializedPropertyType.Vector3)
        {
            Vector3 vector = property.vector3Value;
            vector.x = Mathf.Clamp(vector.x, range.Min, range.Max);
            vector.y = Mathf.Clamp(vector.y, range.Min, range.Max);
            vector.z = Mathf.Clamp(vector.z, range.Min, range.Max);
            property.vector3Value = vector;
            EditorGUI.PropertyField(position, property, label, true);
        }
        else
        {
            EditorGUI.LabelField(position, label.text, "Use Vector3Range with Vector3.");
        }
    }
}
