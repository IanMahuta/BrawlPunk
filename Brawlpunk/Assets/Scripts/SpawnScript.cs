using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public static float spawnTime = 1.0f;  // time between enemy spawns
	float timeLeft;
	public float timeSinceWave = 15.0f;
	public GameObject enemy;
	public static int numEnemies = 0;
	public int maxEnemies = 5;
	public bool spawnWaves = true;
	public float waveTimer = 15.0f;
	bool spawning = false;

	void Start () {  // spawn an enemy and start the countdown
		spawn ();
		timeLeft = spawnTime;
	}
	
	// update countdown, spawn an enemy if time has run out.  Restart countdown after spawn
	void Update () {
		timeLeft -= Time.deltaTime;
		timeSinceWave += Time.deltaTime;
		if(timeSinceWave >= waveTimer){
			spawning = true;
			timeSinceWave = 0.0f;
		}
		if(timeLeft <= 0 && spawning){
			spawn ();
			timeLeft = spawnTime;
		}
	}

	private void spawn(){  // spawn an enemy at the position of the spawner
		Instantiate (enemy, this.transform.position, Quaternion.identity);
		numEnemies ++;
		if(numEnemies == maxEnemies){
			numEnemies = 0;
			spawning = false;
			maxEnemies ++;
		}
	}
}
