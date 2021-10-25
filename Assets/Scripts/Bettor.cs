using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bettor : MonoBehaviour
{
	float Budget = 100;
	public Button BetButton;
	public Image Popup;
	public Layout Layout;
	public Text BudgetText, BetText;

	public void SetBet()
	{
		Popup.gameObject.SetActive (false);
		
		Budget -= 5;
		BudgetText.text = "Budget: " + Budget + "$";
		BetText.text = "Bet 5$ on " + Layout.GetNumber();
		Debug.Log ("bet 5$ on " + Layout.GetNumber());
	}
	
	public void Back()
	{
		Popup.gameObject.SetActive(false);
	}
	
	public float IncreaseBudget(int Multiplier)
	{
		Budget += 5 * Multiplier;
		return Budget;
	}
}
