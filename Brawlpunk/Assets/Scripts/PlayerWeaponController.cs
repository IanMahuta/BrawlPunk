using UnityEngine;
using System.Collections;

public class PlayerWeaponController : MonoBehaviour {

	public int weaponSlot = 1;
	public int weaponNum = 0;
	public string[] weaponName;
	public Texture2D[] weaponIcon;
	public int[] weaponType; //0 = Ranged, 1 = Melee, 2 = Empty Slot
	public GameObject[] weapons;

	void Start(){
		weaponSlot = 1;
		weapons[0].SetActive(true);
		weapons[1].SetActive(false);
	}
	
	void FixedUpdate () {
		//Press 1 or 2 to switch between your weapons
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			weaponSlot = 1;
			weapons[0].SetActive(true);
			weapons[1].SetActive(false);
		}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			weaponSlot = 2;
			weapons[0].SetActive(false);
			weapons[1].SetActive(true);
		}
	}

	void OnGUI(){
		//On-screen weapon buttons. Change to current weapon indicator
		DrawQuad(new Rect(Screen.width/2-35,Screen.height-80,70,70),new Color(0.2f,0.2f,0.2f,1.0f),"",12);
		if(GUI.Button(new Rect(Screen.width/2-30,Screen.height-75,60,60),weaponIcon[weaponSlot-1])){
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
