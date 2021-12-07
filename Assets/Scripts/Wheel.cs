using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
	// Wheel attributes
	float Speed, Rotation, SpinTime;
	bool Spinning;
	
	// Timer attributes
	float Cooldown;
	bool Ticking;
	
	// Outcome attributes
	int Slot;
	string Bet;
	bool Win;
	
	// UI attributes
	public AudioSource SoundFX;
	public Blackboard Blackboard;
	public Buttons Buttons;
	public Layout Layout;
	
	// Streamer attributes
	public Streamer Streamer;
	
	// Start is called before the first frame update
	public void Start()
	{
		transform.eulerAngles = new Vector3 (0, 0, 0);
		Spinning = false;
		Ticking = false;
		Win = false;
	}
	
	public void StartSpinning()
	{
		Buttons.transform.Find("Bet").GetComponent<Button>().enabled = false;
		Layout.transform.Find("Switch").gameObject.SetActive(true);
		
		Speed = Random.Range(250, 500);
		SpinTime = Random.Range(5f, 10f);
		Spinning = true;
		Cooldown = 5;
		
		Streamer.PushSample("Wheel spinning at " + Speed + "°/sec. for " + SpinTime + " sec.");
	}
	
	// Update is called every frame
	void Update() 
	{
		if (Spinning)
		{
			transform.Rotate(0, 0, -Speed * Time.deltaTime);
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
					
					if ((Rotation > 13140/37 && Rotation < 360) || (Rotation >= 0 && Rotation <= 180/37))
						Slot = 0;
					else if (Rotation > 180/37 && Rotation <= 540/37)
						Slot = 32;
					else if (Rotation > 540/37 && Rotation <= 900/37)
						Slot = 15;
					else if (Rotation > 900/37 && Rotation <= 1260/37)
						Slot = 19;
					else if (Rotation > 1260/37 && Rotation <= 1620/37)
						Slot = 4;
					else if (Rotation > 1620/37 && Rotation <= 1980/37)
						Slot = 21;
					else if (Rotation > 1980/37 && Rotation <= 2340/37)
						Slot = 2;
					else if (Rotation > 2340/37 && Rotation <= 2700/37)
						Slot = 25;
					else if (Rotation > 2700/37 && Rotation <= 3060/37)
						Slot = 17;
					else if (Rotation > 3060/37 && Rotation <= 3420/37)
						Slot = 34;
					else if (Rotation > 3420/37 && Rotation <= 3780/37)
						Slot = 7;
					else if (Rotation > 3780/37 && Rotation <= 4140/37)
						Slot = 27;
					else if (Rotation > 4140/37 && Rotation <= 4500/37)
						Slot = 13;
					else if (Rotation > 4500/37 && Rotation <= 4860/37)
						Slot = 36;
					else if (Rotation > 4860/37 && Rotation <= 5220/37)
						Slot = 11;
					else if (Rotation > 5220/37 && Rotation <= 5580/37)
						Slot = 30;
					else if (Rotation > 5580/37 && Rotation <= 5940/37)
						Slot = 8;
					else if (Rotation > 5940/37 && Rotation <= 6300/37)
						Slot = 23;
					else if (Rotation > 6300/37 && Rotation <= 180)
						Slot = 10;
					else if (Rotation > 180 && Rotation <= 7020/37)
						Slot = 5;
					else if (Rotation > 7020/37 && Rotation <= 7380/37)
						Slot = 24;
					else if (Rotation > 7380/37 && Rotation <= 7740/37)
						Slot = 16;
					else if (Rotation > 7740/37 && Rotation <= 8100/37)
						Slot = 33;
					else if (Rotation > 8100/37 && Rotation <= 8460/37)
						Slot = 1;
					else if (Rotation > 8460/37 && Rotation <= 8820/37)
						Slot = 20;
					else if (Rotation > 8820/37 && Rotation <= 9180/37)
						Slot = 14;
					else if (Rotation > 9180/37 && Rotation <= 9540/37)
						Slot = 31;
					else if (Rotation > 9540/37 && Rotation <= 9900/37)
						Slot = 9;
					else if (Rotation > 9900/37 && Rotation <= 10260/37)
						Slot = 22;
					else if (Rotation > 10260/37 && Rotation <= 10620/37)
						Slot = 18;
					else if (Rotation > 10620/37 && Rotation <= 10980/37)
						Slot = 29;
					else if (Rotation > 10980/37 && Rotation <= 11340/37)
						Slot = 7;
					else if (Rotation > 11340/37 && Rotation <= 11700/37)
						Slot = 28;
					else if (Rotation > 11700/37 && Rotation <= 12060/37)
						Slot = 12;
					else if (Rotation > 12060/37 && Rotation <= 12420/37)
						Slot = 35;
					else if (Rotation > 12420/37 && Rotation <= 12780/37)
						Slot = 3;
					else if (Rotation > 12780/37 && Rotation <= 13140/37)
						Slot = 26;
					Streamer.PushSample("Landed on slot " + Slot);
					
					Bet = Layout.GetNumber();
					switch (Slot)
					{
						// 0
						case 0:
							if (Bet.Equals("0"))
								Victory(36);
							else if (Bet.Contains("Trio") || Bet.Equals("Basket"))
								Victory(9);
							break;
							
						// 32
						case 32:
							if (Bet.Equals("32"))
								Victory(36);
							else if (Bet.Contains("32"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("28-33 Six") || Bet.Equals("31-36 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Red") || Bet.Equals("19-36"))
								Victory(2);
							break;
							
						// 15
						case 15:
							if (Bet.Equals("15"))
								Victory(36);
							else if (Bet.Contains("15"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("10-15 Six") || Bet.Equals("13-18 Six"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Black") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 19
						case 19:
							if (Bet.Equals("19"))
								Victory(36);
							else if (Bet.Contains("19"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("16-21 Six") || Bet.Equals("19-24"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Red") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 4
						case 4:
							if (Bet.Equals("4"))
								Victory(36);
							else if (Bet.Contains("4"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("1-6 Six") || Bet.Equals("4-9 Six"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Black") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 21
						case 21:
							if (Bet.Equals("21"))
								Victory(36);
							else if (Bet.Contains("21"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("16-21 Six") || Bet.Equals("19-24"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Red") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 2
						case 2:
							if (Bet.Equals("2"))
								Victory(36);
							else if (Bet.Contains("2"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Contains("Trio") || Bet.Equals("Basket"))
								Victory(9);
							else if (Bet.Equals("1-6 Six") || Bet.Equals("4-9 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Black") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 25
						case 25:
							if (Bet.Equals("25"))
								Victory(36);
							else if (Bet.Contains("25"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("25-30 Six") || Bet.Equals("28-33 Six"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Red") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 17
						case 17:
							if (Bet.Equals("17"))
								Victory(36);
							else if (Bet.Contains("17"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Contains("13-18 Six") || Bet.Contains("16-21 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Black") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 34
						case 34:
							if (Bet.Equals("34"))
								Victory(36);
							else if (Bet.Contains("34"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("31-36 Six"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Red") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 6
						case 6:
							if (Bet.Equals("6"))
								Victory(36);
							else if (Bet.Contains("6"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("1-6 Six") || Bet.Equals("4-9 Six"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Black") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 27
						case 27:
							if (Bet.Equals("27"))
								Victory(36);
							else if (Bet.Contains("27"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("22-27 Six") || Bet.Equals("25-30 Six"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Red") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 13
						case 13:
							if (Bet.Equals("13"))
								Victory(36);
							else if (Bet.Contains("13"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("10-15 Six") || Bet.Equals("13-18 Six"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Black") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 36
						case 36:
							if (Bet.Equals("36"))
								Victory(36);
							else if (Bet.Contains("36"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("31-36 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Red") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 11
						case 11:
							if (Bet.Equals("11"))
								Victory(36);
							else if (Bet.Contains("11"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("10-15 Six") || Bet.Equals("13-18 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Black") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 30
						case 30:
							if (Bet.Equals("30"))
								Victory(36);
							else if (Bet.Contains("30"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("28-33 Six") || Bet.Equals("31-36 Six"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Red") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 8
						case 8:
							if (Bet.Equals("8"))
								Victory(36);
							else if (Bet.Contains("8"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("4-9 Six") || Bet.Equals("7-12 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Black") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 23
						case 23:
							if (Bet.Equals("23"))
								Victory(36);
							else if (Bet.Contains("23"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("22-27 Six") || Bet.Equals("25-30 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Red") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 10
						case 10:
							if (Bet.Equals("10"))
								Victory(36);
							else if (Bet.Contains("10"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("7-12 Six") || Bet.Equals("10-15 Six"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Black") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 5
						case 5:
							if (Bet.Equals("5"))
								Victory(36);
							else if (Bet.Contains("5"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("1-6 Six") || Bet.Equals("4-9 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Red") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 24
						case 24:
							if (Bet.Equals("24"))
								Victory(36);
							else if (Bet.Contains("24"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("19-24 Six") || Bet.Equals("22-27 Six"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Black") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 16
						case 16:
							if (Bet.Equals("16"))
								Victory(36);
							else if (Bet.Contains("16"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("13-18 Six") || Bet.Equals("16-21 Six"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Red") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 33
						case 33:
							if (Bet.Equals("33"))
								Victory(36);
							else if (Bet.Contains("33"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("28-33 Six") || Bet.Equals("31-36 Six"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Black") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 1
						case 1:
							if (Bet.Equals("1"))
								Victory(36);
							else if (Bet.Contains("1"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("1-6 Six"))
								Victory(6);
							else if (Bet.Equals("Trio w/ 1") || Bet.Equals("Basket"))
								Victory(9);
							else if (Bet.Equals("Col 1") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Red") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 20
						case 20:
							if (Bet.Equals("20"))
								Victory(36);
							else if (Bet.Contains("20"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("16-21 Six") || Bet.Equals("19-24 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Black") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 14
						case 14:
							if (Bet.Equals("14"))
								Victory(36);
							else if (Bet.Contains("14"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("10-15 Six") || Bet.Equals("13-18 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Red") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 31
						case 31:
							if (Bet.Equals("31"))
								Victory(36);
							else if (Bet.Contains("31"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("31-36 Six"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Black") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 9
						case 9:
							if (Bet.Equals("9"))
								Victory(36);
							else if (Bet.Contains("9"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("4-9 Six") || Bet.Equals("7-12 Six"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Red") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 22
						case 22:
							if (Bet.Equals("22"))
								Victory(36);
							else if (Bet.Contains("22"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("19-24 Six") || Bet.Equals("22-27 Six"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Black") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 18
						case 18:
							if (Bet.Equals("18"))
								Victory(36);
							else if (Bet.Contains("18"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("13-18 Six") || Bet.Equals("16-21 Six"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("2nd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Red") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 29
						case 29:
							if (Bet.Equals("29"))
								Victory(36);
							else if (Bet.Contains("29"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("25-30 Six") || Bet.Equals("28-33 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Black") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 7
						case 7:
							if (Bet.Equals("7"))
								Victory(36);
							else if (Bet.Contains("7"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("4-9 Six") || Bet.Equals("7-12 Six"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Red") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 28
						case 28:
							if (Bet.Equals("28"))
								Victory(36);
							else if (Bet.Contains("28"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("25-30 Six") || Bet.Equals("28-33 Six"))
								Victory(6);
							else if (Bet.Equals("Col 1") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Black") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 12
						case 12:
							if (Bet.Equals("12"))
								Victory(36);
							else if (Bet.Contains("12"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("7-12 Six") || Bet.Equals("10-15 Six"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Red") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 35
						case 35:
							if (Bet.Equals("35"))
								Victory(36);
							else if (Bet.Contains("35"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("31-36 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Black") || Bet.Equals("19-36"))
								Victory(2);
							break;
						
						// 3
						case 3:
							if (Bet.Equals("3"))
								Victory(36);
							else if (Bet.Contains("3"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("Trio w/ 3") || Bet.Equals("Basket"))
								Victory(9);
							else if (Bet.Equals("1-6 Six"))
								Victory(6);
							else if (Bet.Equals("Col 3") || Bet.Equals("1st 12"))
								Victory(3);
							else if (Bet.Equals("Odd") || Bet.Equals("Red") || Bet.Equals("1-18"))
								Victory(2);
							break;
						
						// 26 DONE
						case 26:
							if (Bet.Equals("26"))
								Victory(36);
							else if (Bet.Contains("26"))
							{
								if (Bet.Contains("Split"))
									Victory(18);
								else if (Bet.Contains("Street"))
									Victory(12);
								else if (Bet.Contains("Corner"))
									Victory(9);
							}
							else if (Bet.Equals("22-27 Six") || Bet.Equals("25-30 Six"))
								Victory(6);
							else if (Bet.Equals("Col 2") || Bet.Equals("3rd 12"))
								Victory(3);
							else if (Bet.Equals("Even") || Bet.Equals("Black") || Bet.Equals("19-36"))
								Victory(2);
							break;
					}
					
					Blackboard.SetRatio(Win);
					if (!Win)
					{
						SoundFX.transform.Find("Thud").GetComponent<AudioSource>().Play();
						Blackboard.SetOutcome("#" + Slot + ". You lose...");
						Streamer.PushSample("Player lost");
					}
					
					if (Blackboard.GetBudget() > 0 && Blackboard.GetBudget() < 300)
					{
						Buttons.transform.Find("Bet").gameObject.SetActive(false);
						Buttons.transform.Find("Reset").gameObject.SetActive(true);
						Ticking = true;
						Streamer.PushSample(Cooldown + "-sec. cooldown");
					}
					else
					{
						Buttons.transform.Find("Bet").GetComponent<Button>().interactable = false;
						Streamer.PushSample("Budget limit reached");
					}
				}
			}
		}
		else if (Ticking)
		{
			if (Cooldown > 0)
			{
				Cooldown -= Time.deltaTime;
				Buttons.transform.Find("Reset").GetComponentInChildren<Text>().text = string.Format("{0:00}", Mathf.FloorToInt(Cooldown + 1));
			}
			else
			{
				Buttons.transform.Find("Reset").GetComponentInChildren<Text>().text = "Reset";
				Buttons.transform.Find("Reset").GetComponent<Button>().interactable = true;
				Cooldown = 0;
				Ticking = false;
				Streamer.PushSample("Cooldown over");
			}
		}
	}
	
	void Victory(int Payout)
	{
		SoundFX.transform.Find("Applause").GetComponent<AudioSource>().Play();
		Blackboard.UpdateBudget(Payout);
		Blackboard.SetOutcome("#" + Slot + ". You win " + 5*Payout + "$!");
		Win = true;
		Streamer.PushSample("Player won " + 5*Payout + "$");
		Streamer.PushSample("Budget post win: " + Blackboard.GetBudget() + "$");
	}
}
