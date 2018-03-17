using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct KeyDirectionPair {
	public KeyCode key;
	public IntVector3 direction;
}

[RequireComponent(typeof(Movable))]
[RequireComponent(typeof(Gravity))]
public class Player : MonoBehaviour {

	IntTransform intTransform;
	Movable movable;

	public int maxBufferSize = 3;

	public KeyDirectionPair[] keyDirectionPairs;

	List<IntVector3> buffer = new List<IntVector3>();

	public float moveTime = .2f;
	bool readyToMove = true;

	void Awake() {
		intTransform = this.GetComponent<IntTransform>();
		movable = this.GetComponent<Movable>();
	}

	void Update () {
		foreach (KeyDirectionPair pair in keyDirectionPairs) {
			if (Input.GetKeyDown(pair.key)) {
				if (buffer.Count < maxBufferSize)
					buffer.Add(pair.direction);
			}
		}

		if (buffer.Count > 0 && readyToMove) {
			IntVector3 dir = buffer[0];
			buffer.RemoveAt(0);
			movable.TryMoveTo(intTransform.position + dir);
			StartCoroutine(Moved());
		}
	}

	IEnumerator Moved() {
		readyToMove = false;
		yield return new WaitForSeconds(moveTime);
		readyToMove = true;
	}

}
