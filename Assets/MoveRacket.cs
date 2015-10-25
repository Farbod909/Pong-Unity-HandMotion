using UnityEngine;
using System.Collections;

public class MoveRacket : MonoBehaviour {
	public float speed = 30;  
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxisRaw("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2(h, 0) * speed;
	}

}
