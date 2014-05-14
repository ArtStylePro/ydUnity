using UnityEngine;
using System.Collections;

public class FireAnimation : MonoBehaviour {
	public int mTrackIndex;
	public GameObject mAnimationObject;

	private bool mLoopMode;
	private Animator mAnimator;
	private int mTouchAnimation;
	private int mLeaveaAnimation;
	private int mIndexParam;
	// Use this for initialization
	void Start () {
		mLoopMode = false;
		mAnimator = mAnimationObject.gameObject.GetComponent ("Animator") as Animator;
		mTouchAnimation = Animator.StringToHash ("TouchDown");
		mLeaveaAnimation = Animator.StringToHash ("TouchUp");
		mIndexParam = Animator.StringToHash ("TrackIndex");
		mAnimator.SetInteger (mIndexParam, mTrackIndex);	
		//gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void beginFire()
	{
		Debug.Log("begin fire");
		mAnimator.SetTrigger (mTouchAnimation);
	//	mAnimator.SetInteger (Animator.StringToHash ("testParam"), 100);
//		if (gameObject.anima.isPlaying) {
//						gameObject.animation.Stop ();
//						gameObject.animation.Play ();
//				} else {
//					gameObject.SetActive (true);
//					gameObject.animation.Play();
//					
//				}

	}
	public void enterLoopMode()
	{
		mLoopMode = true;
	}
	public void leaveLoopMode()
	{
		mLoopMode = false;
	}
	public void animationPlayOver()
	{
	//	Debug.Log ("animation play over");
	//	mAnimator.SetTrigger (mLeaveaAnimation);
	}
	public void setIndex(int _index)
	{
	//	mAnimator.SetInteger (mIndexParam, _index);
	}
	void OnPress(bool _down)
	{
		if(_down)
		{
			int score = GameMainController.script.OnFingerDown(mTrackIndex);
			Debug.Log ("track index" + mTrackIndex + " is pressed,get score:" + score);
			if(score > 0)
			{
				beginFire();
			}
		}
	}

}
