using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour, IOnMove {

	public float moveTime = .25f;
	public AnimationCurve groundCurve;
	public AnimationCurve verticalCurve;

	Coroutine currentCoroutine;
	Vector3 lastPosition;

	void Update() {
		lastPosition = this.transform.position;
	}

	public void OnMove(IntVector3 from, IntVector3 to) {
		if (currentCoroutine != null)
			StopCoroutine(currentCoroutine);
		lastPosition = this.transform.position;
		currentCoroutine = StartCoroutine(MoveSmoothly(lastPosition, (Vector3)to));
	}

	IEnumerator MoveSmoothly(Vector3 fromPos, Vector3 toPos) {
		for (float t = 0; t < moveTime; t += Time.deltaTime) {
			float p = t / moveTime;
			this.transform.position = Vector3.Lerp(fromPos, toPos + Vector3.up * verticalCurve.Evaluate(p), groundCurve.Evaluate(p));
			yield return null;
		}
		this.transform.position = toPos;
	}
}
