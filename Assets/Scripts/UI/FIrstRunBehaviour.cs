using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class FIrstRunBehaviour : MonoBehaviour
{
	[SerializeField] private TMP_Text tutorialText;
	[SerializeField] private string[] replies;
	private int replyIndex;
	public Action FirstRunEnd;
	
	private void OnEnable()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		
		Touch.onFingerDown += FingerDown;
		replyIndex = 0;
		ChangeReplica();
	}
	
	private void FingerDown(Finger finger)
	{
		ChangeReplica();
	}
	
	private void ChangeReplica()
	{
		if (replyIndex >= replies.Length)
		{
			FirstRunEnd?.Invoke();
			gameObject.SetActive(false);
		}
		else
		{
			tutorialText.text = replies[replyIndex];
			replyIndex++;
		}
	}
	
	private void OnDisable()
	{
		Touch.onFingerDown -= FingerDown;
	}
}
