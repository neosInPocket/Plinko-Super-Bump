using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PaletteController : Resetable
{
	[SerializeField] private PossibleColorsController possibleColors;
	[SerializeField] private List<PaletteTile> tiles;
	public Color CurrentColor { get; set; }
	public Action<Color> TileSelected;
	public List<Color> ColorsInUse { get; set; }
	
	private void Awake()
	{
		GameOptions.Load();
	}
	
	private void Start()
	{	
		ColorsInUse = new List<Color>();
		
		Reset();
		
		for (int i = 0; i < tiles.Count; i++)
		{
			tiles[i].SetTileColor(possibleColors.Colors[i]);
		}
		
		SubscribeTiles();
	}
	
	public bool UseColor()
	{
		int foundColorCount = ColorsInUse.Count(x => x == CurrentColor);
		
		if (foundColorCount >= GameOptions.SingleColorCount)
		{
			return false;
		}
		else
		{
			ColorsInUse.Add(CurrentColor);
			if (foundColorCount + 1 >= GameOptions.SingleColorCount)
			{
				tiles.FirstOrDefault(x => x.TileColor == CurrentColor).Active = false;
			}
			return true;
		}
	}

	public override void Enable()
	{
		ToggleTiles(true);
	}

	public override void Disable()
	{
		ToggleTiles(false);
	}


	public void RemoveColor(Color color)
	{
		ColorsInUse.Remove(color);
		tiles.FirstOrDefault(x => x.TileColor == color).Active = true;
	}
	
	private void OnTileSelected(Color color)
	{
		CurrentColor = color;
		TileSelected?.Invoke(color);
	}
	
	public void ToggleTiles(bool value)
	{
		foreach (var tile in tiles)
		{
			tile.Active = value;
		}
	}
	
	public override void Reset()
	{
		ColorsInUse = new List<Color>();
		CurrentColor = possibleColors.Colors[0];
		OnTileSelected(CurrentColor);
		ToggleTiles(false);
	}
	
	private void SubscribeTiles()
	{
		foreach (var tile in tiles)
		{
			tile.Selected += OnTileSelected;
		}
	}
	
	private void UnsubscribeTiles()
	{
		foreach (var tile in tiles)
		{
			tile.Selected -= OnTileSelected;
		}
	}
	
	private void OnDestroy()
	{
		UnsubscribeTiles();
	}
	
	
}
