using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBall : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private PossibleColorsController possibleColors;
	[SerializeField] private GameEffect destroyEffect;
	
	public Color BallColor => spriteRenderer.color;
	
	private void Start()
	{
		spriteRenderer.color = possibleColors.Colors[Random.Range(0, possibleColors.Colors.Count)];
	}
	
	public void Destroy()
	{
		circleCollider2D.enabled = false;
		var effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
		effect.DeathEnded += DestroyEffectEnded;
	}
	
	private void DestroyEffectEnded(GameEffect effect)
	{
		effect.DeathEnded -= DestroyEffectEnded;
		Destroy(gameObject);
	}
}
