using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour {

	public enum PowerUps{
		NONE,
		RANDOM_DIRECTION,
		SPEED_BALL,
		SHIELD,
		OBSTACLE
	}

	[HideInInspector]
	public PowerUps myPowerUpType;

	private DynamicVariables dv;

	void Awake(){
		System.Array A = System.Enum.GetValues (typeof(PowerUps));
		myPowerUpType = (PowerUps)A.GetValue (Random.Range (1, A.Length));

		dv = GameObject.FindGameObjectWithTag ("DynamicVariables").GetComponent<DynamicVariables> (); 
	}

	void Update(){
		transform.Rotate (new Vector3 (0, 0, Time.deltaTime * dv.powerUpRotationSpeed));
	}

}