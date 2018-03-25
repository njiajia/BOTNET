using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Instruction3 : MonoBehaviour {

	public GameObject instruction3, pause, player, firewall;
	public GameObject dialogueBox, nextAction, nextEvent;
	public Text dialogue;


	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		instruction3.SetActive (false);
		pause.SetActive (false);
		player.SetActive (false);
		firewall.SetActive (false);
		dialogueBox.SetActive (true);
		nextAction.SetActive (true);
		nextEvent.SetActive (false);
		dialogue.text = "CENTCOM: This is where the hacker hides from. Destroy the Firewall in the right order!";
	}

	public void Action(){
		dialogue.text = "CENTCOM: Once we are able to break his firewall, we will be able to confront him. Be quick, there is a timer!";
		nextEvent.SetActive (true);
		nextAction.SetActive (false);
	}

	public void Event(){
		dialogueBox.SetActive (false);
		nextEvent.SetActive (false);
		instruction3.SetActive (true);
	}
	
	public void Continue(){
		Time.timeScale = 1;
		instruction3.SetActive (false);
		pause.SetActive (true);
		player.SetActive (true);
		firewall.SetActive (true);
	}

}
