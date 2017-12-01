using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	//INGAME VARS
	static int coins = 0;
	static byte lives = 0;
	static int distance = 0;
	static byte spellEquiped = 0;
	static int treasure = 0;
	static byte mana = 0, maxMana = 100, smallestManaNeeded = 0;
	float manaRegenTimer = 0, livesRegenTimer = 0;
	const byte MAX_MANA_TIMER = 2, MAX_LIVE_TIMER = 15;
	static bool invincable = false;
	float invincableTimer = 0;
	float invincableMaxTimer = 3f;
	
	public GameObject deathPanel;
	public GameObject saveMePanel;
	public UpdateDeathDisplays deathDisplayScript;
	static bool displayPanel = false;
	bool updateDisplayNumbers = false;

	//TRACKING VARS
	static int kills = 0;
	static int jumpes = 0;
	static int dashes = 0;
	static int deaths = 0;
	static int totalCoins = 0;
	static int maxDistance = 0;
	static int totalDistance = 0;


	
	void Start () {
		if (SpellEquiped == Const_Script.Fireball)
			smallestManaNeeded = 25;
		else if (SpellEquiped == Const_Script.IceCube)
			smallestManaNeeded = 20;
		else
			smallestManaNeeded = 15;

		lives = 3;
		distance = 0;
		coins = 0;

		mana = maxMana;
	}
	
	void Update () {
		if (lives > 0) {
			ManaRegen ();
			LivesRegen ();
		}

		if (displayPanel == true) {
			displayPanel = false;
			updateDisplayNumbers = true;
			GameObject.Find("pauseButton").SetActive(false);
			if (totalCoins > 99)  //100 coins to purchase
			{
				saveMePanel.gameObject.SetActive(true);
				GameObject.Find("totalCoinsText").GetComponent<Text>().text = totalCoins.ToString();				
			}
			else 
			{
				GetComponent<AudioSource>().Play();
				deathPanel.SetActive (true);
				deathDisplayScript.SetUpValues();
			}
		}
		if (updateDisplayNumbers) {			
			deathDisplayScript.UpdateDisplay();
		}
		if (invincable) 
		{
			invincableTimer += Time.deltaTime;
			if (invincableTimer > invincableMaxTimer)
			{
				invincable = false;
				invincableTimer = 0;
			}
		}
	}
	public void ManaRegen()
	{
		if (mana < maxMana)
		{
			manaRegenTimer += Time.deltaTime;
			if (manaRegenTimer >= MAX_MANA_TIMER)
			{
				mana += 3;
				manaRegenTimer = 0;
			}
		}
	}

	public void LivesRegen()
	{
		if (lives < 3)
		{
			livesRegenTimer += Time.deltaTime;
			if (livesRegenTimer >= MAX_LIVE_TIMER)
			{
				lives++;
				livesRegenTimer = 0;
			}
		}
	}

	public static void TakeDamage(bool kill)
	{

		if (kill == true) {
			deaths++;

			lives = 0;

			GetMaxValues ();
			Saving.SaveAllInformation ();

			displayPanel = true;
		} 
		else
			lives--;

	}

	public static void AddCoins(bool treasureCheck)
	{
		if (treasureCheck == false)
			coins++;
		else {
			coins += Random.Range (15, 31);
			treasure++;
		}
	}

	public static void GetMaxValues()
	{
		totalCoins += coins;
		totalDistance += distance;
		if (distance > maxDistance)
			maxDistance = distance;
	}

	public static void ReduceMana()
	{
		mana -= smallestManaNeeded;
	}

	public static bool CheckMana()
	{
		if (mana > smallestManaNeeded)
			return true;
		else
			return false;
	}


	public static byte Mana
	{
		get { return mana;}
		set { mana = value;}
	}
	public static byte SpellEquiped
	{
		get { return spellEquiped;}
		set { spellEquiped = value;}
	}
	public static int Distance
	{
		get { return distance;}
		set { distance = value;}
	}
	public static byte Lives
	{
		get { return lives;}
		set { lives = value; } 
	}
	public static byte SmallestManaNeeded
	{
		get { return smallestManaNeeded;}
	}
	public static int Coins
	{
		get { return coins;}
	}


	public static int Dashes
	{
		get { return dashes;}
		set { dashes = value;}
	}
	public static int Jumps
	{
		get { return jumpes;}
		set { jumpes = value;}
	}
	public static int Deaths
	{
		get { return deaths;}
		set { deaths = value;}
	}
	public static int Treasure
	{
		get { return treasure;}
		set { treasure = value;}
	}
	public static int Kills
	{
		get { return kills;}
		set { kills = value;}
	}
	public static bool Invincable
	{
		get { return invincable;}
		set { invincable = value;}
	}
	public static int MaxDistance
	{
		get { return maxDistance;}
		set { maxDistance = value;}
	}
	public static int TotalCoins
	{
		get { return totalCoins;}
		set { totalCoins = value;}
	}
	public static int TotalDistance
	{
		get { return totalDistance;}
		set { totalDistance = value;}
	}
}