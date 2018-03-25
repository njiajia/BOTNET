using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class WallText : MonoBehaviour {
	
	//Script reference from DestroyWall 
	public DestroyWall dw;
	
	//Script reference from SpriteTextSql;
	public SpriteTextSql sts;

	//Script reference from camShake
	public camShake cs;

	//Script reference from CDTimer
	public CDTimer cd;

	
	public Text[] T =  new Text[5]; //Text inside Images
	public string push; 
	public string z;
	
	public int i = 0;	
	public bool x;
	
	void Start () {
		dw = dw.GetComponent<DestroyWall>();
	}


	void Update () {
		
		T [i].GetComponentInChildren<Text> ().text = push;
		Activate ();
	}

	//Count up the array in order to insert data in another TxtImg
	public void count(){
		
		if (x == true) {
			i++;
		} else {
			x = true;
		}
	}


	public float timer = 3f; 
	public GameObject[] Walls;
	public GameObject[] TxImg;
	
	public void TimerStart(){
		InvokeRepeating ("decreaseTimer", 1.0f, 1.0f);
	}

	public void decreaseTimer(){
		timer--;
	}

	public void Activate(){

		if (i >= 4) {

			if (timer >0){
				TimerStart();
				cs.cameraShake ();
				cs.shakeTimer = 2f;

			}else{
				CancelInvoke("decreaseTimer");
				nextQns();
				timer = 3f;
			}
		} 

	}


	public void nextQns(){
			sts.checkAns();
			push = string.Empty;
			i = 0;
			ResetWallsTxt();
			ResetImgTxt();
			sts.reActivate ();
			cd.resetTimer ();

	}

	public void ResetWallsTxt(){
		//Set Walls(Bricks) Active (Reset)
		Walls[0].SetActive(true);
		Walls[1].SetActive(true);
		Walls[2].SetActive(true);
		Walls[3].SetActive(true);
		Walls[4].SetActive(true);
	}

	public void ResetImgTxt(){
		//Reset Text in Images
		TxImg[0].GetComponent<Text>().text = string.Empty;
		TxImg[1].GetComponent<Text>().text = string.Empty;
		TxImg[2].GetComponent<Text>().text = string.Empty;
		TxImg[3].GetComponent<Text>().text = string.Empty;
		TxImg[4].GetComponent<Text>().text = string.Empty;
	}
}
