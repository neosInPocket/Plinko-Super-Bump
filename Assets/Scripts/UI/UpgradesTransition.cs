using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesTransition : MonoBehaviour
{
	[SerializeField] private Transform content;
	[SerializeField] private Button lifesButton;
	[SerializeField] private Button gravityButton;
	[SerializeField] private Image lifesImage;
	[SerializeField] private Image gravityImage;
	[SerializeField] private float transitionSpeed;
	[SerializeField] private float threshold;
	private float lifesDestination = -319.44f;
	private float gravityDestination = 319.44f;
	
	public void GravityTransition()
	{
		lifesButton.interactable = true;
		gravityButton.interactable = false;
		SetImageAlpha(lifesImage, 1f);
		SetImageAlpha(gravityImage, 0.5f);
		
		
		StopAllCoroutines();
		StartCoroutine(Transition(gravityDestination));
	}
	
	public void LifesTransition()
	{
		lifesButton.interactable = false;
		gravityButton.interactable = true;
		SetImageAlpha(lifesImage, 0.5f);
		SetImageAlpha(gravityImage, 1f);
		
		StopAllCoroutines();
		StartCoroutine(Transition(lifesDestination));
	}
	
	private IEnumerator Transition(float destination)
	{
		Vector2 position = content.localPosition;
		float distance = - position.y + destination;
		float magnitude = Mathf.Abs(distance);
		int direction = (int)(distance / magnitude);
		
		while (position.y * direction < Mathf.Abs(destination) + threshold)
		{
			position.y += direction * transitionSpeed * (magnitude + threshold) * Time.deltaTime;
			magnitude = Mathf.Abs(- position.y + destination);
			content.localPosition = position;
			yield return new WaitForEndOfFrame();
		}
		
		position.y = destination;
		content.localPosition = position;
	}
	
	private void SetImageAlpha(Image image, float alpha)
	{
		var color = image.color;
		color.a = alpha;
		image.color = color;
	}
}
