using UnityEngine;
using System.Collections;

public class dropletControllerWrong : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Bullet")) {
			gameController.CollectCounter += 1;
			Debug.Log("+1");
			Debug.Log (gameController.CollectCounter);
			Destroy (gameObject);
		}
	}
	
	void Start () {
		Destroy(gameObject, 25);
		GetComponentInChildren<TextMesh> ().text = SQLcontroller.wrong;
	}
	
	void Update(){
		if(gameController.CollectCounter >=10){
			Destroy (gameObject);
		}
	}
}
