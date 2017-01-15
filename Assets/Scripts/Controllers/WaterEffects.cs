using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterEffects : MonoBehaviour 
{

	// TODO: REMOVE FLIPS
	// FIXME: If we set the wave sprite pivot to center, flipping does not change the position!

	public GameObject wavePrefab;
	
	int waveLayers = 3;
	int waveComponents = 2;
	float waveBaseSpeed = 0.5f;
	float parallaxFactor = 0.2f;
	float waveComponentLength;

	GameObject[,] waveElements;

	void Start () 
	{
		waveElements = new GameObject[waveLayers, 2];
		waveComponentLength = wavePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

		for (int i = 0; i < waveLayers; i++)
		{
			// Instantiate first wave element
			GameObject waveObj;
			Vector3 wavePos = new Vector3(-1.5f, 0.5f*i-1.25f, 0.1f*i);
			waveObj = (GameObject)Instantiate(wavePrefab, wavePos, Quaternion.identity);
			waveElements[i, 0] = waveObj;
			// set name and parent
			waveObj.name = "Wave_"+i+"_0";
			waveObj.transform.parent = this.transform;

			// Instantiate backup wave
			Vector3 wave2Pos = wavePos + new Vector3(waveComponentLength*2, 0f, 0f);
			waveObj = (GameObject)Instantiate(wavePrefab, wave2Pos, Quaternion.identity);
			SpriteRenderer waveSpriteRenderer = waveObj.GetComponent<SpriteRenderer>();
			waveSpriteRenderer.flipX = true;
			waveObj.name = "Wave_"+i+"_1";
			waveObj.transform.parent = this.transform;
			waveElements[i, 1] = waveObj;
		}		
	}
	
	void Update () 
	{
		// Move the waves
		for (int i = 0; i < waveLayers; i++)
		{
			for (int el = 0; el < waveComponents; el++)
			{
				GameObject wave = waveElements[i, el];
				SpriteRenderer waveSR = wave.GetComponent<SpriteRenderer>();
				Vector3 newPos = wave.transform.position;
				newPos.x -= Time.deltaTime * (waveBaseSpeed - i * parallaxFactor);
				if (waveSR.flipX == false && newPos.x < -18f)
				{
					Vector3 endWavePos = waveElements[i, waveComponents-1].transform.position;
					newPos.x = endWavePos.x - Time.deltaTime * waveBaseSpeed;
				}
				else if (waveSR.flipX == true && newPos.x < -1.5f)
				{
					Vector3 endWavePos = waveElements[i, 0].transform.position;
					newPos.x = endWavePos.x + waveComponentLength * 2f;
				}
				wave.transform.position = newPos;
			}
		}
	}
}
