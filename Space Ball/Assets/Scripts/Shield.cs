using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public GameObject ballHitSound;

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Ball")) {
			Destroy (Instantiate (ballHitSound), 4f);
			col.gameObject.GetComponent<BallController> ().SmashBall (transform);
			gameObject.SetActive (false);
		}
	}
}