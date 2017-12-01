using UnityEngine;
using System.Collections;
 
public class TowerObstacleManager : MonoBehaviour {

	public GameObject cube;
	public GameObject coin;
	public GameObject skeleton;
	public GameObject barricade;
	const int CUBE = 0,SKELETON = 1,COIN = 2, BARRICADE = 3,NONE = 4;
	int obstacleRnd;	//Random number indicating the obstacle that spawn
	
	Vector3 spawnPosition;
	float wallSectionDivided;
	float wallLenghtDivider;
	float wallPositionZ;
	void Start () {
		wallPositionZ = transform.position.z;
		CheckFormation();		
	}
	
	private void CheckFormation(){

		wallLenghtDivider = 10;
		wallSectionDivided = GetComponent<Renderer>().bounds.size.z / wallLenghtDivider;
		Formation();
	}
	
	private void Formation(){
		obstacleRnd = BARRICADE;
		CalculateSpawnPosition( 0, 4);
		spawnObstacle();
		obstacleRnd = SKELETON;
		spawnPosition = new Vector3(Const_Script.Obstacle1PositionX, 8, CalculatePositionZ(2f));
		spawnObstacle();
		spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX, 8, CalculatePositionZ(2f));
		spawnObstacle();
		obstacleRnd = CUBE;
		for(int i = 0;i < 6; i++){
			if(i < 3){
				float spawnPositionZ = CalculatePositionZ(0.6f * i) - 26;
				spawnPosition = new Vector3(Const_Script.Obstacle1PositionX, 4, spawnPositionZ);
				spawnObstacle();
				spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX, 4, spawnPositionZ);
				spawnObstacle();
			}
			else{
				float spawnPositionZ = CalculatePositionZ(0.6f * (i% 3)) - 26;
				spawnPosition = new Vector3(Const_Script.Obstacle1PositionX, 8,spawnPositionZ);
				spawnObstacle();
				spawnPosition = new Vector3(-Const_Script.Obstacle1PositionX, 8, spawnPositionZ);
				spawnObstacle();
			}
		}
		obstacleRnd = COIN;
		spawnPosition = new Vector3(0, 4, CalculatePositionZ(3f));
		spawnObstacle();
	}
	
	private void CalculateSpawnPosition( float i, int spawnPositionY){
		float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);

		if(obstacleRnd < BARRICADE){
			spawnPosition = new Vector3(0, spawnPositionY, spawnPositionZ);
		}
		else {
			if(Random.Range(0,2) == 0){
				spawnPosition = new Vector3(Const_Script.Obstacle2PositionX , 4, spawnPositionZ);
			}
			else{
				spawnPosition = new Vector3(-Const_Script.Obstacle2PositionX , 4, spawnPositionZ);
			}
		}

	}

	private float CalculatePositionZ(float i){
		float spawnPositionZ = wallPositionZ + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
		return spawnPositionZ;
	}

	private void spawnObstacle(){
		GameObject obstacle;

		if(obstacleRnd < NONE){
			if(obstacleRnd == CUBE){
				obstacle = cube;
			}
			else if(obstacleRnd == SKELETON){
				obstacle = skeleton;
			}
			else if(obstacleRnd == COIN){
				obstacle = coin;
			}
			else{
				obstacle = barricade;
			}
			GameObject clone = Instantiate(obstacle, spawnPosition, obstacle.transform.rotation) as GameObject;
			clone.transform.parent = transform;
		}
	}
}

