using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : Resetable
{
	[SerializeField] private Image timerFill;
	[SerializeField] private TMP_Text timerText;
	private bool paused;
	public Action TimeExpired;
	
	public void StartTimer(float seconds)
	{
		StartCoroutine(TimerRoutine(seconds));
	}
	
	public override void Disable()
	{
		StopAllCoroutines();
	}
	
	public override void Reset()
	{
		timerText.text = "0,00";
		timerFill.fillAmount = 1f;
	}
	
	public void Pause()
	{
		paused = true;
	}
	
	public void UnPause()
	{
		paused = false;
	}
	
	private IEnumerator TimerRoutine(float seconds)
	{
		var time = seconds;
		
		while (time > 0)
		{
			if (!paused)
			{
				time -= Time.fixedDeltaTime;
				timerFill.fillAmount = time / seconds;
				timerText.text = time.ToString("F2");
				yield return new WaitForFixedUpdate();
			}
			else
			{
				yield return null;
			}
		}
		
		timerFill.fillAmount = 0;
		timerText.text = "0,00";
		TimeExpired?.Invoke();
	}

	public override void Enable() { }
}
