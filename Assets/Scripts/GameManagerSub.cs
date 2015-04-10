using UnityEngine;
using System.Collections;
using System;

namespace UnityTest 
{
	[Serializable]
	public class GameManagerSub
	{
		public string seed;
		public float floatSeed = 0;
		public float section = 0;
		public float generated = 0;
		public bool artType;
		private string possibleCharacters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
		int score = 0;
		private INoise noise;

		public void ConvertSeed(string levelSeed){
			string stringSeed = "0";
			if (levelSeed == null || levelSeed == "0"){
				for(int i = 0; i<5; i++){
					System.Random rnd = new System.Random();
					int a = rnd.Next (0,possibleCharacters.Length);
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
			noise.Noise (floatSeed, section);
			section = section + 100.1f;
			//generate level here
			generated *= 10;
			generated = Mathf.Floor (generated);
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
		
		public int GetScore(){
			return score;
		}
		
		public void SetScore(int newScore){
			score = newScore;
		}

        public void SetNoise(INoise noise)
        {
            this.noise = noise;
        }

	}
}