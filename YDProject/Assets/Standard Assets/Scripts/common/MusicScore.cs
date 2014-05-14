// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using SimpleJSON;
using UnityEngine;
namespace AssemblyCSharpfirstpass
{
	public class MusicScore
	{
		public float mAccuracy;
		public int mCombo;
		public int mMiss;
		public int mScore;
		public string mBedgeList ;	
		private int mTempCombo;

		public MusicScore ()
		{
			mBedgeList = "";
		}
		public static MusicScore parseData(string _data)
		{
			MusicScore score = new MusicScore();
			score.decode(_data);
			return score;
		}
		public string encode()
		{
			var node = new JSONClass();
			node["combo"].AsInt = mCombo;
			node["accuracy"].AsFloat = mAccuracy;
			node["score"].AsInt = mScore;
			node["miss"].AsInt = mMiss;
			node["bedge"] = mBedgeList;
			node.Add("combo","1000");
			Debug.Log ("output json data:" + node.ToString());


			return node.SaveToBase64();
		}
		public bool decode(string _data)
		{
			if(_data.Length > 1)

			{
				JSONNode node =JSONNode.LoadFromBase64(_data);
				mCombo = node["combo"].AsInt;
				mMiss = node["miss"].AsInt;
				mScore = node["score"].AsInt;
				mAccuracy = node["accuracy"].AsFloat;
				mBedgeList = node["bedge"];
				Debug.Log ("restore score:" + mScore + " combo:" + mCombo + " miss:" + mMiss + " ");
			}

			return true;
		}
		public void init()
		{
			mCombo = 0;
			mScore = 0;
			mTempCombo =0;
			mMiss = 0;
			mAccuracy = 0;
			mBedgeList = "";
		}
		public int getCombo()
		{
			return mTempCombo;
		}
		public void addMiss()
		{
			mMiss ++;
			if(mTempCombo > mCombo)
				mCombo = mTempCombo;
			mTempCombo = 0;
		}
		public void AddAccuracy(int _accuracy)
		{
			mAccuracy += _accuracy;
		}
		public void addScore(int _multiple,int _score)
		{
			mScore += _multiple * _score;
		}
		public void addCombo()
		{
			mTempCombo ++;
			if(mTempCombo > mCombo)
				mCombo = mTempCombo;
		}
		public float getAccuracy()
		{
			return mAccuracy;
		}
		public int getScoreLevel()
		{
			return 10;
		}
		public void onMusicOver(int _rythem_count)
		{
			mAccuracy /= _rythem_count;
		}
	}
}

