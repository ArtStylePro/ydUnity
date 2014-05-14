using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

using AssemblyCSharpfirstpass;

public class GameMainController : MonoBehaviour {
	private int TRACK_LIST_NUMBER = 3;
	private MusicTrack[] mTrackList;
	private AudioSource mMusicPlayer;
	private int GAME_KEY_COUNT = 0;
	private Texture2D[] mBallList;
	public GameObject BallObject;
	private int mLastTime;

	public GameUI mGameUIScript;
	private int mGameMode; //0 means normal ,1 means x8
	private int mRythemCount ;


	private enum GameStatus: int{STATUS_NONE, STATUS_PREPARE,STATUS_PLAYING,STATUS_PAUSE,STATUS_STOP};
	private GameStatus mStatus = GameStatus.STATUS_NONE;
	public static MusicInfo mMusicInfo;
	public static bool mIsThreeKey;
	public static GameMainController script;

	// Use this for initialization
	void Start () {
		if(mMusicInfo == null)
		{
			mMusicInfo = MusicMGR.instance().getMusic (120004);
//			mMusicInfo.mID = 120004;

		}

		script = this;
		GAME_KEY_COUNT = 3;
		string song_path = "songs/" + mMusicInfo.mID;
//		string path = "Assets/Resources/songs/" + mMusicID;


		mTrackList= new MusicTrack[GAME_KEY_COUNT];
		for (int i =0; i < GAME_KEY_COUNT; i ++) {
			mTrackList[i] = new MusicTrack();
			mTrackList[i].init (BallObject,this);
			mTrackList[i].setIndex(i + 1,GAME_KEY_COUNT);

		}
		if (GAME_KEY_COUNT == 3) {
			mTrackList [0].setLineSlope (36.0f/14.0f, 88.28f/160.0f);
			mTrackList[1].setLineSlope(10000.0f,0.0f);
			mTrackList[2].setLineSlope(-35.0f/14.0f,84.0f/160.0f);
		}




		mMusicPlayer = GetComponent ("AudioSource") as AudioSource;

		loadTexture ();
		StartCoroutine (loadSongConfig());
		StartCoroutine(loadMusic());
	
		mLastTime = (int)(Time.time * 1000);
		mMusicPlayer.volume = 0.05f;

	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(mStatus)
		{
			case GameStatus.STATUS_PLAYING:
			{
				bool play_over = true;
				for (int i = 0; i < GAME_KEY_COUNT; i ++) {
					float player_time = mMusicPlayer.time ;
					mTrackList[i].draw((int)(player_time*1000));
					mGameUIScript.updatePlayerTime(player_time,mMusicInfo.mLength);
					if(mTrackList[i].playOver() == false)
						play_over = false;
						
					
				}
			if(play_over == true)
			{
				mStatus = GameStatus.STATUS_STOP;
				mGameUIScript.OnGameOver(mMusicInfo,mRythemCount,mIsThreeKey);
			}

			}
			break;
		case GameStatus.STATUS_PAUSE:
			break;
		case GameStatus.STATUS_STOP:
			break;

		}

	}
	private IEnumerator loadSongConfig()
	{
//		TextAsset asset = Resources.Load (_path + "/config" ) as TextAsset;

		string path = getMusicDir() + "/config.xml";
		WWW config_path = new WWW(path);
		yield return config_path;

		mRythemCount = 0;
		MemoryStream stream = new MemoryStream (config_path.bytes);

		XmlTextReader reader = new XmlTextReader (stream);
		while (reader.Read()) {
			if(reader.Name == "beat")
			{
				Debug.Log("found a beat");
				string offsetz_str = reader.GetAttribute("time");
				int offset = int.Parse(offsetz_str);
				int delay = 0;
				int track = 0;
//				string delay_str = reader.GetAttribute("delay");
//				if(delay_str != null)
//				{
//					delay = int.Parse(reader.GetAttribute("delay"));
//				}
				string[] track_list = reader.GetAttribute("type").Split('$');
				foreach(string track_info in track_list)
				{
					int _delay_position = track_info.IndexOf('_');
					if(_delay_position > 0)
					{
						delay = int.Parse(track_info.Substring(_delay_position + 1) );
						track = int.Parse (track_info.Substring(0,_delay_position));

					}
					else
						track = int.Parse(track_info);
					mTrackList[track-1].addRythem(offset,delay);
					mRythemCount ++;

				}
			

			}
		}
		reader.Close();
		stream.Close();
	}
	private void loadTexture()
	{
		mBallList = new Texture2D[GAME_KEY_COUNT *2];
		int i = 1;
		for (i = 1; i < GAME_KEY_COUNT; i ++) {
			mBallList[i] = Resources.Load("pictures/" + GAME_KEY_COUNT.ToString() + "key/Ball00" + i.ToString()) as Texture2D;
			if(mBallList[i] == null)
			{
				Debug.LogWarning("can't load texture " + i);
			}
			else
			{
				Debug.Log ("open ball texture id: " + i + " success");
			}
		}
	}

	public GameObject createBall(int _index,bool _isx8)
	{
		GameObject ball = Instantiate(BallObject,BallObject.transform.position,BallObject.transform.rotation) as GameObject;
		return ball;
	}
	public void destroyBall(GameObject _ball)
	{
		BallRender script = _ball.GetComponent("BallRender") as BallRender;
		if (script.score == 0) {
			mGameUIScript.OnGetScore(-1);
		}
		Destroy (_ball);
	}
	private string  getMusicDir()
	{
		string path = "file://" + Application.persistentDataPath + "/music/" + mMusicInfo.mID;
		return path;
	}
	public IEnumerator loadMusic()
	{
		string path = getMusicDir() + "/music.mp3";
		WWW audio_link = new WWW(path);
		yield return audio_link;
		mMusicPlayer.clip = audio_link.audioClip;
		mMusicPlayer.Play();
		mStatus = GameStatus.STATUS_PLAYING;
	}
	public int OnFingerDown(int _index)
	{

		int interval;
		interval  = mTrackList [_index].processTouchDown ((int)(mMusicPlayer.time * 1000));
		Debug.Log ("main get interval " + interval);

		return mGameUIScript.OnGetScore(interval);
	}
	public void enterX8Mode()
	{
		foreach(MusicTrack track in mTrackList)
		{
			track.enterX8Mode();
		}
	}

	public void leaveX8Mode()
	{
		foreach(MusicTrack track in mTrackList)
		{
			track.leaveX8Mode();
		}

	}
	public int getRythemCount()
	{
		return mRythemCount;
	}
	public void pause()
	{
		mStatus = GameStatus.STATUS_PAUSE;
		if(mMusicPlayer.isPlaying)
		{
			mMusicPlayer.Pause();
		}
		foreach(MusicTrack track in mTrackList)
		{
			track.pause();
		}

	}
	public void resume()
	{
		mStatus = GameStatus.STATUS_PLAYING;
		if(mMusicPlayer.isPlaying == false)
		{
			mMusicPlayer.Play();
		}
		foreach(MusicTrack track in mTrackList)
		{
			track.resume();
		}
	}
	public void restart()
	{
		mStatus = GameStatus.STATUS_PLAYING;
		foreach(MusicTrack track in mTrackList)
		{
			track.restart();
		}
		mMusicPlayer.Stop()	;
		mMusicPlayer.Play();

	}
}
