using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIGameStatus : Resetable
{
	[SerializeField] private GameLoader gameLoader;
	[SerializeField] private LevelTimer timer;
	[SerializeField] private GameProgressBar progressBar;
	[SerializeField] private TMP_Text levelText;
	[SerializeField] private FIrstRunBehaviour firstRun; 
	[SerializeField] private CDPanel countPanel; 
	[SerializeField] private WinPanel winPanel;
	private LevelBuilder levelData;

	private void Start()
	{
		gameLoader.MatchColor += UpdateGameInfo;
		gameLoader.TimerExpired += OnTimerExpired;
	}

	public override void Reset()
	{
		levelData = gameLoader.LevelData;
		ResetControls();
		
		if (GameOptions.FirstRun == 1)
		{
			GameOptions.FirstRun = 0;
			GameOptions.Save();
			
			firstRun.FirstRunEnd += FirstRunEnd;
			firstRun.gameObject.SetActive(true);
		}
		else
		{
			countPanel.CDEnd += CDEnd;
			countPanel.Play();
		}
	}
	
	private void FirstRunEnd()
	{
		firstRun.FirstRunEnd -= FirstRunEnd;
		countPanel.CDEnd += CDEnd;
		countPanel.Play();
	}
	
	private void CDEnd()
	{
		countPanel.CDEnd -= CDEnd;
		gameLoader.StartGame();
		OnGameStart();
	}
	
	private void ResetControls()
	{
		progressBar.Fill(0);
		timer.Reset();
		levelText.text = "level " + GameOptions.Level.ToString();
		
		countPanel.gameObject.SetActive(true);
	}
	
	public void OnGameStart()
	{
		timer.StartTimer(levelData.LevelTime);
	}
	
	public void UpdateGameInfo(bool isWon)
	{
		progressBar.Fill((float)levelData.CurrentScore / (float)levelData.LevelMaxScore);
		
		if (isWon)
		{
			winPanel.Show(true, levelData);
		}
	}
	
	public void OnTimerExpired()
	{
		winPanel.Show(false, levelData);
	}
	
	private void OnDestroy()
	{
		gameLoader.MatchColor -= UpdateGameInfo;
		gameLoader.TimerExpired += OnTimerExpired;
	}
	
	public override void Enable() { }

	public override void Disable() { }
}
