using UnityEngine;
using System.Collections;


public enum EnviromentType { Castle, Forest, Cave };

public class EnviromentManager : MonoBehaviour {
	
	byte castlesCount , forestCount, cavesCount;
	byte currentWallsCount;
	const byte MaxCastles = 3, MinCastles = 4;
	const byte MaxForest = 4, MinForest = 6;
	const byte MaxCaves = 1, MinCaves = 2;
	EnviromentType currentEnviroment;

	void Awake() {
		GetRandomWalls ();
		currentEnviroment = EnviromentType.Castle;
		currentWallsCount = castlesCount;
	}

	void GetRandomWalls() {
		castlesCount = (byte)Random.Range(MinCastles, MaxCastles + 1);
		forestCount = (byte)Random.Range(MinForest, MaxForest + 1);
		cavesCount = (byte)Random.Range(MinCaves, MaxCaves + 1);
	}

	public EnviromentType Enviroment
	{
		get { return currentEnviroment; }
		set { currentEnviroment = value; } 
	}

	public byte WallsCount
	{
		get { return currentWallsCount; }
		set { currentWallsCount = value; } 
	}

	public void CheckWallCount() {
		if (currentWallsCount == 0) {
			GetRandomWalls ();
			currentEnviroment = (EnviromentType)Random.Range(0,3);
			if (currentEnviroment == EnviromentType.Castle)
				currentWallsCount = castlesCount;
			if (currentEnviroment == EnviromentType.Forest)
			{
				currentWallsCount = forestCount;
				AchievementManager.reachedForest = true;
			}
			else
			{
				currentWallsCount = cavesCount;
				AchievementManager.reachedCaves = true;
			}
		}
	}
}