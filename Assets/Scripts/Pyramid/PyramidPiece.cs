using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PyramidPiece : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private AudioSource pingSource;
	[SerializeField] private GameObject selectedEffect; 
	[SerializeField] private float randomPercent;
	[SerializeField] private float duration;
	[SerializeField] private float size;
	
	public Action<Color> ColorMatch;
	
	public Color PieceColor
	{
		get => spriteRenderer.color;
		set
		{
			spriteRenderer.color = value;
			currentStaticColor = value;
			if (value != Color.white)
			{
				selectedEffect.SetActive(true);
			}
			else
			{
				selectedEffect.SetActive(false);
			}
		}
	}
	
	public Color currentStaticColor { get; set; }
	
	public SpriteRenderer SpriteRenderer => spriteRenderer;
	public bool EnableAudio { get; set; }
	
	private void Start()
	{
		currentStaticColor = Color.white;
		spriteRenderer.size = new Vector2(size, size);
		circleCollider2D.radius = size / 2;
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (EnableAudio)
		{
			pingSource.Stop();
			pingSource.pitch *= 1 + Random.Range(-randomPercent / 100, randomPercent / 100);
			pingSource.Play();
		}
		
		if (collision.gameObject.TryGetComponent<FallingBall>(out FallingBall fallingBall))
		{
			if (fallingBall.BallColor == PieceColor && PieceColor != Color.white)
			{
				ColorMatch?.Invoke(currentStaticColor);
				PieceColor = Color.white;
			}
			
			StopAllCoroutines();
			var fallingBallColor = fallingBall.BallColor;
			StartCoroutine(Fade(fallingBallColor, duration));
		}
	}
	
	private IEnumerator Fade(Color color, float duration)
	{
		spriteRenderer.color = color;
		float t = 0;
		float tStep = 1 / duration * Time.fixedDeltaTime;
		
		while (t < 1)
		{
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, currentStaticColor, t);
			t += tStep;
			yield return new WaitForFixedUpdate();
		}
	}
}
