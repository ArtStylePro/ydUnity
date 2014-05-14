using UnityEngine;
using System.Collections;
using AssemblyCSharpfirstpass;
public class Btn_later : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		Debug.Log("do it later is clicked");
		StartCoroutine(MusicDownloader.script.OnDownloadStart());

		//MusicListLogic.script.OnMusicDialogClosed();
	}
}
