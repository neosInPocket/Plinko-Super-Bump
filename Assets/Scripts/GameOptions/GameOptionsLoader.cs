using UnityEngine;

public class GameOptionsLoader : MonoBehaviour
{
	[SerializeField] private bool resetGameOptions;
	
	private void Awake()
	{
		if (resetGameOptions)
		{
			GameOptions.ClearData();
		}
	}
}
