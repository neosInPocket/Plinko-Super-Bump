using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidPiece : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private AudioSource pingSource;
	[SerializeField] private float randomPercent;
	[SerializeField] private float duration;
	private Color initialColor;
	
	public SpriteRenderer SpriteRenderer => spriteRenderer;
	public bool EnableAudio { get; set; }
	
	private void Start()
	{
		initialColor = spriteRenderer.color;
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (EnableAudio)
		{
			pingSource.Stop();
			pingSource.pitch *= 1 + Random.Range(-randomPercent / 100, randomPercent / 100);
			pingSource.Play();
		}
		
		StopAllCoroutines();
		var fallingBallColor = collision.collider.GetComponent<FallingBall>().BallColor;
		StartCoroutine(Fade(fallingBallColor, duration));
	}
	
	private IEnumerator Fade(Color color, float duration)
	{
		spriteRenderer.color = color;
		float t = 0;
		float tStep = 1 / duration * Time.fixedDeltaTime;
		
		while (t < 1)
		{
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, initialColor, t);
			t += tStep;
			yield return new WaitForFixedUpdate();
		}
	}
}
