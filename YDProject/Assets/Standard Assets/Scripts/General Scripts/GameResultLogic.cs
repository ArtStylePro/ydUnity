using UnityEngine;
using System.Collections;
using AssemblyCSharpfirstpass;

public class GameResultLogic : MonoBehaviour {

	public GameUI mUIScript;

	public UILabel mExperienceLabel;
	public UILabel mShineLabel;
	public UILabel mScoreLabel;
	public UILabel mComboLabel;
	public UILabel mMissLabel;
	public UILabel mAccuracyLabel;
	public UISprite mScoreLevel;
	public UISprite mBedge1;
	public UISprite mBedge2;
	public UISprite mBedge3;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onAnimationFinished()
	{
		MusicScore score = mUIScript.getScore();
		mScoreLabel.text = string.Format("{0}",score.mScore);
		mComboLabel.text = string.Format("{0}",score.mCombo);
		mMissLabel.text = string.Format("{0}",score.mMiss);
		Debug.Log ("Accuracy:" + score.getAccuracy() );
		mAccuracyLabel.text = string.Format("{0:##.##}%",score.getAccuracy());
		mScoreLevel.spriteName = string.Format("AccurateLevel_{0:000}",score.getScoreLevel());
	}
}
