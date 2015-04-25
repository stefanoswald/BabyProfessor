using UnityEngine;
using System.Collections;
using UnityTest;
public class artSwitcher : MonoBehaviour {
	GameObject GM;
	GameManager GMScript;
	bool art;
	[SerializeField] private Sprite simple;
	[SerializeField] private Sprite complex;
	[SerializeField] private Sprite complex2;
	SpriteRenderer SR;
	float timer = 0;
	public bool walking = true;
	bool walkcycle;

	// Use this for initialization
	void Awake () {
		GM = GameObject.Find ("GameManager");
		GMScript = (GameManager)GM.GetComponent (typeof(GameManager));
		SR = (SpriteRenderer)GetComponent (typeof(SpriteRenderer));
	}
	
	// Update is called once per frame
	void Update () {
		art = GMScript.artType;
		if (!art) {
			SR.sprite= simple;
		} else {
			SR.sprite = complex;
			if(walking && walkcycle){
				SR.sprite = complex2;
			}else{
				SR.sprite = complex;
			}
		}
		timer += Time.deltaTime;
		if (timer > 0.5) {
			timer = 0;
			walkcycle = !walkcycle;
		}
	}
}
