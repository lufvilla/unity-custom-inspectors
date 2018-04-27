using Entites;
using Entities;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DynamicEntity), true)]
public class DynamicEntityEditor : Editor
{
    DynamicEntity tgt;
    
    public void OnEnable()
    {
        tgt = target as DynamicEntity;
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
