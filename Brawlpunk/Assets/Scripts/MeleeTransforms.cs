using UnityEngine;
using System.Collections;

public class MeleeTransforms : MonoBehaviour {

	public static float angle;
	bool flipped = false;
	Vector3 scale;
	
	void Start () {
		angle = Mathf.PI;
		scale = transform.localScale;
		scale.y *= -1;
	}
	
	void FixedUpdate () {
		//Mirror the gun across the player based on movement, not mouse
		if(Input.GetKey (KeyCode.D) && !flipped){
			scale.y *= -1;
			transform.localScale = scale;
			flipped = true;
			angle = Mathf.PI/4;
		}else if(Input.GetKey (KeyCode.A) && flipped){
			scale.y *= -1;
			transform.localScale = scale;
			flipped = false;
			angle = Mathf.PI*3/4;
		}
		
		//Rotate the gun based on recoil
		if(!flipped){
			transform.rotation = Quaternion.AngleAxis((angle+PlayerSwing.swingDist)*Mathf.Rad2Deg, Vector3.forward);
			transform.position = new Vector2(0.95f*Mathf.Cos (angle+PlayerSwing.swingDist)+PlayerMove.pos.x,0.95f*Mathf.Sin (angle+PlayerSwing.swingDist)+PlayerMove.pos.y);
		}else{
			transform.rotation = Quaternion.AngleAxis((angle-PlayerSwing.swingDist)*Mathf.Rad2Deg, Vector3.forward);
			transform.position = new Vector2(0.95f*Mathf.Cos (angle-PlayerSwing.swingDist)+PlayerMove.pos.x,0.95f*Mathf.Sin (angle-PlayerSwing.swingDist)+PlayerMove.pos.y);
		}
	}
}
