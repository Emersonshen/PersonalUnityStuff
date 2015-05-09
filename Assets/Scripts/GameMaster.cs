using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;
	public Transform playerPrefab;
	public Transform spawnPoint;
	public int respawnTime = 2;
	public Transform particlePrefab;
	


	public static void KillPlayer(Player player){
		Destroy(player.gameObject);
		gm.StartCoroutine(gm.RespawnPlayer ());
	}

	public IEnumerator RespawnPlayer(){
		audio.Play ();
		yield return new WaitForSeconds(respawnTime);
		Transform respawn = (Transform)Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
		Transform clone = (Transform)Instantiate(particlePrefab, spawnPoint.position, spawnPoint.rotation);
		Camera2DFollow.ResetTarget(respawn);
		EnemyAI.Respawn (respawn);
		Destroy(clone.gameObject,3f);
	}
	// Use this for initialization
	void Start () {
		if(gm == null)
			gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
