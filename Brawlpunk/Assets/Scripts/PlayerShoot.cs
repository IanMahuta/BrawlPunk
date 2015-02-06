using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	int ammo = 100;
	int clip = 10;
	float shotSpeed = 0.5f; // Seconds between shots
	float reloadSpeed = 3.0f;
	bool busy = false;
	public GameObject shot;
	public static int shotForce = 500;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(clip >= 1 && !busy){
				Instantiate (shot, new Vector2(0.25f+transform.position.x,0.25f+transform.position.y),Quaternion.identity);
				clip -= 1;
				BusyCheck(shotSpeed);
				busy = false;
			}
		}
		if(Input.GetKey(KeyCode.R)){
			if(ammo > 0 && clip < 10 && !busy){
				ammo = ammo-(10-clip);
				clip = 10;
				BusyCheck(reloadSpeed);
				busy = false;
			}
		}
	}

	IEnumerator BusyCheck(float time){
		busy = true;
		yield return new WaitForSeconds(time);
	}
}
