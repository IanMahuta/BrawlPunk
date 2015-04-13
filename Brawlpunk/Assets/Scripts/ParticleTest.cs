using UnityEngine;
using System.Collections;

public class ParticleTest : MonoBehaviour {

	public ParticleSystem test;
	float time = 0;
	
	void FixedUpdate () {
		//If the player has ammo to shoot with, and presses mouse one, emit particles
		if(Input.GetMouseButtonDown(0) && PlayerShoot.clip > 0){
			test.enableEmission = true;
			time = 0.1f;
		}
		//When the particles have been emitted for a time, turn them off again
		if(time < 0.1f){
			time = 0;
			test.enableEmission = false;
		}
		time -= Time.deltaTime;		
	}
}
