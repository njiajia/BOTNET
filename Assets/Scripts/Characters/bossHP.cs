using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bossHP : MonoBehaviour {
	
	public Image BossHPBar;
	public static float BossHP = 1f;
	public gameController gc;
	bool DropisGo = false;
	bool DropisGo2 = false;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Debug.Log ("Nuke");
			BossHP = BossHP-0.25f;
		}
		BossHPBar.fillAmount = BossHP;
		if (BossHP <= 0.75f && DropisGo == false) {
			gc.Bossinactive();
			gc.dropGo();
			DropisGo = true;
		}

		if (BossHP <= 0.45f && DropisGo2 == false) {
			gameController.CollectCounter = 0;
			gc.y = false;
			gc.Bossinactive();
			gc.dropGo();
			DropisGo2 = true;
		}

		if (Input.GetKeyDown ("enter")) {
			BossHP = -1f;
		}
	}

	public void damage(){
		BossHP = BossHP - 0.01f;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Bullet")) {
			Debug.Log ("It's a hit");
			damage ();
		}
	}
}