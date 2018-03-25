using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	public Canvas enterScreen;
	public Button submitScore;

	// Use this for initialization
	void Start ()
	{
		GameObject mc = GameObject.Find("StageBGM");
		Destroy (mc);
		enterScreen = enterScreen.GetComponent<Canvas> ();
		submitScore = submitScore.GetComponent<Button> ();
		enterScreen.enabled = false;
		
	}

	public void submitPress(){
		enterScreen.enabled = true;
		submitScore.enabled = false;
	}
}
