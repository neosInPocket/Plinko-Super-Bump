using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicVolume : MonoBehaviour
{
	[SerializeField] private AudioSource audioS;
	
	private void Start()
	{
		audioS.volume = GameOptions.BackgroundSoundsVolume;
		audioS.enabled = GameOptions.BackgroundSoundsEnabled == 1;
	}
	
	public void SetVolume(float value)
	{
		audioS.volume = value;
		GameOptions.BackgroundSoundsVolume = value;
		GameOptions.Save();
	}
	
	public void ToggleEnabled()
	{
		if (audioS.enabled)
		{
			audioS.enabled = false;
			GameOptions.BackgroundSoundsEnabled = 0;
			GameOptions.Save();
		}
		else
		{
			audioS.enabled = true;
			GameOptions.BackgroundSoundsEnabled = 1;
			GameOptions.Save();
		}
	}
}
