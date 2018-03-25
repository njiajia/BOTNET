using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionMP2 : MonoBehaviour {

	public GameObject instruction2,pause,optionBox;
	public GameObject dialogueBox, nextAction, nextEvent;
	public Text dialogue;


	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		instruction2.SetActive (false);
		pause.SetActive (false);
		optionBox.SetActive (false);
		dialogueBox.SetActive (true);
		nextAction.SetActive (true);
		nextEvent.SetActive (false);
		dialogue.text = "CENTCOM: Well Done. This is the last target before we are able to reach the firewall. Drag the correct codes into to slot!";
	}

	public void Action(){
		dialogue.text = "CENTCOM: Selecting the wrong answer will get you damaged. Just like before, there's a timer.";
		nextEvent.SetActive (true);
		nextAction.SetActive (false);
	}

	public void Event(){
		dialogueBox.SetActive (false);
		nextEvent.SetActive (false);
		instruction2.SetActive (true);
	}
	
	public void Continue(){
		Time.timeScale = 1;
		instruction2.SetActive (false);
		pause.SetActive (true);
		optionBox.SetActive (true);

	}

}
