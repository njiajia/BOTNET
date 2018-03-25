using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerTwo : MonoBehaviour {


	public float timer2 = 1f;
	public Image clock2;

	//Script reference from camShake
	public camShake cs;

	//Script reference from GameSqlM
	public GamesqlM gamesqlM;

	//Script reference from Fireball
	public FireBall fireBall;

	public void FixedUpdate(){
		countdown ();
	}

	public void countdown(){

		if (timer2 > 0) {
			timer2 -= 0.002f; //10sec
		} 

		if (timer2 < 0) {
			//fireBall.createShot ();
			gamesqlM.activation();
		}

		clock2.fillAmount = timer2; 

	}

	public void resetClock2(){
		timer2 = 1f;
	}

}
