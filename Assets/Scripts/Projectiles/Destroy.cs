using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 8);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Enemy")) {
			Destroy(gameObject);
		}
		if (other.gameObject.CompareTag ("Player")) {
			Destroy(gameObject);
		}
		if (other.gameObject.CompareTag ("Wall")) {
			Destroy(gameObject);
		}
		if (other.gameObject.CompareTag ("Player2")) {
			Destroy(gameObject);
		}

}
}