using System;
using UnityEngine;
using UnityEngine.UI;

public class PaletteTile : MonoBehaviour
{
	[SerializeField] private Image tile;
	[SerializeField] private Button button;
	[SerializeField] private Image cross;
	 
	public bool Active
	{
		get => button.interactable;
		set
		{
			button.interactable = value;
			cross.enabled = !value;
		}
	}
	public Action<Color> Selected;
	
	public Color TileColor
	{
		get => tile.color;
		set => tile.color = value;
	}
	
	public void SetTileColor(Color color)
	{
		TileColor = color;
	}

	public void Select()
	{
		Selected?.Invoke(TileColor);
	}
}
