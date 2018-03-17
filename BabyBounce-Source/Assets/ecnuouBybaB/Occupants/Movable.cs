using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {

	IntTransform intTransform;
	public bool rotate;

	void Awake() {
		intTransform = this.GetComponent<IntTransform>();
	}

	public bool TryMoveTo(IntVector3 to) {
		if (OccupantManager.S.OccupantAt(to) != null)
			return false;

		IntVector3 from = intTransform.position;
		OccupantManager.S.occupants.Remove(from);
		OccupantManager.S.occupants[to] = this.gameObject;
		intTransform.position = to;

		if (rotate) {
			IntVector3 groundedTo = new IntVector3(to.x, 0, to.z);
			IntVector3 groundedFrom = new IntVector3(from.x, 0, from.z);
			this.transform.rotation = IntVector3.RotationFromDir(groundedTo - groundedFrom);
		}
		return true;
	}


}
