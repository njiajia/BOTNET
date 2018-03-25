using UnityEngine;
using System.Collections;

public class DestroyOther : MonoBehaviour {

	public int destroyed;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyed);
	}
}
