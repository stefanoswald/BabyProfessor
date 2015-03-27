using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {
	int health = 5;
	int damage = 1;
	bool grounded;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public int GetHealth(){
		return health;
	}

	public void SetHealth(int newHealth){
		health = newHealth;
	}

	public bool GetGrounded(){
		return grounded;
	}
	
	public void SetGrounded(bool newGrounded){
		grounded = newGrounded;
	}

	//TODO
	//on collision
	public int GetDamage(){
		return damage;
	}

	public void SetDamage (int NewDamage){
		damage = NewDamage;
	}
}
