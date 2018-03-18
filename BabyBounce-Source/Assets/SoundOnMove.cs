using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnMove : MonoBehaviour, IOnMove {
	public void OnMove(IntVector3 from, IntVector3 to) {
		if (from.y <= to.y) {
			SoundManager.S.step.Play();
		}
	}
}
