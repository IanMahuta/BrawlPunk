using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	float moveForce = 0.2f; 
	RaycastHit2D hit;
	public static Vector3 pos;
	float moveRange = 1.5f;
	float initY;
	Animator anim;

	bool facingLeft = true; //character starts facing left

	void Start(){
		//Finite vertical move range centered on the initial position
		initY = transform.position.y;
		anim = GetComponentInChildren<Animator> ();
	}
	
	void FixedUpdate () {
		float speed = 0;
		//Position incrementation based movement using WASD keys
		if(Input.GetKey(KeyCode.W) && transform.position.y <= (moveRange+initY)){
			speed = moveForce;
			transform.position += new Vector3(0.5f*moveForce,moveForce,0);
		}
		if(Input.GetKey(KeyCode.A)){
			speed = moveForce;
			transform.position += new Vector3(-moveForce,0,0);
			facingLeft = true;
		}
		if(Input.GetKey(KeyCode.S) && transform.position.y >= (-moveRange+initY)){
			speed = moveForce;
			transform.position += new Vector3(-0.5f*moveForce,-moveForce,0);
		}	
		if(Input.GetKey(KeyCode.D)){
			speed = moveForce;
			transform.position += new Vector3(moveForce,0,0);
			facingLeft = false;
		}
		pos = transform.position;
		anim.SetFloat ("Speed", speed*10);
		if (!facingLeft) {
			transform.localScale = new Vector3(-1, 1, 1);
		} else {
			transform.localScale = new Vector3(1, 1, 1);
		}

	}
}
