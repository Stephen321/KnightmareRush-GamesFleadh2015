using UnityEngine;
using System.Collections;

public class CavesObstacleManager : MonoBehaviour {

	public GameObject fallingRock; //rhino rock tree vines 
	public GameObject skeletion; 
	public GameObject coin; 
	public GameObject chest;
	public GameObject rock;
	public GameObject caveMonster;
	public GameObject boulder;

	const int FALLINGROCK = 0,SKELETON = 1,COIN =2,CHEST = 3,ROCK = 4,CAVEMONSTER = 5,BOULDER = 6, NONE = 7;
	
	int obstacleType;	//number indicating the obstacle to spawn
	
	Vector3 spawnPosition;		//obstacle spawn position
	float wallSectionDivided;	//lenght between each section
	float wallLenghtDivider;	//section to divide the wall by
	float wallPositionZ;		

	void Start () {
	
		wallPositionZ = transform.position.z;	
		int formationRnd = Random.Range(0,4); //Random number indicating the formation the obstacle will take
		float wallLenght = GetComponent<Renderer>().bounds.size.z;
		formationRnd = 4;
		//check for a formation to spawn the obstacles
		if(formationRnd == 0){
			wallLenghtDivider = 13;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 1){
			wallLenghtDivider = 12;
			wallSectionDivided = wallLenght/ wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 2){
			wallLenghtDivider = 11;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 3){
			wallLenghtDivider = 12;
			wallSectionDivided = wallLenght/ wallLenghtDivider;
			Formation1();
		}
		else if(formationRnd == 4){
			wallLenghtDivider = 11;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			Formation2();
		}
	}
	
	private void RandomFormation(){
		for(int i = 0; i < wallLenghtDivider - 1; i++)
		{
			float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
			obstacleType = Random.Range(0,22);
			SpawnChance();
			if(obstacleType < BOULDER){
				int obstacleSize1Rnd = Random.Range(0,3); //Random number between 3, indicating the spawn lane possibility of a size 1 obstacle
				if(obstacleSize1Rnd == 0){
					spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , 4, spawnPositionZ);
				}
				else if(obstacleSize1Rnd == 1){
					spawnPosition = new Vector3(0 , 4, spawnPositionZ);
				}
				else{
					spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX , 4, spawnPositionZ);
				}
			}
			else {
				if(Random.Range(0,2) == 0){//Random number between 2, indicating the spawn lane possibility of a size 2 obstacle
					spawnPosition = new Vector3(Const_Script.Obstacle2PositionX , 4, spawnPositionZ);
				}
				else{
					spawnPosition = new Vector3(-Const_Script.Obstacle2PositionX , 4, spawnPositionZ);
				}
			}

			spawnObstacle();
		}
	}
	private void Formation1(){
		obstacleType = SKELETON;
		spawnPosition= new Vector3(-Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(0));
		spawnObstacle();
		spawnPosition= new Vector3(Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(0));
		spawnObstacle();
		obstacleType = FALLINGROCK;
		CalculateSpawnPosition(1,4);
		spawnObstacle();
		CalculateSpawnPosition(1,10);
		spawnObstacle();
		obstacleType = CAVEMONSTER;
		spawnPosition= new Vector3(-Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(4));
		spawnObstacle();

		obstacleType = FALLINGROCK;
		CalculateSpawnPosition(5,4);
		spawnObstacle();
		CalculateSpawnPosition(7,4);
		spawnObstacle();
		obstacleType = ROCK;
		CalculateSpawnPosition(9,4);
		spawnObstacle();
	
		obstacleType = BOULDER;
		CalculateSpawnPosition(11,4);
		spawnObstacle();
	}
	private void Formation2(){
		obstacleType = BOULDER;
		CalculateSpawnPosition(0,4);
		spawnObstacle();
		CalculateSpawnPosition(3,4);
		spawnObstacle();
		CalculateSpawnPosition(5,4);
		spawnObstacle();
		obstacleType = SKELETON;
		CalculateSpawnPosition(6,4);
		spawnObstacle();
		obstacleType = CHEST;
		CalculateSpawnPosition(7,4);
		spawnObstacle();
		CalculateSpawnPosition(8,4);
		spawnObstacle();
		obstacleType = FALLINGROCK;
		CalculateSpawnPosition(9,4);
		spawnObstacle();
		CalculateSpawnPosition(9,6);
		spawnObstacle();
		CalculateSpawnPosition(9,8);
		spawnObstacle();

		CalculateSpawnPosition(10,4);
		spawnObstacle();
		CalculateSpawnPosition(10,6);
		spawnObstacle();

	}

	
	
	private void CalculateSpawnPosition(float i, int positionY){
		float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
		if(obstacleType < BOULDER){
			int obstacleSize1Rnd = Random.Range(0,3); //Random number between 3, indicating the spawn lane possibility of a size 1 obstacle
			if(obstacleSize1Rnd == 0){
				spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , positionY, spawnPositionZ);
			}
			else if(obstacleSize1Rnd == 1){
				spawnPosition = new Vector3(0 , positionY, spawnPositionZ);
			}
			else{
				spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX , positionY, spawnPositionZ);
			}
		}
		else{
			if(Random.Range(0,2) == 0){//Random number between 2, indicating the spawn lane possibility of a size 2 obstacle
				spawnPosition = new Vector3(Const_Script.Obstacle2PositionX , positionY, spawnPositionZ);
			}
			else{
				spawnPosition = new Vector3(-Const_Script.Obstacle2PositionX , positionY, spawnPositionZ);
			}
		}

	}
	private void SpawnChance(){
		if(obstacleType < 5){	//5
			obstacleType = FALLINGROCK;
		}
		else if(obstacleType < 9){ //4
			obstacleType = SKELETON;
		}
		else if(obstacleType < 11){ //2
			obstacleType = COIN;
		}
		else if(obstacleType < 12){ //1
			obstacleType = CHEST;
		}
		else if(obstacleType < 15){ //3
			obstacleType = ROCK;
		}
		else if(obstacleType < 18){ //3
			obstacleType = CAVEMONSTER;
		}
		else if(obstacleType < 20){ //2
			obstacleType = BOULDER;
		}
		else{					//1
			obstacleType = NONE;
		}
	}
	private float CalculatePositionZ(float i){
		float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
		return spawnPositionZ;
	}
	private void spawnObstacle(){
		GameObject obstacle;
		
		if(obstacleType < NONE){
			if(obstacleType == FALLINGROCK){
				obstacle = fallingRock;
			}
			else if(obstacleType == SKELETON){
				obstacle = skeletion;
			}
			else if(obstacleType == COIN){
				obstacle = coin;
			}
			else if(obstacleType == CHEST){
				obstacle = chest;
			}
			else if(obstacleType == ROCK){
				obstacle = rock;
			}
			else if(obstacleType == CAVEMONSTER){
				obstacle = caveMonster;
			}
			else{
				obstacle = boulder;
			}
			GameObject clone = Instantiate(obstacle, spawnPosition, obstacle.transform.rotation) as GameObject;
			clone.transform.parent = transform;
		}
	}
}