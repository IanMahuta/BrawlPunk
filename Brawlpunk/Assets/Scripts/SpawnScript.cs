using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public static float spawnTime = 1.0f;  // time between enemy spawns
	float timeLeft;
	public GameObject enemy;
	public static int numEnemies = 0;
	public int maxEnemies = 5;
	public ParticleSystem effect;

	void Start () {  // spawn an enemy and start the countdown
		spawn ();
		timeLeft = spawnTime;
	}
	
	// update countdown, spawn an enemy if time has run out.  Restart countdown after spawn
	void Update () {
		timeLeft -= Time.deltaTime;
		if(timeLeft <= 0){
			if(numEnemies < maxEnemies){
				spawn ();
				timeLeft = spawnTime;
				effect.enableEmission = true;
			}else{
				effect.enableEmission = false;
			}
		}
	}

	private void spawn(){  // spawn an enemy at the position of the spawner
		Instantiate (enemy, this.transform.position, Quaternion.identity);
		numEnemies ++;
	}
}
