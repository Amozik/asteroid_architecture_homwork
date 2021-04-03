using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Lesson5.Adapter.Editor
{
    [CustomEditor(typeof(ExampleWithDictionary))]
    public class ExampleWithDictionaryEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var myTarget = (ExampleWithDictionary) target;

            foreach (var pair in myTarget.MyDictionary)
            {
                EditorGUILayout.IntField(pair.key, GUIStyle.none);
                EditorGUILayout.TextField(pair.value, GUIStyle.none);
            }
            
            //myTarget.MyDictionary = EditorGUILayout.ObjectField("s", myTarget.MyDictionary, typeof(ColorPointDrawer), true);
        }
    }
}