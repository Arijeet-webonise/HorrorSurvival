using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class EditorPlayer : Editor {

	public override void OnInspectorGUI ()
	{
		Player player = (Player)target;
		DrawDefaultInspector ();
		if (GUILayout.Button ("ReSpawn")) {
			player.Respawn ();
		}
	}
}
