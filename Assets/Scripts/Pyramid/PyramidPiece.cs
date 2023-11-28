using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidPiece : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private AudioSource pingSource;
	[SerializeField] private float randomPercent;
	[SerializeField] private float duration;
	
	public SpriteRenderer SpriteRenderer => spriteRenderer;
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		pingSource.Stop();
		pingSource.pitch *= 1 + Random.Range(-randomPercent / 100, randomPercent / 100);
		pingSource.Play();
		
		var fallingBallColor = collision.collider.GetComponent<FallingBall>().BallColor;
		StartCoroutine(Fade(fallingBallColor, duration));
	}
	
	private IEnumerator Fade(Color color, float duration)
	{
		var initialColor = spriteRenderer.color;
		spriteRenderer.color = color;
		float t = 0;
		float tStep = 1 / duration / 60;
		
		while (t < 1)
		{
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, initialColor, t);
			t += tStep;
			yield return new WaitForFixedUpdate();
		}
	}
}
