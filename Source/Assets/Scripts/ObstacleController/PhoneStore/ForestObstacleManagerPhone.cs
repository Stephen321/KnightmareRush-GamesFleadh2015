using UnityEngine;
using System.Collections;

public class ForestObstacleManager : MonoBehaviour {
	
	public GameObject rock; //rhino rock tree vines 
	public GameObject rhino; 
	public GameObject coin; 
	public GameObject vines;
	public GameObject chest;
	public GameObject log;
	const int ROCK = 0,RHINO = 1,COIN =2,CHEST = 3,VINES = 4,LOG = 5,NONE = 6;
	
	int obstacleType;	//number indicating the obstacle to spawn
	
	Vector3 spawnPosition;		//obstacle spawn position
	float wallSectionDivided;	//lenght between each section
	float wallLenghtDivider;	//section to divide the wall by
	float wallPositionZ;		
	void Start () {

		wallPositionZ = transform.position.z;	
		int formationRnd = Random.Range(0,5); //Random number indicating the formation the obstacle will take
		float wallLenght = GetComponent<Renderer>().bounds.size.z;

		//check for a formation to spawn the obstacles
		if(formationRnd == 0){
			wallLenghtDivider = 15;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
			
		}
		else if(formationRnd == 1){
			wallLenghtDivider = 13;
			wallSectionDivided = wallLenght/ wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 2){
			wallLenghtDivider = 11;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 3){
			wallLenghtDivider = 14;
			wallSectionDivided = wallLenght/ wallLenghtDivider;
			Formation1();
		}
		else if(formationRnd == 4){
			wallLenghtDivider = 14;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			Formation2();
		}
		else if(formationRnd == 5){
			wallLenghtDivider = 12;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			Formation3();
		}
	}
	
	private void RandomFormation(){
		for(int i = 0; i < wallLenghtDivider - 1; i++)
		{
			float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
			obstacleType = Random.Range(0,21);
			SpawnChance();
			if(obstacleType < VINES){
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
			else if(obstacleType < LOG){
				if(Random.Range(0,2) == 0){//Random number between 2, indicating the spawn lane possibility of a size 2 obstacle
					spawnPosition = new Vector3(Const_Script.Obstacle2PositionX , 4, spawnPositionZ);
				}
				else{
					spawnPosition = new Vector3(-Const_Script.Obstacle2PositionX , 4, spawnPositionZ);
				}
			}
			else{
				spawnPosition = new Vector3(0 , 4, spawnPositionZ);
			}
			spawnObstacle();
		}
	}
	private void Formation1(){
		obstacleType = ROCK;
		spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(0));
		spawnObstacle();
		spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(0));
		spawnObstacle();
		obstacleType = RHINO;
		spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(4));
		spawnObstacle();
		spawnPosition = new Vector3(0 , 4, CalculatePositionZ(4));
		spawnObstacle();
		obstacleType = CHEST;
		spawnObstacle();
		spawnPosition = new Vector3(0 , 4, CalculatePositionZ(5));
		obstacleType = VINES;
		CalculateSpawnPosition(6);
		spawnObstacle();

		CalculateSpawnPosition(8);
		spawnObstacle();
		obstacleType = LOG;
		spawnPosition = new Vector3(0 , 4, CalculatePositionZ(10));
		spawnObstacle();

		obstacleType = ROCK;
		CalculateSpawnPosition(13);
		spawnObstacle();

	}
	private void Formation2(){
		obstacleType = ROCK;
		CalculateSpawnPosition(0);
		spawnObstacle();
		obstacleType = LOG;
		spawnPosition = new Vector3(0 , 4, CalculatePositionZ(1));
		spawnObstacle();
		obstacleType = VINES;
		CalculateSpawnPosition(2);
		spawnObstacle();
		obstacleType = ROCK;

		CalculateSpawnPosition(4);
		spawnObstacle();


		obstacleType = RHINO;
		spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(8));
		spawnObstacle();
		spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(8));
		spawnObstacle();
		CalculateSpawnPosition(10);
		spawnObstacle();
		obstacleType = COIN;
		spawnObstacle();
		CalculateSpawnPosition(11);
		spawnObstacle();
		obstacleType = LOG;
		spawnPosition = new Vector3(0 , 4, CalculatePositionZ(13));
		spawnObstacle();
	}
	private void Formation3(){
		obstacleType = CHEST;
		CalculateSpawnPosition(0);
		spawnObstacle();
		obstacleType = LOG;
		CalculateSpawnPosition(1);
		spawnObstacle();
		obstacleType = VINES;
		CalculateSpawnPosition(3);
		spawnObstacle();
		CalculateSpawnPosition(4);
		spawnObstacle();
		CalculateSpawnPosition(6);
		spawnObstacle();
		obstacleType = RHINO;
		CalculateSpawnPosition(7);
		spawnObstacle();
		obstacleType = LOG;
		CalculateSpawnPosition(8);
		spawnObstacle();
		CalculateSpawnPosition(9.5f);
		obstacleType = RHINO;
		CalculateSpawnPosition(11);
	}
	

	private void CalculateSpawnPosition(float i){
		float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
		if(obstacleType < VINES){
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
		else if(obstacleType < LOG){
			if(Random.Range(0,2) == 0){//Random number between 2, indicating the spawn lane possibility of a size 2 obstacle
				spawnPosition = new Vector3(Const_Script.Obstacle2PositionX , 4, spawnPositionZ);
			}
			else{
				spawnPosition = new Vector3(-Const_Script.Obstacle2PositionX , 4, spawnPositionZ);
			}
		}
		else{
			spawnPosition = new Vector3(0 , 4, spawnPositionZ);
		}
	}
	private void SpawnChance(){
		if(obstacleType < 4){	//4
			obstacleType = ROCK;
		}
		else if(obstacleType < 7){ //3
			obstacleType = RHINO;
		}
		else if(obstacleType < 9){ //2
			obstacleType = COIN;
		}
		else if(obstacleType < 10){ //1
			obstacleType = CHEST;
		}
		else if(obstacleType < 15){ //5
			obstacleType = VINES;
		}
		else if(obstacleType < 18){ //3
			obstacleType = LOG;
		}
		else{					//2
			obstacleType = NONE;
		}
	}
	private float CalculatePositionZ( float i){
		float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
		return spawnPositionZ;
	}
	private void spawnObstacle(){
		GameObject obstacle;
		
		if(obstacleType < NONE){
			if(obstacleType == ROCK){
				obstacle = rock;
			}
			else if(obstacleType == RHINO){
				obstacle = rhino;
			}
			else if(obstacleType == COIN){
				obstacle = coin;
			}
			else if(obstacleType == CHEST){
				obstacle = chest;
			}
			else if(obstacleType == VINES){
				obstacle = vines;
			}
			else{
				obstacle = log;
			}
			
			GameObject clone = Instantiate(obstacle, spawnPosition, obstacle.transform.rotation) as GameObject;
			clone.transform.parent = transform;
		}
	}
}
