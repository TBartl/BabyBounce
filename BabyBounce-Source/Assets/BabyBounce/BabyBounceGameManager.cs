using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBounceGameManager : MonoBehaviour {

	public static BabyBounceGameManager S;

	public float speed = .1f;

	public float speedIncrease = .05f;

	public bool started = false;

	public GameObject title;

	public float tutorialPace = 3;

	public List<Sprite> sprites;

	public SpriteRenderer instructionSR;

	public List<GameObject> candies;

	Vector3 endPos = Vector3.right * 7f;

	void Awake() {
		S = this;
	}

	void Start() {
		StartCoroutine(RunTutorial());
	}

	IEnumerator RunTutorial() {
		while (!Input.GetKeyDown(KeyCode.Space)) {
			yield return null;
		}
		Destroy(title.gameObject);
		started = true;
		yield return new WaitForSeconds(tutorialPace);

		instructionSR.sprite = sprites[0];
		yield return new WaitForSeconds(tutorialPace);

		instructionSR.sprite = sprites[1];
		SpawnCandy(0);
		yield return new WaitForSeconds(tutorialPace * 2);

		instructionSR.sprite = sprites[2];
		SpawnCandy(1);
		yield return new WaitForSeconds(tutorialPace * 2);

		instructionSR.sprite = sprites[3];
		yield return new WaitForSeconds(tutorialPace * 2);

		instructionSR.sprite = null;
	}

	void SpawnCandy(int type) {
		GameObject candy = Instantiate(candies[type], endPos + Vector3.up * Random.Range(-2, 2), Quaternion.identity);
	}
}
