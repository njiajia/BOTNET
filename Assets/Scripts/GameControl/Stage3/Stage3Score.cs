using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stage3Score : MonoBehaviour {
	
	//Scoring 
	public int Scoring;
	public Text countText;
	
	public void correct ()
	{
		Scoring+=20;
	}
	
	void Start(){
		Scoring = PlayerPrefs.GetInt("Scoring");
	}
	
	
	void Update ()
	{
		countText.text = "Score: " + Scoring.ToString ();
		PlayerPrefs.SetInt ("Scoring4", Scoring); //Save the value in Unity for next screen
	}
	//End of Scoring
	
}
