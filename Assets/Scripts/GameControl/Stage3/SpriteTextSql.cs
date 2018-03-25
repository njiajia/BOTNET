using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpriteTextSql : MonoBehaviour {

//	public AudioClip FireBallSound, LaserSound, Explosion;
//	public AudioSource source;

	// values to match the database columns
	int ID, correct = 0;
	string kw1, kw2, kw3, kw4, kw5, correctAns;
		
	// for checking answer.
	public string checker; 
	
	//Array List of Options with string Datatype. 
	public TextMesh[] Options = new TextMesh[5]; 
	
	//Gameobject for arraylist of Options
	public GameObject[] OptArray; 
	
	// MySQL instance specific items
	string constr = "Server=127.0.0.1;Database=demo;User ID=root;\tPassword=password;Pooling=true";
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
		public int ID;
		public string kw1, kw2, kw3, kw4, kw5, correctAns;
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
			query = "SELECT * FROM stage3 where ID="+no ;
			if (con.State.ToString () != "Open")
				con.Open ();
			using (con) {
				using (cmd = new MySqlCommand(query, con)) {
					rdr = cmd.ExecuteReader ();
					if (rdr.HasRows)
					while (rdr.Read()) {
						data itm = new data ();
						itm.ID = int.Parse (rdr ["ID"].ToString ());
						itm.kw1 = rdr ["kw1"].ToString();
						itm.kw2 = rdr ["kw2"].ToString ();
						itm.kw3 = rdr ["kw3"].ToString ();
						itm.kw4 = rdr ["kw4"].ToString ();
						itm.kw5 = rdr ["kw5"].ToString ();
					
						itm.correctAns = rdr ["correctAns"].ToString ();
						
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
			Options[0].GetComponent<TextMesh>().text  = itm.kw1; 
			Options[1].GetComponent<TextMesh>().text  = itm.kw2;
			Options[2].GetComponent<TextMesh>().text  = itm.kw3;
			Options[3].GetComponent<TextMesh>().text  = itm.kw4;
			Options[4].GetComponent<TextMesh>().text  = itm.kw5;
			checker = itm.correctAns;

		}
		
	}


	void Start()
	{
//		Renderer renderer = GetComponent<Renderer> ();
		Options = GetComponentsInChildren<TextMesh>();
		randQns ();
		QnsCall ();
		Debug.Log ("Started");
		ReadEntries ();
		shuffleOptTxt ();
		LogGameItems ();
	}

	
	//Script reference from WallText
	public camShake cs;

	public void reActivate(){
		QnsCall ();
		ReadEntries ();
		shuffleOptTxt ();
		LogGameItems ();
	}



	/* Randomise ------------------------------------------------------------------*/
	void shuffleOptTxt(){

		Shuffle (Options);
		for (int i = 0; i < 5; i++) {
			OptArray [i].GetComponentInChildren<TextMesh> ().text = Options [i].GetComponent<TextMesh>().text;
		}
	}


	void Shuffle(TextMesh[] a){
		// Loops through array
		for (int i = a.Length-1; i > 0; i--) {
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = UnityEngine.Random.Range (0, i);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			TextMesh temp = a [i];

			// Swap the new and old values
			a [i] = a [rnd];
			a [rnd] = temp;
		}

	}

//
//	/* End Randomise ------------------------------------------------------------------*/


/* ------------------------------------------ Randomise Qns (Without Duplicate)---------------------------------------------*/
	void randQns(){
		ShuffleQns (QnsNo);
	}

	void QnsCall(){
		if (x >= 15) {
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

	//Script reference from WallText
	public WallText wt;

	//Script reference from Health
	public Stage3Health hp;

	//Script reference from Score
	public Stage3Score scoring;

	int x, no;

	int[] QnsNo = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
	

	public void checkAns(){

		if (wt.T [0].text.ToString() + wt.T [1].text.ToString() +
		    wt.T [2].text.ToString() + wt.T [3].text.ToString() +
		    wt.T [4].text.ToString() == checker) {

		//Correct

			scoring.correct(); //add pts
			wt.x = false;
			correct++;
			Debug.Log ("Correct");

		} else {

		//Wrong
			wt.x = false;
			hp.damage();
			Debug.Log ("Wrong");

		}

	}
	
	void Update(){
		if (correct >= 5) {
			Application.LoadLevel("Stage4");
		}
		if (Input.GetKeyDown ("space")) {
			correct = 5;
		}

	}


}
