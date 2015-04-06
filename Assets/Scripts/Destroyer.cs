using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
	int chunkPosition = 0;
	float chunkNumber = 0;
	float lastNumber = 0;
	GameObject GM;
	GameManager GMScript;

	// Use this for initialization

	void Awake (){
		AwakeFunction();
	}

	void AwakeFunction(){
		SpwanSection (0);
		SpwanSection (0);
		SpwanSection (0);
		GM = GameObject.Find ("GameManager");
		GMScript = (GameManager)GM.GetComponent (typeof(GameManager));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpwanSection(float num){
		Vector3 pos = new Vector3 (chunkPosition, 0, 0);
		if (num == 0) {
			GameObject newChunk = (GameObject)Instantiate (Resources.Load ("Chunk0"),pos, Quaternion.identity );
		} else if (num == 1) {
			GameObject newChunk = (GameObject)Instantiate (Resources.Load ("Chunk4"),pos, Quaternion.identity );
		} else if (num == 2) {
			GameObject newChunk = (GameObject)Instantiate (Resources.Load ("Chunk1"),pos, Quaternion.identity );
		} else if (num == 3) {
			GameObject newChunk = (GameObject)Instantiate (Resources.Load ("Chunk7"),pos, Quaternion.identity );
		} else if (num == 4) {
			GameObject newChunk = (GameObject)Instantiate (Resources.Load ("Chunk5"),pos, Quaternion.identity );
		} else if (num == 5) {
			GameObject newChunk = (GameObject)Instantiate (Resources.Load ("Chunk2"),pos, Quaternion.identity );
		} else if (num == 6) {
			GameObject newChunk = (GameObject)Instantiate (Resources.Load ("Chunk3"),pos, Quaternion.identity );
		} else if (num == 7) {
			GameObject newChunk = (GameObject)Instantiate (Resources.Load ("Chunk8"),pos, Quaternion.identity );
		} else if (num == 8) {
			GameObject newChunk = (GameObject)Instantiate (Resources.Load ("Chunk6"),pos, Quaternion.identity );
		} else {
			GameObject newChunk = (GameObject)Instantiate (Resources.Load ("Chunk9"),pos, Quaternion.identity );
		}
		chunkPosition += 20;
	}

	float NewChunkNumber(){
		chunkNumber = GMScript.GenerateLevel();
		if (chunkNumber == lastNumber) {
			chunkNumber++;
			lastNumber = chunkNumber;
			return chunkNumber;
		}
		lastNumber = chunkNumber;
		return chunkNumber;
	}

	void OnTriggerEnter2D(Collider2D coll){
		Trigger (coll);

	}

	void Trigger(Collider2D coll){
		if (coll.gameObject.tag == "Chunk"){
			Destroy (coll.gameObject);
			Debug.Log ("hit trigger");
			SpwanSection(NewChunkNumber());
		}
	}

}
