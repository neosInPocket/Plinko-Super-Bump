using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameStatus : Resetable
{
	[SerializeField] private LevelTimer timer;
	[SerializeField] private GameProgressBar progressBar;

	public override void Reset()
	{
		progressBar.Fill(0);
		timer.Reset();
	}
	
	public void UpdateInfo()
	{
		
	}
}
