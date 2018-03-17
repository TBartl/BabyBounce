using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	static int blockCount;
	public List<Sprite> randomSprites;

	Block() {
		blockCount = 0;
	}

	void Awake() {
		blockCount += 1;
	}

	void Start() {
		SelectRandomSprite();
	}

	void Update() {
		if (BabyBounceGameManager.S.started == true) {
			this.transform.position += Vector3.left * BabyBounceGameManager.S.speed * Time.deltaTime;
			if (this.transform.position.x < -8) {
				this.transform.position += Vector3.right * blockCount / 2;
				SelectRandomSprite();
			}
		}
	}

	void SelectRandomSprite() {
		this.GetComponent<SpriteRenderer>().sprite = randomSprites[Random.Range(0, randomSprites.Count)];
	}

}
