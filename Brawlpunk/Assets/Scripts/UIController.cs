using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public static int gamestate = 0;

	// Use this for initialization
	void Start () {
		gamestate = -1;
	}

	void OnGUI(){
		//Display different things based on the gamestate
		//gamestate -1 = DEBUG MENU
		//gamestate 0 = main menu
		//gamestate 1 = level select
		//gamestate 2 = in game
		//gamestate 3 = pause screen
		//gamestate 4 = game over screen
		//etc

		if(gamestate == -1){
			if(GUI.Button(new Rect(10,10,100,20),"+45 Ammo")){
				PlayerShoot.ammo += 45;
			}
		}

		if(gamestate == -1 || gamestate == 2 || gamestate == 3 || gamestate == 4){
			DrawQuad(new Rect(10,Screen.height-30,100,20),new Color(0.0f,0.0f,0.0f,1.0f),"Ammo: " + PlayerShoot.ammo);
			if(!PlayerShoot.rel){
				DrawQuad(new Rect(10,Screen.height-60,100,20),new Color(0.0f,0.0f,0.0f,1.0f),"Clip: " + PlayerShoot.clip + "/" + PlayerShoot.clipSize);
			}else{
				DrawQuad(new Rect(10,Screen.height-60,100,20),new Color(0.0f,0.0f,0.0f,1.0f),"RELOADING");
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
