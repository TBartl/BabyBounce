using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IntTransform))]
public class PlayerDeath : MonoBehaviour {

	IntTransform intTransform;

	void Awake() {
		intTransform = this.GetComponent<IntTransform>();		
	}


	void FixedUpdate() {
		GameObject below = OccupantManager.S.OccupantAt(intTransform.position + IntVector3.down);
		if (below && below.GetComponent<Spike>()) {
			Debug.Log("DIE");
		}
	}
}
