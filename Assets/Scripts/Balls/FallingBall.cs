using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBall : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private PossibleColorsController possibleColors;
	[SerializeField] private GameEffect destroyEffect;
	[SerializeField] private Rigidbody2D rigid2D;
	private Vector2 speed;
	
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
	
	public void Freeze()
	{
		speed = rigid2D.velocity;
		rigid2D.constraints = RigidbodyConstraints2D.FreezeAll;
	}
	
	public void UnFreeze()
	{
		rigid2D.constraints = RigidbodyConstraints2D.None;
		rigid2D.velocity = speed;
	}
}
