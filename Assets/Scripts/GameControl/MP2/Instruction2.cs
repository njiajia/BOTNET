using UnityEngine;
using System.Collections;

public class Instruction2 : MonoBehaviour {

	public GameObject instruction2;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		instruction2.SetActive (true);
	}
	
	public void Continue(){
		Time.timeScale = 1;
		instruction2.SetActive (false);
	}

}
