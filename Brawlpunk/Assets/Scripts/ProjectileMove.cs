using UnityEngine;
using System.Collections;

public class ProjectileMove : MonoBehaviour {

	float bangle = 0.0f;
	
	void Start () { 
		//Angle the bullets so they match the angle of the gun that shot them, with spread
		bangle = GunTransforms.angle+Random.Range(-PlayerShoot.spread,PlayerShoot.spread);
		transform.rotation = Quaternion.AngleAxis((GunTransforms.angle+Random.Range(-PlayerShoot.spread,PlayerShoot.spread))*Mathf.Rad2Deg, Vector3.forward);
	}

	void FixedUpdate(){
		//bullet moves in a straight line by incrementing its position
		transform.position += new Vector3(PlayerShoot.shotForce*Mathf.Cos(bangle),PlayerShoot.shotForce*Mathf.Sin(bangle),0);
	}

	void OnCollisionEnter2D(){
		//bullet despawns after contact with any object
		StartCoroutine(Despawn(0.05f));
	}

	// we don't need bullets piling up everywhere, but instant despawn doesn't allow for reliable hit detection
	IEnumerator Despawn(float delay){
		yield return new WaitForSeconds(delay);
		Destroy(gameObject);
	}
	
}
