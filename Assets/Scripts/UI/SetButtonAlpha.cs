using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SetButtonAlpha : MonoBehaviour
{
	private void Start()
	{
		var image = GetComponent<Image>();
		
		image.alphaHitTestMinimumThreshold = 1f;
	}
}
