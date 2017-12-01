using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
	
	public Sprite highlighted;
	public Sprite empty;
	
	public GameObject playerObject;

	public void StartGame()
	{ 
		Application.LoadLevel (4);
	}

	public void Revive()
	{
		playerObject.GetComponent<PlayerControlKeyboard> ().Revive ();	//Needs to get changed if to be build for phone
		GameManager.TotalCoins -= 100;
		GameManager.Invincable = true;
	}

	public void RestartGame ()
	{
		Application.LoadLevel (4);
	}
	
	public void Achievement(string description) 
	{
		GameObject.FindGameObjectWithTag ("DescriptionPanel").GetComponentInChildren<Text> ().text = description;
	}
	
	public void Achievements()
	{
		Application.LoadLevel (2);
	}
	
	public void UpdateSpellSelected (string spell) {		
		GameObject.FindWithTag ("CurrentText").GetComponent<Text> ().text = "Currently Selected: " + spell;
		if (spell == "Fire Ball"){
			GameManager.SpellEquiped =Const_Script.Fireball;
			GameObject.FindWithTag("FireSelect").GetComponent<Image>().sprite = highlighted;
			GameObject.FindWithTag("IceSelect").GetComponent<Image>().sprite = empty;
			GameObject.FindWithTag("ThunderSelect").GetComponent<Image>().sprite = empty;
		}
		else if (spell == "Ice Cube")	{
			GameManager.SpellEquiped =Const_Script.IceCube;
			GameObject.FindWithTag("FireSelect").GetComponent<Image>().sprite = empty;
			GameObject.FindWithTag("IceSelect").GetComponent<Image>().sprite = highlighted;
			GameObject.FindWithTag("ThunderSelect").GetComponent<Image>().sprite = empty;
		}
		else {
			GameManager.SpellEquiped =Const_Script.ThunderCone;
			GameObject.FindWithTag("FireSelect").GetComponent<Image>().sprite = empty;
			GameObject.FindWithTag("IceSelect").GetComponent<Image>().sprite = empty;
			GameObject.FindWithTag("ThunderSelect").GetComponent<Image>().sprite = highlighted;
		}
	}
	
	public void LoadSpellChooser()
	{
		Application.LoadLevel (3);
	}
	
	public void ExitGame()
	{
		Application.Quit ();
		
	}
	
	public void LoadMenu() 
	{
		Application.LoadLevel (1);
	}
	
	public void Back()
	{
		Application.LoadLevel (1);
	}


	public void Pause() 
	{
		if (Time.timeScale == 1) 
		{	
			Time.timeScale = 0;
		}	
	}

	public void Resume() 
	{
		if (Time.timeScale == 0) 
		{	
			Time.timeScale = 1;
		}
	}
}
