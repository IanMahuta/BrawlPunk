using UnityEngine;
using System.Collections;

public class ParticleTest : MonoBehaviour {

	public ParticleSystem test;
	float time = 0;
	
	void Update () {
		if(Input.GetMouseButtonDown(0) && PlayerShoot.clip > 0){
			test.enableEmission = true;
			time = 0.1f;
		}
		if(time < 0.1f){
			time = 0;
			test.enableEmission = false;
		}
		time -= Time.deltaTime;		
	}
}
