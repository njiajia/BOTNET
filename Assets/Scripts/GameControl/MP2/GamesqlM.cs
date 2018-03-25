using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GamesqlM : MonoBehaviour {

	public HealthMP1 P1health; 
	public HealthMP2 P2health;

	// values to match the database columns
	int ID, no, x = 0;
	string option1, option2, option3, option4, correctAns, qn1,qn2,qn3; 

	int[] QnsNo = {1,2,3,4,5,6,7,8,9,10,11,12,13,14};

	public Text q1, q2, q3;

	// for checking answer.
	public string checker; 
		
	//Array List of Options with string Datatype. 
	string[] Options = new string[4]; 

	//Gameobject for arraylist of Options
	public GameObject[] OptArray; 

	public GameObject[] OptArray2; 

	// MySQL instance specific items
	string constr = "Server=127.0.0.1;Database=demo;User ID=root;Password=password;Pooling=true";
	// connection object
	MySqlConnection con = null;
	// command object
	MySqlCommand cmd = null;
	// reader object
	MySqlDataReader rdr = null;
	// object collection array
	GameObject[] bodies;
	// object definitions
	public struct data
	{
		public int ID, sID;
		public string option1, option2, option3, option4, correctAns, qn1,qn2,qn3, score; 
	}
	
	// collection container
	List<data> _GameItems;

	//Startup Database
	public void Awake ()
	{
		try {
			// setup the connection element
			con = new MySqlConnection (constr);
			
			// lets see if we can open the connection
			con.Open ();
			Debug.Log ("Connection State: " + con.State);
		} catch (Exception ex) {
			Debug.Log (ex.ToString ());
		}
		
	}
	

	// Shutdown database connection 
	void OnApplicationQuit ()
	{
		Debug.Log ("killing con");
		if (con != null) {
			if (con.State.ToString () != "Closed")
				con.Close ();
			con.Dispose ();
		}
	}
	
	// Read all entries from the table
	public void ReadEntries ()
	{
		string query = string.Empty;
		if (_GameItems == null)
			_GameItems = new List<data> ();
		if (_GameItems.Count > 0)
			_GameItems.Clear ();
		
		// Error trapping in the simplest form
		try {
			query = "SELECT * FROM test where ID=" + no ;
			if (con.State.ToString () != "Open")
				con.Open ();
			using (con) {
				using (cmd = new MySqlCommand(query, con)) {
					rdr = cmd.ExecuteReader ();
					if (rdr.HasRows)
						while (rdr.Read()) {
							data itm = new data ();
							itm.ID = int.Parse (rdr ["ID"].ToString ());
							itm.option1 = rdr ["option1"].ToString ();
							itm.option2 = rdr ["option2"].ToString ();
							itm.option3 = rdr ["option3"].ToString (); 
							itm.option4 = rdr ["option4"].ToString ();
							itm.correctAns = rdr ["correctAns"].ToString ();
							itm.qn1 = rdr ["qn1"].ToString ();
							itm.qn2 = rdr ["qn2"].ToString (); 
							itm.qn3 = rdr ["qn3"].ToString ();
							_GameItems.Add (itm);
						}
					rdr.Dispose ();
				}
			}
		} catch (Exception ex) {
			Debug.Log (ex.ToString ());
		} finally {
		}
	}


	public void LogGameItems ()
	{
		
		foreach (data itm in _GameItems) {

			Debug.Log ("ID: " + itm.ID);
			Options[0] = itm.option1; 
			Options[1] = itm.option2;
			Options[2] = itm.option3;
			Options[3] = itm.option4;
			checker = itm.correctAns;
			q1.text = itm.qn1;
			q2.text = itm.qn2;
			q3.text = itm.qn3;

		}
		
	}

	void Start ()
	{
		GameObject mc = GameObject.Find ("MusicManager");
		Destroy (mc);
		randQns ();
		QnsCall ();
		ReadEntries ();
		LogGameItems ();

		optionTxt1 ();
		HideOptBox2 ();
		T2.SetActive (false);
		x1 = false;
	}

	public bool x1;

	//Script reference from TimerOne
	public TimerOne tr1;

	//Script reference from TimerOne
	public TimerTwo tr2;

	public void activation(){
 		QnsCall ();
		ReadEntries ();
		LogGameItems ();
	
		//Player two's turn
		if (x1 == false) {

			O1.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			O1.SetActive (false);
			O2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			O2.SetActive (false);
			O3.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			O3.SetActive (false);
			O4.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			O4.SetActive (false);
			T1.SetActive(false);
			HideOptBox1 ();

			P1.SetActive (true);
			P2.SetActive (true);
			P3.SetActive (true);
			P4.SetActive (true);
			T2.SetActive(true);
			ShowOptBox2 ();
			tr2.resetClock2();

			optionTxt2 ();
			x1 = true;
			
		}

		//Player one's turn
		else{
		
			P1.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			P1.SetActive (false);
			P2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			P2.SetActive (false);
			P3.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			P3.SetActive (false);
			P4.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			P4.SetActive (false);
			T2.SetActive(false);
			HideOptBox2();


			O1.SetActive (true);
			O2.SetActive (true);
			O3.SetActive (true);
			O4.SetActive (true);
			T1.SetActive(true); 
			ShowOptBox1();
			tr1.resetClock1();

			optionTxt1 ();
			x1 = false;
		}
	}
	

/* ------------------------------------------ Randomise Options (Without Duplicate)-------------------------------------------*/
	//Display + Shuffle Player1 Options
	void optionTxt1(){

		Shuffle (Options);
		for (int i = 0; i < 4; i++) {
			OptArray [i].GetComponentInChildren<Text> ().text = Options [i];
		}

	}

	//Display + Shuffle Player2 Options
	void optionTxt2(){
	
		Shuffle (Options);
		for (int i = 0; i < 4; i++) {	
			OptArray2 [i].GetComponentInChildren<Text> ().text = Options [i]; 
		}
	}

	void Shuffle(String[] a){
		// Loops through array
		for (int i = a.Length-1; i > 0; i--) {
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = UnityEngine.Random.Range (0, i);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			String temp = a [i];
			
			// Swap the new and old values
			a [i] = a [rnd];
			a [rnd] = temp;
		}
	}

/* ------------------------------------------ End of Randomise Options -----------------------------------------------------*/


/* ------------------------------------------ Randomise Qns (Without Duplicate)---------------------------------------------*/
	void randQns(){
		ShuffleQns (QnsNo);
	}

	void QnsCall(){
		if (x > 13) {
			x = 0;
			no = QnsNo [x];
		} else {
			no = QnsNo [x];
			x++;
		}
	}

	void ShuffleQns(int[] b){
		// Loops through array
		for (int i = b.Length-1; i > 0; i--) {
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = UnityEngine.Random.Range (0, b.Length);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			int temps = b [i];
			
			// Swap the new and old values
			b [i] = b [rnd];
			b [rnd] = temps;
		}
	}

/* ------------------------------------------ End of Randomise Qns -------------------------------------------*/
	IEnumerator LoadAfterDelay(string levelname){
		
		if (P1health.hp <= 0) {
			yield return new WaitForSeconds(2); 
			Application.LoadLevel ("P2WIN");
			PlayerPrefs.SetString("StageName", Application.loadedLevelName);
		}
		if (P2health.hp < 0) {
			yield return new WaitForSeconds(2); //Wait for 2 seconds
			Application.LoadLevel ("P1WIN");
			PlayerPrefs.SetString("StageName", Application.loadedLevelName);
		}
	}
	
	public void Wait(){
		StartCoroutine (LoadAfterDelay ("GameOver"));
	}


	void Update(){
		Wait ();
	}

	//Script reference from SlotForAns2
	public SlotForAns2 slot4ans2;


/* ------------------------------------------ OptionBox(P1)-------------------------------------------*/
	public GameObject OptBox1;
	public GameObject O1,O2,O3,O4;

	public void HideOptBox1(){
		OptBox1.SetActive (false);
	}

	public void ShowOptBox1(){
		OptBox1.SetActive(true);
	}

/* ------------------------------------------ OptionBox(P2)-------------------------------------------*/

	public GameObject OptionBox2;
	public GameObject P1,P2,P3,P4;

	public void HideOptBox2(){
		OptionBox2.SetActive(false);
	}

	public void ShowOptBox2(){
		OptionBox2.SetActive(true);
	}


/* ------------------------------------------TIMER GAMEOBJECT-------------------------------------------*/

	public GameObject T1,T2;


}
