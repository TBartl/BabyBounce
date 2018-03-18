using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour {
	void LateUpdate () {
		this.transform.rotation = Quaternion.identity;
	}
}
