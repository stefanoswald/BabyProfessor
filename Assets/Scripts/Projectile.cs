using UnityEngine;
using System.Collections;

public class Projectile : Collider {
	int speed = 15;
	int damage;
	private Rigidbody2D rigidBody;
	GameObject player;
	Character characterScript;

	// Use this for initialization
	void Awake () {
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		player = GameObject.Find ("Player");
		characterScript = (Character)player.GetComponent (typeof(Character));
		SetDamage(characterScript.GetDamage ());
	}
	
	// Update is called once per frame
	void Update () {
		rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
	}

	public void SetSpeed(int newSpeed){
		speed = newSpeed;
	}

	public void SetDamage(int newDamage){
		damage = newDamage;
		Debug.Log (GetDamage ());
	}

	public int GetDamage(){
		return damage;
	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			//remove enemy health
		}
	}
}
