using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Layout : MonoBehaviour
{
	string SelectedNumber;
	public Button BetButton;
	public Text BetText;
    
    public void SetNumber(Button LayoutNumber)
    {
        SelectedNumber = LayoutNumber.name;
		BetText.text = "Bet on " + SelectedNumber + "?";
		BetButton.interactable = true;
    }
	
	public string GetNumber()
	{
		return SelectedNumber;
	}
}
