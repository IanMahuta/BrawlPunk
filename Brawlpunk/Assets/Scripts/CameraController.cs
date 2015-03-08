using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	Vector3 PlayPos = new Vector3(0.0f,0.0f,0.0f);
	
	void FixedUpdate () {
		PlayPos = Camera.main.WorldToScreenPoint(PlayerMove.pos);
		if(PlayPos.x >= Screen.width*0.75){
			Camera.main.transform.position += new Vector3(0.1f,0.0f,0.0f);
		}else if(PlayPos.x <= Screen.width*0.25){
			Camera.main.transform.position += new Vector3(-0.1f,0.0f,0.0f);
		}
	}
}
