using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	int ammo = 100;
	int clip = 30; // Keeps track of the current clip
	int clipSize = 30;
	float shotSpeed = 0.05f; // Seconds between shots
	float reloadSpeed = 2.0f;
	bool busy = false; // For allowing shooting or reloading based on relevent time delays.
	public GameObject shot; // The projectile
	public static int shotForce = 1500;
	public static float spread = 0.1f;
	public static float recoil = 0.0f;
	float shakeDist = 0.2f;
	float camAng = 0.0f;
	bool screenShake = false;
	
	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0)){ //Mouse 1 to shoot. Mouse 2 for alt-firemode? Consult design team.
			if(clip >= 1 && !busy){
				Instantiate (shot, new Vector2(0.4f*Mathf.Cos(GunTransforms.angle)+transform.position.x,0.4f*Mathf.Sin(GunTransforms.angle)+transform.position.y),Quaternion.identity);
				clip -= 1;
				StartCoroutine(BusyCheck(shotSpeed));
				shakeDist = 0.2f;
				camAng = GunTransforms.angle;
				recoil = 0.5f;
			}
		}
		if(Input.GetKey(KeyCode.R)){ // Also consult design team for the inclusion of "clips" or just one giant ammo supply.
			if(ammo > 0 && clip < clipSize && !busy){
				ammo -= clipSize-clip;
				clip = clipSize;
				StartCoroutine(BusyCheck(reloadSpeed));
			}
		}

		// Manual screen shake for recoilless weapons
		if(Mathf.Abs(shakeDist)>0.1f && screenShake){
			Camera.main.transform.position = new Vector3(shakeDist*Mathf.Cos(camAng)+transform.position.x,shakeDist*Mathf.Sin(camAng)+transform.position.y,-10.0f);
			shakeDist *= -0.5f;
		}else{
			Camera.main.transform.position = new Vector3(transform.position.x,transform.position.y,-10.0f);
			shakeDist = 0.0f;
		}

		if(recoil > 0.0f && busy){
			recoil *= 0.5f;
		}else{
			recoil = 0.0f;
		}
	}

	IEnumerator BusyCheck(float time){
		busy = true; //This is where I could use some SE help. I want it to return whether it is reloading or not, not just "busy".
		yield return new WaitForSeconds(time);
		busy = false;
	}

	void OnGUI(){
		if(busy){ //Want to change it to display when reloading. Consult design team to see what the plan for that is.
			DrawQuad(new Rect(Screen.width/2-25,Screen.height/2-80,50,20),new Color (0.0f, 0.0f, 0.0f, 1.0f),"BUSY");
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
