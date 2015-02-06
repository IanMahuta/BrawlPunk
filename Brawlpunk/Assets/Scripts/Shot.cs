using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.Euler (0,0,Mathf.Atan2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).y-transform.position.y,Camera.main.ScreenToWorldPoint(Input.mousePosition).x-transform.position.x)*Mathf.Rad2Deg-90);
		transform.rigidbody2D.AddForce(transform.right*PlayerShoot.shotForce);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
