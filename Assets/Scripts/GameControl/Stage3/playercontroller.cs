using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	Vector3 target;
	private Animator anim;
	public float moveForce = 350f;

	[HideInInspector] public bool facingRight = true;
	private Rigidbody2D rb2d;
	float speed; //for animation

	void Awake () 
	{	
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
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
