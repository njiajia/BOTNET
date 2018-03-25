using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pauser : MonoBehaviour {

	public GameObject PauseMenu, QuitMenu;
	public Button mute;
	string l;

	void Start(){
		PauseMenu.SetActive (false);
		QuitMenu.SetActive (false);
	}

	// Update is called once per frame
	public void pause () {
		PauseMenu.SetActive (true);
		Time.timeScale = 0;
	}

	public void resume(){
		PauseMenu.SetActive (false);
		Time.timeScale = 1;
	}

	public void quit(){
		QuitMenu.SetActive (true);
	}

	public void home(){
		Time.timeScale = 1;
		Application.LoadLevel ("Menu");
	}

	public void noQuit(){
		QuitMenu.SetActive (false);
	}

	public void Mute(){
		if (mute.GetComponentInChildren<Text> ().text.ToString() == "MUTE") {
			l = "UNMUTE";
			mute.GetComponentInChildren<Text> ().text = l;
			AudioListener.volume = 0f;
		}
		else{
			l = "MUTE";
			mute.GetComponentInChildren<Text> ().text = l;
			AudioListener.volume = 1f;
		}
	}
}
