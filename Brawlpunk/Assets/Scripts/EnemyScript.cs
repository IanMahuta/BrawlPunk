﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed = 5;  //distance that the enemy moves every second
	float timeSinceMove = 0;
	float health = 3.0f;
	//float initHealth = 3.0f;
	Vector3 barPosition = new Vector3(0.0f,0.0f,0.0f);
	float damage = 20.0f; //damage the enemy does to the player on attack

	// Move the enemy
	void FixedUpdate () {
		timeSinceMove = Time.deltaTime;
		float distance = speed * timeSinceMove;
		Vector3 currentPos = transform.position;

		float dist = Vector3.Distance(PlayerMove.pos,currentPos);
		if(dist <= distance){
			transform.position += PlayerMove.pos-currentPos;
		}else{
			transform.position += (PlayerMove.pos-currentPos)/dist*distance/2;
		}
		
	}

	void OnCollisionEnter2D(Collision2D hitBy){
		if(hitBy.gameObject.tag == "shot"){  // if enemy was hit by a shot, remove health or destroy the enemy
			Destroy(hitBy.transform.gameObject);
			health--;
			if(health < 1){
				Destroy(transform.gameObject);
				// decrease num enemies counter
			}
		}
	}

	void OnCollisionStay2D(Collision2D hitBy){
		if(hitBy.gameObject.tag == "Player"){
			if(HealthController.invulnTime == 0){
				HealthController.P1Health -= damage;
				HealthController.invulnTime = 0.5f;
			}
		}
	}

	void OnGUI(){
		barPosition = Camera.main.WorldToScreenPoint(transform.position);
		//DrawQuad(new Rect(barPosition.x-20,Screen.height-barPosition.y-35,40,10),new Color (1.0f, 0.0f, 0.0f, 1.0f),"");
		//DrawQuad(new Rect(barPosition.x-20,Screen.height-barPosition.y-35,Mathf.RoundToInt(40*health/initHealth),10),new Color (0.0f, 1.0f, 0.0f, 1.0f),"");
	}

	void DrawQuad(Rect position, Color color, string strng) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.skin.box.fontSize = 12;
		GUI.Box(position, strng);
	}
}
