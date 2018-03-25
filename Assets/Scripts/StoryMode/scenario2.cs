using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scenario2 : MonoBehaviour {

	public GameObject nextScene, nextAction;
	public bool x = false;
	Animator anim;

	public Text dialogue;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		nextScene.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("x", x);
	}

	public void next(){
		x = true;
		nextScene.SetActive (true);
		nextAction.SetActive (false);

		dialogue.text = "PROJECT BOTNET";
	}


}
