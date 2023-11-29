
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesController : MonoBehaviour
{
	[SerializeField] private List<Image> singleColorImages;
	[SerializeField] private List<Image> gravityImages;
	[SerializeField] private Button singleColorPurchase;
	[SerializeField] private Button gravityPurchase;
	[SerializeField] private TMP_Text singleColorButtonCaption;
	[SerializeField] private TMP_Text gravityButtonCaption;
	[SerializeField] private TMP_Text coins;
	
	private void Start()
	{
		Refresh();
	}
	
	public void Refresh()
	{
		foreach(var image in singleColorImages.Concat(gravityImages).ToList())
		{
			image.enabled = false;
		}	
		
		for (int i = 0; i < GameOptions.SingleColorCount; i++)
		{
			singleColorImages[i].enabled = true;
		}
		
		for (int i = 0; i < GameOptions.Gravity; i++)
		{
			gravityImages[i].enabled = true;
		}
		
		if (GameOptions.Gold >= 100 && GameOptions.SingleColorCount < 3)
		{
			singleColorPurchase.interactable = true;
			SetTextAlpha(singleColorButtonCaption, 1f);
		}
		else
		{
			singleColorPurchase.interactable = false;
			SetTextAlpha(singleColorButtonCaption, 0.5f);
		}
		
		if (GameOptions.Gold >= 45 && GameOptions.Gravity < 3)
		{
			gravityPurchase.interactable = true;
			SetTextAlpha(gravityButtonCaption, 1f);
		}
		else
		{
			gravityPurchase.interactable = false;
			SetTextAlpha(gravityButtonCaption, 0.5f);
		}
		
		coins.text = GameOptions.Gold.ToString();
	}
	
	public void PurchaseLifeUpgrade()
	{
		GameOptions.Gold -= 100;
		GameOptions.SingleColorCount++;
		GameOptions.Save();
		Refresh();
	}
	
	public void PurchaseGravityUpgrade()
	{
		GameOptions.Gold -= 45;
		GameOptions.Gravity++;
		GameOptions.Save();
		Refresh();
	}
	
	private void SetTextAlpha(TMP_Text text, float alpha)
	{
		var color = text.color;
		color.a = alpha;
		text.color = color;
	}
  }
