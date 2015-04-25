using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityTest;

public class adScript : MonoBehaviour {
	GameObject GM;
	GameManager GMScript;
	[SerializeField] private Text ad;
	[SerializeField] private Image banner;
	// Use this for initialization
	void Awake () {
		GM = GameObject.Find ("GameManager");
		GMScript = (GameManager)GM.GetComponent (typeof(GameManager));
	}
	
	// Update is called once per frame
	void Update () {
		if (GMScript.ads) {
			banner.enabled = true;
			ad.enabled=true;
		} else {
			banner.enabled = false;
			ad.enabled = false;
		}
	}
}
