using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateDeathDisplays : MonoBehaviour {

	int targetTreasure;
	int treasure;
	int totalCoins;
	int targetCoinsEarned;
	int coinsEarned;
	bool allUpdated;
	float timeCounter;
	const float MaxTime = 0.01f;

	public void SetUpValues()
	{
		targetTreasure = GameManager.Treasure;
		treasure = 0;
		targetCoinsEarned = 0;
		coinsEarned = GameManager.Coins;
		totalCoins = GameManager.TotalCoins - coinsEarned;
		allUpdated = false;
		timeCounter = 0;
	}

	public void  UpdateDisplay()
	{
		if (!allUpdated) {
			timeCounter += Time.deltaTime;
			if (timeCounter > MaxTime) {
				bool treasureUpgraded = false, coinsUpgraded = false;
				if (treasure < targetTreasure) {
					treasure++;
				}
				else 
					treasureUpgraded = true;

				if (coinsEarned > targetCoinsEarned) {
					coinsEarned--;
					totalCoins++;
				}
				else 
					coinsUpgraded = true;


				GetComponent<Text> ().text = "Total Coins: " + totalCoins + "\n" +
					"Coins Earned: " + coinsEarned + "\n" +
					"\n" +
					"Treasure: " + treasure;

				allUpdated = treasureUpgraded && coinsUpgraded;
				timeCounter = 0;
			}
		}
	}
}
