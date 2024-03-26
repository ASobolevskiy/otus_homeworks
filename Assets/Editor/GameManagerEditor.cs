using ShootEmUp;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gManager = (GameManager)target;

        EditorGUILayout.LabelField("Game State", gManager.GameState.ToString());

        if (GUILayout.Button("Start game"))
        {
            gManager.HandleStart();
        }
        if (GUILayout.Button("Pause game"))
        {
            gManager.HandlePause();
        }
        if (GUILayout.Button("Resume game"))
        {
            gManager.HandleResume();
        }
        if (GUILayout.Button("Finish game"))
        {
            gManager.HandleFinish();
        }
    }
}