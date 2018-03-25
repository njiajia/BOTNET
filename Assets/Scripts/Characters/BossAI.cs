using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

//	public GameObject player;
//	public float speed;
//	
//	void FixedUpdate () {
//		if (player.transform.position.x > transform.position.x) {
//			GetComponent<Rigidbody2D>().velocity = new Vector3 (speed, 0f, 0f);
//		}
//		if (player.transform.position.x < transform.position.x) {
//			GetComponent<Rigidbody2D>().velocity = new Vector3 (-speed, 0f, 0f); 
//		}
//	}

	private float useSpeed;
	public float directionSpeed = 0f;
	float origX;
	public float distance = 0f;
	
	// Use this for initialization
	void Start ()
	{
		origX = transform.position.x;
		useSpeed = -directionSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(origX - transform.position.x > distance)
		{
			useSpeed = directionSpeed; //flip direction
		}
		else if(origX - transform.position.x < -distance)
		{
			useSpeed = -directionSpeed; //flip direction
		}
		transform.Translate(useSpeed*Time.deltaTime, 0,0);
	}
}
