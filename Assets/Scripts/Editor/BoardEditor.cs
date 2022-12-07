using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Board))]
public class BoardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Board board = target as Board;

        if(GUILayout.Button("Creare"))
        {
            board.Create();
            Debug.Log("Create");
        }
    }
}
