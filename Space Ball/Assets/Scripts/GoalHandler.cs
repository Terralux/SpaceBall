using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler : MonoBehaviour {

	public GameObject cheerSound;

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Ball")) {
			col.GetComponent<BallController> ().Goal (tag);
			Destroy (Instantiate (cheerSound), 4f);
		}
	}

	public void AddShield(){
		transform.GetChild (0).gameObject.SetActive (true);
	}
}