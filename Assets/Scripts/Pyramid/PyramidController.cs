using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidController : Resetable
{
	[SerializeField] private PaletteController paletteController;
	
	[Header("Misc")]
	[SerializeField] private Transform container;
	[SerializeField] private PyramidPiece piecePrefab;
	[SerializeField] private Vector2 yBorders;
	[SerializeField] private Vector2 xBorders;
	[SerializeField] private float bordersDelta;
	[SerializeField] private int rowCount;
	[SerializeField] private bool enableSound;
	
	private List<PyramidPiece> pieces;
	private Vector2 screenSize;
	public Action ColorMatch;
	
	private void Awake()
	{
		pieces = new();
	}
	
	private void Start()
	{
		screenSize = GameTools.GetScreenSize();
		
		Build();
	}
	
	private void Build()
	{
		Vector2 ySize = new Vector2(2 * screenSize.y * yBorders.x - screenSize.y, 2 * screenSize.y * yBorders.y - screenSize.y);
		Vector2 xSize = new Vector2(2 * screenSize.x * xBorders.x - screenSize.x, 2 * screenSize.x * xBorders.y - screenSize.x);
		
		float yStep = (ySize.y - ySize.x) / (rowCount - 1);
		float xStep = (xSize.y - xSize.x) / (rowCount - 1);
		
		Vector2 position = Vector2.one;
		position.x = xSize.x;
		
		for (int i = 0; i < rowCount; i++)
		{
			position.y = ySize.x + yStep * i;
			
			for (int j = rowCount - i; j > 0; j--)
			{
				var piece = Instantiate(piecePrefab, position, Quaternion.identity, container);
				piece.ColorMatch += OnPieceColorMatch;
				piece.EnableAudio = enableSound;
				pieces.Add(piece);
				position.x += xStep;
			}
			
			position.x = xSize.x + (i + 1) * xStep / 2;
		}
	}
	
	private void OnPieceColorMatch(Color color)
	{
		paletteController.RemoveColor(color);
		ColorMatch?.Invoke();
	}
	
	private void UnsubscribePieces()
	{
		foreach (var piece in pieces)
		{
			piece.ColorMatch -= OnPieceColorMatch;
		}
	}
	
	private void OnDestroy()
	{
		UnsubscribePieces();
	}

	public override void Reset()
	{
		foreach (var piece in pieces)
		{
			piece.PieceColor = Color.white;
		}
	}

	public override void Enable()
	{
		
	}

	public override void Disable()
	{
		
	}
}
