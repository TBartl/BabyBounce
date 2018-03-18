using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBounceBaby : MonoBehaviour {
	Rigidbody2D rigid;
	public float speed;
	public float upSpeed = 2;

	public Vector2 xBounds;

	bool goingUp = true;

	bool alreadySwitched = false;

	public float rotSpeed = 100f;

	public float sizeIncrease = .2f;

	void Awake() {
		rigid = this.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (BabyBounceGameManager.S.started) {
			rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, goingUp ? upSpeed : -upSpeed);
			this.transform.rotation *= Quaternion.Euler(0, 0, -rotSpeed * Time.deltaTime);
		}
		else {
			rigid.velocity = Vector3.zero;
		}
		alreadySwitched = false;
	}
	void LateUpdate() {
		Vector3 finalPos = transform.position;
		finalPos.x = Mathf.Clamp(finalPos.x, xBounds.x, xBounds.y);
		transform.position = finalPos;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (alreadySwitched)
			return;
		alreadySwitched = true;
		goingUp = !goingUp;
		BabyBounceSoundManager.S.bounce.Play();
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.GetComponent<Candy>()) {
			if (collision.GetComponent<Candy>().isSize)
				this.transform.localScale = Vector3.one * Mathf.Min(transform.localScale.x + sizeIncrease, 3);
			else
				BabyBounceGameManager.S.speed += BabyBounceGameManager.S.speedIncrease;
			Destroy(collision.gameObject);
			BabyBounceSoundManager.S.yum.Play();
		}
		else if (collision.GetComponent<Spikes>()) {
			BabyBounceGameManager.S.EndGame();
			BabyBounceSoundManager.S.owch.Play();
		}
	}


}
