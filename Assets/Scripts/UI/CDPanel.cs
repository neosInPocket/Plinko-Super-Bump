using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDPanel : MonoBehaviour
{
	[SerializeField] private Animator animator; 
	public Action CDEnd;
	
	public void OnCDEnd()
	{
		CDEnd?.Invoke();
		gameObject.SetActive(false);
	}
	
	public void Play()
	{
		animator.SetTrigger("CD");
	}
}
