using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour {

	public GameObject ballHitSound;

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Ball") && !GetComponent<CharacterControllerSimple>().isFalling) {
			col.GetComponent<BallController> ().SmashBall (transform);
			Destroy (Instantiate (ballHitSound), 2f);
		}
	}
}