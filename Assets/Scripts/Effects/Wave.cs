using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour 
{

	public float waveAmplitude = 1f;
	public float waveSpeed = 0.025f;

	float remMovement = 0f;

	Vector3 startingPos;

	void Start ()
	{
		startingPos = this.transform.position;
		remMovement = waveAmplitude;
	}

	void Update () 
	{
		Vector3 temp = this.transform.position;
		temp.y += waveSpeed;
		remMovement -= Mathf.Abs(waveSpeed);

		if (remMovement > 0f)
		{
			this.transform.position = temp;
		}
		else
		{
			remMovement = waveAmplitude;
			waveSpeed = -1 * waveSpeed;
		}
	}
}
