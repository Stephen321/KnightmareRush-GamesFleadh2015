using UnityEngine;
using System.Collections;

public class BallSpawn : MonoBehaviour {

	public GameObject cannonBall;
	bool once, frozen;

	// Use this for initialization
	void Start () {
		once = false;
		frozen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (once == false && frozen == false) {
			Vector3 playerPositon = GameObject.FindGameObjectWithTag("Player").transform.position;

			if(playerPositon.z < transform.position.z +50) {
				GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
				GetComponent<AudioSource>().Play ();

				Vector3 position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z + 6);
				this.GetComponent<Rigidbody>().AddForce(0,0,-50000);
				GameObject cannonBallClone = (GameObject)Instantiate(cannonBall, position, Quaternion.identity);
				cannonBallClone.GetComponent<Rigidbody>().AddForce(0,30000,50000);
				once = true;
			}
		}
		else if (transform.position.y < -5)
			Destroy(gameObject);
	}

	void OnCollisionEnter (Collision colInfo) 
	{
		if (colInfo.collider.tag == "FireSpell" || colInfo.collider.tag == "ThunderSpell")
		{
			GameManager.Kills++;
			Destroy(gameObject);
		}
		if (colInfo.collider.tag == "IceSpell")
		{
			frozen = true;
		}
	}
}
