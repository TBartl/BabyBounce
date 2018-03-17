using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RandomizeBlocks : EditorWindow {
	[MenuItem("Edit/Randomize Blocks %3")]
	public static void PlayFromPrelaunchScene() {
		foreach (Block b in FindObjectsOfType<Block>()) {
			b.Randomize();
		}
	}

}