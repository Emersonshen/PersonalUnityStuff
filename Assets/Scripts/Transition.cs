using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {


	Vector3 door;
	Vector3 player;

	public int targetScene;

	// Use this for initialization
	void Start () {
		door = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlatformerCharacter2D.doorCheck()) {

		}
	}
}
