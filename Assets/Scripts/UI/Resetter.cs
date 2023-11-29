using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
	[SerializeField] private List<Resetable> resetables;
	
	public void AllReset()
	{
		foreach (var resetable in resetables)
		{
			resetable.Reset();
		}
	}
	
	public void AllEnable()
	{
		foreach (var resetable in resetables)
		{
			resetable.Enable();
		}
	}
	
	public void AllDisable()
	{
		foreach (var resetable in resetables)
		{
			resetable.Disable();
		}
	}
}
