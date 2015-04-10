using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace UnityTest{
public class ReplayScript : MonoBehaviour {
	GameObject GM;
	GameManager GMScript;
	[SerializeField] Text text;
	[SerializeField] Text text2;
	// Use this for initialization
	void Awake () {
		GM = GameObject.Find ("GameManager");
		GMScript = (GameManager)GM.GetComponent (typeof(GameManager));
		text.text = GMScript.GetSeed ();
		text2.text = GMScript.GetScore ()+"";
	}
	
	public void Replay(){
		GMScript.SetSeed (text.text);
		GMScript.SetScore (0); 
		Application.LoadLevel ("GameScene");
	}
}
}