using UnityEngine;
using System.Collections;

public class PlayerWeaponController : MonoBehaviour {

	public int weaponSlot = 1;
	public int weaponNum = 0;
	public string[] weaponName;
	public Texture2D[] weaponIcon;
	public int[] weaponType; //0 = Ranged, 1 = Melee, 2 = Empty Slot
	
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			weaponSlot = 1;
		}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			weaponSlot = 2;
		}else if(Input.GetKeyDown(KeyCode.Alpha3)){
			weaponSlot = 3;
		}
		
		//Add section that checks weaponNum vs some data source to get texture, name, upgrades, etc.
	}

	void OnGUI(){
		DrawQuad(new Rect(Screen.width/2-80,Screen.height-80,155,55),new Color(0.2f,0.2f,0.2f,1.0f),"",12);
		if(GUI.Button(new Rect(Screen.width/2-75,Screen.height-75,45,45),weaponIcon[0])){
			weaponSlot = 1;
		}
		if(GUI.Button(new Rect(Screen.width/2-25,Screen.height-75,45,45),weaponIcon[1])){
			weaponSlot = 2;
		}
		if(GUI.Button(new Rect(Screen.width/2+25,Screen.height-75,45,45),weaponIcon[2])){
			weaponSlot = 3;
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
