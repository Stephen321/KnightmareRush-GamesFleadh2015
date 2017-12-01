using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateCoinsDisplay : MonoBehaviour {

	public Text textDisplay;

	public void UpdateCoins() {
		textDisplay.text = GameManager.Coins.ToString();
	}
}
