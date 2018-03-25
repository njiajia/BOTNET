using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Laser : MonoBehaviour {
	
	public float maxSpeed = 20f;
	public Rigidbody2D enemyLaser;
	
	public void Update() {
		if (Input.GetKeyDown (KeyCode.L)) {
			Debug.Log ("ENEMY HAS FIRED");
			createShot ();
		}
	}
	
	
	public void clicked(){
		createShot ();
	}
	
	public void createShot ()
	{
		Rigidbody2D bulletInstance = Instantiate(enemyLaser, transform.position, Quaternion.Euler(new Vector3(0,0,90))) as Rigidbody2D;
		bulletInstance.velocity = new Vector2(-maxSpeed, 0);
	}
}
