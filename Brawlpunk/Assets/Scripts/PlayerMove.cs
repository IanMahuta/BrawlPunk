using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	float moveForce = 1.0f; // Movement is currently based on pushing a rigidbody around
	bool ground = true; // Can only jump after touching object beneath you
	RaycastHit2D hit;
	public static Vector3 pos;
	
	void Update () {
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
		//pos = transform.position;
	}

	void OnCollisionEnter2D(Collision2D hitBy){ //For detecting the ground for jumping and if enemy hits player
		if(hitBy.gameObject.tag == "enemy"){ // detect if collision was from an enemy
			Debug.Log ("DEAD");  // if yes, kill the player
		}else{

			collider2D.enabled = false;
			hit = Physics2D.Raycast (transform.position, -Vector2.up,0.5f);
			if(hit.rigidbody != null){
				ground = true;
			}
			collider2D.enabled = true;
		}
	}
}
