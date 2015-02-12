using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public static int gamestate = 0;

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI(){
		//Display different things based on the gamestate
		//gamestate 0 = main menu
		//gamestate 1 = level select
		//gamestate 2 = in game
		//gamestate 3 = pause screen
		//gamestate 4 = game over screen
		//etc
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
