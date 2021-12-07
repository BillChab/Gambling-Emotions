using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    // UI attributes
	public Blackboard Blackboard;
	public Layout Layout;
	
	// Stream attribute
	public Streamer Streamer;
	
	// Class methods
	public void Play()
	{
		Blackboard.StartTimer();
		Streamer.PushSample("Round " + Blackboard.GetRound());
		Streamer.PushSample("Initial budget: " + Blackboard.GetBudget() + "$");
		gameObject.SetActive(false);
		transform.Find("Menu").gameObject.SetActive(false);
		transform.Find("Bettor").gameObject.SetActive(true);
	}
	
	public void Ready()
	{
		gameObject.SetActive(false);
		
		Blackboard.UpdateBudget(-1);
		Blackboard.SetBet("Bet 5$ on " + Layout.GetNumber());
		
		Streamer.PushSample("Player bet 5$ on " + Layout.GetNumber());
		Streamer.PushSample("Budget post bet: " + Blackboard.GetBudget() + "$");
	}
	
	public void Back()
	{
		gameObject.SetActive(false);
		Streamer.PushSample("Player changed their mind");
	}
}
