using UnityEngine;
using System.Collections;

public class Turrets : MonoBehaviour {

	public float maxSpeed =  420f;
	public Rigidbody2D LaserEx;

	public void createShot ()
	{
		Rigidbody2D LaserExInstance = Instantiate(LaserEx, transform.position, Quaternion.Euler(new Vector3(0,0,-180))) as Rigidbody2D;
		LaserExInstance.velocity = new Vector2(0,-maxSpeed);
	}

	void Start(){
		InvokeRepeating ("createShot", 0.8f, 0.8f);
	}
}
