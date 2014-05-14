using UnityEngine;
using System.Collections;

public class ScoreMaxPercent : MonoBehaviour {
	private Texture2D[] mTextureList;
	private Animation mMaxAnimation;
	// Use this for initialization
	void Start () {
		mTextureList = new Texture2D[11];
		loadTextures ();
		mMaxAnimation = gameObject.animation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void loadTextures()
	{

		for(int i = 0;i < 10 ;i ++)
		{
			mTextureList[i] = Resources.Load("pictures/common/maxpercent00" + i) as Texture2D;
		}
		mTextureList[10] = Resources.Load("pictures/common/maxpercent010") as Texture2D;
	}
	public void setPercent(int _percent)
	{
		int level = _percent / 10;
		gameObject.renderer.material.mainTexture = mTextureList [level];
		this.animation.Stop ();
		this.animation.Play ();
	}
}
