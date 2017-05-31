using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsHandler : MonoBehaviour {

	private int player1Points;
	private int player2Points;

	public Text scoreField;
	public Text textField;

	public Text counterField;

	private DynamicVariables dv;

	void Awake(){
		player1Points = 0;
		player2Points = 0;

		dv = GameObject.FindGameObjectWithTag ("DynamicVariables").GetComponent<DynamicVariables> ();

		StartCoroutine (WaitForCountDown (dv.countDownTime));
	}

	public void UpdatePoints(int player1, int player2){
		player1Points += player1;
		player2Points += player2;

		if (dv.pointsToWinAMatch == player1Points || dv.pointsToWinAMatch == player2Points) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (0);
		}

		scoreField.text = player1Points.ToString () + " : " + player2Points.ToString ();
		StartCoroutine (WaitForCountDown (dv.countDownTime));
	}

	public void UpdateScreenText(string text){
		textField.text = text;
		StartCoroutine (WaitForTextReset ());
	}

	IEnumerator WaitForTextReset(){
		yield return new WaitForSeconds (3f);
		textField.text = "Points";
	}

	IEnumerator WaitForCountDown(int i){
		counterField.gameObject.SetActive (true);
		counterField.text = i.ToString ();
		yield return new WaitForSeconds (1f);

		if (i > 0) {
			StartCoroutine (WaitForCountDown (i - 1));
		} else {
			counterField.gameObject.SetActive (false);
		}
	}
}