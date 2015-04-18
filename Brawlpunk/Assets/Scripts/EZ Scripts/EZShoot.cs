using UnityEngine;
using System.Collections;

public class EZShoot : MonoBehaviour {


	public float muzzleSpeed = 50; //m/s
	public GameObject bullet;
	public Transform player;
	Transform muzzle;


	// Use this for initialization
	void Start () {
		muzzle = transform.Find ("Muzzle");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 velocity = muzzle.right * muzzleSpeed * player.localScale.x;
			GameObject go;
			go = (GameObject) Instantiate (bullet, muzzle.position, player.rotation);
			EZProjectile p = go.GetComponent<EZProjectile>();
			p.Init (velocity);
			p.transform.localScale = -player.transform.localScale;
		}

	}
}
