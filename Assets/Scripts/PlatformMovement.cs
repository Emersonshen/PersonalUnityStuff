using UnityEngine;
using System.Collections;



public enum Direction{
	UP		=0x0,
	DOWN	=0x1,
	LEFT	=0x2,
	RIGHT	=0x3
}


public class PlatformMovement : MonoBehaviour {
	
	Rigidbody2D rb;
	Vector3 startPos;
	Vector3 destination;

	float dist;
	Vector3 dir;
	bool backFore = false;
	float turnDistance = 0.1f;

	[BitMaskAttribute(typeof(Direction))]
	public int Direction = 0;//0 - Up; 1 - Down; 2 - Left; 3 - Right;

	public float speed = 5f;
	public float distance = 10f;
	public ForceMode2D fMode;
	

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		startPos = transform.position;
		switch (Direction) {
			case 0: //Up
				destination = new Vector3 (startPos.x, startPos.y + distance);
				dir = Vector3.up;
				break;
			case 1: //Down
				destination = new Vector3 (startPos.x, startPos.y - distance);
				dir = Vector3.down;
				break;
			case 2: //Left
				destination = new Vector3 (startPos.x - distance, startPos.y);
				dir = Vector3.left;
				break;
			case 3: //Right
				destination = new Vector3 (startPos.x + distance, startPos.y);
				dir = Vector3.right;
				break;
			default: //Nothing
				break;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {//		

//		Vector3 dir;
		if (!backFore) {
			dist = Vector3.Distance (transform.position, destination);
		} 
		else {
			dist = Vector3.Distance(transform.position, startPos);
		}
			
		//		dir *= speed * Time.fixedDeltaTime;
		transform.Translate (speed * dir * Time.fixedDeltaTime, Space.World);
		if (dist <= turnDistance) {
			backFore = !backFore;
			dir *= -1f;
			return;
		}
	}	
}
