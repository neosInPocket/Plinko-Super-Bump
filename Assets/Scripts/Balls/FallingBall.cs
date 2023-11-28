using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBall : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Color[] possibleColors;
	
	public Color BallColor => spriteRenderer.color;
	
	private void Start()
	{
		spriteRenderer.color = possibleColors[Random.Range(0, possibleColors.Length)];
	}
}
