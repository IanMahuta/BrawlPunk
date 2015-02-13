using UnityEngine;
using System.Collections;

public class ProjectileMove : MonoBehaviour {

	// Bullets are physics-based and will move in their initial direction with a force specified by the gun that spawned them.
	float bangle = 0.0f;
	
	void Start () { 
		bangle = GunTransforms.angle+Random.Range(-PlayerShoot.spread,PlayerShoot.spread);
		transform.rotation = Quaternion.AngleAxis((GunTransforms.angle+Random.Range(-PlayerShoot.spread,PlayerShoot.spread))*Mathf.Rad2Deg, Vector3.forward);
		//transform.rigidbody2D.AddForce(transform.right*PlayerShoot.shotForce);
	}

	void FixedUpdate(){
		transform.position += new Vector3(PlayerShoot.shotForce*Mathf.Cos(bangle),PlayerShoot.shotForce*Mathf.Sin(bangle),0);
	}

	void OnCollisionEnter2D(){
		StartCoroutine(Despawn(0.05f));
	}

	// we don't need bullets piling up everywhere, but instant despawn doesn't allow for reliable hit detection
	IEnumerator Despawn(float delay){
		yield return new WaitForSeconds(delay);
		Destroy(gameObject);
	}
	
}
