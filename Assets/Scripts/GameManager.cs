using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	string seed;
	float floatSeed = 0;
	float section = 0;
	float generated = 0;
	bool artType;
	private string possibleCharacters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//GenerateLevel ();
	}

	public void ConvertSeed(string levelSeed){
		string stringSeed = "0";
		if (levelSeed == null){
			for(int i = 0; i<20; i++){
				int a = Random.Range (0,possibleCharacters.Length);
				stringSeed = stringSeed + possibleCharacters[a];
			}
		}
		for (int i = 0; i< levelSeed.Length; i++) {
			char c = levelSeed[i];
			int x = c;
			stringSeed += x;
		}
		floatSeed = float.Parse (stringSeed);
	}

	public float GenerateLevel(){
		generated = Mathf.PerlinNoise (floatSeed, section);
		section = section + 100.1f;
		//generate level here
		generated *= 10;
		generated = Mathf.Floor (generated);
		//Debug.Log(generated);
		return generated;
		//closer to 5 is more common
	}

	public void SwapArt(){
		artType = !artType;
	}

	public string GetSeed(){
		return seed;
	}

	public void SetSeed(string newSeed){
		seed = newSeed;
	}

}
