using UnityEngine;
using System.Collections;

public class PlayerSwing : MonoBehaviour {

	float swingDelay = 1.0f; // Seconds between swings
	bool busy = false; // For checking if still swinging
	GameObject S1;
	AudioSource[] Snd;
	public static float swingDist = 50.0f; //degrees
	float swing;

	void Start () {
		S1 = GameObject.FindGameObjectWithTag("AudioHolder");
		Snd = S1.GetComponents<AudioSource>();
		swing = swingDist;
	}
	
	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0) && !busy){
			busy = true;
			swingDelay = 1.0f;
			swingDist = 0;
		}

		if(busy && swingDelay < 0.1f){
			swingDelay = 0;
			swingDist = swing;
			busy = false;
		}else if(busy){
			swingDelay -= Time.deltaTime;
			swingDist = (1.0f - Time.deltaTime/swingDelay)*Mathf.Deg2Rad*swing;
		}
	}
}
