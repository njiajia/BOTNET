using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//

public class AnsChk1MP : MonoBehaviour {
	public Button button1, button2, button3;
	public SQLMP1 sql;
	
	public FireBall fb;
	public Laser laser;

	public HealthMP1 P1health; 
	public HealthMP2 P2health;

//	public AudioClip FireBallSound, LaserSound, Explosion;
//	public AudioSource source;	

	string l;

	
	void Start(){
		GameObject mc = GameObject.Find("MusicManager");
		Destroy (mc);
	}

	IEnumerator LoadAfterDelay(string levelname){
		
		if (P1health.hp < 0) {
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

	public void Check(){
		if (button1.GetComponentInChildren<Text> ().text == SQLMP1.Checker) {
			if (sql.p1active == true) {
				correctp1 ();
			} else {
				correctp2 ();
			}
		} else {
			if (sql.p1active == true) {
				wrongp1 ();
			} else{
				wrongp2 ();
			}
		}
	}
	
	public void Check1(){
		if (button2.GetComponentInChildren<Text> ().text == SQLMP1.Checker) {
			if (sql.p1active == true) {
				correctp1 ();
			} else {
				correctp2 ();
			}
		} else {
			if (sql.p1active == true) {
				wrongp1 ();
			} else{
				wrongp2 ();
			}
		}
	}
	
	public void Check2(){
		if (button3.GetComponentInChildren<Text> ().text == SQLMP1.Checker) {
			if (sql.p1active == true) {
				correctp1 ();
			} else {
				correctp2 ();
			}
		} else {
			if (sql.p1active == true) {
				wrongp1 ();
			} else{
				wrongp2 ();
			}
		}
	}
	
	void correctp1(){
		Debug.Log("Player1 Correct");
		fb.createShot ();
//		source.PlayOneShot(FireBallSound);
	}
	
	public void wrongp1(){
		Debug.Log("Player1 Wrong");
		laser.createShot ();
//		source.PlayOneShot(LaserSound);
	}

	void correctp2(){
		Debug.Log("Player2 correct");
		laser.createShot ();
		//		source.PlayOneShot(LaserSound);
	}

	public void wrongp2(){
		Debug.Log("Player2 Wrong");
		fb.createShot ();
		//		source.PlayOneShot(LaserSound);
	}

	void Update(){
		Wait ();
	}
}