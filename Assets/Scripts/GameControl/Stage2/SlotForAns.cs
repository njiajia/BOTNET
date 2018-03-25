using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SlotForAns : MonoBehaviour, IDropHandler {


	public AudioSource source;
	public AudioClip fireballsound, fly;

	//Script reference from Fireball
	public FireBall fireBall;
	
	//Script reference from Fireball
	public Missile missile;
	
	//Script reference from GameSql
	public Gamesql gamesql;
	
	//Script reference from GameSql
	public ResetOption resetOpt;
	
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
			
			if (y == gamesql.checker) {
				correctAttack ();
			} else {
				wrongAttack();
			}
		}
	}
	
	#endregion
	
	//String y
	string y = "";

	public Image ansslot;
		
//	public void submit(){
//	
//		y = ansslot.GetComponentInChildren<Text> ().text ;
//		//Debug.Log (ansslot.GetComponentInChildren<Text> ().text);
//
//		if (y == gamesql.checker) {
//			correctAttack ();
//		} else {
//			wrongAttack();
//		}
//
//	}


	public void wrongAttack(){

//		gamesql.timer = 1f;
		//Fire when option is choosen. 
		missile = missile.GetComponent<Missile> ();
		source.PlayOneShot(fly);
		missile.createShot ();

		resetOpt = resetOpt.GetComponent<ResetOption> ();
		resetOpt.reset ();

		gamesql.activation();
	}
	
	public void correctAttack(){

//		gamesql.timer = 1f;
		//add one point 
		scoreCount.correct ();
		
		//Fire when option is choosen. 
		fireBall = fireBall.GetComponent<FireBall> ();
		source.PlayOneShot(fireballsound);
		fireBall.createShot ();
		
		//reset the options back to original place. 
		resetOpt = resetOpt.GetComponent<ResetOption> ();
		resetOpt.reset ();

		gamesql.activation();
	}


	//Script reference from countScore 
	public countScore scoreCount;

	public void displayscoretext(){
		scoreCount = scoreCount.GetComponent<countScore>();

	}

}