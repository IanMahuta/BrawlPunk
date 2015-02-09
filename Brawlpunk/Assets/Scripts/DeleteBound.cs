using UnityEngine;
using System.Collections;

public class DeleteBound : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D hit){
		Destroy(hit.gameObject);
	}
}
