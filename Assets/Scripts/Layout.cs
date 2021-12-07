using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Layout : MonoBehaviour
{
	// Class attribute
	string SelectedNumber;
	
	// UI attributes
	public Blackboard Blackboard;
	public Buttons Buttons;
	
	// Stream attribute
	public Streamer Streamer;
    
	// Class methods
	public string GetNumber() { return SelectedNumber; }
    public void SetNumber(Button LayoutNumber)
    {
        SelectedNumber = LayoutNumber.name;
		Blackboard.SetBet("Bet on " + SelectedNumber + "?");
		
		Streamer.PushSample(SelectedNumber + " selected");
		
		Buttons.transform.Find("Bet").GetComponent<Button>().interactable = true;
    }
}
