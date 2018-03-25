using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBall : MonoBehaviour {

	public float maxSpeed = 20f;
	public Rigidbody2D fireBall;
	
	public void Update() {
		if (Input.GetKeyDown (KeyCode.F)) {
			Debug.Log ("FIRE");
			createShot ();
		}
	}


	public void clicked(){
		createShot ();
	}

	public void createShot ()
	{
		Rigidbody2D bulletInstance = Instantiate(fireBall, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
		bulletInstance.velocity = new Vector2(maxSpeed, 0);
}
}