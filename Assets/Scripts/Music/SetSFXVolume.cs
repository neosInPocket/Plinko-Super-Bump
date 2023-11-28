using UnityEngine;

public class SetSFXVolume : MonoBehaviour
{
	public void SetVolume(float value)
	{
		GameOptions.SfxVolume = value;
		GameOptions.Save();
	}
	
	public void ToggleEnabled()
	{
		if (GameOptions.SFXEnabled == 1)
		{
			GameOptions.SFXEnabled = 0;
			GameOptions.Save();
		}
		else
		{
			GameOptions.SFXEnabled = 1;
			GameOptions.Save();
		}
	}
}
