﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour {

	public bool isSize;

	void Update() {
		if (BabyBounceGameManager.S.started)
			this.transform.position += Vector3.left * BabyBounceGameManager.S.speed * Time.deltaTime;
	}

}
