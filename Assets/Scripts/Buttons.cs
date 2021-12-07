using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
	// UI attributes
	public Blackboard Blackboard;
	public GUI GUI;
	public Layout Layout;
	public Wheel Wheel;
	
	// Stream attribute
	public Streamer Streamer;
	
	// class methods
	public void Bet()
	{
		GUI.gameObject.SetActive(true);
		Streamer.PushSample("Player ready to bet");
	}
	
	public void Reset()
	{
		// Wheel reset
		Wheel.Start();
		Layout.transform.Find("Switch").gameObject.SetActive(false);
		
		// Blackboard update
		Blackboard.NextRound();
		Blackboard.SetBet("");
		Blackboard.SetOutcome("");
		
		Streamer.PushSample("Round " + Blackboard.GetRound());
		
		// Buttons reset
		transform.Find("Bet").GetComponent<Button>().enabled = true;
		transform.Find("Bet").GetComponent<Button>().interactable = false;
		transform.Find("Bet").gameObject.SetActive(true);
		
		transform.Find("Reset").GetComponent<Button>().interactable = false;
		transform.Find("Reset").gameObject.SetActive(false);
	}
	
	public void Exit()
	{
		Blackboard.StopTimer();
		Streamer.PushSample("Quitting application");
		Streamer.PushSample("Final budget: " + Blackboard.GetBudget() + "$");
		Streamer.PushSample("Rounds played: " + Blackboard.GetRound());
		Streamer.PushSample("Time played: " + Blackboard.DisplayRuntime());
		Streamer.PushSample("Win-Loss Ratio: " + Blackboard.GetRatio());
		Thread.Sleep(500);
		Application.Quit();
	}
}
