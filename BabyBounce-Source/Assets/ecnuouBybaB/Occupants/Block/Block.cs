using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public BlockPalette palette;

	[ContextMenu("Randomize")]
	public void Randomize() {
		MeshRenderer[] mrs = this.GetComponentsInChildren<MeshRenderer>();
		Material mat = palette.colorMats[Random.Range(0, palette.colorMats.Count)];
		for (int i = 0; i < mrs.Length; i++) {
			Material[] mats = mrs[i].sharedMaterials;
			if (i == 0)
				mats[1] = mat;
			else
				mats[0] = mat;
			mrs[i].sharedMaterials = mats;
		}
		MeshFilter[] mfs = this.GetComponentsInChildren<MeshFilter>();
		Mesh mesh = palette.letters[Random.Range(0, palette.letters.Count)];
		for (int i = 1; i < mfs.Length; i++) {
			mfs[i].sharedMesh = mesh;
		}
		this.transform.rotation = Quaternion.Euler(
			Random.Range(0, 5) * 90,
			Random.Range(0, 5) * 90,
			Random.Range(0, 5) * 90);
	}
}
