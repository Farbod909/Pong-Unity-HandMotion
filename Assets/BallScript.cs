using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	public float speed = 30;

	void Start() {
		// Initial Velocity
		GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos,
	                float racketWidth) {
		// ascii art:
		// ||  1 <- at the top of the racket
		// ||
		// ||  0 <- at the middle of the racket
		// ||
		// || -1 <- at the bottom of the racket
		return (ballPos.x - racketPos.x) / racketWidth;
	}

	void OnCollisionEnter2D(Collision2D col) {
		// Note: 'col' holds the collision information. If the
		// Ball collided with a racket, then:
		//   col.gameObject is the racket
		//   col.transform.position is the racket's position
		//   col.collider is the racket's collider

		if (col.gameObject.name == "Racket") {
			// Calculate hit Factor
			float x = hitFactor (transform.position,
			                    col.transform.position,
			                    col.collider.bounds.size.x);
			
			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2 (x, 1).normalized;
			
			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}
		if (col.gameObject.name == "WallTop") {
			// Calculate hit Factor
			float x = hitFactor (transform.position,
			                     col.transform.position,
			                     col.collider.bounds.size.x);
			
			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2 (x, -1).normalized;
			
			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speed;

		}

	}
}
