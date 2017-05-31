using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject powerUps;
	public GameObject obstacles;

	private DynamicVariables dv;

	void Awake () {
		dv = GameObject.FindGameObjectWithTag ("DynamicVariables").GetComponent<DynamicVariables> ();
		StartCoroutine (WaitForNextSpawn ());
	}

	IEnumerator WaitForNextSpawn(){
		yield return new WaitForSeconds (Random.Range (dv.minPowerUpSpawnDelay, dv.maxPowerUpSpawnDelay));

		Vector2 spawnPos = Random.insideUnitCircle * dv.spawnRange;

		Destroy (Instantiate (powerUps, transform.position + new Vector3 (spawnPos.x, spawnPos.y, 0), Quaternion.identity), dv.powerUpLifeTime);
		StartCoroutine (WaitForNextSpawn ());
	}

	public void SpawnObstacle(){
		Vector2 spawnPos = Random.insideUnitCircle * dv.spawnRange;
		Destroy (Instantiate (obstacles, transform.position + new Vector3 (spawnPos.x, spawnPos.y, 0), Quaternion.identity), dv.obstacleLifeTime);
	}
}