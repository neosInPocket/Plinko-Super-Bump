using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
	[SerializeField] private Resetter resetter;
	[SerializeField] private PyramidController pyramidController;
	[SerializeField] private LevelTimer levelTimer;
	[SerializeField] private TouchController touchController;
	
	public Action<bool> MatchColor;
	public Action TimerExpired;
	public LevelBuilder LevelData { get; set; }
	
	private void Start()
	{
		pyramidController.ColorMatch += OnColorMatch;
		levelTimer.TimeExpired += OnTimeExpired;
		Load();
	}
	
	public void Load()
	{
		LevelData = new LevelBuilder();
		resetter.AllReset();
		touchController.Disable();
	}
	
	public void StartGame()
	{
		resetter.AllEnable();
		touchController.Enable();
	}
	
	private void OnColorMatch()
	{
		bool isWon = LevelData.IncreaseCurrentScore(15);
		
		if (isWon)
		{
			resetter.AllDisable();
			GameOptions.Level++;
			GameOptions.Gold += LevelData.LevelReward;
			GameOptions.Save();
		}
		
		MatchColor?.Invoke(isWon);
	}
	
	private void OnTimeExpired()
	{
		resetter.AllDisable();
		TimerExpired?.Invoke();
		touchController.Disable();
	}
	
	public void LoseGame()
	{
		resetter.AllDisable();
	}
	
	private void OnDestroy()
	{
		pyramidController.ColorMatch -= OnColorMatch;
		levelTimer.TimeExpired -= OnTimeExpired;
	}
	
	public void GetMainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
