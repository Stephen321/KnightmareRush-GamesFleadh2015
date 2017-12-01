using UnityEngine;
using System.Collections;

public class RhinoControl : MonoBehaviour {
	float zP;
	bool frozen;

	// Use this for initialization
	void Start () {
		zP = -Const_Script.RunningSpeed*2;
		PlayAudio ();
		frozen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (frozen == false) {
			Vector3 playerPositon = GameObject.FindGameObjectWithTag ("Player").transform.position;		
			if (playerPositon.z < transform.position.z + 80) {
				GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, zP * Time.deltaTime);
			}
		}
	}

	void PlayAudio()
	{
		GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.1f);
		GetComponent<AudioSource>().Play ();
	}

	void OnCollisionEnter (Collision colInfo) 
	{
		if (colInfo.collider.tag == "TripObstacle" || colInfo.collider.tag == "BackObstacle")
		{
			Destroy(colInfo.collider.gameObject);
		}
	}
}
