using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using System.Data;
using Mono.Data.Sqlite;
using AssemblyCSharpfirstpass;



public class MusicListLogic : MonoBehaviour {

	public GameObject mSongItem;
	public GameObject mScrollContainer;
//	public UIDragScrollView mDraggablePanel ;
	public GameObject mDialogContainer;
	public UICamera mMainCamera;

	private IDbConnection mDBHandle;
	private IDataReader mDBReader;
	private IDbCommand mDBCommander;
	public static MusicListLogic script;
	public static GameObject mMusicDialog;



	// Use this for initialization
	void Start () {	

		MusicListLogic.script = this;

		UITable table_script =  mScrollContainer.GetComponent("UITable") as UITable;

		openDB();

		string sql = "select * from music where downloaded = '1' order by id";

		mDBCommander = mDBHandle.CreateCommand(	);
		mDBCommander.CommandText = sql;
		mDBReader = mDBCommander.ExecuteReader();

		float y_offset = 0.0f;//mScrollCamera.orthographicSize;
		float x_offset = 0.0f;
//		float item_height = mSongItem.transform.localScale.y;

		while (mDBReader.Read()) {

				GameObject item = NGUITools.AddChild(mScrollContainer,mSongItem);
				MusicItem script = item.GetComponent("MusicItem") as MusicItem;

				
				MusicInfo musicInfo = new MusicInfo();
				musicInfo.parseMusicItem(mDBReader);
				script.loadMusic(musicInfo);

		}
		table_script.Reposition();
		mDBHandle.Close();
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	private void openDB()
	{
		mDBHandle = MusicMGR.instance().getDBConnection();
		mDBHandle.Open();

	}
	public void OnMusicItemChecked(MusicInfo _info)
	{
		if(_info.mDownLoaded )
		{
			GameMainController.mMusicInfo = _info;
			Application.LoadLevel("Main");
		}
		else
		{
			int bg_id = LayerMask.NameToLayer("BackGround");
			int df_id = LayerMask.NameToLayer("Default");
			int dl_id = LayerMask.NameToLayer("Dialog"); 
			Debug.Log("dialog event mask id:" + dl_id);
			mMainCamera.eventReceiverMask.value = 1 << dl_id;
			Debug.Log("camera eventmask:" + mMainCamera.eventReceiverMask.value);

			GameObject dialog = NGUITools.AddChild(mDialogContainer,mMusicDialog);
			MusicDownloader script = dialog.GetComponent("MusicDownloader") as MusicDownloader;
			script.loadMusicInfo(_info);

		}
	
	}
	public void OnMusicDialogClosed()
	{
		Destroy(mMusicDialog);
		int bg_id = LayerMask.NameToLayer("BackGround");
		int df_id = LayerMask.NameToLayer("Default");
		int dl_id = LayerMask.NameToLayer("Dialog"); 
		mMainCamera.eventReceiverMask.value = 1 << df_id;
		mMainCamera.eventReceiverMask.value |= 1 << bg_id;
	}
	public void OnMusicDownloaded(MusicInfo _item)
	{
		openDB();
		string sql = "update music set downloaded = '1' where id=" + _item.mID ;
		mDBCommander = mDBHandle.CreateCommand();
		mDBCommander.CommandText = sql;
		mDBReader = mDBCommander.ExecuteReader();
		if(mDBReader.RecordsAffected == 1)
		{
			Debug.Log("update music download status success:" + _item.mID);
		}
		else
			Debug.LogWarning("update music download status fail:" + _item.mID);
	}

}
