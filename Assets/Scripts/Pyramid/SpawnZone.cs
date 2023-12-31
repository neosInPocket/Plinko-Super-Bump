using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnZone : Resetable
{
	[SerializeField] private Vector2 xSize;
	[SerializeField] private float spawnDelay;
	[SerializeField] private FallingBall fallingBallPrefab;
	[SerializeField] private bool isEnabled; 
	private Vector2 screenSize;
	private Vector2 worldXSize;
	private bool isSpawning;
	
		
	private void Start()
	{
		screenSize = GameTools.GetScreenSize();
		worldXSize = new Vector2(2 * screenSize.x * xSize.x - screenSize.x, 2 * screenSize.x * xSize.y - screenSize.x);
	}
	
	private void FixedUpdate()
	{
		if (isSpawning || !isEnabled) return;
		StartCoroutine(Spawn());
	}
	
	public override void Enable()
	{
		isEnabled = true;
	}
	
	public override void Disable()
	{
		isEnabled = false;
		isSpawning = false;
	}
	
	public void Clear()
	{
		StopAllCoroutines();
		isSpawning = false;
		ClearAllBalls();
	}

	public override void Reset()
	{
		Clear();
		Disable();
	}

	private void ClearAllBalls()
	{
		foreach (Transform ball in transform)
		{
			Destroy(ball.gameObject);
		}
	}
	
	private IEnumerator Spawn()
	{
		isSpawning = true;
		Vector2 position = new Vector2(Random.Range(worldXSize.x, worldXSize.y), transform.position.y);
		Instantiate(fallingBallPrefab, position, Quaternion.identity, transform);
		yield return new WaitForSeconds(spawnDelay);
		isSpawning = false;
	}
}
