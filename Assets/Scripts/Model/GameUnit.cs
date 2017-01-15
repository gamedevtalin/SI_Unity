using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit
{

	public bool isActive {get; protected set;}

	Action<GameUnit> OnChange;

	public GameUnit ()
	{
		isActive = false;
	}

	public void Enable ()
	{
		if (isActive == false)
		{
			isActive = true;
			OnChange(this);
		}
	}

	public void Disable ()
	{
		if (isActive == true)
		{
			isActive = false;
			OnChange(this);
		}
	}

	public void RegisterObserver (Action<GameUnit> callback)
	{
		OnChange += callback;
	}

	public void UnregisterObserver (Action<GameUnit> callback)
	{
		OnChange -= callback;
	}

}
