using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D CactusJones;

	public GameObject CactusJones2;

	// Particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	// Respawn Delay
	public float RespawnDelay;


	// Point Penalty on Death
	public int PointPenaltyOnDeath;

	// Stor Gravity Value
	private float GravityStore;



	// Use this for initialization
	void Start () {
		CactusJones = GameObject.Find("CactusJones").GetComponent<Rigidbody2D>();
		CactusJones2 = GameObject.Find("CactusJones");
	}
	
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}
	
	public IEnumerator RespawnPlayerCo(){
		// Genterate Death Paricle
		Instantiate (DeathParticle, CactusJones.transform.position, CactusJones.transform.rotation);
		// Hide CactusJones
		// CactusJones.enable = false;
		CactusJones2.SetActive(false);
		CactusJones.GetComponent<Renderer> ().enabled = false;
		// Gravity Reset
		GravityStore = CactusJones.GetComponent<Rigidbody2D>().gravityScale;
		CactusJones.GetComponent<Rigidbody2D>().gravityScale = 0f;
		CactusJones.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		// Debug Message
		Debug.Log ("CactusJones Respawn");
		// Respawn Dealay
		yield return new WaitForSeconds (RespawnDelay);
		// Gravity Restore
		CactusJones.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		// Match CactusJones's transform position
		CactusJones.transform.position = CurrentCheckPoint.transform.position;
		// Show CactusJones
		// CactusJones.enabled = true;
		CactusJones2.SetActive(true);
		CactusJones.GetComponent<Renderer> ().enabled = true;
		//Spawn CactusJones
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}
