using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	static int blockCount;
	public List<Sprite> randomSprites;

	void Awake() {
		blockCount += 1;
	}

	void Start() {
		SelectRandomSprite();
	}

	void SelectRandomSprite() {
		this.GetComponent<SpriteRenderer>().sprite = randomSprites[Random.Range(0, randomSprites.Count)];
	}

}
