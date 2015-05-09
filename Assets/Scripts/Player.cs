using UnityEngine;
using System;
using System.Collections;

public class Player : MonoBehaviour {


	[Serializable]public class PlayerStats{
		public int health = 100;
	}
	public PlayerStats playerStats = new PlayerStats();

	public int killFloor = -20;

	public void DamagePlayer (int damage){
		playerStats.health -= damage;
		if(playerStats.health <= 0){
			GameMaster.KillPlayer(this);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= killFloor)
			DamagePlayer (100000000);
	}
}
