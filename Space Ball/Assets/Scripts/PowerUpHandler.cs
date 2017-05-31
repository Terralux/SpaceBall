using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour {

	private PowerUpPickup.PowerUps currentPowerUp = PowerUpPickup.PowerUps.NONE;
	public GameObject pickUpSound;

	private DynamicVariables dv;

	void Awake(){
		dv = GameObject.FindGameObjectWithTag ("DynamicVariables").GetComponent<DynamicVariables> ();
	}

	void Update(){
		if (currentPowerUp == PowerUpPickup.PowerUps.NONE) {
			return;
		}

		if (Input.GetKeyDown (dv.GetPowerUpKey (tag))) {
			switch (currentPowerUp) {
			case PowerUpPickup.PowerUps.OBSTACLE:
				GameObject.FindGameObjectWithTag ("Spawner").GetComponent<Spawner> ().SpawnObstacle ();
				break;
			case PowerUpPickup.PowerUps.RANDOM_DIRECTION:
				GameObject.FindGameObjectWithTag ("Ball").GetComponent<BallController> ().RandomizeDirection ();
				break;
			case PowerUpPickup.PowerUps.SHIELD:
				if (tag == "Player 1") {
					GameObject.FindGameObjectWithTag ("Goal 1").GetComponent<GoalHandler> ().AddShield ();
				} else {
					GameObject.FindGameObjectWithTag ("Goal 2").GetComponent<GoalHandler> ().AddShield ();
				}
				break;
			case PowerUpPickup.PowerUps.SPEED_BALL:
				GameObject.FindGameObjectWithTag ("Ball").GetComponent<BallController> ().SpeedBoost ();
				break;
			}

			currentPowerUp = PowerUpPickup.PowerUps.NONE;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("PowerUp")) {
			currentPowerUp = col.GetComponent<PowerUpPickup> ().myPowerUpType;
			Destroy (col.gameObject);
			Destroy (Instantiate (pickUpSound), 4f);
		}
	}
}