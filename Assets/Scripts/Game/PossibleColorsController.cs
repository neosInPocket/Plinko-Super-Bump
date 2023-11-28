using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Possible Colors")]
public class PossibleColorsController : ScriptableObject
{
	[SerializeField] private List<Color> possibleColors;
	public List<Color> Colors => possibleColors;
}
