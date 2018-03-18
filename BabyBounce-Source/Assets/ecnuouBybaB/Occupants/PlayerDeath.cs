using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IntTransform))]
public class PlayerDeath : MonoBehaviour {

	IntTransform intTransform;

	public GameObject blood;

	void Awake() {
		intTransform = this.GetComponent<IntTransform>();		
	}

	void FixedUpdate() {
		GameObject below = OccupantManager.S.OccupantAt(intTransform.position + IntVector3.down);
		if (below && below.GetComponent<Spike>()) {
			IntVector3 targetPos = intTransform.position + IntVector3.down;
			OccupantManager.S.occupants[targetPos] = null;
			this.GetComponent<Movable>().TryMoveTo(targetPos);
			Instantiate(blood, this.transform.position, Quaternion.identity);
			GameManager.S.NextLevel();
		}
	}
}
