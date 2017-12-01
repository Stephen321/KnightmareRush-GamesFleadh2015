using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
	void Update () {
		GetComponent<Image> ().CrossFadeAlpha (255f, 10f, false);
	}
}
