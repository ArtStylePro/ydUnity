using UnityEngine;
using System.Collections;

public class BallRender : MonoBehaviour
{
		private int mStatus;//0 is unpress,1 is pressed,2 is out of screen;
		private int mStartPlayerTime; //player time when ball was falled;
		private int mBallFallingTime;
		private int mSuppendTime;
		private MusicTrack mTrack;
		public  Vector3 mCurrentPosition;
		public MusicRythem mRythemInfo;
		private Animation mMaxAnimation;
		private int mScore;
		private bool mPaused;
		// Use this for initialization

		void Start ()
		{
				mCurrentPosition = new Vector3 (0, 0, -1);
				mScore = 0;


		}
	
		// Update is called once per frame
		void Update ()
		{
				if (mPaused == false) {
						int time_offset = (int)(Time.time * 1000) - mBallFallingTime;
						bool inScreen = mTrack.getCurrentPosition (time_offset, ref mCurrentPosition);
						//	Debug.Log ("current position:" + mCurrentPosition.x + "x" + mCurrentPosition.y);
						gameObject.transform.position = mCurrentPosition;
						if (inScreen == false) {

								mTrack.recycleBall (gameObject);
						}

				}
		}

		public void updateTexture (Sprite _sprite)
		{
//		gameObject.renderer.material.mainTexture = _texture;
				GetComponent<SpriteRenderer> ().sprite = _sprite;
//		renderer.material.mainTexture = _texture;

		}

		public void setPosition (float _x, float _y)
		{
				//Vector3 vec = new Vector3 (_x, _y, 0.0f);
				//gameObject.transform.position = vec;
//		gameObject.transform.position.x = _x;
//		gameObject.transform.position.y = _y;
		}

		public void setTrack (MusicTrack _track)
		{
				mTrack = _track;
		}

		public void setRythem (MusicRythem _rythem, int _offset)
		{
				mRythemInfo = _rythem;
				mStartPlayerTime = _offset;
				mBallFallingTime = (int)(Time.time * 1000);
		}

		void OnCollisionEnter2D (Collision2D _collision)
		{
				if (_collision.gameObject.tag == "quad") {

				}
		}

		public void setScore (int _score)
		{
				mScore = _score;
		}

		public int score {
				get { 
						return mScore;
				}

				set {
						mScore = value;
				}
		}

		public void pause ()
		{
			mSuppendTime = (int)(Time.time *1000);
			mPaused = true; 
			gameObject.animation.enabled = false;
		}
		public void resume()
		{
			mBallFallingTime += (int)(Time.time *1000) - mSuppendTime;
			mPaused = false;
			gameObject.animation.enabled = true;
		}
}
