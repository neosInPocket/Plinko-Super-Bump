using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder
{
	public int LevelReward { get; set; }
	public int LevelMaxScore { get; set; }
	public int LevelTime { get; private set; }
	
	public int CurrentScore => currentScore;
	private int currentScore;
	
	public LevelBuilder()
	{
		CalculateLevelTime();
		CalculateMaxReward();
		CalculateMaxScore();
		currentScore = 0;
	}
	
	private void CalculateLevelTime()
	{
		float x = GameOptions.Level;
		LevelTime = (int)(10f * Mathf.Exp(-x * x * x * x / 1000f) + 20f);
	}
	
	private void CalculateMaxReward()
	{
		float x = GameOptions.Level;
		LevelReward = (int)(-30f * Mathf.Exp(-x * x / 100f) + 70f);
	}
	
	private void CalculateMaxScore()
	{
		float x = GameOptions.Level;
		LevelMaxScore = (int)(-30f * Mathf.Exp(-x * x / 100f) + 70f);
	}
	
	public bool IncreaseCurrentScore(int value)
	{
		currentScore += value;
		
		if (currentScore >= LevelMaxScore)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
