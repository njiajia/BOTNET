using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SlotForAns2: MonoBehaviour, IDropHandler {


	public AudioSource source;
	public AudioClip fireballsound, fly;

	//Script reference from Fireball
	public FireBall fireBall;
	
	//Script reference from Fireball
	public Missile missile;
	
	//Script reference from GameSql
	public GamesqlM gamesqlM;
	
	//Script reference from GameSql
	public ResetOption resetOpt;

	//Script reference from GameSql
	public ResetOption2 resetOpt2;
	
	public GameObject item {
		get {
			if(transform.childCount>0){
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}
	

	#region IDropHandler implementation
	
	public void OnDrop (PointerEventData eventData)
	{
		
		if (!item) {
			
			Draggable.itemBeingDragged.transform.SetParent (transform);

			y = ansslot.GetComponentInChildren<Text> ().text ;
			//Debug.Log (ansslot.GetComponentInChildren<Text> ().text);
			
			if (y == gamesqlM.checker) {

				if(gamesqlM.x1==true){
					//P1CorrectAttack();
					P2CorrectAttack();
				}else{
					//P2CorrectAttack();
					P1CorrectAttack();
				}

			} else {

				if(gamesqlM.x1==true){
					//P1WrongAttack();
					P2WrongAttack();
				}else{
					//P2WrongAttack();
					P1WrongAttack();
				}

			}

		}
	}
	
	#endregion
	
	//String y
	string y = "";

	public Image ansslot;

/*------------------------------------PLAYER1 ATTACK--------------------------------------------------------*/

	public void P1CorrectAttack(){

		//Fire when option is choosen. 
		fireBall = fireBall.GetComponent<FireBall> ();
		source.PlayOneShot(fireballsound);
		fireBall.createShot ();

		//reset the options back to original place. 
		resetOpt = resetOpt.GetComponent<ResetOption> ();
		resetOpt.reset ();
		resetOpt2 = resetOpt.GetComponent<ResetOption2> ();
		resetOpt2.reset ();
		
		gamesqlM.activation();
	}

	public void P1WrongAttack(){
		//Fire when option is choosen. 
		missile = missile.GetComponent<Missile> ();
		source.PlayOneShot(fly);
		missile.createShot ();

		//reset the options back to original place. 
		resetOpt = resetOpt.GetComponent<ResetOption> ();
		resetOpt.reset ();
		resetOpt2 = resetOpt.GetComponent<ResetOption2> ();
		resetOpt2.reset ();
		
		gamesqlM.activation();
	}

/*------------------------------------PLAYER2 ATTACK--------------------------------------------------------*/

	public void P2CorrectAttack(){

		//Fire when option is choosen. 
		missile = missile.GetComponent<Missile> ();
		source.PlayOneShot(fly);
		missile.createShot ();

		//reset the options back to original place. 
		resetOpt = resetOpt.GetComponent<ResetOption> ();
		resetOpt.reset ();
		resetOpt2 = resetOpt.GetComponent<ResetOption2> ();
		resetOpt2.reset ();
		
		gamesqlM.activation();
	}

	public void P2WrongAttack(){
		//Fire when option is choosen. 
		fireBall = fireBall.GetComponent<FireBall> ();
		source.PlayOneShot(fireballsound);
		fireBall.createShot ();

		//reset the options back to original place. 
		resetOpt = resetOpt.GetComponent<ResetOption> ();
		resetOpt.reset ();
		resetOpt2 = resetOpt.GetComponent<ResetOption2> ();
		resetOpt2.reset ();
		
		gamesqlM.activation();
	}

}