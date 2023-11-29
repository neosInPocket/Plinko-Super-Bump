using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
	[SerializeField] private SpawnZone spawnZone;
	[SerializeField] private Animator pauseImage; 
	[SerializeField] private LevelTimer levelTimer;
	[SerializeField] private TouchController touchController;
	
	public void Pause()
	{
		levelTimer.Pause();
		touchController.Disable();
		
		spawnZone.Disable();
		foreach (Transform ball in spawnZone.transform)
		{
			ball.GetComponent<FallingBall>().Freeze();
		}
	}
	
	public void StartUnpauseCountDown()
	{
		pauseImage.SetTrigger("countdown");
	}
	
	public void Unpause()
	{
		levelTimer.UnPause();
		touchController.Enable();
		spawnZone.Enable();
		foreach (Transform ball in spawnZone.transform)
		{
			ball.GetComponent<FallingBall>().UnFreeze();
		}
		
		pauseImage.gameObject.SetActive(false);
	}
}
