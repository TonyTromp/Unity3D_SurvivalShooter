using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform Target;
	public float Smoothing = 5f;
	public Vector3 Offset;

	// Use this for initialization
	void Start () {
		Offset = transform.position - Target.position;
	
	}
	
	// Update is called every Physics Upadate
	void FixedUpdate () {
		Vector3 targetCampos = Target.position + Offset;
		transform.position = Vector3.Lerp (transform.position, targetCampos, Smoothing * Time.deltaTime);
	}
}
