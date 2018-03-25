using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CDTimer : MonoBehaviour {
	

	public float countdownT = 1f;
	public Image clock;

	//Script reference from WallText
	public WallText wt;

	//Script reference from WallText
	public camShake cs;

	//Script reference from Health
	public Stage3Health hp;
		
	void FixedUpdate () {
		countDown ();
	}

	void countDown(){

			if (countdownT > 0) {
			countdownT -= 0.002f; //10sec
			} 
			if (countdownT < 0) {
				cs.cameraShake();
					if (cs.shakeTimer <= 0) {
					wt.nextQns ();
					hp.damage ();
					countdownT = 1f;
					cs.shakeTimer = 1f;
			}
			}
			clock.fillAmount = countdownT;
	
	}

	public void resetTimer(){
		countdownT = 1f;
	}

}
