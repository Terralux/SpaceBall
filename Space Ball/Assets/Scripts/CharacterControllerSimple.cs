using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerSimple : MonoBehaviour {

	public float maxDistanceToCenter = 4.5f;
	private float minDistanceToCenter = 1f;
	private float currentDistance = 4.5f;

	private bool isJumping;

	[HideInInspector]
	public bool isFalling;

	private DynamicVariables dv;

	void Awake () {
		dv = GameObject.FindGameObjectWithTag ("DynamicVariables").GetComponent<DynamicVariables>();
		currentDistance = maxDistanceToCenter;
	}

	void Update () {
		transform.rotation = Quaternion.LookRotation(Vector3.forward, -transform.position);

		float move = 
			(Input.GetKey (
			dv.GetRunRightKey (tag)
		) ? 1 : 0) - 
			(Input.GetKey (
				dv.GetRunLeftKey (tag)
			) ? 1 : 0);

		if (Input.GetKey (dv.GetJumpKey (tag)) && !isJumping) {
			isJumping = true;
			isFalling = false;
		}

		if (isJumping) {
			if (isFalling) {
				currentDistance += dv.jumpSpeed * (new Vector2 (transform.position.x, transform.position.y).magnitude);
				if (currentDistance >= maxDistanceToCenter) {
					isJumping = false;
					currentDistance = maxDistanceToCenter;
				}
			} else {
				currentDistance -= dv.jumpSpeed * (new Vector2 (transform.position.x, transform.position.y).magnitude);
				if (currentDistance <= minDistanceToCenter) {
					isFalling = true;
				}
			}
		}

		transform.position = (-transform.up) * currentDistance + transform.right * move * dv.movementSpeed;
	}
}