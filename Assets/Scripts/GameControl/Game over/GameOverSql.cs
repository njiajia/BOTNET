using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameOverSql : MonoBehaviour {

	// values to match the database columns
	int sID, score;
	string pname; 

	public Text score1, highscore;

	// MySQL instance specific items
	string constr = "Server=127.0.0.1;Database=demo;User ID=root;Password=password;Pooling=true;Allow User Variables=True";
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
		public int score;
		public string pname; 
	}
	
	// collection container
	List<data> _GameItems;
	
	void Awake ()
	{
		try {
			// setup the connection element
			con = new MySqlConnection (constr);
			
			// lets see if we can open the connection
			con.Open ();
			//Debug.Log ("Connection State: " + con.State);
		} catch (Exception ex) {
			Debug.Log (ex.ToString ());
		}

	}
	
	// Shutdown database connection 
	void OnApplicationQuit ()
	{
		//Debug.Log ("killing con");
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
			query = "SELECT * from scoring" ;
			if (con.State.ToString () != "Open")
				con.Open ();
			using (con) {
				using (cmd = new MySqlCommand(query, con)) {
					rdr = cmd.ExecuteReader ();
					if (rdr.HasRows)
					while (rdr.Read()) {
						data itm = new data ();

						itm.score = int.Parse(rdr ["score"].ToString ());
						itm.pname = rdr ["pname"].ToString ();

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
		
			pname = itm.pname; 
			highscore.text = itm.score.ToString();
		}
		
	}

	public GameObject gameController;

	void Start ()
	{
		 //get value from scoring
		score1.text = PlayerPrefs.GetFloat("ScoringFinal").ToString();
		Debug.Log ("Started");
		ReadEntries ();
		LogGameItems ();

	}

/*-------------------------------- Insert Data ------------------------------------------------*/	
	    void InsertEntries()
	    {

	        string query = string.Empty;
	        // Error trapping in the simplest form
	        try
	        {
			query = "INSERT INTO scoring (score, pname) VALUES ("+PlayerPrefs.GetFloat("ScoringFinal")+", '"+pname+"')";
	            if (con.State.ToString() != "Open"){
	                con.Open();
				cmd = new MySqlCommand(query, con);
				cmd.ExecuteNonQuery();
				Debug.Log("Data Inserted");
				}
	        }
	        catch (Exception ex)
	        {
	            Debug.Log(ex.ToString());
				

	        }
	        finally
	        {
	        }
	    }

/*-------------------------------- End of Insert Data ------------------------------------------------*/	


/*-------------------------------- Store Player Name + Score ------------------------------------------------*/	

	string ssaveName;
	public Text tsaveName;
	public InputField saveField;
	public Text placeholderText;
	public Text ErrMsg;
	
	public void ConfirmName(){


		if (placeholderText.enabled == true) {
			Debug.Log ("Please Enter a Name");
			ErrMsg.text = "Please Enter a Name";

		} 
		else {
			ssaveName = saveField.text.ToString ();
			pname = ssaveName;
			InsertEntries ();
			ReadEntries ();
			Destroy(ErrMsg);
			GoMenu();
			Debug.Log ("Input Name: " + ssaveName);

		}	

	}


/*-------------------------------- End of Store Player Name ------------------------------------------------*/	

	public void GoMenu(){
		
		Application.LoadLevel("Menu");
	}

}


