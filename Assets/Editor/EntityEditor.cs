using Entites;
using Entities;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Entity), true)]
public class EntityEditor : Editor
{
    Entity tgt;
    
    public void OnEnable()
    {
        tgt = target as Entity;
    }

    public override void OnInspectorGUI()
    {
        GUIContent content = new GUIContent("Entity inspector");
        GUILayout.Label(content, EditorStyles.boldLabel);
        tgt.Definition = (EntityDefinition)EditorGUILayout.ObjectField("Definition", tgt.Definition, typeof(EntityDefinition), false);

        if (tgt.Definition != null)
        {
            if(tgt.Definition.State != null)
                EditorGUILayout.HelpBox("Using external state", MessageType.Info);
            else
                EditorGUILayout.HelpBox("Not using external state", MessageType.Warning);
        }
    }
}
