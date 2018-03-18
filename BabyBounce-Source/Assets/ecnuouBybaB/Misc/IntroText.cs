using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour {
	static int lastScene = -1;

	public float waitTime = .05f;

	IEnumerator Start() {
		int thisScene = SceneManager.GetActiveScene().buildIndex;
		if (lastScene == thisScene) {
			Destroy(this.gameObject);
			yield break;
		}
		lastScene = thisScene;

		Text textBox = this.GetComponentInChildren<Text>();
		string originalText = textBox.text;
		for (int i = 0; i < originalText.Length; i++) {
			textBox.text = originalText.Substring(0, i) + 
				"<color=#00000000>" + 
				originalText.Substring(i) + 
				"</color>";
			yield return new WaitForSeconds(waitTime);
		}

		float fadeAwayTime = 1f;
		CanvasGroup canvasGroup = this.GetComponentInChildren<CanvasGroup>();
		for (float t = 0; t < fadeAwayTime; t += Time.deltaTime) {
			canvasGroup.alpha = 1 - t / fadeAwayTime;
			yield return null;
		}
	}
}
