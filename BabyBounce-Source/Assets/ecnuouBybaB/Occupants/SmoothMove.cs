using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour, IOnMove {

	public float moveTime = .25f;
	public AnimationCurve groundCurve;
	public AnimationCurve verticalCurve;

	Coroutine currentCoroutine;
	Vector3 lastPosition;
	Vector3 targetPos;

	void Start() {
		targetPos = this.transform.position;
	}

	public void OnMove(IntVector3 from, IntVector3 to) {
		if (currentCoroutine != null)
			StopCoroutine(currentCoroutine);
		currentCoroutine = StartCoroutine(MoveSmoothly(lastPosition, (Vector3)to));
	}

	IEnumerator MoveSmoothly(Vector3 fromPos, Vector3 toPos) {
		for (float t = 0; t < moveTime; t += Time.deltaTime) {
			float p = t / moveTime;
			targetPos = Vector3.Lerp(fromPos, toPos, groundCurve.Evaluate(p));
			if (toPos.y - fromPos.y > -.5f)
				targetPos += Vector3.up * verticalCurve.Evaluate(p);
			else
				targetPos.y = Mathf.Lerp(fromPos.y, toPos.y, p);
			yield return null;
		}
		this.transform.position = toPos;
	}

	void LateUpdate() {
		this.transform.position = targetPos;
		lastPosition = this.transform.position;
	}
}
