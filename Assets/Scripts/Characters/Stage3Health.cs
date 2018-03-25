using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stage3Health : MonoBehaviour {
	
	public Image healthBar;
	public float hp =1 ;
	public Stage3Score scorer;
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = hp;
		PlayerPrefs.SetFloat("health", hp);
		if (hp <= 0) {
			PlayerPrefs.SetFloat ("ScoringFinal", scorer.Scoring);
			Application.LoadLevel("GameOver");
		}
	}
	
	public void damage(){
		hp = hp - 0.1f;
		
	}
}

