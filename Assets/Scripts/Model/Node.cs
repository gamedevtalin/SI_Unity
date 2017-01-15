using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node 
{

	public int x {get; protected set;}
	public int y {get; protected set;}

	Stack<GameUnit> unitStack;
	
	Action<Node> OnNodeStackChange;

	public Node (int targetX, int targetY)
	{
		x = targetX;
		y = targetY;
		unitStack = new Stack<GameUnit>();
	}

	public void PlaceUnit (GameUnit unit)
	{
		if (unit == null)
		{
			Debug.LogError("GameUnit pushed to node stack is null");
		}
		else
		{
			unitStack.Peek().Disable();
			unitStack.Push(unit);
			unit.Enable();
			OnNodeStackChange(this);
		}
	}

	public GameUnit GetTopUnit ()
	{
		if (unitStack.Count > 0)
		{
			return unitStack.Peek();
		}
		return null;
	}

	public void RemoveUnit ()
	{
		if (unitStack.Count > 0)
		{
			GameUnit unitToRemove = unitStack.Pop();
			if (unitStack.Count > 0)
			{
				unitStack.Peek().Enable();
			}
			OnNodeStackChange(this);
		}
	}

	public void RegisterObserver (Action<Node> callback)
	{
		OnNodeStackChange += callback;
	}

	public void UnregisterObserver (Action<Node> callback)
	{
		OnNodeStackChange -= callback;
	}

}
