using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolumeSliderValue : MonoBehaviour
{
	[SerializeField] private Slider slider;
	[SerializeField] private SwitchType musicType;
	
	private void Start()
	{
		if (musicType == SwitchType.Music)
		{
			slider.value = GameOptions.BackgroundSoundsVolume;
		}
		
		if (musicType == SwitchType.SFX)
		{
			slider.value = GameOptions.SfxVolume;
		}
	}
}
