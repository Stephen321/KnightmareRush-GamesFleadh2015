using UnityEngine;
using System.Collections;

public class TreasureControl : MonoBehaviour {
	
	void PlayAudio()
	{
		GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.1f);
		GetComponent<AudioSource>().Play ();
		gameObject.GetComponent<Renderer>().enabled = false;
		gameObject.GetComponent<Collider>().enabled = false;
		gameObject.GetComponent<Rigidbody> ().Sleep ();
	}
}
