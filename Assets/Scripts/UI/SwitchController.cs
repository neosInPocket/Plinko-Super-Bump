using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SwitchController : MonoBehaviour
{
	[SerializeField] private SwitchType switchType;
	[SerializeField] private Transform handle;
	[SerializeField] private float threshold;
	[SerializeField] private float speed;
	private float distance = 68.72f;
	private int currentPosition;
	
	private void Start()
	{
		if (switchType == SwitchType.Music)
		{
			currentPosition = GameOptions.BackgroundSoundsEnabled * 2 - 1;
		}
		else
		{
			currentPosition = GameOptions.SFXEnabled * 2 - 1;
		}
		
		var position = handle.localPosition;
		position.x = distance * currentPosition;
		handle.localPosition = position;
	}
	
	public void Toggle()
	{
		StopAllCoroutines();
		
		if (currentPosition == 1)
		{
			currentPosition = -1;
			StartCoroutine(HandleDestination(-1));
		}
		else
		{
			currentPosition = 1;
			StartCoroutine(HandleDestination(1));
		}
	}
	
	private IEnumerator HandleDestination(float direction)
	{
		Vector2 position = handle.localPosition;
		
		while (position.x * direction < distance + threshold)
		{
			position.x += speed * direction * Time.deltaTime * (Mathf.Abs(distance * direction - position.x) + threshold);
			handle.localPosition = position;
			yield return new WaitForEndOfFrame();
		}
		
		position.x = direction * distance;
		handle.localPosition = position;
	}
	
	
}

public enum SwitchType
{
	Music,
	SFX
}
