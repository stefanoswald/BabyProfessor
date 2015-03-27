using UnityEngine;
using System.Collections;

public class Block : Collider {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetTag(){
		return gameObject.tag;
	}

	public void SetTag(string NewTag){
		gameObject.tag = NewTag;
	}

}
