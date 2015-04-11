using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public const int MAIN_MENU = 0;
	public const int LEVEL_SELECT = 1;
	public const int IN_GAME = 2;
	public const int PAUSE_SCREEN = 3;
	public const int OPTIONS = 4;
	public const int GAME_OVER_SCREEN = 5;
	bool DEBUG = false;

	public SpawnScript EnemySpawn;

	public static int gamestate = MAIN_MENU;

	// Use this for initialization
	void Start () {
		gamestate = IN_GAME;
	}

	void Update(){
		//Toggle Debug Menu
		if(Input.GetKeyDown(KeyCode.F1)){
			DEBUG = !DEBUG;
		}

		//Only allow pause key to function while in-game
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(gamestate == IN_GAME){
				gamestate = PAUSE_SCREEN;
				Time.timeScale = 0;
			}else if(gamestate == OPTIONS){
				gamestate = PAUSE_SCREEN;
			}else{
				gamestate = IN_GAME;
				Time.timeScale = 1;
			}
		}
	}

	void OnGUI(){		
		//Display pause menu
		if(gamestate == PAUSE_SCREEN){
			DrawQuad(new Rect(Screen.width/2-100,Screen.height/2-100,200,300),new Color(0.0f,0.0f,0.0f,1.0f),"PAUSED",36);
			//Buttons for exiting to main menu, options, resuming
			if(GUI.Button(new Rect(Screen.width/2-90,Screen.height/2-30,180,60),"Resume")){
				gamestate = IN_GAME;
				Time.timeScale = 1;
			}
			if(GUI.Button(new Rect(Screen.width/2-90,Screen.height/2+40,180,60),"Options")){
				gamestate = OPTIONS;
			}
			if(GUI.Button(new Rect(Screen.width/2-90,Screen.height/2+110,180,60),"Quit")){
				gamestate = MAIN_MENU;
				//Application.LoadLevel();
			}
		}

		if(gamestate == OPTIONS){
			DrawQuad(new Rect(Screen.width/2-100,Screen.height/2-100,200,300),new Color(0.0f,0.0f,0.0f,1.0f),"OPTIONS",36);
			if(GUI.Button(new Rect(Screen.width/2-90,Screen.height/2-30,180,60),"Back")){
				gamestate = PAUSE_SCREEN;
			}
		}

		//Display debug options
		if(DEBUG){
			DrawQuad(new Rect(10,10,160,160),new Color(0.0f,0.0f,0.0f,1.0f),"DEBUG TOOLS",12);
			if(GUI.Button(new Rect(15,60,100,20),"+1 Life")){
				HealthController.P1Lives++;
			}
			if(GUI.Button(new Rect(15,85,100,20),"Full Health")){
				HealthController.P1Health = HealthController.P1InitHealth;
			}

			DrawQuad(new Rect(15,110,100,20),new Color(0.1f,0.1f,0.1f,1.0f),"SpawnTime: " + Mathf.Round(SpawnScript.spawnTime*10)/10 + "s",12);
			if(GUI.Button(new Rect(120,110,20,20),"+")){
				SpawnScript.spawnTime += 0.1f;
			}
			if(GUI.Button(new Rect(140,110,20,20),"-")){
				if(SpawnScript.spawnTime > 0.2f){
					SpawnScript.spawnTime -= 0.1f;
				}
			}
			if(GUI.Button(new Rect(12,135,120,20),"ResetSpawnCount")){
				SpawnScript.numEnemies = 0;
			}
		}

		//Displays ammo and such
		if(gamestate == IN_GAME || gamestate == PAUSE_SCREEN || gamestate == OPTIONS){
			DrawQuad(new Rect(5,Screen.height*4/5-5,Screen.width-10,Screen.height/5+5),new Color(0.5f,0.5f,0.5f,1.0f),"",12);
			DrawQuad(new Rect(10,Screen.height*4/5,Screen.width-20,Screen.height/5),new Color(0.1f,0.1f,0.1f,0.9f),"",12);

			DrawQuad(new Rect(Screen.width/2-55,5,110,30),new Color(0.0f,0.0f,0.0f,1.0f),"" + HealthController.P1Health,12);
			DrawQuad(new Rect(Screen.width/2-Mathf.Round(HealthController.P1Health/2),10,HealthController.P1Health,20),new Color(1.0f,0.0f,0.0f,0.75f),"",12);
			
			DrawQuad(new Rect(15,Screen.height*4/5+5,120,30),new Color(0.0f,1.0f,0.0f,0.9f),"Lives: " + HealthController.P1Lives,16);

			if(!PlayerShoot.rel){
				DrawQuad(new Rect(15,Screen.height*4/5+35,120,30),new Color(0.0f,0.0f,1.0f,0.9f),"Clip: " + PlayerShoot.clip,16);
			}else{
				DrawQuad(new Rect(15,Screen.height*4/5+35,120,30),new Color(0.0f,0.0f,1.0f,0.9f),"RELOADING",16);
			}
		}

		//Displays the game over screen with restart options
		if(gamestate == GAME_OVER_SCREEN){
			DrawQuad(new Rect(10,10,Screen.width-20,Screen.height-20),new Color(1.0f,0.0f,0.0f,0.5f),"UR DED LOL",190);
			if(GUI.Button(new Rect(Screen.width/2-40,Screen.height/2-20,80,40),"RESTART")){
				Application.LoadLevel(Application.loadedLevel);
				Time.timeScale = 1;
			}
		}
	}

	void DrawQuad(Rect position, Color color, string strng, int fontSize) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.skin.box.fontSize = fontSize;
		GUI.Box(position, strng);
	}
}
