using UnityEngine;
using System.Collections;

public class AchievementManager : MonoBehaviour {
	public static int ACHIEVEMENT1_DISTANCE = 1000; //achievement 1
	public static int ACHIEVEMENT2_DISTANCE = 10000; //achievement 2
	public static int MAX_KILLS = 10; //achievement 3
	public static int MAX_DASHES = 50; //achievement 4
	public static int MAX_JUMPS = 50; //achievement 5
	public static bool reachedCaves = false; //achievement 6
	public static bool reachedForest = false; //achievement 7
	public static bool reachedCastle = true; //achievement 8
	public static int MAX_COINS = 100; //achievement 9
	public static int MAX_DEATHS = 10; //achievement 10
	
	static string[] achievementNames = new string[10] {
		"1000m",
		"10,000m",
		"Killer",
		"Dasher",
		"Jump!",
		"Caves",
		"Forest",
		"Castle",
		"Money!",
		":(" };
	
	// Use this for initialization
	void Start () {
		float progressPercentage;
		AchievementScript[] scripts = GetComponentsInChildren<AchievementScript> ();
		
		//achievement 1 
		progressPercentage = Mathf.Clamp (((float)GameManager.TotalDistance / ACHIEVEMENT1_DISTANCE), 0, 1);
		scripts[0].SetProgress (progressPercentage);
		
		//achievement 2
		progressPercentage = Mathf.Clamp (((float)GameManager.TotalDistance / ACHIEVEMENT2_DISTANCE), 0, 1);
		scripts[1].SetProgress (progressPercentage);
		
		//achievement 3
		progressPercentage = Mathf.Clamp (((float)GameManager.Kills / MAX_KILLS), 0, 1);
		scripts[2].SetProgress (progressPercentage);
		
		//achievement 4
		progressPercentage = Mathf.Clamp (((float)GameManager.Dashes / MAX_DASHES), 0, 1);
		scripts[3].SetProgress (progressPercentage);
		
		//achievement 5
		progressPercentage = Mathf.Clamp (((float)GameManager.Jumps / MAX_JUMPS), 0, 1);
		scripts[4].SetProgress (progressPercentage);
		
		//achievement 6
		if ( reachedCaves)
		scripts[5].SetProgress (1);
		
		//achievement 7
		if ( reachedForest)
		scripts[6].SetProgress (1);
		
		//achievement 8
		if ( reachedCastle)
			scripts[7].SetProgress (1);	
		
		//achievement 9
		progressPercentage = Mathf.Clamp (((float)GameManager.TotalCoins / MAX_COINS), 0, 1);
		scripts[8].SetProgress (progressPercentage);
		
		//achievement 10
		progressPercentage = Mathf.Clamp (((float)GameManager.Deaths / MAX_DEATHS), 0, 1);
		scripts[9].SetProgress (progressPercentage);
	}
	
	public static string[] AchievementNames
	{
		get { return achievementNames; }
	}
}
