
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesController : MonoBehaviour
{
	[SerializeField] private List<Image> lifesImages;
	[SerializeField] private List<Image> gravityImages;
	[SerializeField] private Button lifesPurchase;
	[SerializeField] private Button gravityPurchase;
	[SerializeField] private TMP_Text lifesButtonCaption;
	[SerializeField] private TMP_Text gravityButtonCaption;
	[SerializeField] private TMP_Text coins;
	
	private void Start()
	{
		Refresh();
	}
	
	public void Refresh()
	{
		foreach(var image in lifesImages.Concat(gravityImages).ToList())
		{
			image.enabled = false;
		}	
		
		for (int i = 0; i < GameOptions.Lifes; i++)
		{
			lifesImages[i].enabled = true;
		}
		
		for (int i = 0; i < GameOptions.Gravity; i++)
		{
			gravityImages[i].enabled = true;
		}
		
		if (GameOptions.Gold >= 100 && GameOptions.Lifes <= 3)
		{
			lifesPurchase.interactable = true;
			SetTextAlpha(lifesButtonCaption, 1f);
		}
		else
		{
			lifesPurchase.interactable = false;
			SetTextAlpha(lifesButtonCaption, 0.5f);
		}
		
		if (GameOptions.Gold >= 45 && GameOptions.Gravity <= 3)
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
		GameOptions.Lifes++;
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
