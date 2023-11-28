using UnityEngine;
using UnityEngine.UI;

public class TilePreview : MonoBehaviour
{
	[SerializeField] private Image tile;
	[SerializeField] private PaletteController paletteController;
	
	public Color TileColor
	{
		get => tile.color;
		set => tile.color = value;
	}
	
	private void Start()
	{
		paletteController.TileSelected += OnTileSelected;
	}
	
	private void OnTileSelected(Color color)
	{
		TileColor = color;
	}
	
	private void OnDestroy()
	{
		if (paletteController)
		{
			paletteController.TileSelected -= OnTileSelected;
		}
	}
}
