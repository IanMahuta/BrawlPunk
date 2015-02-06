using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	int ammo = 100;
	int clip = 10;
	float shotSpeed = 0.2f; // Seconds between shots
	float reloadSpeed = 2.0f;
	bool busy = false;
	public GameObject shot;
	public static int shotForce = 1000;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(clip >= 1 && !busy){
				Instantiate (shot, new Vector2(0.4f*Mathf.Cos(GunAngle.angle)+transform.position.x,0.4f*Mathf.Sin(GunAngle.angle)+transform.position.y),Quaternion.identity);
				clip -= 1;
				StartCoroutine(BusyCheck(shotSpeed));
			}
		}
		if(Input.GetKey(KeyCode.R)){
			if(ammo > 0 && clip < 10 && !busy){
				ammo -= (10-clip);
				clip = 10;
				StartCoroutine(BusyCheck(reloadSpeed));
			}
		}
	}

	IEnumerator BusyCheck(float time){
		busy = true;
		yield return new WaitForSeconds(time);
		busy = false;
	}

	void OnGUI(){
		if(busy){
			DrawQuad(new Rect(Screen.width/2-25,Screen.height/2-10,50,20),new Color (0.0f, 0.0f, 0.0f, 1.0f),"BUSY");
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
