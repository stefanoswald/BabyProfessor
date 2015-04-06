using UnityEngine;
using System.Collections;

public class Character : Person {
	public int score = 0;
	[SerializeField] private Rigidbody2D rigidBody;
	[SerializeField] private Transform spawner;
	float jumpForce = 400f;
	float speed = 10f;
	// Use this for initialization
	void Awake () {
		SetHealth (5);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateFunction ();
	}
	void UpdateFunction(){
		if (Input.GetKeyDown (KeyCode.Space) && GetGrounded()) {
			Jump();
		}
		rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
		if (Input.GetKeyDown (KeyCode.K)) {
			Shoot();
		}
		if (GetHealth () <= 0) {
			Die ();
		}
	}

	void Jump(){
		rigidBody.AddForce(new Vector2(0f, jumpForce));
		SetGrounded (false);
	}

	void Shoot(){
		GameObject projectile = (GameObject)Instantiate (Resources.Load ("Projectile"),spawner.position, Quaternion.identity );
	}

	void Die(){
		//set data in gameManager
		LoadResults (GetScore());
	}
	

	public int GetScore(){
		return score;
	}

	public void SetScore(int newScore){
		score = newScore;
	}

	public void LoadResults(int score){
		//load the results page
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		Collision (coll);
	}

	void Collision(Collision2D coll){
		if (coll.gameObject.tag == "Wall"){
			SetGrounded (true);
			Debug.Log ("hit wall");
		}
		if (coll.gameObject.tag == "Enemy"){
			int oldHealth = GetHealth();
			int newHealth = oldHealth-1;
			SetHealth(newHealth);
			Destroy(coll.gameObject);
			Debug.Log ("hit enemy");
		}
		
		if (coll.gameObject.tag == "Spike"){
			//Destroy (gameObject);
			Debug.Log ("hit spike");
			SetHealth (0);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		Trigger (coll);
	}

	void Trigger(Collider2D coll){
		if (coll.gameObject.tag == "Coin"){
			SetScore(GetScore()+1);
			Destroy (coll.gameObject);
			Debug.Log ("hit coin");
		}
		if (coll.gameObject.tag == "Powerup"){
			SetDamage(GetDamage() + GetDamage());
			Destroy (coll.gameObject);
			Debug.Log ("hit powerup");
		}
	}
}
