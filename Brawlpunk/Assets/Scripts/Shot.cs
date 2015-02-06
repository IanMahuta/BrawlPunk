using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.LookAt(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,transform.position.z));
		transform.rigidbody2D.AddForce(transform.right*50);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
