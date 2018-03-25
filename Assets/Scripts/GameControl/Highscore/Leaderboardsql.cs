using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Leaderboardsql : MonoBehaviour {
	
	// values to match the database columns
	string pname, score; 
	
	public Text pname1, score1, rank1;

	int n;

	// For listing player score
	public GameObject ScoreEntryPrefab;	
	
	
	// MySQL instance specific items
	string constr = "Server=127.0.0.1;Database=demo;User ID=root;Password=password;Pooling=true;Allow User Variables = True";
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
		public string pname, score; 
	}
	
	// collection container
	List<data> _GameItems;
	
	void Awake()
	{
		try
		{
			// setup the connection element
			con = new MySqlConnection(constr);
			
			// lets see if we can open the connection
			con.Open();
			Debug.Log("Connection State: " + con.State);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
	}
	
	//Kill Database connection
	void OnApplicationQuit()
	{
		Debug.Log("killing con");
		if (con != null)
		{
			if (con.State.ToString() != "Closed")
				con.Close();
			con.Dispose();
		}
	}
	
	
	// Read all entries from the table
	public void ReadEntries()
	{
		for (n = 1; n <= 5; n++) {
			 
			string query = string.Empty;
			if (_GameItems == null)
				_GameItems = new List<data>();
			if (_GameItems.Count > 0)
				_GameItems.Clear();
			//Error trapping in the simplest form
			try
			{
				query = "SELECT * FROM (SELECT @rank:=@rank+1 AS rank,pname,score FROM scoring, (SELECT @rank:=0) r ORDER BY Score DESC) score_rank WHERE rank =" + n;
				if (con.State.ToString() != "Open")
					con.Open();
				using (con)
				{
					using (cmd = new MySqlCommand(query, con))
					{
						rdr = cmd.ExecuteReader();
						if (rdr.HasRows)
							while (rdr.Read())
						{
							data itm = new data();
							itm.pname = rdr["pname"].ToString();
							itm.score = rdr["score"].ToString();
							_GameItems.Add(itm);
							
						}
						rdr.Dispose();
					}
				} 
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
			}
			finally
			{
				LogGameItems ();
				GameObject go = (GameObject)Instantiate(ScoreEntryPrefab);
				go.transform.SetParent(this.transform, true);
			}
		}
	}


	//Retrieve the text values from database
	public void LogGameItems()
	{
		foreach (data itm in _GameItems) {
			pname1.text=itm.pname;
			score1.text=itm.score;
			rank1.text = n.ToString();
		}
	}
	
	
	//Display when game start
	void Start(){
		ReadEntries ();
		DontDestroyOnLoad(MusicManager.instance);
	}

	public void GoMenu(){
		Application.LoadLevel("Menu");
	}

}
