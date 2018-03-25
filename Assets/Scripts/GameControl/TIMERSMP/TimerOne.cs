using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerOne : MonoBehaviour {


	public float timer1 = 1f;
	public Image clock1;

	//Script reference from camShake
	public camShake cs;

	//Script reference from GameSqlM
	public GamesqlM gamesqlM;

	//Script reference from Fireball
	public Missile missile;

	public void FixedUpdate(){
		countdown ();
	}

	public void countdown(){

		if (timer1 > 0) {
			timer1 -= 0.002f; //10sec
		} 

		if (timer1 < 0) {

			missile.createShot ();
			timer1 =1f;
			gamesqlM.activation();
//			cs.cameraShake();
		}

		clock1.fillAmount = timer1; 

	}

	public void resetClock1(){
		timer1 = 1f;
	}

}
