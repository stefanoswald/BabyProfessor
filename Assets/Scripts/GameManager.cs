using UnityEngine;
using System.Collections;
namespace UnityTest{
	public class GameManager : MonoBehaviour, INoise {
		static bool created = false;
		public bool artType;
		public GameManagerSub GMS;
		public bool ads = true;
		public string seed = "";
		int score = 0;
		// Use this for initialization
		void Awake () {
            GMS.SetNoise(this);
			if (!created)
			{
				DontDestroyOnLoad(this.gameObject);
				created = true;
			}
		
			else
			{
				Destroy(this.gameObject);
			}
		}

		public void SwapAds(bool newAds){
			ads = newAds;
		}

		void Update () {
			artType = GMS.artType;
			seed = GetSeed ();
		}

		public void SwapArt(){
			GMS.SwapArt();
		}

		public string GetSeed(){
			return GMS.GetSeed();
		}
		
		public void SetSeed(string newSeed){
			GMS.SetSeed(newSeed);
		}

		public int GetScore(){
			return GMS.GetScore();
		}
		
		public void SetScore(int newScore){
			GMS.SetScore( newScore);
		}

        #region INoise implementation

        public float Noise(float floatSeed, float section)
        {
          return Mathf.PerlinNoise(floatSeed, section);
        }

        #endregion
	
	}
}