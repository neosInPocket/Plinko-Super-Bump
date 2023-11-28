using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSpawnZone : MonoBehaviour
{
	[SerializeField] private ParticleSystem glowCircle;
	[SerializeField] private float yPosition;
	
	private void Awake()
	{
		var screenSize = GameTools.GetScreenSize();
		
		var main = glowCircle.main;
		main.startSize = screenSize.x * 2;
		
		var position = transform.position;
		position.y = 2 * screenSize.y * yPosition - screenSize.y;
		transform.position = position;
	}
}
