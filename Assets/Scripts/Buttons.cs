using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
	int Round = 1;
	public Button BetButton, ResetButton;
    public Image Popup;
	public Layout Layout;
	public Text RoundText, BetText, OutcomeText;
	public Wheel Wheel;
	
	public void Bet()
	{
		Popup.gameObject.SetActive (true);
	}
	
	public void Reset()
	{
		Wheel.Start();
		Layout.transform.GetChild(8).gameObject.SetActive(false);
		
		RoundText.text = "Round " + (++Round);
		BetText.text = "";
		OutcomeText.text = "";
		
		BetButton.enabled = true;
		BetButton.interactable = false;
		BetButton.gameObject.SetActive(true);
		ResetButton.interactable = false;
		ResetButton.gameObject.SetActive(false);
	}
}
