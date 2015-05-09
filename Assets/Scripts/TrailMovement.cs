using UnityEngine;
using System.Collections;

public class TrailMovement : MonoBehaviour {
	public int bulletSpeed = 230;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * Time.deltaTime * bulletSpeed);
		Destroy(gameObject, 1);
	}
}
