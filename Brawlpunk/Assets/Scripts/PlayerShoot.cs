using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public static int ammo = 60;
	int clip = 30; // Keeps track of the current clip
	int clipSize = 30;
	float shotSpeed = 0.05f; // Seconds between shots
	float reloadSpeed = 2.0f;
	bool busy = false; // For allowing shooting or reloading based on relevent time delays.
	bool rel = false;
	public GameObject shot; // The projectile
	public static float shotForce = 0.6f;
	public static float spread = 0.1f;
	public static float recoil = 0.0f;
	
	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0)){ //Mouse 1 to shoot. Mouse 2 for alt-firemode? Consult design team.
			if(clip >= 1 && !busy){
				Instantiate (shot, new Vector2(0.4f*Mathf.Cos(GunTransforms.angle)+transform.position.x,0.4f*Mathf.Sin(GunTransforms.angle)+transform.position.y),Quaternion.identity);
				clip -= 1;
				StartCoroutine(BusyCheck(shotSpeed));
				recoil = 0.5f;
			}
		}
		if(Input.GetKey(KeyCode.R)){ // Also consult design team for the inclusion of "clips" or just one giant ammo supply.
			if(ammo > 0 && clip < clipSize && !busy){
				if(ammo+clip >= clipSize){
					ammo -= clipSize-clip;
					clip = clipSize;
				}else{
					clip += ammo;
					ammo = 0;
				}
				StartCoroutine(BusyCheck(reloadSpeed));
				rel = true;
			}
		}

		if(Mathf.Abs(recoil) > 0.0f && busy){
			recoil *= 0.5f;
		}else{
			recoil = 0.0f;
		}
	}

	IEnumerator BusyCheck(float time){
		busy = true; //This is where I could use some SE help. I want it to return whether it is reloading or not, not just "busy".
		yield return new WaitForSeconds(time);
		busy = false;
		rel = false;
	}

	void OnGUI(){
		if(rel){ 
			DrawQuad(new Rect(Screen.width/2-40,Screen.height/2-80,80,20),new Color (0.0f, 0.0f, 0.0f, 1.0f),"RELOADING");
		}else{
			DrawQuad(new Rect(Screen.width/2-25,Screen.height/2-80,50,20),new Color (0.0f, 0.0f, 0.0f, 1.0f),clip + "/" + clipSize);
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
