using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthMP1 : MonoBehaviour {

	Animator anim;
	public Image healthBar;
	public float hp ;
	bool shake = false;
	public camShake cs;

	void Start (){
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = hp;
		anim.SetFloat ("hp", hp);
		if (shake == true) {
			cs.cameraShake ();
			if(cs.shakeTimer <=0){
				shake = false;
				cs.reload();
			}
		}
	}

	public void damage(){
		hp = hp - 0.1f;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Bullet")) {
			Debug.Log ("You have been hit!!!");
			shake = true;
			damage();
				}
			}
			
}


