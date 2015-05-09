using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] grounds;		//All objects to be parallaxed
	public float parallaxSmoothing = 0.5f;	//Parallax smoothing, Must be above 0

	float[] parallaxScales;		//Parallaxing Scales, same length as the graounds array
	Transform cam;		//Main Camera Transform
	Vector3 prevCamPos;  	//Previous Camera Position


	//Called before Start()
	void Awake(){
		cam = Camera.main.transform; //Set up camera reference

	}
	// Use this for initialization
	void Start () {
		prevCamPos = cam.position;

		parallaxScales = new float[grounds.Length];
		//Assign scales basec on the z position
		for (int i = 0; i < grounds.Length; i++) {
			parallaxScales[i] = (-1) * grounds[i].position.z;
		}

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < grounds.Length; i++) {
			//calculate the movment by multiplying the prev minus current by the scale
			float parallax = (prevCamPos.x - cam.position.x) * parallaxScales[i];	
			//create new position for grounds
			Vector3 groundTargetPos = new Vector3(grounds[i].position.x + parallax, grounds[i].position.y, grounds[i].position.z);

			//fade to new position
			grounds[i].position = Vector3.Lerp (grounds[i].position, groundTargetPos, parallaxSmoothing * Time.deltaTime);
		}
		//Update camera position
		prevCamPos = cam.position;
	}
}
