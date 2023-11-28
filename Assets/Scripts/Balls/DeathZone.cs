using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
	[SerializeField] private BoxCollider2D boxCollider2D;
	
	private void Start()
	{
		var screenSize = GameTools.GetScreenSize();
		
		var size = boxCollider2D.size;
		size.x = 16 * screenSize.x;
		boxCollider2D.size = size;
		
		Vector2 position = Vector2.one;
		position.x = 0;
		position.y = -screenSize.y - boxCollider2D.size.y / 2;
		
		transform.position = position;
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		Destroy(collider.gameObject);
	}
}
