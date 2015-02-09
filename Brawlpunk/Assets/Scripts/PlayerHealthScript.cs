using UnityEngine;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour {

	public int startingHealth = 100;
	int health;
	void Start(){
		health = startingHealth;
	}

	public void playerHit(int damage){
		health -= damage;
		Debug.Log (health + " health remaining (of " + startingHealth + ")");
		if(health <= 0){
			// player loses
			Debug.Log ("DEAD");
			Application.Quit ();
			Destroy (this.gameObject);
		}
	}
}
