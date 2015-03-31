using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public string[] names;
	
	// Update is called once per frame
	void OnGUI () {
		GUIStyle cust = new GUIStyle("button");
		cust.fontSize = 24;
		DrawQuad(new Rect(10,10,Screen.width-20,Screen.height-20),new Color(0.1f,0.1f,0.1f,0.4f),"LEVEL SELECT",36);

		if(GUI.Button(new Rect(20,Screen.height/2,(Screen.width-60)/3,Screen.height/10),names[0],cust)){
			Application.LoadLevel(0);
		}
		if(GUI.Button(new Rect((Screen.width-60)/3+30,Screen.height/2,(Screen.width-60)/3,Screen.height/10),names[1],cust)){
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(2*(Screen.width-60)/3+40,Screen.height/2,(Screen.width-60)/3,Screen.height/10),names[2],cust)){
			Application.LoadLevel(2);
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
