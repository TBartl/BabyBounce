using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnFallOut : MonoBehaviour, IOnMove {
	public void OnMove(IntVector3 from, IntVector3 to) {
		if (to.y < OccupantManager.S.lowestPoint)
			GameManager.S.ResetLevel();
	}
}
