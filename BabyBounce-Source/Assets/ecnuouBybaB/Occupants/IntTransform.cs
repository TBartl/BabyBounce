using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class IntTransform : MonoBehaviour {

	IntVector3 pos;

	public IntVector3 position {
		get {
			return pos;
		}
		set {
			pos = value;
			this.transform.position = (Vector3)pos;
		}
	}

	void Awake() {
		pos = IntVector3.fromVector3(this.transform.position);
	}
}
