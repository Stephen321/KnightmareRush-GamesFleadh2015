using UnityEngine;
using System.Collections;

public class WallSpawner : MonoBehaviour {
	public bool hasFrontWall;
	
	private const int DestroyDistance = 10; //the distance the player will be away from this wall before it is destroyed 
	
	public GameObject nextWall;
	public GameObject previousWall;
	
	public EnviromentManager enviromentScript;
	
	// Update is called once per frame
	void Update () {
		if (hasFrontWall == false) { //use forloop
			float distanceBehind = (GetComponent<Renderer>().bounds.size.z / 2);
			
			if ( GameObject.FindWithTag("Player").GetComponent<Rigidbody>().position.z < (transform.position.z + distanceBehind)) { 
				int chance = Random.Range(0, 11);
				GameObject wallType;
				EnviromentType enviromentType = enviromentScript.Enviroment;
				if (enviromentType == EnviromentType.Castle)
				{
					if ( chance < Const_Script.NormalWallSpawn) {
						wallType = GameObject.FindWithTag("Wall_Manager").GetComponent<TypesOfWalls>().normal;
					}
					else if ( chance < Const_Script.SideWallSpawn) {
						if (Random.Range(0,2) == 0)
							wallType = GameObject.FindWithTag("Wall_Manager").GetComponent<TypesOfWalls>().oneSideL;
						else
							wallType = GameObject.FindWithTag("Wall_Manager").GetComponent<TypesOfWalls>().oneSideR;
					}
					else if ( chance < Const_Script.BridgeWallSpawn) {
						wallType = GameObject.FindWithTag("Wall_Manager").GetComponent<TypesOfWalls>().sides;
					}
					else {
						wallType = GameObject.FindWithTag("Wall_Manager").GetComponent<TypesOfWalls>().tower;
					}
				}
				else if (enviromentType == EnviromentType.Forest)
				{
					wallType = GameObject.FindWithTag("Wall_Manager").GetComponent<TypesOfWalls>().forest;					
				}
				else
				{					
					wallType = GameObject.FindWithTag("Wall_Manager").GetComponent<TypesOfWalls>().caves;	
				}
				
				Quaternion newWallRotation = transform.rotation;
				Vector3 newWallPosition = new Vector3(0, 0, (this.transform.position.z - (GetComponent<Renderer>().bounds.size.z / 2)) - (wallType.GetComponent<Renderer>().bounds.size.z / 2));
				GameObject newWall = Instantiate(wallType, newWallPosition, newWallRotation) as GameObject;
				newWall.transform.parent = GameObject.FindWithTag("Wall_Manager").transform;
				nextWall = newWall;
				hasFrontWall = true;
				
				WallSpawner script = newWall.GetComponent<WallSpawner>();
				script.previousWall = this.gameObject;
				script.enviromentScript = this.gameObject.GetComponentInParent<EnviromentManager> ();
				enviromentScript.WallsCount--;
				enviromentScript.CheckWallCount();
			}
		}
		
		if (GameObject.FindWithTag ("Player").transform.position.z < (this.transform.position.z - DestroyDistance - GetComponent<Renderer>().bounds.size.z / 2)) {
			Destroy(gameObject);
		}
	}
}
