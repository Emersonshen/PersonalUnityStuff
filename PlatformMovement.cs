using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	Rigidbody2D rb;
	Vector3 startPos;
	Vector3 destination;
	float distY = 0;
	bool upDown = false;

	public bool direction = false;
	public float speed = 100f;
	public float distance = 10f;
	public ForceMode2D fMode;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		startPos = transform.position;
		if(upDown)
			destination = new Vector3 (startPos.x, startPos.y + distance);
		else
			destination = new Vector3 (startPos.x, startPos.y - distance);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		
		Vector3 dir;
		if (!direction) {
			dir = (destination - transform.position).normalized;
			distY = Vector3.Distance (transform.position, destination);
		} 
		else {
			dir = (startPos - transform.position).normalized;
			distY = Vector3.Distance(transform.position, startPos);
		}
			
		dir *= speed * Time.fixedDeltaTime;
		rb.AddForce (dir, fMode);
		if (distY <= 0.1) {
			direction = !direction;
			return;
		}
		//distY = Vector3.Distance(transform.position, destination);
//		if(distY <= 0){
//			direction = !direction;
//			startPos = destination;
//			return;
//		}
	}	
}
