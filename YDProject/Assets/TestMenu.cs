using UnityEngine;
using System.Collections;

public class TestMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		GUI.TextField (new Rect (0, 0, 100, 100), "我是谁");
	}
}
