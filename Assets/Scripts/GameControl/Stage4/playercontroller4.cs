using UnityEngine;
using System.Collections;

public class playercontroller4 : MonoBehaviour {

	Vector3 target;
	private Animator anim;
	public float moveForce = 350f;
	[HideInInspector] public bool facingRight = true;
	float speed;
	Transform firePoint;

	void Awake () 
	{	
		anim = GetComponent<Animator>();
		firePoint = transform.FindChild ("firePoint");
	}

	void Start(){
		target = transform.position;
	}

	void Update(){
		anim.SetFloat ("Speed", speed);
		Movement ();
	}

	void Movement(){
		if (Input.GetKey(KeyCode.D)) {
			speed = 1;
			transform.Translate (Vector2.right * moveForce * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
		} else if (Input.GetKey(KeyCode.A)) {
			speed = 1;
			transform.Translate (Vector2.right * moveForce * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		} else {
			speed = 0;
		}
	}
}
