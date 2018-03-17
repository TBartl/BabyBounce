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
		bool toReturn = false;

		IntVector3 from = intTransform.position;

		if (OccupantManager.S.OccupantAt(to) != null)
			toReturn = false;
		else {
			OccupantManager.S.occupants.Remove(from);
			OccupantManager.S.occupants[to] = this.gameObject;
			intTransform.position = to;
			toReturn = true;

			foreach (IOnMove onMove in this.GetComponentsInChildren<IOnMove>())
				onMove.OnMove(from, to);
		}
		

		if (rotate) {
			IntVector3 groundedFrom = new IntVector3(from.x, 0, from.z);
			IntVector3 groundedTo = new IntVector3(to.x, 0, to.z);

			Quaternion fromRot = this.transform.rotation;
			Quaternion toRot = IntVector3.RotationFromDir(groundedTo - groundedFrom);

			this.transform.rotation = toRot;

			SmoothRotate smoothRotate = this.GetComponentInChildren<SmoothRotate>();
			if (smoothRotate)
				smoothRotate.OnRotate(fromRot, toRot);
		}
		return toReturn;
	}


}
