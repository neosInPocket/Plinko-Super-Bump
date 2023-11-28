using System;
using System.Collections;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class GameEffect : MonoBehaviour
{
	[SerializeField] private ParticleSystem _particles;
	public Action<GameEffect> DeathEnded;
	
	private void Start()
	{
		StartCoroutine(DeathRoutine());
	}
	
	private IEnumerator DeathRoutine()
	{
		yield return new WaitForSeconds(_particles.main.duration);
		DeathEnded?.Invoke(this);
		Destroy(gameObject);
	}
}
