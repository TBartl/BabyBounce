using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBounceGameManager : MonoBehaviour {

	public static BabyBounceGameManager S;

	public float speed = .1f;

	public bool started = false;

	public GameObject title;

	void Awake() {
		S = this;
	}

	void LateUpdate() {
		if (Input.GetKeyDown(KeyCode.Space) && !started) {
			started = true;
			title.SetActive(false);
		}
	}
}
