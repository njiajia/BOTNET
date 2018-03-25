using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	
	public static MusicManager instance;

	public static MusicManager Instance {
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
