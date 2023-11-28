using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class PanelsChanger : MonoBehaviour
{
	[SerializeField] private GameObject menuPanel;
	[SerializeField] private GameObject optionsPanel;
	[SerializeField] private GameObject upgradesPanel;
	private GameObject currentPanel;
	
	private void Start()
	{
		currentPanel = menuPanel;
	}
	
	public void ChangePanel(int panelType)
	{
		currentPanel.SetActive(false);
		
		if (panelType == 0)
		{
			menuPanel.SetActive(true);
			currentPanel = menuPanel;
		}
		
		if (panelType == 1)
		{
			optionsPanel.SetActive(true);
			currentPanel = optionsPanel;
		}
		
		if (panelType == 2)
		{
			upgradesPanel.SetActive(true);
			currentPanel = upgradesPanel;
		}
	}
}

public enum PanelType
{
	Menu = 0,
	Options = 1,
	Upgrades = 2
}
