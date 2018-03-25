using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

	
	public Stage4health userhealth; 
	public bossHP enemyhealth;
	public Text scoreText;

	public GameObject Boss, LaserEx, LaserFast, hpBar, dropper1, dropper2, dropper3, dropper4, droplet, dropletCorrect, dialogue2;
	public static int CollectCounter = 0;
	float time, totalscore, playerHP, bosshealth;
	int score;
	public bool x = false, y = true;


	public void Bossinactive(){
		Boss.SetActive(false);
		LaserEx.SetActive(false);
		LaserFast.SetActive(false);
		hpBar.SetActive (false);
	}

	public void BossActive(){
		Debug.Log ("Boss is activated");
		Boss.SetActive(true);
		LaserEx.SetActive(true);
		LaserFast.SetActive(true);
		hpBar.SetActive(true);
	}

	public void dropGo(){
		suprise ();
		Debug.Log ("Drop is Go");
		dropper1.SetActive(true);
		dropper2.SetActive(true);
		dropper3.SetActive(true);
		dropper4.SetActive(true);
		droplet.SetActive (true);
		dropletCorrect.SetActive (true);
	}

	void dropStop(){
		Debug.Log ("Drop is No Go");
		dropper1.SetActive(false);
		dropper2.SetActive(false);
		dropper3.SetActive(false);
		dropper4.SetActive(false);
		droplet.SetActive (false);
		dropletCorrect.SetActive (false);
	}

	void Start () {
		LaserEx.SetActive(true);
		LaserFast.SetActive(true);
		dropper1.SetActive(false);
		dropper2.SetActive(false);
		dropper3.SetActive(false);
		dropper4.SetActive(false);
		droplet.SetActive (false);
		dropletCorrect.SetActive (false);
		dialogue2.SetActive (false);
		score = PlayerPrefs.GetInt("Scoring4");
	}

	public void hitCounterUp(){
		CollectCounter++;
	}

	void FixedUpdate(){
		Debug.Log (totalscore);
		if (Input.GetKeyDown ("l")) {
			CollectCounter = 10;
		}
		if (CollectCounter >= 10 && x == false) {
			x = true;
			dropStop();
			BossActive();
		}

		if (CollectCounter >= 10 && y == false) {
			y = true;
			dropStop();
			BossActive();
		}
		time+=0.1f;
		PlayerPrefs.SetFloat("ScoringFinal", totalscore);
		Wait ();
		if (time <= 280) {
			scoreText.text = "Score Multiplier: X2";
		} else if (time <= 450 && time >= 280) {
			scoreText.text = "Score Multiplier: X1.5";
		} else if (time >= 450) {
			scoreText.text = "Score Multiplier: X1.2";
		}
	}
	public void bosskill(){
		if (time <= 280) {
			totalscore = score * 2;
		} else if (time <= 450 && time >= 280) {
			totalscore = score * 1.5f;
		} else if (time >= 450) {
			totalscore = score * 1.2f;
		}
	}

	void PlayerKill(){
		totalscore = score;
	}

	IEnumerator LoadAfterDelay(string levelname){
		
		playerHP = userhealth.hp;
		bosshealth = bossHP.BossHP;
		
		if (playerHP <= 0) {
			yield return new WaitForSeconds(2); 
			Application.LoadLevel ("GameOver");

		}
		if (bosshealth < 0) {
			Bossinactive();
			bosskill();
			yield return new WaitForSeconds(2); //Wait for 2 seconds
			Application.LoadLevel ("GameOver");
		}
	}

	public void Wait(){
		StartCoroutine (LoadAfterDelay ("GameOver"));
	}

	void suprise(){
		Time.timeScale = 0;
		dialogue2.SetActive (true);
	}

	public void understood(){
		Time.timeScale = 1;
		dialogue2.SetActive (false);
	}
}

