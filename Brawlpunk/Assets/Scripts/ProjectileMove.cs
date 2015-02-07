using UnityEngine;
using System.Collections;

public class ProjectileMove : MonoBehaviour {

	// Bullets are physics-based and will move in their initial direction with a force specified by the gun that spawned them.
	
	void Start () { 
		transform.rotation = Quaternion.AngleAxis(GunTransforms.angle*Mathf.Rad2Deg, Vector3.forward);
		transform.rigidbody2D.AddForce(transform.right*PlayerShoot.shotForce);
	}
	
}
