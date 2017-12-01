using UnityEngine;
using System.Collections;

public class RocksControl : MonoBehaviour {

	void PlayAudio()
	{
		GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.1f);
		GetComponent<AudioSource>().Play ();
	}

	void Destroy()
	{
		GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.1f);
		GetComponent<AudioSource>().Play ();
		gameObject.GetComponent<Renderer>().enabled = false;
		gameObject.GetComponent<Collider>().enabled = false;
	}

	void OnCollisionEnter (Collision colInfo) 
	{
		if (colInfo.collider.tag == "IceSpell")
			Destroy(gameObject);
	}
}
