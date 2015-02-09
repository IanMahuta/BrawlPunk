using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed = 5;  //distance that the enemy moves every second
	float timeSinceMove = 0;

	// Move the enemy
	void Update () {
		timeSinceMove = Time.deltaTime;
		transform.position = transform.position + new Vector3 (speed*timeSinceMove, 0, 0); 
		//transform.rigidbody2D.AddForce(new Vector2(speed,0.0f));
	}

	// detect if the enemy was hit by a live shot or not
	void OnCollisionEnter2D(Collision2D hitBy){
		if(hitBy.gameObject.tag=="shot"){  // if enemy was hit by a shot, destroy the enemy
			Destroy (hitBy.gameObject);
			Destroy (gameObject);
		}
	}
}
