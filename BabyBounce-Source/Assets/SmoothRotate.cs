using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotate : MonoBehaviour {
	public AnimationCurve curve;

	public float rotateTime = .25f;
	Coroutine currentCoroutine;
	Quaternion lastRotation;

	void Update() {
		lastRotation = this.transform.rotation;
	}

	public void OnRotate(Quaternion from, Quaternion to) {
		if (currentCoroutine != null)
			StopCoroutine(currentCoroutine);

		currentCoroutine = StartCoroutine(RotateSmoothly(lastRotation, to));
	}

	IEnumerator RotateSmoothly(Quaternion fromRot, Quaternion toRot) {
		for (float t = 0; t < rotateTime; t += Time.deltaTime) {
			float p = t / rotateTime;
			this.transform.rotation = Quaternion.SlerpUnclamped(fromRot, toRot, curve.Evaluate(p));
			yield return null;
		}
		this.transform.rotation = toRot;
	}
}
