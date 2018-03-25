using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scenario1 : MonoBehaviour {

	public float timer = 1f;
	public GameObject lightbuild;
	public GameObject darkbuild;
	public GameObject message;
	public GameObject nextScene;
	public Text dialogue;

	void Start () {
		message.SetActive (false);
		nextScene.SetActive (false);
	}
	
	void Update () {
	
		if (timer <=0) {
			lightbuild.SetActive(false);
			darkbuild.SetActive(true);
			message.SetActive(true);
			timer = 0f;
		} else {
//			timer -= 0.005f;
			timer -= Time.deltaTime /2 ;
		}

	}

	public void skip(){
		Application.LoadLevel ("Stage1");
	}

	public void NextScene(){
		Application.LoadLevel ("SM2");
	}

	public void NextAction(){
		dialogue.text = "IT experts are calling it a revolution in the hacking world.";
		nextScene.SetActive (true);
	}




}
