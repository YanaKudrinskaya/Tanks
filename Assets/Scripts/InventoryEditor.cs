using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    private Inventory _inventory;

    public void OnEnable()
    {
        _inventory = (Inventory)target;
    }

    public override void OnInspectorGUI()
    {
        if (_inventory.Items.Count > 0)
        {
            foreach (Inventory.Item item in _inventory.Items)
            {
                EditorGUILayout.BeginVertical("box");
                item.Id = EditorGUILayout.IntField("�������������", item.Id);
                item.Name = EditorGUILayout.TextField("��� ��������", item.Name);
                item.Image = (Sprite)EditorGUILayout.ObjectField("������", item.Image,typeof(Sprite), false);
                EditorGUILayout.EndVertical();
            }
        }
        else
        {
            EditorGUILayout.LabelField("��������� ������, ��������� ���");
        }
        if (GUILayout.Button("�������� �������", GUILayout.Width(300),GUILayout.Height(20))) {
            _inventory.Items.Add(new Inventory.Item());
        }
        if (GUI.changed)
        {
            SetObjectDirty(_inventory.gameObject);
        }
    }

    public static void SetObjectDirty(GameObject obj)
    {
        EditorUtility.SetDirty(obj);
        EditorSceneManager.MarkSceneDirty(obj.scene);

    }
}
