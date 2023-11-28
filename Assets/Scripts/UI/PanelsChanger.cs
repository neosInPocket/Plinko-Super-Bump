using UnityEngine;
using UnityEngine.SceneManagement;

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
		
		if (panelType == 3)
		{
			LoadGame();
		}
	}
	
	public void LoadGame()
	{
		SceneManager.LoadScene("Game");
	}
}

public enum PanelType
{
	Menu = 0,
	Options = 1,
	Upgrades = 2,
	Game = 3
}
