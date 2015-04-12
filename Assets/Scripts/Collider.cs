using UnityEngine;
using System.Collections;

public class Collider : MonoBehaviour {
	string name;
	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Destroy is actually inherited by MonoBehaviour
	void DestroySelf(){
		Destroy (gameObject);
	}
	//TODO collider stuff

	public string GetName(){
		return name;
	}

	public void SetName(string newName){
		name = newName;
	}
}
