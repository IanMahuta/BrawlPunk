using UnityEngine;
using System.Collections;

public class GunTransforms : MonoBehaviour {
	
	public static float angle;
	bool flipped = false;
	Vector3 scale;
	
	void Start () {
//		angle = 0.0f;
//		scale = transform.localScale;
//		scale.y *= -1;
	}
	
	void FixedUpdate () {
		//Mirror the gun across the player based on movement, not mouse
//		if(Input.GetKey (KeyCode.D) && !flipped){
//			scale.y *= -1;
//			transform.localScale = scale;
//			flipped = true;
//			angle = 0.0f;
//		}else if(Input.GetKey (KeyCode.A) && flipped){
//			scale.y *= -1;
//			transform.localScale = scale;
//			flipped = false;
//			angle = Mathf.PI;
//		}

		//Rotate the gun based on recoil
//		if(!flipped){
//			transform.rotation = Quaternion.AngleAxis((angle-PlayerShoot.recoil)*Mathf.Rad2Deg, Vector3.forward);
//			transform.localPosition = new Vector2(0.1f*Mathf.Cos (angle-PlayerShoot.recoil),0.1f*Mathf.Sin (angle-PlayerShoot.recoil));
//		}else{
//			transform.rotation = Quaternion.AngleAxis((angle+PlayerShoot.recoil)*Mathf.Rad2Deg, Vector3.forward);
//			transform.localPosition = new Vector2(0.1f*Mathf.Cos (angle+PlayerShoot.recoil),0.1f*Mathf.Sin (angle+PlayerShoot.recoil));
//		}
	}
}