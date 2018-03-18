using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnTime : MonoBehaviour {

	IEnumerator Start() {
		this.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds(22);
		this.GetComponent<SpriteRenderer>().enabled = true;
	}
}
