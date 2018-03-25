using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBall2 : MonoBehaviour {

	public float maxSpeed =  420f;
	public GameObject fireBall;
	public float fireRate = 1.5F;
	private float nextFire = 0.0F;
	
	public void Update() {
		if (Input.GetMouseButton (0) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			createShot ();
		}
	}

	public void createShot ()
	{
			Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
			Vector2 myPos = new Vector2(transform.position.x,transform.position.y + 1);
			Vector2 direction = target - myPos;
			direction.Normalize();
			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
			GameObject projectile = (GameObject) Instantiate( fireBall, myPos, rotation);
			projectile.GetComponent<Rigidbody2D>().velocity = direction * maxSpeed;
}
}	