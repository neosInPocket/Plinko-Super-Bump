using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderPyramid : MonoBehaviour
{
	[SerializeField] private PyramidPiece piecePrefab;
	[SerializeField] private Vector2 yBorders;
	[SerializeField] private float bordersDelta;
	
	private Vector2 screenSize;
	
	private void Start()
	{
		screenSize = GameTools.GetScreenSize();
		
		Build();
	}
	
	private void Build()
	{
		Vector2 initialPoint = new Vector2(0, 2 * screenSize.y * yBorders.x);
		Vector2 xValue = Vector2.one;
		Vector2 yValue = Vector2.one;
		
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < i + 1; j++)
			{
				Instantiate(piecePrefab, initialPoint, Quaternion.identity, transform);
			}
		}
	}
	
}
