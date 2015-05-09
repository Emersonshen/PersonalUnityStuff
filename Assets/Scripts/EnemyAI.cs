using UnityEngine;
using System.Collections;
using Pathfinding;


[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {
	public Transform target;
	public float updateRate = 2f;		//Pathing update rate
	public Path path;		
	public float speed = 300f;	//AI Speed
	public ForceMode2D fMode;
	public float nextDistance = 3;	//Max distance from a waypoint before moving to the next
	[HideInInspector]public bool pathHasEnded = false;
	public static bool respawned = false;
	public static Transform newTarget;
	//Caching
	Seeker seeker;
	Rigidbody2D rb;
	int currentWaypoint = 0;	//Current target waypoint index 



	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();
		if(target == null){
			return;
		}
		seeker.StartPath(transform.position, target.position, OnPathComplete);

		StartCoroutine(UpdatePath());
	}
	public void OnPathComplete(Path p){
		Debug.Log ("Pathing Complete, Error:" + p.error);
		if(!p.error){
			path = p;
			currentWaypoint = 0;
		}
	}
	IEnumerator UpdatePath(){
		if(target == null){
			return false;
		}
		seeker.StartPath(transform.position, target.position, OnPathComplete);
		yield return new WaitForSeconds(1/updateRate);
		StartCoroutine(UpdatePath());
	}
	void FixedUpdate(){
		if(target == null){
			if(respawned){
				target = newTarget;
				Start();
			}
			else
				return;
		}

		if(path == null)
			return;

		if(currentWaypoint >= path.vectorPath.Count){
			if(pathHasEnded)
				return;
			Debug.Log ("Path End");
			pathHasEnded = true;
			return;
		}
		pathHasEnded = false;

		//Find the direction to the waypoint
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		//Move the enemy
		rb.AddForce(dir, fMode);

		if(Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextDistance){
			currentWaypoint ++;
			return;
		}
	}
	public static void Respawn(Transform t){
		respawned = true;
		newTarget = t;
	}

}
