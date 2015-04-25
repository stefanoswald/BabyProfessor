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
		if (text.text != "") {
				GMScript.SetSeed ("7");
			} else {
				GMScript.SetSeed("0");
			}
		GMScript.SetScore (0); 
			try{
				GMScript.GMS.ConvertSeed (text.text);
				Debug.Log ("that worked");
				Application.LoadLevel ("GameScene");
			}
			catch{
				GMScript.GMS.ConvertSeed ("0");
				Debug.Log ("that didn't work");
				Application.LoadLevel ("GameScene");
			}
	}
	public void MainMenu(){
		Application.LoadLevel ("MainMenu");
	}
		public void SwapArt(){
			GMScript.SwapArt ();
		}
}
}