using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour {

	public GameObject Popout,Credits,gameModes;
	public MusicManager BGM;
	
	void Start(){
		GameObject mc = GameObject.Find("StageBGM");
		Destroy (mc);
		Popout.SetActive(false);
		Credits.SetActive(false);
		gameModes.SetActive(false);
	}

	public void gameStart () {
		gameModes.SetActive(true);
	}

	public void gameQuit () {
		Debug.Log ("QUIT!");
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}

	public void showPop(){
		Popout.SetActive(true);
	}

	public void hidePop(){
		Popout.SetActive(false);
	}

	public void High(){
		Application.LoadLevel ("Highscores");
	}

	public void credited(){
		Credits.SetActive(true);
	}

	public void uncredited(){
		Credits.SetActive(false);
	}
	public void hidegameModes(){
		gameModes.SetActive(false);
	}

	public void storymode(){
		Application.LoadLevel ("SM1");
	}

	public void mp1(){
		Application.LoadLevel ("Stage1M");
	}

	public void mp2(){
		Application.LoadLevel ("Stage2M");
	}
}
