using UnityEngine;
using System.Collections;

public class GameTouchProcesser : MonoBehaviour {

	public int mTrackIndex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnPress(bool _down)
	{
		if(_down)
		{
			Debug.Log ("track index" + mTrackIndex + " is pressed");
			GameMainController.script.OnFingerDown(mTrackIndex);
		}
	}
}
