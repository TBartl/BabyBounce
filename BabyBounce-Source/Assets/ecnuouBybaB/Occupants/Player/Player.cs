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

	public KeyCode[] keys;

	List<IntVector3> buffer = new List<IntVector3>();

	public float moveTime = .2f;
	bool readyToMove = true;

	public bool canClimb = false;
	public bool canPush = false;

	void Awake() {
		intTransform = this.GetComponent<IntTransform>();
		movable = this.GetComponent<Movable>();
	}

	void Update () {
		for (int i = 0; i < keys.Length; i++) {
			if (Input.GetKeyDown(keys[i]) && buffer.Count < maxBufferSize) {
				IntVector3 dir = IntVector3.directions[(i + CameraFollow.S.GetDirectionOffset()) % 4];
				buffer.Add(dir);
			}
		}

		if (buffer.Count > 0 && readyToMove) {
			IntVector3 dir = buffer[0];
			buffer.RemoveAt(0);
			IntVector3 testPos = intTransform.position + dir;
			GameObject objectAtSpot = OccupantManager.S.OccupantAt(testPos);
			if (canClimb && objectAtSpot && !OccupantManager.S.OccupantAt(testPos + IntVector3.up) && !OccupantManager.S.OccupantAt(intTransform.position + IntVector3.up))
				movable.TryMoveTo(testPos + IntVector3.up);
			else if (canPush && objectAtSpot && OccupantManager.S.OccupantAt(testPos + IntVector3.up) && OccupantManager.S.OccupantAt(intTransform.position + IntVector3.down)) {
				objectAtSpot.GetComponent<Movable>().TryMoveTo(testPos + dir);
				movable.TryMoveTo(testPos);
			}
			else
				movable.TryMoveTo(testPos);
			StartCoroutine(Moved());
		}
	}

	IEnumerator Moved() {
		readyToMove = false;
		yield return new WaitForSeconds(moveTime);
		readyToMove = true;
	}

}
