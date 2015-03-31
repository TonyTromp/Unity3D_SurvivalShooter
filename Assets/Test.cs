using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	GameObject obj;
	// Use this for initialization
	void Start () {
		obj = GameObject.FindGameObjectWithTag ("MyTag");
		PlayerHealth pl = obj.GetComponent<PlayerHealth> ();


		Debug.Log ("IS?"+pl);
	}

	
	// Update is called once per frame
	void FixedUpdate () {



	}
}
