using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapController : MonoBehaviour 
{

	public static MapController Instance {get; protected set;}

	public GameObject nodePrefab;

	public int width = 28;
	public int height = 15;

	Dictionary<Node, GameObject> nodeObjectMap;

	Map map;

	float xOffset = 2 * 0.52f;
	float yOffset = 0.8f;

	void Start () 
	{
		Instance = this;
		nodeObjectMap = new Dictionary<Node, GameObject>();

		// Initialize game map
		map = new Map(width, height);

		// Create (visual) node objects
		SpawnNodes();	

		// Lock camera into the centre of the screen
		CenterCamera();
	}

	void Update () 
	{
	}

	public void SpawnNodes ()
	{
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				// Calcualte Node object position
				Vector3 pos = new Vector3(0f, 0f, 0f);
				pos.y = y * yOffset;
				pos.x = x * xOffset;
				
				// Push nodes on odd rows
				if (y % 2 == 1)
				{
					pos.x += xOffset / 2f;
				}
				
				// Cut end nodes on odd rows to establish symmetry
				if (y % 2 != 1 || x != width - 1)
				{
					Node nodeData = map.GetNodeAt(x, y);
					GameObject nodeObject = (GameObject)Instantiate(nodePrefab, pos, Quaternion.identity);
					
					nodeObject.name = "Node_"+x+"_"+y;
					nodeObject.transform.parent = this.transform;
					nodeObjectMap.Add(nodeData, nodeObject);
				}
			}
		}
	}

	  //////////////////////////
	 //	   Event handlers    //
	//////////////////////////

	void OnAddToNodeStack (Node node)
	{
		//
	}

	void OnRemFromNodeStack (Node node)
	{
		//
	}

	  //////////////////////////
	 //	Camera functionality //
	//////////////////////////

	void CenterCamera ()
	{
		Vector3 newCamPos;
		float camXOffset = (width - 1) * 0.52f;
		float camYOffset = (height - 1) * yOffset / 2f;
		newCamPos = new Vector3(camXOffset, camYOffset, -10f);
		Camera.main.transform.position = newCamPos;
	}

}

