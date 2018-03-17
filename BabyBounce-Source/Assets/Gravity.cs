using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movable))]
public class Gravity : MonoBehaviour, IOnMove {

	IntTransform intTransform;
	Movable movable;

	public float fallTime;

	bool falling = false;

	void Awake() {
		intTransform = this.GetComponent<IntTransform>();
		movable = this.GetComponent<Movable>();
	}

	public void OnMove(IntVector3 from, IntVector3 to) {
		if (!falling)
			StartCoroutine(ApplyGravity());
	}

	IEnumerator ApplyGravity() {
		falling = true;
		while (!OccupantManager.S.OccupantAt(intTransform.position + IntVector3.down)) {
			movable.TryMoveTo(intTransform.position + IntVector3.down);
			yield return new WaitForSeconds(fallTime);
		}
		falling = false;
	}

	public bool IsFalling() {
		return falling;
	}
	
	
}
