using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countScore : MonoBehaviour {

	//Scoring 
	public int Scoring;
	public Text countText;

	public void correct ()
	{
		Scoring+=10;
	}

 	void Start(){
		Scoring = PlayerPrefs.GetInt("scoreInt");
	}
	

	void Update ()
	{
//		countText.text = "Score: " + Scoring.ToString ();
		countText.text = ("SCORE: " + Scoring);
		PlayerPrefs.SetInt ("Scoring", Scoring); //Save the value in Unity for next screen
	}
	//End of Scoring

}
