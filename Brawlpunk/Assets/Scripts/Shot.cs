using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.AngleAxis(GunAngle.angle*Mathf.Rad2Deg, Vector3.forward);
		transform.rigidbody2D.AddForce(transform.right*PlayerShoot.shotForce);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
