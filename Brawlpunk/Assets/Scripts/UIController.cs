﻿using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public const int DEBUG = -1;
	public const int MAIN_MENU = 0;
	public const int LEVEL_SELECT = 1;
	public const int IN_GAME = 2;
	public const int PAUSE_SCREEN = 3;
	public const int GAME_OVER_SCREEN = 4;

	public SpawnScript EnemySpawn;

	public static int gamestate = MAIN_MENU;

	// Use this for initialization
	void Start () {
		gamestate = DEBUG;
	}

	void OnGUI(){
		//Display different things based on the gamestate
		if(gamestate == DEBUG){
			DrawQuad(new Rect(10,10,160,160),new Color(0.0f,0.0f,0.0f,1.0f),"DEBUG TOOLS");
			if(GUI.Button(new Rect(15,35,100,20),"+45 Ammo")){
				PlayerShoot.ammo += 45;
			}
			if(GUI.Button(new Rect(15,60,100,20),"+1 Life")){
				HealthController.P1Lives++;
			}
			if(GUI.Button(new Rect(15,85,100,20),"Full Health")){
				HealthController.P1Health = HealthController.P1InitHealth;
			}

			DrawQuad(new Rect(15,110,100,20),new Color(0.1f,0.1f,0.1f,1.0f),"SpawnTime: " + Mathf.Round(SpawnScript.spawnTime*10)/10 + "s");
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

		if(gamestate == DEBUG || gamestate == IN_GAME || gamestate == PAUSE_SCREEN || gamestate == MAIN_MENU){
			DrawQuad(new Rect(10,Screen.height-30,100,20),new Color(0.0f,0.0f,0.0f,1.0f),"Ammo: " + PlayerShoot.ammo);
			DrawQuad(new Rect(115,Screen.height-30,100,20),new Color(0.0f,0.0f,0.0f,1.0f),"Health: " + HealthController.P1Health);
			DrawQuad(new Rect(115,Screen.height-50,100,20),new Color(0.0f,0.0f,0.0f,1.0f),"Lives: " + HealthController.P1Lives);
			if(!PlayerShoot.rel){
				DrawQuad(new Rect(10,Screen.height-50,100,20),new Color(0.0f,0.0f,0.0f,1.0f),"Clip: " + PlayerShoot.clip + "/" + PlayerShoot.clipSize);
			}else{
				DrawQuad(new Rect(10,Screen.height-50,100,20),new Color(0.0f,0.0f,0.0f,1.0f),"RELOADING");
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
