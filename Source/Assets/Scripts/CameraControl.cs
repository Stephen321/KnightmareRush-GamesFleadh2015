using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public Transform p;

	// Use this for initialization
	void Start () {
		//audio.Play ();
		//audio.loop = true;
		transform.position = new Vector3(0, Const_Script.CameraHeight, p.position.z + Const_Script.CameraDepth);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(0, Const_Script.CameraHeight, p.position.z + Const_Script.CameraDepth);
	}
}
