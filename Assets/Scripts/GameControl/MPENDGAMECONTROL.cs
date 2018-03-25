using UnityEngine;
using System.Collections;

public class MPENDGAMECONTROL : MonoBehaviour {

	public void mainMenu(){
		Application.LoadLevel ("Menu");
	}

	public void retry(){
		Application.LoadLevel(PlayerPrefs.GetString("StageName"));

	}
}
