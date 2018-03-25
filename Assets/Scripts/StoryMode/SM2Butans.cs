using UnityEngine;
using System.Collections;

public class SM2Butans : MonoBehaviour {

	public scenario2 control;

	public void skip(){
		Application.LoadLevel ("Stage1");
	}

	public void nextScene(){
			Application.LoadLevel ("Stage1");
	}
}
