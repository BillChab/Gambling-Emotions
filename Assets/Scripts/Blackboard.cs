using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Blackboard : MonoBehaviour
{
	// Class attributes
	int Round = 1;
	float Budget = 100;
	string Bet = "", Outcome = "";
	
	int[] Ratio = new int[2];
	Stopwatch Stopwatch = new Stopwatch();
	
	// Class methods
	public int GetRound() { return Round; }
	public void NextRound() { Round++; }
	
	public float GetBudget() { return Budget; }
	public float UpdateBudget(int Multiplier)
	{
		Budget += 5 * Multiplier;
		return Budget;
	}
	
	public void SetBet(string Bet) { this.Bet = Bet; }
	public void SetOutcome(string Outcome) { this.Outcome = Outcome; }
	
	public string GetRatio() { return Ratio[0] + "-" + Ratio[1]; }
	public void SetRatio(bool Win)
	{
		if (Win) Ratio[0]++;
		else Ratio[1]++;
	}
	
	public void StartTimer() { Stopwatch.Start(); }
	public void StopTimer() { Stopwatch.Stop(); }
	public string DisplayRuntime()
	{
		TimeSpan TimeSpan = Stopwatch.Elapsed;
		return TimeSpan.Hours + " hr., " + TimeSpan.Minutes + " min., " + TimeSpan.Seconds + " sec., and " + TimeSpan.Milliseconds/10 + " msec.";
	}
		
	void Update()
	{
		transform.Find("Round").GetComponent<Text>().text = "Round " + Round;
		transform.Find("Budget").GetComponent<Text>().text = "Budget: " + Budget + "$";
		transform.Find("Bet").GetComponent<Text>().text = Bet;
		transform.Find("Outcome").GetComponent<Text>().text = Outcome;
	}
}
