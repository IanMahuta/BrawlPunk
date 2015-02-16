using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	float spawnTime = 2.0f;  // time between enemy spawns
	float timeLeft;
	public GameObject enemy;


	void Start () {  // spawn an enemy and start the countdown
		spawn ();
		timeLeft = spawnTime;
	}
	
	// update countdown, spawn an enemy if time has run out.  Restart countdown after spawn
	void Update () {
		timeLeft -= Time.deltaTime;
		if(timeLeft <= 0){
			spawn ();
			timeLeft = spawnTime;
		}
	}

	private void spawn(){  // spawn an enemy at the position of the spawner
		Instantiate (enemy, this.transform.position, Quaternion.identity);
	}
}
