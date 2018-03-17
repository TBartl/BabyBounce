using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotate : MonoBehaviour {
	public AnimationCurve curve;

	public float rotateTime = .25f;
	Coroutine currentCoroutine;
	Quaternion targetRotation;
	Quaternion lastRotation;

	void Start() {
		targetRotation = this.transform.rotation;
	}

	public void OnRotate(Quaternion from, Quaternion to) {
		if (currentCoroutine != null)
			StopCoroutine(currentCoroutine);

		currentCoroutine = StartCoroutine(RotateSmoothly(lastRotation, to));
	}

	IEnumerator RotateSmoothly(Quaternion fromRot, Quaternion toRot) {
		for (float t = 0; t < rotateTime; t += Time.deltaTime) {
			float p = t / rotateTime;
			targetRotation = Quaternion.SlerpUnclamped(fromRot, toRot, curve.Evaluate(p));
			yield return null;
		}
		this.transform.rotation = toRot;
	}

	void LateUpdate() {
		this.transform.rotation = targetRotation;
		lastRotation = this.transform.rotation;
	}
}
