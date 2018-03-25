using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Instruction : MonoBehaviour {

	public GameObject dialogueBox, nextAction, nextEvent;
	public Text dialogue;

	public GameObject instruction, Pause, Qns;

	public GameObject Button1, Button2, Button3;

	void Start () {
		Time.timeScale = 0;
		Button1.SetActive (false);
		Button2.SetActive (false);
		Button3.SetActive (false);
		Pause.SetActive (false);
		Qns.SetActive (false);
		instruction.SetActive (false);
		nextEvent.SetActive (false);
		nextAction.SetActive (true);
		dialogueBox.SetActive (true);
		dialogue.text = "CENTCOM: Our first target has been identified, select the right answer to attack";

	}

	public void Action(){
			dialogue.text = "CENTCOM: Selecting the wrong answer will get you damaged. Be quick too, there's a timer.";
			nextEvent.SetActive (true);
			nextAction.SetActive (false);
	}

	public void Event(){
		dialogueBox.SetActive (false);
		nextEvent.SetActive (false);
		instruction.SetActive (true);
	}

	public void Continue(){
		Time.timeScale = 1;
		Button1.SetActive (true);
		Button2.SetActive (true);
		Button3.SetActive (true);
		Pause.SetActive (true);
		Qns.SetActive (true);
		instruction.SetActive (false);
	}

}
