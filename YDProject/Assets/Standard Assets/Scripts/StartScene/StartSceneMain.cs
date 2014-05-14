using UnityEngine;
using System.Collections;
using AssemblyCSharpfirstpass;
using System.IO.Compression;

public class StartSceneMain : MonoBehaviour {

	private int mStatus = 0;

	// Use this for initialization
	void Start () {
		mStatus = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(mStatus == 0)
		{
			Vector3 position = new Vector3();
			bool process_input = false;
			if (Input.GetMouseButtonDown (0)) {
			//	Vector3 mouseInWorld = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
				position = Input.mousePosition;
				process_input = true;
			}
			else
			if(Input.touchCount > 0 )
			{
				Touch touch = Input.GetTouch(0);
				if(touch.phase == TouchPhase.Began)
				{
					position = touch.rawPosition;
					process_input = true;
				}
			}


			if(process_input)
			{
				Ray ray = Camera.main.ScreenPointToRay(position);
				RaycastHit2D ray_hit  = Physics2D.Raycast(ray.origin,ray.direction);
				if(ray_hit.collider != null)
				{
					if(ray_hit.collider.tag == "music_list")
					{
						Debug.Log ("music list is touched");
						if(mStatus == 0)
						{
							Application.LoadLevel("SongList");
						}
						mStatus = 1;
					}
					else
						if(ray_hit.collider.tag == "download_list")
					{
						Debug.Log ("download list is touched");
						if(mStatus == 0)
						{
							Application.LoadLevel("SongList");
						}
						mStatus = 1;
					}
				}

				//DataService.instance().checkEvent(DataService.CHECK_VERSION,this);
				//Application.LoadLevel("Main");
			}

		}
	}
}
