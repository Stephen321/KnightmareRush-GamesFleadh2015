using UnityEngine;
using System.Collections;
 
public class OneSideObstacleManager : MonoBehaviour {
	
	public GameObject cube;
	public GameObject coin;
	public GameObject chest;
	public GameObject cannon;
	public GameObject rectangle;
	const int CUBE = 0,COIN = 1,CHEST = 2, RECTANGLE =3,NONE = 4;

	int obstacleType;	

	Vector3 spawnPosition;
	float wallSectionDivided;
	float wallLenghtDivider;

	void Start () {
		int formationRnd = Random.Range(0,3); //Random number indicating the formation the obstacle will take
		float wallLenght = GetComponent<Renderer>().bounds.size.z;
		if(formationRnd == 0){
			wallLenghtDivider = 7;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
		}
		else if(formationRnd == 1){
			wallLenghtDivider = 6;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
		}
		else{
			wallLenghtDivider = 5;
			wallSectionDivided = wallLenght / wallLenghtDivider;
			RandomFormation();
		}
	}
	
	private void RandomFormation(){

		float wallPosition = transform.position.z;
		for(int i = 0; i < wallLenghtDivider - 1; i++)
		{
			float spawnPositionZ = wallPosition + ((wallLenghtDivider/2-1)*wallSectionDivided) - (wallSectionDivided*i);
			obstacleType = Random.Range(0,21);
			SpawnChance();
			if(obstacleType < RECTANGLE){
				spawnPosition = new Vector3(0 , 4, spawnPositionZ);
			}
			else{
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
	private void SpawnChance(){
		if(obstacleType < 10){	//10 
			obstacleType = CUBE;
		}
		else if(obstacleType < 13){ //3
			obstacleType = COIN;
		}
		else if(obstacleType < 14){ //1
			obstacleType = CHEST;
		}
		else if(obstacleType < 19){ //5
			obstacleType = RECTANGLE;
		}
		else{					//2
			obstacleType = NONE;
		}
	}
	private void spawnObstacle(){
		GameObject obstacle;
		if(obstacleType < NONE){
			if(obstacleType == CUBE){
				obstacle = cube;
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

