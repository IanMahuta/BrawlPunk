using UnityEngine;
using System.Collections;

public class GunTransforms : MonoBehaviour {

	public static float angle;
	bool flipped = false;
	Vector3 scale;

	void Start () {
		scale = transform.localScale;
	}
	
	void FixedUpdate () {
		//Angle the gun from -90 to 90 degrees, mirroring on either side

		var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - PlayerMove.pos;
		angle = Mathf.Atan2(dir.y, dir.x);
		if(angle<0){
			angle += 2*Mathf.PI;
		}else if(angle>2*Mathf.PI){
			angle -= 2*Mathf.PI*Mathf.Round(angle/(2*Mathf.PI));
		}
		if(angle>Mathf.PI/2 && angle<Mathf.PI*3/2){
			transform.rotation = Quaternion.AngleAxis((angle-PlayerShoot.recoil)*Mathf.Rad2Deg, Vector3.forward);
			transform.localPosition = new Vector2(0.1f*Mathf.Cos (angle-PlayerShoot.recoil),0.1f*Mathf.Sin (angle-PlayerShoot.recoil));
		}else{
			transform.rotation = Quaternion.AngleAxis((angle+PlayerShoot.recoil)*Mathf.Rad2Deg, Vector3.forward);
			transform.localPosition = new Vector2(0.1f*Mathf.Cos (angle+PlayerShoot.recoil),0.1f*Mathf.Sin (angle+PlayerShoot.recoil));
		}

		if(angle>Mathf.PI/2 && angle<Mathf.PI*3/2 && !flipped){
			scale.y *= -1;
			transform.localScale = scale;
			flipped = true;
		}else if(flipped && (angle<=Mathf.PI/2 || angle>=Mathf.PI*3/2)){
			scale.y *= -1;
			transform.localScale = scale;
			flipped = false;
		}
	}
}
