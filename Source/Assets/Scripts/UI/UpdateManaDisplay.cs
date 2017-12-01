using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateManaDisplay : MonoBehaviour {


	void LateUpdate () {
		GetComponent<Slider> ().value = GameManager.Mana;
	}
}
