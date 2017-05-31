using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicVariables : MonoBehaviour {

	[Header("Player 1 controls")]
	public KeyCode player1RunLeftKey;
	public KeyCode player1RunRightKey;
	public KeyCode player1JumpKey;
	public KeyCode player1PowerUpKey;

	[Header("Player 2 controls")]
	public KeyCode player2RunLeftKey;
	public KeyCode player2RunRightKey;
	public KeyCode player2JumpKey;
	public KeyCode player2PowerUpKey;

	[Header("Player Stats")]
	public float movementSpeed;
	public float jumpSpeed;

	[Header("Game Stats")]
	public int countDownTime;
	public int pointsToWinAMatch;

	[Space(5)]
	public float ballStartSpeed;
	public float ballSpeedModifier;

	[Space(5)]
	public float levelRotationSpeed;
	public float levelRotationAcceleration;

	[Space(5)]
	public float powerUpRotationSpeed;
	public float powerUpLifeTime;
	public float maxPowerUpSpawnDelay;
	public float minPowerUpSpawnDelay;
	public float spawnRange;

	[Header("PowerUp Stats")]
	public float ballSpeedBoost;
	public float obstacleLifeTime;

	public KeyCode GetRunLeftKey(string tag){
		if (tag == "Player 1") {
			return player1RunLeftKey;
		} else {
			return player2RunLeftKey;
		}
	}

	public KeyCode GetRunRightKey(string tag){
		if (tag == "Player 1") {
			return player1RunRightKey;
		} else {
			return player2RunRightKey;
		}
	}

	public KeyCode GetJumpKey(string tag){
		if (tag == "Player 1") {
			return player1JumpKey;
		} else {
			return player2JumpKey;
		}
	}

	public KeyCode GetPowerUpKey(string tag){
		if (tag == "Player 1") {
			return player1PowerUpKey;
		} else {
			return player2PowerUpKey;
		}
	}
}