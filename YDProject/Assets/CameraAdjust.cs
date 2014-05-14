using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UICamera))]
[ExecuteInEditMode]
public class CameraAdjust : MonoBehaviour
{

		
		void Start ()
		{
			camera.aspect = 320.0f/480.0f;		
		}
	 

}
