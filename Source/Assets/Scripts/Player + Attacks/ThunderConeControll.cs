using UnityEngine;
using System.Collections;

public class ThunderConeControll : MonoBehaviour {

	Vector3 vel;
	float speed = 0;
	float timer = 0;
	const float MAX_ALIVE_TIME = 30;

	// Use this for initialization
	void Start () {
		speed = Const_Script.RunningSpeed * 6;
		vel = new Vector3 (0, 0, speed);
		timer = MAX_ALIVE_TIME;
	}
	
	// Update is called once per frame
	void Update () {
		timer --;
		GetComponent<Rigidbody>().velocity = vel * Time.deltaTime;
		if (timer <= 0)
			Destroy (this.gameObject);
	}

	void OnCollisionEnter (Collision colInfo) 
	{
			Destroy (this.gameObject);
	}
}
