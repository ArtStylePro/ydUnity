using UnityEngine;
using System.Collections;

public class MusicTrack {
	private int mTrackIndex;
	private float mSlope;
	private float mOffset;
	private ArrayList mRythemList;
	private int mIterator;
	public static int TRACK_DURATION = 900;
	private ArrayList mBallList;
	private ArrayList mRecycleBallList;
	public GameObject mBallObject;
	private Sprite[] mSpriteList;
	private bool mX8Mode = false;
	private GameMainController mGameLogic;
	private bool mPlayOver = false;
	//private FireAnimation mTouchAnimationScript;
	// Use this for initialization


	public bool init(GameObject _ball,GameMainController _gameLogic)
	{
		mRythemList = new ArrayList ();
		mBallObject = _ball;
		mIterator = 0;
		mBallList = new ArrayList ();
		mRecycleBallList = new ArrayList ();
		mGameLogic = _gameLogic;
		return true;
	}
	public void setIndex(int _index,int _key_count)
	{
		mTrackIndex = _index;
		mSpriteList = new Sprite[2];
		mSpriteList [0] = Resources.Load<Sprite>("pictures/" + _key_count + "key/Ball00" + _index);
		mSpriteList [1] = Resources.Load<Sprite>("pictures/" + _key_count + "key/Ball00" + (_index + _key_count));
	}
	public int getIndex()
	{
		return mTrackIndex;
	}
	public void setLineSlope(float _slope,float _offset)
	{
		mSlope = _slope;
		float scale = Camera.main.orthographicSize * Camera.main.aspect ;
		mOffset = _offset*scale;
	}
	public void addRythem(MusicRythem _rythem)
	{
		mRythemList.Add (_rythem);
	}
	public void addRythem(int _offset,int _delay)
	{
//		Debug.Log ("add rythem:" + _offset + " delay:" + _delay);
		MusicRythem rythem = new MusicRythem ();
		rythem.setRythem (_offset, _delay);
		mRythemList.Add (rythem);
	}
	public MusicRythem getNext(int _offset)
	{
		do {
			if(mIterator >= mRythemList.Count)
			{
				break;
			}
			MusicRythem rythem = mRythemList[mIterator] as MusicRythem;
			if(rythem != null)
			{
				if(rythem.mOffset < _offset)
				{
					mIterator ++;
					continue;
				}
				if(rythem.mOffset <= _offset + TRACK_DURATION)
				{
					//this is it;
					mIterator ++;
					if(mTrackIndex == 2)
					{
					//	Debug.Log("track_index:" + mTrackIndex + " iterator:" + mIterator);
					//	Debug.Log ("current offset:" + _offset + " dest:" + rythem.mOffset);
					}
					return rythem;
				}
			}
		} while(false);
		return null;
	}
	public bool getCurrentPosition(int _offset,ref Vector3 _position)
	{
		_offset += 50;
		float top = 280.0f * 10.0f / 480.0f;
		float height = 228.0f * 10.0f / 480.0f;
		if(_offset > TRACK_DURATION)
		{
			if(_offset < TRACK_DURATION + 100)
			{
				_offset = TRACK_DURATION;
			}
			else
				_offset -= 100;
		}
		_position.y = top - Camera.main.orthographicSize -    (height *_offset )/ TRACK_DURATION;
		_position.x = mSlope > 100?0:(_position.y - mOffset) / mSlope;
	//	Debug.Log ("track:" + mTrackIndex + "offset:" + _offset + " get position:" + _position.x + "x" + _position.y);
		if (_position.y < -5.5) {
			return false;
		}
		return true;
	}
	public void draw(int _offset)
	{
		MusicRythem rythem = getNext (_offset);
		if (rythem != null) {

			GameObject ball = mGameLogic.createBall(mTrackIndex,mX8Mode);
			BallRender script = ball.GetComponent("BallRender") as BallRender;
			script.setTrack(this);
			script.setRythem(rythem,_offset);
			getCurrentPosition(0,ref script.mCurrentPosition);
			ball.transform.position = script.mCurrentPosition;
			if(mX8Mode)
			{
				script.updateTexture(mSpriteList[1]);
			}
			else
				script.updateTexture(mSpriteList[0]);
			mBallList.Add(ball);

		}
		if(mIterator  == mRythemList.Count && mBallList.Count  == 0)
		{
			mPlayOver = true;

		}
	}
	public void recycleBall(GameObject _ball)
	{
		BallRender script = _ball.GetComponent("BallRender") as BallRender;
	//	Debug.Log ("destroy ball with offset:" + script.mRythemInfo.mOffset);
		mBallList.Remove (_ball);

		mGameLogic.destroyBall (_ball);
	}
	public int processTouchDown(int _offset)
	{
		int len = mBallList.Count;
		int interval = 0;
		int score = -1;

		if(len > 0)
		{
			GameObject ball  = mBallList[0] as GameObject;
			BallRender script = ball.GetComponent("BallRender") as BallRender;

			int offset = Mathf.Abs (_offset - script.mRythemInfo.mOffset);

			Debug.Log ("current music offset:" + _offset + " target rythem:" + script.mRythemInfo.mOffset);
			if(offset < 350)
			{
				script.score = 1;
				mBallList.Remove(ball);
				mGameLogic.destroyBall(ball);
			}
			return offset;
			/*
			score = getScore(offset);
			Debug.Log ("get socre:" + score);
			if(score >= 0)
			{
				script.score = score;
				mBallList.Remove(ball);

				if(score > 0)
				{
					mTouchAnimationScript.beginFire();
					

				}

			}
			*/
		
		}
		return score;
	}
	public void enterX8Mode()
	{
		mX8Mode = true;
		foreach(GameObject ball in mBallList)
		{
			ball.GetComponent<SpriteRenderer>().sprite = mSpriteList[1] ;
		}

	}
	public void leaveX8Mode()
	{
		mX8Mode = false;
		foreach(GameObject ball in mBallList)
		{
			ball.GetComponent<SpriteRenderer>().sprite = mSpriteList[0] ;
		}

	}
	public void pause()
	{
		foreach(GameObject ball in mBallList)
		{
			ball.GetComponent<BallRender>().pause();
		}
	}
	public void  resume()
	{
		foreach(GameObject ball in mBallList)
		{
			ball.GetComponent<BallRender>().resume();
		}

	}
	public void restart()
	{
		foreach(GameObject ball in mBallList)
		{
			mGameLogic.destroyBall(ball);
		}
		mBallList.Clear();
		mIterator = 0;
		mPlayOver = false;
			
	}
	public bool playOver()
	{
		return mPlayOver;
	}

}
