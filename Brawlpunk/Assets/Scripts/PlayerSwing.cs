using UnityEngine;
using System.Collections;

public class PlayerSwing : MonoBehaviour {

	float shotSpeed = 0.1f; // Seconds between swings
	bool busy = false; // For checking if still swinging
	GameObject S1;
	AudioSource[] Snd;

	void Start () {
		S1 = GameObject.FindGameObjectWithTag("AudioHolder");
		Snd = S1.GetComponents<AudioSource>();
	}
	
	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0) && !busy){
			StartCoroutine(BusyCheck(shotSpeed));
		}
	}

	IEnumerator BusyCheck(float time){
		busy = true;
		yield return new WaitForSeconds(time);
		busy = false;
	}
}
