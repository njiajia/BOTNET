using UnityEngine;
using System.Collections;

public class PlayerDest : MonoBehaviour {

	public static PlayerDest instance;
	
	public static PlayerDest Instance {
		get { return instance; }
	}
	
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
			
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
