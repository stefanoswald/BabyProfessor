using NSubstitute;
using NUnit.Framework;

namespace UnityTest
{
	public class GMTests
	{
		[Test]
		public void ConvertSeed ()
		{
			var GMS = GetGMS ();
			string seed = "GuoIsAwesome";
			GMS.ConvertSeed (seed);
			float seed1 = GMS.floatSeed;
			GMS.ConvertSeed (seed);
			float seed2 = GMS.floatSeed;
			Assert.AreEqual (seed1, seed2);
		}

		[Test]
		public void EmptySeed ()
		{
			var GMS = GetGMS ();
			GMS.ConvertSeed ("");
			float seed1 = GMS.floatSeed;
			Assert.AreNotEqual (seed1, null);
		}

		[Test]
		public void GenerateLevel ()
		{
		    var noise = GetNoise();
			var GMS = GetGMS2 (noise);
			//generate two numbers
			float gen11 = GMS.GenerateLevel ();
			float gen12 = GMS.GenerateLevel ();
			//reset section
			GMS.section = 0;
			//generate two numbers
			float gen21 = GMS.GenerateLevel ();
			float gen22 = GMS.GenerateLevel ();
			//compair the 4 results
			Assert.AreEqual(gen11,gen21);
		}

		[Test]
		public void SwapArt ()
		{
			var GMS = GetGMS ();
			bool art = GMS.artType;
			GMS.SwapArt ();
			Assert.AreNotEqual (art, GMS.artType);
		}


		[Test]
		public void GetSetSeed ()
		{
			var GMS = GetGMS ();
			GMS.SetSeed ("Amazing");
			string seed = GMS.GetSeed ();
			Assert.AreEqual ("Amazing", seed);
		}
        [Test]
        public void GetSetScore()
        {
            var GMS = GetGMS();
            GMS.SetScore(5);
            int score = GMS.GetScore();
            Assert.AreEqual(5, score);
        }

		private GameManagerSub GetGMS (){
			return Substitute.For<GameManagerSub> ();
		}
        private GameManagerSub GetGMS2(INoise noise)
        {
            var gms = Substitute.For<GameManagerSub>();
            gms.SetNoise(noise);
            return gms;
        }
        private INoise GetNoise()
        {
            return Substitute.For<INoise>();
        }
	}
}
