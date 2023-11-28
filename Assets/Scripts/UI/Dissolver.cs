using System;
using Coffee.UIEffects;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
	[SerializeField] private UITransitionEffect transition;
	[SerializeField] private PanelsChanger panelsChanger;
	private bool showing;
	private int targetPanel;
	
	private void Update()
	{
		if (!showing) return;
		
		if (transition.effectFactor == 1)
		{
			showing = false;
			panelsChanger.ChangePanel(targetPanel);
			transition.Hide();
		}
	}
	
	public void Dissolve(int panelType)
	{
		targetPanel = panelType;
		showing = true;
		transition.Show();
	}
}
