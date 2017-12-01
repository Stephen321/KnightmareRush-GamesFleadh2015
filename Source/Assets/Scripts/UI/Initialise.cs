using UnityEngine;
using System.Collections;

public class Initialise : MonoBehaviour {
	//some initialisation that must be done before going into other states/scenes

	// Use this for initialization
	void Start () {
		GameManager.SpellEquiped = Const_Script.IceCube;
		Loading.LoadAllInformation ();
	}
}
