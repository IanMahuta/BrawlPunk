using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed = 5;  //distance that the enemy moves every second
	float timeSinceMove = 0;
	float health = 3.0f;
	float initHealth = 3.0f;
	Vector3 barPosition = new Vector3(0.0f,0.0f,0.0f);
	float damage = 20.0f; //damage the enemy does to the player on attack

	// Move the enemy
	void Update () {
		timeSinceMove = Time.deltaTime;
		transform.position = transform.position + new Vector3 (speed*timeSinceMove, 0, 0); 
	}

	// detect if the enemy was hit by a live shot or not
	void OnCollisionEnter2D(Collision2D hitBy){
		if(hitBy.gameObject.tag=="shot"){  // if enemy was hit by a shot, remove health or destroy the enemy
			Destroy (hitBy.gameObject);
			health--;
			if(health < 1){
				Destroy (gameObject);
			}
		}else if(hitBy.gameObject.tag=="Player"){
			HealthController.P1Health -= damage;
		}
	}

	void OnGUI(){
		barPosition = Camera.main.WorldToScreenPoint(transform.position);
		DrawQuad(new Rect(barPosition.x-20,Screen.height-barPosition.y-35,40,10),new Color (1.0f, 0.0f, 0.0f, 1.0f),"");
		DrawQuad(new Rect(barPosition.x-20,Screen.height-barPosition.y-35,Mathf.RoundToInt(40*health/initHealth),10),new Color (0.0f, 1.0f, 0.0f, 1.0f),"");
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
