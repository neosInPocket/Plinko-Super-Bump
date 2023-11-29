using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSfxVolume : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;
	
	private void Start()
	{
		sfx.volume = GameOptions.SfxVolume;
		sfx.enabled = GameOptions.SFXEnabled == 1;
	}
}
