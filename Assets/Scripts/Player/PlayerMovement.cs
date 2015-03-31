using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float Speed = 6f;

	Vector3 Movement;
	Animator Anim;
	Rigidbody PlayerRigidbody;
	int floorMask;
	float camRayLength = 100;

	void Awake() {
		this.tag = "Player";
		floorMask = LayerMask.GetMask ("Floor");
		Anim = GetComponent<Animator> ();

		PlayerRigidbody = GetComponent<Rigidbody> ();

		//Debug.Log ("Enabled" + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth> ().enabled);
	}

	void FixedUpdate() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move(h,v);
		Turning ();
		Animating (h,v);
	}

	void Move(float h, float v) {
		Movement.Set (h,0f,v);
		Movement = Movement.normalized * Speed * Time.deltaTime;
		PlayerRigidbody.MovePosition (transform.position + Movement);
	}

	void Turning() {
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			PlayerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v) {
		bool walking = h != 0f || v != 0f;
		Anim.SetBool ("IsWalking", walking);
	}

}
