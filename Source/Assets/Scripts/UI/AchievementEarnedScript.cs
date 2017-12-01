using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementEarnedScript : MonoBehaviour {

	public Text textDisplay;
	bool showAchievement;
	string stringToShow;
	string lastStringShown;
	static bool[] notDisplayedAlready = new bool[10] { //save and load
		true,
		true,
		true,
		true,
		true,
		true,
		true,
		true,
		true,
		true };
	int animationHash = Animator.StringToHash("show");

	void Update () {
		if (GetComponentInParent<RectTransform>().position.x > Screen.width) {
			bool achievementEarned = false;
			if ( (float)GameManager.Distance / AchievementManager.ACHIEVEMENT1_DISTANCE >= 1 && notDisplayedAlready[0]) {
				stringToShow = AchievementManager.AchievementNames[0];
				notDisplayedAlready[0] = false;
				achievementEarned = true;
			}
			else if ( (float)GameManager.Distance / AchievementManager.ACHIEVEMENT2_DISTANCE >= 1 && notDisplayedAlready[1]) {
				stringToShow = AchievementManager.AchievementNames[1];		
				notDisplayedAlready[1] = false;
				achievementEarned = true;
			}
			else if ( (float)GameManager.Kills / AchievementManager.MAX_KILLS >= 1 && notDisplayedAlready[2]){
				stringToShow = AchievementManager.AchievementNames[2];	
				notDisplayedAlready[2] = false;
				achievementEarned = true;
			}	
			else if ( (float)GameManager.Dashes / AchievementManager.MAX_DASHES >= 1  && notDisplayedAlready[3]) {
				stringToShow = AchievementManager.AchievementNames[3];	
				notDisplayedAlready[3] = false;
				achievementEarned = true;
			}	
			else if ( (float)GameManager.Jumps / AchievementManager.MAX_JUMPS >= 1 && notDisplayedAlready[4]) {
				stringToShow = AchievementManager.AchievementNames[4];
				notDisplayedAlready[4] = false;
				achievementEarned = true;
			}			
			else if ( AchievementManager.reachedCaves && notDisplayedAlready[5]) {
				stringToShow = AchievementManager.AchievementNames[5];
				notDisplayedAlready[5] = false;
				notDisplayedAlready[6] = true;
				notDisplayedAlready[7] = true;
				achievementEarned = true;
			}
			else if ( AchievementManager.reachedForest && notDisplayedAlready[6]) {
				stringToShow = AchievementManager.AchievementNames[6];	
				notDisplayedAlready[6] = false;
				notDisplayedAlready[5] = true;
				notDisplayedAlready[7] = true;
				achievementEarned = true;
			}
			else if ( AchievementManager.reachedCastle && notDisplayedAlready[7]) {
				stringToShow = AchievementManager.AchievementNames[7];
				notDisplayedAlready[7] = false;
				notDisplayedAlready[6] = true;
				notDisplayedAlready[5] = true;
				achievementEarned = true;
			}
			else if ( (float)GameManager.Coins / AchievementManager.MAX_COINS >= 1&& notDisplayedAlready[8]) {
				stringToShow = AchievementManager.AchievementNames[8];
				notDisplayedAlready[8] = false;
				achievementEarned = true;
			}
			else if ( (float)GameManager.Deaths / AchievementManager.MAX_DEATHS >= 1&& notDisplayedAlready[9]) {
				stringToShow = AchievementManager.AchievementNames[9];
				notDisplayedAlready[9] = false;
				achievementEarned = true;
			}
			if ( lastStringShown != stringToShow && achievementEarned)
			{
				GetComponent<Text>().text = stringToShow;
				GetComponentInParent<Animator>().SetTrigger(animationHash);
			}

			lastStringShown = stringToShow;		
		}
	}

	public bool[] NotDisplayedAlready
	{
		get { return notDisplayedAlready; }
		set { notDisplayedAlready = value; }
	}
}

