using UnityEngine;
using System.Collections;

public class DestroyStage4 : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 8);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Enemy")) {
			Destroy(gameObject);
		}
		if (other.gameObject.CompareTag ("DropletCollect")) {
			Destroy(gameObject);
		}
		if (other.gameObject.CompareTag ("Droplet")) {
			Destroy(gameObject);
		}
}
}