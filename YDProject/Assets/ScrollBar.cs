using UnityEngine;
using System.Collections;

public class ScrollBar : MonoBehaviour {

	public GameObject mEventReceiver;
	public string iDentify;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		gameObject.GetComponent<Animator>().SetTrigger(Animator.StringToHash("Touched"));
		mEventReceiver.SendMessage("OnButtonClicked",iDentify);
	}
	public void OnAnimationOver()
	{
		Debug.Log ("animation is over")	;	
		mEventReceiver.SendMessage("OnButtonAnimationOver",iDentify);
	}
}
