using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SQLMP1 : MonoBehaviour {

	public GameObject t1, t2;
	public Image TimerP1, TimerP2;
	bool t = false;
	public float xtimer = 1f, timer;
	public AnsChk1MP anschk;
	private Image b1, b2, b3;
	public Sprite p1, p2;
	public bool p1active = true;
	public GameObject[] Button;
	string quest, Question;
	public static string Checker;
	int[] QnsNo = {1,2,3,4,5,6,7,8,9,10,11,12,13,14};
	string[] Options = new string[3];
	int ID, no, x = 0;
	public Text qns;
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
		public string Question, correct, wrong1, wrong2; 
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
			query = "SELECT * FROM view_demo WHERE ID =" +no ;
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
						itm.Question = rdr["Question"].ToString();
						quest = itm.Question;
						itm.wrong1 = rdr["wrong1"].ToString();
						itm.wrong2 = rdr["wrong2"].ToString();
						itm.correct = rdr["correct"].ToString(); 
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
			Debug.Log ("ID: " + itm.ID);
			qns.text = itm.Question;
			Options[0] = itm.correct;
			Checker = itm.correct;
			Options[1] = itm.wrong1;
			Options[2] = itm.wrong2;
		}
	}
	
	void randQns(){
		ShuffleQns (QnsNo);
	}
	
	void Start(){
		randQns ();
		b1 = Button[0].GetComponent<Image>();
		b2 = Button[1].GetComponent<Image>();
		b3 = Button[2].GetComponent<Image>(); 
		Cycle ();
	}
	
	public void click(){
		Cycle ();
		if (p1active == true) {
			p1active = false;
		} else {
			p1active = true;
		}
		Debug.Log (p1active);
	}

	void FixedUpdate(){
		if (p1active == true) {
			t1.SetActive(true);
			t2.SetActive(false);
			b1.sprite = p1;
			b2.sprite = p1;
			b3.sprite = p1;
			if ( t == false){
				timer = xtimer;
				t = true;
			}
			TimerP1.fillAmount = timer;
				timer -= 0.002f;
			if (timer <= 0) {
				anschk.wrongp1 ();
				p1active = false;
				Cycle();
			}
		} 
		if (p1active == false) {
			t1.SetActive(false);
			t2.SetActive(true);
			b1.sprite = p2;
			b2.sprite = p2;
			b3.sprite = p2;
			if ( t == true){
				timer = xtimer;
				t = false;
			}
			TimerP2.fillAmount = timer;
				timer -= 0.002f;
			if (timer <= 0) {
				anschk.wrongp2 ();
				p1active = true;
				Cycle();
			}
		}
	}

	void Qnscall(){
		if (x > 13) {
			x = 0;
			ShuffleQns (QnsNo);
			no = QnsNo [x];
		} else {
			no = QnsNo [x];
			x++;
		}
	}
	
	void Cycle(){
		Qnscall ();
		Debug.Log ("Started the SQL!!!");
		ReadEntries ();
		LogGameItems ();
		BtnTxt ();
	}
	
	void BtnTxt(){
		
		Shuffle (Options);
		for (int i = 0; i < 3; i++) {
			Button [i].GetComponentInChildren<Text> ().text = Options [i];
		}
	}
	void Shuffle(String[] a){
		// Loops through array
		for (int i = a.Length-1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = UnityEngine.Random.Range(0,2);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			String temp = a[i];
			
			// Swap the new and old values
			a[i] = a[rnd];
			a[rnd] = temp;
		}
		
	}
	
	void ShuffleQns(int[] b){
		// Loops through array
		for (int i = b.Length-1; i > 0; i--) {
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = UnityEngine.Random.Range (0, b.Length);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			int sterm = b [i];
			
			// Swap the new and old values
			b [i] = b [rnd];
			b [rnd] = sterm;
		}
	}
	
	public void CloseCon(){
		OnApplicationQuit ();
	}
	
	
}
