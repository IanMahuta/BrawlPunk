﻿using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	int defaultClip = 30;
	public static int clip = 30; // Keeps track of the current clip
	public static int clipSize = 30;
	float shotSpeed = 0.01f; // Seconds between shots
	float reloadSpeed = 2.0f;
	bool busy = false; // For allowing shooting or reloading based on relevent time delays.
	public static bool rel = false;
	public GameObject shot; // The projectile
	public static float shotForce = 0.6f;
	public static float spread = 0.075f;
	public static float recoil = 0.0f;
	GameObject S1;
	AudioSource[] Snd;

	void Awake(){
		clip = defaultClip;
		clipSize = defaultClip;
	}
	
	// Use this for initialization
	void Start () {
		S1 = GameObject.FindGameObjectWithTag("AudioHolder");
		Snd = S1.GetComponents<AudioSource>();
	}
	
	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0) && !busy){ //Mouse 1 to shoot. Mouse 2 for alt-firemode? Consult design team.
			if(clip >= 1 && !busy){
				Instantiate (shot, new Vector2(0.4f*Mathf.Cos(GunTransforms.angle)+transform.position.x,0.4f*Mathf.Sin(GunTransforms.angle)+transform.position.y),Quaternion.identity);
				clip -= 1;
				StartCoroutine(BusyCheck(shotSpeed));
				recoil = 0.5f;
				Snd[0].Play();
			}
		}
		if(Input.GetKey(KeyCode.R)){ // Also consult design team for the inclusion of "clips" or just one giant ammo supply.
			if(clip < clipSize && !busy){
				clip = clipSize;
				StartCoroutine(BusyCheck(reloadSpeed));
				rel = true;
			}
		}

		if(Mathf.Abs(recoil) > 0.0f && busy){
			recoil *= 0.5f;
		}else{
			recoil = 0.0f;
		}
	}

	IEnumerator BusyCheck(float time){
		busy = true;
		yield return new WaitForSeconds(time);
		busy = false;
		rel = false;
	}
}
