﻿using UnityEngine;
using System.Collections;

public class DontDestroyMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
}
