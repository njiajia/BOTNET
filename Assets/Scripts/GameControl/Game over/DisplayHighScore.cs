using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour {

	public Text highscore;

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

	public void LogGameItems ()
	{
		foreach (data itm in _GameItems) {
			//pname = itm.pname; 
			highscore.text = itm.score.ToString();
		}
		
	}

/*-------------------------------- Display HighScore  ------------------------------------------------*/	

	public void readHighscore(){
		string query = string.Empty;
		
		if (_GameItems == null)
			_GameItems = new List<data>();
		if (_GameItems.Count > 0)
			_GameItems.Clear();
		
		// Error trapping in the simplest form
		try
		{
			query = "SELECT score FROM (SELECT @rank:=@rank+1 AS rank,pname,score FROM scoring, (SELECT @rank:=0) r ORDER BY Score DESC) score_rank WHERE rank = 1";
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
						itm.score = int.Parse(rdr ["score"].ToString ());
						_GameItems.Add(itm);
						
					}
					rdr.Dispose();
				}
			} 
		}
		catch (Exception ex) {
			Debug.Log (ex.ToString ());
		} finally {
		}
	}


/*-------------------------------- End of Display HighScore  ------------------------------------------------*/	

	void Update(){

		readHighscore ();
		LogGameItems ();
	}

	void Start(){
		GameObject mc = GameObject.Find("StageBGM");
		Destroy (mc);
	}
	

}
