using UnityEngine;
using System.Collections;

public class Turret2 : MonoBehaviour {

	public float maxSpeed =  500f;
	public Rigidbody2D LaserFast;
	
	public void createShot ()
	{
		Rigidbody2D LaserExInstance = Instantiate(LaserFast, transform.position, Quaternion.Euler(new Vector3(0,0,-180))) as Rigidbody2D ;
		LaserExInstance.velocity = new Vector2(0,-maxSpeed);
	}
	
	void TimerStart(){
		InvokeRepeating ("createShot", 2.0f, 2.0f);
	}
	void Start(){
		TimerStart ();
	}
}
