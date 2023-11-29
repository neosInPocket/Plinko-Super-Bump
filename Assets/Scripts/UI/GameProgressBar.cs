using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgressBar : MonoBehaviour
{
	[SerializeField] private Image fill;
	
	public void Fill(float fillAmount)
	{
		fill.fillAmount = fillAmount;
	}
}
