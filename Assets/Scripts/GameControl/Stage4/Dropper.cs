using UnityEngine;
using System.Collections;

public class Dropper : MonoBehaviour {
	
	public Rigidbody2D [] drop = new Rigidbody2D[2];
	public float maxSpeed = 300f;
	int a;
	
	void Spawn ()
	{
		Rigidbody2D dropInstance = Instantiate(drop[a], transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D ;
		Debug.Log ("Dropped");
		dropInstance.velocity = new Vector2(0 ,-maxSpeed);
	}

	void Update (){
		a = Random.Range (0, 2);
	}

	void Start ()
	{
		InvokeRepeating("Spawn",  Random.Range(3.0F, 5.0F), Random.Range(3.0F, 5.0F));
	}
}
