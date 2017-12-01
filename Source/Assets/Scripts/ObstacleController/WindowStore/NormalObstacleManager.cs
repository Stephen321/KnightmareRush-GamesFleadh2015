using UnityEngine;
using System.Collections;

public class NormalObstacleManagerPhone : MonoBehaviour {

	public GameObject cube; 
	public GameObject cannon; 
	public GameObject coin; 
 	public GameObject cylinder;
	public GameObject skeleton;
	public GameObject chest;
	public GameObject rectangle;
	public GameObject barricade;	
	const int CUBE = 0,CANNON = 1,CYLINDER =2,SKELETON = 3,COIN = 4,CHEST = 5, RECTANGLE =6,BARRICADE = 7,NONE = 8;

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
			wallLenghtDivider = 18;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
			
		}
		else if(formationRnd == 1){
			wallLenghtDivider = 16;
			wallSectionDivided = wallLenght/ wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 2){
			wallLenghtDivider = 14;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 3){
			wallLenghtDivider = 14;
			wallSectionDivided = wallLenght/ wallLenghtDivider;
			Formation1();
		}
		else if(formationRnd == 4){
			wallLenghtDivider = 10;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			Formation2();
		}
		else if(formationRnd == 5){
			wallLenghtDivider = 16;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			Formation3();
		}
		else{
			wallLenghtDivider = 12;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			Formation4();
		}	
	}

	private void RandomFormation(){
		for(int i = 0; i < wallLenghtDivider - 1; i++)
		{
			float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
			obstacleType = Random.Range(0,31);
			SpawnChance();
			if(obstacleType < RECTANGLE){
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
		//hardcode formation....cube blockage (x3), cannons (x2), skeleton (x2) etc.....
		obstacleType = CUBE;
		CalculateSpawnPosition(0,8);
		spawnObstacle();
		CalculateSpawnPosition(0,12);
		spawnObstacle();
		CalculateSpawnPosition(0,16);
		spawnObstacle();

		obstacleType = CANNON;
		spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(0.5f));
		spawnObstacle();
		spawnPosition = new Vector3(0 , 4, CalculatePositionZ(0.5f));;
		spawnObstacle();

		obstacleType = RECTANGLE;
		CalculateSpawnPosition(2,8);
		spawnObstacle();

		obstacleType = SKELETON;
		spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(3));
		spawnObstacle();
		spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(3));
		spawnObstacle();

		obstacleType = CUBE;
		CalculateSpawnPosition( 5,4);
		spawnObstacle();
		CalculateSpawnPosition( 5,8);
		spawnObstacle();
		CalculateSpawnPosition(5,12);
		spawnObstacle();
		CalculateSpawnPosition(5,16);
		spawnObstacle();
		CalculateSpawnPosition(5,20);
		spawnObstacle();

		obstacleType = COIN;
		CalculateSpawnPosition( 6,4);
		spawnObstacle();

		obstacleType = RECTANGLE;
		CalculateSpawnPosition( 8,4);
		spawnObstacle();
		obstacleType = SKELETON;
		CalculateSpawnPosition(8,8);
		spawnObstacle();
		obstacleType = CANNON;
		CalculateSpawnPosition(9,4);
		spawnObstacle();

		obstacleType = CUBE;
		CalculateSpawnPosition(11,4);
		spawnObstacle();
		obstacleType = CYLINDER;
		CalculateSpawnPosition(11.5f,4);
		spawnObstacle();
		CalculateSpawnPosition(11.5f,12);
		spawnObstacle();

		spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(12.5f));
		spawnObstacle();
		obstacleType = CUBE;
		spawnPosition = new Vector3(0 , 4, CalculatePositionZ(12.5f));
		spawnObstacle();
		spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(12.5f));
		spawnObstacle();
		spawnPosition = new Vector3(0 , 4, CalculatePositionZ( 13));
		spawnObstacle(); 
	}
	private void Formation2(){
		//hardcode formation... etc.....
		obstacleType = SKELETON;
		spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , 4, CalculatePositionZ( 0));
		spawnObstacle();
		obstacleType = CYLINDER;
		spawnPosition = new Vector3(0 , 4, CalculatePositionZ(0.8f));
		spawnObstacle();
		spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX , 4, CalculatePositionZ(1.6f));
		spawnObstacle();
		obstacleType = SKELETON;
		spawnPosition = new Vector3(0 , 4, CalculatePositionZ(2.4f));
		spawnObstacle();
		spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , 4, CalculatePositionZ( 3.2f));
		spawnObstacle();

		obstacleType = CUBE;
		CalculateSpawnPosition( 4, 4);
		spawnObstacle();
		obstacleType = CUBE;
		CalculateSpawnPosition(4.3f,4);
		spawnObstacle();
		CalculateSpawnPosition(4.3f,8);
		spawnObstacle();
		obstacleType = CUBE;
		CalculateSpawnPosition( 4.5f,4);

		obstacleType = CUBE;
		for(int i = 0; i<5; i ++){
			CalculateSpawnPosition(5, 4 * i);
			spawnObstacle();
		}

		CalculateSpawnPosition(6.5f, 4);
		spawnObstacle();
		CalculateSpawnPosition( 6.5f, 8);
		spawnObstacle();
		CalculateSpawnPosition( 6.5f, 12);
		spawnObstacle();
		CalculateSpawnPosition( 6.5f, 16);
		spawnObstacle();

		CalculateSpawnPosition( 7.5f, 4);
		spawnObstacle();
		CalculateSpawnPosition( 7.5f, 8);
		spawnObstacle();

		CalculateSpawnPosition( 8f, 4);
		spawnObstacle();
		spawnPosition = new Vector3(spawnPosition.x , 8, spawnPosition.z);
		spawnObstacle();
	}
	private void Formation3(){
		obstacleType =CUBE;
		for(int i = 0; i<5; i ++){
			CalculateSpawnPosition(1,4 * i);
			spawnObstacle();
		}

		for(int i = 0; i<5; i ++){
			CalculateSpawnPosition(3,4 * i);
			spawnObstacle();
		}
		for(int i = 0; i<5; i ++){
			CalculateSpawnPosition(5,4 * i);
			spawnObstacle();
		}
		obstacleType = Random.Range(0,9);
		CalculateSpawnPosition( 7,4);
		spawnObstacle();
		obstacleType = Random.Range(0,9);
		CalculateSpawnPosition(8,4);
		spawnObstacle();
		obstacleType = RECTANGLE;
		CalculateSpawnPosition( 9,4);
		spawnObstacle();
		CalculateSpawnPosition(10,4);
		spawnObstacle();
		obstacleType = CUBE;
		CalculateSpawnPosition(10,8);
		spawnObstacle();
		obstacleType = CANNON;
		CalculateSpawnPosition( 12,4);
		spawnObstacle();
		CalculateSpawnPosition( 13,4);
		spawnObstacle();
		obstacleType = Random.Range(0,9);
		CalculateSpawnPosition( 14,4);
		spawnObstacle();

	}

	private void Formation4(){
		for(float i =0; i < 4; i+=0.9f){
			obstacleType = Random.Range(0,9);
			CalculateSpawnPosition( i,4);
			spawnObstacle();
		}
		obstacleType = BARRICADE;
		CalculateSpawnPosition( 5,4);
		spawnObstacle();
		CalculateSpawnPosition( 6,4);
		spawnObstacle();
		CalculateSpawnPosition( 7,4);
		spawnObstacle();
		obstacleType = CUBE;
		CalculateSpawnPosition( 9,4);
		spawnObstacle();
		CalculateSpawnPosition( 9,8);
		spawnObstacle();
		obstacleType = CANNON;
		CalculateSpawnPosition(9,12);
		spawnObstacle();
		CalculateSpawnPosition(10,4);
		spawnObstacle();
	}
	private void CalculateSpawnPosition(float i, int spawnPositionY){
		float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
		if(obstacleType < RECTANGLE){
			int obstacleSize1Rnd = Random.Range(0,3); //Random number between 3, indicating the spawn lane possibility of a size 1 obstacle
			if(obstacleSize1Rnd == 0){
				spawnPosition = new Vector3(Const_Script.Obstacle1PositionX , spawnPositionY, spawnPositionZ);
			}
			else if(obstacleSize1Rnd == 1){
				spawnPosition = new Vector3(0 , spawnPositionY, spawnPositionZ);
			}
			else{
				spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX , spawnPositionY, spawnPositionZ);
			}
		}
		else{
			if(Random.Range(0,2) == 0){//Random number between 2, indicating the spawn lane possibility of a size 2 obstacle
				spawnPosition = new Vector3(Const_Script.Obstacle2PositionX , spawnPositionY, spawnPositionZ);
			}
			else{
				spawnPosition = new Vector3(-Const_Script.Obstacle2PositionX , spawnPositionY, spawnPositionZ);
			}
		}
	}
	private void SpawnChance(){
		if(obstacleType < 6){	//6 
			obstacleType = CUBE;
		}
		else if(obstacleType < 10){ //4
			obstacleType = CANNON;
		}
		else if(obstacleType < 14){ //4
			obstacleType = CYLINDER;
		}
		else if(obstacleType < 17){ //3
			obstacleType = SKELETON;
		}
		else if(obstacleType < 19){ //2
			obstacleType = COIN;
		}
		else if(obstacleType < 20){ //1
			obstacleType = CHEST;
		}
		else if(obstacleType < 25){ //5
			obstacleType = RECTANGLE;
		}
		else if(obstacleType < 28){ //3
			obstacleType = BARRICADE;
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
			if(obstacleType == CUBE){
				obstacle = cube;
			}
			else if(obstacleType == CANNON){
				obstacle = cannon;
			}
			else if(obstacleType ==CYLINDER){
				obstacle = cylinder;
			}
			else if(obstacleType == SKELETON){
				obstacle = skeleton;
			}
			else if(obstacleType == COIN){
				obstacle = coin;
			}
			else if(obstacleType == CHEST){
				obstacle = chest;
			}
			else if(obstacleType == RECTANGLE){
				obstacle = rectangle;
			}
			else{
				obstacle = barricade;
			}

			GameObject clone = Instantiate(obstacle, spawnPosition, obstacle.transform.rotation) as GameObject;
			clone.transform.parent = transform;
		}
	}
}
