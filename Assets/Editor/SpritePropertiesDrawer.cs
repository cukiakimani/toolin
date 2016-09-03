using UnityEngine;

using System.Collections;

using System;
using UnityEditorInternal;
using System.Reflection;
using UnityEditor;

[CustomPropertyDrawer(typeof(SpriteProperties))]
public class SpritePropertiesDrawer : PropertyDrawer
{
	string[] _sortingLayerNames;

    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
    {
    	_sortingLayerNames = GetSortingLayerNames();

    	// get properties of the class
    	SerializedProperty layerName = prop.FindPropertyRelative("SortingLayerName");
        SerializedProperty layerOrder = prop.FindPropertyRelative("SortingLayerOrder");
        SerializedProperty selectedIndex = prop.FindPropertyRelative("SortingLayerIndex");

        EditorGUI.BeginProperty(pos, label, prop);

        var rect = new Rect(pos.x, pos.y, pos.width * 0.39f, 16f);
        EditorGUI.LabelField(rect, "Sorting Layer");

        rect.x += rect.width;
        rect.width = pos.width - rect.width;
        
        // layerName.stringValue = EditorGUI.TextField(rect, layerName.stringValue);

        selectedIndex.intValue = EditorGUI.Popup(rect, selectedIndex.intValue, _sortingLayerNames);
        layerName.stringValue = _sortingLayerNames[selectedIndex.intValue];

        rect = new Rect(pos.x, pos.y + 18f, pos.width * 0.39f, 16f);
        EditorGUI.LabelField(rect, "Order in Layer");

        rect.x += rect.width;
        rect.width = pos.width - rect.width;
        layerOrder.intValue = EditorGUI.IntField(rect, layerOrder.intValue);

        EditorGUI.EndProperty();
    }

    // set the height of the property
    public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
    {
        return 28f;
    }

    // i found this on the internet 
    public string[] GetSortingLayerNames()
     {
         Type internalEditorUtilityType = typeof(InternalEditorUtility);
         PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
         return (string[])sortingLayersProperty.GetValue(null, new object[0]);
     }
}
