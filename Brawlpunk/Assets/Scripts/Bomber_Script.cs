using UnityEngine;
using System.Collections;

public class Bomber_Script : MonoBehaviour {

	public float speed = 5;  //distance that the enemy moves every second
	float timeSinceMove = 0;
	float health = 3.0f;
	Vector3 shadowPosition = new Vector3(0.0f,0.0f,0.0f);
	
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
			}
		}
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
