using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
	[SerializeField] private Image timerFill;
	[SerializeField] private TMP_Text timerText;
	private bool started;
	private float timerSeconds;
	private float startTime;
	
	private void Start()
	{
		StartTimer(10);
	}
	
	private void Update()
	{
		if (!started) return;
		
		if (startTime - Time.time > 0)
		{
			startTime -= Time.deltaTime;
			timerFill.fillAmount = (startTime - Time.time) / timerSeconds;
			timerText.text =  (startTime - Time.time).ToString("F2");
		}
		else
		{
			timerFill.fillAmount = 0;
			timerText.text = "0,00";
			started = false;
		}
		
	}
	
	public void StartTimer(float seconds)
	{
		timerSeconds = seconds;
		startTime = Time.time + seconds;
		started = true;
	}
	
	public void StopTimer()
	{
		started = false;
	}
	
	public void ResetTimer()
	{
		timerText.text = "0,00";
		timerFill.fillAmount = 1f;
	}
}
