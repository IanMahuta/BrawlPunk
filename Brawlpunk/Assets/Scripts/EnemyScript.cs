using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed = 5;  //distance that the enemy moves every second
	float timeSinceMove = 0;
	float health = 3.0f;
	float damage = 15.0f; //damage the enemy does to the player on attack
	
	// Move the enemy
	void FixedUpdate () {
		timeSinceMove = Time.deltaTime;
		float distance = speed * timeSinceMove;
		Vector3 currentPos = transform.position;
		
		float dist = Vector3.Distance(PlayerMove.pos,currentPos);
		if(dist <= distance){
			transform.position += PlayerMove.pos-currentPos;
		}else{
			transform.position += (PlayerMove.pos-currentPos)/dist*distance/2;
		}
	}
	
	void OnCollisionEnter2D(Collision2D hitBy){
		if(hitBy.gameObject.tag == "shot"){  // if enemy was hit by a shot, remove health or destroy the enemy
			Destroy(hitBy.transform.gameObject);
			health--;
			if(health < 1){
				Destroy(transform.gameObject);
			}
		}else if(hitBy.gameObject.tag == "melee"){
			health--;
			if(health < 1){
				Destroy(transform.gameObject);
			}
		}
	}
	
	void OnCollisionStay2D(Collision2D hitBy){
		if(hitBy.gameObject.tag == "Player"){
			if(HealthController.invulnTime == 0){
				HealthController.P1Health -= damage;
				HealthController.invulnTime = 0.5f;
			}
		}
	}
}
