using UnityEngine;

[ExecuteInEditMode]
public class PixelDensityCamera : MonoBehaviour {

	public float pixelsToUnits = 100;

	void Update () {

		GetComponent<Canvas>().scaleFactor = Screen.height / pixelsToUnits / 2;
	}
}
