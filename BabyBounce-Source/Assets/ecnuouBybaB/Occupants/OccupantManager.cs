using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupantManager : MonoBehaviour {

	public static OccupantManager S;

	public Dictionary<IntVector3, GameObject> occupants;

	public int lowestPoint;

	void Awake () {
		S = this;
		occupants = new Dictionary<IntVector3, GameObject>();
	}

	public GameObject OccupantAt(IntVector3 pos) {
		GameObject toReturn;
		occupants.TryGetValue(pos, out toReturn);
		return toReturn;
	}


}
