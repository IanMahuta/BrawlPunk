using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	float moveForce = 60.0f; // Movement is currently based on pushing a rigidbody around
	bool ground = true; // Can only jump after touching object beneath you
	RaycastHit2D hit;
	public static Vector3 pos;
	
	void Update () {
		if(Input.GetKey(KeyCode.W) && ground){
			gameObject.rigidbody2D.AddForce(new Vector2(0.0f,30.0f*moveForce));
			ground = false;
		}
		if(Input.GetKey(KeyCode.A)){
			gameObject.rigidbody2D.AddForce(new Vector2(-moveForce,0.0f));
		}
		if(Input.GetKey(KeyCode.S)){
			gameObject.rigidbody2D.AddForce(new Vector2(0.0f,-moveForce));
		}	
		if(Input.GetKey(KeyCode.D)){
			gameObject.rigidbody2D.AddForce(new Vector2(moveForce,0.0f));
		}
		pos = transform.position;
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
