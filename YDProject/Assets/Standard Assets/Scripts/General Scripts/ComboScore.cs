using UnityEngine;
using System.Collections;

public class ComboScore : MonoBehaviour {
	private int mComboCount;
	private float mSpriteWidth;
	private Vector3 mMiddlePosition;
	private Vector3 mLeftHalfPosition;
	private Vector3 mLeftPosition;
	private Vector3 mRightHalfPosition;
	private Vector3 mRightPosition;

	public Sprite[] mAtlasChildrenList;
	public GameObject[] mComboSpriteList;


	// Use this for initialization
	void Start () {
		mComboCount = 0;
		mSpriteWidth = mComboSpriteList [0].renderer.bounds.max.x - mComboSpriteList [0].renderer.bounds.min.x;
		mMiddlePosition = new Vector3 (0.0f, 0.0f, 0.0f);
		mLeftHalfPosition = new Vector3 (-mSpriteWidth / 2.0f, 0.0f, 0.0f);
		mLeftPosition = new Vector3 (-mSpriteWidth, 0.0f, 0.0f);
		mRightHalfPosition = new Vector3 (mSpriteWidth / 2.0f, 0.0f, 0.0f);
		mRightPosition = new Vector3 (mSpriteWidth, 0.0f, 0.0f);
		missCombo ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void addCombo()
	{
		mComboCount ++;
		Debug.Log ("set combo number:" + mComboCount);
		if (mComboCount == 1) 
		{
			Debug.Log ("combo is 1");
		//	gameObject.renderer.enabled = true;
			mComboSpriteList[0].renderer.enabled = true;
			mComboSpriteList[0].transform.localPosition = mMiddlePosition;
		}
		else
		if (mComboCount == 10) 
		{
			Debug.Log ("combo is 10");
			mComboSpriteList[1].renderer.enabled = true;
			mComboSpriteList[1].transform.localPosition = mLeftHalfPosition;
			mComboSpriteList[0].transform.localPosition = mRightHalfPosition;
		}
		else
		if(mComboCount == 100)
		{
			Debug.Log ("combo is 100");
			mComboSpriteList[2].renderer.enabled = true;
			mComboSpriteList[2].transform.localPosition = mLeftPosition;
			mComboSpriteList[1].transform.localPosition = mMiddlePosition;
			mComboSpriteList[0].transform.localPosition = mRightPosition;
		}
	


		int combo = mComboCount;
		int len = mComboSpriteList.Length;


		for(int i = 0;i < len ;i ++)
		{
			int num = combo%10;
			SpriteRenderer render = mComboSpriteList[i].renderer as SpriteRenderer;

			render.sprite = mAtlasChildrenList[num];
			UnityEngine.Debug.Log ("set combo number:" + num + " at position:" + mComboSpriteList[i].name);
			combo /= 10;
			if(combo == 0)
				break;
		}


	}
	public void missCombo()
	{
		mComboCount = 0;
		for (int i = 0; i < mComboSpriteList.Length; i ++)
						mComboSpriteList [i].renderer.enabled = false;
	//	gameObject.renderer.enabled = false;
	}
}
