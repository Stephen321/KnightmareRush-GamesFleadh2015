using UnityEngine;
using System.Collections;

public class CoinControll : MonoBehaviour {

	private Vector3 origin, rotation;
	private float speed = 4f;
	private float distance = 2f;

	bool soundTriggered;
	// Use this for initialization
	void Start () {
		origin = this.transform.position;
		rotation = new Vector3(0, 3f, 0);

		soundTriggered = false;
	}
	// Update is called once per frame
	void Update () {
		if (soundTriggered == false)
		{
			Vector3 pos = new Vector3(transform.position.x, origin.y + Mathf.Sin(Time.time/speed)*distance, origin.z);
			this.transform.position = pos;
			this.transform.Rotate(rotation);
		}
		else if (soundTriggered == true)
		{
			if (GetComponent<AudioSource>().isPlaying == false)
				Destroy (this.gameObject);
		}
	}

	void PlayAudio()
	{
		GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.1f);
		GetComponent<AudioSource>().Play ();
		soundTriggered = true;
		gameObject.GetComponent<Renderer>().enabled = false;
		gameObject.GetComponent<Collider>().enabled = false;
	}
}
