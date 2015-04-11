using UnityEngine;
using System.Collections;

public class PlayerSwing : MonoBehaviour {

	float swingTime = 0.1f; // Time taken to swing once
	bool busy = false; // For checking if still swinging
	GameObject S1;
	AudioSource[] Snd;
	public static float swingDist = 90.0f; //degrees
	float swing;

	void Start () {
		S1 = GameObject.FindGameObjectWithTag("AudioHolder");
		Snd = S1.GetComponents<AudioSource>();
		swing = swingDist;
	}
	
	void FixedUpdate () {
		gameObject.collider2D.enabled = false;
		if(Input.GetMouseButtonDown(0) && !busy){
			busy = true;
			swingTime = 0;
			swingDist = 0;
			Snd[0].Play();
		}

		if(busy && swingTime > 0.1f){
			swingTime = 0.1f;
			swingDist = 0;
			busy = false;
			gameObject.collider2D.enabled = false;
		}else if(busy){
			swingTime += Time.deltaTime;
			swingDist += 2*swingTime*Mathf.Deg2Rad*swing;
			gameObject.collider2D.enabled = true;
		}
	}
}
