using UnityEngine;
using System;
using System.Collections;

public class Enemy : MonoBehaviour {

	[Serializable]public class EnemyStats{
		public int health = 100;
	}
	public EnemyStats stats = new EnemyStats();
	

	public void DamageEnemy (int damage){
		stats.health -= damage;
		if(stats.health <= 0){
			GameMaster.KillEnemy(this);
		}
	}
	// Use this for initialization
	void Start () {
		
	}

}
