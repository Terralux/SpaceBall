using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private Rigidbody2D rb2d;

	public Sprite player1Ball;
	public Sprite player2Ball;
	public Sprite neutralBall;

	private SpriteRenderer sr;
	private PointsHandler ph;

	public GameObject soundPrefab;

	private DynamicVariables dv;

	void Awake(){
		sr = GetComponent<SpriteRenderer> ();
		rb2d = GetComponent<Rigidbody2D>();
		ph = GameObject.FindGameObjectWithTag("PointsHandler").GetComponent<PointsHandler> ();
		dv = GameObject.FindGameObjectWithTag ("DynamicVariables").GetComponent<DynamicVariables> ();

		ResetBall ();
	}

	void Launch () {
		rb2d.velocity = Random.insideUnitCircle.normalized * dv.ballStartSpeed;
		sr.sprite = neutralBall;
	}

	void Update () {
		rb2d.rotation += rb2d.velocity.magnitude;
	}

	public void SmashBall(Transform player){
		if (player.CompareTag ("Player 1")) {
			sr.sprite = player1Ball;
		} else if (player.CompareTag ("Player 2")) {
			sr.sprite = player2Ball;
		} else {
			sr.sprite = neutralBall;
		}

		Vector2 direction = new Vector2 ((transform.position - player.position).x, (transform.position - player.position).y).normalized;
		rb2d.velocity = direction * dv.ballSpeedModifier * rb2d.velocity.magnitude;
	}

	public void Goal(string tag){
		if (tag == "Goal 1") {
			ph.UpdatePoints(0,1);
			if (sr.sprite == player1Ball) {
				ph.UpdateScreenText ("Oh no! It was his own goal!");
			} else if (sr.sprite == player2Ball) {
				ph.UpdateScreenText ("Nice job Player 2!");
			} else {
				ph.UpdateScreenText ("You guys Suck!");
			}
		} else {
			ph.UpdatePoints(1,0);
			if (sr.sprite == player1Ball) {
				ph.UpdateScreenText ("Nice job Player 1!");
			} else if (sr.sprite == player2Ball) {
				ph.UpdateScreenText ("Oh no! It was his own goal!");
			} else {
				ph.UpdateScreenText ("You guys Suck!");
			}
		}

		ResetBall();
	}

	void ResetBall(){
		rb2d.velocity = Vector2.zero;
		rb2d.rotation = 0f;
		transform.position = Vector3.zero;
		sr.sprite = neutralBall;

		StartCoroutine (WaitForBallLaunch ());
	}

	IEnumerator WaitForBallLaunch(){
		yield return new WaitForSeconds (3f);
		Launch ();
	}

	void OnCollisionEnter2D(Collision2D col){
		Destroy(Instantiate (soundPrefab), 2f);
	}

	public void RandomizeDirection(){
		rb2d.velocity = Random.insideUnitCircle.normalized * rb2d.velocity.magnitude;
	}

	public void SpeedBoost(){
		rb2d.velocity = rb2d.velocity * dv.ballSpeedBoost;
	}
}