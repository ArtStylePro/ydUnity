using UnityEngine;
using System.Collections;

public class StartSceneLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnButtonClicked(string _id)
	{
		Debug.Log ("button is clicked:" + _id);
	}
	public  void OnButtonAnimationOver(string _id)
	{
		Debug.Log ("button is animation over:" + _id);
		if(_id == "music")
			Application.LoadLevel("songList");
	}
}
