using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	float moveForce = 0.1f; 
	RaycastHit2D hit;
	public static Vector3 pos;
	float moveRange = 1.5f;
	float initY;

	void Start(){
		initY = transform.position.y;
	}
	
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.W) && transform.position.y <= (moveRange+initY)){
			transform.position += new Vector3(0.75f*moveForce,moveForce,0);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.position += new Vector3(-moveForce,0,0);
		}
		if(Input.GetKey(KeyCode.S) && transform.position.y >= (-moveRange+initY)){
			transform.position += new Vector3(-0.75f*moveForce,-moveForce,0);
		}	
		if(Input.GetKey(KeyCode.D)){
			transform.position += new Vector3(moveForce,0,0);
		}
		pos = transform.position;
	}
}
