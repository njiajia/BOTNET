using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Gamesql : MonoBehaviour {

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
		TimerStart ();
		randQns ();
		QnsCall ();
		Debug.Log ("Started");
		ReadEntries ();
		LogGameItems ();
		optionTxt ();


	}
	
	public void activation(){
		timer = 1f;
 		QnsCall ();
		Debug.Log ("Started");
		ReadEntries ();
		LogGameItems ();
		optionTxt ();
	}


/* ------------------------------------------ Randomise Options (Without Duplicate)-------------------------------------------*/
	void optionTxt(){

		Shuffle (Options);
		for (int i = 0; i < 4; i++) {
			OptArray [i].GetComponentInChildren<Text> ().text = Options [i];
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
	//End of shuffle

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

	//Script reference from Health 
	public HealthStage2 userhealth; 
	public EnemyHealth enemyhealth;
	public Image timerPic;

	IEnumerator LoadAfterDelay(string levelname){

		if (userhealth.hp <= 0) {
			yield return new WaitForSeconds(2); 
			Application.LoadLevel ("GameOver");
		}
		if (enemyhealth.hp < 0) {
			yield return new WaitForSeconds(2); //Wait for 3 seconds
			Application.LoadLevel ("Stage3");
		}
	}


	public void Wait(){
		StartCoroutine (LoadAfterDelay ("GameOver"));
	}

	void FixedUpdate(){
		Debug.Log (timer);
		timerPic.fillAmount = timer;
		if (timer <= 0) {
			CancelInvoke ("decreaseTimer");
			if (enemyhealth.hp <= 0) {
				TimerStart();
			} else {
				slot4ans.wrongAttack();
				activation ();
				TimerStart ();
			}
		}
		Wait ();

	}

/* ------------------------------------------ TIMER AUTO-ATTACK-------------------------------------------*/
	public SlotForAns slot4ans;


	public float timer = 1f;
	public float gg = 0.15f;

	void decreaseTimer(){
		timer-= gg;
	}

	void TimerStart(){
		InvokeRepeating ("decreaseTimer", 1.0f, 1.0f);
	}

}
