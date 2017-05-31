using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownEffect : MonoBehaviour {

	private float maxDistance = 1.5f;

	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Ball")) {

			float distance = Vector3.Distance (transform.position, col.transform.position);
			distance -= 9.5f;

			Time.timeScale = distance / maxDistance;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Ball")) {
			Time.timeScale = 1f;
		}
	}
}