using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchController : MonoBehaviour
{
	[SerializeField] private PaletteController paletteController;
	[SerializeField] private GameObject touchEffect;
	
	private void Awake()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}
	
	public void Enable()
	{
		Touch.onFingerDown += OnFingerDown;
	}
	
	public void Disable()
	{
		Touch.onFingerDown -= OnFingerDown;
	}
	
	private void OnFingerDown(Finger finger)
	{
		var worldPos = finger.screenPosition.ScreenToWorldPosition();
		
		RaycastHit2D raycastHit2D = Physics2D.Raycast(worldPos, Vector3.forward);
		if (!raycastHit2D) return;
		
		if (raycastHit2D.collider.TryGetComponent<PyramidPiece>(out PyramidPiece piece))
		{
			if (piece.currentStaticColor != Color.white) return;
			
			if (paletteController.UseColor())
			{
				piece.PieceColor = paletteController.CurrentColor;
				Instantiate(touchEffect, piece.transform.position, Quaternion.identity, transform);
			}
		}
	}
	
	private void OnDestroy()
	{
		Disable();
	}
}
