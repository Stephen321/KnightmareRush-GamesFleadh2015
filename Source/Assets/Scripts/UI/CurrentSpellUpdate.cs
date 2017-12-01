using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentSpellUpdate : MonoBehaviour {

	public Sprite highLightImage;
	void Awake() {
		if (GameManager.SpellEquiped == Const_Script.Fireball){
			UpdateSpellSelected("Fire Ball");
			GameObject.FindWithTag("FireSelect").GetComponent<Image>().sprite = highLightImage;
		}
		else if (GameManager.SpellEquiped == Const_Script.IceCube)	{
			UpdateSpellSelected("Ice Cube");
			GameObject.FindWithTag("IceSelect").GetComponent<Image>().sprite = highLightImage;
		} 
		else {
			UpdateSpellSelected("Thunder Cone");
			GameObject.FindWithTag("ThunderSelect").GetComponent<Image>().sprite = highLightImage;
		}
	}

	public void UpdateSpellSelected (string spell) {
		GetComponent<Text> ().text = "Currently Selected: " + spell;
	}
}
