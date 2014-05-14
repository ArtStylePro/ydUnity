using UnityEngine;
using System.Collections;

public class GamePauseMenu : MonoBehaviour {

	public GameUI mGameUI;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnMenuLeaveAnimationOver()
    {
		mGameUI.OnPauseMenuGone();
	}
}
