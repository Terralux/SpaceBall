using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlayArea : MonoBehaviour
{

    private int numberOfSegments = 24;
    private float radius = 5;

    public GameObject boundary;
	public GameObject player1Goal;
	public GameObject player2Goal;

    private List<GameObject> currentBoundaries = new List<GameObject>();

	private DynamicVariables dv;

	void Awake() {
		numberOfSegments = 2 * numberOfSegments;
	    GenerateMap();
		dv = GameObject.FindGameObjectWithTag ("DynamicVariables").GetComponent<DynamicVariables> ();
	}

    void GenerateMap()
    {
        foreach (GameObject go in currentBoundaries)
        {
            Destroy(go);
        }

        currentBoundaries = new List<GameObject>();

        for (int i = 0; i < numberOfSegments; i++)
        {
            float angle = 2 * Mathf.PI * i / numberOfSegments;
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

			if (i == 0) {
				currentBoundaries.Add (Instantiate (player1Goal));
			} else if (i == numberOfSegments / 2) {
				currentBoundaries.Add (Instantiate (player2Goal));
			} else {
				currentBoundaries.Add (Instantiate (boundary));
			}

			currentBoundaries [i].transform.SetParent (transform);
            currentBoundaries[i].transform.position = new Vector3(x, y, transform.position.z + 10);
            currentBoundaries[i].transform.rotation = Quaternion.LookRotation(transform.forward,
                transform.position - currentBoundaries[i].transform.position);
			if (i == 0 || i == numberOfSegments / 2) {
				currentBoundaries [i].transform.Rotate (new Vector3 (0, 0, 180));
			}
        }
    }

	void Update(){
		transform.Rotate (new Vector3 (0, 0, Time.deltaTime * dv.levelRotationSpeed));
		dv.levelRotationSpeed += dv.levelRotationAcceleration * Time.deltaTime;
	}
}