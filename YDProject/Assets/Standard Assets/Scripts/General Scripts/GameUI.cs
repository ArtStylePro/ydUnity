using UnityEngine;
using System.Collections;
using AssemblyCSharpfirstpass;

public class GameUI : MonoBehaviour {

	public UILabel mScoreNumber;
	public UILabel mComboNumber;
	public UISprite mComboSprite;
	public UISprite mMaxSprite;
	public UISlider mProgressBar;
	public UISlider mLifeBar;
	public UISprite mMultipleSprite;
	public UIPanel mPauseMenu;
	public UIPanel mResultPanel;

	private int mMultiple;

	private int mShowPauseMenuEvent;
	private int mLeavePauseMenuEvent;


	private int mComboMatchEvent ;
	private Animator mComboAnimator;
	private Animator mComboNumAnimator;

	private MusicScore mScore = new MusicScore();
	private enum GameStatus: int {STATUS_NORMAL,STATUS_SHOW_PAUSE_MENU,STATUS_WAITING_PAUSE_MENU_RESUME,STATUS_WAITING_PAUSE_MENU_RESTART};
	private GameStatus mStatus;
	private enum MenuEvent : int { EVENT_GAME_PAUSE,EVENT_MENU_RESUME,EVENT_MENU_RESTART,EVENT_MENU_STOP,EVENT_MENU_GONE};

	private int[,]mScoreList = {
		{ 50, 100 }, 
		{ 80, 90 }, 
		{ 110, 80 },
		{ 135,70}, 
		{ 160,60},
		{185,50},
		{210,40},
		{235,30},
		{260,20},
		{285,10},
		{310,1},
		{350,0}
	};

	// Use this for initialization
	void Start () {
		mMultiple = 1;
		mShowPauseMenuEvent = Animator.StringToHash("ShowMenu");
		mLeavePauseMenuEvent = Animator.StringToHash("LeaveMenu");
		mStatus = GameStatus.STATUS_NORMAL;

		string value = mScore.encode();
		Debug.Log ("value:" + value);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public int OnGetScore(int _interval) //0 means missed
	{
		int score = 0;
		if(_interval == -1)
		{
			Debug.Log ("missed");
			mScore.addMiss();
		}
		else
		{
			int level = getLevel(_interval);
			if(level  == -1)
				return 0;
			score = mScoreList[level,1];
			mScore.AddAccuracy(score);

			Debug.Log("get level:" + level);
			mScore.addCombo();
			updateMax(level);
			mScore.addScore(mMultiple,score);
			mScoreNumber.text = string.Format("{0}",mScore.mScore);

			updateCombo();
			updateMultiple();

		
		}
		return score;
	}
	public int getMutipleMode()
	{
		int combo = mScore.getCombo();
		if(combo < 20)
			return 1;
		else
		if(combo 	< 30)
				return 2;
		else
		if(combo < 40)
				return 3;
		else
		if(combo < 80)
				return 4;
		else
			return 8;

	}
	private void updateMax(int _max)
	{
		string name = string.Format("maxpercent{0:000}",10 - _max);
		mMaxSprite.spriteName = name;
		mMaxSprite.animation.Stop();
		mMaxSprite.animation.Play();
		Debug.Log("max percent name:" + name);
	}
	private void updateMultiple()
	{
		int multiple = getMutipleMode();
		if(multiple != mMultiple)
		{
			Debug.Log ("multiple mode chagne from:" + mMultiple + " to " + multiple);
			mMultiple = multiple;
			if(mMultiple == 1)
			{
				setVisible(mMultipleSprite,false);
				GameMainController.script.leaveX8Mode();
			}
			else
			{
				string name = string.Format("x{0}",mMultiple);
				setVisible(mMultipleSprite,true);
				mMultipleSprite.animation.Play();
				mMultipleSprite.spriteName = name;
				if(mMultiple == 8)
				{
					GameMainController.script.enterX8Mode();
				}
			}

		}
	}
	private void updateCombo()
	{
		mComboNumber.text = string.Format("{0}",mScore.getCombo());
		mComboNumber.animation.Stop();
		mComboNumber.animation.Play ();

		mComboSprite.animation.Stop();
		mComboSprite.animation.Play ();
	}
	private int getLevel(int _offset)
	{
		
		for(int i = 0;i < mScoreList.GetLength(0);i ++)
		{
			if(_offset <= mScoreList[i,0])
				return i;
		}
		return -1;
	}
	public void updatePlayerTime(float _time_passed,int _time_total)
	{
		mProgressBar.value = 1.0f - _time_passed/_time_total;
	//	Debug.Log("change progress of player:" + mProgressBar.value);
	}
	public static void setVisible(UISprite _sprite,bool _visible)
	{
		if(_visible)
		{
			if(_sprite.transform.localPosition.z != 0.0f)
			{
				_sprite.transform.localPosition = new Vector3(_sprite.transform.localPosition.x,_sprite.transform.localPosition.y,0.0f);
			}
		}
		else
		{
			if(_sprite.transform.localPosition.z != -10.0f)
				_sprite.transform.localPosition = new Vector3(_sprite.transform.localPosition.x,_sprite.transform.localPosition.y,-10.0f);

		}
	
	}
	private void onStart()
	{
		mScore.init();
		updateCombo();
		updateMultiple();
		mScoreNumber.text = string.Format("{0}",mScore);

	}
	public void OnPauseClicked()
	{
		Debug.Log ("pause button is clicked");
		processMenuEvent(MenuEvent.EVENT_GAME_PAUSE);
	
	}
	public void OnPauseMenuResume()
	{
		Debug.Log("pause menu:resume");
		processMenuEvent(MenuEvent.EVENT_MENU_RESUME);

	}
	public void OnPauseMenuRestart()
	{
		Debug.Log("pause menu:restart");
		processMenuEvent(MenuEvent.EVENT_MENU_RESTART);
	}
	public void OnPauseMenuStop()
	{
		Debug.Log("pause menu:stop");
		processMenuEvent(MenuEvent.EVENT_MENU_STOP);
	}
	public void OnPauseMenuGone()
	{
		processMenuEvent(MenuEvent.EVENT_MENU_GONE);
	}

	private void processMenuEvent(MenuEvent _event)
	{
		switch(_event)
		{
		case MenuEvent.EVENT_GAME_PAUSE:
			if(mStatus == GameStatus.STATUS_NORMAL)
			{
				GameMainController.script.pause();
				mPauseMenu.gameObject.SetActive(true);
				mPauseMenu.GetComponent<Animator>().SetTrigger(mShowPauseMenuEvent);
				CameraEventProxy.instance().disableDefaultEventMask(camera.GetComponent<UICamera>());
				mStatus = GameStatus.STATUS_SHOW_PAUSE_MENU;
			}
			break;
		case MenuEvent.EVENT_MENU_RESTART:
			if(mStatus == GameStatus.STATUS_SHOW_PAUSE_MENU)
			{
				mStatus = GameStatus.STATUS_WAITING_PAUSE_MENU_RESTART;
				Debug.Log ("remove pause menu");
				mPauseMenu.GetComponent<Animator>().SetTrigger(mLeavePauseMenuEvent);
			}
			break;
		case MenuEvent.EVENT_MENU_RESUME:
			if(mStatus == GameStatus.STATUS_SHOW_PAUSE_MENU)
			{
				mStatus = GameStatus.STATUS_WAITING_PAUSE_MENU_RESUME;
				Debug.Log ("remove pause menu");
				mPauseMenu.GetComponent<Animator>().SetTrigger(mLeavePauseMenuEvent);

			}
			break;
		case MenuEvent.EVENT_MENU_STOP:
			if(mStatus == GameStatus.STATUS_SHOW_PAUSE_MENU)
			{
			
		//		mPauseMenu.GetComponent<Animator>().SetTrigger(mLeavePauseMenuEvent);

			}
			break;
		case MenuEvent.EVENT_MENU_GONE:
			CameraEventProxy.instance().enableDefaultEventMask(camera.GetComponent<UICamera>());
			if(mStatus == GameStatus.STATUS_WAITING_PAUSE_MENU_RESTART)
			{
				//todo:restart game
				Debug.Log ("now can restart the music");
				GameMainController.script.restart();
				onStart();
			}
			else
			if(mStatus == GameStatus.STATUS_WAITING_PAUSE_MENU_RESUME)
			{
				//todo:resume game
				Debug.Log ("now can resume the music");
				GameMainController.script.resume();
			}
			Debug.Log ("destroy game pause menu");
			mStatus = GameStatus.STATUS_NORMAL;
			break;
		default:
			break;

		}
	}

	public void OnButtonAnimationOver(string _id)
	{
		if(_id == "share")
		{
			Debug.Log("share button is clicked");
		}
		else
			if(_id == "quit")
		{
			Debug.Log ("return button is clicked");
		}
	}
	public void OnButtonClicked(string _id)
	{
		Debug.Log ("scroll button is clicked");
	}
 
	public void OnGameOver(MusicInfo _music,int _rythem_count,bool _is_three_key)
	{
		mScore.onMusicOver(_rythem_count);
		MusicMGR.instance().updateMusicScore(_music.mID,mScore,_is_three_key);
		mResultPanel.gameObject.SetActive(true);
		mResultPanel.GetComponent<Animator>().SetTrigger(Animator.StringToHash("GameOver"));
		CameraEventProxy.instance().disableDefaultEventMask(camera.GetComponent<UICamera>());
	}
	public MusicScore getScore()
	{
		return mScore;
	}
}
