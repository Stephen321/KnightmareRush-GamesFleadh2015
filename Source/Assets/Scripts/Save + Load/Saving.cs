using UnityEngine;
using System.Collections;

public class Saving : MonoBehaviour
{

    public static void SaveAllInformation()
    {
        PlayerPrefs.SetInt("Max_Distance", GameManager.MaxDistance);
        PlayerPrefs.SetInt("Total_Coins", GameManager.TotalCoins);
        PlayerPrefs.SetInt("Total_Distance", GameManager.TotalDistance);
        PlayerPrefs.SetInt("Deaths", GameManager.Deaths);
        PlayerPrefs.SetInt("Dashes", GameManager.Dashes);
        PlayerPrefs.SetInt("Jumps", GameManager.Jumps);
        PlayerPrefs.SetInt("Kills", GameManager.Kills);

        //PlayerPrefs.SetInt ("Castle", (int)AchievementManager.reachedCastle);
        //PlayerPrefs.SetInt ("Forest", (int)AchievementManager.reachedForest);
        //PlayerPrefs.SetInt ("Cave", (int)AchievementManager.reachedCaves);

        Debug.Log("Saved");
    }
}