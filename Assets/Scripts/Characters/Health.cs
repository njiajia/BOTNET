using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	Animator anim;
	public Image healthBar;
	public float hp ;
	public Scoring scorer;

	void Start (){
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = hp;
		anim.SetFloat("hp", hp);
		PlayerPrefs.SetFloat("health", hp);
		if (hp <= 0) {
			PlayerPrefs.SetFloat("ScoringFinal", scorer.scoreInt);
		}
	}

	public void damage(){
		hp = hp - 0.1f;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Bullet")) {
			Debug.Log ("You have been hit!!!");
			damage ();
			
		}
	}
}

