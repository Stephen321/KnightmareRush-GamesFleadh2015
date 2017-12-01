using UnityEngine;
using System.Collections;
 
public class OneSideLRObstacleManagerPhone : MonoBehaviour {

	public bool sideWallROn;
	public GameObject cube;
	public GameObject coin;
	public GameObject chest;
	public GameObject cannon;
	public GameObject cylinder;
	public GameObject skeleton;
	public GameObject rectangle;
	const int CUBE = 0,CANNON = 1,CYLINDER =2,SKELETON = 3,COIN = 4,CHEST = 5, RECTANGLE =6,NONE = 7;
	
	int obstacleType;			//number indicating the obstacle that spawn
	Vector3 spawnPosition;		//obstacle spawn position
	float wallSectionDivided; 	//lenght between each section
	float wallLenghtDivider;	//section to divide the wall by
	float wallPositionZ;
	float fixSize1PositionX, fixSize2PositionX;			//fix the position of object x position depending on the type of the oneSideWall spawn.

	void Start () {
		if(sideWallROn == false){	//check which side the OneSideWall spawned.
			fixSize1PositionX = -Const_Script.Obstacle1PositionX;
			fixSize2PositionX = -Const_Script.Obstacle2PositionX;
		}
		else{
			fixSize1PositionX = Const_Script.Obstacle1PositionX;
			fixSize2PositionX = Const_Script.Obstacle2PositionX;
		}

		wallPositionZ = transform.position.z;
		int formationRnd = Random.Range(0,5); //Random number indicating the formation the obstacle will spawn in
		float wallLenght = GetComponent<Renderer>().bounds.size.z;
		if(formationRnd == 0){
			wallLenghtDivider = 8;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 1){
			wallLenghtDivider = 7;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 2){
			wallLenghtDivider = 6;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 3){
			wallLenghtDivider = 8;
			wallSectionDivided = wallLenght/ wallLenghtDivider;
			Formation1();
		}
		else if(formationRnd == 4){
			wallLenghtDivider = 7;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			Formation2();
		}		
	}

	private void RandomFormation(){
		for(int i = 0; i < wallLenghtDivider - 1; i++)
		{
			float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
			obstacleType = Random.Range(0,31);
			SpawnChance();
			if(obstacleType < RECTANGLE){
				if(Random.Range(0,2) == 0){ //Random number between 2, indicating the spawn lane possibility of a size 1 obstacle
					spawnPosition = new Vector3(0 , 4, spawnPositionZ);
				}
				else{
					spawnPosition = new Vector3(fixSize1PositionX , 4, spawnPositionZ);
				}
			}
			else {
				spawnPosition = new Vector3(fixSize2PositionX, 4, spawnPositionZ);
			}
			SpawnObstacle();
		}
		
	}
	private void Formation1(){

		obstacleType = CUBE;
		CalculateSpawnPosition(0,4);
		SpawnObstacle();
		CalculateSpawnPosition(0,8);
		SpawnObstacle();
		CalculateSpawnPosition( 0,12);
		SpawnObstacle();

		CalculateSpawnPosition(1,4);
		SpawnObstacle();
		CalculateSpawnPosition(1,8);
		SpawnObstacle();
		CalculateSpawnPosition(1,12);
		SpawnObstacle();
		obstacleType = RECTANGLE;
		CalculateSpawnPosition(2.5f,12);
		SpawnObstacle();
		obstacleType = CANNON;
		CalculateSpawnPosition(3.5f,12);
		SpawnObstacle();
		obstacleType = SKELETON;
		CalculateSpawnPosition(5f,12);
		SpawnObstacle();
		obstacleType = COIN;
		spawnPosition = new Vector3(0,4,CalculatePositionZ(6f));
		SpawnObstacle();
		spawnPosition = new Vector3(fixSize1PositionX,4,CalculatePositionZ(6f));
		SpawnObstacle();
	}
	private void Formation2(){
		obstacleType = RECTANGLE;
		CalculateSpawnPosition(0,4);
		SpawnObstacle();
		obstacleType = CANNON;
		CalculateSpawnPosition(0,8);
		SpawnObstacle();
		obstacleType = SKELETON;
		CalculateSpawnPosition(1.5f,4);
		SpawnObstacle();
		CalculateSpawnPosition(2.5f,4);
		SpawnObstacle();
		CalculateSpawnPosition(3.5f,4);
		SpawnObstacle();
		obstacleType = CYLINDER;
		spawnPosition = new Vector3(fixSize1PositionX,4,CalculatePositionZ(4.2f));
		SpawnObstacle();
		obstacleType = CUBE;
		spawnPosition = new Vector3(0,4,CalculatePositionZ(4.2f));
		SpawnObstacle();
		obstacleType = COIN;
		CalculateSpawnPosition(5.5f,4);
		SpawnObstacle();
	}
	
	private void CalculateSpawnPosition( float i, int spawnPositionY){
		float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
		if(obstacleType < RECTANGLE){
			if(Random.Range(0,2) == 0){			//Random number between 2, indicating the spawn lane possibility of a size 1 obstacle
				spawnPosition = new Vector3(0 , spawnPositionY, spawnPositionZ);
			}
			else{
				spawnPosition = new Vector3(fixSize1PositionX , spawnPositionY, spawnPositionZ);
			}
		}
		else{
			spawnPosition = new Vector3(fixSize2PositionX , spawnPositionY, spawnPositionZ);
		}
	}

	private float CalculatePositionZ(float i){
		float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
		return spawnPositionZ;
	}

	private void SpawnChance(){
		if(obstacleType < 9){	//9 
			obstacleType = CUBE;
		}
		else if(obstacleType < 13){ //4
			obstacleType = CANNON;
		}
		else if(obstacleType < 18){ //5
			obstacleType = CYLINDER;
		}
		else if(obstacleType < 22){ //4
			obstacleType = SKELETON;
		}
		else if(obstacleType < 24){ //2
			obstacleType = COIN;
		}
		else if(obstacleType < 25){ //1
			obstacleType = CHEST;
		}
		else if(obstacleType < 28){ //3
			obstacleType = RECTANGLE;
		}
		else{					//2
			obstacleType = NONE;
		}
	}
	private void SpawnObstacle(){
		GameObject obstacle;

		if(obstacleType < NONE){
			if(obstacleType == CUBE){
				obstacle = cube;
			}
			else if(obstacleType == CANNON){
				obstacle = cannon;
			}
			else if(obstacleType == CYLINDER){
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
			else {
				obstacle = rectangle;
			}
			GameObject clone = Instantiate(obstacle, spawnPosition, obstacle.transform.rotation) as GameObject;
			clone.transform.parent = transform;
		}
	}
}

