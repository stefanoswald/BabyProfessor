using UnityEngine;
using System.Collections;

public class Enemy : Person {
	GameObject player;
	Character playerScript;
	// Use this for initialization
	void Awake () {
		SetHealth (5);
		player = GameObject.Find ("Player");
		playerScript = (Character)player.GetComponent (typeof(Character));
	}
	
	// Update is called once per frame
	void Update () {
		if (GetHealth () <= 0) {
			DestroySelf();
		}
	}

	//Destroy is actually inherited by MonoBehaviour
	void DestroySelf(){
		playerScript.SetScore (playerScript.GetScore () + 1);
		Destroy (gameObject);
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Projectile") {
			Debug.Log ("shoot");
			Projectile pScript = (Projectile)coll.gameObject.GetComponent (typeof(Projectile));
			SetHealth(GetHealth()-pScript.GetDamage());
			Destroy (coll.gameObject);
		}
	}
}
