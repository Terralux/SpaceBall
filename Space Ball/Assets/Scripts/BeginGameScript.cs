using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGameScript : MonoBehaviour {
	
	void Update () {
		if (Input.anyKeyDown) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (1);
		}
	}
}