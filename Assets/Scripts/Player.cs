using UnityEngine;
using System;
using System.Collections;

public class Player : MonoBehaviour {
	static Vector3 pos;

	[Serializable]public class PlayerStats{
		public int health = 100;
	}
	public PlayerStats playerStats = new PlayerStats();

	public int killFloor = -20;

	#region Properties

	static public Vector3 getPosition(){return pos;}


	#endregion

	public void DamagePlayer (int damage){
		playerStats.health -= damage;
		if(playerStats.health <= 0){
			GameMaster.KillPlayer(this);
		}
	}
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pos = this.transform.position;
		if(transform.position.y <= killFloor)
			DamagePlayer (100000000);
	}

}
