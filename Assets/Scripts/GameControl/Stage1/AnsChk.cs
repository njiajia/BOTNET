using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

//

public class AnsChk : MonoBehaviour {

	public Image timerPic;
	public Button button1, button2, button3;
	public newsql newsql;

	public FireBall fb;
	public Laser laser;

	public Scoring scoring;

	public AudioClip FireBallSound, LaserSound, Explosion;
	public AudioSource source;	

	public Health userhealth; 
	public Enemy1Health enemyhealth;
	
	public float x = 0.05f ;
	float timer = 1;

	void Start(){
		TimerStart ();
		GameObject mc = GameObject.Find("MusicManager");
		Destroy (mc);
		
	}

	IEnumerator LoadAfterDelay(string levelname){

		if (userhealth.hp < 0 ) {
			Debug.Log("WAITING PLAYER KEEL");
			yield return new WaitForSeconds(2); 
			Application.LoadLevel ("GameOver");
		}
		if (enemyhealth.e1hp < 0) {
			source.PlayOneShot(Explosion);
			Debug.Log("WAITING ENEMY KEEL");
			yield return new WaitForSeconds(2); //Wait for 2 seconds
			Application.LoadLevel ("Stage2");
		}
	}

	public void Wait(){
		StartCoroutine (LoadAfterDelay ("GameOver"));
	}

	public void home(){
		Time.timeScale = 1;
		Application.LoadLevel ("Menu");
	}

	void Update(){
		timerPic.fillAmount = timer;
		if (timer <= 0) {
			CancelInvoke ("decreaseTimer");
			if (enemyhealth.e1hp <= 0) {
				TimerStart();
			} else {
				wrong ();
				newsql.activation ();
				TimerStart ();
			}
		}
		Wait ();

	}

	void decreaseTimer(){
		timer-=x;
	}

	void TimerStart(){
		timer = 1;
		InvokeRepeating ("decreaseTimer", 1f, 1f);
	}
	
	void Logger(){
		Debug.Log (newsql.Checker);
	}

	public void Check(){
		Logger ();
		if (button1.GetComponentInChildren<Text> ().text == newsql.Checker) {
			correct ();
		} else {
			wrong ();
		} 
	}

	public void Check1(){
		if (button2.GetComponentInChildren<Text> ().text == newsql.Checker) {
			correct ();
		} else {
			wrong ();
		}
	}
	
	public	void Check2(){
		if (button3.GetComponentInChildren<Text> ().text == newsql.Checker) {
			correct ();
		} else {
			wrong ();
		} 
	}

	void correct(){
		timer = 1;
		Debug.Log("Correct");
		source.PlayOneShot(FireBallSound);
		fb.clicked ();
		scoring.scoreUp();
	}
	
	void wrong(){
		timer = 1;
		Debug.Log("Wrong");
		source.PlayOneShot(LaserSound);
		laser.clicked ();
	}
}