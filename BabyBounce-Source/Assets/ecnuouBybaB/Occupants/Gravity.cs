using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movable))]
public class Gravity : MonoBehaviour, IOnMove {

	IntTransform intTransform;
	Movable movable;

	public float fallTime;

	bool falling = false;

	public bool grasping = true;
	public List<GameObject> graspers;

	void Awake() {
		intTransform = this.GetComponent<IntTransform>();
		movable = this.GetComponent<Movable>();
	}

	public void OnMove(IntVector3 from, IntVector3 to) {
		if (!falling)
			StartCoroutine(ApplyGravity());
	}

	IEnumerator ApplyGravity() {
		yield return null;
		falling = true;
		while (true) {
			bool didGrasp = false;
			for (int i = 0; i < 4; i++) {
				IntVector3 inDir = intTransform.position + IntVector3.directions[i];
				if (OccupantManager.S.OccupantAt(inDir) && !OccupantManager.S.OccupantAt(inDir + IntVector3.up)) {
					didGrasp = true;
					graspers[i].SetActive(true);
				}
				else {
					graspers[i].SetActive(false);
				}
			}
			if (didGrasp)
				break;

			if (OccupantManager.S.OccupantAt(intTransform.position + IntVector3.down))
				break;
			

			movable.TryMoveTo(intTransform.position + IntVector3.down);
			yield return new WaitForSeconds(fallTime);
		}
		falling = false;
	}

	public bool IsFalling() {
		return falling;
	}
	
	
}
