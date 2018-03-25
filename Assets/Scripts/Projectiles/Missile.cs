using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public float maxSpeed = 350f;
	public Rigidbody2D missile;
	
	public void Update() {
		if (Input.GetKeyDown (KeyCode.Y)) {
			Debug.Log ("FIRE");
			createShot ();
		}
	}
	
	public void createShot ()
	{
		Rigidbody2D bulletInstance = Instantiate(missile, transform.position, Quaternion.Euler(new Vector3(0,0,-180))) as Rigidbody2D;
		bulletInstance.velocity = new Vector2(-maxSpeed, 0);
	}
}
