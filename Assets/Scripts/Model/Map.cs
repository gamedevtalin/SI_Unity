using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map
{

	public static Map Instance {get; protected set;}

	public int width {get; protected set;}
	public int height {get; protected set;}

	Node[,] nodes;

	public Map (int mapWidth, int mapHeight)
	{
		Instance = this;

		// set map dimensions
		width = mapWidth;
		height = mapHeight;
		nodes = new Node[width, height];

		// create nodes
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				Node newNode = new Node(x, y);
				nodes[x, y] = newNode;
			}
		}
	}

	public Node GetNodeAt (int x, int y)
	{
		if (x >= width || x < 0 || y >= height || y < 0)
		{
			Debug.LogError("Location "+x+","+y+" is out of bounds.");
			return null;
		}
		if (nodes[x, y] == null)
		{
			Debug.LogError("Node at "+x+","+y+" is inactive");
			return null;
		}
		return nodes[x, y];
	}

}
