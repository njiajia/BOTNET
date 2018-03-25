using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stage4health : MonoBehaviour {

	Animator anim;
	public Image healthBar;
	public float hp ;
	
	void Start (){
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = hp;
		anim.SetFloat("hp", hp);
		PlayerPrefs.SetFloat("health", hp);
		if (hp <= 0) {
			Application.LoadLevel("GameOver");
		}
	}
	
	public void damage(){
		hp = hp - 0.1f;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("LASER")) {
			Debug.Log ("You have been hit!!!");
			damage ();
			
		}
	}
}
