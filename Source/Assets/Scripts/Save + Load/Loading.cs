﻿using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour
{

    public static void LoadAllInformation()
    {
        GameManager.TotalCoins = PlayerPrefs.GetInt("Total_Coins");
        GameManager.TotalDistance = PlayerPrefs.GetInt("Total_Distance");
        GameManager.MaxDistance = PlayerPrefs.GetInt("Max_Distance");
        GameManager.Deaths = PlayerPrefs.GetInt("Deaths");
        GameManager.Dashes = PlayerPrefs.GetInt("Dashes");
        GameManager.Jumps = PlayerPrefs.GetInt("Jumps");
        GameManager.Kills = PlayerPrefs.GetInt("Kills");

        //AchievementManager.reachedCastle = (bool) PlayerPrefs.GetInt ("Castle");
        //AchievementManager.reachedForest = (bool) PlayerPrefs.GetInt ("Forest");
        //AchievementManager.reachedCaves =  (bool) PlayerPrefs.GetInt ("Cave");

        Debug.Log("Loaded");
    }
}