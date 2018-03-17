using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour {

	[SerializeField] GameObject followObject;
	public float pivotLerpPower;
	public float cameraLerpPower;

	public float hoverOverObjectAmount = 3;
	public float hoverOverPivotAmount = 2;
	public float backAmount = 3;

	public float velocityDistMultiplier;
	public AnimationCurve velocityDampenByCurrent;

	Vector3 targetHoverPivot;
	Vector3 currHoverPivot;

	Vector3 targetCameraPos;

	int playerDirection;

	Vector3 lastObjectPos;
	Vector3 objectVelocity;

	public static CameraFollow S;

	void Awake() {
		S = this;
	}

	void Start() {
		Player player = FindObjectOfType<Player>();
		if (player)
			followObject = player.gameObject;
		if (followObject) {
			UpdateTargetHoverPivotPos();
			currHoverPivot = targetHoverPivot;
			lastObjectPos = followObject.transform.position;
		}
	}

	void LateUpdate() {
		// Update rotation based off input
		int numDirections = IntVector3.directions.Length;
		if (Input.GetKeyDown(KeyCode.Q))
			playerDirection = (playerDirection - 1 + numDirections) % numDirections;
		if (Input.GetKeyDown(KeyCode.E))
			playerDirection = (playerDirection + 1) % numDirections;

		// Update velocity
		if (followObject) {
			objectVelocity += followObject.transform.position - lastObjectPos;
			objectVelocity = objectVelocity.normalized * Mathf.Max(0,
				objectVelocity.magnitude - velocityDampenByCurrent.Evaluate(objectVelocity.magnitude) * Time.deltaTime);
			lastObjectPos = followObject.transform.position;
		}

		// Move pivot point
		if (followObject) {
			UpdateTargetHoverPivotPos();
		}
		currHoverPivot = Vector3.Lerp(currHoverPivot, targetHoverPivot, Time.deltaTime * pivotLerpPower);

		// Move camera position
		targetCameraPos = currHoverPivot - (Vector3)IntVector3.directions[playerDirection] * backAmount + Vector3.up * hoverOverPivotAmount;
		this.transform.position = Vector3.Lerp(this.transform.position, targetCameraPos, Time.deltaTime * cameraLerpPower);

		// Look at pivot
		this.transform.LookAt(currHoverPivot);
	}

	void UpdateTargetHoverPivotPos() {
		targetHoverPivot = followObject.transform.position + objectVelocity * velocityDistMultiplier + Vector3.up * hoverOverObjectAmount;
	}

	public int GetDirectionOffset() {
		return playerDirection;
	}
}
