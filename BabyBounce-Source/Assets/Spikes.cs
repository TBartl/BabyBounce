using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	void Update() {
		if (BabyBounceGameManager.S.started == true) {
			this.transform.position += Vector3.left * BabyBounceGameManager.S.speed * Time.deltaTime;
		}
	}
}
