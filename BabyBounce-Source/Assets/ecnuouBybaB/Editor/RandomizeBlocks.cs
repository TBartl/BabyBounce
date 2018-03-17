using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class RandomizeBlocks : EditorWindow {
	[MenuItem("Edit/Randomize Blocks %3")]
	public static void PlayFromPrelaunchScene() {
		foreach (Block b in FindObjectsOfType<Block>()) {
			b.Randomize();
		}
		EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
	}

}