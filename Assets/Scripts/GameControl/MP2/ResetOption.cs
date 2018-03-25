using UnityEngine;
using System.Collections;

public class ResetOption : MonoBehaviour {

	public GameObject opt1;
	public GameObject option1;

	public GameObject opt2;
	public GameObject option2;

	public GameObject opt3;
	public GameObject option3;

	public GameObject opt4;
	public GameObject option4;


	public void reset(){

		opt1.transform.SetParent (option1.transform);
		opt2.transform.SetParent (option2.transform);
		opt3.transform.SetParent (option3.transform);
		opt4.transform.SetParent (option4.transform);
	
	}

	
}
