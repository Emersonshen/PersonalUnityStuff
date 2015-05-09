using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2;		
	public bool hasRight = false;
	public bool hasLeft = false;
	public bool reverseScale = false;	//Object is not Tilable

	float spriteWidth = 0f;
	Camera cam;
	Transform myTransform;

	void Awake(){
		cam = Camera.main;
		myTransform = transform;
	}
	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> ();
		spriteWidth = sRenderer.sprite.bounds.size.x;

	}
	
	// Update is called once per frame
	void Update () {
		if (!hasLeft || !hasRight) {
			float camExtent = cam.orthographicSize * Screen.width/Screen.height;

			float edgeVisibleRight = (myTransform.position.x + spriteWidth/2) - camExtent;
			float edgeVisibleLeft = (myTransform.position.x - spriteWidth/2) + camExtent;

			if(cam.transform.position.x >= edgeVisibleRight - offsetX && !hasRight){
				MakeTile (1);
				hasRight = true;
			}
			else if(cam.transform.position.x <= edgeVisibleLeft + offsetX && !hasLeft){
				MakeTile(-1);
				hasLeft = true;
			}
		}
	}

	void MakeTile(int dir){
		Vector3 newPos = new Vector3(myTransform.position.x + spriteWidth * dir, myTransform.position.y, myTransform.position.z);

		Transform newTile = (Transform)Instantiate(myTransform, newPos, myTransform.rotation);

		//Fixes Seams
		if(reverseScale){
			newTile.localScale = new Vector3(newTile.localScale.x *-1, newTile.localScale.y, newTile.localScale.z);
		}
		newTile.parent = myTransform.parent;

		if (dir > 0) {
			newTile.GetComponent<Tiling> ().hasLeft = true;
		} 
		else {
			newTile.GetComponent<Tiling>().hasRight = true;
		}
	}
}
