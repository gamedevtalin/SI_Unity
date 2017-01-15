using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class SnapCameraToOrigin : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		PlaceCameraAtOrigin();
	}

	public void PlaceCameraAtOrigin ()
	{
		// Acquire camera
		Camera camera = Camera.main;

		if (camera != null)
		{
			float aspect = (float)camera.aspect;
			float size = (float)camera.orthographicSize;
			camera.transform.position = new Vector3(aspect * size, size, -10f);
		}		
	}

}
