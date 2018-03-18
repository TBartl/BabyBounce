using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBounceSoundManager : MonoBehaviour {

	public static BabyBounceSoundManager S;

	void Awake() {
		S = this;
	}

	public AudioSource timeToPlay;
	public AudioSource bounce;
	public AudioSource yum;
	public AudioSource owch;
}
