using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	public int offset = 90;
	// Update is called once per frame
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();

		float rotAngle = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler ( 0f, 0f ,rotAngle + offset);
	}
}
