using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementScript : MonoBehaviour {
	
	
	public void SetProgress(float percentage)
	{
		transform.Find ("Image").GetComponent<Image> ().fillAmount = percentage;
		if (transform.Find ("Image").GetComponent<Image> ().fillAmount == 1) {
			transform.Find ("Image").GetComponent<Image> ().sprite = 
				GameObject.Find("UIManager").GetComponent<Image> ().sprite;
		}
	}
}
