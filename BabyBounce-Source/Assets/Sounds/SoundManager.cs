using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {
	public static SoundManager S;

	public List<AudioClip> phrases;

	public AudioSource phrase;

	public AudioSource step;
	public AudioSource push;
	public AudioSource win;

	int lastScene = -1;

	void Awake() {
		if (S) {
			Destroy(this.gameObject);
		} else {
			S = this;
			DontDestroyOnLoad(this.gameObject);
			SceneManager.activeSceneChanged += SceneChanged;
			SceneChanged();
		}
	}

	void SceneChanged(Scene from, Scene to) {
		SceneChanged();
	}

	void OnDestroy() {
		SceneManager.activeSceneChanged -= SceneChanged;
	}

	void SceneChanged() {
		int newScene = SceneManager.GetActiveScene().buildIndex;
		if (newScene == 0) {
			Destroy(this.gameObject);
		} else if (lastScene != newScene) {
			phrase.clip = phrases[newScene - 1];
			phrase.Play();
		}
		lastScene = newScene;
	}
}
