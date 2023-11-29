using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
	[SerializeField] private TMP_Text resultText;
	[SerializeField] private TMP_Text rewardText;
	[SerializeField] private TMP_Text buttonText;
	
	public void Show(bool isWon, LevelBuilder levelData)
	{
		gameObject.SetActive(true);
		if (isWon)
		{
			resultText.text = "you win";
			rewardText.text = $"+{levelData.LevelReward}";
			buttonText.text = "next level";
		}
		else
		{
			resultText.text = "you lose";
			rewardText.text = $"+0";
			buttonText.text = "retry";
		}
	}
}
