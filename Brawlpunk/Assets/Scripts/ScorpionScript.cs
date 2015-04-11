using UnityEngine;
using System.Collections;

public class ScorpionScript : MonoBehaviour {
	
	public float speed = 5;  //distance that the enemy moves every second
	float timeSinceMove = 0;
	float health = 3.0f;
	//float initHealth = 3.0f;
	Vector3 barPosition = new Vector3(0.0f,0.0f,0.0f);
	float damage = 20.0f; //damage the enemy does to the player on attack
	float maxAttackDist = 15.0f;
	float minAttackDist = 5.0f;
	float timeSinceAttack = 0.0f;
	float attackCooldown = 5.0f;
	public GameObject shot;
	
	// Move the enemy
	void FixedUpdate () {
		timeSinceMove = Time.deltaTime;
		timeSinceAttack += Time.deltaTime;

		float distance = speed * timeSinceMove;
		Vector3 currentPos = transform.position;
		
		float dist = Vector3.Distance(PlayerMove.pos,currentPos);

		if(timeSinceAttack >= attackCooldown && (dist >= minAttackDist || dist <= maxAttackDist)){
			ShootArrow();
		}else if (dist < minAttackDist){
			// move away from player
		}else if (dist > maxAttackDist) {
			// move towards player
		}else {

		}
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
	}
	
	void DrawQuad(Rect position, Color color, string strng) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.skin.box.fontSize = 12;
		GUI.Box(position, strng);
	}

	void ShootArrow(){
		Instantiate (shot, new Vector2(0.4f*Mathf.Cos(GunTransforms.angle)+transform.position.x,0.4f*Mathf.Sin(GunTransforms.angle)+transform.position.y),Quaternion.identity);

	}
}
