using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class DestroyWall : MonoBehaviour {

	public string Txt;

	//Script reference from WallText
	public WallText wt;

	//Script reference from WallText
	public SpriteTextSql sts;


	public void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Bullet")) {
		
		//Store the text data into string Txt
		Txt = GetComponentInChildren<TextMesh>().text;

			//push the text data from another script into Txt in wt;
			wt.push = Txt;

			wt.count ();

			//Destroy (gameObject);
			gameObject.SetActive(false);

		}


	}

}