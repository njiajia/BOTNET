using UnityEngine;
using System.Collections;

public class camShake : MonoBehaviour {

	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	public float shakeTimer = 1f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 6f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;


	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}


	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}



	public void cameraShake(){
		if (shakeTimer > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shakeTimer -= Time.deltaTime * decreaseFactor;

		}
		else
		{
			shakeTimer = 0f;
			camTransform.localPosition = originalPos;

		}
	}

	public void reload(){
		shakeTimer = 1f;
	}
}


