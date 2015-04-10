using UnityEngine;
using System.Collections;
namespace UnityTest{
	public class GameManager : MonoBehaviour, INoise {
		static bool created = false;
		bool artType;
		public GameManagerSub GMS;
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

		void Update () {
			artType = GMS.artType;
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