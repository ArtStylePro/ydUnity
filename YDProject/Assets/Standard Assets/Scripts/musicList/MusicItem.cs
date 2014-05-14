using UnityEngine;
using System.Collections;
using System.Xml;
using System.Data;
using Mono.Data.Sqlite;
using AssemblyCSharpfirstpass;

public class MusicItem : MonoBehaviour {


	private MusicInfo mMusicInfo;
	public UILabel mSongNameLabel;
	public UILabel mSingerDurationLabel;
	public UISprite mSongLevelSprite;


//	public UISprite mScoreBestColumn;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadMusic(MusicInfo _info)
	{
		mMusicInfo = _info;
		mSingerDurationLabel.text = string.Format("{0}  {1}",_info.mSingerName,_info.mSongDuration);
		mSongNameLabel.text = _info.mSongName;
		mSongLevelSprite.spriteName = string.Format("dj{0:D4}",_info.mSongLevel);
	}

	void OnClick()
	{

		Debug.Log("music is not downloaed");
			
		MusicListLogic.script.OnMusicItemChecked(mMusicInfo);
			
	}


}
