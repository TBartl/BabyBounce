using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	public GameObject spikes;

	public AnimationCurve candyCurve;
	public AnimationCurve spikeCurve;

	public int targetScene = 0;

	float startTime = 0;

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
		yield return new WaitForSeconds(tutorialPace * .5f);

		instructionSR.sprite = sprites[0];
		yield return new WaitForSeconds(tutorialPace);

		instructionSR.sprite = sprites[1];
		SpawnCandy(0);
		yield return new WaitForSeconds(tutorialPace * 2);

		instructionSR.sprite = sprites[2];
		SpawnCandy(1);
		yield return new WaitForSeconds(tutorialPace * 2);

		instructionSR.sprite = sprites[3];
		SpawnSpike();
		yield return new WaitForSeconds(tutorialPace * 2);

		if (started) {
			startTime = Time.timeSinceLevelLoad;
			instructionSR.sprite = null;
			StartCoroutine(SpawnCandies());
			StartCoroutine(SpawnSpikes());
		}
	}

	IEnumerator SpawnCandies() {
		yield return new WaitForSeconds(Random.Range(0, 3));
		while (started) {
			yield return new WaitForSeconds(candyCurve.Evaluate(Time.timeSinceLevelLoad - startTime));
			SpawnCandy(Random.Range(0, 2));
		}
	}
	IEnumerator SpawnSpikes() {
		yield return new WaitForSeconds(Random.Range(0, 3));
		while (started) {
			yield return new WaitForSeconds(spikeCurve.Evaluate(Time.timeSinceLevelLoad - startTime));
			SpawnSpike();
		}
	}
	void SpawnCandy(int type) {
		Instantiate(candies[type], endPos + Vector3.up * Random.Range(-2, 2), Quaternion.identity);
	}

	void SpawnSpike() {
		Instantiate(spikes);
	}

	public void EndGame() {
		started = false;
		instructionSR.sprite = sprites[4];
		StartCoroutine(WaitForRestart());
	}

	IEnumerator WaitForRestart() {
		while (!Input.GetKeyDown(KeyCode.Space)) {
			yield return null;
		}
		SceneManager.LoadScene(targetScene);
	}
}
