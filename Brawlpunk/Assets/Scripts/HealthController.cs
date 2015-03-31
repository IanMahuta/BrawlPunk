using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	float defaultHealth = 100.0f;
	int defaultLives = 5;
	public static float P1Health = 100.0f;
	public static float P1InitHealth;
	public static int P1Lives = 5;
	public static float invulnTime = 0.5f; //seconds of invulnerability after each hit
	float sumTime = 0.0f;
	public GameObject PlayerOne;
	Vector3 barPosition = new Vector3(0.0f,0.0f,0.0f);

	//Resets the static variables
	void Awake(){
		P1Health = defaultHealth;
		P1InitHealth = defaultHealth;
		P1Lives = defaultLives;
	}
	
	void FixedUpdate () {
		if(sumTime >= invulnTime){
			invulnTime = 0;
			sumTime = 0;
		}else{
			sumTime += Time.deltaTime;
		}

		if(P1Health <= 0){
			P1Health = 0;
			//Destroy(PlayerOne.gameObject); //Or some sort of death animation
			if(P1Lives > 0){
				P1Lives--;
				//And respawn the player
				P1Health = P1InitHealth;
			}else{
				Time.timeScale = 0;
				UIController.gamestate = UIController.GAME_OVER_SCREEN; //Tell the UIController (and other controllers) to display a game over screen
			}
		}
	}

	void OnGUI(){
		//would eventually display health bar for player on in-game GUI near ammo and such
		barPosition = Camera.main.WorldToScreenPoint(PlayerMove.pos);
		//DrawQuad(new Rect(barPosition.x-20,Screen.height-barPosition.y-45,40,10),new Color (1.0f, 0.0f, 0.0f, 1.0f),"");
		if(P1Health > 0){
			//DrawQuad(new Rect(barPosition.x-20,Screen.height-barPosition.y-45,Mathf.RoundToInt(40*P1Health/P1InitHealth),10),new Color (0.0f, 1.0f, 0.0f, 1.0f),"");
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
