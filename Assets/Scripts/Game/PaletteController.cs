using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaletteController : MonoBehaviour
{
	[SerializeField] private PossibleColorsController possibleColors;
	[SerializeField] private List<PaletteTile> tiles;
	public Color CurrentColor { get; set; }
	public Action<Color> TileSelected;
	public List<Color> ColorsInUse { get; set; }
	
	private void Start()
	{	
		ColorsInUse = new List<Color>();
		
		Reset();
		
		for (int i = 0; i < tiles.Count; i++)
		{
			tiles[i].SetTileColor(possibleColors.Colors[i]);
		}
		
		SubscribeTiles();
		ToggleTiles(true);
	}
	
	public bool UseColor()
	{
		bool foundColor = ColorsInUse.Contains(CurrentColor);
		
		if (foundColor)
		{
			return false;
		}
		else
		{
			ColorsInUse.Add(CurrentColor);
			tiles.FirstOrDefault(x => x.TileColor == CurrentColor).Active = false;
			return true;
		}
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
	
	public void Reset()
	{
		CurrentColor = possibleColors.Colors[0];
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
