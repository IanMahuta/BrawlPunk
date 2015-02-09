using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed = 4.0f;  //distance that the enemy moves every second
	float timeSinceMove = 0;
	GameObject player;

	void Start(){
		player = GameObject.Find ("player");
	}

	// Move the enemy towards the player
	void Update () {
		timeSinceMove = Time.deltaTime;
		float moveDistance = speed * timeSinceMove;  // get distance that the enemy should move

		Vector3 playerPos = player.transform.position; // current player position
		Vector3 currentPos = this.transform.position; // current position of the enemy
		Vector3 newPos = this.transform.position; // new position that the enemy should move to

		/*
		 * Determine where the enemy needs to move.  This is always towards the player's x position.
		 * If the moveDistance is greater than the distance between the player and the enemy, then the enemy moves
		 * to the x position of the player.
		 */
		if (playerPos.x > currentPos.x){
			if((playerPos.x - currentPos.x)> moveDistance){
				newPos.x += moveDistance;
			}else{
				newPos.x = playerPos.x;
			}
		} else if (playerPos.x < currentPos.x){
			if((currentPos.x - playerPos.x) > moveDistance){
				newPos.x -= moveDistance;
			}else{
				newPos.x = playerPos.x;
			}
		}
		transform.position = newPos;
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
