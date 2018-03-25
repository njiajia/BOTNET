using UnityEngine;
using System.Collections;

public class InstructionMP1 : MonoBehaviour {

	public GameObject Button1, Button2, Button3, Pause, Qns;

	public GameObject instruction;
	void Start () {
		Time.timeScale = 0;
		Pause.SetActive (false);
		Qns.SetActive (false);
		instruction.SetActive (true);
	}


	public void Continue(){
		Time.timeScale = 1;
		Pause.SetActive (true);
		Qns.SetActive (true);
		instruction.SetActive (false);
	}
}
