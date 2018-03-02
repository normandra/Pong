using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

	public float speed;
	public int lScore = 0;
	public int rScore = 0;
	public Text rSc;
	public Text lSc;

	void Start ()
	{
		// Initial Velocity
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos,float racketHeight) {
		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void OnCollisionEnter2D (Collision2D col){

		if (col.gameObject.name == "Brett") {
			float y = hitFactor (transform.position, col.transform.position, col.collider.bounds.size.y);
			Vector2 dir = new Vector2 (1, y).normalized;
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}

		if (col.gameObject.name == "Brett2") {
			float y = hitFactor (transform.position, col.transform.position, col.collider.bounds.size.y);
			Vector2 dir = new Vector2 (-1, y).normalized;
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}

		if(col.gameObject.name == "right") {
			lScore++;
			lSc.text = lScore.ToString ();
			Reset ();
		}

		if(col.gameObject.name == "left") {
			rScore++;
			rSc.text = rScore.ToString ();
			Reset ();
		}
	}

	void Reset(){
		transform.position = new Vector3 (0, 0, 0);
	}
}
