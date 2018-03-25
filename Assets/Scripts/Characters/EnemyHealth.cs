using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	Animator anim;
	public Image healthBar;
	public float hp = 1f;

	void Start (){
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
	
		healthBar.fillAmount = hp;
		anim.SetFloat ("hp", hp);
		if (Input.GetKeyDown (KeyCode.G)) {
			Debug.Log("10 Damage");
			damage ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Debug.Log ("HAND OF GOD");
			hp = hp + 0.1f;
		}
	}

	public void damage(){
		hp = hp - 0.3f;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Bullet")) {
			Debug.Log ("It's a hit");
			hp = hp - 0.2075f;

		}
	}
}
