using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager S;
	Image image;

	public bool running = true;

	float fadeTime = .5f;

	void Awake() {
		S = this;
		image = this.GetComponentInChildren<Image>();
	}

	void Start() {
		StartCoroutine(FadeFromBlack());
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha0) && !running) {
			running = false;
			StartCoroutine(FadeToBlack(0));
		}
	}

	public void ResetLevel() {
		if (!running)
			return;
		running = false;
		StartCoroutine(FadeToBlack(SceneManager.GetActiveScene().buildIndex));
	}

	public void NextLevel() {
		if (!running)
			return;
		running = false;
		StartCoroutine(FadeToBlack((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings, true));
	}

	IEnumerator FadeFromBlack() {
		running = true;
		for (float t = 0; t < fadeTime; t += Time.deltaTime) {
			float p = t / fadeTime;
			image.color = Color.Lerp(Color.black, Color.clear, p);
			yield return null;
		}
		image.color = Color.clear;
	}
	IEnumerator FadeToBlack(int scene, bool endLevel = false) {
		running = false;
		for (float t = 0; t < fadeTime; t += Time.deltaTime) {
			float p = t / fadeTime;
			image.color = Color.Lerp(Color.clear, Color.black, p);
			yield return null;
		}

		if (endLevel) {
			CanvasGroup group = this.GetComponentInChildren<CanvasGroup>();
			float textInTime = 1f;
			for (float t = 0; t < textInTime; t += Time.deltaTime) {
				float p = t / textInTime;
				group.alpha = p;
				yield return null;
			}
			yield return new WaitForSeconds(2);
			for (float t = 0; t < textInTime; t += Time.deltaTime) {
				float p = t / textInTime;
				group.alpha = 1 - p;
				yield return null;
			}
		}
		
		SceneManager.LoadScene(scene);
	}

}
