using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {


	public Text countText; //For the GameOverScreen
	public Text countText2; //For the Popout
	int score;

	// Use this for initialization
	void Start () {

		//Get the value from Stage2 Screen
		score = PlayerPrefs.GetInt ("Scoring");

	}
	
	// Update is called once per frame
	void Update () {
	
		countText.text = "Your Score: " + score.ToString ();
		countText2.text = "Score: " + score.ToString ();
	}
}
