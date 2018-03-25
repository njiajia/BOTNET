using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
	
	public class SQLcontroller : MonoBehaviour {
		
		
		public static string correct,wrong;
		int no;

		// MySQL instance specific items
		string constr = "Server=127.0.0.1;Database=demo;User ID=root;Password=password;Pooling=true";
		// connection object
		MySqlConnection con = null;
		// command object
		MySqlCommand cmd = null;
		// reader object
		MySqlDataReader rdr = null;
		// object definitions
		public struct data
		{
			public int ID;
			public string Correct, Wrong;
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
			string query = string.Empty;
			if (_GameItems == null)
				_GameItems = new List<data>();
			if (_GameItems.Count > 0)
				_GameItems.Clear();
			// Error trapping in the simplest form
			try
			{
				query = "SELECT * FROM dropper WHERE ID =" + no ;
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
							itm.ID = int.Parse(rdr["ID"].ToString());
							itm.Correct = rdr["Correct"].ToString();
							itm.Wrong = rdr["Wrong"].ToString();
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
			}
		}
		
		public void LogGameItems()
		{
			foreach (data itm in _GameItems) {
				correct = itm.Correct;
				wrong = itm.Wrong;
			}
		}
	public void CloseCon(){
		OnApplicationQuit ();
	}

	void Start(){
		no = UnityEngine.Random.Range (1, 5);
		ReadEntries ();
		LogGameItems ();
	}

	void Update(){
		no = UnityEngine.Random.Range (1, 9);
		ReadEntries ();
		LogGameItems ();
	}
}
