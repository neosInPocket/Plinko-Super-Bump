using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceholderPyramid : MonoBehaviour
{
	[SerializeField] private Transform container;
	[SerializeField] private PyramidPiece piecePrefab;
	[SerializeField] private Vector2 yBorders;
	[SerializeField] private Vector2 xBorders;
	[SerializeField] private float bordersDelta;
	[SerializeField] private  int rowCount;
	[SerializeField] private bool enableSound;
	
	private Vector2 screenSize;
	
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
				if (!enableSound) piece.EnableAudio = false;
				position.x += xStep;
			}
			
			position.x = xSize.x + (i + 1) * xStep / 2;
		}
	}
	
}
