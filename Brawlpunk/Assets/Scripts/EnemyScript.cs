using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed = 5;  //distance that the enemy moves every second
	float timeSinceMove = 0;

	// Move the enemy
	void Update () {
		timeSinceMove = Time.deltaTime;
		transform.position = transform.position + new Vector3 (speed*timeSinceMove, 0, 0);
	}

	// detect if the enemy was hit by a live shot or not
	void OnCollisionEnter2D(Collision2D hitBy){
		if(hitBy.gameObject.tag=="live"){  // if enemy was hit by a live shot, destroy the enemy
			Debug.Log ("hit");
			Destroy (this.gameObject);
		} else if(hitBy.gameObject.tag=="shot"){ // checking if hit by a dead shot
			Debug.Log ("hit by dead shot");
		}
	}
}
