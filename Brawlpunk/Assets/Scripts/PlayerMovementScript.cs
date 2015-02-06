using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	float moveForce = 60.0f;
	bool ground = true;
	RaycastHit2D hit;
	public static Vector3 pos;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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

	void OnCollisionEnter2D(){
		collider2D.enabled = false;
		hit = Physics2D.Raycast (transform.position, -Vector2.up,0.5f);
		if(hit.rigidbody != null){
			ground = true;
		}
		collider2D.enabled = true;
	}
}
