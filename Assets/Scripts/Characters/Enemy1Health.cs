using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy1Health : MonoBehaviour {
	
	Animator anim;
	public Image healthBar;
	public float e1hp = 1f;
	public newsql closer;

	
	void Start (){
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = e1hp;
		anim.SetFloat("E1hp", e1hp);

	}
	
	public void damage(){
		e1hp = e1hp - 0.3f;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Bullet")) {
			Debug.Log ("It's a hit");
			damage ();
			
		}
}
}