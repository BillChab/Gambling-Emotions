using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
	// Wheel variables
	int Speed;
	float Rotation, SpinTime;
	bool Spinning;
	string Info;
	
	// Interface variables
	public AudioSource Applause, Thud;
	public Bettor Bettor;
	public Button Reset, BetButton;
	public Layout Layout;
	public Text BudgetText, Outcome;
	
	// Timer variables
	float Cooldown;
	bool Ticking;
	
	// Outcome variables
	int Slot;
	string Bet;
	bool Win;

	public void Start()
	{
		transform.eulerAngles = new Vector3 (0, 0, 0);
		Spinning = false;
		Ticking = false;
		Win = false;
	}
	
	public void StartSpinning()
	{
		BetButton.enabled = false;
		Layout.transform.GetChild(8).gameObject.SetActive(true);
		
		Speed = Random.Range(530, 690);
		SpinTime = Random.Range(5.3f, 6.9f);
		Spinning = true;
		Cooldown = 20; // Possibly 60 or 90 sec.
		
		Info = "Wheel spinning at " + Speed + "°/sec. for " + SpinTime + " sec.";
		Debug.Log(Info);
	}

	void Update() 
	{
		if (Spinning)
		{
			transform.Rotate (0, 0, -Speed * Time.deltaTime);
			SpinTime -= Time.deltaTime;
			if (SpinTime <= 0 && Speed > 0)
			{
				Speed--;
				if (Speed == 0)
				{
					Spinning = false;
					Rotation = transform.localRotation.eulerAngles.z;
					
					if (Rotation < 0)
						Rotation += 360;
					
					if (Rotation >= 13140/37 && Rotation <= 180/37)
						Slot = 0;
					else if (Rotation >= 180/37 && Rotation <= 540/37)
						Slot = 32;
					else if (Rotation >= 540/37 && Rotation <= 900/37)
						Slot = 15;
					else if (Rotation >= 900/37 && Rotation <= 1260/37)
						Slot = 19;
					else if (Rotation >= 1260/37 && Rotation <= 1620/37)
						Slot = 4;
					else if (Rotation >= 1620/37 && Rotation <= 1980/37)
						Slot = 21;
					else if (Rotation >= 1980/37 && Rotation <= 2340/37)
						Slot = 2;
					else if (Rotation >= 2340/37 && Rotation <= 2700/37)
						Slot = 25;
					else if (Rotation >= 2700/37 && Rotation <= 3060/37)
						Slot = 17;
					else if (Rotation >= 3060/37 && Rotation <= 3420/37)
						Slot = 34;
					else if (Rotation >= 3420/37 && Rotation <= 3780/37)
						Slot = 7;
					else if (Rotation >= 3780/37 && Rotation <= 4140/37)
						Slot = 27;
					else if (Rotation >= 4140/37 && Rotation <= 4500/37)
						Slot = 13;
					else if (Rotation >= 4500/37 && Rotation <= 4860/37)
						Slot = 36;
					else if (Rotation >= 4860/37 && Rotation <= 5220/37)
						Slot = 11;
					else if (Rotation >= 5220/37 && Rotation <= 5580/37)
						Slot = 30;
					else if (Rotation >= 5580/37 && Rotation <= 5940/37)
						Slot = 8;
					else if (Rotation >= 5940/37 && Rotation <= 6300/37)
						Slot = 23;
					else if (Rotation >= 6300/37 && Rotation <= 6660/37)
						Slot = 10;
					else if (Rotation >= 6660/37 && Rotation <= 7020/37)
						Slot = 5;
					else if (Rotation >= 7020/37 && Rotation <= 7380/37)
						Slot = 24;
					else if (Rotation >= 7380/37 && Rotation <= 7740/37)
						Slot = 16;
					else if (Rotation >= 7740/37 && Rotation <= 8100/37)
						Slot = 33;
					else if (Rotation >= 8100/37 && Rotation <= 8460/37)
						Slot = 1;
					else if (Rotation >= 8460/37 && Rotation <= 8820/37)
						Slot = 20;
					else if (Rotation >= 8820/37 && Rotation <= 9180/37)
						Slot = 14;
					else if (Rotation >= 9180/37 && Rotation <= 9540/37)
						Slot = 31;
					else if (Rotation >= 9540/37 && Rotation <= 9900/37)
						Slot = 9;
					else if (Rotation >= 9900/37 && Rotation <= 10260/37)
						Slot = 22;
					else if (Rotation >= 10260/37 && Rotation <= 10620/37)
						Slot = 18;
					else if (Rotation >= 10620/37 && Rotation <= 10980/37)
						Slot = 29;
					else if (Rotation >= 10980/37 && Rotation <= 11340/37)
						Slot = 7;
					else if (Rotation >= 11340/37 && Rotation <= 11700/37)
						Slot = 28;
					else if (Rotation >= 11700/37 && Rotation <= 12060/37)
						Slot = 12;
					else if (Rotation >= 12060/37 && Rotation <= 12420/37)
						Slot = 35;
					else if (Rotation >= 12420/37 && Rotation <= 12780/37)
						Slot = 3;
					else if (Rotation >= 12780/37 && Rotation <= 13140/37)
						Slot = 26;
					Debug.Log("Slot " + Slot);
					
					Bet = Layout.GetNumber();
					switch (Slot)
					{
						// 0 DONE
						case 0:
							if (Bet.Equals("0"))
								Victory(35);
							else if (Bet.Contains("Trio") ^ Bet.Equals("Basket"))
								Victory(8);
							break;
							
						// 32 DONE
						case 32:
							if (Bet.Equals("32"))
								Victory(35);
							else if (Bet.Contains("32"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Red") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
							
						// 15 DONE
						case 15:
							if (Bet.Equals("15"))
								Victory(35);
							else if (Bet.Contains("15"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 3") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Black") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 19 DONE
						case 19:
							if (Bet.Equals("19"))
								Victory(35);
							else if (Bet.Contains("19"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Red") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 4 DONE
						case 4:
							if (Bet.Equals("4"))
								Victory(35);
							else if (Bet.Contains("4"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Black") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 21 DONE
						case 21:
							if (Bet.Equals("21"))
								Victory(35);
							else if (Bet.Contains("21"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 3") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Red") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 2 DONE
						case 2:
							if (Bet.Equals("2"))
								Victory(35);
							else if (Bet.Contains("2"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Contains("Trio") ^ Bet.Equals("Basket"))
								Victory(8);
							else if (Bet.Equals("Col 2") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Black") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 25 DONE
						case 25:
							if (Bet.Equals("25"))
								Victory(35);
							else if (Bet.Contains("25"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Red") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 17 DONE
						case 17:
							if (Bet.Equals("17"))
								Victory(35);
							else if (Bet.Contains("17"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Black") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 34 DONE
						case 34:
							if (Bet.Equals("34"))
								Victory(35);
							else if (Bet.Contains("34"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Red") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 6 DONE
						case 6:
							if (Bet.Equals("6"))
								Victory(35);
							else if (Bet.Contains("6"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 3") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Black") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 27 DONE
						case 27:
							if (Bet.Equals("27"))
								Victory(35);
							else if (Bet.Contains("27"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 3") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Red") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 13 DONE
						case 13:
							if (Bet.Equals("13"))
								Victory(35);
							else if (Bet.Contains("13"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Black") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 36 DONE
						case 36:
							if (Bet.Equals("36"))
								Victory(35);
							else if (Bet.Contains("36"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Red") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 11 DONE
						case 11:
							if (Bet.Equals("11"))
								Victory(35);
							else if (Bet.Contains("11"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Black") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 30 DONE
						case 30:
							if (Bet.Equals("30"))
								Victory(35);
							else if (Bet.Contains("30"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 3") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Red") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 8 DONE
						case 8:
							if (Bet.Equals("8"))
								Victory(35);
							else if (Bet.Contains("8"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Black") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 23 DONE
						case 23:
							if (Bet.Equals("23"))
								Victory(35);
							else if (Bet.Contains("23"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Red") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 10 DONE
						case 10:
							if (Bet.Equals("10"))
								Victory(35);
							else if (Bet.Contains("10"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Black") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 5 DONE
						case 5:
							if (Bet.Equals("5"))
								Victory(35);
							else if (Bet.Contains("5"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Red") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 24 DONE
						case 24:
							if (Bet.Equals("24"))
								Victory(35);
							else if (Bet.Contains("24"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 3") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Black") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 16 DONE
						case 16:
							if (Bet.Equals("16"))
								Victory(35);
							else if (Bet.Contains("16"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Red") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 33 DONE
						case 33:
							if (Bet.Equals("33"))
								Victory(35);
							else if (Bet.Contains("33"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 3") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Black") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 1 DONE
						case 1:
							if (Bet.Equals("1"))
								Victory(35);
							else if (Bet.Contains("1"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Trio w/ 1") ^ Bet.Equals("Basket"))
								Victory(8);
							else if (Bet.Equals("Col 1") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Red") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 20
						case 20:
							if (Bet.Equals("20"))
								Victory(35);
							else if (Bet.Contains("20"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Black") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 14
						case 14:
							if (Bet.Equals("14"))
								Victory(35);
							else if (Bet.Contains("14"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Red") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 31
						case 31:
							if (Bet.Equals("31"))
								Victory(35);
							else if (Bet.Contains("31"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Black") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 9
						case 9:
							if (Bet.Equals("9"))
								Victory(35);
							else if (Bet.Contains("9"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 3") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Red") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 22
						case 22:
							if (Bet.Equals("22"))
								Victory(35);
							else if (Bet.Contains("22"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Black") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 18
						case 18:
							if (Bet.Equals("18"))
								Victory(35);
							else if (Bet.Contains("18"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 3") ^ Bet.Equals("2nd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Red") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 29
						case 29:
							if (Bet.Equals("29"))
								Victory(35);
							else if (Bet.Contains("29"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Black") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 7
						case 7:
							if (Bet.Equals("7"))
								Victory(35);
							else if (Bet.Contains("7"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Red") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 28
						case 28:
							if (Bet.Equals("28"))
								Victory(35);
							else if (Bet.Contains("28"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 1") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Black") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 12
						case 12:
							if (Bet.Equals("12"))
								Victory(35);
							else if (Bet.Contains("12"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 3") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Red") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 35
						case 35:
							if (Bet.Equals("35"))
								Victory(35);
							else if (Bet.Contains("35"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Black") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
						
						// 3 DONE
						case 3:
							if (Bet.Equals("3"))
								Victory(35);
							else if (Bet.Contains("3"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Trio w/ 3") ^ Bet.Equals("Basket"))
								Victory(8);
							else if (Bet.Equals("Col 3") ^ Bet.Equals("1st 12"))
								Victory(2);
							else if (Bet.Equals("Odd") ^ Bet.Equals("Red") ^ Bet.Equals("1-18"))
								Victory(1);
							break;
						
						// 26 DONE
						case 26:
							if (Bet.Equals("26"))
								Victory(35);
							else if (Bet.Contains("26"))
							{
								if (Bet.Contains("Split"))
									Victory(17);
								else if (Bet.Contains("Street"))
									Victory(11);
								else if (Bet.Contains("Corner"))
									Victory(8);
								else if (Bet.Contains("Six"))
									Victory(5);
							}
							else if (Bet.Equals("Col 2") ^ Bet.Equals("3rd 12"))
								Victory(2);
							else if (Bet.Equals("Even") ^ Bet.Equals("Black") ^ Bet.Equals("19-36"))
								Victory(1);
							break;
					}
					
					if (!Win)
					{
						Thud.Play();
						Outcome.text = "You lose...";
						Debug.Log ("Loss");
					}
					
					BetButton.gameObject.SetActive(false);
					Reset.gameObject.SetActive(true);
					Ticking = true;
				}
			}
		}
		else if (Ticking)
		{
			if (Cooldown > 0)
			{
				Cooldown -= Time.deltaTime;
				Reset.GetComponentInChildren<Text>().text = string.Format("{0:00}", Mathf.FloorToInt(Cooldown + 1));
			}
			else
			{
				Reset.GetComponentInChildren<Text>().text = "Reset";
				Reset.interactable = true;
				Cooldown = 0;
				Ticking = false;
			}
		}
	}
	
	void Victory(int Payout)
	{
		Applause.Play();
		BudgetText.text = "Budget: " + Bettor.IncreaseBudget(Payout) + "$";
		Outcome.text = "You win " + 5*Payout + "$!";
		Win = true;
		Debug.Log("Win");
	}
}
