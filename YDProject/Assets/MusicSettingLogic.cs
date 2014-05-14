using UnityEngine;
using System.Collections;
using AssemblyCSharpfirstpass;

public class MusicSettingLogic : MonoBehaviour {

	public static MusicSettingLogic script;
	public static MusicInfo mMusicInfo;
	public UITexture mSingerAlbum;
	public UISprite mThreeKeyButton;
	public UISprite mFourKeyButton;
	public UISprite mScoreLevel;
	public UISprite mSongLevel;
	public UISprite mSongLevelGraph;
	public UILabel mHighestScore;
	public UILabel mMaxCombo;
	public UILabel mMinumMistake;
	public UILabel mMaxAccuracy;
	private Texture2D mSingerHead;
	private bool mIsThreeKey;
	public UISprite mKeySelectAnimation;

	// Use this for initialization
	void Start () {
		script = this;
		if(mMusicInfo == null)
		{
			mMusicInfo = MusicMGR.instance().getMusic(120004);
		}
		StartCoroutine(loadSingerHeader());

		mIsThreeKey = true;
		changeKeyType();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnButtonClicked(string _id)
	{
		Debug.Log ("button is clicked:" + _id);
	}
	public  void OnButtonAnimationOver(string _id)
	{
		Debug.Log ("button is animation over:" + _id);
		GameMainController.mMusicInfo = mMusicInfo;
		GameMainController.mIsThreeKey = mIsThreeKey;
		Application.LoadLevel("Main");
	}
	private IEnumerator loadSingerHeader()
	{
		string path = "file://" + MusicMGR.instance().getMusicDir() + "/" + mMusicInfo.mID + "/starhead.png";
		Debug.Log("load singer header from :" + path);
		WWW album_head_reqeust = new WWW(path);
		yield return album_head_reqeust;
		mSingerHead = album_head_reqeust.texture;
		mSingerAlbum.mainTexture = mSingerHead;

	}
	public void OnThreekeyClicked()
	{
		mIsThreeKey = true;
		changeKeyType();
	}
	public void OnFourkeyClicked()
	{
		mIsThreeKey = false;
		changeKeyType();
	}
	private void changeKeyType()
	{
		if(mIsThreeKey)
		{
			mThreeKeyButton.spriteName = "key_menu_3_light";
			mFourKeyButton.spriteName = "key_menu_4";
			mKeySelectAnimation.transform.localPosition = mThreeKeyButton.transform.localPosition;
		}
		else
		{
			mThreeKeyButton.spriteName = "key_menu_3";
			mFourKeyButton.spriteName = "key_menu_4_light";
			mKeySelectAnimation.transform.localPosition = mFourKeyButton.transform.localPosition;
		}
		updateScoreInfo();
	}
	private void updateScoreInfo()
	{
		MusicScore score = mIsThreeKey?mMusicInfo.mThreeKeyScore:mMusicInfo.mFourKeyScore;
		mMaxCombo.text = string.Format("{0}",score.mCombo);
		mMaxAccuracy.text = string.Format("{0:##.##}",score.getAccuracy());
		mMinumMistake.text = string.Format("{0}",score.mMiss);
	}

}
