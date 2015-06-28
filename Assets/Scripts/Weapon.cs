using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {


	public float fireRate = 0;
	public int damage = 10;
	public LayerMask toHit;
	public Transform bulletPrefab;
	public float bulletSpawnRate = 10;
	public Transform muzzleFlashPrefab;

	float timeToSpawnBullet = 0;
	float timeToFire = 0;
	Transform firePoint;

	void Awake(){
		firePoint = transform.FindChild ("Fire_Point");
		if (firePoint == null)
			Debug.LogError ("Fire Point does not Exist.");
	}
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {		
		if (fireRate == 0) {
			if(Input.GetButtonDown ("Fire1"))
				Shoot ();
		} 
		else {
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1/fireRate;
				Shoot ();
			}
		}
	}
	void Effect(){
		Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		Transform clone = (Transform)Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
		clone.parent = firePoint;
		float size = Random.Range (0.6f, 0.9f);
		clone.localScale = new Vector3(size, size,size);
		Destroy(clone.gameObject,0.02f);
	}
	void Shoot(){
		//Debug.Log ("Shoot");
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, toHit);
		audio.Play();
		if(Time.time >= timeToSpawnBullet){
			Effect();
			timeToSpawnBullet = Time.time + 1/bulletSpawnRate;
		}
		if (hit.collider != null) {
				
			Enemy enemy = hit.collider.GetComponent<Enemy>();
			if(enemy != null){
				Debug.Log ("You hit " + hit.collider.name + "and did " + damage + " damage.");
				enemy.DamageEnemy (damage);
			}
		}
	}
}
