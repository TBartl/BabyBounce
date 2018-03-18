using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IntTransform))]
public class Occupant : MonoBehaviour {

	IntTransform intTransform;

	// Use this for initialization
	void Awake () {
		intTransform = this.GetComponent<IntTransform>();
		OccupantManager.S.occupants[intTransform.position] = this.gameObject;
		OccupantManager.S.lowestPoint = Mathf.Min(OccupantManager.S.lowestPoint, intTransform.position.y);
	}
}
