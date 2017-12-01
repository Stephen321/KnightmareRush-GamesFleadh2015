using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateDistanceDisplay : MonoBehaviour {

	public void UpdateDistance () {
		GetComponent<Text> ().text = GameManager.Distance.ToString() + "m";
	}
}
