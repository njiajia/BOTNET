using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Instruction4 : MonoBehaviour {
	
	public GameObject instruction4, pause, player, boss;
	public GameObject dialogueBox, nextAction, nextEvent;
	public Text dialogue;
	
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		instruction4.SetActive (false);
		pause.SetActive (false);
		player.SetActive (false);
		boss.SetActive (false);
		dialogueBox.SetActive (true);
		nextAction.SetActive (true);
		nextEvent.SetActive (false);
		dialogue.text = "CENTCOM: This is where the hacker hides. Defeat him!";
	}
	
	public void Action(){
		dialogue.text = "Good luck!";
		nextEvent.SetActive (true);
		nextAction.SetActive (false);
	}
	
	public void Event(){
		dialogueBox.SetActive (false);
		nextEvent.SetActive (false);
		instruction4.SetActive (true);
	}
	
	public void Continue(){
		Time.timeScale = 1;
		instruction4.SetActive (false);
		pause.SetActive (true);
		player.SetActive (true);
		boss.SetActive (true);
	}
	
}
