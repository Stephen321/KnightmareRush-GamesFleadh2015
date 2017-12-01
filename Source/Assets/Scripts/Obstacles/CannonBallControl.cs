using UnityEngine;
using System.Collections;

public class CannonBallControl : MonoBehaviour {
	bool grounded = false;
	void OnCollisionEnter (Collision colInfo) 
	{
		if (colInfo.collider.tag == "Ground" && grounded == false) {
			GetComponent<AudioSource> ().pitch = Random.Range (0.9f, 1.1f);
			GetComponent<AudioSource> ().Play ();
			
			GetComponent<Collider>().enabled = false;
			GetComponent<Rigidbody>().Sleep();

			grounded = true;
		}
	}
}
