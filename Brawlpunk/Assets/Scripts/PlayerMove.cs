using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	float moveForce = 0.3f; 
	RaycastHit2D hit;
	public static Vector3 pos;
	
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.W)){
			transform.position = transform.position + new Vector3(0,moveForce,0);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.position= transform.position + new Vector3(-moveForce,0,0);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.position = transform.position + new Vector3(0,-moveForce,0);
		}	
		if(Input.GetKey(KeyCode.D)){
			transform.position= transform.position + new Vector3(moveForce,0,0);
		}
		pos = transform.position;
	}

	void OnCollisionEnter2D(Collision2D hitBy){ //For detecting the ground for jumping and if enemy hits player
		if(hitBy.gameObject.tag == "enemy"){ // detect if collision was from an enemy
			Debug.Log ("DEAD");  // if yes, kill the player
		}
	}
}
