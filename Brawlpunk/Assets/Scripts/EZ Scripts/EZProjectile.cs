using UnityEngine;
using System.Collections;

public class EZProjectile : MonoBehaviour {

	Vector3 vel;

	// Use this for initialization
	public void Init (Vector3 velocity) {
		vel = velocity;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + vel * Time.deltaTime;
	}

	void OnCollisionEnter(Collision c) {
		Destroy (this.gameObject);
	}
}
