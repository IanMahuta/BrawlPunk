using UnityEngine;
using System.Collections;

public class GunAngle : MonoBehaviour {

	public static float angle;
	bool flipped = false;
	Vector3 scale;

	// Use this for initialization
	void Start () {
		scale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		//Angle the gun from -90 to 90 degrees, mirroring on either side
		var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - PlayerMovementScript.pos;
		angle = Mathf.Atan2(dir.y, dir.x);
		if(angle<0){
			angle += 2*Mathf.PI;
		}else if(angle>2*Mathf.PI){
			angle -= 2*Mathf.PI*Mathf.Round(angle/(2*Mathf.PI));
		}
		transform.rotation = Quaternion.AngleAxis(angle*Mathf.Rad2Deg, Vector3.forward);
		transform.localPosition = new Vector2(0.1f*Mathf.Cos (angle),0.1f*Mathf.Sin (angle));
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
